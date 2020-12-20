namespace NaOtvet
{
    partial class TestInfoForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TestInfoForm));
            this.TestNameLabel = new NaOtvet.CustomizableLabel();
            this.TeacherLabel = new NaOtvet.CustomizableLabel();
            this.label3 = new NaOtvet.CustomizableLabel();
            this.CreateDateTimeLabel = new NaOtvet.CustomizableLabel();
            this.EndDateTimeLabel = new NaOtvet.CustomizableLabel();
            this.DurationLabel = new NaOtvet.CustomizableLabel();
            this.TestNameText = new NaOtvet.CustomizableLabel();
            this.CreateDateTimeText = new NaOtvet.CustomizableLabel();
            this.EndDateTimeText = new NaOtvet.CustomizableLabel();
            this.QuestionsCountText = new NaOtvet.CustomizableLabel();
            this.DurationText = new NaOtvet.CustomizableLabel();
            this.TeacherAccountLink = new System.Windows.Forms.LinkLabel();
            this.label9 = new NaOtvet.CustomizableLabel();
            this.StartDateTimeText = new NaOtvet.CustomizableLabel();
            this.ShowQuestionsButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // TestNameLabel
            // 
            this.TestNameLabel.AutoSize = true;
            this.TestNameLabel.DisabledForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(150)))), ((int)(((byte)(150)))), ((int)(((byte)(150)))));
            this.TestNameLabel.Font = new System.Drawing.Font("Montserrat", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.TestNameLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(230)))), ((int)(((byte)(230)))));
            this.TestNameLabel.Location = new System.Drawing.Point(8, 17);
            this.TestNameLabel.Margin = new System.Windows.Forms.Padding(3);
            this.TestNameLabel.Name = "TestNameLabel";
            this.TestNameLabel.Size = new System.Drawing.Size(177, 27);
            this.TestNameLabel.TabIndex = 0;
            this.TestNameLabel.Text = "Название теста:";
            // 
            // TeacherLabel
            // 
            this.TeacherLabel.AutoSize = true;
            this.TeacherLabel.DisabledForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(150)))), ((int)(((byte)(150)))), ((int)(((byte)(150)))));
            this.TeacherLabel.Font = new System.Drawing.Font("Montserrat", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.TeacherLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(230)))), ((int)(((byte)(230)))));
            this.TeacherLabel.Location = new System.Drawing.Point(8, 50);
            this.TeacherLabel.Margin = new System.Windows.Forms.Padding(3);
            this.TeacherLabel.Name = "TeacherLabel";
            this.TeacherLabel.Size = new System.Drawing.Size(100, 27);
            this.TeacherLabel.TabIndex = 1;
            this.TeacherLabel.Text = "Учитель:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.DisabledForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(150)))), ((int)(((byte)(150)))), ((int)(((byte)(150)))));
            this.label3.Font = new System.Drawing.Font("Montserrat", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(230)))), ((int)(((byte)(230)))));
            this.label3.Location = new System.Drawing.Point(8, 215);
            this.label3.Margin = new System.Windows.Forms.Padding(3);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(194, 27);
            this.label3.TabIndex = 2;
            this.label3.Text = "Кол-во вопросов:";
            // 
            // CreateDateTimeLabel
            // 
            this.CreateDateTimeLabel.AutoSize = true;
            this.CreateDateTimeLabel.DisabledForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(150)))), ((int)(((byte)(150)))), ((int)(((byte)(150)))));
            this.CreateDateTimeLabel.Font = new System.Drawing.Font("Montserrat", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.CreateDateTimeLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(230)))), ((int)(((byte)(230)))));
            this.CreateDateTimeLabel.Location = new System.Drawing.Point(8, 83);
            this.CreateDateTimeLabel.Margin = new System.Windows.Forms.Padding(3);
            this.CreateDateTimeLabel.Name = "CreateDateTimeLabel";
            this.CreateDateTimeLabel.Size = new System.Drawing.Size(214, 27);
            this.CreateDateTimeLabel.TabIndex = 3;
            this.CreateDateTimeLabel.Text = "Открыт учителем в:";
            // 
            // EndDateTimeLabel
            // 
            this.EndDateTimeLabel.AutoSize = true;
            this.EndDateTimeLabel.DisabledForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(150)))), ((int)(((byte)(150)))), ((int)(((byte)(150)))));
            this.EndDateTimeLabel.Font = new System.Drawing.Font("Montserrat", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.EndDateTimeLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(230)))), ((int)(((byte)(230)))));
            this.EndDateTimeLabel.Location = new System.Drawing.Point(8, 116);
            this.EndDateTimeLabel.Margin = new System.Windows.Forms.Padding(3);
            this.EndDateTimeLabel.Name = "EndDateTimeLabel";
            this.EndDateTimeLabel.Size = new System.Drawing.Size(155, 27);
            this.EndDateTimeLabel.TabIndex = 4;
            this.EndDateTimeLabel.Text = "Закончится в:";
            // 
            // DurationLabel
            // 
            this.DurationLabel.AutoSize = true;
            this.DurationLabel.DisabledForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(150)))), ((int)(((byte)(150)))), ((int)(((byte)(150)))));
            this.DurationLabel.Font = new System.Drawing.Font("Montserrat", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.DurationLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(230)))), ((int)(((byte)(230)))));
            this.DurationLabel.Location = new System.Drawing.Point(8, 182);
            this.DurationLabel.Margin = new System.Windows.Forms.Padding(3);
            this.DurationLabel.Name = "DurationLabel";
            this.DurationLabel.Size = new System.Drawing.Size(161, 27);
            this.DurationLabel.TabIndex = 5;
            this.DurationLabel.Text = "Ограничение:";
            // 
            // TestNameText
            // 
            this.TestNameText.AutoEllipsis = true;
            this.TestNameText.AutoSize = true;
            this.TestNameText.DisabledForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(150)))), ((int)(((byte)(150)))), ((int)(((byte)(150)))));
            this.TestNameText.Font = new System.Drawing.Font("Montserrat", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.TestNameText.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(230)))), ((int)(((byte)(230)))));
            this.TestNameText.Location = new System.Drawing.Point(236, 17);
            this.TestNameText.Margin = new System.Windows.Forms.Padding(3);
            this.TestNameText.MaximumSize = new System.Drawing.Size(250, 27);
            this.TestNameText.Name = "TestNameText";
            this.TestNameText.Size = new System.Drawing.Size(65, 27);
            this.TestNameText.TabIndex = 7;
            this.TestNameText.Text = "текст";
            // 
            // CreateDateTimeText
            // 
            this.CreateDateTimeText.AutoSize = true;
            this.CreateDateTimeText.DisabledForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(150)))), ((int)(((byte)(150)))), ((int)(((byte)(150)))));
            this.CreateDateTimeText.Font = new System.Drawing.Font("Montserrat", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.CreateDateTimeText.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(230)))), ((int)(((byte)(230)))));
            this.CreateDateTimeText.Location = new System.Drawing.Point(236, 83);
            this.CreateDateTimeText.Margin = new System.Windows.Forms.Padding(3);
            this.CreateDateTimeText.Name = "CreateDateTimeText";
            this.CreateDateTimeText.Size = new System.Drawing.Size(65, 27);
            this.CreateDateTimeText.TabIndex = 9;
            this.CreateDateTimeText.Text = "текст";
            // 
            // EndDateTimeText
            // 
            this.EndDateTimeText.AutoSize = true;
            this.EndDateTimeText.DisabledForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(150)))), ((int)(((byte)(150)))), ((int)(((byte)(150)))));
            this.EndDateTimeText.Font = new System.Drawing.Font("Montserrat", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.EndDateTimeText.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(230)))), ((int)(((byte)(230)))));
            this.EndDateTimeText.Location = new System.Drawing.Point(236, 116);
            this.EndDateTimeText.Margin = new System.Windows.Forms.Padding(3);
            this.EndDateTimeText.Name = "EndDateTimeText";
            this.EndDateTimeText.Size = new System.Drawing.Size(65, 27);
            this.EndDateTimeText.TabIndex = 10;
            this.EndDateTimeText.Text = "текст";
            // 
            // QuestionsCountText
            // 
            this.QuestionsCountText.AutoSize = true;
            this.QuestionsCountText.DisabledForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(150)))), ((int)(((byte)(150)))), ((int)(((byte)(150)))));
            this.QuestionsCountText.Font = new System.Drawing.Font("Montserrat", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.QuestionsCountText.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(230)))), ((int)(((byte)(230)))));
            this.QuestionsCountText.Location = new System.Drawing.Point(236, 215);
            this.QuestionsCountText.Margin = new System.Windows.Forms.Padding(3);
            this.QuestionsCountText.Name = "QuestionsCountText";
            this.QuestionsCountText.Size = new System.Drawing.Size(65, 27);
            this.QuestionsCountText.TabIndex = 11;
            this.QuestionsCountText.Text = "текст";
            // 
            // DurationText
            // 
            this.DurationText.AutoSize = true;
            this.DurationText.DisabledForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(150)))), ((int)(((byte)(150)))), ((int)(((byte)(150)))));
            this.DurationText.Font = new System.Drawing.Font("Montserrat", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.DurationText.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(230)))), ((int)(((byte)(230)))));
            this.DurationText.Location = new System.Drawing.Point(236, 182);
            this.DurationText.Margin = new System.Windows.Forms.Padding(3);
            this.DurationText.Name = "DurationText";
            this.DurationText.Size = new System.Drawing.Size(65, 27);
            this.DurationText.TabIndex = 12;
            this.DurationText.Text = "текст";
            // 
            // TeacherAccountLink
            // 
            this.TeacherAccountLink.ActiveLinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(36)))), ((int)(((byte)(36)))));
            this.TeacherAccountLink.AutoSize = true;
            this.TeacherAccountLink.DisabledLinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(150)))), ((int)(((byte)(150)))), ((int)(((byte)(150)))));
            this.TeacherAccountLink.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.TeacherAccountLink.LinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(77)))), ((int)(((byte)(62)))), ((int)(((byte)(255)))));
            this.TeacherAccountLink.Location = new System.Drawing.Point(236, 52);
            this.TeacherAccountLink.Margin = new System.Windows.Forms.Padding(3);
            this.TeacherAccountLink.Name = "TeacherAccountLink";
            this.TeacherAccountLink.Size = new System.Drawing.Size(92, 25);
            this.TeacherAccountLink.TabIndex = 14;
            this.TeacherAccountLink.TabStop = true;
            this.TeacherAccountLink.Text = "(ссылка)";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.DisabledForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(150)))), ((int)(((byte)(150)))), ((int)(((byte)(150)))));
            this.label9.Font = new System.Drawing.Font("Montserrat", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label9.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(230)))), ((int)(((byte)(230)))));
            this.label9.Location = new System.Drawing.Point(8, 149);
            this.label9.Margin = new System.Windows.Forms.Padding(3);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(203, 27);
            this.label9.TabIndex = 16;
            this.label9.Text = "Начат учеником в:";
            // 
            // StartDateTimeText
            // 
            this.StartDateTimeText.AutoSize = true;
            this.StartDateTimeText.DisabledForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(150)))), ((int)(((byte)(150)))), ((int)(((byte)(150)))));
            this.StartDateTimeText.Font = new System.Drawing.Font("Montserrat", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.StartDateTimeText.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(230)))), ((int)(((byte)(230)))));
            this.StartDateTimeText.Location = new System.Drawing.Point(236, 149);
            this.StartDateTimeText.Margin = new System.Windows.Forms.Padding(3);
            this.StartDateTimeText.Name = "StartDateTimeText";
            this.StartDateTimeText.Size = new System.Drawing.Size(65, 27);
            this.StartDateTimeText.TabIndex = 17;
            this.StartDateTimeText.Text = "текст";
            // 
            // ShowQuestionsButton
            // 
            this.ShowQuestionsButton.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ShowQuestionsButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.ShowQuestionsButton.FlatAppearance.BorderSize = 0;
            this.ShowQuestionsButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ShowQuestionsButton.Font = new System.Drawing.Font("Montserrat", 12F);
            this.ShowQuestionsButton.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(230)))), ((int)(((byte)(230)))));
            this.ShowQuestionsButton.Location = new System.Drawing.Point(13, 251);
            this.ShowQuestionsButton.Name = "ShowQuestionsButton";
            this.ShowQuestionsButton.Size = new System.Drawing.Size(315, 38);
            this.ShowQuestionsButton.TabIndex = 18;
            this.ShowQuestionsButton.Text = "Просмотреть вопросы";
            this.ShowQuestionsButton.UseVisualStyleBackColor = false;
            this.ShowQuestionsButton.Click += new System.EventHandler(this.ShowQuestionsButton_Click);
            // 
            // TestInfoForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.ClientSize = new System.Drawing.Size(343, 297);
            this.Controls.Add(this.ShowQuestionsButton);
            this.Controls.Add(this.StartDateTimeText);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.TeacherAccountLink);
            this.Controls.Add(this.DurationText);
            this.Controls.Add(this.QuestionsCountText);
            this.Controls.Add(this.EndDateTimeText);
            this.Controls.Add(this.CreateDateTimeText);
            this.Controls.Add(this.TestNameText);
            this.Controls.Add(this.DurationLabel);
            this.Controls.Add(this.EndDateTimeLabel);
            this.Controls.Add(this.CreateDateTimeLabel);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.TeacherLabel);
            this.Controls.Add(this.TestNameLabel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "TestInfoForm";
            this.Padding = new System.Windows.Forms.Padding(5);
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Про тест";
            this.Load += new System.EventHandler(this.TestInfoForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private CustomizableLabel TestNameLabel;
        private CustomizableLabel TeacherLabel;
        private CustomizableLabel label3;
        private CustomizableLabel CreateDateTimeLabel;
        private CustomizableLabel EndDateTimeLabel;
        private CustomizableLabel DurationLabel;
        private CustomizableLabel TestNameText;
        private CustomizableLabel CreateDateTimeText;
        private CustomizableLabel EndDateTimeText;
        private CustomizableLabel QuestionsCountText;
        private CustomizableLabel DurationText;
        private System.Windows.Forms.LinkLabel TeacherAccountLink;
        private CustomizableLabel label9;
        private CustomizableLabel StartDateTimeText;
        private System.Windows.Forms.Button ShowQuestionsButton;
    }
}