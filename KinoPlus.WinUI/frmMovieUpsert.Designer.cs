namespace KinoPlus.WinUI
{
    partial class frmMovieUpsert
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
            lblPopularnost = new Label();
            numPopularnost = new NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)pcbSlika).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numTrajanje).BeginInit();
            ((System.ComponentModel.ISupportInitialize)errorProvider).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numPopularnost).BeginInit();
            SuspendLayout();
            // 
            // lblNaziv
            // 
            lblNaziv.AutoSize = true;
            lblNaziv.FlatStyle = FlatStyle.System;
            lblNaziv.Font = new Font("Verdana", 11.25F, FontStyle.Regular, GraphicsUnit.Point);
            lblNaziv.ForeColor = SystemColors.ControlDarkDark;
            lblNaziv.Location = new Point(247, 53);
            lblNaziv.Name = "lblNaziv";
            lblNaziv.Size = new Size(49, 18);
            lblNaziv.TabIndex = 6;
            lblNaziv.Text = "Naziv";
            // 
            // txtNaziv
            // 
            txtNaziv.Font = new Font("Verdana", 11.25F, FontStyle.Regular, GraphicsUnit.Point);
            txtNaziv.Location = new Point(247, 78);
            txtNaziv.Name = "txtNaziv";
            txtNaziv.Size = new Size(495, 26);
            txtNaziv.TabIndex = 0;
            // 
            // cmbGodina
            // 
            cmbGodina.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbGodina.FlatStyle = FlatStyle.Flat;
            cmbGodina.Font = new Font("Verdana", 11.25F, FontStyle.Regular, GraphicsUnit.Point);
            cmbGodina.FormattingEnabled = true;
            cmbGodina.Location = new Point(772, 77);
            cmbGodina.Name = "cmbGodina";
            cmbGodina.Size = new Size(151, 26);
            cmbGodina.TabIndex = 1;
            // 
            // lblGodina
            // 
            lblGodina.AutoSize = true;
            lblGodina.FlatStyle = FlatStyle.System;
            lblGodina.Font = new Font("Verdana", 11.25F, FontStyle.Regular, GraphicsUnit.Point);
            lblGodina.ForeColor = SystemColors.ControlDarkDark;
            lblGodina.Location = new Point(772, 53);
            lblGodina.Name = "lblGodina";
            lblGodina.Size = new Size(60, 18);
            lblGodina.TabIndex = 11;
            lblGodina.Text = "Godina";
            // 
            // lblTrajanje
            // 
            lblTrajanje.AutoSize = true;
            lblTrajanje.FlatStyle = FlatStyle.System;
            lblTrajanje.Font = new Font("Verdana", 11.25F, FontStyle.Regular, GraphicsUnit.Point);
            lblTrajanje.ForeColor = SystemColors.ControlDarkDark;
            lblTrajanje.Location = new Point(977, 54);
            lblTrajanje.Name = "lblTrajanje";
            lblTrajanje.Size = new Size(114, 18);
            lblTrajanje.TabIndex = 6;
            lblTrajanje.Text = "Trajanje (min)";
            // 
            // pcbSlika
            // 
            pcbSlika.BackColor = SystemColors.ControlLightLight;
            pcbSlika.Location = new Point(32, 61);
            pcbSlika.Name = "pcbSlika";
            pcbSlika.Size = new Size(191, 254);
            pcbSlika.SizeMode = PictureBoxSizeMode.StretchImage;
            pcbSlika.TabIndex = 13;
            pcbSlika.TabStop = false;
            // 
            // btnOdaberi
            // 
            btnOdaberi.Font = new Font("Verdana", 9.749999F, FontStyle.Regular, GraphicsUnit.Point);
            btnOdaberi.Location = new Point(32, 321);
            btnOdaberi.Name = "btnOdaberi";
            btnOdaberi.Size = new Size(191, 30);
            btnOdaberi.TabIndex = 10;
            btnOdaberi.Text = "Odaberi";
            btnOdaberi.UseVisualStyleBackColor = true;
            btnOdaberi.Click += btnOdaberi_Click;
            // 
            // lblStatus
            // 
            lblStatus.AutoSize = true;
            lblStatus.FlatStyle = FlatStyle.System;
            lblStatus.Font = new Font("Verdana", 11.25F, FontStyle.Regular, GraphicsUnit.Point);
            lblStatus.ForeColor = SystemColors.ControlDarkDark;
            lblStatus.Location = new Point(32, 380);
            lblStatus.Name = "lblStatus";
            lblStatus.Size = new Size(56, 18);
            lblStatus.TabIndex = 11;
            lblStatus.Text = "Status";
            // 
            // cmbStatus
            // 
            cmbStatus.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbStatus.FlatStyle = FlatStyle.Flat;
            cmbStatus.Font = new Font("Verdana", 11.25F, FontStyle.Regular, GraphicsUnit.Point);
            cmbStatus.FormattingEnabled = true;
            cmbStatus.Location = new Point(32, 404);
            cmbStatus.Name = "cmbStatus";
            cmbStatus.Size = new Size(191, 26);
            cmbStatus.TabIndex = 4;
            // 
            // btnSpasi
            // 
            btnSpasi.Font = new Font("Verdana", 11.25F, FontStyle.Regular, GraphicsUnit.Point);
            btnSpasi.Location = new Point(1014, 542);
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
            lbKategorija.Font = new Font("Verdana", 11.25F, FontStyle.Regular, GraphicsUnit.Point);
            lbKategorija.FormattingEnabled = true;
            lbKategorija.ItemHeight = 18;
            lbKategorija.Location = new Point(247, 158);
            lbKategorija.Name = "lbKategorija";
            lbKategorija.SelectionMode = SelectionMode.MultiSimple;
            lbKategorija.Size = new Size(244, 112);
            lbKategorija.TabIndex = 4;
            // 
            // lbZanr
            // 
            lbZanr.Font = new Font("Verdana", 11.25F, FontStyle.Regular, GraphicsUnit.Point);
            lbZanr.FormattingEnabled = true;
            lbZanr.ItemHeight = 18;
            lbZanr.Location = new Point(534, 158);
            lbZanr.Name = "lbZanr";
            lbZanr.SelectionMode = SelectionMode.MultiSimple;
            lbZanr.Size = new Size(208, 112);
            lbZanr.TabIndex = 5;
            // 
            // lbUloge
            // 
            lbUloge.Font = new Font("Verdana", 11.25F, FontStyle.Regular, GraphicsUnit.Point);
            lbUloge.FormattingEnabled = true;
            lbUloge.ItemHeight = 18;
            lbUloge.Location = new Point(773, 158);
            lbUloge.Name = "lbUloge";
            lbUloge.SelectionMode = SelectionMode.MultiSimple;
            lbUloge.Size = new Size(334, 112);
            lbUloge.TabIndex = 6;
            // 
            // rtbOpis
            // 
            rtbOpis.Font = new Font("Verdana", 9.75F, FontStyle.Regular, GraphicsUnit.Point);
            rtbOpis.Location = new Point(248, 401);
            rtbOpis.Name = "rtbOpis";
            rtbOpis.Size = new Size(874, 106);
            rtbOpis.TabIndex = 9;
            rtbOpis.Text = "";
            // 
            // lblKategorija
            // 
            lblKategorija.AutoSize = true;
            lblKategorija.FlatStyle = FlatStyle.System;
            lblKategorija.Font = new Font("Verdana", 11.25F, FontStyle.Regular, GraphicsUnit.Point);
            lblKategorija.ForeColor = SystemColors.ControlDarkDark;
            lblKategorija.Location = new Point(248, 134);
            lblKategorija.Name = "lblKategorija";
            lblKategorija.Size = new Size(84, 18);
            lblKategorija.TabIndex = 11;
            lblKategorija.Text = "Kategorija";
            // 
            // lblZanr
            // 
            lblZanr.AutoSize = true;
            lblZanr.FlatStyle = FlatStyle.System;
            lblZanr.Font = new Font("Verdana", 11.25F, FontStyle.Regular, GraphicsUnit.Point);
            lblZanr.ForeColor = SystemColors.ControlDarkDark;
            lblZanr.Location = new Point(534, 134);
            lblZanr.Name = "lblZanr";
            lblZanr.Size = new Size(42, 18);
            lblZanr.TabIndex = 11;
            lblZanr.Text = "Žanr";
            // 
            // lblUloge
            // 
            lblUloge.AutoSize = true;
            lblUloge.FlatStyle = FlatStyle.System;
            lblUloge.Font = new Font("Verdana", 11.25F, FontStyle.Regular, GraphicsUnit.Point);
            lblUloge.ForeColor = SystemColors.ControlDarkDark;
            lblUloge.Location = new Point(772, 133);
            lblUloge.Name = "lblUloge";
            lblUloge.Size = new Size(50, 18);
            lblUloge.TabIndex = 11;
            lblUloge.Text = "Uloge";
            // 
            // lbllOpis
            // 
            lbllOpis.AutoSize = true;
            lbllOpis.FlatStyle = FlatStyle.System;
            lbllOpis.Font = new Font("Verdana", 11.25F, FontStyle.Regular, GraphicsUnit.Point);
            lbllOpis.ForeColor = SystemColors.ControlDarkDark;
            lbllOpis.Location = new Point(247, 377);
            lbllOpis.Name = "lbllOpis";
            lbllOpis.Size = new Size(40, 18);
            lbllOpis.TabIndex = 11;
            lbllOpis.Text = "Opis";
            // 
            // lblTrailer
            // 
            lblTrailer.AutoSize = true;
            lblTrailer.FlatStyle = FlatStyle.System;
            lblTrailer.Font = new Font("Verdana", 11.25F, FontStyle.Regular, GraphicsUnit.Point);
            lblTrailer.ForeColor = SystemColors.ControlDarkDark;
            lblTrailer.Location = new Point(247, 298);
            lblTrailer.Name = "lblTrailer";
            lblTrailer.Size = new Size(77, 18);
            lblTrailer.TabIndex = 6;
            lblTrailer.Text = "Trailer Url";
            // 
            // txtTrailer
            // 
            txtTrailer.Font = new Font("Verdana", 9.749999F, FontStyle.Regular, GraphicsUnit.Point);
            txtTrailer.Location = new Point(247, 324);
            txtTrailer.Name = "txtTrailer";
            txtTrailer.Size = new Size(860, 23);
            txtTrailer.TabIndex = 8;
            // 
            // numTrajanje
            // 
            numTrajanje.Font = new Font("Verdana", 11.25F, FontStyle.Regular, GraphicsUnit.Point);
            numTrajanje.Location = new Point(977, 79);
            numTrajanje.Maximum = new decimal(new int[] { 500, 0, 0, 0 });
            numTrajanje.Name = "numTrajanje";
            numTrajanje.RightToLeft = RightToLeft.No;
            numTrajanje.Size = new Size(130, 26);
            numTrajanje.TabIndex = 2;
            // 
            // errorProvider
            // 
            errorProvider.ContainerControl = this;
            // 
            // lblPopularnost
            // 
            lblPopularnost.AutoSize = true;
            lblPopularnost.FlatStyle = FlatStyle.System;
            lblPopularnost.Font = new Font("Verdana", 11.25F, FontStyle.Regular, GraphicsUnit.Point);
            lblPopularnost.ForeColor = SystemColors.ControlDarkDark;
            lblPopularnost.Location = new Point(32, 457);
            lblPopularnost.Name = "lblPopularnost";
            lblPopularnost.Size = new Size(96, 18);
            lblPopularnost.TabIndex = 6;
            lblPopularnost.Text = "Popularnost";
            // 
            // numPopularnost
            // 
            numPopularnost.DecimalPlaces = 1;
            numPopularnost.Font = new Font("Verdana", 11.25F, FontStyle.Regular, GraphicsUnit.Point);
            numPopularnost.Location = new Point(32, 481);
            numPopularnost.Maximum = new decimal(new int[] { 10, 0, 0, 0 });
            numPopularnost.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            numPopularnost.Name = "numPopularnost";
            numPopularnost.RightToLeft = RightToLeft.No;
            numPopularnost.Size = new Size(191, 26);
            numPopularnost.TabIndex = 7;
            numPopularnost.Value = new decimal(new int[] { 8, 0, 0, 0 });
            // 
            // frmMovieUpsert
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1162, 620);
            Controls.Add(numPopularnost);
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
            Controls.Add(lblPopularnost);
            Controls.Add(lblGodina);
            Controls.Add(lblTrajanje);
            Controls.Add(txtTrailer);
            Controls.Add(lblTrailer);
            Controls.Add(txtNaziv);
            Controls.Add(lblNaziv);
            Name = "frmMovieUpsert";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Novi Film";
            Load += frmFilmUpsert_Load;
            ((System.ComponentModel.ISupportInitialize)pcbSlika).EndInit();
            ((System.ComponentModel.ISupportInitialize)numTrajanje).EndInit();
            ((System.ComponentModel.ISupportInitialize)errorProvider).EndInit();
            ((System.ComponentModel.ISupportInitialize)numPopularnost).EndInit();
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
        private NumericUpDown numPopularnost;
        private Label lblPopularnost;
    }
}