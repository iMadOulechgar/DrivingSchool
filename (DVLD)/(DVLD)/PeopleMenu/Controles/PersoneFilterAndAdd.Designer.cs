namespace _DVLD_.Controls
{
    partial class PersoneFilterAndAdd
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
            this.components = new System.ComponentModel.Container();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.CBSearch = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnFind = new System.Windows.Forms.Button();
            this.TBSearch = new System.Windows.Forms.TextBox();
            this.BtnAddNewPer = new System.Windows.Forms.Button();
            this.personInfo1 = new _DVLD_.Controls.PersonInfo();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.CBSearch);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.btnFind);
            this.groupBox1.Controls.Add(this.TBSearch);
            this.groupBox1.Controls.Add(this.BtnAddNewPer);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(11, 5);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(756, 75);
            this.groupBox1.TabIndex = 6;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Filter";
            // 
            // CBSearch
            // 
            this.CBSearch.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CBSearch.FormattingEnabled = true;
            this.CBSearch.Items.AddRange(new object[] {
            "National No.",
            "Person ID"});
            this.CBSearch.Location = new System.Drawing.Point(101, 33);
            this.CBSearch.Name = "CBSearch";
            this.CBSearch.Size = new System.Drawing.Size(171, 24);
            this.CBSearch.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(6, 33);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(86, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "SearchBy : ";
            // 
            // btnFind
            // 
            this.btnFind.Image = global::_DVLD_.Properties.Resources.icons8_find_user_male_48;
            this.btnFind.Location = new System.Drawing.Point(520, 14);
            this.btnFind.Name = "btnFind";
            this.btnFind.Size = new System.Drawing.Size(57, 54);
            this.btnFind.TabIndex = 4;
            this.btnFind.UseVisualStyleBackColor = true;
            this.btnFind.Click += new System.EventHandler(this.button2_Click);
            // 
            // TBSearch
            // 
            this.TBSearch.Location = new System.Drawing.Point(301, 34);
            this.TBSearch.Name = "TBSearch";
            this.TBSearch.Size = new System.Drawing.Size(167, 22);
            this.TBSearch.TabIndex = 2;
            this.TBSearch.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox1_KeyPress);
            // 
            // BtnAddNewPer
            // 
            this.BtnAddNewPer.Image = global::_DVLD_.Properties.Resources.icons8_add_user_male_48;
            this.BtnAddNewPer.Location = new System.Drawing.Point(605, 14);
            this.BtnAddNewPer.Name = "BtnAddNewPer";
            this.BtnAddNewPer.Size = new System.Drawing.Size(57, 54);
            this.BtnAddNewPer.TabIndex = 3;
            this.BtnAddNewPer.UseVisualStyleBackColor = true;
            this.BtnAddNewPer.Click += new System.EventHandler(this.button1_Click);
            // 
            // personInfo1
            // 
            this.personInfo1.Location = new System.Drawing.Point(11, 86);
            this.personInfo1.Name = "personInfo1";
            this.personInfo1.Size = new System.Drawing.Size(747, 256);
            this.personInfo1.TabIndex = 7;
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // PersoneFilterAndAdd
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.personInfo1);
            this.Controls.Add(this.groupBox1);
            this.Name = "PersoneFilterAndAdd";
            this.Size = new System.Drawing.Size(776, 351);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ComboBox CBSearch;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnFind;
        private System.Windows.Forms.TextBox TBSearch;
        private System.Windows.Forms.Button BtnAddNewPer;
        private PersonInfo personInfo1;
        private System.Windows.Forms.ErrorProvider errorProvider1;
    }
}
