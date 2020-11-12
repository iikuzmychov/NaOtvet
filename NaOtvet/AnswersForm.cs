using NaOtvet.Core;
using System;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace NaOtvet
{
    public partial class AnswersForm : Form
    {
        private TestSession testSession;

        public AnswersForm(TestSession testSession)
        {
            InitializeComponent();
            this.testSession = testSession;
        }

        private void AnswersForm_Load(object sender, EventArgs e)
        {
            GenerateQuestions();
        }

        private void AnswersForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            var confirmationBoxResult = MessageBox.Show("Вы точно хотите закрыть это окно?", "Потдверждение", MessageBoxButtons.YesNo);

            if (confirmationBoxResult != DialogResult.Yes)
                e.Cancel = true;
        }


        private int GetMaxPointsCount()
        {
            return testSession.Questions.Select(question => question.Points).Sum();
        }

        private string HtmlToText(string html)
        {
            return Regex.Replace(html, @"<[^>]*>", "");
        }

        private string GenerateText(TestQuestion question)
        {
            var stringBuilder = new StringBuilder();
            var maxPointsCount = GetMaxPointsCount();
            var questionText = HtmlToText(question.Content);
            var questionPoints12System = Math.Round((double)question.Points * 12 / maxPointsCount, 1);

            stringBuilder.AppendLine("ВОПРОС: " + questionText);
            stringBuilder.AppendLine($"БАЛЛЫ ЗА ВОПРОС: {questionPoints12System}б.");

            if (question.Answers.Count > 1)
                stringBuilder.AppendLine("ОТВЕТЫ: ");
            else
                stringBuilder.Append("ОТВЕТ: ");


            for (int i = 0; i < question.Answers.Count; i++)
            {
                string answerText;

                try
                {
                    answerText = HtmlToText(question.Answers[i].Content);
                }
                catch (Exception)
                {
                    answerText = "Ответ не найден, возможно, это потому, что ответ - картинка";
                }

                if (question.Answers.Count > 1)
                {
                    if (i < question.Answers.Count - 1)
                        stringBuilder.AppendLine($"  {i + 1}. {answerText}");
                    else
                        stringBuilder.Append($"  {i + 1}. {answerText}");
                }
                else
                {
                    stringBuilder.Append(answerText);
                }
            }

            return stringBuilder.ToString();
        }

        private (TextBox, CheckBox) GenerateQuestion(int yLocation, TestQuestion question)
        {
            var font = new Font(FontFamily.GenericSansSerif, 12);

            var questionTextBox = new TextBox
            {
                Location    = new Point(5, yLocation),
                Size        = new Size(600, 1),
                BorderStyle = BorderStyle.FixedSingle,
                Anchor      = AnchorStyles.Top | AnchorStyles.Left,
                Multiline   = true,
                ScrollBars  = ScrollBars.Vertical,
                ReadOnly    = true,
                TabStop     = false,
                BackColor   = Color.FromKnownColor(KnownColor.Window),
                Font        = font
            };

            questionTextBox.TextChanged += QuestionTextBox_TextChanged;
            questionTextBox.Text = GenerateText(question);

            var questionCheckBox = new CheckBox
            {
                Location    = new Point(633, yLocation),
                AutoSize    = true,                
                Font        = font,
                Text        = "Вопрос отвечен",
            };

            SimpleToolTip.SetToolTip(questionCheckBox, "Нажмите, что бы скрыть вопрос");
            questionCheckBox.CheckedChanged += (sender, args) => QuestionTextBox_CheckedChanged(sender, questionTextBox);

            Controls.Add(questionTextBox);
            Controls.Add(questionCheckBox);

            return (questionTextBox, questionCheckBox);
        }

        private void GenerateQuestions()
        {
            TextBox lastQuestionTextBox = null;

            for (int i = 0; i < testSession.Questions.Count; i++)
            {
                int textBoxYLocation;

                if (lastQuestionTextBox is null)
                    textBoxYLocation = 3;
                else
                    textBoxYLocation = lastQuestionTextBox.Location.Y + lastQuestionTextBox.Size.Height + 3;

                lastQuestionTextBox = GenerateQuestion(textBoxYLocation, testSession.Questions[i]).Item1;
            }

            if (lastQuestionTextBox.Location.Y + lastQuestionTextBox.Size.Height < this.Size.Height)
            {
                this.MinimumSize = new Size();
                this.AutoSize = true;
            }
        }
        
        private void QuestionTextBox_TextChanged(object sender, EventArgs e)
        {
            var textBox = sender as TextBox;
            const int yMargin = 3;
            Size size = TextRenderer.MeasureText(textBox.Text, textBox.Font);
            textBox.ClientSize = new Size(textBox.Width, size.Height + yMargin);
        }

        private void QuestionTextBox_CheckedChanged(object sender, TextBox questionTextBox)
        {
            var checkBox = sender as CheckBox;

            if (checkBox.Checked)
                questionTextBox.BackColor = Color.Black;
            else
                questionTextBox.BackColor = Color.FromKnownColor(KnownColor.Window);
        }
    }
}
