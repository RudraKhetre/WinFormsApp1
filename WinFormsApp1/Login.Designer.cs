namespace WindowsFormsApp1
{
    partial class Login
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        private System.Windows.Forms.Label lblLoginId;
        private System.Windows.Forms.Label lblPassword;
        private System.Windows.Forms.Label lblCountry;
        private System.Windows.Forms.Label lblCorporateId;
        private System.Windows.Forms.TextBox txtLoginId;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.TextBox txtCorporateId;
        private System.Windows.Forms.ComboBox cmbCountry;
        private System.Windows.Forms.Button btnLogin;
        private System.Windows.Forms.Button btnCancel;

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

        private void InitializeComponent()
        {
            lblLoginId = new Label();
            lblPassword = new Label();
            lblCountry = new Label();
            lblCorporateId = new Label();
            txtLoginId = new TextBox();
            txtPassword = new TextBox();
            cmbCountry = new ComboBox();
            txtCorporateId = new TextBox();
            btnLogin = new Button();
            btnCancel = new Button();
            SuspendLayout();
            // 
            // lblLoginId
            // 
            lblLoginId.AutoSize = true;
            lblLoginId.Location = new Point(59, 50);
            lblLoginId.Margin = new Padding(4, 0, 4, 0);
            lblLoginId.Name = "lblLoginId";
            lblLoginId.Size = new Size(54, 15);
            lblLoginId.TabIndex = 0;
            lblLoginId.Text = "Login ID:";
            lblLoginId.Click += lblLoginId_Click;
            // 
            // lblPassword
            // 
            lblPassword.AutoSize = true;
            lblPassword.Location = new Point(59, 90);
            lblPassword.Margin = new Padding(4, 0, 4, 0);
            lblPassword.Name = "lblPassword";
            lblPassword.Size = new Size(60, 15);
            lblPassword.TabIndex = 1;
            lblPassword.Text = "Password:";
            // 
            // lblCountry
            // 
            lblCountry.AutoSize = true;
            lblCountry.Location = new Point(59, 130);
            lblCountry.Margin = new Padding(4, 0, 4, 0);
            lblCountry.Name = "lblCountry";
            lblCountry.Size = new Size(53, 15);
            lblCountry.TabIndex = 2;
            lblCountry.Text = "Country:";
            // 
            // lblCorporateId
            // 
            lblCorporateId.AutoSize = true;
            lblCorporateId.Location = new Point(59, 170);
            lblCorporateId.Margin = new Padding(4, 0, 4, 0);
            lblCorporateId.Name = "lblCorporateId";
            lblCorporateId.Size = new Size(77, 15);
            lblCorporateId.TabIndex = 3;
            lblCorporateId.Text = "Corporate ID:";
            // 
            // txtLoginId
            // 
            txtLoginId.Location = new Point(160, 47);
            txtLoginId.Margin = new Padding(4, 3, 4, 3);
            txtLoginId.Name = "txtLoginId";
            txtLoginId.Size = new Size(180, 23);
            txtLoginId.TabIndex = 4;
            txtLoginId.TextChanged += txtLoginId_TextChanged;
            // 
            // txtPassword
            // 
            txtPassword.Location = new Point(160, 87);
            txtPassword.Margin = new Padding(4, 3, 4, 3);
            txtPassword.Name = "txtPassword";
            txtPassword.PasswordChar = '*';
            txtPassword.Size = new Size(180, 23);
            txtPassword.TabIndex = 5;
            // 
            // cmbCountry
            // 
            cmbCountry.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbCountry.FormattingEnabled = true;
            cmbCountry.Items.AddRange(new object[] { "India", "USA", "UK", "Canada" });
            cmbCountry.Location = new Point(160, 127);
            cmbCountry.Margin = new Padding(4, 3, 4, 3);
            cmbCountry.Name = "cmbCountry";
            cmbCountry.Size = new Size(180, 23);
            cmbCountry.TabIndex = 6;
            // 
            // txtCorporateId
            // 
            txtCorporateId.Location = new Point(160, 167);
            txtCorporateId.Margin = new Padding(4, 3, 4, 3);
            txtCorporateId.Name = "txtCorporateId";
            txtCorporateId.Size = new Size(180, 23);
            txtCorporateId.TabIndex = 7;
            txtCorporateId.TextChanged += txtCorporateId_TextChanged;
            // 
            // btnLogin
            // 
            btnLogin.Location = new Point(160, 210);
            btnLogin.Margin = new Padding(4, 3, 4, 3);
            btnLogin.Name = "btnLogin";
            btnLogin.Size = new Size(75, 25);
            btnLogin.TabIndex = 8;
            btnLogin.Text = "Login";
            btnLogin.UseVisualStyleBackColor = true;
            // 
            // btnCancel
            // 
            btnCancel.Location = new Point(265, 210);
            btnCancel.Margin = new Padding(4, 3, 4, 3);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(75, 25);
            btnCancel.TabIndex = 9;
            btnCancel.Text = "Cancel";
            btnCancel.UseVisualStyleBackColor = true;
            // 
            // Login
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(420, 280);
            Controls.Add(btnCancel);
            Controls.Add(btnLogin);
            Controls.Add(txtCorporateId);
            Controls.Add(cmbCountry);
            Controls.Add(txtPassword);
            Controls.Add(txtLoginId);
            Controls.Add(lblCorporateId);
            Controls.Add(lblCountry);
            Controls.Add(lblPassword);
            Controls.Add(lblLoginId);
            Margin = new Padding(4, 3, 4, 3);
            Name = "Login";
            Text = "Dossier-Mgmt - Update Root Directory Name (User Login)";
            ResumeLayout(false);
            PerformLayout();

        }

        #endregion
    }
}
