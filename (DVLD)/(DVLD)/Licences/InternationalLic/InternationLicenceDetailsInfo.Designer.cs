namespace _DVLD_.LicencesLocal_And_International
{
    partial class InternationLicenceDetailsInfo
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
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.BTNcancel = new System.Windows.Forms.Button();
            this.ctrlInternationDetails1 = new _DVLD_.Licences.InternationalLic.Controle.ctrlInternationDetails();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Red;
            this.label1.Location = new System.Drawing.Point(273, 99);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(359, 25);
            this.label1.TabIndex = 6;
            this.label1.Text = "Driving International Lisence Info";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::_DVLD_.Properties.Resources.id_search__2_1;
            this.pictureBox1.Location = new System.Drawing.Point(416, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(100, 84);
            this.pictureBox1.TabIndex = 7;
            this.pictureBox1.TabStop = false;
            // 
            // BTNcancel
            // 
            this.BTNcancel.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.BTNcancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BTNcancel.Image = global::_DVLD_.Properties.Resources.icons8_cancel_20;
            this.BTNcancel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BTNcancel.Location = new System.Drawing.Point(771, 413);
            this.BTNcancel.Name = "BTNcancel";
            this.BTNcancel.Size = new System.Drawing.Size(104, 37);
            this.BTNcancel.TabIndex = 9;
            this.BTNcancel.Text = "Cancel";
            this.BTNcancel.UseVisualStyleBackColor = false;
            this.BTNcancel.Click += new System.EventHandler(this.BTNcancel_Click);
            // 
            // ctrlInternationDetails1
            // 
            this.ctrlInternationDetails1.Location = new System.Drawing.Point(12, 137);
            this.ctrlInternationDetails1.Name = "ctrlInternationDetails1";
            this.ctrlInternationDetails1.Size = new System.Drawing.Size(867, 270);
            this.ctrlInternationDetails1.TabIndex = 10;
            // 
            // InternationLicenceDetailsInfo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(887, 455);
            this.Controls.Add(this.ctrlInternationDetails1);
            this.Controls.Add(this.BTNcancel);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "InternationLicenceDetailsInfo";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "InternationLicenceDetailsInfo";
            this.Load += new System.EventHandler(this.InternationLicenceDetailsInfo_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button BTNcancel;
        private Licences.InternationalLic.Controle.ctrlInternationDetails ctrlInternationDetails1;
    }
}