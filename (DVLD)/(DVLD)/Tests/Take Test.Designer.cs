namespace _DVLD_.TestForms
{
    partial class Take_Test
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
            this.RBpass = new System.Windows.Forms.RadioButton();
            this.RBFail = new System.Windows.Forms.RadioButton();
            this.label2 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.BTNsave = new System.Windows.Forms.Button();
            this.clTakeTest2 = new _DVLD_.AllAboutTest.ClTakeTest();
            this.BTNcancel = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(51, 503);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(63, 16);
            this.label1.TabIndex = 1;
            this.label1.Text = "Result : ";
            // 
            // RBpass
            // 
            this.RBpass.AutoSize = true;
            this.RBpass.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RBpass.Location = new System.Drawing.Point(137, 501);
            this.RBpass.Name = "RBpass";
            this.RBpass.Size = new System.Drawing.Size(56, 20);
            this.RBpass.TabIndex = 2;
            this.RBpass.TabStop = true;
            this.RBpass.Text = "Pass";
            this.RBpass.UseVisualStyleBackColor = true;
            // 
            // RBFail
            // 
            this.RBFail.AutoSize = true;
            this.RBFail.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RBFail.Location = new System.Drawing.Point(225, 501);
            this.RBFail.Name = "RBFail";
            this.RBFail.Size = new System.Drawing.Size(47, 20);
            this.RBFail.TabIndex = 2;
            this.RBFail.TabStop = true;
            this.RBFail.Text = "Fail";
            this.RBFail.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(51, 539);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(60, 16);
            this.label2.TabIndex = 1;
            this.label2.Text = "Notes : ";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(137, 539);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(336, 62);
            this.textBox1.TabIndex = 3;
            // 
            // BTNsave
            // 
            this.BTNsave.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.BTNsave.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BTNsave.Image = global::_DVLD_.Properties.Resources.icons8_save_20;
            this.BTNsave.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BTNsave.Location = new System.Drawing.Point(369, 636);
            this.BTNsave.Name = "BTNsave";
            this.BTNsave.Size = new System.Drawing.Size(104, 37);
            this.BTNsave.TabIndex = 5;
            this.BTNsave.Text = "Save";
            this.BTNsave.UseVisualStyleBackColor = false;
            this.BTNsave.Click += new System.EventHandler(this.BTNsave_Click);
            // 
            // clTakeTest2
            // 
            this.clTakeTest2.Location = new System.Drawing.Point(4, 5);
            this.clTakeTest2.Name = "clTakeTest2";
            this.clTakeTest2.Size = new System.Drawing.Size(483, 480);
            this.clTakeTest2.TabIndex = 6;
            // 
            // BTNcancel
            // 
            this.BTNcancel.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.BTNcancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BTNcancel.Image = global::_DVLD_.Properties.Resources.icons8_cancel_20;
            this.BTNcancel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BTNcancel.Location = new System.Drawing.Point(256, 636);
            this.BTNcancel.Name = "BTNcancel";
            this.BTNcancel.Size = new System.Drawing.Size(104, 37);
            this.BTNcancel.TabIndex = 4;
            this.BTNcancel.Text = "Cancel";
            this.BTNcancel.UseVisualStyleBackColor = false;
            this.BTNcancel.Click += new System.EventHandler(this.BTNcancel_Click);
            // 
            // Take_Test
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(492, 685);
            this.Controls.Add(this.clTakeTest2);
            this.Controls.Add(this.BTNcancel);
            this.Controls.Add(this.BTNsave);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.RBFail);
            this.Controls.Add(this.RBpass);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "Take_Test";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Take_Test";
            this.Load += new System.EventHandler(this.Take_Test_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.RadioButton RBpass;
        private System.Windows.Forms.RadioButton RBFail;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button BTNsave;
        private AllAboutTest.ClTakeTest clTakeTest1;
        private AllAboutTest.ClTakeTest clTakeTest2;
        private System.Windows.Forms.Button BTNcancel;
    }
}