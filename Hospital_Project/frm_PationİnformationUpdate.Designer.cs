namespace Hospital_Project
{
    partial class frm_PationİnformationUpdate
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frm_PationİnformationUpdate));
            this.btnUpdate = new System.Windows.Forms.Button();
            this.cmbRegisterGender = new System.Windows.Forms.ComboBox();
            this.MskRegisterPhone = new System.Windows.Forms.MaskedTextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtSurname = new System.Windows.Forms.TextBox();
            this.txtName = new System.Windows.Forms.TextBox();
            this.MskRegisterTC = new System.Windows.Forms.MaskedTextBox();
            this.txtRegisterPsswrd = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnUpdate
            // 
            this.btnUpdate.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.btnUpdate.Location = new System.Drawing.Point(237, 358);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(191, 47);
            this.btnUpdate.TabIndex = 31;
            this.btnUpdate.Text = "Update";
            this.btnUpdate.UseVisualStyleBackColor = false;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // cmbRegisterGender
            // 
            this.cmbRegisterGender.FormattingEnabled = true;
            this.cmbRegisterGender.Items.AddRange(new object[] {
            "Erkek",
            "Kadın"});
            this.cmbRegisterGender.Location = new System.Drawing.Point(237, 313);
            this.cmbRegisterGender.Name = "cmbRegisterGender";
            this.cmbRegisterGender.Size = new System.Drawing.Size(191, 39);
            this.cmbRegisterGender.TabIndex = 5;
            // 
            // MskRegisterPhone
            // 
            this.MskRegisterPhone.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.MskRegisterPhone.Location = new System.Drawing.Point(237, 205);
            this.MskRegisterPhone.Mask = "(999) 000-0000";
            this.MskRegisterPhone.Name = "MskRegisterPhone";
            this.MskRegisterPhone.Size = new System.Drawing.Size(191, 38);
            this.MskRegisterPhone.TabIndex = 3;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(148, 41);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(83, 31);
            this.label6.TabIndex = 28;
            this.label6.Text = "Name:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(135, 321);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(96, 31);
            this.label5.TabIndex = 27;
            this.label5.Text = "Gender:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(15, 212);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(216, 31);
            this.label4.TabIndex = 26;
            this.label4.Text = "Telephone Number:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(117, 98);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(114, 31);
            this.label1.TabIndex = 25;
            this.label1.Text = "Surname:";
            // 
            // txtSurname
            // 
            this.txtSurname.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.txtSurname.Location = new System.Drawing.Point(237, 98);
            this.txtSurname.Name = "txtSurname";
            this.txtSurname.Size = new System.Drawing.Size(191, 38);
            this.txtSurname.TabIndex = 1;
            // 
            // txtName
            // 
            this.txtName.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.txtName.Location = new System.Drawing.Point(237, 41);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(191, 38);
            this.txtName.TabIndex = 0;
            // 
            // MskRegisterTC
            // 
            this.MskRegisterTC.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.MskRegisterTC.Location = new System.Drawing.Point(237, 154);
            this.MskRegisterTC.Mask = "00000000000";
            this.MskRegisterTC.Name = "MskRegisterTC";
            this.MskRegisterTC.Size = new System.Drawing.Size(191, 38);
            this.MskRegisterTC.TabIndex = 2;
            this.MskRegisterTC.ValidatingType = typeof(int);
            // 
            // txtRegisterPsswrd
            // 
            this.txtRegisterPsswrd.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.txtRegisterPsswrd.Location = new System.Drawing.Point(237, 262);
            this.txtRegisterPsswrd.Name = "txtRegisterPsswrd";
            this.txtRegisterPsswrd.Size = new System.Drawing.Size(191, 38);
            this.txtRegisterPsswrd.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(65, 161);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(166, 31);
            this.label2.TabIndex = 20;
            this.label2.Text = "TC ID Number:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(112, 269);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(119, 31);
            this.label3.TabIndex = 19;
            this.label3.Text = "Password:";
            // 
            // frm_PationİnformationUpdate
            // 
            this.AcceptButton = this.btnUpdate;
            this.AutoScaleDimensions = new System.Drawing.SizeF(13F, 31F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(467, 426);
            this.Controls.Add(this.btnUpdate);
            this.Controls.Add(this.cmbRegisterGender);
            this.Controls.Add(this.MskRegisterPhone);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtSurname);
            this.Controls.Add(this.txtName);
            this.Controls.Add(this.MskRegisterTC);
            this.Controls.Add(this.txtRegisterPsswrd);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label3);
            this.Font = new System.Drawing.Font("Corbel", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.MaximizeBox = false;
            this.Name = "frm_PationİnformationUpdate";
            this.Text = "İnformation update";
            this.Load += new System.EventHandler(this.frm_PationİnformationUpdate_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.ComboBox cmbRegisterGender;
        private System.Windows.Forms.MaskedTextBox MskRegisterPhone;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtSurname;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.MaskedTextBox MskRegisterTC;
        private System.Windows.Forms.TextBox txtRegisterPsswrd;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
    }
}