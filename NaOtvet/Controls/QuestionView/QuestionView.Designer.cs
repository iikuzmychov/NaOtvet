namespace NaOtvet
{
    partial class QuestionView
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

        #region Код, автоматически созданный конструктором компонентов

        /// <summary> 
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.MainPanel = new System.Windows.Forms.Panel();
            this.QuestionShortText = new System.Windows.Forms.Label();
            this.OptionsPanel = new System.Windows.Forms.Panel();
            this.ExampleOptionText = new System.Windows.Forms.Label();
            this.OptionsLabel = new System.Windows.Forms.Label();
            this.PointsLabel = new System.Windows.Forms.Label();
            this.QuestionText = new System.Windows.Forms.Label();
            this.QuestionLabel = new System.Windows.Forms.Label();
            this.QuestionCollapsedCheckBox = new System.Windows.Forms.CheckBox();
            this.ExampleImageLinkLabel = new System.Windows.Forms.LinkLabel();
            this.PicturesPanel = new System.Windows.Forms.Panel();
            this.MainPanel.SuspendLayout();
            this.OptionsPanel.SuspendLayout();
            this.PicturesPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // MainPanel
            // 
            this.MainPanel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.MainPanel.AutoSize = true;
            this.MainPanel.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.MainPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.MainPanel.Controls.Add(this.QuestionShortText);
            this.MainPanel.Controls.Add(this.OptionsPanel);
            this.MainPanel.Controls.Add(this.OptionsLabel);
            this.MainPanel.Controls.Add(this.PointsLabel);
            this.MainPanel.Controls.Add(this.QuestionText);
            this.MainPanel.Controls.Add(this.QuestionLabel);
            this.MainPanel.Location = new System.Drawing.Point(5, 5);
            this.MainPanel.Margin = new System.Windows.Forms.Padding(5);
            this.MainPanel.MinimumSize = new System.Drawing.Size(400, 0);
            this.MainPanel.Name = "MainPanel";
            this.MainPanel.Padding = new System.Windows.Forms.Padding(3);
            this.MainPanel.Size = new System.Drawing.Size(592, 124);
            this.MainPanel.TabIndex = 0;
            // 
            // QuestionShortText
            // 
            this.QuestionShortText.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.QuestionShortText.AutoEllipsis = true;
            this.QuestionShortText.Font = new System.Drawing.Font("Montserrat", 12F);
            this.QuestionShortText.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(150)))), ((int)(((byte)(150)))), ((int)(((byte)(150)))));
            this.QuestionShortText.Location = new System.Drawing.Point(97, 3);
            this.QuestionShortText.Margin = new System.Windows.Forms.Padding(0);
            this.QuestionShortText.Name = "QuestionShortText";
            this.QuestionShortText.Size = new System.Drawing.Size(334, 25);
            this.QuestionShortText.TabIndex = 7;
            this.QuestionShortText.Text = "Начало текста вопроса бла бла бла";
            this.QuestionShortText.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.QuestionShortText.Visible = false;
            // 
            // OptionsPanel
            // 
            this.OptionsPanel.AutoSize = true;
            this.OptionsPanel.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.OptionsPanel.Controls.Add(this.ExampleOptionText);
            this.OptionsPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.OptionsPanel.Location = new System.Drawing.Point(3, 80);
            this.OptionsPanel.Margin = new System.Windows.Forms.Padding(0);
            this.OptionsPanel.Name = "OptionsPanel";
            this.OptionsPanel.Padding = new System.Windows.Forms.Padding(3);
            this.OptionsPanel.Size = new System.Drawing.Size(586, 41);
            this.OptionsPanel.TabIndex = 3;
            this.OptionsPanel.SizeChanged += new System.EventHandler(this.OptionsPanel_SizeChanged);
            // 
            // ExampleOptionText
            // 
            this.ExampleOptionText.Dock = System.Windows.Forms.DockStyle.Top;
            this.ExampleOptionText.Font = new System.Drawing.Font("Montserrat", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.ExampleOptionText.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(230)))), ((int)(((byte)(230)))));
            this.ExampleOptionText.Location = new System.Drawing.Point(3, 3);
            this.ExampleOptionText.Margin = new System.Windows.Forms.Padding(3);
            this.ExampleOptionText.Name = "ExampleOptionText";
            this.ExampleOptionText.Size = new System.Drawing.Size(580, 35);
            this.ExampleOptionText.TabIndex = 7;
            this.ExampleOptionText.Text = "Текст первого варианта ответа бла бла бла бла";
            this.ExampleOptionText.Visible = false;
            // 
            // OptionsLabel
            // 
            this.OptionsLabel.Dock = System.Windows.Forms.DockStyle.Top;
            this.OptionsLabel.Font = new System.Drawing.Font("Montserrat SemiBold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.OptionsLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(254)))), ((int)(((byte)(176)))), ((int)(((byte)(31)))));
            this.OptionsLabel.Location = new System.Drawing.Point(3, 55);
            this.OptionsLabel.Margin = new System.Windows.Forms.Padding(3);
            this.OptionsLabel.Name = "OptionsLabel";
            this.OptionsLabel.Size = new System.Drawing.Size(586, 25);
            this.OptionsLabel.TabIndex = 6;
            this.OptionsLabel.Text = "Варианты ответов:";
            // 
            // PointsLabel
            // 
            this.PointsLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.PointsLabel.Font = new System.Drawing.Font("Montserrat SemiBold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.PointsLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(197)))), ((int)(((byte)(251)))));
            this.PointsLabel.Location = new System.Drawing.Point(431, 4);
            this.PointsLabel.Margin = new System.Windows.Forms.Padding(0);
            this.PointsLabel.Name = "PointsLabel";
            this.PointsLabel.Size = new System.Drawing.Size(158, 25);
            this.PointsLabel.TabIndex = 5;
            this.PointsLabel.Text = "X баллов";
            this.PointsLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // QuestionText
            // 
            this.QuestionText.Dock = System.Windows.Forms.DockStyle.Top;
            this.QuestionText.Font = new System.Drawing.Font("Montserrat", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.QuestionText.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(230)))), ((int)(((byte)(230)))));
            this.QuestionText.Location = new System.Drawing.Point(3, 28);
            this.QuestionText.Margin = new System.Windows.Forms.Padding(3);
            this.QuestionText.Name = "QuestionText";
            this.QuestionText.Size = new System.Drawing.Size(586, 27);
            this.QuestionText.TabIndex = 4;
            this.QuestionText.Text = "Текст вопроса бла бла бла бла";
            this.QuestionText.Paint += new System.Windows.Forms.PaintEventHandler(this.QuestionText_Paint);
            this.QuestionText.DoubleClick += new System.EventHandler(this.QuestionText_DoubleClick);
            // 
            // QuestionLabel
            // 
            this.QuestionLabel.Dock = System.Windows.Forms.DockStyle.Top;
            this.QuestionLabel.Font = new System.Drawing.Font("Montserrat SemiBold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.QuestionLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(252)))), ((int)(((byte)(204)))), ((int)(((byte)(41)))));
            this.QuestionLabel.Location = new System.Drawing.Point(3, 3);
            this.QuestionLabel.Margin = new System.Windows.Forms.Padding(3);
            this.QuestionLabel.Name = "QuestionLabel";
            this.QuestionLabel.Size = new System.Drawing.Size(586, 25);
            this.QuestionLabel.TabIndex = 4;
            this.QuestionLabel.Text = "Вопрос:";
            // 
            // QuestionCollapsedCheckBox
            // 
            this.QuestionCollapsedCheckBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.QuestionCollapsedCheckBox.AutoSize = true;
            this.QuestionCollapsedCheckBox.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.QuestionCollapsedCheckBox.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.QuestionCollapsedCheckBox.Font = new System.Drawing.Font("Montserrat", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.QuestionCollapsedCheckBox.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(230)))), ((int)(((byte)(230)))));
            this.QuestionCollapsedCheckBox.Location = new System.Drawing.Point(617, 7);
            this.QuestionCollapsedCheckBox.Margin = new System.Windows.Forms.Padding(15, 4, 3, 3);
            this.QuestionCollapsedCheckBox.Name = "QuestionCollapsedCheckBox";
            this.QuestionCollapsedCheckBox.Size = new System.Drawing.Size(191, 30);
            this.QuestionCollapsedCheckBox.TabIndex = 1;
            this.QuestionCollapsedCheckBox.Text = "Вопрос свёрнут";
            this.QuestionCollapsedCheckBox.UseVisualStyleBackColor = true;
            this.QuestionCollapsedCheckBox.CheckedChanged += new System.EventHandler(this.QuestionCollapsedCheckBox_CheckedChanged);
            // 
            // ExampleImageLinkLabel
            // 
            this.ExampleImageLinkLabel.ActiveLinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(36)))), ((int)(((byte)(36)))));
            this.ExampleImageLinkLabel.AutoEllipsis = true;
            this.ExampleImageLinkLabel.DisabledLinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(80)))), ((int)(((byte)(80)))));
            this.ExampleImageLinkLabel.Dock = System.Windows.Forms.DockStyle.Top;
            this.ExampleImageLinkLabel.Font = new System.Drawing.Font("Montserrat", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.ExampleImageLinkLabel.LinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(77)))), ((int)(((byte)(62)))), ((int)(((byte)(255)))));
            this.ExampleImageLinkLabel.Location = new System.Drawing.Point(0, 0);
            this.ExampleImageLinkLabel.Margin = new System.Windows.Forms.Padding(3);
            this.ExampleImageLinkLabel.Name = "ExampleImageLinkLabel";
            this.ExampleImageLinkLabel.Size = new System.Drawing.Size(191, 26);
            this.ExampleImageLinkLabel.TabIndex = 2;
            this.ExampleImageLinkLabel.TabStop = true;
            this.ExampleImageLinkLabel.Text = "Рис. X";
            this.ExampleImageLinkLabel.Visible = false;
            this.ExampleImageLinkLabel.VisitedLinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(154)))), ((int)(((byte)(31)))), ((int)(((byte)(254)))));
            // 
            // PicturesPanel
            // 
            this.PicturesPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.PicturesPanel.AutoSize = true;
            this.PicturesPanel.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.PicturesPanel.Controls.Add(this.ExampleImageLinkLabel);
            this.PicturesPanel.Location = new System.Drawing.Point(617, 45);
            this.PicturesPanel.Margin = new System.Windows.Forms.Padding(15, 5, 5, 5);
            this.PicturesPanel.MinimumSize = new System.Drawing.Size(191, 2);
            this.PicturesPanel.Name = "PicturesPanel";
            this.PicturesPanel.Size = new System.Drawing.Size(191, 26);
            this.PicturesPanel.TabIndex = 3;
            // 
            // QuestionView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.Controls.Add(this.PicturesPanel);
            this.Controls.Add(this.QuestionCollapsedCheckBox);
            this.Controls.Add(this.MainPanel);
            this.MinimumSize = new System.Drawing.Size(540, 0);
            this.Name = "QuestionView";
            this.Padding = new System.Windows.Forms.Padding(3);
            this.Size = new System.Drawing.Size(816, 137);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.QuestionAnswerControl_Paint);
            this.MainPanel.ResumeLayout(false);
            this.MainPanel.PerformLayout();
            this.OptionsPanel.ResumeLayout(false);
            this.PicturesPanel.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel MainPanel;
        private System.Windows.Forms.CheckBox QuestionCollapsedCheckBox;
        private System.Windows.Forms.LinkLabel ExampleImageLinkLabel;
        private System.Windows.Forms.Label PointsLabel;
        private System.Windows.Forms.Label QuestionText;
        private System.Windows.Forms.Label QuestionLabel;
        private System.Windows.Forms.Label OptionsLabel;
        private System.Windows.Forms.Label ExampleOptionText;
        private System.Windows.Forms.Panel OptionsPanel;
        private System.Windows.Forms.Label QuestionShortText;
        private System.Windows.Forms.Panel PicturesPanel;
    }
}
