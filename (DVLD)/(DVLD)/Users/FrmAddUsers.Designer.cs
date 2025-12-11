namespace _DVLD_.Users
{
    partial class FrmAddUsers
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
            this.components = new System.ComponentModel.Container();
            this.label1 = new System.Windows.Forms.Label();
            this.Tab = new System.Windows.Forms.TabControl();
            this.Tab1 = new System.Windows.Forms.TabPage();
            this.button1 = new System.Windows.Forms.Button();
            this.Tab2 = new System.Windows.Forms.TabPage();
            this.CBIsActive = new System.Windows.Forms.CheckBox();
            this.TBConfirmPassword = new System.Windows.Forms.TextBox();
            this.TBPassword = new System.Windows.Forms.TextBox();
            this.TBUsername = new System.Windows.Forms.TextBox();
            this.LBLUserID = new System.Windows.Forms.Label();
            this.pictureBox4 = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.BTNcancel = new System.Windows.Forms.Button();
            this.BTNsave = new System.Windows.Forms.Button();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.personeFilterAndAdd1 = new _DVLD_.Controls.PersoneFilterAndAdd();
            this.Tab.SuspendLayout();
            this.Tab1.SuspendLayout();
            this.Tab2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Red;
            this.label1.Location = new System.Drawing.Point(335, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(161, 25);
            this.label1.TabIndex = 1;
            this.label1.Text = "Add New User";
            // 
            // Tab
            // 
            this.Tab.Controls.Add(this.Tab1);
            this.Tab.Controls.Add(this.Tab2);
            this.Tab.Location = new System.Drawing.Point(12, 47);
            this.Tab.Name = "Tab";
            this.Tab.SelectedIndex = 0;
            this.Tab.Size = new System.Drawing.Size(799, 456);
            this.Tab.TabIndex = 2;
            // 
            // Tab1
            // 
            this.Tab1.Controls.Add(this.personeFilterAndAdd1);
            this.Tab1.Controls.Add(this.button1);
            this.Tab1.Location = new System.Drawing.Point(4, 22);
            this.Tab1.Name = "Tab1";
            this.Tab1.Padding = new System.Windows.Forms.Padding(3);
            this.Tab1.Size = new System.Drawing.Size(791, 430);
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
            this.button1.Location = new System.Drawing.Point(658, 375);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(104, 37);
            this.button1.TabIndex = 3;
            this.button1.Text = "Next";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // Tab2
            // 
            this.Tab2.Controls.Add(this.CBIsActive);
            this.Tab2.Controls.Add(this.TBConfirmPassword);
            this.Tab2.Controls.Add(this.TBPassword);
            this.Tab2.Controls.Add(this.TBUsername);
            this.Tab2.Controls.Add(this.LBLUserID);
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
            this.Tab2.Size = new System.Drawing.Size(791, 430);
            this.Tab2.TabIndex = 1;
            this.Tab2.Text = "Login Info";
            this.Tab2.UseVisualStyleBackColor = true;
            // 
            // CBIsActive
            // 
            this.CBIsActive.AutoSize = true;
            this.CBIsActive.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CBIsActive.Location = new System.Drawing.Point(263, 300);
            this.CBIsActive.Name = "CBIsActive";
            this.CBIsActive.Size = new System.Drawing.Size(73, 20);
            this.CBIsActive.TabIndex = 9;
            this.CBIsActive.Text = "IsActive";
            this.CBIsActive.UseVisualStyleBackColor = true;
            // 
            // TBConfirmPassword
            // 
            this.TBConfirmPassword.Location = new System.Drawing.Point(263, 248);
            this.TBConfirmPassword.MaxLength = 10;
            this.TBConfirmPassword.Name = "TBConfirmPassword";
            this.TBConfirmPassword.Size = new System.Drawing.Size(164, 20);
            this.TBConfirmPassword.TabIndex = 8;
            this.TBConfirmPassword.UseSystemPasswordChar = true;
            this.TBConfirmPassword.Validating += new System.ComponentModel.CancelEventHandler(this.TBConfirmPassword_Validating);
            // 
            // TBPassword
            // 
            this.TBPassword.Location = new System.Drawing.Point(263, 192);
            this.TBPassword.MaxLength = 10;
            this.TBPassword.Name = "TBPassword";
            this.TBPassword.Size = new System.Drawing.Size(164, 20);
            this.TBPassword.TabIndex = 8;
            this.TBPassword.UseSystemPasswordChar = true;
            // 
            // TBUsername
            // 
            this.TBUsername.Location = new System.Drawing.Point(263, 138);
            this.TBUsername.Name = "TBUsername";
            this.TBUsername.Size = new System.Drawing.Size(164, 20);
            this.TBUsername.TabIndex = 8;
            // 
            // LBLUserID
            // 
            this.LBLUserID.AutoSize = true;
            this.LBLUserID.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LBLUserID.Location = new System.Drawing.Point(259, 80);
            this.LBLUserID.Name = "LBLUserID";
            this.LBLUserID.Size = new System.Drawing.Size(44, 20);
            this.LBLUserID.TabIndex = 7;
            this.LBLUserID.Text = "[???]";
            // 
            // pictureBox4
            // 
            this.pictureBox4.Image = global::_DVLD_.Properties.Resources.icons8_password_24;
            this.pictureBox4.Location = new System.Drawing.Point(205, 244);
            this.pictureBox4.Name = "pictureBox4";
            this.pictureBox4.Size = new System.Drawing.Size(26, 24);
            this.pictureBox4.TabIndex = 6;
            this.pictureBox4.TabStop = false;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = global::_DVLD_.Properties.Resources.icons8_user_id_24;
            this.pictureBox2.Location = new System.Drawing.Point(207, 78);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(26, 23);
            this.pictureBox2.TabIndex = 6;
            this.pictureBox2.TabStop = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::_DVLD_.Properties.Resources.icons8_name_24;
            this.pictureBox1.Location = new System.Drawing.Point(207, 135);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(26, 23);
            this.pictureBox1.TabIndex = 6;
            this.pictureBox1.TabStop = false;
            // 
            // pictureBox3
            // 
            this.pictureBox3.Image = global::_DVLD_.Properties.Resources.icons8_password_24;
            this.pictureBox3.Location = new System.Drawing.Point(206, 187);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(25, 25);
            this.pictureBox3.TabIndex = 6;
            this.pictureBox3.TabStop = false;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(58, 244);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(143, 16);
            this.label4.TabIndex = 2;
            this.label4.Text = "Confirm Password : ";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(114, 189);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(87, 16);
            this.label3.TabIndex = 3;
            this.label3.Text = "Password : ";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(108, 135);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(93, 16);
            this.label2.TabIndex = 4;
            this.label2.Text = "UserName : ";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(126, 78);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(75, 16);
            this.label5.TabIndex = 5;
            this.label5.Text = "User ID :  ";
            // 
            // BTNcancel
            // 
            this.BTNcancel.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.BTNcancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BTNcancel.Image = global::_DVLD_.Properties.Resources.icons8_cancel_20;
            this.BTNcancel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BTNcancel.Location = new System.Drawing.Point(581, 509);
            this.BTNcancel.Name = "BTNcancel";
            this.BTNcancel.Size = new System.Drawing.Size(104, 37);
            this.BTNcancel.TabIndex = 3;
            this.BTNcancel.Text = "Cancel";
            this.BTNcancel.UseVisualStyleBackColor = false;
            this.BTNcancel.Click += new System.EventHandler(this.BTNcancel_Click);
            // 
            // BTNsave
            // 
            this.BTNsave.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.BTNsave.Enabled = false;
            this.BTNsave.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BTNsave.Image = global::_DVLD_.Properties.Resources.icons8_save_20;
            this.BTNsave.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BTNsave.Location = new System.Drawing.Point(703, 509);
            this.BTNsave.Name = "BTNsave";
            this.BTNsave.Size = new System.Drawing.Size(104, 37);
            this.BTNsave.TabIndex = 4;
            this.BTNsave.Text = "Save";
            this.BTNsave.UseVisualStyleBackColor = false;
            this.BTNsave.Click += new System.EventHandler(this.BTNsave_Click);
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // personeFilterAndAdd1
            // 
            this.personeFilterAndAdd1.Location = new System.Drawing.Point(9, 18);
            this.personeFilterAndAdd1.Name = "personeFilterAndAdd1";
            this.personeFilterAndAdd1.Size = new System.Drawing.Size(776, 351);
            this.personeFilterAndAdd1.TabIndex = 6;
            // 
            // FrmAddUsers
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(823, 558);
            this.Controls.Add(this.BTNcancel);
            this.Controls.Add(this.BTNsave);
            this.Controls.Add(this.Tab);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.Name = "FrmAddUsers";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FrmAddUsers";
            this.Load += new System.EventHandler(this.FrmAddUsers_Load);
            this.Tab.ResumeLayout(false);
            this.Tab1.ResumeLayout(false);
            this.Tab2.ResumeLayout(false);
            this.Tab2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TabControl Tab;
        private System.Windows.Forms.TabPage Tab1;
        private System.Windows.Forms.TabPage Tab2;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.PictureBox pictureBox4;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.CheckBox CBIsActive;
        private System.Windows.Forms.TextBox TBConfirmPassword;
        private System.Windows.Forms.TextBox TBPassword;
        private System.Windows.Forms.TextBox TBUsername;
        private System.Windows.Forms.Label LBLUserID;
        private System.Windows.Forms.Button BTNcancel;
        private System.Windows.Forms.Button BTNsave;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private Controls.PersoneFilterAndAdd personeFilterAndAdd1;
    }
}