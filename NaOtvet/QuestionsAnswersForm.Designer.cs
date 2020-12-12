namespace NaOtvet
{
    partial class QuestionsAnswersForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(QuestionsAnswersForm));
            this.questionAnswerControl1 = new NaOtvet.QuestionAnswerControl();
            this.SuspendLayout();
            // 
            // questionAnswerControl1
            // 
            this.questionAnswerControl1.Answers = ((System.Collections.ObjectModel.ObservableCollection<string>)(resources.GetObject("questionAnswerControl1.Answers")));
            this.questionAnswerControl1.AutoSize = true;
            this.questionAnswerControl1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.questionAnswerControl1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.questionAnswerControl1.IsMinimized = false;
            this.questionAnswerControl1.Location = new System.Drawing.Point(154, 109);
            this.questionAnswerControl1.MinimumSize = new System.Drawing.Size(540, 0);
            this.questionAnswerControl1.Name = "questionAnswerControl1";
            this.questionAnswerControl1.Padding = new System.Windows.Forms.Padding(3);
            this.questionAnswerControl1.Pictures = ((System.Collections.ObjectModel.ObservableCollection<NaOtvet.UrlDescription>)(resources.GetObject("questionAnswerControl1.Pictures")));
            this.questionAnswerControl1.Points = 1F;
            this.questionAnswerControl1.Question = "";
            this.questionAnswerControl1.Size = new System.Drawing.Size(594, 96);
            this.questionAnswerControl1.TabIndex = 0;
            // 
            // QuestionsAnswersForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.questionAnswerControl1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "QuestionsAnswersForm";
            this.Text = "Ответы на вопросы";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private QuestionAnswerControl questionAnswerControl1;
    }
}