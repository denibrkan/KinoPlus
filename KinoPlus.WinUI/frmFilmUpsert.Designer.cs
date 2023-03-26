namespace KinoPlus.WinUI
{
    partial class frmFilmUpsert
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
            components = new System.ComponentModel.Container();
            lblNaziv = new Label();
            txtNaziv = new TextBox();
            cmbGodina = new ComboBox();
            lblGodina = new Label();
            lblTrajanje = new Label();
            pcbSlika = new PictureBox();
            btnOdaberi = new Button();
            lblStatus = new Label();
            cmbStatus = new ComboBox();
            btnSpasi = new Button();
            ofdSlika = new OpenFileDialog();
            lbKategorija = new ListBox();
            lbZanr = new ListBox();
            lbUloge = new ListBox();
            rtbOpis = new RichTextBox();
            lblKategorija = new Label();
            lblZanr = new Label();
            lblUloge = new Label();
            lbllOpis = new Label();
            lblTrailer = new Label();
            txtTrailer = new TextBox();
            numTrajanje = new NumericUpDown();
            errorProvider = new ErrorProvider(components);
            ((System.ComponentModel.ISupportInitialize)pcbSlika).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numTrajanje).BeginInit();
            ((System.ComponentModel.ISupportInitialize)errorProvider).BeginInit();
            SuspendLayout();
            // 
            // lblNaziv
            // 
            lblNaziv.AutoSize = true;
            lblNaziv.Font = new Font("Dubai", 11.25F, FontStyle.Regular, GraphicsUnit.Point);
            lblNaziv.ForeColor = SystemColors.ControlDarkDark;
            lblNaziv.Location = new Point(296, 80);
            lblNaziv.Name = "lblNaziv";
            lblNaziv.Size = new Size(45, 25);
            lblNaziv.TabIndex = 6;
            lblNaziv.Text = "Naziv";
            // 
            // txtNaziv
            // 
            txtNaziv.Font = new Font("Dubai", 12F, FontStyle.Regular, GraphicsUnit.Point);
            txtNaziv.Location = new Point(296, 108);
            txtNaziv.Name = "txtNaziv";
            txtNaziv.Size = new Size(321, 35);
            txtNaziv.TabIndex = 0;
            txtNaziv.Validating += txtNaziv_Validating;
            // 
            // cmbGodina
            // 
            cmbGodina.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbGodina.FlatStyle = FlatStyle.Flat;
            cmbGodina.Font = new Font("Dubai", 12F, FontStyle.Regular, GraphicsUnit.Point);
            cmbGodina.FormattingEnabled = true;
            cmbGodina.Location = new Point(712, 108);
            cmbGodina.Name = "cmbGodina";
            cmbGodina.Size = new Size(127, 35);
            cmbGodina.TabIndex = 2;
            cmbGodina.Validating += cmbGodina_Validating;
            // 
            // lblGodina
            // 
            lblGodina.AutoSize = true;
            lblGodina.Font = new Font("Dubai", 11.25F, FontStyle.Regular, GraphicsUnit.Point);
            lblGodina.ForeColor = SystemColors.ControlDarkDark;
            lblGodina.Location = new Point(712, 81);
            lblGodina.Name = "lblGodina";
            lblGodina.Size = new Size(56, 25);
            lblGodina.TabIndex = 11;
            lblGodina.Text = "Godina";
            // 
            // lblTrajanje
            // 
            lblTrajanje.AutoSize = true;
            lblTrajanje.Font = new Font("Dubai", 11.25F, FontStyle.Regular, GraphicsUnit.Point);
            lblTrajanje.ForeColor = SystemColors.ControlDarkDark;
            lblTrajanje.Location = new Point(927, 80);
            lblTrajanje.Name = "lblTrajanje";
            lblTrajanje.Size = new Size(98, 25);
            lblTrajanje.TabIndex = 6;
            lblTrajanje.Text = "Trajanje (min)";
            // 
            // pcbSlika
            // 
            pcbSlika.BackColor = SystemColors.ControlLightLight;
            pcbSlika.Location = new Point(83, 81);
            pcbSlika.Name = "pcbSlika";
            pcbSlika.Size = new Size(155, 190);
            pcbSlika.SizeMode = PictureBoxSizeMode.StretchImage;
            pcbSlika.TabIndex = 13;
            pcbSlika.TabStop = false;
            pcbSlika.Validating += pcbSlika_Validating;
            // 
            // btnOdaberi
            // 
            btnOdaberi.Font = new Font("Dubai", 9.749999F, FontStyle.Regular, GraphicsUnit.Point);
            btnOdaberi.Location = new Point(116, 290);
            btnOdaberi.Name = "btnOdaberi";
            btnOdaberi.Size = new Size(86, 30);
            btnOdaberi.TabIndex = 11;
            btnOdaberi.Text = "Odaberi";
            btnOdaberi.UseVisualStyleBackColor = true;
            btnOdaberi.Click += btnOdaberi_Click;
            // 
            // lblStatus
            // 
            lblStatus.AutoSize = true;
            lblStatus.Font = new Font("Dubai", 11.25F, FontStyle.Regular, GraphicsUnit.Point);
            lblStatus.ForeColor = SystemColors.ControlDarkDark;
            lblStatus.Location = new Point(295, 195);
            lblStatus.Name = "lblStatus";
            lblStatus.Size = new Size(51, 25);
            lblStatus.TabIndex = 11;
            lblStatus.Text = "Status";
            // 
            // cmbStatus
            // 
            cmbStatus.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbStatus.FlatStyle = FlatStyle.Flat;
            cmbStatus.Font = new Font("Dubai", 12F, FontStyle.Regular, GraphicsUnit.Point);
            cmbStatus.FormattingEnabled = true;
            cmbStatus.Location = new Point(296, 222);
            cmbStatus.Name = "cmbStatus";
            cmbStatus.Size = new Size(189, 35);
            cmbStatus.TabIndex = 4;
            cmbStatus.Validating += cmbStatus_Validating;
            // 
            // btnSpasi
            // 
            btnSpasi.Font = new Font("Dubai", 12F, FontStyle.Regular, GraphicsUnit.Point);
            btnSpasi.Location = new Point(595, 609);
            btnSpasi.Name = "btnSpasi";
            btnSpasi.Size = new Size(108, 35);
            btnSpasi.TabIndex = 10;
            btnSpasi.Text = "Spasi";
            btnSpasi.UseVisualStyleBackColor = true;
            btnSpasi.Click += btnSpasi_Click;
            // 
            // ofdSlika
            // 
            ofdSlika.Filter = "jpg files(.*jpg)|*.jpg| PNG files(.*png)|*.png| All Files(*.*)|*.*";
            // 
            // lbKategorija
            // 
            lbKategorija.Font = new Font("Dubai", 12F, FontStyle.Regular, GraphicsUnit.Point);
            lbKategorija.FormattingEnabled = true;
            lbKategorija.ItemHeight = 27;
            lbKategorija.Location = new Point(553, 222);
            lbKategorija.Name = "lbKategorija";
            lbKategorija.SelectionMode = SelectionMode.MultiSimple;
            lbKategorija.Size = new Size(210, 85);
            lbKategorija.TabIndex = 5;
            // 
            // lbZanr
            // 
            lbZanr.Font = new Font("Dubai", 12F, FontStyle.Regular, GraphicsUnit.Point);
            lbZanr.FormattingEnabled = true;
            lbZanr.ItemHeight = 27;
            lbZanr.Location = new Point(847, 222);
            lbZanr.Name = "lbZanr";
            lbZanr.SelectionMode = SelectionMode.MultiSimple;
            lbZanr.Size = new Size(210, 85);
            lbZanr.TabIndex = 6;
            // 
            // lbUloge
            // 
            lbUloge.Font = new Font("Dubai", 12F, FontStyle.Regular, GraphicsUnit.Point);
            lbUloge.FormattingEnabled = true;
            lbUloge.ItemHeight = 27;
            lbUloge.Location = new Point(296, 354);
            lbUloge.Name = "lbUloge";
            lbUloge.SelectionMode = SelectionMode.MultiSimple;
            lbUloge.Size = new Size(321, 85);
            lbUloge.TabIndex = 7;
            // 
            // rtbOpis
            // 
            rtbOpis.Font = new Font("Dubai", 9.749999F, FontStyle.Regular, GraphicsUnit.Point);
            rtbOpis.Location = new Point(701, 354);
            rtbOpis.Name = "rtbOpis";
            rtbOpis.Size = new Size(356, 167);
            rtbOpis.TabIndex = 8;
            rtbOpis.Text = "";
            rtbOpis.Validating += rtbOpis_Validating;
            // 
            // lblKategorija
            // 
            lblKategorija.AutoSize = true;
            lblKategorija.Font = new Font("Dubai", 11.25F, FontStyle.Regular, GraphicsUnit.Point);
            lblKategorija.ForeColor = SystemColors.ControlDarkDark;
            lblKategorija.Location = new Point(553, 195);
            lblKategorija.Name = "lblKategorija";
            lblKategorija.Size = new Size(73, 25);
            lblKategorija.TabIndex = 11;
            lblKategorija.Text = "Kategorija";
            // 
            // lblZanr
            // 
            lblZanr.AutoSize = true;
            lblZanr.Font = new Font("Dubai", 11.25F, FontStyle.Regular, GraphicsUnit.Point);
            lblZanr.ForeColor = SystemColors.ControlDarkDark;
            lblZanr.Location = new Point(847, 195);
            lblZanr.Name = "lblZanr";
            lblZanr.Size = new Size(40, 25);
            lblZanr.TabIndex = 11;
            lblZanr.Text = "Zanr";
            // 
            // lblUloge
            // 
            lblUloge.AutoSize = true;
            lblUloge.Font = new Font("Dubai", 11.25F, FontStyle.Regular, GraphicsUnit.Point);
            lblUloge.ForeColor = SystemColors.ControlDarkDark;
            lblUloge.Location = new Point(295, 326);
            lblUloge.Name = "lblUloge";
            lblUloge.Size = new Size(47, 25);
            lblUloge.TabIndex = 11;
            lblUloge.Text = "Uloge";
            // 
            // lbllOpis
            // 
            lbllOpis.AutoSize = true;
            lbllOpis.Font = new Font("Dubai", 11.25F, FontStyle.Regular, GraphicsUnit.Point);
            lbllOpis.ForeColor = SystemColors.ControlDarkDark;
            lbllOpis.Location = new Point(701, 327);
            lbllOpis.Name = "lbllOpis";
            lbllOpis.Size = new Size(40, 25);
            lbllOpis.TabIndex = 11;
            lbllOpis.Text = "Opis";
            // 
            // lblTrailer
            // 
            lblTrailer.AutoSize = true;
            lblTrailer.Font = new Font("Dubai", 11.25F, FontStyle.Regular, GraphicsUnit.Point);
            lblTrailer.ForeColor = SystemColors.ControlDarkDark;
            lblTrailer.Location = new Point(296, 464);
            lblTrailer.Name = "lblTrailer";
            lblTrailer.Size = new Size(73, 25);
            lblTrailer.TabIndex = 6;
            lblTrailer.Text = "Trailer Url";
            // 
            // txtTrailer
            // 
            txtTrailer.Font = new Font("Dubai", 9.749999F, FontStyle.Regular, GraphicsUnit.Point);
            txtTrailer.Location = new Point(296, 492);
            txtTrailer.Name = "txtTrailer";
            txtTrailer.Size = new Size(321, 29);
            txtTrailer.TabIndex = 9;
            // 
            // numTrajanje
            // 
            numTrajanje.Font = new Font("Dubai", 12F, FontStyle.Regular, GraphicsUnit.Point);
            numTrajanje.Location = new Point(927, 108);
            numTrajanje.Maximum = new decimal(new int[] { 500, 0, 0, 0 });
            numTrajanje.Name = "numTrajanje";
            numTrajanje.RightToLeft = RightToLeft.No;
            numTrajanje.Size = new Size(130, 35);
            numTrajanje.TabIndex = 3;
            numTrajanje.Validating += numTrajanje_Validating;
            // 
            // errorProvider
            // 
            errorProvider.ContainerControl = this;
            // 
            // frmFilmUpsert
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1270, 725);
            Controls.Add(numTrajanje);
            Controls.Add(rtbOpis);
            Controls.Add(lbZanr);
            Controls.Add(lbUloge);
            Controls.Add(lbKategorija);
            Controls.Add(btnSpasi);
            Controls.Add(btnOdaberi);
            Controls.Add(pcbSlika);
            Controls.Add(cmbStatus);
            Controls.Add(lblZanr);
            Controls.Add(lbllOpis);
            Controls.Add(lblUloge);
            Controls.Add(lblKategorija);
            Controls.Add(lblStatus);
            Controls.Add(cmbGodina);
            Controls.Add(lblGodina);
            Controls.Add(lblTrajanje);
            Controls.Add(txtTrailer);
            Controls.Add(lblTrailer);
            Controls.Add(txtNaziv);
            Controls.Add(lblNaziv);
            Name = "frmFilmUpsert";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Novi Film";
            Load += frmFilmUpsert_Load;
            ((System.ComponentModel.ISupportInitialize)pcbSlika).EndInit();
            ((System.ComponentModel.ISupportInitialize)numTrajanje).EndInit();
            ((System.ComponentModel.ISupportInitialize)errorProvider).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblNaziv;
        private TextBox txtNaziv;
        private ComboBox cmbGodina;
        private Label lblGodina;
        private Label lblTrajanje;
        private PictureBox pcbSlika;
        private Button btnOdaberi;
        private Label lblStatus;
        private ComboBox cmbStatus;
        private Button btnSpasi;
        private OpenFileDialog ofdSlika;
        private ListBox lbKategorija;
        private ListBox lbZanr;
        private ListBox lbUloge;
        private RichTextBox rtbOpis;
        private Label lblKategorija;
        private Label lblZanr;
        private Label lblUloge;
        private Label lbllOpis;
        private Label lblTrailer;
        private TextBox txtTrailer;
        private NumericUpDown numTrajanje;
        private ErrorProvider errorProvider;
    }
}