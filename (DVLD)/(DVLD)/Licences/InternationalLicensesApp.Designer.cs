namespace _DVLD_.LicencesLocal_And_International
{
    partial class InternationalLicensesApp
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
            this.label1 = new System.Windows.Forms.Label();
            this.newInternationalLicenseControle1 = new _DVLD_.Controls.NewInternationalLicenseControle();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Red;
            this.label1.Location = new System.Drawing.Point(301, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(356, 25);
            this.label1.TabIndex = 9;
            this.label1.Text = "International License Application";
            // 
            // newInternationalLicenseControle1
            // 
            this.newInternationalLicenseControle1.Location = new System.Drawing.Point(12, 53);
            this.newInternationalLicenseControle1.Name = "newInternationalLicenseControle1";
            this.newInternationalLicenseControle1.Size = new System.Drawing.Size(936, 636);
            this.newInternationalLicenseControle1.TabIndex = 10;
            // 
            // InternationalLicensesApp
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(948, 694);
            this.Controls.Add(this.newInternationalLicenseControle1);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "InternationalLicensesApp";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "InternationalLicenses";
            this.Load += new System.EventHandler(this.InternationalLicensesApp_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private Controls.NewInternationalLicenseControle newInternationalLicenseControle1;
    }
}