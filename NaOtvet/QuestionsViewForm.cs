using NaUrokApiClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace NaOtvet
{
    public partial class QuestionsViewForm : Form
    {
        private TestQuestion[] questions;
        private List<QuestionView> questionsViewControls = new List<QuestionView>();
        private bool showOnlyAnswers;

        public QuestionsViewForm(TestQuestion[] questions, bool showOnlyAnswers)
        {
            InitializeComponent();

            this.questions = questions;
            this.showOnlyAnswers = showOnlyAnswers;
        }

        public QuestionsViewForm(List<TestQuestion> questions, bool showOnlyAnswers) : this(questions.ToArray(), showOnlyAnswers) { }


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
                var optionsTexts    = new List<string>();
                var questionText    = HelpClass.HtmlToPlainText(question.HtmlText);
                var points          = HelpClass.PointsToSystem(question.Points, system, 12);
                var options         = showOnlyAnswers ? question.Answers : question.Options;

                if (question.ImageUrl != null)
                {
                    var picture = new UrlDescription(question.ImageUrl, "Рис. вопроса");
                    pictures.Add(picture);
                }

                if (options != null)
                {
                    for (int i = 0; i < options.Count; i++)
                    {
                        var option = options[i];
                        var optionText = HelpClass.HtmlToPlainText(option.HtmlText);

                        if (option.ImageUrl != null)
                        {
                            var pictureBaseText = showOnlyAnswers ? "Рис. ответа" : "Рис. варианта";
                            var pictureDescription = options.Count > 1 ? $"{pictureBaseText} {i + 1}" : pictureBaseText;
                            var picture = new UrlDescription(option.ImageUrl, pictureDescription);
                            pictures.Add(picture);

                            if (string.IsNullOrWhiteSpace(optionText))
                                optionText = $"({pictureDescription})";
                        }

                        optionsTexts.Add(optionText);
                    }
                }

                var control = new QuestionView(questionText, Math.Round(points, 2), optionsTexts, pictures)
                {
                    OptionsAreAnswers = showOnlyAnswers,
                    Dock = DockStyle.Top
                };

                control.OnControlStateChanged += OnQuestionAnswerControlStateChanged;
                questionsViewControls.Add(control);

                QuestionsAnswersPanel.Controls.Add(control);
                control.BringToFront();
            }
        }

        private void FilterAnswersQuestionsControls(string text)
        {
            var query = text.ToLower().Trim();
            var findedControls = questionsViewControls
                .Where(control =>
                    control.Question.ToLower().Contains(query) ||
                    control.Options.Any(answer => answer.ToLower().Contains(query)));

            if (OnlyNotCollapsedQuestionsCheckBox.Checked)
                findedControls = findedControls.Where(control => control.IsMinimized == false);

            questionsViewControls.ForEach(control => control.Visible = findedControls.Contains(control));

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
