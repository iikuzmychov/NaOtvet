using NaUrokApiClient;
using System;
using System.Collections.Generic;
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
        private TestQuestion[] testQuestions;

        public AnswersForm(TestQuestion[] questions)
        {
            if (questions is null)
                throw new ArgumentNullException();
            
            testQuestions = questions;
            InitializeComponent();
        }

        private void AnswersForm_Load(object sender, EventArgs e)
        {
            GenerateControlsForQuestions();
        }

        private void AnswersForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            var confirmationBoxResult = MessageBox.Show("Вы точно хотите закрыть это окно?", "Потдверждение", MessageBoxButtons.YesNo);

            if (confirmationBoxResult != DialogResult.Yes)
                e.Cancel = true;
        }


        private int GetMaxPointsCount()
        {
            return testQuestions.Select(question => question.Points).Sum();
        }

        private string HtmlToText(string html)
        {
            return Regex.Replace(html, @"<[^>]*>", "");
        }

        private string GenerateText(TestQuestion question, out string questionImageUrl, out string[] answersImagesUrls)
        {
            var stringBuilder = new StringBuilder();
            var maxPointsCount = GetMaxPointsCount();
            var questionText = HtmlToText(question.HtmlText);
            var questionPoints12System = Math.Round((double)question.Points * 12 / maxPointsCount, 1);

            stringBuilder.Append("ВОПРОС: ");

            if (question.ImageUrl != null)
            {
                stringBuilder.Append($"(рис.0) ");
                questionImageUrl = question.ImageUrl;
            }
            else
            {
                questionImageUrl = null;
            }

            stringBuilder.AppendLine(questionText);
            stringBuilder.AppendLine($"БАЛЛЫ ЗА ВОПРОС: {questionPoints12System}б.");

            if (question.Answers.Count > 0)
            {
                bool maybeIncorrectAnswer = false;

                if (question.Type == QuestionType.ManyAnswers &&
                    question.Options
                        .Where(answer => answer.ImageUrl != null)
                        .Count() > 1)
                {
                    maybeIncorrectAnswer = true;
                }

                if (question.Answers.Count > 1)
                    stringBuilder.Append("ОТВЕТЫ: ");
                else
                    stringBuilder.Append("ОТВЕТ: ");

                if (maybeIncorrectAnswer)
                    stringBuilder.Append("[возможно, это НЕ ПОЛНЫЙ ОТВЕТ] ");

                if (question.Answers.Count > 1)
                    stringBuilder.AppendLine();

                var answersImagesUrlsList = new List<string>();

                for (int i = 0; i < question.Answers.Count; i++)
                {
                    string answerText = "";

                    if (question.Answers[i].ImageUrl != null)
                    {
                        answerText = $"(рис.{i + 1}) ";
                        answersImagesUrlsList.Add(question.Answers[i].ImageUrl);
                    }
                    else
                    {
                        answersImagesUrlsList.Add(null);
                    }

                    if (question.Answers[i].HtmlText != null && question.Answers[i].HtmlText != string.Empty)
                    {
                        answerText = HtmlToText(question.Answers[i].HtmlText);
                    }
                    else if (question.Answers[i].ImageUrl == null)
                    {
                        answerText = "невозможно найти ответ";
                    }

                    if (question.Answers.Count > 1)
                    {
                        stringBuilder.Append($"  {i + 1}. {answerText}");

                        if (i < question.Answers.Count - 1)
                            stringBuilder.AppendLine();
                    }
                    else
                    {
                        stringBuilder.Append(answerText);
                    }
                }

                answersImagesUrls = answersImagesUrlsList.ToArray();
            }
            else
            {
                stringBuilder.Append("НЕ УДАЛОСЬ НАЙТИ ОТВЕТ");
                answersImagesUrls = null;
            }

            return stringBuilder.ToString();
        }

        private (TextBox, CheckBox) GenerateControlForQuestion(int yLocation, TestQuestion question)
        {
            var defaultFont = new Font(FontFamily.GenericSansSerif, 12);
            var littleFont = new Font(FontFamily.GenericSansSerif, 10);

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
                Font        = defaultFont
            };

            questionTextBox.TextChanged += QuestionTextBox_TextChanged;
            questionTextBox.Text = GenerateText(question, out string questionImageUrl, out string[] answersImagesUrls);
            Controls.Add(questionTextBox);

            var questionCheckBox = new CheckBox
            {
                Location    = new Point(633, yLocation),
                AutoSize    = true,                
                Font        = defaultFont,
                Text        = "Вопрос отвечен",
            };

            SimpleToolTip.SetToolTip(questionCheckBox, "Нажмите, что бы скрыть вопрос");
            questionCheckBox.CheckedChanged += (sender, args) => QuestionTextBox_CheckedChanged(sender, questionTextBox);
            Controls.Add(questionCheckBox);

            LinkLabel questionImageLinkedText = null;

            if (questionImageUrl != null)
            {
                questionImageLinkedText = new LinkLabel
                {
                    Location    = new Point(questionCheckBox.Location.X, questionCheckBox.Location.Y + questionCheckBox.Size.Height + 3),
                    AutoSize    = true,
                    Font        = littleFont,
                    Text        = "рис.0"
                };

                questionImageLinkedText.Click += (sender, args) => new ImageViewForm(questionImageUrl, questionImageLinkedText.Text).ShowDialog();
                Controls.Add(questionImageLinkedText);
            }

            if (answersImagesUrls != null)
            {
                int answerStartYLocation;
                LinkLabel lastAnswerLabel = null;

                if (questionImageLinkedText != null)
                    answerStartYLocation = questionImageLinkedText.Location.Y + questionImageLinkedText.Size.Height + 3;
                else
                    answerStartYLocation = questionCheckBox.Location.Y + questionCheckBox.Size.Height + 3;

                for (int i = 0; i < answersImagesUrls.Length; i++)
                {
                    if (answersImagesUrls[i] is null)
                        continue;

                    int answerYLocation;
                    
                    if (lastAnswerLabel != null)
                        answerYLocation = answerStartYLocation + lastAnswerLabel.Size.Height + 3;
                    else
                        answerYLocation = answerStartYLocation;

                    var answerImageLinkedText = new LinkLabel
                    {
                        Location    = new Point(questionCheckBox.Location.X, answerYLocation),
                        AutoSize    = true,
                        Font        = littleFont,
                        Text        = $"рис.{i + 1}"
                    };

                    var imageUrl = answersImagesUrls[i];
                    answerImageLinkedText.Click += (sender, args) => new ImageViewForm(imageUrl, answerImageLinkedText.Text).ShowDialog();
                    Controls.Add(answerImageLinkedText);

                    lastAnswerLabel = answerImageLinkedText;
                }
            }

            return (questionTextBox, questionCheckBox);
        }

        private void GenerateControlsForQuestions()
        {
            TextBox lastQuestionTextBox = null;

            for (int i = 0; i < testQuestions.Length; i++)
            {
                int textBoxYLocation;

                if (lastQuestionTextBox is null)
                    textBoxYLocation = 3;
                else
                    textBoxYLocation = lastQuestionTextBox.Location.Y + lastQuestionTextBox.Size.Height + 3;

                lastQuestionTextBox = GenerateControlForQuestion(textBoxYLocation, testQuestions[i]).Item1;
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
            {
                questionTextBox.Enabled = false;
                questionTextBox.BackColor = Color.Black;
            }
            else
            {
                questionTextBox.Enabled = true;
                questionTextBox.BackColor = Color.FromKnownColor(KnownColor.Window);
            }
        }
    }
}
