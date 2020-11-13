using System.Windows.Forms;
using System;
using System.Diagnostics;
using System.Text.RegularExpressions;
using System.Drawing;
using System.Linq;
using System.Reflection;
using NaOtvet.ApiClient;
using NaOtvet.Core;
using System.Threading.Tasks;
using NaUrokApiClient;
using System.Media;

namespace NaOtvet
{
    public partial class MainForm : Form
    {        
        private readonly int threadsCount = 5;
        private readonly int finderIterationsCount = 500;

        private readonly LoadingForm loadingForm = new LoadingForm();
        private readonly Stopwatch stopwatch = new Stopwatch();

        private NaUrokClient client;
        private FinderSystem finderSystem;       
        
        private bool youtubeVideoOpened = false;

        private string youtubeTutorialUrl;
        private string youtubeChannelUrl;
        private WebSiteAccount naurokAccount;

        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            Task.Run(loadingForm.ShowDialog);

            try
            {
                if (!IsLastAppVersion())
                {
                    var oldVersionForm = new OldVersionForm();

                    loadingForm.Invoke(new Action(loadingForm.Close));
                    oldVersionForm.ShowDialog();

                    Environment.Exit(1);
                }

                LoadRemoteData();

                client = new NaUrokClient(naurokAccount.Login, naurokAccount.Password);
            }
            catch (Exception)
            {
                loadingForm.Invoke(new Action(loadingForm.Close));
                MessageBox.Show("Невозможно загрузить данные, возможно у вас нет доступа к интернету.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);

                Environment.Exit(1);
            }
        }

        private void MainForm_Shown(object sender, EventArgs e)
        {
            loadingForm.Invoke(new Action(loadingForm.Close));

            if (HelpClass.IsUserAdministrator() == false)
                MessageBox.Show("Если вы хотите, что бы программа работала быстрее, можете запустить её с правами администратора. Ей будет задан максимальный приоритет.", "Скорость работы", MessageBoxButtons.OK, MessageBoxIcon.Information);
            else
                Process.GetCurrentProcess().PriorityClass = ProcessPriorityClass.RealTime;

            TopMost = false;
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (finderSystem is null || finderSystem.IsStoped == true)
                return;

            var confirmationBoxResult = MessageBox.Show("Вы уверены, что хотите выйти?", "Подтверждение", MessageBoxButtons.YesNo);

            if (confirmationBoxResult == DialogResult.Yes)
                Stop();
            else
                e.Cancel = true;
        }


        private void StartButton_Click(object sender, EventArgs e)
        {
            if (UuIdText.Enabled)
                return;

            LogText.Clear();
            stopwatch.Restart();

            StartButton.Enabled         = false;
            ClearUuIdTextButton.Enabled = false;
            StopButton.Enabled          = true;

            try
            {
                if (finderSystem is null)
                {
                    finderSystem = new FinderSystem(client, UuIdText.Text, threadsCount, finderIterationsCount);
                    finderSystem.OnNewDocument += FinderSystem_OnNewDocument;
                    finderSystem.OnDocumentIsFound += FinderSystem_OnDocumentIsFound;
                    finderSystem.OnError += FinderSystem_OnError;

                    finderSystem.Start();
                }
                else
                {
                    finderSystem.Restart(UuIdText.Text);
                }
            }
            catch (Exception exception)
            {
                OnFatalError(exception);
            }
        }

        private void StopButton_Click(object sender, EventArgs e)
        {
            var confirmationBoxResult = MessageBox.Show("Вы уверены, что хотите остановить работу программы?", "Подтверждение", MessageBoxButtons.YesNo);
            
            if (confirmationBoxResult == DialogResult.Yes)
                Stop();
        }

        private void OpenTestButton_Click(object sender, EventArgs e)
        {
            Process.Start("https://naurok.com.ua/test/testing/" + UuIdText.Text);
        }

        private void JoinNaurokLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start("https://naurok.com.ua/test/join");
        }

        private void UuIdText_TextChanged(object sender, EventArgs e)
        {
            var textBox = (TextBox)sender;
            var uuIdRegexPattern = @"\w{8}-\w{4}-\w{4}-\w{4}-\w{12}";
            var uuIdRegex = new Regex(uuIdRegexPattern);
            var uuIdOnlyRegex = new Regex($@"\A{uuIdRegexPattern}\z");
            var urlOnlyRegex = new Regex($@"\A(https://)?naurok(\.com)?\.ua/test/(testing|realtime-client)/{uuIdRegexPattern}\z");

            if (textBox.Text == string.Empty && uuIdOnlyRegex.IsMatch(textBox.Text) == false)
            {
                OpenTestButton.Enabled = false;
                return;
            }

            if (urlOnlyRegex.IsMatch(textBox.Text) && uuIdRegex.IsMatch(textBox.Text))
            {
                textBox.Text = uuIdRegex.Match(textBox.Text).Value;
            }
            if (uuIdOnlyRegex.IsMatch(textBox.Text))
            {
                textBox.BackColor   = Color.LimeGreen;
                textBox.Enabled     = false;
                OpenTestButton.Enabled = true;
            }
            else
            {
                textBox.Text        = string.Empty;
                textBox.BackColor   = Color.Red;
                OpenTestButton.Enabled = false;
            }
        }

        private void ClearUuIdTextButton_Click(object sender, EventArgs e)
        {
            UuIdText.Text = string.Empty;
            UuIdText.BackColor = Color.FromKnownColor(KnownColor.Control);
            UuIdText.Enabled = true;
        }

        private void LogoImage_Click(object sender, EventArgs e)
        {
            Process.Start(youtubeChannelUrl);
        }

        private void GuidePage_Selected(object sender, TabControlEventArgs e)
        {
            if (!youtubeVideoOpened)
                youtubeVideoOpened = true;
            else
                return;

            Process.Start(youtubeTutorialUrl);
        }
        
        
        private bool IsLastAppVersion()
        {
            var lastVersion = NaOtvetApiClient.GetLastApplicationVersion().Version;
            var currentVersion = Assembly.GetExecutingAssembly().GetName().Version.ToString();

            return int.Parse(currentVersion.Replace(".", "")) >= int.Parse(lastVersion.Replace(".", ""));
        }

        private void LoadRemoteData()
        {
            var webLinks = NaOtvetApiClient.GetWebLinks(new string[] { "youtubeTutorial", "youtubeChannel" });
            youtubeTutorialUrl = webLinks.First(webLink => webLink.Name == "youtubeTutorial").Url;
            youtubeChannelUrl = webLinks.First(webLink => webLink.Name == "youtubeChannel").Url;
            naurokAccount = NaOtvetApiClient.GetWebSiteAccount("https://naurok.com.ua");
        }


        private void Stop()
        {
            finderSystem?.Stop();
            stopwatch.Stop();
                        
            StopButton.Enabled          = false;
            ClearUuIdTextButton.Enabled = true;
            StartButton.Enabled         = true;            
        }

        private void Log(string text)
        {
            if (LogText.InvokeRequired)
            {
                LogText.Invoke(new Action(() => Log(text)));
                return;
            }

            LogText.AppendText(text + Environment.NewLine);
        }

        private void LogError(string errorText)
        {
            Log("ОШИБКА: " + errorText);
        }

        private void ThrowFatalError(string errorText)
        {
            Stop();
            SystemSounds.Exclamation.Play();

            MessageBox.Show(errorText, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }


        private void OnFatalError(Exception exception)
        {
            if (HelpClass.IsInternetConnectionAvailable() == false)
            {
                ThrowFatalError("Нет доступа к интернету.");
                return;
            }

            try
            {
                throw exception;
            }
            catch (AnsweredQuestionException)
            {
                ThrowFatalError("Вы ответели на некоторые вопросы теста, по-этому программа не сможет найти ответы.");
            }
            catch
            {
                ThrowFatalError("Возникла неизвестная ошибка. Возможно, тест был завершён/не существует. Текст ошибки: " + exception.Message);                    
            }
        }

        private void FinderSystem_OnNewDocument(object sender, OnNewTestDocumentArgs args)
        {
            if ((sender as FinderSystem).TestIsFound == false)
            {
#if DEBUG
                Log(args.DocumentId.ToString());
#else
                Log(args.DocumentId.ToString().Last().ToString());
#endif
            }
        }

        private void FinderSystem_OnDocumentIsFound(object sender, OnTestDocumentIsFoundArgs args)
        {
#if DEBUG
            Log($"НАЙДЕНО: {args.DocumentId}.");
            Log($"Затрачено времени: {stopwatch.Elapsed}.");
            Log($"Проверено тестов: {finderSystem.CheckedDocumentsCount}");
#else
            Log($"НАЙДЕНО!");
            Log($"Затрачено времени: {stopwatch.Elapsed}.");
#endif

            this.Invoke(new Action(() =>
            {
                Stop();                
                SystemSounds.Asterisk.Play();

                var answersForm = new AnswersForm(args.TestSession);
                answersForm.TopMost = true;
                answersForm.Show();                
                answersForm.TopMost = false;
            }));
        }

        private void FinderSystem_OnError(object sender, OnErrorArgs args)
        {            
            this.Invoke(new Action(() => LogError(args.Exception.Message)));
        }
    }
}
