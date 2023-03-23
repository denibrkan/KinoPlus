namespace KinoPlus.WinUI
{
    partial class frmProjekcije
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
            cmbLokacija = new ComboBox();
            lblLokacija = new Label();
            lblDatum = new Label();
            dtpDatum = new DateTimePicker();
            btnDodaj = new Button();
            SuspendLayout();
            // 
            // cmbLokacija
            // 
            cmbLokacija.Font = new Font("Dubai", 10F, FontStyle.Regular, GraphicsUnit.Point);
            cmbLokacija.FormattingEnabled = true;
            cmbLokacija.Location = new Point(391, 109);
            cmbLokacija.Name = "cmbLokacija";
            cmbLokacija.Size = new Size(187, 30);
            cmbLokacija.TabIndex = 11;
            // 
            // lblLokacija
            // 
            lblLokacija.AutoSize = true;
            lblLokacija.Font = new Font("Dubai", 9.749999F, FontStyle.Regular, GraphicsUnit.Point);
            lblLokacija.ForeColor = SystemColors.ControlDarkDark;
            lblLokacija.Location = new Point(391, 84);
            lblLokacija.Name = "lblLokacija";
            lblLokacija.Size = new Size(53, 22);
            lblLokacija.TabIndex = 9;
            lblLokacija.Text = "Lokacija";
            // 
            // lblDatum
            // 
            lblDatum.AutoSize = true;
            lblDatum.Font = new Font("Dubai", 9.749999F, FontStyle.Regular, GraphicsUnit.Point);
            lblDatum.ForeColor = SystemColors.ControlDarkDark;
            lblDatum.Location = new Point(71, 84);
            lblDatum.Name = "lblDatum";
            lblDatum.Size = new Size(47, 22);
            lblDatum.TabIndex = 10;
            lblDatum.Text = "Datum";
            // 
            // dtpDatum
            // 
            dtpDatum.CalendarFont = new Font("Dubai", 10F, FontStyle.Regular, GraphicsUnit.Point);
            dtpDatum.Font = new Font("Dubai", 10F, FontStyle.Regular, GraphicsUnit.Point);
            dtpDatum.Location = new Point(71, 109);
            dtpDatum.Name = "dtpDatum";
            dtpDatum.Size = new Size(229, 30);
            dtpDatum.TabIndex = 8;
            // 
            // btnDodaj
            // 
            btnDodaj.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnDodaj.Font = new Font("Dubai", 12F, FontStyle.Regular, GraphicsUnit.Point);
            btnDodaj.Location = new Point(999, 107);
            btnDodaj.Margin = new Padding(4, 3, 4, 3);
            btnDodaj.Name = "btnDodaj";
            btnDodaj.Size = new Size(122, 32);
            btnDodaj.TabIndex = 7;
            btnDodaj.Text = "Dodaj";
            btnDodaj.UseVisualStyleBackColor = true;
            // 
            // frmProjekcije
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1264, 744);
            ControlBox = false;
            Controls.Add(cmbLokacija);
            Controls.Add(lblLokacija);
            Controls.Add(lblDatum);
            Controls.Add(dtpDatum);
            Controls.Add(btnDodaj);
            FormBorderStyle = FormBorderStyle.None;
            Name = "frmProjekcije";
            Text = "Projekcije";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ComboBox cmbLokacija;
        private Label lblLokacija;
        private Label lblDatum;
        private DateTimePicker dtpDatum;
        private Button btnDodaj;
    }
}