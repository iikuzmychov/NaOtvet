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

        private void TestInfoForm_Load(object sender, System.EventArgs e)
        {
            UpdateInfo();
        }

        private void UpdateInfo()
        {
            TestNameText.Text = testSession.TestName != null ? testSession.TestName : "-";

            if (testSession.CreatorId.HasValue)
                TeacherAccountLink.Click += (sender, args) => Process.Start(NaUrokClient.GetProfileUrl(testSession.CreatorId.Value));
            else
                TeacherAccountLink.Enabled = false;

            CreateDateTimeText.Text = testSession.TestStartDateTime.HasValue ? testSession.TestStartDateTime.Value.ToString() : "-";
            EndDateTimeText.Text    = testSession.TestEndDateTime.HasValue ? testSession.TestEndDateTime.Value.ToString() : "-";
            StartDateTimeText.Text  = testSession.StartDateTime.ToString();

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
            }

            QuestionsCountText.Text = testSession.TestQuestionsCount.ToString();
        }
    }
}
