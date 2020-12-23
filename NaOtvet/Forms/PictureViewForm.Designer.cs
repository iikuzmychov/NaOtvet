namespace NaOtvet
{
    partial class PictureViewForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PictureViewForm));
            this.PictureView = new System.Windows.Forms.PictureBox();
            this.DescriptionText = new System.Windows.Forms.Label();
            this.DescriptionPanel = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.PictureView)).BeginInit();
            this.DescriptionPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // PictureView
            // 
            this.PictureView.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.PictureView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PictureView.Image = global::NaOtvet.Properties.Resources.loadingImage;
            this.PictureView.InitialImage = null;
            this.PictureView.Location = new System.Drawing.Point(5, 5);
            this.PictureView.Name = "PictureView";
            this.PictureView.Size = new System.Drawing.Size(502, 473);
            this.PictureView.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.PictureView.TabIndex = 0;
            this.PictureView.TabStop = false;
            // 
            // DescriptionText
            // 
            this.DescriptionText.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.DescriptionText.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DescriptionText.Font = new System.Drawing.Font("Montserrat", 12F);
            this.DescriptionText.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(230)))), ((int)(((byte)(230)))));
            this.DescriptionText.Location = new System.Drawing.Point(0, 0);
            this.DescriptionText.Margin = new System.Windows.Forms.Padding(3);
            this.DescriptionText.Name = "DescriptionText";
            this.DescriptionText.Size = new System.Drawing.Size(502, 48);
            this.DescriptionText.TabIndex = 1;
            this.DescriptionText.Text = "Описание";
            this.DescriptionText.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // DescriptionPanel
            // 
            this.DescriptionPanel.Controls.Add(this.DescriptionText);
            this.DescriptionPanel.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.DescriptionPanel.Location = new System.Drawing.Point(5, 430);
            this.DescriptionPanel.Name = "DescriptionPanel";
            this.DescriptionPanel.Size = new System.Drawing.Size(502, 48);
            this.DescriptionPanel.TabIndex = 2;
            // 
            // PictureViewForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.ClientSize = new System.Drawing.Size(512, 483);
            this.Controls.Add(this.DescriptionPanel);
            this.Controls.Add(this.PictureView);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(400, 400);
            this.Name = "PictureViewForm";
            this.Padding = new System.Windows.Forms.Padding(5);
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Просмотр изображения";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.PictureViewForm_FormClosed);
            this.Load += new System.EventHandler(this.PictureViewForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.PictureView)).EndInit();
            this.DescriptionPanel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox PictureView;
        private System.Windows.Forms.Label DescriptionText;
        private System.Windows.Forms.Panel DescriptionPanel;
    }
}