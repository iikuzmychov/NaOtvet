using System.Windows.Forms;
using System;
using System.Diagnostics;
using System.Text.RegularExpressions;
using System.Drawing;
using System.Linq;
using System.Reflection;
using NaOtvet.Api.Client;
using NaOtvet.Core;
using System.Threading.Tasks;
using NaUrokApiClient;
using System.Media;
using NaOtvet.Api.Models;
using System.Collections.Generic;

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
                ThrowFatalError("Невозможно загрузить данные, возможно у вас нет доступа к интернету");

                Environment.Exit(1);
            }
        }

        private void MainForm_Shown(object sender, EventArgs e)
        {
            loadingForm.Invoke(new Action(loadingForm.Close));
            TopMost = false;

            if (HelpClass.IsUserAdministrator() == false)
                MessageForm.Show("Если вы хотите, что бы программа работала быстрее, можете запустить её с правами администратора. Ей будет задан максимальный приоритет", "Скорость работы");
            else
                Process.GetCurrentProcess().PriorityClass = ProcessPriorityClass.RealTime;
        }
        
        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (finderSystem is null || finderSystem.IsStoped == true)
                return;
            
            var confirmationBoxResult = MessageForm.Show("Вы уверены, что хотите выйти?", "Подтверждение", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

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
            TestInfoButton.Enabled      = true;

            try
            {
                if (Cache.CacheObjects
                    .SolvedTestSessions
                    .Where(session => session.Value.UuId == UuIdText.Text)
                    .Count() == 1)
                {
                    var solvedSession = Cache.CacheObjects
                        .SolvedTestSessions
                        .First(session => session.Value.UuId == UuIdText.Text);

                    FinderSystem_OnDocumentIsFound(null, new OnTestDocumentIsFoundArgs(solvedSession.Key, solvedSession.Value));
                }
                else
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
            }
            catch (Exception exception)
            {
                OnFatalError(exception);
            }

            var testSession = finderSystem.GetTestSession();

            if (testSession != null && testSession.Duration.HasValue)
            {                
                splitContainer2.Panel2.Enabled = true;
                TestTimer.Start();
            }
        }

        private void StopButton_Click(object sender, EventArgs e)
        {
            var confirmationBoxResult = MessageForm.Show("Вы уверены, что хотите остановить работу программы?", "Подтверждение", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            
            if (confirmationBoxResult == DialogResult.Yes)
                Stop();
        }

        private void OpenTestButton_Click(object sender, EventArgs e)
        {            
            Process.Start("https://naurok.com.ua/test/testing/" + UuIdText.Text);
        }

        private void TestInfoButton_Click(object sender, EventArgs e)
        {
            new TestInfoForm(finderSystem.GetTestSession()).Show();
        }

        private void JoinNaurokLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start("https://naurok.com.ua/test/join");
        }

        private void ClearUuIdTextButton_Click(object sender, EventArgs e)
        {
            UuIdText.Text = string.Empty;
            UuIdText.BackColor = Color.FromArgb(30, 30, 30);
            UuIdTextPanel.BackColor = Color.FromArgb(30, 30, 30);
            UuIdTextPanel.Enabled = true;
        }

        private void LogoImage_Click(object sender, EventArgs e)
        {
            Process.Start(youtubeChannelUrl);
        }

        private void UuIdTextPanel_Click(object sender, EventArgs e)
        {
            UuIdText.Focus();
        }

        private void UuIdText_TextChanged(object sender, EventArgs e)
        {
            var uuIdRegexPattern = @"\w{8}-\w{4}-\w{4}-\w{4}-\w{12}";
            var uuIdRegex = new Regex(uuIdRegexPattern);
            var uuIdOnlyRegex = new Regex($@"\A{uuIdRegexPattern}\z");
            var urlOnlyRegex = new Regex($@"\A(https://)?naurok(\.com)?\.ua/test/(testing|realtime-client)/{uuIdRegexPattern}\z");

            if (UuIdText.Text == string.Empty && uuIdOnlyRegex.IsMatch(UuIdText.Text) == false)
            {
                OpenTestButton.Enabled = false;
                TestInfoButton.Enabled = false;
                return;
            }

            if (urlOnlyRegex.IsMatch(UuIdText.Text) && uuIdRegex.IsMatch(UuIdText.Text))
            {
                UuIdText.Text = uuIdRegex.Match(UuIdText.Text).Value;
            }
            if (uuIdOnlyRegex.IsMatch(UuIdText.Text))
            {
                UuIdText.BackColor      = Color.FromArgb(74, 253, 49);
                UuIdTextPanel.BackColor = Color.FromArgb(74, 253, 49);

                UuIdTextPanel.Enabled   = false;
                OpenTestButton.Enabled  = true;
            }
            else
            {
                UuIdText.Text           = string.Empty;
                UuIdText.BackColor      = Color.FromArgb(255, 40, 55);
                UuIdTextPanel.BackColor = Color.FromArgb(255, 40, 55);

                OpenTestButton.Enabled = false;
                TestInfoButton.Enabled = false;
            }
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
            var lastVersion = NaOtvetClient.GetLastApplicationVersion().Version;
            var currentVersion = Assembly.GetExecutingAssembly().GetName().Version.ToString();

            return int.Parse(currentVersion.Replace(".", "")) >= int.Parse(lastVersion.Replace(".", ""));
        }

        private void LoadRemoteData()
        {
            var webLinks = NaOtvetClient.GetWebLinks(new string[] { "youtubeTutorial", "youtubeChannel" });
            youtubeTutorialUrl = webLinks.First(webLink => webLink.Name == "youtubeTutorial").Url;
            youtubeChannelUrl = webLinks.First(webLink => webLink.Name == "youtubeChannel").Url;
            naurokAccount = NaOtvetClient.GetWebSiteAccount("https://naurok.com.ua");
        }


        private void Stop()
        {
            finderSystem?.Stop();
            stopwatch.Stop();
            TestTimer.Stop();
            
            StopButton.Enabled              = false;
            splitContainer2.Panel2.Enabled  = false;
            ClearUuIdTextButton.Enabled     = true;
            StartButton.Enabled             = true;

            TestTimeLeftText.Text = "00:00:00";
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
            TestInfoButton.Enabled = false;

            Stop();
            SystemSounds.Exclamation.Play();

            MessageForm.Show(errorText, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }


        private void OnFatalError(Exception exception)
        {
            if (HelpClass.IsInternetConnectionAvailable() == false)
            {
                ThrowFatalError("Нет доступа к интернету");
                return;
            }

            try
            {
                throw exception;
            }
            catch (AnsweredQuestionException)
            {
                ThrowFatalError("Вы ответели на некоторые вопросы теста, по-этому программа не сможет найти ответы");
            }
            catch
            {
                ThrowFatalError("Возникла неизвестная ошибка. Возможно, тест был завершён/не существует. Текст ошибки: " + exception.Message);                    
            }
        }

        private void TestTimer_Tick(object sender, EventArgs args)
        {
            var session = finderSystem.GetTestSession();

            if (DateTime.Now <= session.EndDateTime)
            {
                var timeLeft = session.EndDateTime.Value - DateTime.Now;
                TestTimeLeftText.Text = timeLeft.ToString(@"hh\:mm\:ss");

                if (timeLeft.TotalMinutes <= 5 && session.Duration.Value.TotalMinutes >= 5)
                {
                    TestTimeLeftText.ForeColor = Color.FromArgb(255, 36, 36);
                }
            }
            else
            {
                splitContainer2.Panel2.Enabled = false;
                TestTimer.Stop();
                MessageForm.Show("Время прохождения теста истекло. Советуем подождать, пока программа найдёт ответы, что бы сохранить их для других учеников", "Тест завершён", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
            if (Cache.CacheObjects
                .SolvedTestSessions
                .Contains(new KeyValuePair<int, TestSession>(args.DocumentId, args.TestSession)) == false)
            {
                Cache.CacheObjects.SolvedTestSessions.Add(new KeyValuePair<int, TestSession>(args.DocumentId, args.TestSession));
            }

#if DEBUG
            Log($"НАЙДЕНО: {args.DocumentId}.");
            Log($"Затрачено времени: {stopwatch.Elapsed}.");

            var testDocumentsChecked = finderSystem?.CheckedDocumentsCount is null ? 0 : finderSystem.CheckedDocumentsCount;

            Log($"Проверено тестов: {testDocumentsChecked}");
#else
            Log($"НАЙДЕНО!");
            Log($"Затрачено времени: {stopwatch.Elapsed}.");
#endif

            this.Invoke(new Action(() =>
            {
                Stop();                
                SystemSounds.Asterisk.Play();

                var questionsViewForm = new QuestionsViewForm(args.TestSession.Questions, true);
                questionsViewForm.TopMost = true;
                questionsViewForm.Show();                
                questionsViewForm.TopMost = false;
            }));
        }

        private void FinderSystem_OnError(object sender, OnErrorArgs args)
        {            
            this.Invoke(new Action(() => LogError(args.Exception.Message)));
        }
    }
}
