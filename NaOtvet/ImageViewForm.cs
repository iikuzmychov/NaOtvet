using System;
using System.Windows.Forms;

namespace NaOtvet
{
    public partial class ImageViewForm : Form
    {
        public ImageViewForm(string imageUrl, string description)
        {
            if (imageUrl is null)
                throw new ArgumentNullException(nameof(imageUrl));

            if (description is null)
                throw new ArgumentNullException(nameof(description));

            InitializeComponent();

            try
            {
                MainImage.Image = HelpClass.DownloadImage(imageUrl);
            }
            catch (Exception)
            {
                MainImage.Image = MainImage.ErrorImage;
            }

            DescriptionText.Text = description;
        }
    }
}
