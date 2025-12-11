namespace _DVLD_.LicencesLocal_And_International
{
    partial class frmReplaceForLostOrDamage
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
            this.controleReplaceForDamageOrLost1 = new _DVLD_.Controls.ControleReplaceForDamageOrLost();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Red;
            this.label1.Location = new System.Drawing.Point(321, 1);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(332, 25);
            this.label1.TabIndex = 23;
            this.label1.Text = "Replacement For Lost License";
            // 
            // controleReplaceForDamageOrLost1
            // 
            this.controleReplaceForDamageOrLost1.Location = new System.Drawing.Point(12, 29);
            this.controleReplaceForDamageOrLost1.Name = "controleReplaceForDamageOrLost1";
            this.controleReplaceForDamageOrLost1.Size = new System.Drawing.Size(921, 583);
            this.controleReplaceForDamageOrLost1.TabIndex = 0;
            // 
            // frmReplaceForLostOrDamage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(942, 614);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.controleReplaceForDamageOrLost1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "frmReplaceForLostOrDamage";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmReplaceForLostOrDamage";
            this.Load += new System.EventHandler(this.frmReplaceForLostOrDamage_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Controls.ControleReplaceForDamageOrLost controleReplaceForDamageOrLost1;
        private System.Windows.Forms.Label label1;
    }
}