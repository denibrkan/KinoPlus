namespace KinoPlus.WinUI
{
    partial class frmProjectionInsert
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
            cmbFilm = new ComboBox();
            lblFilm = new Label();
            lblVrstaProjekcije = new Label();
            cmbVrstaProjekcije = new ComboBox();
            lblVrijeme = new Label();
            lblCijena = new Label();
            dtpVrijeme = new DateTimePicker();
            numCijena = new NumericUpDown();
            lblLokacije = new Label();
            lblDvorane = new Label();
            btnSpasi = new Button();
            errorProvider = new ErrorProvider(components);
            dtpDatumProjekcije = new DateTimePicker();
            lblDatumProjekcije = new Label();
            cbRedovnaProjekcija = new CheckBox();
            dtpDatumZavrsava = new DateTimePicker();
            dtpDatumPocinje = new DateTimePicker();
            cmbDan = new ComboBox();
            lblDatumZavrsava = new Label();
            lblDatumPocinje = new Label();
            lblDan = new Label();
            lblRedovnaProjekcija = new Label();
            panel = new Panel();
            ((System.ComponentModel.ISupportInitialize)numCijena).BeginInit();
            ((System.ComponentModel.ISupportInitialize)errorProvider).BeginInit();
            SuspendLayout();
            // 
            // cmbFilm
            // 
            cmbFilm.FlatStyle = FlatStyle.Flat;
            cmbFilm.Font = new Font("Verdana", 11.25F, FontStyle.Regular, GraphicsUnit.Point);
            cmbFilm.FormattingEnabled = true;
            cmbFilm.Location = new Point(45, 82);
            cmbFilm.Name = "cmbFilm";
            cmbFilm.Size = new Size(307, 26);
            cmbFilm.TabIndex = 0;
            // 
            // lblFilm
            // 
            lblFilm.AutoSize = true;
            lblFilm.FlatStyle = FlatStyle.System;
            lblFilm.Font = new Font("Verdana", 11.25F, FontStyle.Regular, GraphicsUnit.Point);
            lblFilm.ForeColor = SystemColors.ControlDarkDark;
            lblFilm.Location = new Point(45, 57);
            lblFilm.Name = "lblFilm";
            lblFilm.Size = new Size(38, 18);
            lblFilm.TabIndex = 11;
            lblFilm.Text = "Film";
            // 
            // lblVrstaProjekcije
            // 
            lblVrstaProjekcije.AutoSize = true;
            lblVrstaProjekcije.FlatStyle = FlatStyle.System;
            lblVrstaProjekcije.Font = new Font("Verdana", 11.25F, FontStyle.Regular, GraphicsUnit.Point);
            lblVrstaProjekcije.ForeColor = SystemColors.ControlDarkDark;
            lblVrstaProjekcije.Location = new Point(414, 58);
            lblVrstaProjekcije.Name = "lblVrstaProjekcije";
            lblVrstaProjekcije.Size = new Size(125, 18);
            lblVrstaProjekcije.TabIndex = 12;
            lblVrstaProjekcije.Text = "Vrsta projekcije";
            // 
            // cmbVrstaProjekcije
            // 
            cmbVrstaProjekcije.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbVrstaProjekcije.FlatStyle = FlatStyle.Flat;
            cmbVrstaProjekcije.Font = new Font("Verdana", 11.25F, FontStyle.Regular, GraphicsUnit.Point);
            cmbVrstaProjekcije.FormattingEnabled = true;
            cmbVrstaProjekcije.Location = new Point(415, 82);
            cmbVrstaProjekcije.Name = "cmbVrstaProjekcije";
            cmbVrstaProjekcije.Size = new Size(276, 26);
            cmbVrstaProjekcije.TabIndex = 1;
            // 
            // lblVrijeme
            // 
            lblVrijeme.AutoSize = true;
            lblVrijeme.FlatStyle = FlatStyle.System;
            lblVrijeme.Font = new Font("Verdana", 11.25F, FontStyle.Regular, GraphicsUnit.Point);
            lblVrijeme.ForeColor = SystemColors.ControlDarkDark;
            lblVrijeme.Location = new Point(730, 58);
            lblVrijeme.Name = "lblVrijeme";
            lblVrijeme.Size = new Size(65, 18);
            lblVrijeme.TabIndex = 13;
            lblVrijeme.Text = "Vrijeme";
            // 
            // lblCijena
            // 
            lblCijena.AutoSize = true;
            lblCijena.FlatStyle = FlatStyle.System;
            lblCijena.Font = new Font("Verdana", 11.25F, FontStyle.Regular, GraphicsUnit.Point);
            lblCijena.ForeColor = SystemColors.ControlDarkDark;
            lblCijena.Location = new Point(893, 58);
            lblCijena.Name = "lblCijena";
            lblCijena.Size = new Size(54, 18);
            lblCijena.TabIndex = 14;
            lblCijena.Text = "Cijena";
            // 
            // dtpVrijeme
            // 
            dtpVrijeme.CustomFormat = "HH:mm";
            dtpVrijeme.Font = new Font("Verdana", 11.25F, FontStyle.Regular, GraphicsUnit.Point);
            dtpVrijeme.Format = DateTimePickerFormat.Custom;
            dtpVrijeme.Location = new Point(730, 82);
            dtpVrijeme.Name = "dtpVrijeme";
            dtpVrijeme.ShowUpDown = true;
            dtpVrijeme.Size = new Size(122, 26);
            dtpVrijeme.TabIndex = 2;
            // 
            // numCijena
            // 
            numCijena.DecimalPlaces = 2;
            numCijena.Font = new Font("Verdana", 11.25F, FontStyle.Regular, GraphicsUnit.Point);
            numCijena.Location = new Point(893, 82);
            numCijena.Margin = new Padding(1);
            numCijena.Name = "numCijena";
            numCijena.Size = new Size(95, 26);
            numCijena.TabIndex = 3;
            // 
            // lblLokacije
            // 
            lblLokacije.AutoSize = true;
            lblLokacije.FlatStyle = FlatStyle.System;
            lblLokacije.Font = new Font("Verdana", 11.25F, FontStyle.Regular, GraphicsUnit.Point);
            lblLokacije.ForeColor = SystemColors.ControlDarkDark;
            lblLokacije.Location = new Point(415, 177);
            lblLokacije.Name = "lblLokacije";
            lblLokacije.Size = new Size(69, 18);
            lblLokacije.TabIndex = 20;
            lblLokacije.Text = "Lokacije";
            // 
            // lblDvorane
            // 
            lblDvorane.AutoSize = true;
            lblDvorane.FlatStyle = FlatStyle.System;
            lblDvorane.Font = new Font("Verdana", 11.25F, FontStyle.Regular, GraphicsUnit.Point);
            lblDvorane.ForeColor = SystemColors.ControlDarkDark;
            lblDvorane.Location = new Point(730, 177);
            lblDvorane.Name = "lblDvorane";
            lblDvorane.Size = new Size(71, 18);
            lblDvorane.TabIndex = 21;
            lblDvorane.Text = "Dvorane";
            // 
            // btnSpasi
            // 
            btnSpasi.Anchor = AnchorStyles.None;
            btnSpasi.Font = new Font("Verdana", 12F, FontStyle.Regular, GraphicsUnit.Point);
            btnSpasi.Location = new Point(880, 515);
            btnSpasi.Name = "btnSpasi";
            btnSpasi.Size = new Size(108, 35);
            btnSpasi.TabIndex = 10;
            btnSpasi.Text = "Spasi";
            btnSpasi.UseVisualStyleBackColor = true;
            btnSpasi.Click += btnSpasi_Click;
            // 
            // errorProvider
            // 
            errorProvider.ContainerControl = this;
            // 
            // dtpDatumProjekcije
            // 
            dtpDatumProjekcije.Font = new Font("Verdana", 11.25F, FontStyle.Regular, GraphicsUnit.Point);
            dtpDatumProjekcije.Location = new Point(51, 247);
            dtpDatumProjekcije.Name = "dtpDatumProjekcije";
            dtpDatumProjekcije.Size = new Size(301, 26);
            dtpDatumProjekcije.TabIndex = 5;
            // 
            // lblDatumProjekcije
            // 
            lblDatumProjekcije.AutoSize = true;
            lblDatumProjekcije.FlatStyle = FlatStyle.System;
            lblDatumProjekcije.Font = new Font("Verdana", 11.25F, FontStyle.Regular, GraphicsUnit.Point);
            lblDatumProjekcije.ForeColor = SystemColors.ControlDarkDark;
            lblDatumProjekcije.Location = new Point(51, 223);
            lblDatumProjekcije.Name = "lblDatumProjekcije";
            lblDatumProjekcije.Size = new Size(58, 18);
            lblDatumProjekcije.TabIndex = 16;
            lblDatumProjekcije.Text = "Datum";
            // 
            // cbRedovnaProjekcija
            // 
            cbRedovnaProjekcija.AccessibleDescription = "Redovna projekcija kreira projekcije na svaki odabrani dan u zadanom vremenskom razdoblju";
            cbRedovnaProjekcija.Font = new Font("Microsoft Sans Serif", 16F, FontStyle.Regular, GraphicsUnit.Point);
            cbRedovnaProjekcija.Location = new Point(233, 177);
            cbRedovnaProjekcija.Name = "cbRedovnaProjekcija";
            cbRedovnaProjekcija.Size = new Size(30, 30);
            cbRedovnaProjekcija.TabIndex = 4;
            cbRedovnaProjekcija.UseVisualStyleBackColor = true;
            cbRedovnaProjekcija.CheckedChanged += cbRedovnaProjekcija_CheckedChanged;
            // 
            // dtpDatumZavrsava
            // 
            dtpDatumZavrsava.Font = new Font("Verdana", 11.25F, FontStyle.Regular, GraphicsUnit.Point);
            dtpDatumZavrsava.Format = DateTimePickerFormat.Short;
            dtpDatumZavrsava.Location = new Point(51, 397);
            dtpDatumZavrsava.Name = "dtpDatumZavrsava";
            dtpDatumZavrsava.Size = new Size(301, 26);
            dtpDatumZavrsava.TabIndex = 8;
            // 
            // dtpDatumPocinje
            // 
            dtpDatumPocinje.Font = new Font("Verdana", 11.25F, FontStyle.Regular, GraphicsUnit.Point);
            dtpDatumPocinje.Format = DateTimePickerFormat.Short;
            dtpDatumPocinje.Location = new Point(51, 319);
            dtpDatumPocinje.Name = "dtpDatumPocinje";
            dtpDatumPocinje.Size = new Size(301, 26);
            dtpDatumPocinje.TabIndex = 7;
            // 
            // cmbDan
            // 
            cmbDan.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbDan.FlatStyle = FlatStyle.Flat;
            cmbDan.Font = new Font("Verdana", 11.25F, FontStyle.Regular, GraphicsUnit.Point);
            cmbDan.FormattingEnabled = true;
            cmbDan.Location = new Point(51, 247);
            cmbDan.Name = "cmbDan";
            cmbDan.Size = new Size(301, 26);
            cmbDan.TabIndex = 6;
            // 
            // lblDatumZavrsava
            // 
            lblDatumZavrsava.AutoSize = true;
            lblDatumZavrsava.FlatStyle = FlatStyle.System;
            lblDatumZavrsava.Font = new Font("Verdana", 11.25F, FontStyle.Regular, GraphicsUnit.Point);
            lblDatumZavrsava.ForeColor = SystemColors.ControlDarkDark;
            lblDatumZavrsava.Location = new Point(51, 373);
            lblDatumZavrsava.Name = "lblDatumZavrsava";
            lblDatumZavrsava.Size = new Size(84, 18);
            lblDatumZavrsava.TabIndex = 19;
            lblDatumZavrsava.Text = "Završava:";
            // 
            // lblDatumPocinje
            // 
            lblDatumPocinje.AutoSize = true;
            lblDatumPocinje.FlatStyle = FlatStyle.System;
            lblDatumPocinje.Font = new Font("Verdana", 11.25F, FontStyle.Regular, GraphicsUnit.Point);
            lblDatumPocinje.ForeColor = SystemColors.ControlDarkDark;
            lblDatumPocinje.Location = new Point(51, 295);
            lblDatumPocinje.Name = "lblDatumPocinje";
            lblDatumPocinje.Size = new Size(68, 18);
            lblDatumPocinje.TabIndex = 18;
            lblDatumPocinje.Text = "Počinje:";
            // 
            // lblDan
            // 
            lblDan.AutoSize = true;
            lblDan.Font = new Font("Verdana", 11.25F, FontStyle.Regular, GraphicsUnit.Point);
            lblDan.ForeColor = SystemColors.ControlDarkDark;
            lblDan.Location = new Point(51, 223);
            lblDan.Name = "lblDan";
            lblDan.Size = new Size(111, 18);
            lblDan.TabIndex = 17;
            lblDan.Text = "Dan u sedmici";
            // 
            // lblRedovnaProjekcija
            // 
            lblRedovnaProjekcija.AutoSize = true;
            lblRedovnaProjekcija.FlatStyle = FlatStyle.System;
            lblRedovnaProjekcija.Font = new Font("Verdana", 11.25F, FontStyle.Regular, GraphicsUnit.Point);
            lblRedovnaProjekcija.ForeColor = SystemColors.ControlDarkDark;
            lblRedovnaProjekcija.Location = new Point(51, 180);
            lblRedovnaProjekcija.Name = "lblRedovnaProjekcija";
            lblRedovnaProjekcija.Size = new Size(159, 18);
            lblRedovnaProjekcija.TabIndex = 15;
            lblRedovnaProjekcija.Text = "Redovna projekcija?";
            // 
            // panel
            // 
            panel.AutoScroll = true;
            panel.Location = new Point(415, 206);
            panel.Name = "panel";
            panel.Size = new Size(573, 282);
            panel.TabIndex = 9;
            // 
            // frmProjectionInsert
            // 
            AutoScaleDimensions = new SizeF(8F, 14F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.Control;
            ClientSize = new Size(1031, 571);
            Controls.Add(lblDvorane);
            Controls.Add(lblLokacije);
            Controls.Add(panel);
            Controls.Add(dtpDatumProjekcije);
            Controls.Add(lblDatumProjekcije);
            Controls.Add(cbRedovnaProjekcija);
            Controls.Add(dtpDatumZavrsava);
            Controls.Add(dtpDatumPocinje);
            Controls.Add(cmbDan);
            Controls.Add(lblDatumZavrsava);
            Controls.Add(lblDatumPocinje);
            Controls.Add(lblDan);
            Controls.Add(lblRedovnaProjekcija);
            Controls.Add(btnSpasi);
            Controls.Add(numCijena);
            Controls.Add(dtpVrijeme);
            Controls.Add(cmbVrstaProjekcije);
            Controls.Add(lblCijena);
            Controls.Add(lblVrijeme);
            Controls.Add(lblVrstaProjekcije);
            Controls.Add(cmbFilm);
            Controls.Add(lblFilm);
            Font = new Font("Verdana", 9F, FontStyle.Regular, GraphicsUnit.Point);
            Name = "frmProjectionInsert";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Nova Projekcija";
            Load += frmProjekcijaInsert_Load;
            ((System.ComponentModel.ISupportInitialize)numCijena).EndInit();
            ((System.ComponentModel.ISupportInitialize)errorProvider).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ComboBox cmbFilm;
        private Label lblFilm;
        private Label lblVrstaProjekcije;
        private ComboBox cmbVrstaProjekcije;
        private Label lblVrijeme;
        private Label lblCijena;
        private DateTimePicker dtpVrijeme;
        private NumericUpDown numCijena;
        private Label lblLokacije;
        private Label lblDvorane;
        private Button btnSpasi;
        private ErrorProvider errorProvider;
        private DateTimePicker dtpDatumProjekcije;
        private Label lblDatumProjekcije;
        private CheckBox cbRedovnaProjekcija;
        private DateTimePicker dtpDatumZavrsava;
        private DateTimePicker dtpDatumPocinje;
        private ComboBox cmbDan;
        private Label lblDatumZavrsava;
        private Label lblDatumPocinje;
        private Label lblDan;
        private Label lblRedovnaProjekcija;
        private Panel panel;
    }
}