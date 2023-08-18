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
            txtKorisnickoIme.Font = new Font("Verdana", 12F, FontStyle.Regular, GraphicsUnit.Point);
            txtKorisnickoIme.Location = new Point(120, 113);
            txtKorisnickoIme.Name = "txtKorisnickoIme";
            txtKorisnickoIme.Size = new Size(240, 27);
            txtKorisnickoIme.TabIndex = 0;
            // 
            // lblKorisnickoIme
            // 
            lblKorisnickoIme.AutoSize = true;
            lblKorisnickoIme.FlatStyle = FlatStyle.System;
            lblKorisnickoIme.Font = new Font("Verdana", 11.25F, FontStyle.Regular, GraphicsUnit.Point);
            lblKorisnickoIme.ForeColor = SystemColors.ControlDarkDark;
            lblKorisnickoIme.Location = new Point(120, 92);
            lblKorisnickoIme.Name = "lblKorisnickoIme";
            lblKorisnickoIme.Size = new Size(115, 18);
            lblKorisnickoIme.TabIndex = 1;
            lblKorisnickoIme.Text = "Korisničko ime";
            // 
            // lblPassword
            // 
            lblPassword.AutoSize = true;
            lblPassword.FlatStyle = FlatStyle.System;
            lblPassword.Font = new Font("Verdana", 11.25F, FontStyle.Regular, GraphicsUnit.Point);
            lblPassword.ForeColor = SystemColors.ControlDarkDark;
            lblPassword.Location = new Point(120, 167);
            lblPassword.Name = "lblPassword";
            lblPassword.Size = new Size(65, 18);
            lblPassword.TabIndex = 3;
            lblPassword.Text = "Lozinka";
            // 
            // txtPassword
            // 
            txtPassword.Font = new Font("Verdana", 12F, FontStyle.Regular, GraphicsUnit.Point);
            txtPassword.Location = new Point(120, 188);
            txtPassword.Name = "txtPassword";
            txtPassword.Size = new Size(240, 27);
            txtPassword.TabIndex = 2;
            txtPassword.UseSystemPasswordChar = true;
            // 
            // btnLogin
            // 
            btnLogin.BackColor = Color.MidnightBlue;
            btnLogin.Font = new Font("Verdana", 12F, FontStyle.Regular, GraphicsUnit.Point);
            btnLogin.ForeColor = SystemColors.Control;
            btnLogin.Location = new Point(120, 257);
            btnLogin.Name = "btnLogin";
            btnLogin.Size = new Size(240, 48);
            btnLogin.TabIndex = 4;
            btnLogin.Text = "Prijavi se";
            btnLogin.UseVisualStyleBackColor = false;
            btnLogin.Click += btnLogin_Click;
            // 
            // frmLogin
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(467, 491);
            Controls.Add(btnLogin);
            Controls.Add(lblPassword);
            Controls.Add(txtPassword);
            Controls.Add(lblKorisnickoIme);
            Controls.Add(txtKorisnickoIme);
            Name = "frmLogin";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Prijava";
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