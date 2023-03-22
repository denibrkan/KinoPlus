namespace eProdaja.WinUI
{
    partial class frmLogin
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
            txtKorisnickoIme = new TextBox();
            lblKorisnickoIme = new Label();
            lblPassword = new Label();
            txtPassword = new TextBox();
            btnLogin = new Button();
            SuspendLayout();
            // 
            // txtKorisnickoIme
            // 
            txtKorisnickoIme.Location = new Point(160, 192);
            txtKorisnickoIme.Margin = new Padding(4, 5, 4, 5);
            txtKorisnickoIme.Name = "txtKorisnickoIme";
            txtKorisnickoIme.Size = new Size(231, 31);
            txtKorisnickoIme.TabIndex = 0;
            // 
            // lblKorisnickoIme
            // 
            lblKorisnickoIme.AutoSize = true;
            lblKorisnickoIme.Font = new Font("Dubai", 12F, FontStyle.Regular, GraphicsUnit.Point);
            lblKorisnickoIme.ForeColor = SystemColors.ControlDarkDark;
            lblKorisnickoIme.Location = new Point(154, 142);
            lblKorisnickoIme.Margin = new Padding(4, 0, 4, 0);
            lblKorisnickoIme.Name = "lblKorisnickoIme";
            lblKorisnickoIme.Size = new Size(158, 40);
            lblKorisnickoIme.TabIndex = 1;
            lblKorisnickoIme.Text = "Korisnicko ime";
            // 
            // lblPassword
            // 
            lblPassword.AutoSize = true;
            lblPassword.Font = new Font("Dubai", 12F, FontStyle.Regular, GraphicsUnit.Point);
            lblPassword.ForeColor = SystemColors.ControlDarkDark;
            lblPassword.Location = new Point(154, 252);
            lblPassword.Margin = new Padding(4, 0, 4, 0);
            lblPassword.Name = "lblPassword";
            lblPassword.Size = new Size(111, 40);
            lblPassword.TabIndex = 3;
            lblPassword.Text = "Password";
            // 
            // txtPassword
            // 
            txtPassword.Location = new Point(159, 302);
            txtPassword.Margin = new Padding(4, 5, 4, 5);
            txtPassword.Name = "txtPassword";
            txtPassword.Size = new Size(231, 31);
            txtPassword.TabIndex = 2;
            txtPassword.UseSystemPasswordChar = true;
            // 
            // btnLogin
            // 
            btnLogin.BackColor = Color.MidnightBlue;
            btnLogin.Font = new Font("Dubai", 12F, FontStyle.Regular, GraphicsUnit.Point);
            btnLogin.ForeColor = SystemColors.Control;
            btnLogin.Location = new Point(191, 382);
            btnLogin.Margin = new Padding(4, 5, 4, 5);
            btnLogin.Name = "btnLogin";
            btnLogin.Size = new Size(156, 65);
            btnLogin.TabIndex = 4;
            btnLogin.Text = "Log in";
            btnLogin.UseVisualStyleBackColor = false;
            btnLogin.Click += btnLogin_Click;
            // 
            // frmLogin
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(597, 772);
            Controls.Add(btnLogin);
            Controls.Add(lblPassword);
            Controls.Add(txtPassword);
            Controls.Add(lblKorisnickoIme);
            Controls.Add(txtKorisnickoIme);
            Margin = new Padding(4, 5, 4, 5);
            Name = "frmLogin";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Login";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox txtKorisnickoIme;
        private Label lblKorisnickoIme;
        private Label lblPassword;
        private TextBox txtPassword;
        private Button btnLogin;
    }
}