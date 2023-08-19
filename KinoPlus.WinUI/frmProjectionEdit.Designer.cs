namespace KinoPlus.WinUI.Projections
{
    partial class frmProjectionEdit
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
            dtpDatumVrijeme = new DateTimePicker();
            lblDatumProjekcije = new Label();
            lblDvorana = new Label();
            cmbDvorana = new ComboBox();
            btnOtkazi = new Button();
            btnSpasi = new Button();
            SuspendLayout();
            // 
            // dtpDatumVrijeme
            // 
            dtpDatumVrijeme.CustomFormat = "dd/MM/yyyy HH:mm";
            dtpDatumVrijeme.Font = new Font("Verdana", 11.25F, FontStyle.Regular, GraphicsUnit.Point);
            dtpDatumVrijeme.Format = DateTimePickerFormat.Custom;
            dtpDatumVrijeme.Location = new Point(78, 95);
            dtpDatumVrijeme.Name = "dtpDatumVrijeme";
            dtpDatumVrijeme.Size = new Size(200, 26);
            dtpDatumVrijeme.TabIndex = 0;
            // 
            // lblDatumProjekcije
            // 
            lblDatumProjekcije.AutoSize = true;
            lblDatumProjekcije.FlatStyle = FlatStyle.System;
            lblDatumProjekcije.Font = new Font("Verdana", 11.25F, FontStyle.Regular, GraphicsUnit.Point);
            lblDatumProjekcije.ForeColor = SystemColors.ControlDarkDark;
            lblDatumProjekcije.Location = new Point(78, 70);
            lblDatumProjekcije.Margin = new Padding(0);
            lblDatumProjekcije.Name = "lblDatumProjekcije";
            lblDatumProjekcije.Size = new Size(127, 18);
            lblDatumProjekcije.TabIndex = 27;
            lblDatumProjekcije.Text = "Datum i vrijeme";
            // 
            // lblDvorana
            // 
            lblDvorana.AutoSize = true;
            lblDvorana.FlatStyle = FlatStyle.System;
            lblDvorana.Font = new Font("Verdana", 11.25F, FontStyle.Regular, GraphicsUnit.Point);
            lblDvorana.ForeColor = SystemColors.ControlDarkDark;
            lblDvorana.Location = new Point(375, 70);
            lblDvorana.Margin = new Padding(0);
            lblDvorana.Name = "lblDvorana";
            lblDvorana.Size = new Size(71, 18);
            lblDvorana.TabIndex = 27;
            lblDvorana.Text = "Dvorana";
            // 
            // cmbDvorana
            // 
            cmbDvorana.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbDvorana.FlatStyle = FlatStyle.Flat;
            cmbDvorana.Font = new Font("Verdana", 11.25F, FontStyle.Regular, GraphicsUnit.Point);
            cmbDvorana.FormattingEnabled = true;
            cmbDvorana.Location = new Point(375, 95);
            cmbDvorana.Name = "cmbDvorana";
            cmbDvorana.Size = new Size(199, 26);
            cmbDvorana.TabIndex = 28;
            // 
            // btnOtkazi
            // 
            btnOtkazi.Anchor = AnchorStyles.None;
            btnOtkazi.BackColor = Color.Red;
            btnOtkazi.Font = new Font("Verdana", 12F, FontStyle.Regular, GraphicsUnit.Point);
            btnOtkazi.ForeColor = Color.White;
            btnOtkazi.Location = new Point(85, 314);
            btnOtkazi.Name = "btnOtkazi";
            btnOtkazi.Size = new Size(115, 35);
            btnOtkazi.TabIndex = 29;
            btnOtkazi.Text = "Otkaži";
            btnOtkazi.UseVisualStyleBackColor = false;
            btnOtkazi.Click += btnOtkazi_Click;
            // 
            // btnSpasi
            // 
            btnSpasi.Anchor = AnchorStyles.None;
            btnSpasi.Font = new Font("Verdana", 12F, FontStyle.Regular, GraphicsUnit.Point);
            btnSpasi.Location = new Point(306, 314);
            btnSpasi.Name = "btnSpasi";
            btnSpasi.Size = new Size(108, 35);
            btnSpasi.TabIndex = 29;
            btnSpasi.Text = "Spasi";
            btnSpasi.UseVisualStyleBackColor = true;
            btnSpasi.Click += btnSpasi_Click;
            // 
            // frmProjectionEdit
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(665, 392);
            Controls.Add(btnSpasi);
            Controls.Add(btnOtkazi);
            Controls.Add(cmbDvorana);
            Controls.Add(lblDvorana);
            Controls.Add(lblDatumProjekcije);
            Controls.Add(dtpDatumVrijeme);
            Name = "frmProjectionEdit";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Uredi Projekciju";
            Load += frmProjectionEdit_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DateTimePicker dtpDatumVrijeme;
        private Label lblDatumProjekcije;
        private Label lblDvorana;
        private ComboBox cmbDvorana;
        private Button btnOtkazi;
        private Button btnSpasi;
    }
}