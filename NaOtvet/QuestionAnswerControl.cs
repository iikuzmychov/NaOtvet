using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Drawing;
using System.Windows.Forms;

namespace NaOtvet
{
    public partial class QuestionAnswerControl : UserControl
    {
        private readonly Size mainPanelStartSize;
        private readonly Size formStartSize;

        private string question;
        private decimal points;
        private bool isMinimized;

        private List<Label> answersLabels = new List<Label>();
        private ObservableCollection<string> answers = new ObservableCollection<string>();

        private List<LinkLabel> picturesLinksLabels = new List<LinkLabel>();
        private ObservableCollection<UrlDescription> pictures = new ObservableCollection<UrlDescription>();

        public EventHandler<ControlStateChangedEventArgs> OnControlStateChanged;

        public bool IsMinimized
        {
            get
            {
                return isMinimized;
            }

            set
            {
                isMinimized = value;

                if (isMinimized)
                {
                    QuestionCollapsedCheckBox.CheckState = CheckState.Checked;                    
                    QuestionShortText.Visible = true;
                    QuestionText.Visible    = false;
                    AnswersLabel.Visible    = false;
                    AnswersPanel.Visible    = false;
                    PicturesPanel.Visible   = false;
                }
                else
                {
                    QuestionCollapsedCheckBox.CheckState = CheckState.Unchecked;
                    QuestionShortText.Visible   = false;
                    QuestionText.Visible    = true;
                    AnswersLabel.Visible    = true;
                    AnswersPanel.Visible    = true;
                    PicturesPanel.Visible   = true;
                }

                OnControlStateChanged?.Invoke(this, new ControlStateChangedEventArgs(isMinimized));
            }
        }
        public string Question
        {
            get
            {
                return question;
            }

            set
            {
                if (value is null)
                    throw new ArgumentNullException();

                question = value;
                QuestionText.Text = question;
                QuestionShortText.Text = question;
            }
        }
        public decimal Points
        {
            get
            {
                return points;
            }

            set
            {
                if (value <= 0)
                    throw new ArgumentException();

                points = value;

                int lastDigit = points < 10 ? (int)points : (int)(points % 10);

                if (points >= 10 && points <= 19)
                {
                    PointsLabel.Text = $"{value} баллов";
                }
                else
                {
                    if (lastDigit == 1)
                        PointsLabel.Text = $"{value} балл";
                    else if (lastDigit > 1 && lastDigit <= 4)
                        PointsLabel.Text = $"{value} балла";
                    else
                        PointsLabel.Text = $"{value} баллов";
                }
            }
        }
        public ObservableCollection<string> Answers
        {
            get
            {
                return answers;
            }

            set
            {
                if (value is null)
                    throw new ArgumentNullException();

                answers.Clear();
                AnswersPanel.Controls.Clear();
                answersLabels.Clear();

                foreach (string answer in value)
                    answers.Add(answer);
            }
        }
        public ObservableCollection<UrlDescription> Pictures
        {
            get
            {
                return pictures;
            }

            set
            {
                if (value is null)
                    throw new ArgumentNullException();

                pictures.Clear();
                PicturesPanel.Controls.Clear();
                picturesLinksLabels.Clear();

                foreach (UrlDescription picture in value)
                    pictures.Add(picture);
            }
        }


        public QuestionAnswerControl()
        {
            InitializeComponent();

            formStartSize = this.Size;
            mainPanelStartSize = MainPanel.Size;

            Answers.CollectionChanged += Answers_CollectionChanged;
            Pictures.CollectionChanged += Pictures_CollectionChanged;

            QuestionText.AutoSize = true;

            Question = string.Empty;
            Points = 1;
        }

        public QuestionAnswerControl(string question, decimal points, string[] answers, UrlDescription[] pictures) : this()
        {
            Question    = question;
            Points      = points;
            Answers     = new ObservableCollection<string>(answers);
            Pictures    = new ObservableCollection<UrlDescription>(pictures);
        }

        public QuestionAnswerControl(string question, decimal points, List<string> answers, List<UrlDescription> pictures) : this()
        {
            if (answers is null)
                throw new ArgumentNullException(nameof(answers));

            if (pictures is null)
                throw new ArgumentNullException(nameof(pictures));

            Question    = question;
            Points      = points;
            Answers     = new ObservableCollection<string>(answers);
            Pictures    = new ObservableCollection<UrlDescription>(pictures);
        }


        private void QuestionText_Paint(object sender, PaintEventArgs e)
        {
            var newWidth = MainPanel.ClientSize.Width - MainPanel.Padding.Right - QuestionText.Margin.Right;
            QuestionText.MaximumSize = new Size(newWidth, 0);
        }

        private void QuestionAnswerControl_Paint(object sender, PaintEventArgs e)
        {
            MainPanel.Width = this.Width + this.Margin.Left + this.Margin.Right - (formStartSize.Width - mainPanelStartSize.Width);
        }

        private void QuestionCollapsedCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            var checkBox = sender as CheckBox;
            
            if (IsMinimized != checkBox.Checked)
                IsMinimized = checkBox.Checked;
        }


        private void Pictures_CollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            switch (e.Action)
            {
                case NotifyCollectionChangedAction.Add:
                    AddPicture((UrlDescription)e.NewItems[0]);
                    break;

                case NotifyCollectionChangedAction.Replace:
                    picturesLinksLabels[e.OldStartingIndex].Text = (string)e.NewItems[0];
                    break;

                case NotifyCollectionChangedAction.Remove:
                    PicturesPanel.Controls.Remove(picturesLinksLabels[e.OldStartingIndex]);
                    picturesLinksLabels.RemoveAt(e.OldStartingIndex);
                    break;

                case NotifyCollectionChangedAction.Reset:
                    PicturesPanel.Controls.Clear();
                    picturesLinksLabels.Clear();
                    break;

                case NotifyCollectionChangedAction.Move:
                    var movedLabel = picturesLinksLabels[e.OldStartingIndex];
                    picturesLinksLabels.RemoveAt(e.OldStartingIndex);
                    picturesLinksLabels.Insert(e.NewStartingIndex, movedLabel);
                    break;
            }
        }

        private LinkLabel AddPicture(UrlDescription picture)
        {
            LinkLabel pictureLabel;

            if (picturesLinksLabels.Count > 0)
                pictureLabel = ExampleImageLinkLabel.Clone();
            else
                pictureLabel = ExampleImageLinkLabel;

            pictureLabel.Text = picture.Description;
            pictureLabel.Visible = true;
            pictureLabel.Links.Clear();

            var link = new LinkLabel.Link(0, picture.Description.Length, picture.Url);
            link.Description = picture.Description;

            pictureLabel.Links.Add(link);
            pictureLabel.LinkClicked += PictureLinkLabel_LinkClicked;

            picturesLinksLabels.Add(pictureLabel);

            if (PicturesPanel.Controls.Contains(pictureLabel) == false)
                PicturesPanel.Controls.Add(pictureLabel);

            pictureLabel.BringToFront();

            return pictureLabel;
        }

        private void PictureLinkLabel_LinkClicked(object label, LinkLabelLinkClickedEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                var viewForm = new PictureViewForm((string)e.Link.LinkData, e.Link.Description);
                viewForm.ShowDialog();
            }
        }


        private void Answers_CollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            switch (e.Action)
            {
                case NotifyCollectionChangedAction.Add:                    
                    AddAnswer((string)e.NewItems[0]);
                    break;

                case NotifyCollectionChangedAction.Replace:
                    answersLabels[e.OldStartingIndex].Text = (string)e.NewItems[0];
                    break;

                case NotifyCollectionChangedAction.Remove:
                    AnswersPanel.Controls.Remove(answersLabels[e.OldStartingIndex]);
                    answersLabels.RemoveAt(e.OldStartingIndex);
                    break;

                case NotifyCollectionChangedAction.Reset:
                    AnswersPanel.Controls.Clear();
                    answersLabels.Clear();
                    break;

                case NotifyCollectionChangedAction.Move:
                    var movedLabel = answersLabels[e.OldStartingIndex];                    
                    answersLabels.RemoveAt(e.OldStartingIndex);
                    answersLabels.Insert(e.NewStartingIndex, movedLabel);
                    AnswersPanel.Controls.SetChildIndex(movedLabel, e.NewStartingIndex);
                    break;
            }
        }

        private Label AddAnswer(string text)
        {
            if (text is null)
                throw new ArgumentNullException(nameof(text));

            Label answerLabel;

            if (answersLabels.Count > 0)
                answerLabel = ExampleAnswerText.Clone();
            else
                answerLabel = ExampleAnswerText;

            answerLabel.Text        = text;
            answerLabel.Visible     = true;
            answerLabel.AutoSize    = true;
            answerLabel.Paint += AnswerText_Paint;
                        
            answersLabels.Add(answerLabel);

            if (AnswersPanel.Controls.Contains(answerLabel) == false)
                AnswersPanel.Controls.Add(answerLabel);

            answerLabel.BringToFront();

            return answerLabel;
        }

        private void AnswerText_Paint(object sender, PaintEventArgs e)
        {
            var label = sender as Label;
            label.MaximumSize = new Size(AnswersPanel.ClientSize.Width, 0);
        }
    }
}
