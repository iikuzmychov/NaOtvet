using NaUrokApiClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace NaOtvet
{
    public partial class QuestionsAnswersForm : Form
    {
        private TestQuestion[] questions;
        private List<QuestionAnswerControl> questionAnswerControls = new List<QuestionAnswerControl>();

        public QuestionsAnswersForm(TestQuestion[] testQuestions)
        {
            InitializeComponent();

            questions = testQuestions;
        }

        public QuestionsAnswersForm(List<TestQuestion> testQuestions) : this(testQuestions.ToArray()) { }


        private void QuestionsAnswersForm_Load(object sender, EventArgs e)
        {
            GenerateQuestionAnswerControls();
        }

        private void QuestionsAnswersForm_Shown(object sender, EventArgs e)
        {
            ActiveControl = null; // убрать фокус
            FilterAnswersQuestionsControls(SearchQueryText.Text);
        }


        private void GenerateQuestionAnswerControls()
        {
            decimal system = questions.Sum(question => question.Points); // максимальная оценка

            foreach (var question in questions)
            {
                var pictures        = new List<UrlDescription>();
                var answersTexts    = new List<string>();
                var questionText    = HelpClass.HtmlToPlainText(question.HtmlText);
                var points          = HelpClass.PointsToSystem(question.Points, system, 12);

                if (question.ImageUrl != null)
                {
                    var picture = new UrlDescription(question.ImageUrl, "Рис. вопроса");
                    pictures.Add(picture);
                }

                if (question.Answers != null)
                {
                    for (int i = 0; i < question.Answers.Count; i++)
                    {
                        var answer = question.Answers[i];
                        var answerText = HelpClass.HtmlToPlainText(answer.HtmlText);

                        if (answer.ImageUrl != null)
                        {
                            var pictureDescription = question.Answers.Count > 1 ? $"Рис. ответа {i + 1}" : "Рис. ответа";
                            var picture = new UrlDescription(answer.ImageUrl, pictureDescription);
                            pictures.Add(picture);

                            if (string.IsNullOrWhiteSpace(answerText))
                                answerText = $"({pictureDescription})";
                        }

                        answersTexts.Add(answerText);
                    }
                }

                var control = new QuestionAnswerControl(questionText, points, answersTexts, pictures)
                {
                    Dock = DockStyle.Top
                };
                control.OnControlStateChanged += OnQuestionAnswerControlStateChanged;
                questionAnswerControls.Add(control);

                QuestionsAnswersPanel.Controls.Add(control);
                control.BringToFront();
            }
        }

        private void FilterAnswersQuestionsControls(string text)
        {
            var query = text.ToLower().Trim();
            var findedControls = questionAnswerControls
                .Where(control =>
                    control.Question.ToLower().Contains(query) ||
                    control.Answers.Any(answer => answer.ToLower().Contains(query)));

            if (OnlyNotCollapsedQuestionsCheckBox.Checked)
                findedControls = findedControls.Where(control => control.IsMinimized == false);

            questionAnswerControls.ForEach(control => control.Visible = findedControls.Contains(control));

            if (findedControls.Count() == 0)
            {
                NothingFindedLabel.Visible = true;
                QuestionsAnswersPanel.AutoScroll = false;
            }
            else
            {
                NothingFindedLabel.Visible = false;
                QuestionsAnswersPanel.AutoScroll = true;
            }
        }


        private void OnQuestionAnswerControlStateChanged(object sender, ControlStateChangedEventArgs e)
        {
            FilterAnswersQuestionsControls(SearchQueryText.Text);
        }

        private void SearchQueryTextPanel_MouseClick(object sender, MouseEventArgs e)
        {
            // сфокусироваться на текст при нажатии на панель
            if (e.Button == MouseButtons.Left)
                SearchQueryText.Focus();
        }

        private void ClearSearchQueryButton_Click(object sender, EventArgs e)
        {
            SearchQueryText.Text = string.Empty;
        }

        private void SearchQueryText_TextChanged(object sender, EventArgs e)
        {
            SearchQueryText.Text = SearchQueryText.Text.TrimStart();
            FilterAnswersQuestionsControls(SearchQueryText.Text);
        }

        private void OnlyNotCollapsedQuestionsCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            FilterAnswersQuestionsControls(SearchQueryText.Text);
        }
    }
}
