using NaUrokApiClient;
using System;
using System.Diagnostics;
using System.Windows.Forms;

namespace NaOtvet
{
    public partial class TestInfoForm : Form
    {
        private TestSession testSession;

        public TestInfoForm(TestSession session)
        {
            if (session is null)
                throw new ArgumentNullException();

            testSession = session;

            InitializeComponent();
        }

        private void TestInfoForm_Load(object sender, EventArgs e)
        {
            UpdateInfo();
        }

        private void UpdateInfo()
        {
            if (testSession.TestName != null)
            {
                TestNameText.Text = testSession.TestName;
            }
            else
            {
                TestNameText.Text = "-";

                TestNameText.Enabled = false;
                TestNameLabel.Enabled = false;
            }

            if (testSession.CreatorId.HasValue)
            {
                TeacherAccountLink.Click += (sender, args) => Process.Start(NaUrokClient.GetProfileUrl(testSession.CreatorId.Value));
            }
            else
            {
                TeacherAccountLink.Enabled = false;
                TeacherLabel.Enabled = false;
            }

            if (testSession.TestStartDateTime.HasValue)
            {
                CreateDateTimeText.Text = testSession.TestStartDateTime.Value.ToString();
            }
            else
            {
                CreateDateTimeText.Text = "-";

                CreateDateTimeText.Enabled = false;
                CreateDateTimeLabel.Enabled = false;
            }

            if (testSession.TestEndDateTime.HasValue)
            {
                EndDateTimeText.Text = testSession.TestEndDateTime.Value.ToString();
            }
            else
            {
                EndDateTimeText.Text = "-";

                EndDateTimeText.Enabled = false;
                EndDateTimeLabel.Enabled = false;
            }

            StartDateTimeText.Text = testSession.StartDateTime.ToString();

            if (testSession.Duration.HasValue)
            {
                DurationText.Text = string.Empty;

                if (testSession.Duration.Value.Hours > 0)
                    DurationText.Text += testSession.Duration.Value.Hours + "ч ";
                
                DurationText.Text += testSession.Duration.Value.Minutes+ "мин";
            }
            else
            {
                DurationText.Text = "-";

                DurationText.Enabled = false;
                DurationLabel.Enabled = false;
            }

            QuestionsCountText.Text = testSession.TestQuestionsCount.ToString();
        }

        private void ShowQuestionsButton_Click(object sender, EventArgs e)
        {
            new QuestionsViewForm(testSession.Questions, false).Show();
        }
    }
}
