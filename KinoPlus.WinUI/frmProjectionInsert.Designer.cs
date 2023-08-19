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
            cmbFilm.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbFilm.FlatStyle = FlatStyle.Flat;
            cmbFilm.Font = new Font("Verdana", 11.25F, FontStyle.Regular, GraphicsUnit.Point);
            cmbFilm.FormattingEnabled = true;
            cmbFilm.Location = new Point(88, 114);
            cmbFilm.Name = "cmbFilm";
            cmbFilm.Size = new Size(307, 26);
            cmbFilm.TabIndex = 1;
            cmbFilm.Validating += cmbFilm_Validating;
            // 
            // lblFilm
            // 
            lblFilm.AutoSize = true;
            lblFilm.FlatStyle = FlatStyle.System;
            lblFilm.Font = new Font("Verdana", 11.25F, FontStyle.Regular, GraphicsUnit.Point);
            lblFilm.ForeColor = SystemColors.ControlDarkDark;
            lblFilm.Location = new Point(88, 91);
            lblFilm.Name = "lblFilm";
            lblFilm.Size = new Size(38, 18);
            lblFilm.TabIndex = 13;
            lblFilm.Text = "Film";
            // 
            // lblVrstaProjekcije
            // 
            lblVrstaProjekcije.AutoSize = true;
            lblVrstaProjekcije.FlatStyle = FlatStyle.System;
            lblVrstaProjekcije.Font = new Font("Verdana", 11.25F, FontStyle.Regular, GraphicsUnit.Point);
            lblVrstaProjekcije.ForeColor = SystemColors.ControlDarkDark;
            lblVrstaProjekcije.Location = new Point(465, 91);
            lblVrstaProjekcije.Name = "lblVrstaProjekcije";
            lblVrstaProjekcije.Size = new Size(47, 18);
            lblVrstaProjekcije.TabIndex = 13;
            lblVrstaProjekcije.Text = "Vrsta";
            // 
            // cmbVrstaProjekcije
            // 
            cmbVrstaProjekcije.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbVrstaProjekcije.FlatStyle = FlatStyle.Flat;
            cmbVrstaProjekcije.Font = new Font("Verdana", 11.25F, FontStyle.Regular, GraphicsUnit.Point);
            cmbVrstaProjekcije.FormattingEnabled = true;
            cmbVrstaProjekcije.Location = new Point(466, 114);
            cmbVrstaProjekcije.Name = "cmbVrstaProjekcije";
            cmbVrstaProjekcije.Size = new Size(226, 26);
            cmbVrstaProjekcije.TabIndex = 2;
            cmbVrstaProjekcije.Validating += cmbVrstaProjekcije_Validating;
            // 
            // lblVrijeme
            // 
            lblVrijeme.AutoSize = true;
            lblVrijeme.FlatStyle = FlatStyle.System;
            lblVrijeme.Font = new Font("Verdana", 11.25F, FontStyle.Regular, GraphicsUnit.Point);
            lblVrijeme.ForeColor = SystemColors.ControlDarkDark;
            lblVrijeme.Location = new Point(769, 91);
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
            lblCijena.Location = new Point(968, 91);
            lblCijena.Name = "lblCijena";
            lblCijena.Size = new Size(54, 18);
            lblCijena.TabIndex = 13;
            lblCijena.Text = "Cijena";
            // 
            // dtpVrijeme
            // 
            dtpVrijeme.CustomFormat = "HH:mm";
            dtpVrijeme.Font = new Font("Verdana", 11.25F, FontStyle.Regular, GraphicsUnit.Point);
            dtpVrijeme.Format = DateTimePickerFormat.Custom;
            dtpVrijeme.Location = new Point(769, 114);
            dtpVrijeme.Name = "dtpVrijeme";
            dtpVrijeme.ShowUpDown = true;
            dtpVrijeme.Size = new Size(124, 26);
            dtpVrijeme.TabIndex = 3;
            // 
            // numCijena
            // 
            numCijena.DecimalPlaces = 2;
            numCijena.Font = new Font("Verdana", 11.25F, FontStyle.Regular, GraphicsUnit.Point);
            numCijena.Location = new Point(968, 114);
            numCijena.Margin = new Padding(1);
            numCijena.Name = "numCijena";
            numCijena.Size = new Size(95, 26);
            numCijena.TabIndex = 4;
            numCijena.Validating += numCijena_Validating;
            // 
            // lblLokacije
            // 
            lblLokacije.AutoSize = true;
            lblLokacije.FlatStyle = FlatStyle.System;
            lblLokacije.Font = new Font("Verdana", 11.25F, FontStyle.Regular, GraphicsUnit.Point);
            lblLokacije.ForeColor = SystemColors.ControlDarkDark;
            lblLokacije.Location = new Point(689, 233);
            lblLokacije.Name = "lblLokacije";
            lblLokacije.Size = new Size(69, 18);
            lblLokacije.TabIndex = 13;
            lblLokacije.Text = "Lokacije";
            // 
            // lblDvorane
            // 
            lblDvorane.AutoSize = true;
            lblDvorane.FlatStyle = FlatStyle.System;
            lblDvorane.Font = new Font("Verdana", 11.25F, FontStyle.Regular, GraphicsUnit.Point);
            lblDvorane.ForeColor = SystemColors.ControlDarkDark;
            lblDvorane.Location = new Point(968, 233);
            lblDvorane.Name = "lblDvorane";
            lblDvorane.Size = new Size(71, 18);
            lblDvorane.TabIndex = 13;
            lblDvorane.Text = "Dvorane";
            // 
            // btnSpasi
            // 
            btnSpasi.Anchor = AnchorStyles.None;
            btnSpasi.Font = new Font("Verdana", 12F, FontStyle.Regular, GraphicsUnit.Point);
            btnSpasi.Location = new Point(588, 678);
            btnSpasi.Name = "btnSpasi";
            btnSpasi.Size = new Size(108, 35);
            btnSpasi.TabIndex = 6;
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
            dtpDatumProjekcije.Location = new Point(88, 294);
            dtpDatumProjekcije.Name = "dtpDatumProjekcije";
            dtpDatumProjekcije.Size = new Size(197, 26);
            dtpDatumProjekcije.TabIndex = 25;
            dtpDatumProjekcije.Validating += dtpDatumProjekcije_Validating;
            // 
            // lblDatumProjekcije
            // 
            lblDatumProjekcije.AutoSize = true;
            lblDatumProjekcije.FlatStyle = FlatStyle.System;
            lblDatumProjekcije.Font = new Font("Verdana", 11.25F, FontStyle.Regular, GraphicsUnit.Point);
            lblDatumProjekcije.ForeColor = SystemColors.ControlDarkDark;
            lblDatumProjekcije.Location = new Point(88, 270);
            lblDatumProjekcije.Name = "lblDatumProjekcije";
            lblDatumProjekcije.Size = new Size(58, 18);
            lblDatumProjekcije.TabIndex = 26;
            lblDatumProjekcije.Text = "Datum";
            // 
            // cbRedovnaProjekcija
            // 
            cbRedovnaProjekcija.Font = new Font("Microsoft Sans Serif", 16F, FontStyle.Regular, GraphicsUnit.Point);
            cbRedovnaProjekcija.Location = new Point(270, 229);
            cbRedovnaProjekcija.Name = "cbRedovnaProjekcija";
            cbRedovnaProjekcija.Size = new Size(30, 30);
            cbRedovnaProjekcija.TabIndex = 24;
            cbRedovnaProjekcija.UseVisualStyleBackColor = true;
            cbRedovnaProjekcija.CheckedChanged += cbRedovnaProjekcija_CheckedChanged;
            // 
            // dtpDatumZavrsava
            // 
            dtpDatumZavrsava.Font = new Font("Verdana", 11.25F, FontStyle.Regular, GraphicsUnit.Point);
            dtpDatumZavrsava.Format = DateTimePickerFormat.Short;
            dtpDatumZavrsava.Location = new Point(335, 376);
            dtpDatumZavrsava.Name = "dtpDatumZavrsava";
            dtpDatumZavrsava.Size = new Size(197, 26);
            dtpDatumZavrsava.TabIndex = 18;
            dtpDatumZavrsava.Validating += dtpDatumZavrsava_Validating;
            // 
            // dtpDatumPocinje
            // 
            dtpDatumPocinje.Font = new Font("Verdana", 11.25F, FontStyle.Regular, GraphicsUnit.Point);
            dtpDatumPocinje.Format = DateTimePickerFormat.Short;
            dtpDatumPocinje.Location = new Point(88, 376);
            dtpDatumPocinje.Name = "dtpDatumPocinje";
            dtpDatumPocinje.Size = new Size(197, 26);
            dtpDatumPocinje.TabIndex = 19;
            dtpDatumPocinje.Validating += dtpDatumPocinje_Validating;
            // 
            // cmbDan
            // 
            cmbDan.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbDan.FlatStyle = FlatStyle.Flat;
            cmbDan.Font = new Font("Verdana", 11.25F, FontStyle.Regular, GraphicsUnit.Point);
            cmbDan.FormattingEnabled = true;
            cmbDan.Location = new Point(88, 294);
            cmbDan.Name = "cmbDan";
            cmbDan.Size = new Size(197, 26);
            cmbDan.TabIndex = 17;
            // 
            // lblDatumZavrsava
            // 
            lblDatumZavrsava.AutoSize = true;
            lblDatumZavrsava.FlatStyle = FlatStyle.System;
            lblDatumZavrsava.Font = new Font("Verdana", 11.25F, FontStyle.Regular, GraphicsUnit.Point);
            lblDatumZavrsava.ForeColor = SystemColors.ControlDarkDark;
            lblDatumZavrsava.Location = new Point(335, 352);
            lblDatumZavrsava.Name = "lblDatumZavrsava";
            lblDatumZavrsava.Size = new Size(84, 18);
            lblDatumZavrsava.TabIndex = 20;
            lblDatumZavrsava.Text = "Završava:";
            // 
            // lblDatumPocinje
            // 
            lblDatumPocinje.AutoSize = true;
            lblDatumPocinje.FlatStyle = FlatStyle.System;
            lblDatumPocinje.Font = new Font("Verdana", 11.25F, FontStyle.Regular, GraphicsUnit.Point);
            lblDatumPocinje.ForeColor = SystemColors.ControlDarkDark;
            lblDatumPocinje.Location = new Point(88, 352);
            lblDatumPocinje.Name = "lblDatumPocinje";
            lblDatumPocinje.Size = new Size(68, 18);
            lblDatumPocinje.TabIndex = 21;
            lblDatumPocinje.Text = "Počinje:";
            // 
            // lblDan
            // 
            lblDan.AutoSize = true;
            lblDan.Font = new Font("Verdana", 11.25F, FontStyle.Regular, GraphicsUnit.Point);
            lblDan.ForeColor = SystemColors.ControlDarkDark;
            lblDan.Location = new Point(88, 270);
            lblDan.Name = "lblDan";
            lblDan.Size = new Size(111, 18);
            lblDan.TabIndex = 22;
            lblDan.Text = "Dan u sedmici";
            // 
            // lblRedovnaProjekcija
            // 
            lblRedovnaProjekcija.AutoSize = true;
            lblRedovnaProjekcija.FlatStyle = FlatStyle.System;
            lblRedovnaProjekcija.Font = new Font("Verdana", 11.25F, FontStyle.Regular, GraphicsUnit.Point);
            lblRedovnaProjekcija.ForeColor = SystemColors.ControlDarkDark;
            lblRedovnaProjekcija.Location = new Point(88, 233);
            lblRedovnaProjekcija.Name = "lblRedovnaProjekcija";
            lblRedovnaProjekcija.Size = new Size(159, 18);
            lblRedovnaProjekcija.TabIndex = 23;
            lblRedovnaProjekcija.Text = "Redovna projekcija?";
            // 
            // panel
            // 
            panel.AutoScroll = true;
            panel.Location = new Point(689, 258);
            panel.Name = "panel";
            panel.Size = new Size(440, 359);
            panel.TabIndex = 27;
            // 
            // frmProjectionInsert
            // 
            AutoScaleDimensions = new SizeF(8F, 14F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1270, 776);
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