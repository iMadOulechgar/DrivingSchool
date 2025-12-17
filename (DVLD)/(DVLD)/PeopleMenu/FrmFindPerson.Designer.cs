namespace _DVLD_.PeopleMenu
{
    partial class FrmFindPerson
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
            this.lblTitle = new System.Windows.Forms.Label();
            this.personeFilterAndAdd1 = new _DVLD_.Controls.PersoneFilterAndAdd();
            this.BTNcancel = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.ForeColor = System.Drawing.Color.Red;
            this.lblTitle.Location = new System.Drawing.Point(322, 9);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(152, 25);
            this.lblTitle.TabIndex = 1;
            this.lblTitle.Text = "Find Persone";
            // 
            // personeFilterAndAdd1
            // 
            this.personeFilterAndAdd1.FilterEnabled = true;
            this.personeFilterAndAdd1.Location = new System.Drawing.Point(6, 47);
            this.personeFilterAndAdd1.Name = "personeFilterAndAdd1";
            this.personeFilterAndAdd1.ShowAddPerson = true;
            this.personeFilterAndAdd1.Size = new System.Drawing.Size(776, 351);
            this.personeFilterAndAdd1.TabIndex = 2;
            // 
            // BTNcancel
            // 
            this.BTNcancel.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.BTNcancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BTNcancel.Image = global::_DVLD_.Properties.Resources.icons8_cancel_20;
            this.BTNcancel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BTNcancel.Location = new System.Drawing.Point(658, 393);
            this.BTNcancel.Name = "BTNcancel";
            this.BTNcancel.Size = new System.Drawing.Size(104, 37);
            this.BTNcancel.TabIndex = 114;
            this.BTNcancel.Text = "Cancel";
            this.BTNcancel.UseVisualStyleBackColor = false;
            this.BTNcancel.Click += new System.EventHandler(this.BTNcancel_Click);
            // 
            // FrmFindPerson
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(794, 444);
            this.Controls.Add(this.BTNcancel);
            this.Controls.Add(this.personeFilterAndAdd1);
            this.Controls.Add(this.lblTitle);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "FrmFindPerson";
            this.Text = "FrmFindPerson";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblTitle;
        private Controls.PersoneFilterAndAdd personeFilterAndAdd1;
        private System.Windows.Forms.Button BTNcancel;
    }
}