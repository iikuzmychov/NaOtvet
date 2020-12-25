using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Drawing;
using System.Windows.Forms;

namespace NaOtvet
{
    public partial class QuestionView : UserControl
    {
        private readonly Size mainPanelStartSize;
        private readonly Size formStartSize;

        private string question;
        private decimal points;
        private bool isMinimized = false;
        private bool optionsAreAnswers = false;

        private List<Label> optionsLabels = new List<Label>();
        private ObservableCollection<string> options = new ObservableCollection<string>();

        private List<LinkLabel> picturesLinksLabels = new List<LinkLabel>();
        private ObservableCollection<UrlDescription> pictures = new ObservableCollection<UrlDescription>();

        private static readonly List<Color> backgroungOptionColors = new List<Color>
        {
            Color.FromArgb(74, 253, 49),
            Color.FromArgb(252, 204, 41),
            Color.FromArgb(34, 197, 251),
            Color.FromArgb(255, 36, 36)
        };

        public EventHandler<ControlStateChangedEventArgs> OnControlStateChanged;

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
                    QuestionText.Visible = false;
                    OptionsLabel.Visible = false;
                    OptionsPanel.Visible = false;
                    PicturesPanel.Visible = false;
                }
                else
                {
                    QuestionCollapsedCheckBox.CheckState = CheckState.Unchecked;
                    QuestionShortText.Visible = false;
                    QuestionText.Visible = true;
                    OptionsLabel.Visible = true;
                    OptionsPanel.Visible = true;
                    PicturesPanel.Visible = true;
                }

                OnControlStateChanged?.Invoke(this, new ControlStateChangedEventArgs(isMinimized));
            }
        }
        public bool OptionsAreAnswers
        {
            get
            {
                return optionsAreAnswers;
            }

            set
            {
                optionsAreAnswers = value;

                if (optionsAreAnswers)
                {
                    OptionsLabel.Text = "Ответы:";
                    OptionsLabel.ForeColor = Color.FromArgb(74, 253, 49);
                }
                else
                {
                    OptionsLabel.Text = "Варианты ответов:";
                    OptionsLabel.ForeColor = Color.FromArgb(254, 176, 31);                    
                }
            }
        }
        public ObservableCollection<string> Options
        {
            get
            {
                return options;
            }

            set
            {
                if (value is null)
                    throw new ArgumentNullException();

                options.Clear();
                OptionsPanel.Controls.Clear();
                optionsLabels.Clear();

                foreach (string answer in value)
                    options.Add(answer);
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


        public QuestionView()
        {
            InitializeComponent();

            formStartSize = this.Size;
            mainPanelStartSize = MainPanel.Size;

            Options.CollectionChanged += Options_CollectionChanged;
            Pictures.CollectionChanged += Pictures_CollectionChanged;

            QuestionText.AutoSize = true;

            Question = string.Empty;
            Points = 1;
        }

        public QuestionView(string question, decimal points, string[] options, UrlDescription[] pictures) : this()
        {
            Question    = question;
            Points      = points;
            Options     = new ObservableCollection<string>(options);
            Pictures    = new ObservableCollection<UrlDescription>(pictures);
        }

        public QuestionView(string question, decimal points, List<string> options, List<UrlDescription> pictures) : this()
        {
            if (options is null)
                throw new ArgumentNullException(nameof(options));

            if (pictures is null)
                throw new ArgumentNullException(nameof(pictures));

            Question    = question;
            Points      = points;
            Options     = new ObservableCollection<string>(options);
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
        
        private void QuestionText_DoubleClick(object sender, EventArgs e)
        {
            Clipboard.SetText(Question);
            MessageForm.Show("Текст вопроса скопирован в буфер обмена");
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
                var oictureViewForm = new PictureViewForm((string)e.Link.LinkData, e.Link.Description);
                oictureViewForm.ShowDialog();
            }
        }


        private void Options_CollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            switch (e.Action)
            {
                case NotifyCollectionChangedAction.Add:                    
                    AddOption((string)e.NewItems[0]);
                    break;

                case NotifyCollectionChangedAction.Replace:
                    optionsLabels[e.OldStartingIndex].Text = (string)e.NewItems[0];
                    break;

                case NotifyCollectionChangedAction.Remove:
                    OptionsPanel.Controls.Remove(optionsLabels[e.OldStartingIndex]);
                    optionsLabels.RemoveAt(e.OldStartingIndex);
                    break;

                case NotifyCollectionChangedAction.Reset:
                    OptionsPanel.Controls.Clear();
                    optionsLabels.Clear();
                    break;

                case NotifyCollectionChangedAction.Move:
                    var movedLabel = optionsLabels[e.OldStartingIndex];                    
                    optionsLabels.RemoveAt(e.OldStartingIndex);
                    optionsLabels.Insert(e.NewStartingIndex, movedLabel);
                    OptionsPanel.Controls.SetChildIndex(movedLabel, e.NewStartingIndex);
                    break;
            }
        }

        private Label AddOption(string text)
        {
            if (text is null)
                throw new ArgumentNullException(nameof(text));

            Label optionLabel;

            if (optionsLabels.Count > 0)
                optionLabel = ExampleOptionText.Clone();
            else
                optionLabel = ExampleOptionText;

            optionLabel.Text        = text;
            optionLabel.Visible     = true;
            optionLabel.AutoSize    = true;
            optionLabel.BackColor   = GetBackgroundOptionColor();

            optionLabel.DoubleClick += OptionText_DoubleClick;
                        
            optionsLabels.Add(optionLabel);

            if (OptionsPanel.Controls.Contains(optionLabel) == false)
                OptionsPanel.Controls.Add(optionLabel);

            optionLabel.BringToFront();

            return optionLabel;
        }

        private Color GetBackgroundOptionColor()
        {
            int baseColorIndex = optionsLabels.Count - backgroungOptionColors.Count * (int)(optionsLabels.Count / backgroungOptionColors.Count);
            var baseColor = backgroungOptionColors[baseColorIndex];
            
            return Color.FromArgb(35, baseColor);
        }

        private void OptionText_DoubleClick(object sender, EventArgs e)
        {
            var optionLabel = sender as Label;
            var text = Options[optionsLabels.IndexOf(optionLabel)];

            Clipboard.SetText(text);
            MessageForm.Show("Текст опции скопирован в буфер обмена");
        }

        private void OptionsPanel_SizeChanged(object sender, EventArgs e)
        {
            foreach (var label in optionsLabels)
                label.MaximumSize = new Size(OptionsPanel.Width, 0);
        }
    }
}
