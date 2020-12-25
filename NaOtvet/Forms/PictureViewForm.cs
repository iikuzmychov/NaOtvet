using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NaOtvet
{
    public partial class PictureViewForm : Form
    {
        private Stream imageStream;
        private string pictureUrl;
        private CancellationTokenSource loadingTaskSources = new CancellationTokenSource();
        private Task loadingTask;

        public static Dictionary<string, Image> CachedPictures { get; private set; } = new Dictionary<string, Image>();

        public PictureViewForm(string pictureUrl, string description)
        {
            if (pictureUrl is null)
                throw new ArgumentNullException(nameof(pictureUrl));

            if (description is null)
                throw new ArgumentNullException(nameof(description));

            InitializeComponent();

            this.pictureUrl = pictureUrl;
            DescriptionText.Text = description;
        }
        
        private void PictureViewForm_Load(object sender, EventArgs e)
        {
            loadingTask = Task.Run(LoadPicture, loadingTaskSources.Token);
        }

        private void PictureViewForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            imageStream?.Dispose();
            loadingTaskSources.Cancel();
        }

        private void LoadPicture()
        {
            try
            {
                Image picture;

                if (Cache.CacheObjects.Pictures.ContainsKey(pictureUrl))
                {
                    picture = Cache.CacheObjects.Pictures[pictureUrl];
                }
                else
                {
                    imageStream = HelpClass.DownloadImageAsStream(pictureUrl);
                    picture = Image.FromStream(imageStream);

                    if (ImageFormat.Gif.Equals(picture.RawFormat) == false)
                    {
                        imageStream.Dispose();

                        if (Cache.CacheObjects.Pictures.ContainsKey(pictureUrl) == false)
                        {
                            Cache.CacheObjects.Pictures.Add(pictureUrl, picture);
                            Cache.CacheObjects.Save();
                        }
                    }
                }

                PictureView.Image = picture;
            }
            catch (Exception ex)
            {
                PictureView.Image = PictureView.ErrorImage;
            }
        }
    }
}
