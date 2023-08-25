namespace KinoPlus.WinUI
{
    partial class frmReports
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
            reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            dtpDatumOd = new DateTimePicker();
            lblDatumOd = new Label();
            dtpDatumDo = new DateTimePicker();
            lblDatumDo = new Label();
            label1 = new Label();
            btnOsvjezi = new Button();
            cmbLokacija = new ComboBox();
            lblLokacija = new Label();
            lblFilm = new Label();
            cmbFilm = new ComboBox();
            SuspendLayout();
            // 
            // reportViewer1
            // 
            reportViewer1.LocalReport.ReportEmbeddedResource = "KinoPlus.WinUI.Reports.rptProjekcije.rdlc";
            reportViewer1.Location = new Point(110, 220);
            reportViewer1.Name = "ReportViewer";
            reportViewer1.ServerReport.BearerToken = null;
            reportViewer1.Size = new Size(1200, 700);
            reportViewer1.TabIndex = 0;
            // 
            // dtpDatumOd
            // 
            dtpDatumOd.Font = new Font("Verdana", 11.25F, FontStyle.Regular, GraphicsUnit.Point);
            dtpDatumOd.Format = DateTimePickerFormat.Short;
            dtpDatumOd.Location = new Point(111, 164);
            dtpDatumOd.Name = "dtpDatumOd";
            dtpDatumOd.Size = new Size(200, 26);
            dtpDatumOd.TabIndex = 14;
            // 
            // lblDatumOd
            // 
            lblDatumOd.AutoSize = true;
            lblDatumOd.FlatStyle = FlatStyle.System;
            lblDatumOd.Font = new Font("Verdana", 10F, FontStyle.Regular, GraphicsUnit.Point);
            lblDatumOd.ForeColor = SystemColors.ControlDarkDark;
            lblDatumOd.Location = new Point(111, 144);
            lblDatumOd.Name = "lblDatumOd";
            lblDatumOd.Size = new Size(28, 17);
            lblDatumOd.TabIndex = 15;
            lblDatumOd.Text = "Od";
            // 
            // dtpDatumDo
            // 
            dtpDatumDo.Font = new Font("Verdana", 11.25F, FontStyle.Regular, GraphicsUnit.Point);
            dtpDatumDo.Format = DateTimePickerFormat.Short;
            dtpDatumDo.Location = new Point(355, 164);
            dtpDatumDo.Name = "dtpDatumDo";
            dtpDatumDo.Size = new Size(200, 26);
            dtpDatumDo.TabIndex = 16;
            // 
            // lblDatumDo
            // 
            lblDatumDo.AutoSize = true;
            lblDatumDo.FlatStyle = FlatStyle.System;
            lblDatumDo.Font = new Font("Verdana", 10F, FontStyle.Regular, GraphicsUnit.Point);
            lblDatumDo.ForeColor = SystemColors.ControlDarkDark;
            lblDatumDo.Location = new Point(355, 144);
            lblDatumDo.Name = "lblDatumDo";
            lblDatumDo.Size = new Size(28, 17);
            lblDatumDo.TabIndex = 17;
            lblDatumDo.Text = "Do";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Verdana", 11.25F, FontStyle.Regular, GraphicsUnit.Point);
            label1.Location = new Point(107, 86);
            label1.Name = "label1";
            label1.Size = new Size(478, 18);
            label1.TabIndex = 18;
            label1.Text = "Generiraj izvještaj o projekcijama unutar datumskog intervala:";
            // 
            // btnOsvjezi
            // 
            btnOsvjezi.Font = new Font("Verdana", 11.25F, FontStyle.Regular, GraphicsUnit.Point);
            btnOsvjezi.Location = new Point(1208, 155);
            btnOsvjezi.Name = "btnOsvjezi";
            btnOsvjezi.Size = new Size(108, 35);
            btnOsvjezi.TabIndex = 19;
            btnOsvjezi.Text = "Osvježi";
            btnOsvjezi.UseVisualStyleBackColor = true;
            btnOsvjezi.Click += btnOsvjezi_Click;
            // 
            // cmbLokacija
            // 
            cmbLokacija.FlatStyle = FlatStyle.Flat;
            cmbLokacija.Font = new Font("Verdana", 11.25F, FontStyle.Regular, GraphicsUnit.Point);
            cmbLokacija.FormattingEnabled = true;
            cmbLokacija.Location = new Point(596, 164);
            cmbLokacija.Name = "cmbLokacija";
            cmbLokacija.Size = new Size(250, 26);
            cmbLokacija.TabIndex = 21;
            // 
            // lblLokacija
            // 
            lblLokacija.AutoSize = true;
            lblLokacija.FlatStyle = FlatStyle.System;
            lblLokacija.Font = new Font("Verdana", 9.749999F, FontStyle.Regular, GraphicsUnit.Point);
            lblLokacija.ForeColor = SystemColors.ControlDarkDark;
            lblLokacija.Location = new Point(596, 145);
            lblLokacija.Name = "lblLokacija";
            lblLokacija.Size = new Size(60, 16);
            lblLokacija.TabIndex = 20;
            lblLokacija.Text = "Lokacija";
            // 
            // lblFilm
            // 
            lblFilm.AutoSize = true;
            lblFilm.FlatStyle = FlatStyle.System;
            lblFilm.Font = new Font("Verdana", 9.749999F, FontStyle.Regular, GraphicsUnit.Point);
            lblFilm.ForeColor = SystemColors.ControlDarkDark;
            lblFilm.Location = new Point(872, 145);
            lblFilm.Name = "lblFilm";
            lblFilm.Size = new Size(32, 16);
            lblFilm.TabIndex = 20;
            lblFilm.Text = "Film";
            // 
            // cmbFilm
            // 
            cmbFilm.FlatStyle = FlatStyle.Flat;
            cmbFilm.Font = new Font("Verdana", 11.25F, FontStyle.Regular, GraphicsUnit.Point);
            cmbFilm.FormattingEnabled = true;
            cmbFilm.Location = new Point(872, 164);
            cmbFilm.Name = "cmbFilm";
            cmbFilm.Size = new Size(250, 26);
            cmbFilm.TabIndex = 21;
            // 
            // frmReports
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1448, 1000);
            ControlBox = false;
            Controls.Add(cmbFilm);
            Controls.Add(lblFilm);
            Controls.Add(cmbLokacija);
            Controls.Add(lblLokacija);
            Controls.Add(btnOsvjezi);
            Controls.Add(label1);
            Controls.Add(dtpDatumDo);
            Controls.Add(lblDatumDo);
            Controls.Add(dtpDatumOd);
            Controls.Add(lblDatumOd);
            Controls.Add(reportViewer1);
            FormBorderStyle = FormBorderStyle.None;
            Name = "frmReports";
            Text = "Izvjestaji";
            Load += frmIzvjestaji_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private DateTimePicker dtpDatumOd;
        private Label lblDatumOd;
        private DateTimePicker dtpDatumDo;
        private Label lblDatumDo;
        private Label label1;
        private Button btnOsvjezi;
        private ComboBox cmbLokacija;
        private Label lblLokacija;
        private Label lblFilm;
        private ComboBox cmbFilm;
    }
}