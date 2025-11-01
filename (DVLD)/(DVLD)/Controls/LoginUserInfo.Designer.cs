namespace _DVLD_.Controls
{
    partial class LoginUserInfo
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.LBLUI = new System.Windows.Forms.Label();
            this.LBLUN = new System.Windows.Forms.Label();
            this.LBLIA = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(519, 36);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(74, 16);
            this.label3.TabIndex = 5;
            this.label3.Text = "IsActive : ";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(265, 37);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(93, 16);
            this.label2.TabIndex = 6;
            this.label2.Text = "UserName : ";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(56, 37);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(67, 16);
            this.label1.TabIndex = 7;
            this.label1.Text = "UserID : ";
            // 
            // LBLUI
            // 
            this.LBLUI.AutoSize = true;
            this.LBLUI.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LBLUI.Location = new System.Drawing.Point(148, 39);
            this.LBLUI.Name = "LBLUI";
            this.LBLUI.Size = new System.Drawing.Size(41, 16);
            this.LBLUI.TabIndex = 8;
            this.LBLUI.Text = "[???]";
            // 
            // LBLUN
            // 
            this.LBLUN.AutoSize = true;
            this.LBLUN.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LBLUN.Location = new System.Drawing.Point(403, 39);
            this.LBLUN.Name = "LBLUN";
            this.LBLUN.Size = new System.Drawing.Size(41, 16);
            this.LBLUN.TabIndex = 9;
            this.LBLUN.Text = "[???]";
            // 
            // LBLIA
            // 
            this.LBLIA.AutoSize = true;
            this.LBLIA.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LBLIA.Location = new System.Drawing.Point(610, 39);
            this.LBLIA.Name = "LBLIA";
            this.LBLIA.Size = new System.Drawing.Size(41, 16);
            this.LBLIA.TabIndex = 9;
            this.LBLIA.Text = "[???]";
            // 
            // LoginUserInfo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.Controls.Add(this.LBLIA);
            this.Controls.Add(this.LBLUN);
            this.Controls.Add(this.LBLUI);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label3);
            this.Name = "LoginUserInfo";
            this.Size = new System.Drawing.Size(718, 88);
            this.Load += new System.EventHandler(this.LoginUserInfo_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label LBLUI;
        private System.Windows.Forms.Label LBLUN;
        private System.Windows.Forms.Label LBLIA;
    }
}
