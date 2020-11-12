using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NaOtvet
{
    public partial class LoadingForm : Form
    {
        private Stopwatch stopwatch;

        public LoadingForm()
        {
            InitializeComponent();
        }

        private void LoadingForm_Load(object sender, EventArgs e)
        {
            stopwatch = new Stopwatch();
            Timer1.Start();
            stopwatch.Start();
        }

        private void Timer1_Tick(object sender, EventArgs e)
        {
            PassedTimeText.Text = stopwatch.Elapsed.ToString("mm\\:ss");
        }
    }
}
