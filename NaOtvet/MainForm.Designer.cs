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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.LogText = new System.Windows.Forms.TextBox();
            this.StartButton = new System.Windows.Forms.Button();
            this.UuIdText = new System.Windows.Forms.TextBox();
            this.StopButton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.LogoImage = new System.Windows.Forms.PictureBox();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.AnswersPage = new System.Windows.Forms.TabPage();
            this.label6 = new System.Windows.Forms.Label();
            this.ClearUuIdTextButton = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.GuidePage = new System.Windows.Forms.TabPage();
            this.label12 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.JoinNaurokLabel = new System.Windows.Forms.LinkLabel();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.OpenTestButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.LogoImage)).BeginInit();
            this.tabControl1.SuspendLayout();
            this.AnswersPage.SuspendLayout();
            this.GuidePage.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            this.SuspendLayout();
            // 
            // LogText
            // 
            this.LogText.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.LogText.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.LogText.Location = new System.Drawing.Point(6, 118);
            this.LogText.MaxLength = 600000;
            this.LogText.Multiline = true;
            this.LogText.Name = "LogText";
            this.LogText.ReadOnly = true;
            this.LogText.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.LogText.Size = new System.Drawing.Size(248, 221);
            this.LogText.TabIndex = 0;
            this.LogText.TabStop = false;
            // 
            // StartButton
            // 
            this.StartButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.StartButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.StartButton.Location = new System.Drawing.Point(0, 0);
            this.StartButton.Name = "StartButton";
            this.StartButton.Size = new System.Drawing.Size(180, 41);
            this.StartButton.TabIndex = 2;
            this.StartButton.Text = "Старт";
            this.StartButton.UseVisualStyleBackColor = true;
            this.StartButton.Click += new System.EventHandler(this.StartButton_Click);
            // 
            // UuIdText
            // 
            this.UuIdText.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.UuIdText.Location = new System.Drawing.Point(53, 6);
            this.UuIdText.Name = "UuIdText";
            this.UuIdText.Size = new System.Drawing.Size(433, 22);
            this.UuIdText.TabIndex = 0;
            this.UuIdText.TextChanged += new System.EventHandler(this.UuIdText_TextChanged);
            // 
            // StopButton
            // 
            this.StopButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.StopButton.Enabled = false;
            this.StopButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.StopButton.Location = new System.Drawing.Point(0, 0);
            this.StopButton.Name = "StopButton";
            this.StopButton.Size = new System.Drawing.Size(134, 41);
            this.StopButton.TabIndex = 3;
            this.StopButton.Text = "Стоп";
            this.StopButton.UseVisualStyleBackColor = true;
            this.StopButton.Click += new System.EventHandler(this.StopButton_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.label1.Location = new System.Drawing.Point(6, 90);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(52, 25);
            this.label1.TabIndex = 4;
            this.label1.Text = "Лог:";
            // 
            // splitContainer1
            // 
            this.splitContainer1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.splitContainer1.Location = new System.Drawing.Point(6, 34);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.StartButton);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.splitContainer2);
            this.splitContainer1.Size = new System.Drawing.Size(510, 41);
            this.splitContainer1.SplitterDistance = 180;
            this.splitContainer1.TabIndex = 5;
            // 
            // LogoImage
            // 
            this.LogoImage.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.LogoImage.BackColor = System.Drawing.Color.Black;
            this.LogoImage.Cursor = System.Windows.Forms.Cursors.Hand;
            this.LogoImage.Image = global::NaOtvet.Properties.Resources.kuzcode_logo;
            this.LogoImage.Location = new System.Drawing.Point(260, 118);
            this.LogoImage.Name = "LogoImage";
            this.LogoImage.Size = new System.Drawing.Size(256, 221);
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
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.Padding = new System.Drawing.Point(0, 0);
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(532, 376);
            this.tabControl1.TabIndex = 7;
            this.tabControl1.Selected += new System.Windows.Forms.TabControlEventHandler(this.GuidePage_Selected);
            // 
            // AnswersPage
            // 
            this.AnswersPage.Controls.Add(this.label6);
            this.AnswersPage.Controls.Add(this.ClearUuIdTextButton);
            this.AnswersPage.Controls.Add(this.label2);
            this.AnswersPage.Controls.Add(this.UuIdText);
            this.AnswersPage.Controls.Add(this.LogoImage);
            this.AnswersPage.Controls.Add(this.LogText);
            this.AnswersPage.Controls.Add(this.splitContainer1);
            this.AnswersPage.Controls.Add(this.label1);
            this.AnswersPage.Location = new System.Drawing.Point(4, 25);
            this.AnswersPage.Name = "AnswersPage";
            this.AnswersPage.Padding = new System.Windows.Forms.Padding(3);
            this.AnswersPage.Size = new System.Drawing.Size(524, 347);
            this.AnswersPage.TabIndex = 0;
            this.AnswersPage.Text = "Поиск ответов";
            this.AnswersPage.UseVisualStyleBackColor = true;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(6, 9);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(41, 17);
            this.label6.TabIndex = 8;
            this.label6.Text = "UuId:";
            // 
            // ClearUuIdTextButton
            // 
            this.ClearUuIdTextButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.ClearUuIdTextButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.ClearUuIdTextButton.Location = new System.Drawing.Point(492, 5);
            this.ClearUuIdTextButton.Name = "ClearUuIdTextButton";
            this.ClearUuIdTextButton.Size = new System.Drawing.Size(24, 24);
            this.ClearUuIdTextButton.TabIndex = 1;
            this.ClearUuIdTextButton.Text = "X";
            this.ClearUuIdTextButton.UseVisualStyleBackColor = true;
            this.ClearUuIdTextButton.Click += new System.EventHandler(this.ClearUuIdTextButton_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.label2.Location = new System.Drawing.Point(255, 90);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(183, 25);
            this.label2.TabIndex = 7;
            this.label2.Text = "Автор (нажмите):";
            // 
            // GuidePage
            // 
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
            this.GuidePage.Location = new System.Drawing.Point(4, 25);
            this.GuidePage.Name = "GuidePage";
            this.GuidePage.Padding = new System.Windows.Forms.Padding(3);
            this.GuidePage.Size = new System.Drawing.Size(524, 347);
            this.GuidePage.TabIndex = 1;
            this.GuidePage.Text = "Как пользоваться";
            this.GuidePage.UseVisualStyleBackColor = true;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.label12.Location = new System.Drawing.Point(8, 317);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(470, 25);
            this.label12.TabIndex = 10;
            this.label12.Text = "Шаг 8: по окончанию, появиться окно с ответами";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.label11.Location = new System.Drawing.Point(8, 279);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(508, 25);
            this.label11.TabIndex = 9;
            this.label11.Text = "Шаг 7: ожидайте (может занять от секунды до часу)";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.label10.Location = new System.Drawing.Point(8, 241);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(306, 25);
            this.label10.TabIndex = 8;
            this.label10.Text = "Шаг 6: нажмите кнопку \"Старт\"";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.label9.Location = new System.Drawing.Point(8, 203);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(473, 25);
            this.label9.TabIndex = 7;
            this.label9.Text = "Шаг 5: если всё правильно, поле станет зелёным";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F);
            this.label8.ForeColor = System.Drawing.Color.Red;
            this.label8.Location = new System.Drawing.Point(10, 135);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(427, 17);
            this.label8.TabIndex = 6;
            this.label8.Text = "Все следующие шаги нужно делать во вкладке \"Поиск ответов\"";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.label7.Location = new System.Drawing.Point(8, 165);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(353, 25);
            this.label7.TabIndex = 5;
            this.label7.Text = "Шаг 4: вставить ссылку в поле \"UuId\"";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.label5.Location = new System.Drawing.Point(8, 86);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(260, 25);
            this.label5.TabIndex = 4;
            this.label5.Text = "Шаг 3: скопировать ссылку";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.label4.Location = new System.Drawing.Point(8, 48);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(473, 25);
            this.label4.TabIndex = 3;
            this.label4.Text = "Шаг 2: ввести код, имя и нажать присоединиться";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.label3.Location = new System.Drawing.Point(8, 13);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(250, 25);
            this.label3.TabIndex = 2;
            this.label3.Text = "Шаг 1: перейти по ссылке";
            // 
            // JoinNaurokLabel
            // 
            this.JoinNaurokLabel.AutoSize = true;
            this.JoinNaurokLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.JoinNaurokLabel.Location = new System.Drawing.Point(252, 13);
            this.JoinNaurokLabel.Name = "JoinNaurokLabel";
            this.JoinNaurokLabel.Size = new System.Drawing.Size(214, 25);
            this.JoinNaurokLabel.TabIndex = 1;
            this.JoinNaurokLabel.TabStop = true;
            this.JoinNaurokLabel.Text = "naurok.com.ua/test/join";
            this.JoinNaurokLabel.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.JoinNaurokLabel_LinkClicked);
            // 
            // splitContainer2
            // 
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.Location = new System.Drawing.Point(0, 0);
            this.splitContainer2.Name = "splitContainer2";
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.OpenTestButton);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.StopButton);
            this.splitContainer2.Size = new System.Drawing.Size(326, 41);
            this.splitContainer2.SplitterDistance = 188;
            this.splitContainer2.TabIndex = 0;
            // 
            // OpenTestButton
            // 
            this.OpenTestButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.OpenTestButton.Enabled = false;
            this.OpenTestButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.OpenTestButton.Location = new System.Drawing.Point(0, 0);
            this.OpenTestButton.Name = "OpenTestButton";
            this.OpenTestButton.Size = new System.Drawing.Size(188, 41);
            this.OpenTestButton.TabIndex = 4;
            this.OpenTestButton.Text = "Открыть тест";
            this.OpenTestButton.UseVisualStyleBackColor = true;
            this.OpenTestButton.Click += new System.EventHandler(this.OpenTestButton_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(532, 376);
            this.Controls.Add(this.tabControl1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximumSize = new System.Drawing.Size(790, 650);
            this.MinimumSize = new System.Drawing.Size(550, 423);
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
            ((System.ComponentModel.ISupportInitialize)(this.LogoImage)).EndInit();
            this.tabControl1.ResumeLayout(false);
            this.AnswersPage.ResumeLayout(false);
            this.AnswersPage.PerformLayout();
            this.GuidePage.ResumeLayout(false);
            this.GuidePage.PerformLayout();
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TextBox LogText;
        private System.Windows.Forms.Button StartButton;
        private System.Windows.Forms.TextBox UuIdText;
        private System.Windows.Forms.Button StopButton;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.PictureBox LogoImage;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage AnswersPage;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TabPage GuidePage;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.LinkLabel JoinNaurokLabel;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button ClearUuIdTextButton;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.Button OpenTestButton;
    }
}

