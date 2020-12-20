namespace NaOtvet
{
    partial class QuestionsViewForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(QuestionsViewForm));
            this.SearchPanel = new System.Windows.Forms.Panel();
            this.ClearSearchQueryButton = new System.Windows.Forms.Button();
            this.OnlyNotCollapsedQuestionsCheckBox = new System.Windows.Forms.CheckBox();
            this.SearchQueryTextPanel = new System.Windows.Forms.Panel();
            this.SearchQueryText = new System.Windows.Forms.TextBox();
            this.ExampleAnswerText = new System.Windows.Forms.Label();
            this.QuestionsAnswersPanel = new System.Windows.Forms.Panel();
            this.NothingFindedLabel = new System.Windows.Forms.Label();
            this.SearchPanel.SuspendLayout();
            this.SearchQueryTextPanel.SuspendLayout();
            this.QuestionsAnswersPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // SearchPanel
            // 
            this.SearchPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.SearchPanel.Controls.Add(this.ClearSearchQueryButton);
            this.SearchPanel.Controls.Add(this.OnlyNotCollapsedQuestionsCheckBox);
            this.SearchPanel.Controls.Add(this.SearchQueryTextPanel);
            this.SearchPanel.Controls.Add(this.ExampleAnswerText);
            this.SearchPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.SearchPanel.Location = new System.Drawing.Point(0, 0);
            this.SearchPanel.Name = "SearchPanel";
            this.SearchPanel.Padding = new System.Windows.Forms.Padding(3);
            this.SearchPanel.Size = new System.Drawing.Size(820, 56);
            this.SearchPanel.TabIndex = 0;
            // 
            // ClearSearchQueryButton
            // 
            this.ClearSearchQueryButton.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ClearSearchQueryButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.ClearSearchQueryButton.FlatAppearance.BorderSize = 0;
            this.ClearSearchQueryButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ClearSearchQueryButton.Font = new System.Drawing.Font("Montserrat", 12F);
            this.ClearSearchQueryButton.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(230)))), ((int)(((byte)(230)))));
            this.ClearSearchQueryButton.Location = new System.Drawing.Point(535, 12);
            this.ClearSearchQueryButton.Name = "ClearSearchQueryButton";
            this.ClearSearchQueryButton.Size = new System.Drawing.Size(42, 38);
            this.ClearSearchQueryButton.TabIndex = 1;
            this.ClearSearchQueryButton.Text = "X";
            this.ClearSearchQueryButton.UseVisualStyleBackColor = false;
            this.ClearSearchQueryButton.Click += new System.EventHandler(this.ClearSearchQueryButton_Click);
            // 
            // OnlyNotCollapsedQuestionsCheckBox
            // 
            this.OnlyNotCollapsedQuestionsCheckBox.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.OnlyNotCollapsedQuestionsCheckBox.AutoSize = true;
            this.OnlyNotCollapsedQuestionsCheckBox.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.OnlyNotCollapsedQuestionsCheckBox.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.OnlyNotCollapsedQuestionsCheckBox.Font = new System.Drawing.Font("Montserrat", 12F);
            this.OnlyNotCollapsedQuestionsCheckBox.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(230)))), ((int)(((byte)(230)))));
            this.OnlyNotCollapsedQuestionsCheckBox.Location = new System.Drawing.Point(595, 16);
            this.OnlyNotCollapsedQuestionsCheckBox.Margin = new System.Windows.Forms.Padding(15, 4, 3, 3);
            this.OnlyNotCollapsedQuestionsCheckBox.Name = "OnlyNotCollapsedQuestionsCheckBox";
            this.OnlyNotCollapsedQuestionsCheckBox.Size = new System.Drawing.Size(219, 31);
            this.OnlyNotCollapsedQuestionsCheckBox.TabIndex = 2;
            this.OnlyNotCollapsedQuestionsCheckBox.Text = "скрыть свёрнутые";
            this.OnlyNotCollapsedQuestionsCheckBox.UseVisualStyleBackColor = true;
            this.OnlyNotCollapsedQuestionsCheckBox.CheckedChanged += new System.EventHandler(this.OnlyNotCollapsedQuestionsCheckBox_CheckedChanged);
            // 
            // SearchQueryTextPanel
            // 
            this.SearchQueryTextPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.SearchQueryTextPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.SearchQueryTextPanel.Controls.Add(this.SearchQueryText);
            this.SearchQueryTextPanel.Location = new System.Drawing.Point(98, 12);
            this.SearchQueryTextPanel.Name = "SearchQueryTextPanel";
            this.SearchQueryTextPanel.Size = new System.Drawing.Size(431, 38);
            this.SearchQueryTextPanel.TabIndex = 2;
            this.SearchQueryTextPanel.MouseClick += new System.Windows.Forms.MouseEventHandler(this.SearchQueryTextPanel_MouseClick);
            // 
            // SearchQueryText
            // 
            this.SearchQueryText.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.SearchQueryText.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.SearchQueryText.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.SearchQueryText.Font = new System.Drawing.Font("Montserrat", 12F);
            this.SearchQueryText.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(230)))), ((int)(((byte)(230)))));
            this.SearchQueryText.Location = new System.Drawing.Point(5, 6);
            this.SearchQueryText.Margin = new System.Windows.Forms.Padding(5);
            this.SearchQueryText.Name = "SearchQueryText";
            this.SearchQueryText.Size = new System.Drawing.Size(421, 25);
            this.SearchQueryText.TabIndex = 1;
            this.SearchQueryText.TextChanged += new System.EventHandler(this.SearchQueryText_TextChanged);
            // 
            // ExampleAnswerText
            // 
            this.ExampleAnswerText.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.ExampleAnswerText.AutoSize = true;
            this.ExampleAnswerText.Font = new System.Drawing.Font("Montserrat", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.ExampleAnswerText.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(230)))), ((int)(((byte)(230)))));
            this.ExampleAnswerText.Location = new System.Drawing.Point(9, 18);
            this.ExampleAnswerText.Margin = new System.Windows.Forms.Padding(3);
            this.ExampleAnswerText.Name = "ExampleAnswerText";
            this.ExampleAnswerText.Size = new System.Drawing.Size(83, 27);
            this.ExampleAnswerText.TabIndex = 8;
            this.ExampleAnswerText.Text = "Поиск:";
            this.ExampleAnswerText.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // QuestionsAnswersPanel
            // 
            this.QuestionsAnswersPanel.AutoScroll = true;
            this.QuestionsAnswersPanel.Controls.Add(this.NothingFindedLabel);
            this.QuestionsAnswersPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.QuestionsAnswersPanel.Location = new System.Drawing.Point(0, 56);
            this.QuestionsAnswersPanel.Margin = new System.Windows.Forms.Padding(0);
            this.QuestionsAnswersPanel.Name = "QuestionsAnswersPanel";
            this.QuestionsAnswersPanel.Size = new System.Drawing.Size(820, 427);
            this.QuestionsAnswersPanel.TabIndex = 1;
            // 
            // NothingFindedLabel
            // 
            this.NothingFindedLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.NothingFindedLabel.Font = new System.Drawing.Font("Montserrat", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.NothingFindedLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(150)))), ((int)(((byte)(150)))), ((int)(((byte)(150)))));
            this.NothingFindedLabel.Location = new System.Drawing.Point(0, 0);
            this.NothingFindedLabel.Margin = new System.Windows.Forms.Padding(3);
            this.NothingFindedLabel.Name = "NothingFindedLabel";
            this.NothingFindedLabel.Padding = new System.Windows.Forms.Padding(3);
            this.NothingFindedLabel.Size = new System.Drawing.Size(820, 427);
            this.NothingFindedLabel.TabIndex = 9;
            this.NothingFindedLabel.Text = "Ничего не найдено";
            this.NothingFindedLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.NothingFindedLabel.Visible = false;
            // 
            // QuestionsViewForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.ClientSize = new System.Drawing.Size(820, 483);
            this.Controls.Add(this.QuestionsAnswersPanel);
            this.Controls.Add(this.SearchPanel);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(700, 530);
            this.Name = "QuestionsViewForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Просмотр вопросов";
            this.Load += new System.EventHandler(this.QuestionsAnswersForm_Load);
            this.Shown += new System.EventHandler(this.QuestionsAnswersForm_Shown);
            this.SearchPanel.ResumeLayout(false);
            this.SearchPanel.PerformLayout();
            this.SearchQueryTextPanel.ResumeLayout(false);
            this.SearchQueryTextPanel.PerformLayout();
            this.QuestionsAnswersPanel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel SearchPanel;
        private System.Windows.Forms.TextBox SearchQueryText;
        private System.Windows.Forms.Label ExampleAnswerText;
        private System.Windows.Forms.Panel SearchQueryTextPanel;
        private System.Windows.Forms.CheckBox OnlyNotCollapsedQuestionsCheckBox;
        private System.Windows.Forms.Button ClearSearchQueryButton;
        private System.Windows.Forms.Panel QuestionsAnswersPanel;
        private System.Windows.Forms.Label NothingFindedLabel;
    }
}