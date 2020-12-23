using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NaOtvet
{
    public partial class PictureViewForm : Form
    {
        private Stream imageStream;
        private string pictureUrl;
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
            loadingTask = Task.Run(LoadPicture);
        }

        private void PictureViewForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            imageStream?.Dispose();
            loadingTask?.Dispose();
        }

        private void LoadPicture()
        {
            try
            {
                Image picture;

                if (CachedPictures.ContainsKey(pictureUrl))
                {
                    picture = CachedPictures[pictureUrl];
                }
                else
                {
                    imageStream = HelpClass.DownloadImageAsStream(pictureUrl);
                    picture = Image.FromStream(imageStream);

                    if (ImageFormat.Gif.Equals(picture.RawFormat) == false)
                    {
                        imageStream.Dispose();
                        CachedPictures.Add(pictureUrl, picture);
                    }
                }

                PictureView.Image = picture;
            }
            catch (Exception)
            {
                PictureView.Image = PictureView.ErrorImage;
            }
        }
    }
}
