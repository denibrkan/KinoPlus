namespace KinoPlus.WinUI
{
    partial class frmLokacijaUpsert
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
            txtNaziv = new TextBox();
            lblNaziv = new Label();
            lblAdresa = new Label();
            txtAdresa = new TextBox();
            cmbGrad = new ComboBox();
            lblGrad = new Label();
            lbDvorane = new ListBox();
            lbVrstaProjekcije = new ListBox();
            lblDvorane = new Label();
            lblVrstaProjekcije = new Label();
            btnSpasi = new Button();
            SuspendLayout();
            // 
            // txtNaziv
            // 
            txtNaziv.Font = new Font("Dubai", 12F, FontStyle.Regular, GraphicsUnit.Point);
            txtNaziv.Location = new Point(120, 141);
            txtNaziv.Name = "txtNaziv";
            txtNaziv.Size = new Size(259, 35);
            txtNaziv.TabIndex = 1;
            // 
            // lblNaziv
            // 
            lblNaziv.AutoSize = true;
            lblNaziv.Font = new Font("Dubai", 11.25F, FontStyle.Regular, GraphicsUnit.Point);
            lblNaziv.ForeColor = SystemColors.ControlDarkDark;
            lblNaziv.Location = new Point(120, 113);
            lblNaziv.Name = "lblNaziv";
            lblNaziv.Size = new Size(45, 25);
            lblNaziv.TabIndex = 8;
            lblNaziv.Text = "Naziv";
            // 
            // lblAdresa
            // 
            lblAdresa.AutoSize = true;
            lblAdresa.Font = new Font("Dubai", 11.25F, FontStyle.Regular, GraphicsUnit.Point);
            lblAdresa.ForeColor = SystemColors.ControlDarkDark;
            lblAdresa.Location = new Point(458, 113);
            lblAdresa.Name = "lblAdresa";
            lblAdresa.Size = new Size(54, 25);
            lblAdresa.TabIndex = 8;
            lblAdresa.Text = "Adresa";
            // 
            // txtAdresa
            // 
            txtAdresa.Font = new Font("Dubai", 12F, FontStyle.Regular, GraphicsUnit.Point);
            txtAdresa.Location = new Point(458, 141);
            txtAdresa.Name = "txtAdresa";
            txtAdresa.Size = new Size(259, 35);
            txtAdresa.TabIndex = 2;
            // 
            // cmbGrad
            // 
            cmbGrad.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbGrad.FlatStyle = FlatStyle.Flat;
            cmbGrad.Font = new Font("Dubai", 12F, FontStyle.Regular, GraphicsUnit.Point);
            cmbGrad.FormattingEnabled = true;
            cmbGrad.Location = new Point(809, 141);
            cmbGrad.Name = "cmbGrad";
            cmbGrad.Size = new Size(212, 35);
            cmbGrad.TabIndex = 3;
            // 
            // lblGrad
            // 
            lblGrad.AutoSize = true;
            lblGrad.Font = new Font("Dubai", 11.25F, FontStyle.Regular, GraphicsUnit.Point);
            lblGrad.ForeColor = SystemColors.ControlDarkDark;
            lblGrad.Location = new Point(809, 114);
            lblGrad.Name = "lblGrad";
            lblGrad.Size = new Size(42, 25);
            lblGrad.TabIndex = 13;
            lblGrad.Text = "Grad";
            // 
            // lbDvorane
            // 
            lbDvorane.Font = new Font("Dubai", 12F, FontStyle.Regular, GraphicsUnit.Point);
            lbDvorane.FormattingEnabled = true;
            lbDvorane.ItemHeight = 27;
            lbDvorane.Location = new Point(644, 258);
            lbDvorane.Name = "lbDvorane";
            lbDvorane.SelectionMode = SelectionMode.MultiSimple;
            lbDvorane.Size = new Size(377, 247);
            lbDvorane.TabIndex = 5;
            // 
            // lbVrstaProjekcije
            // 
            lbVrstaProjekcije.Font = new Font("Dubai", 12F, FontStyle.Regular, GraphicsUnit.Point);
            lbVrstaProjekcije.FormattingEnabled = true;
            lbVrstaProjekcije.ItemHeight = 27;
            lbVrstaProjekcije.Location = new Point(120, 258);
            lbVrstaProjekcije.Name = "lbVrstaProjekcije";
            lbVrstaProjekcije.SelectionMode = SelectionMode.MultiSimple;
            lbVrstaProjekcije.Size = new Size(377, 247);
            lbVrstaProjekcije.TabIndex = 4;
            // 
            // lblDvorane
            // 
            lblDvorane.AutoSize = true;
            lblDvorane.Font = new Font("Dubai", 11.25F, FontStyle.Regular, GraphicsUnit.Point);
            lblDvorane.ForeColor = SystemColors.ControlDarkDark;
            lblDvorane.Location = new Point(644, 230);
            lblDvorane.Name = "lblDvorane";
            lblDvorane.Size = new Size(64, 25);
            lblDvorane.TabIndex = 16;
            lblDvorane.Text = "Dvorane";
            // 
            // lblVrstaProjekcije
            // 
            lblVrstaProjekcije.AutoSize = true;
            lblVrstaProjekcije.Font = new Font("Dubai", 11.25F, FontStyle.Regular, GraphicsUnit.Point);
            lblVrstaProjekcije.ForeColor = SystemColors.ControlDarkDark;
            lblVrstaProjekcije.Location = new Point(120, 231);
            lblVrstaProjekcije.Name = "lblVrstaProjekcije";
            lblVrstaProjekcije.Size = new Size(105, 25);
            lblVrstaProjekcije.TabIndex = 18;
            lblVrstaProjekcije.Text = "Vrsta projekcije";
            // 
            // btnSpasi
            // 
            btnSpasi.Anchor = AnchorStyles.Bottom;
            btnSpasi.Font = new Font("Dubai", 12F, FontStyle.Regular, GraphicsUnit.Point);
            btnSpasi.Location = new Point(554, 636);
            btnSpasi.Name = "btnSpasi";
            btnSpasi.Size = new Size(108, 35);
            btnSpasi.TabIndex = 6;
            btnSpasi.Text = "Spasi";
            btnSpasi.UseVisualStyleBackColor = true;
            btnSpasi.Click += btnSpasi_Click;
            // 
            // frmLokacijaUpsert
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1213, 742);
            Controls.Add(btnSpasi);
            Controls.Add(lbDvorane);
            Controls.Add(lbVrstaProjekcije);
            Controls.Add(lblDvorane);
            Controls.Add(lblVrstaProjekcije);
            Controls.Add(cmbGrad);
            Controls.Add(lblGrad);
            Controls.Add(txtAdresa);
            Controls.Add(lblAdresa);
            Controls.Add(txtNaziv);
            Controls.Add(lblNaziv);
            Name = "frmLokacijaUpsert";
            Text = "Nova Lokacija";
            Load += frmLokacijaUpsert_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox txtNaziv;
        private Label lblNaziv;
        private Label lblAdresa;
        private TextBox txtAdresa;
        private ComboBox cmbGrad;
        private Label lblGrad;
        private ListBox lbDvorane;
        private ListBox lbVrstaProjekcije;
        private Label lblDvorane;
        private Label lblVrstaProjekcije;
        private Button btnSpasi;
    }
}