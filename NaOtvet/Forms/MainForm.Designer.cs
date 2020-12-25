using System.Windows.Forms;

namespace NaOtvet
{
    partial class MainForm
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.LogText = new TextBox();
            this.UuIdText = new TextBox();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.StartButton = new NaOtvet.CustomizableButton();
            this.splitContainer3 = new System.Windows.Forms.SplitContainer();
            this.OpenTestButton = new NaOtvet.CustomizableButton();
            this.StopButton = new NaOtvet.CustomizableButton();
            this.LogoImage = new System.Windows.Forms.PictureBox();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.AnswersPage = new System.Windows.Forms.TabPage();
            this.UuIdTextPanel = new System.Windows.Forms.Panel();
            this.LogPanel = new System.Windows.Forms.Panel();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.TestInfoButton = new NaOtvet.CustomizableButton();
            this.TestTimeLeftText = new NaOtvet.CustomizableLabel();
            this.label13 = new NaOtvet.CustomizableLabel();
            this.label6 = new NaOtvet.CustomizableLabel();
            this.ClearUuIdTextButton = new NaOtvet.CustomizableButton();
            this.label2 = new NaOtvet.CustomizableLabel();
            this.label1 = new NaOtvet.CustomizableLabel();
            this.GuidePage = new System.Windows.Forms.TabPage();
            this.label12 = new NaOtvet.CustomizableLabel();
            this.label11 = new NaOtvet.CustomizableLabel();
            this.label10 = new NaOtvet.CustomizableLabel();
            this.label9 = new NaOtvet.CustomizableLabel();
            this.label8 = new NaOtvet.CustomizableLabel();
            this.label7 = new NaOtvet.CustomizableLabel();
            this.label5 = new NaOtvet.CustomizableLabel();
            this.label4 = new NaOtvet.CustomizableLabel();
            this.label3 = new NaOtvet.CustomizableLabel();
            this.JoinNaurokLabel = new System.Windows.Forms.LinkLabel();
            this.TestTimer = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer3)).BeginInit();
            this.splitContainer3.Panel1.SuspendLayout();
            this.splitContainer3.Panel2.SuspendLayout();
            this.splitContainer3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.LogoImage)).BeginInit();
            this.tabControl1.SuspendLayout();
            this.AnswersPage.SuspendLayout();
            this.UuIdTextPanel.SuspendLayout();
            this.LogPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            this.GuidePage.SuspendLayout();
            this.SuspendLayout();
            // 
            // LogText
            // 
            this.LogText.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.LogText.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.LogText.Dock = System.Windows.Forms.DockStyle.Fill;
            this.LogText.Font = new System.Drawing.Font("Montserrat", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.LogText.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(150)))), ((int)(((byte)(150)))), ((int)(((byte)(150)))));
            this.LogText.Location = new System.Drawing.Point(5, 5);
            this.LogText.MaxLength = 600000;
            this.LogText.Multiline = true;
            this.LogText.Name = "LogText";
            this.LogText.ReadOnly = true;
            this.LogText.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.LogText.Size = new System.Drawing.Size(238, 210);
            this.LogText.TabIndex = 0;
            this.LogText.TabStop = false;
            // 
            // UuIdText
            // 
            this.UuIdText.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.UuIdText.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.UuIdText.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.UuIdText.Font = new System.Drawing.Font("Montserrat", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.UuIdText.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(230)))), ((int)(((byte)(230)))));
            this.UuIdText.Location = new System.Drawing.Point(8, 4);
            this.UuIdText.Name = "UuIdText";
            this.UuIdText.Size = new System.Drawing.Size(412, 25);
            this.UuIdText.TabIndex = 0;
            this.UuIdText.TextChanged += new System.EventHandler(this.UuIdText_TextChanged);
            // 
            // splitContainer1
            // 
            this.splitContainer1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.splitContainer1.Location = new System.Drawing.Point(8, 51);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.StartButton);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.splitContainer3);
            this.splitContainer1.Size = new System.Drawing.Size(544, 41);
            this.splitContainer1.SplitterDistance = 116;
            this.splitContainer1.SplitterWidth = 6;
            this.splitContainer1.TabIndex = 5;
            // 
            // StartButton
            // 
            this.StartButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.StartButton.DisabledForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(80)))), ((int)(((byte)(80)))));
            this.StartButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.StartButton.FlatAppearance.BorderSize = 0;
            this.StartButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.StartButton.Font = new System.Drawing.Font("Montserrat", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.StartButton.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(230)))), ((int)(((byte)(230)))));
            this.StartButton.Location = new System.Drawing.Point(0, 0);
            this.StartButton.Name = "StartButton";
            this.StartButton.Size = new System.Drawing.Size(116, 41);
            this.StartButton.TabIndex = 2;
            this.StartButton.Text = "Старт";
            this.StartButton.UseVisualStyleBackColor = false;
            this.StartButton.Click += new System.EventHandler(this.StartButton_Click);
            // 
            // splitContainer3
            // 
            this.splitContainer3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer3.IsSplitterFixed = true;
            this.splitContainer3.Location = new System.Drawing.Point(0, 0);
            this.splitContainer3.Name = "splitContainer3";
            // 
            // splitContainer3.Panel1
            // 
            this.splitContainer3.Panel1.Controls.Add(this.OpenTestButton);
            // 
            // splitContainer3.Panel2
            // 
            this.splitContainer3.Panel2.Controls.Add(this.StopButton);
            this.splitContainer3.Size = new System.Drawing.Size(422, 41);
            this.splitContainer3.SplitterDistance = 178;
            this.splitContainer3.SplitterWidth = 6;
            this.splitContainer3.TabIndex = 0;
            // 
            // OpenTestButton
            // 
            this.OpenTestButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.OpenTestButton.DisabledForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(80)))), ((int)(((byte)(80)))));
            this.OpenTestButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.OpenTestButton.Enabled = false;
            this.OpenTestButton.FlatAppearance.BorderSize = 0;
            this.OpenTestButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.OpenTestButton.Font = new System.Drawing.Font("Montserrat", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.OpenTestButton.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(230)))), ((int)(((byte)(230)))));
            this.OpenTestButton.Location = new System.Drawing.Point(0, 0);
            this.OpenTestButton.Name = "OpenTestButton";
            this.OpenTestButton.Size = new System.Drawing.Size(178, 41);
            this.OpenTestButton.TabIndex = 4;
            this.OpenTestButton.Text = "Открыть тест";
            this.OpenTestButton.UseVisualStyleBackColor = true;
            this.OpenTestButton.Click += new System.EventHandler(this.OpenTestButton_Click);
            // 
            // StopButton
            // 
            this.StopButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.StopButton.DisabledForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(80)))), ((int)(((byte)(80)))));
            this.StopButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.StopButton.Enabled = false;
            this.StopButton.FlatAppearance.BorderSize = 0;
            this.StopButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.StopButton.Font = new System.Drawing.Font("Montserrat", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.StopButton.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(230)))), ((int)(((byte)(230)))));
            this.StopButton.Location = new System.Drawing.Point(0, 0);
            this.StopButton.Name = "StopButton";
            this.StopButton.Size = new System.Drawing.Size(238, 41);
            this.StopButton.TabIndex = 3;
            this.StopButton.Text = "Стоп";
            this.StopButton.UseVisualStyleBackColor = false;
            this.StopButton.Click += new System.EventHandler(this.StopButton_Click);
            // 
            // LogoImage
            // 
            this.LogoImage.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.LogoImage.BackColor = System.Drawing.Color.Black;
            this.LogoImage.Cursor = System.Windows.Forms.Cursors.Hand;
            this.LogoImage.Image = global::NaOtvet.Properties.Resources.kuzcode_logo;
            this.LogoImage.Location = new System.Drawing.Point(262, 188);
            this.LogoImage.Name = "LogoImage";
            this.LogoImage.Size = new System.Drawing.Size(290, 220);
            this.LogoImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.LogoImage.TabIndex = 6;
            this.LogoImage.TabStop = false;
            this.LogoImage.Click += new System.EventHandler(this.LogoImage_Click);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.AnswersPage);
            this.tabControl1.Controls.Add(this.GuidePage);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Font = new System.Drawing.Font("Montserrat", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Multiline = true;
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.Padding = new System.Drawing.Point(0, 0);
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(570, 449);
            this.tabControl1.TabIndex = 7;
            this.tabControl1.Selected += new System.Windows.Forms.TabControlEventHandler(this.GuidePage_Selected);
            // 
            // AnswersPage
            // 
            this.AnswersPage.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.AnswersPage.Controls.Add(this.UuIdTextPanel);
            this.AnswersPage.Controls.Add(this.LogPanel);
            this.AnswersPage.Controls.Add(this.splitContainer2);
            this.AnswersPage.Controls.Add(this.label6);
            this.AnswersPage.Controls.Add(this.ClearUuIdTextButton);
            this.AnswersPage.Controls.Add(this.label2);
            this.AnswersPage.Controls.Add(this.LogoImage);
            this.AnswersPage.Controls.Add(this.splitContainer1);
            this.AnswersPage.Controls.Add(this.label1);
            this.AnswersPage.Location = new System.Drawing.Point(4, 27);
            this.AnswersPage.Name = "AnswersPage";
            this.AnswersPage.Padding = new System.Windows.Forms.Padding(5);
            this.AnswersPage.Size = new System.Drawing.Size(562, 418);
            this.AnswersPage.TabIndex = 0;
            this.AnswersPage.Text = "Поиск ответов";
            // 
            // UuIdTextPanel
            // 
            this.UuIdTextPanel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.UuIdTextPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.UuIdTextPanel.Controls.Add(this.UuIdText);
            this.UuIdTextPanel.Location = new System.Drawing.Point(81, 8);
            this.UuIdTextPanel.Name = "UuIdTextPanel";
            this.UuIdTextPanel.Padding = new System.Windows.Forms.Padding(5);
            this.UuIdTextPanel.Size = new System.Drawing.Size(428, 37);
            this.UuIdTextPanel.TabIndex = 11;
            this.UuIdTextPanel.Click += new System.EventHandler(this.UuIdTextPanel_Click);
            // 
            // LogPanel
            // 
            this.LogPanel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.LogPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.LogPanel.Controls.Add(this.LogText);
            this.LogPanel.Location = new System.Drawing.Point(8, 188);
            this.LogPanel.Name = "LogPanel";
            this.LogPanel.Padding = new System.Windows.Forms.Padding(5);
            this.LogPanel.Size = new System.Drawing.Size(248, 220);
            this.LogPanel.TabIndex = 10;
            // 
            // splitContainer2
            // 
            this.splitContainer2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.splitContainer2.FixedPanel = System.Windows.Forms.FixedPanel.Panel2;
            this.splitContainer2.IsSplitterFixed = true;
            this.splitContainer2.Location = new System.Drawing.Point(8, 98);
            this.splitContainer2.Name = "splitContainer2";
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.TestInfoButton);
            this.splitContainer2.Panel1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.TestTimeLeftText);
            this.splitContainer2.Panel2.Controls.Add(this.label13);
            this.splitContainer2.Panel2.Enabled = false;
            this.splitContainer2.Panel2.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.splitContainer2.Size = new System.Drawing.Size(544, 41);
            this.splitContainer2.SplitterDistance = 220;
            this.splitContainer2.TabIndex = 9;
            // 
            // TestInfoButton
            // 
            this.TestInfoButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.TestInfoButton.DisabledForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(80)))), ((int)(((byte)(80)))));
            this.TestInfoButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TestInfoButton.Enabled = false;
            this.TestInfoButton.FlatAppearance.BorderSize = 0;
            this.TestInfoButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.TestInfoButton.Font = new System.Drawing.Font("Montserrat", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.TestInfoButton.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(230)))), ((int)(((byte)(230)))));
            this.TestInfoButton.Location = new System.Drawing.Point(0, 0);
            this.TestInfoButton.Name = "TestInfoButton";
            this.TestInfoButton.Size = new System.Drawing.Size(220, 41);
            this.TestInfoButton.TabIndex = 10;
            this.TestInfoButton.Text = "Про тест";
            this.TestInfoButton.UseVisualStyleBackColor = false;
            this.TestInfoButton.Click += new System.EventHandler(this.TestInfoButton_Click);
            // 
            // TestTimeLeftText
            // 
            this.TestTimeLeftText.DisabledForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(80)))), ((int)(((byte)(80)))));
            this.TestTimeLeftText.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TestTimeLeftText.Font = new System.Drawing.Font("Montserrat", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.TestTimeLeftText.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(230)))), ((int)(((byte)(230)))));
            this.TestTimeLeftText.Location = new System.Drawing.Point(221, 0);
            this.TestTimeLeftText.Margin = new System.Windows.Forms.Padding(0);
            this.TestTimeLeftText.Name = "TestTimeLeftText";
            this.TestTimeLeftText.Size = new System.Drawing.Size(99, 41);
            this.TestTimeLeftText.TabIndex = 11;
            this.TestTimeLeftText.Text = "00:00:00";
            this.TestTimeLeftText.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label13
            // 
            this.label13.DisabledForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(80)))), ((int)(((byte)(80)))));
            this.label13.Dock = System.Windows.Forms.DockStyle.Left;
            this.label13.Font = new System.Drawing.Font("Montserrat", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label13.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(230)))), ((int)(((byte)(230)))));
            this.label13.Location = new System.Drawing.Point(0, 0);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(221, 41);
            this.label13.TabIndex = 10;
            this.label13.Text = "Ограничение теста:";
            this.label13.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.DisabledForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(80)))), ((int)(((byte)(80)))));
            this.label6.Font = new System.Drawing.Font("Montserrat", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(230)))), ((int)(((byte)(230)))));
            this.label6.Location = new System.Drawing.Point(10, 12);
            this.label6.Margin = new System.Windows.Forms.Padding(5, 0, 3, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(65, 27);
            this.label6.TabIndex = 8;
            this.label6.Text = "UuId:";
            // 
            // ClearUuIdTextButton
            // 
            this.ClearUuIdTextButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.ClearUuIdTextButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.ClearUuIdTextButton.DisabledForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(80)))), ((int)(((byte)(80)))));
            this.ClearUuIdTextButton.FlatAppearance.BorderSize = 0;
            this.ClearUuIdTextButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ClearUuIdTextButton.Font = new System.Drawing.Font("Montserrat", 12F);
            this.ClearUuIdTextButton.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(230)))), ((int)(((byte)(230)))));
            this.ClearUuIdTextButton.Location = new System.Drawing.Point(515, 8);
            this.ClearUuIdTextButton.Name = "ClearUuIdTextButton";
            this.ClearUuIdTextButton.Size = new System.Drawing.Size(37, 37);
            this.ClearUuIdTextButton.TabIndex = 1;
            this.ClearUuIdTextButton.Text = "X";
            this.ClearUuIdTextButton.UseVisualStyleBackColor = false;
            this.ClearUuIdTextButton.Click += new System.EventHandler(this.ClearUuIdTextButton_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.DisabledForeColor = System.Drawing.Color.Empty;
            this.label2.Font = new System.Drawing.Font("Montserrat", 12F);
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(150)))), ((int)(((byte)(150)))), ((int)(((byte)(150)))));
            this.label2.Location = new System.Drawing.Point(262, 158);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(192, 27);
            this.label2.TabIndex = 7;
            this.label2.Text = "Автор (нажмите):";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.DisabledForeColor = System.Drawing.Color.Empty;
            this.label1.Font = new System.Drawing.Font("Montserrat", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(230)))), ((int)(((byte)(230)))));
            this.label1.Location = new System.Drawing.Point(8, 158);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(55, 27);
            this.label1.TabIndex = 4;
            this.label1.Text = "Лог:";
            // 
            // GuidePage
            // 
            this.GuidePage.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.GuidePage.Controls.Add(this.label12);
            this.GuidePage.Controls.Add(this.label11);
            this.GuidePage.Controls.Add(this.label10);
            this.GuidePage.Controls.Add(this.label9);
            this.GuidePage.Controls.Add(this.label8);
            this.GuidePage.Controls.Add(this.label7);
            this.GuidePage.Controls.Add(this.label5);
            this.GuidePage.Controls.Add(this.label4);
            this.GuidePage.Controls.Add(this.label3);
            this.GuidePage.Controls.Add(this.JoinNaurokLabel);
            this.GuidePage.Location = new System.Drawing.Point(4, 27);
            this.GuidePage.Name = "GuidePage";
            this.GuidePage.Padding = new System.Windows.Forms.Padding(5);
            this.GuidePage.Size = new System.Drawing.Size(562, 418);
            this.GuidePage.TabIndex = 1;
            this.GuidePage.Text = "Как пользоваться";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.DisabledForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(80)))), ((int)(((byte)(80)))));
            this.label12.Font = new System.Drawing.Font("Montserrat", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label12.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(150)))), ((int)(((byte)(150)))), ((int)(((byte)(150)))));
            this.label12.Location = new System.Drawing.Point(8, 303);
            this.label12.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(526, 27);
            this.label12.TabIndex = 10;
            this.label12.Text = "Шаг 8: по окончанию, появиться окно с ответами";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.DisabledForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(80)))), ((int)(((byte)(80)))));
            this.label11.Font = new System.Drawing.Font("Montserrat", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label11.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(150)))), ((int)(((byte)(150)))), ((int)(((byte)(150)))));
            this.label11.Location = new System.Drawing.Point(8, 266);
            this.label11.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(353, 27);
            this.label11.TabIndex = 9;
            this.label11.Text = "Шаг 7: ожидайте какое-то время";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.DisabledForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(80)))), ((int)(((byte)(80)))));
            this.label10.Font = new System.Drawing.Font("Montserrat", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label10.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(150)))), ((int)(((byte)(150)))), ((int)(((byte)(150)))));
            this.label10.Location = new System.Drawing.Point(7, 229);
            this.label10.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(332, 27);
            this.label10.TabIndex = 8;
            this.label10.Text = "Шаг 6: нажмите кнопку \"Старт\"";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.DisabledForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(80)))), ((int)(((byte)(80)))));
            this.label9.Font = new System.Drawing.Font("Montserrat", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label9.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(150)))), ((int)(((byte)(150)))), ((int)(((byte)(150)))));
            this.label9.Location = new System.Drawing.Point(7, 192);
            this.label9.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(523, 27);
            this.label9.TabIndex = 7;
            this.label9.Text = "Шаг 5: если всё правильно, поле станет зелёным";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.DisabledForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(170)))), ((int)(((byte)(25)))), ((int)(((byte)(25)))));
            this.label8.Font = new System.Drawing.Font("Montserrat", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label8.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(36)))), ((int)(((byte)(36)))));
            this.label8.Location = new System.Drawing.Point(9, 124);
            this.label8.Margin = new System.Windows.Forms.Padding(3, 8, 3, 5);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(507, 21);
            this.label8.TabIndex = 6;
            this.label8.Text = "Все следующие шаги нужно делать во вкладке \"Поиск ответов\"";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.DisabledForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(80)))), ((int)(((byte)(80)))));
            this.label7.Font = new System.Drawing.Font("Montserrat", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label7.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(150)))), ((int)(((byte)(150)))), ((int)(((byte)(150)))));
            this.label7.Location = new System.Drawing.Point(7, 155);
            this.label7.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(392, 27);
            this.label7.TabIndex = 5;
            this.label7.Text = "Шаг 4: вставить ссылку в поле \"UuId\"";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.DisabledForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(80)))), ((int)(((byte)(80)))));
            this.label5.Font = new System.Drawing.Font("Montserrat", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(150)))), ((int)(((byte)(150)))), ((int)(((byte)(150)))));
            this.label5.Location = new System.Drawing.Point(7, 84);
            this.label5.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(293, 27);
            this.label5.TabIndex = 4;
            this.label5.Text = "Шаг 3: скопировать ссылку";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.DisabledForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(80)))), ((int)(((byte)(80)))));
            this.label4.Font = new System.Drawing.Font("Montserrat", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(150)))), ((int)(((byte)(150)))), ((int)(((byte)(150)))));
            this.label4.Location = new System.Drawing.Point(7, 47);
            this.label4.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(524, 27);
            this.label4.TabIndex = 3;
            this.label4.Text = "Шаг 2: ввести код, имя и нажать присоединиться";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.DisabledForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(80)))), ((int)(((byte)(80)))));
            this.label3.Font = new System.Drawing.Font("Montserrat", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(150)))), ((int)(((byte)(150)))), ((int)(((byte)(150)))));
            this.label3.Location = new System.Drawing.Point(8, 10);
            this.label3.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(276, 27);
            this.label3.TabIndex = 2;
            this.label3.Text = "Шаг 1: перейти по ссылке";
            // 
            // JoinNaurokLabel
            // 
            this.JoinNaurokLabel.ActiveLinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(36)))), ((int)(((byte)(36)))));
            this.JoinNaurokLabel.AutoSize = true;
            this.JoinNaurokLabel.DisabledLinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(80)))), ((int)(((byte)(80)))));
            this.JoinNaurokLabel.Font = new System.Drawing.Font("Montserrat", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.JoinNaurokLabel.LinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(77)))), ((int)(((byte)(62)))), ((int)(((byte)(255)))));
            this.JoinNaurokLabel.Location = new System.Drawing.Point(280, 10);
            this.JoinNaurokLabel.Margin = new System.Windows.Forms.Padding(0, 5, 3, 5);
            this.JoinNaurokLabel.Name = "JoinNaurokLabel";
            this.JoinNaurokLabel.Size = new System.Drawing.Size(250, 27);
            this.JoinNaurokLabel.TabIndex = 1;
            this.JoinNaurokLabel.TabStop = true;
            this.JoinNaurokLabel.Text = "naurok.com.ua/test/join";
            this.JoinNaurokLabel.VisitedLinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(154)))), ((int)(((byte)(31)))), ((int)(((byte)(254)))));
            this.JoinNaurokLabel.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.JoinNaurokLabel_LinkClicked);
            // 
            // TestTimer
            // 
            this.TestTimer.Interval = 500;
            this.TestTimer.Tick += new System.EventHandler(this.TestTimer_Tick);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(570, 449);
            this.Controls.Add(this.tabControl1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(588, 496);
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "НаОтвет";
            this.TopMost = true;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.Shown += new System.EventHandler(this.MainForm_Shown);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.splitContainer3.Panel1.ResumeLayout(false);
            this.splitContainer3.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer3)).EndInit();
            this.splitContainer3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.LogoImage)).EndInit();
            this.tabControl1.ResumeLayout(false);
            this.AnswersPage.ResumeLayout(false);
            this.AnswersPage.PerformLayout();
            this.UuIdTextPanel.ResumeLayout(false);
            this.UuIdTextPanel.PerformLayout();
            this.LogPanel.ResumeLayout(false);
            this.LogPanel.PerformLayout();
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            this.GuidePage.ResumeLayout(false);
            this.GuidePage.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private TextBox LogText;
        private CustomizableButton StartButton;
        private TextBox UuIdText;
        private CustomizableButton StopButton;
        private CustomizableLabel label1;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.PictureBox LogoImage;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage AnswersPage;
        private CustomizableLabel label2;
        private System.Windows.Forms.TabPage GuidePage;
        private CustomizableLabel label3;
        private System.Windows.Forms.LinkLabel JoinNaurokLabel;
        private CustomizableLabel label4;
        private CustomizableButton ClearUuIdTextButton;
        private CustomizableLabel label6;
        private CustomizableLabel label8;
        private CustomizableLabel label7;
        private CustomizableLabel label10;
        private CustomizableLabel label9;
        private CustomizableLabel label12;
        private CustomizableLabel label11;
        private CustomizableButton OpenTestButton;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private CustomizableLabel TestTimeLeftText;
        private CustomizableLabel label13;
        private System.Windows.Forms.SplitContainer splitContainer3;
        private CustomizableButton TestInfoButton;
        private System.Windows.Forms.Timer TestTimer;
        private System.Windows.Forms.Panel LogPanel;
        private System.Windows.Forms.Panel UuIdTextPanel;
        private CustomizableLabel label5;
    }
}

