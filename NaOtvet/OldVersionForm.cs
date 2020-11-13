using NaOtvet.ApiClient;
using System;
using System.Diagnostics;
using System.Windows.Forms;

namespace NaOtvet
{
    public partial class OldVersionForm : Form
    {
        private string downloadUrl;

        public OldVersionForm()
        {
            InitializeComponent();
            LoadDownloadUrl();
        }

        private void LoadDownloadUrl()
        {
            try
            {
                downloadUrl = NaOtvetApiClient.GetWebLink("downloadPage").Url;
            }
            catch (Exception) { }
        }

        private void DownloadButton_Click(object sender, EventArgs e)
        {
            if (downloadUrl != null)
                Process.Start(downloadUrl);
            else
                MessageBox.Show("Невозможно загрузить ссылку на скачивание. Перейдите на сайт naotvet.pp.ua. Если он, вдруг, не работает, перейдите в телеграм t.me/naurokanswers", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);

            Close();
        }
    }
}
