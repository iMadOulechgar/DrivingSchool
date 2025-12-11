namespace _DVLD_.Detained
{
    partial class FrmDetainedLicense
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
            this.detainedLicenseControle1 = new _DVLD_.Controls.DetainedLicenseControle();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // detainedLicenseControle1
            // 
            this.detainedLicenseControle1.Location = new System.Drawing.Point(3, 21);
            this.detainedLicenseControle1.Name = "detainedLicenseControle1";
            this.detainedLicenseControle1.Size = new System.Drawing.Size(901, 600);
            this.detainedLicenseControle1.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Red;
            this.label1.Location = new System.Drawing.Point(348, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(195, 25);
            this.label1.TabIndex = 10;
            this.label1.Text = "Detained License";
            // 
            // FrmDetainedLicense
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(916, 620);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.detainedLicenseControle1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "FrmDetainedLicense";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FrmDetainedLicense";
            this.Load += new System.EventHandler(this.FrmDetainedLicense_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Controls.DetainedLicenseControle detainedLicenseControle1;
        private System.Windows.Forms.Label label1;
    }
}