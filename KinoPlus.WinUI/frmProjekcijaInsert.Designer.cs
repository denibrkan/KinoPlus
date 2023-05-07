namespace KinoPlus.WinUI
{
    partial class frmProjekcijaInsert
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
            dtpDatumProjekcije = new DateTimePicker();
            lblDatumProjekcije = new Label();
            lblLokacije = new Label();
            lblDvorane = new Label();
            btnSpasi = new Button();
            errorProvider = new ErrorProvider(components);
            lblRedovnaProjekcija = new Label();
            cbRedovnaProjekcija = new CheckBox();
            label1 = new Label();
            cmbDan = new ComboBox();
            dtpDatumPocinje = new DateTimePicker();
            label2 = new Label();
            label3 = new Label();
            dtpDatumTrajeDo = new DateTimePicker();
            ((System.ComponentModel.ISupportInitialize)numCijena).BeginInit();
            ((System.ComponentModel.ISupportInitialize)errorProvider).BeginInit();
            SuspendLayout();
            // 
            // cmbFilm
            // 
            cmbFilm.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbFilm.FlatStyle = FlatStyle.Flat;
            cmbFilm.Font = new Font("Dubai", 12F, FontStyle.Regular, GraphicsUnit.Point);
            cmbFilm.FormattingEnabled = true;
            cmbFilm.Location = new Point(88, 114);
            cmbFilm.Name = "cmbFilm";
            cmbFilm.Size = new Size(307, 35);
            cmbFilm.TabIndex = 1;
            cmbFilm.Validating += cmbFilm_Validating;
            // 
            // lblFilm
            // 
            lblFilm.AutoSize = true;
            lblFilm.Font = new Font("Dubai", 11.25F, FontStyle.Regular, GraphicsUnit.Point);
            lblFilm.ForeColor = SystemColors.ControlDarkDark;
            lblFilm.Location = new Point(87, 87);
            lblFilm.Name = "lblFilm";
            lblFilm.Size = new Size(38, 25);
            lblFilm.TabIndex = 13;
            lblFilm.Text = "Film";
            // 
            // lblVrstaProjekcije
            // 
            lblVrstaProjekcije.AutoSize = true;
            lblVrstaProjekcije.Font = new Font("Dubai", 11.25F, FontStyle.Regular, GraphicsUnit.Point);
            lblVrstaProjekcije.ForeColor = SystemColors.ControlDarkDark;
            lblVrstaProjekcije.Location = new Point(465, 87);
            lblVrstaProjekcije.Name = "lblVrstaProjekcije";
            lblVrstaProjekcije.Size = new Size(44, 25);
            lblVrstaProjekcije.TabIndex = 13;
            lblVrstaProjekcije.Text = "Vrsta";
            // 
            // cmbVrstaProjekcije
            // 
            cmbVrstaProjekcije.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbVrstaProjekcije.FlatStyle = FlatStyle.Flat;
            cmbVrstaProjekcije.Font = new Font("Dubai", 12F, FontStyle.Regular, GraphicsUnit.Point);
            cmbVrstaProjekcije.FormattingEnabled = true;
            cmbVrstaProjekcije.Location = new Point(466, 114);
            cmbVrstaProjekcije.Name = "cmbVrstaProjekcije";
            cmbVrstaProjekcije.Size = new Size(226, 35);
            cmbVrstaProjekcije.TabIndex = 2;
            cmbVrstaProjekcije.Validating += cmbVrstaProjekcije_Validating;
            // 
            // lblVrijeme
            // 
            lblVrijeme.AutoSize = true;
            lblVrijeme.Font = new Font("Dubai", 11.25F, FontStyle.Regular, GraphicsUnit.Point);
            lblVrijeme.ForeColor = SystemColors.ControlDarkDark;
            lblVrijeme.Location = new Point(769, 87);
            lblVrijeme.Name = "lblVrijeme";
            lblVrijeme.Size = new Size(58, 25);
            lblVrijeme.TabIndex = 13;
            lblVrijeme.Text = "Vrijeme";
            // 
            // lblCijena
            // 
            lblCijena.AutoSize = true;
            lblCijena.Font = new Font("Dubai", 11.25F, FontStyle.Regular, GraphicsUnit.Point);
            lblCijena.ForeColor = SystemColors.ControlDarkDark;
            lblCijena.Location = new Point(968, 87);
            lblCijena.Name = "lblCijena";
            lblCijena.Size = new Size(49, 25);
            lblCijena.TabIndex = 13;
            lblCijena.Text = "Cijena";
            // 
            // dtpVrijeme
            // 
            dtpVrijeme.CustomFormat = "HH:mm";
            dtpVrijeme.Font = new Font("Dubai", 12F, FontStyle.Regular, GraphicsUnit.Point);
            dtpVrijeme.Format = DateTimePickerFormat.Custom;
            dtpVrijeme.Location = new Point(769, 114);
            dtpVrijeme.Name = "dtpVrijeme";
            dtpVrijeme.ShowUpDown = true;
            dtpVrijeme.Size = new Size(124, 35);
            dtpVrijeme.TabIndex = 3;
            // 
            // numCijena
            // 
            numCijena.DecimalPlaces = 2;
            numCijena.Font = new Font("Dubai", 12F, FontStyle.Regular, GraphicsUnit.Point);
            numCijena.Location = new Point(968, 114);
            numCijena.Margin = new Padding(1);
            numCijena.Name = "numCijena";
            numCijena.Size = new Size(95, 35);
            numCijena.TabIndex = 4;
            numCijena.Validating += numCijena_Validating;
            // 
            // dtpDatumProjekcije
            // 
            dtpDatumProjekcije.Enabled = false;
            dtpDatumProjekcije.Font = new Font("Dubai", 12F, FontStyle.Regular, GraphicsUnit.Point);
            dtpDatumProjekcije.Location = new Point(769, 257);
            dtpDatumProjekcije.Name = "dtpDatumProjekcije";
            dtpDatumProjekcije.Size = new Size(197, 35);
            dtpDatumProjekcije.TabIndex = 5;
            // 
            // lblDatumProjekcije
            // 
            lblDatumProjekcije.AutoSize = true;
            lblDatumProjekcije.Font = new Font("Dubai", 11.25F, FontStyle.Regular, GraphicsUnit.Point);
            lblDatumProjekcije.ForeColor = SystemColors.ControlDarkDark;
            lblDatumProjekcije.Location = new Point(769, 229);
            lblDatumProjekcije.Name = "lblDatumProjekcije";
            lblDatumProjekcije.Size = new Size(54, 25);
            lblDatumProjekcije.TabIndex = 13;
            lblDatumProjekcije.Text = "Datum";
            // 
            // lblLokacije
            // 
            lblLokacije.AutoSize = true;
            lblLokacije.Font = new Font("Dubai", 11.25F, FontStyle.Regular, GraphicsUnit.Point);
            lblLokacije.ForeColor = SystemColors.ControlDarkDark;
            lblLokacije.Location = new Point(88, 228);
            lblLokacije.Name = "lblLokacije";
            lblLokacije.Size = new Size(61, 25);
            lblLokacije.TabIndex = 13;
            lblLokacije.Text = "Lokacije";
            // 
            // lblDvorane
            // 
            lblDvorane.AutoSize = true;
            lblDvorane.Font = new Font("Dubai", 11.25F, FontStyle.Regular, GraphicsUnit.Point);
            lblDvorane.ForeColor = SystemColors.ControlDarkDark;
            lblDvorane.Location = new Point(465, 228);
            lblDvorane.Name = "lblDvorane";
            lblDvorane.Size = new Size(64, 25);
            lblDvorane.TabIndex = 13;
            lblDvorane.Text = "Dvorane";
            // 
            // btnSpasi
            // 
            btnSpasi.Anchor = AnchorStyles.None;
            btnSpasi.Font = new Font("Dubai", 12F, FontStyle.Regular, GraphicsUnit.Point);
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
            // lblRedovnaProjekcija
            // 
            lblRedovnaProjekcija.AutoSize = true;
            lblRedovnaProjekcija.Font = new Font("Dubai", 11.25F, FontStyle.Regular, GraphicsUnit.Point);
            lblRedovnaProjekcija.ForeColor = SystemColors.ControlDarkDark;
            lblRedovnaProjekcija.Location = new Point(769, 315);
            lblRedovnaProjekcija.Name = "lblRedovnaProjekcija";
            lblRedovnaProjekcija.Size = new Size(134, 25);
            lblRedovnaProjekcija.TabIndex = 13;
            lblRedovnaProjekcija.Text = "Redovna projekcija?";
            // 
            // cbRedovnaProjekcija
            // 
            cbRedovnaProjekcija.AutoSize = true;
            cbRedovnaProjekcija.Checked = true;
            cbRedovnaProjekcija.CheckState = CheckState.Checked;
            cbRedovnaProjekcija.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            cbRedovnaProjekcija.Location = new Point(951, 320);
            cbRedovnaProjekcija.Name = "cbRedovnaProjekcija";
            cbRedovnaProjekcija.Size = new Size(15, 14);
            cbRedovnaProjekcija.TabIndex = 14;
            cbRedovnaProjekcija.UseVisualStyleBackColor = true;
            cbRedovnaProjekcija.CheckedChanged += cbRedovnaProjekcija_CheckedChanged;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Dubai", 11.25F, FontStyle.Regular, GraphicsUnit.Point);
            label1.ForeColor = SystemColors.ControlDarkDark;
            label1.Location = new Point(769, 354);
            label1.Name = "label1";
            label1.Size = new Size(98, 25);
            label1.TabIndex = 13;
            label1.Text = "Dan u sedmici";
            // 
            // cmbDan
            // 
            cmbDan.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbDan.FlatStyle = FlatStyle.Flat;
            cmbDan.Font = new Font("Dubai", 12F, FontStyle.Regular, GraphicsUnit.Point);
            cmbDan.FormattingEnabled = true;
            cmbDan.Location = new Point(769, 382);
            cmbDan.Name = "cmbDan";
            cmbDan.Size = new Size(197, 35);
            cmbDan.TabIndex = 2;
            cmbDan.Validating += cmbVrstaProjekcije_Validating;
            // 
            // dtpDatumPocinje
            // 
            dtpDatumPocinje.Font = new Font("Dubai", 12F, FontStyle.Regular, GraphicsUnit.Point);
            dtpDatumPocinje.Format = DateTimePickerFormat.Short;
            dtpDatumPocinje.Location = new Point(769, 464);
            dtpDatumPocinje.Name = "dtpDatumPocinje";
            dtpDatumPocinje.Size = new Size(197, 35);
            dtpDatumPocinje.TabIndex = 5;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Dubai", 11.25F, FontStyle.Regular, GraphicsUnit.Point);
            label2.ForeColor = SystemColors.ControlDarkDark;
            label2.Location = new Point(769, 436);
            label2.Name = "label2";
            label2.Size = new Size(81, 25);
            label2.TabIndex = 13;
            label2.Text = "Počinje od:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Dubai", 11.25F, FontStyle.Regular, GraphicsUnit.Point);
            label3.ForeColor = SystemColors.ControlDarkDark;
            label3.Location = new Point(1016, 436);
            label3.Name = "label3";
            label3.Size = new Size(66, 25);
            label3.TabIndex = 13;
            label3.Text = "Traje do:";
            // 
            // dtpDatumTrajeDo
            // 
            dtpDatumTrajeDo.Font = new Font("Dubai", 12F, FontStyle.Regular, GraphicsUnit.Point);
            dtpDatumTrajeDo.Format = DateTimePickerFormat.Short;
            dtpDatumTrajeDo.Location = new Point(1016, 464);
            dtpDatumTrajeDo.Name = "dtpDatumTrajeDo";
            dtpDatumTrajeDo.Size = new Size(197, 35);
            dtpDatumTrajeDo.TabIndex = 5;
            // 
            // frmProjekcijaInsert
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1270, 776);
            Controls.Add(cbRedovnaProjekcija);
            Controls.Add(btnSpasi);
            Controls.Add(dtpDatumTrajeDo);
            Controls.Add(dtpDatumPocinje);
            Controls.Add(dtpDatumProjekcije);
            Controls.Add(numCijena);
            Controls.Add(dtpVrijeme);
            Controls.Add(cmbDan);
            Controls.Add(cmbVrstaProjekcije);
            Controls.Add(lblCijena);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(lblRedovnaProjekcija);
            Controls.Add(lblDatumProjekcije);
            Controls.Add(lblVrijeme);
            Controls.Add(lblDvorane);
            Controls.Add(lblVrstaProjekcije);
            Controls.Add(cmbFilm);
            Controls.Add(lblLokacije);
            Controls.Add(lblFilm);
            Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            Name = "frmProjekcijaInsert";
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
        private DateTimePicker dtpDatumProjekcije;
        private Label lblDatumProjekcije;
        private Label lblLokacije;
        private Label lblDvorane;
        private Button btnSpasi;
        private ErrorProvider errorProvider;
        private CheckBox cbRedovnaProjekcija;
        private Label lblRedovnaProjekcija;
        private DateTimePicker dtpDatumTrajeDo;
        private DateTimePicker dtpDatumPocinje;
        private ComboBox cmbDan;
        private Label label3;
        private Label label2;
        private Label label1;
    }
}