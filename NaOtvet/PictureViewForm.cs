using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace NaOtvet
{
    public partial class PictureViewForm : Form
    {
        public static Dictionary<string, Image> CachedPictures { get; private set; } = new Dictionary<string, Image>();

        public PictureViewForm(string pictureUrl, string description)
        {
            if (pictureUrl is null)
                throw new ArgumentNullException(nameof(pictureUrl));

            if (description is null)
                throw new ArgumentNullException(nameof(description));

            InitializeComponent();

            try
            {
                Image picture;

                if (CachedPictures.ContainsKey(pictureUrl))
                {
                    picture = CachedPictures[pictureUrl];
                }
                else
                {
                    picture = HelpClass.DownloadImage(pictureUrl);
                    CachedPictures.Add(pictureUrl, picture);
                }

                PictureView.Image = picture;
            }
            catch (Exception)
            {
                PictureView.Image = PictureView.ErrorImage;
            }

            DescriptionText.Text = description;
        }
    }
}
