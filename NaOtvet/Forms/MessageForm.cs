using NaOtvet.Properties;
using System;
using System.Windows.Forms;

namespace NaOtvet
{
    public partial class MessageForm : Form
    {
        public static DialogResult Show(string text, string title,
            MessageBoxButtons buttons = MessageBoxButtons.OK, MessageBoxIcon icon = MessageBoxIcon.Information)
        {
            using (var form = new MessageForm(text, title, buttons, icon))
                return form.ShowDialog();
        }

        public MessageForm(string text, string title, MessageBoxButtons buttons, MessageBoxIcon icon)
        {
            InitializeComponent();
            SetButtons(buttons);
            SetPicture(icon);

            MessageText.Text = text;
            Text = title;
        }

        private void SetPicture(MessageBoxIcon icon)
        {
            switch (icon)
            {
                case MessageBoxIcon.Warning:
                    Picture.Image = Resources.WarningImage;
                    break;

                case MessageBoxIcon.Error:
                    Picture.Image = Resources.ErrorImage;
                    break;

                case MessageBoxIcon.Question:
                    Picture.Image = Resources.QuestionImage;
                    break;

                case MessageBoxIcon.Information:
                default:
                    Picture.Image = Resources.InfoImage;
                    break;
            }
        }

        private void SetButtons(MessageBoxButtons buttons)
        {
            switch (buttons)
            {
                case MessageBoxButtons.OK:
                    DialogResult = DialogResult.OK;

                    Button2.Visible = false;
                    Button3.Visible = false;

                    Button1.Text = "Ок";

                    Button1.Click += (sender, args) => DialogResult = DialogResult.OK;

                    tableLayoutPanel1.SetColumnSpan(Button1, 3);
                    break;

                case MessageBoxButtons.OKCancel:
                    DialogResult = DialogResult.Cancel;

                    Button3.Visible = false;

                    Button1.Text = "Ок";
                    Button2.Text = "Отмена";

                    Button1.Click += (sender, args) => DialogResult = DialogResult.OK;
                    Button2.Click += (sender, args) => DialogResult = DialogResult.Cancel;

                    tableLayoutPanel1.ColumnCount = 2;
                    break;

                case MessageBoxButtons.YesNo:
                    DialogResult = DialogResult.No;

                    Button3.Visible = false;

                    Button1.Text = "Да";
                    Button2.Text = "Нет";

                    Button1.Click += (sender, args) => DialogResult = DialogResult.Yes;
                    Button2.Click += (sender, args) => DialogResult = DialogResult.No;

                    tableLayoutPanel1.ColumnCount = 2;
                    break;

                case MessageBoxButtons.RetryCancel:
                    DialogResult = DialogResult.Cancel;

                    Button3.Visible = false;

                    Button1.Text = "Повторить";
                    Button2.Text = "Отмена";

                    Button1.Click += (sender, args) => DialogResult = DialogResult.Retry;
                    Button2.Click += (sender, args) => DialogResult = DialogResult.Cancel;

                    tableLayoutPanel1.ColumnCount = 2;
                    break;

                case MessageBoxButtons.YesNoCancel:
                    DialogResult = DialogResult.Cancel;

                    Button1.Text = "Да";
                    Button2.Text = "Нет";
                    Button2.Text = "Отмена";

                    Button1.Click += (sender, args) => DialogResult = DialogResult.Yes;
                    Button2.Click += (sender, args) => DialogResult = DialogResult.No;
                    Button3.Click += (sender, args) => DialogResult = DialogResult.Cancel;
                    break;

                case MessageBoxButtons.AbortRetryIgnore:
                    DialogResult = DialogResult.Ignore;

                    Button1.Text = "Прервать";
                    Button2.Text = "Повторить";
                    Button2.Text = "Игнорировать";

                    Button1.Click += (sender, args) => DialogResult = DialogResult.Abort;
                    Button2.Click += (sender, args) => DialogResult = DialogResult.Retry;
                    Button3.Click += (sender, args) => DialogResult = DialogResult.Ignore;
                    break;

                default:
                    throw new Exception();
            }

            Button1.Click += CloseButton_Click;
            Button3.Click += CloseButton_Click;
        }

        private void CloseButton_Click(object sender, System.EventArgs e)
        {
            Close();
        }
    }
}
