namespace _DVLD_.Applications
{
    partial class FrmNewDrivingLicenceApp
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
            this.BTNcancel = new System.Windows.Forms.Button();
            this.BTNsave = new System.Windows.Forms.Button();
            this.Tab = new System.Windows.Forms.TabControl();
            this.Tab1 = new System.Windows.Forms.TabPage();
            this.button1 = new System.Windows.Forms.Button();
            this.Tab2 = new System.Windows.Forms.TabPage();
            this.CBLicenceClasses = new System.Windows.Forms.ComboBox();
            this.LBLFees = new System.Windows.Forms.Label();
            this.LBLCreatedBY = new System.Windows.Forms.Label();
            this.LBLDate = new System.Windows.Forms.Label();
            this.LBLDrivingLicenAPP = new System.Windows.Forms.Label();
            this.LBLCreator = new System.Windows.Forms.Label();
            this.lbl = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.LBLUserID = new System.Windows.Forms.Label();
            this.pictureBox5 = new System.Windows.Forms.PictureBox();
            this.pictureBox4 = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.personeFilterAndAdd1 = new _DVLD_.Controls.PersoneFilterAndAdd();
            this.Tab.SuspendLayout();
            this.Tab1.SuspendLayout();
            this.Tab2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            this.SuspendLayout();
            // 
            // BTNcancel
            // 
            this.BTNcancel.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.BTNcancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BTNcancel.Image = global::_DVLD_.Properties.Resources.icons8_cancel_20;
            this.BTNcancel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BTNcancel.Location = new System.Drawing.Point(582, 497);
            this.BTNcancel.Name = "BTNcancel";
            this.BTNcancel.Size = new System.Drawing.Size(104, 37);
            this.BTNcancel.TabIndex = 7;
            this.BTNcancel.Text = "Cancel";
            this.BTNcancel.UseVisualStyleBackColor = false;
            // 
            // BTNsave
            // 
            this.BTNsave.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.BTNsave.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BTNsave.Image = global::_DVLD_.Properties.Resources.icons8_save_20;
            this.BTNsave.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BTNsave.Location = new System.Drawing.Point(704, 497);
            this.BTNsave.Name = "BTNsave";
            this.BTNsave.Size = new System.Drawing.Size(104, 37);
            this.BTNsave.TabIndex = 8;
            this.BTNsave.Text = "Save";
            this.BTNsave.UseVisualStyleBackColor = false;
            this.BTNsave.Click += new System.EventHandler(this.BTNsave_Click);
            // 
            // Tab
            // 
            this.Tab.Controls.Add(this.Tab1);
            this.Tab.Controls.Add(this.Tab2);
            this.Tab.Location = new System.Drawing.Point(12, 52);
            this.Tab.Name = "Tab";
            this.Tab.SelectedIndex = 0;
            this.Tab.Size = new System.Drawing.Size(797, 440);
            this.Tab.TabIndex = 6;
            // 
            // Tab1
            // 
            this.Tab1.Controls.Add(this.personeFilterAndAdd1);
            this.Tab1.Controls.Add(this.button1);
            this.Tab1.Location = new System.Drawing.Point(4, 22);
            this.Tab1.Name = "Tab1";
            this.Tab1.Padding = new System.Windows.Forms.Padding(3);
            this.Tab1.Size = new System.Drawing.Size(789, 414);
            this.Tab1.TabIndex = 0;
            this.Tab1.Text = "Persone Info";
            this.Tab1.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Image = global::_DVLD_.Properties.Resources.icons8_sign_out_24;
            this.button1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button1.Location = new System.Drawing.Point(670, 363);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(104, 37);
            this.button1.TabIndex = 3;
            this.button1.Text = "Next";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // Tab2
            // 
            this.Tab2.Controls.Add(this.CBLicenceClasses);
            this.Tab2.Controls.Add(this.LBLFees);
            this.Tab2.Controls.Add(this.LBLCreatedBY);
            this.Tab2.Controls.Add(this.LBLDate);
            this.Tab2.Controls.Add(this.LBLDrivingLicenAPP);
            this.Tab2.Controls.Add(this.LBLCreator);
            this.Tab2.Controls.Add(this.lbl);
            this.Tab2.Controls.Add(this.label9);
            this.Tab2.Controls.Add(this.label8);
            this.Tab2.Controls.Add(this.label6);
            this.Tab2.Controls.Add(this.LBLUserID);
            this.Tab2.Controls.Add(this.pictureBox5);
            this.Tab2.Controls.Add(this.pictureBox4);
            this.Tab2.Controls.Add(this.pictureBox2);
            this.Tab2.Controls.Add(this.pictureBox1);
            this.Tab2.Controls.Add(this.pictureBox3);
            this.Tab2.Controls.Add(this.label4);
            this.Tab2.Controls.Add(this.label3);
            this.Tab2.Controls.Add(this.label2);
            this.Tab2.Controls.Add(this.label5);
            this.Tab2.Location = new System.Drawing.Point(4, 22);
            this.Tab2.Name = "Tab2";
            this.Tab2.Padding = new System.Windows.Forms.Padding(3);
            this.Tab2.Size = new System.Drawing.Size(789, 414);
            this.Tab2.TabIndex = 1;
            this.Tab2.Text = "Application Info";
            this.Tab2.UseVisualStyleBackColor = true;
            // 
            // CBLicenceClasses
            // 
            this.CBLicenceClasses.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CBLicenceClasses.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CBLicenceClasses.FormattingEnabled = true;
            this.CBLicenceClasses.Location = new System.Drawing.Point(336, 192);
            this.CBLicenceClasses.Name = "CBLicenceClasses";
            this.CBLicenceClasses.Size = new System.Drawing.Size(255, 23);
            this.CBLicenceClasses.TabIndex = 11;
            // 
            // LBLFees
            // 
            this.LBLFees.AutoSize = true;
            this.LBLFees.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LBLFees.Location = new System.Drawing.Point(333, 245);
            this.LBLFees.Name = "LBLFees";
            this.LBLFees.Size = new System.Drawing.Size(23, 16);
            this.LBLFees.TabIndex = 10;
            this.LBLFees.Text = "15";
            // 
            // LBLCreatedBY
            // 
            this.LBLCreatedBY.AutoSize = true;
            this.LBLCreatedBY.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LBLCreatedBY.Location = new System.Drawing.Point(333, 293);
            this.LBLCreatedBY.Name = "LBLCreatedBY";
            this.LBLCreatedBY.Size = new System.Drawing.Size(49, 16);
            this.LBLCreatedBY.TabIndex = 10;
            this.LBLCreatedBY.Text = "[????]";
            // 
            // LBLDate
            // 
            this.LBLDate.AutoSize = true;
            this.LBLDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LBLDate.Location = new System.Drawing.Point(333, 149);
            this.LBLDate.Name = "LBLDate";
            this.LBLDate.Size = new System.Drawing.Size(49, 16);
            this.LBLDate.TabIndex = 10;
            this.LBLDate.Text = "[????]";
            // 
            // LBLDrivingLicenAPP
            // 
            this.LBLDrivingLicenAPP.AutoSize = true;
            this.LBLDrivingLicenAPP.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LBLDrivingLicenAPP.Location = new System.Drawing.Point(333, 101);
            this.LBLDrivingLicenAPP.Name = "LBLDrivingLicenAPP";
            this.LBLDrivingLicenAPP.Size = new System.Drawing.Size(49, 16);
            this.LBLDrivingLicenAPP.TabIndex = 10;
            this.LBLDrivingLicenAPP.Text = "[????]";
            // 
            // LBLCreator
            // 
            this.LBLCreator.AutoSize = true;
            this.LBLCreator.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LBLCreator.Location = new System.Drawing.Point(158, 293);
            this.LBLCreator.Name = "LBLCreator";
            this.LBLCreator.Size = new System.Drawing.Size(92, 16);
            this.LBLCreator.TabIndex = 10;
            this.LBLCreator.Text = "Created By :";
            this.LBLCreator.Click += new System.EventHandler(this.label8_Click);
            // 
            // lbl
            // 
            this.lbl.AutoSize = true;
            this.lbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl.Location = new System.Drawing.Point(122, 245);
            this.lbl.Name = "lbl";
            this.lbl.Size = new System.Drawing.Size(132, 16);
            this.lbl.TabIndex = 10;
            this.lbl.Text = "Application Fees :";
            this.lbl.Click += new System.EventHandler(this.label8_Click);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(138, 197);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(112, 16);
            this.label9.TabIndex = 10;
            this.label9.Text = "Licence Class :";
            this.label9.Click += new System.EventHandler(this.label8_Click);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(124, 149);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(126, 16);
            this.label8.TabIndex = 10;
            this.label8.Text = "ApplicationDate :";
            this.label8.Click += new System.EventHandler(this.label8_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(77, 101);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(177, 16);
            this.label6.TabIndex = 10;
            this.label6.Text = "Driving Licence App ID : ";
            // 
            // LBLUserID
            // 
            this.LBLUserID.AutoSize = true;
            this.LBLUserID.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LBLUserID.Location = new System.Drawing.Point(309, 116);
            this.LBLUserID.Name = "LBLUserID";
            this.LBLUserID.Size = new System.Drawing.Size(0, 20);
            this.LBLUserID.TabIndex = 7;
            // 
            // pictureBox5
            // 
            this.pictureBox5.Image = global::_DVLD_.Properties.Resources.icons8_user_30;
            this.pictureBox5.Location = new System.Drawing.Point(264, 285);
            this.pictureBox5.Name = "pictureBox5";
            this.pictureBox5.Size = new System.Drawing.Size(26, 24);
            this.pictureBox5.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox5.TabIndex = 6;
            this.pictureBox5.TabStop = false;
            // 
            // pictureBox4
            // 
            this.pictureBox4.Image = global::_DVLD_.Properties.Resources.icons8_fees_64;
            this.pictureBox4.Location = new System.Drawing.Point(263, 237);
            this.pictureBox4.Name = "pictureBox4";
            this.pictureBox4.Size = new System.Drawing.Size(26, 24);
            this.pictureBox4.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox4.TabIndex = 6;
            this.pictureBox4.TabStop = false;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = global::_DVLD_.Properties.Resources.icons8_user_id_24;
            this.pictureBox2.Location = new System.Drawing.Point(264, 94);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(26, 23);
            this.pictureBox2.TabIndex = 6;
            this.pictureBox2.TabStop = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::_DVLD_.Properties.Resources.icons8_date_50;
            this.pictureBox1.Location = new System.Drawing.Point(264, 142);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(26, 23);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 6;
            this.pictureBox1.TabStop = false;
            // 
            // pictureBox3
            // 
            this.pictureBox3.Image = global::_DVLD_.Properties.Resources.icons8_car_insurance_48;
            this.pictureBox3.Location = new System.Drawing.Point(264, 188);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(25, 25);
            this.pictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox3.TabIndex = 6;
            this.pictureBox3.TabStop = false;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(108, 280);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(0, 16);
            this.label4.TabIndex = 2;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(164, 225);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(0, 16);
            this.label3.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(158, 171);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(0, 16);
            this.label2.TabIndex = 4;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(126, -42);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(0, 16);
            this.label5.TabIndex = 5;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Red;
            this.label1.Location = new System.Drawing.Point(224, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(415, 25);
            this.label1.TabIndex = 5;
            this.label1.Text = "New Local Driving Licence Application";
            // 
            // personeFilterAndAdd1
            // 
            this.personeFilterAndAdd1.Location = new System.Drawing.Point(8, 6);
            this.personeFilterAndAdd1.Name = "personeFilterAndAdd1";
            this.personeFilterAndAdd1.Size = new System.Drawing.Size(776, 351);
            this.personeFilterAndAdd1.TabIndex = 4;
            // 
            // FrmNewDrivingLicenceApp
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(823, 546);
            this.Controls.Add(this.BTNcancel);
            this.Controls.Add(this.BTNsave);
            this.Controls.Add(this.Tab);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "FrmNewDrivingLicenceApp";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "NewFrmDrivingLicenceApp";
            this.Load += new System.EventHandler(this.NewFrmDrivingLicenceApp_Load);
            this.Tab.ResumeLayout(false);
            this.Tab1.ResumeLayout(false);
            this.Tab2.ResumeLayout(false);
            this.Tab2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button BTNcancel;
        private System.Windows.Forms.Button BTNsave;
        private System.Windows.Forms.TabControl Tab;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TabPage Tab1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TabPage Tab2;
        private System.Windows.Forms.Label LBLUserID;
        private System.Windows.Forms.PictureBox pictureBox4;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label5;
        private Controls.PersoneFilterAndAdd personeFilterAndAdd1;
        private System.Windows.Forms.Label LBLDrivingLicenAPP;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label LBLDate;
        private System.Windows.Forms.Label LBLCreator;
        private System.Windows.Forms.Label lbl;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.PictureBox pictureBox5;
        private System.Windows.Forms.ComboBox CBLicenceClasses;
        private System.Windows.Forms.Label LBLFees;
        private System.Windows.Forms.Label LBLCreatedBY;
    }
}