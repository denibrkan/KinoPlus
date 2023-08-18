namespace KinoPlus.WinUI
{
    partial class frmKategorijaUpsert
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
            txtNaziv = new TextBox();
            lblNaziv = new Label();
            lblOrderPoeni = new Label();
            lblFilmovi = new Label();
            btnSpasi = new Button();
            numOrderPoints = new NumericUpDown();
            lbFilmovi = new ListBox();
            cbPrikazan = new CheckBox();
            lblPrikazan = new Label();
            errorProvider = new ErrorProvider(components);
            ((System.ComponentModel.ISupportInitialize)numOrderPoints).BeginInit();
            ((System.ComponentModel.ISupportInitialize)errorProvider).BeginInit();
            SuspendLayout();
            // 
            // txtNaziv
            // 
            txtNaziv.Font = new Font("Verdana", 12F, FontStyle.Regular, GraphicsUnit.Point);
            txtNaziv.Location = new Point(116, 118);
            txtNaziv.Name = "txtNaziv";
            txtNaziv.Size = new Size(359, 27);
            txtNaziv.TabIndex = 1;
            txtNaziv.Validating += txtNaziv_Validating;
            // 
            // lblNaziv
            // 
            lblNaziv.AutoSize = true;
            lblNaziv.FlatStyle = FlatStyle.System;
            lblNaziv.Font = new Font("Verdana", 11.25F, FontStyle.Regular, GraphicsUnit.Point);
            lblNaziv.ForeColor = SystemColors.ControlDarkDark;
            lblNaziv.Location = new Point(116, 90);
            lblNaziv.Name = "lblNaziv";
            lblNaziv.Size = new Size(49, 18);
            lblNaziv.TabIndex = 8;
            lblNaziv.Text = "Naziv";
            // 
            // lblOrderPoeni
            // 
            lblOrderPoeni.AutoSize = true;
            lblOrderPoeni.FlatStyle = FlatStyle.System;
            lblOrderPoeni.Font = new Font("Verdana", 11.25F, FontStyle.Regular, GraphicsUnit.Point);
            lblOrderPoeni.ForeColor = SystemColors.ControlDarkDark;
            lblOrderPoeni.Location = new Point(572, 91);
            lblOrderPoeni.Name = "lblOrderPoeni";
            lblOrderPoeni.Size = new Size(95, 18);
            lblOrderPoeni.TabIndex = 8;
            lblOrderPoeni.Text = "Order poeni";
            // 
            // lblFilmovi
            // 
            lblFilmovi.AutoSize = true;
            lblFilmovi.FlatStyle = FlatStyle.System;
            lblFilmovi.Font = new Font("Verdana", 11.25F, FontStyle.Regular, GraphicsUnit.Point);
            lblFilmovi.ForeColor = SystemColors.ControlDarkDark;
            lblFilmovi.Location = new Point(116, 208);
            lblFilmovi.Name = "lblFilmovi";
            lblFilmovi.Size = new Size(60, 18);
            lblFilmovi.TabIndex = 18;
            lblFilmovi.Text = "Filmovi";
            // 
            // btnSpasi
            // 
            btnSpasi.Anchor = AnchorStyles.Bottom;
            btnSpasi.Font = new Font("Verdana", 12F, FontStyle.Regular, GraphicsUnit.Point);
            btnSpasi.Location = new Point(467, 632);
            btnSpasi.Name = "btnSpasi";
            btnSpasi.Size = new Size(108, 35);
            btnSpasi.TabIndex = 6;
            btnSpasi.Text = "Spasi";
            btnSpasi.UseVisualStyleBackColor = true;
            btnSpasi.Click += btnSpasi_Click;
            // 
            // numOrderPoints
            // 
            numOrderPoints.Font = new Font("Verdana", 12F, FontStyle.Regular, GraphicsUnit.Point);
            numOrderPoints.Increment = new decimal(new int[] { 10, 0, 0, 0 });
            numOrderPoints.Location = new Point(572, 119);
            numOrderPoints.Maximum = new decimal(new int[] { 500, 0, 0, 0 });
            numOrderPoints.Name = "numOrderPoints";
            numOrderPoints.RightToLeft = RightToLeft.No;
            numOrderPoints.Size = new Size(130, 27);
            numOrderPoints.TabIndex = 2;
            // 
            // lbFilmovi
            // 
            lbFilmovi.Font = new Font("Verdana", 12F, FontStyle.Regular, GraphicsUnit.Point);
            lbFilmovi.FormattingEnabled = true;
            lbFilmovi.ItemHeight = 18;
            lbFilmovi.Location = new Point(116, 236);
            lbFilmovi.Name = "lbFilmovi";
            lbFilmovi.SelectionMode = SelectionMode.MultiSimple;
            lbFilmovi.Size = new Size(789, 274);
            lbFilmovi.TabIndex = 19;
            // 
            // cbPrikazan
            // 
            cbPrikazan.AutoSize = true;
            cbPrikazan.Checked = true;
            cbPrikazan.CheckState = CheckState.Checked;
            cbPrikazan.Font = new Font("Verdana", 13F, FontStyle.Regular, GraphicsUnit.Point);
            cbPrikazan.Location = new Point(771, 119);
            cbPrikazan.Name = "cbPrikazan";
            cbPrikazan.Padding = new Padding(8);
            cbPrikazan.Size = new Size(31, 30);
            cbPrikazan.TabIndex = 21;
            cbPrikazan.UseVisualStyleBackColor = true;
            // 
            // lblPrikazan
            // 
            lblPrikazan.AutoSize = true;
            lblPrikazan.FlatStyle = FlatStyle.System;
            lblPrikazan.Font = new Font("Verdana", 11.25F, FontStyle.Regular, GraphicsUnit.Point);
            lblPrikazan.ForeColor = SystemColors.ControlDarkDark;
            lblPrikazan.Location = new Point(771, 91);
            lblPrikazan.Name = "lblPrikazan";
            lblPrikazan.Size = new Size(163, 18);
            lblPrikazan.TabIndex = 20;
            lblPrikazan.Text = "Prikaži na naslovnici?";
            // 
            // errorProvider
            // 
            errorProvider.ContainerControl = this;
            // 
            // frmKategorijaUpsert
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1038, 742);
            Controls.Add(cbPrikazan);
            Controls.Add(lblPrikazan);
            Controls.Add(lbFilmovi);
            Controls.Add(numOrderPoints);
            Controls.Add(btnSpasi);
            Controls.Add(lblFilmovi);
            Controls.Add(lblOrderPoeni);
            Controls.Add(txtNaziv);
            Controls.Add(lblNaziv);
            Name = "frmKategorijaUpsert";
            Text = "Nova Kategorija";
            Load += frmKategorijaUpsert_Load;
            ((System.ComponentModel.ISupportInitialize)numOrderPoints).EndInit();
            ((System.ComponentModel.ISupportInitialize)errorProvider).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox txtNaziv;
        private Label lblNaziv;
        private Label lblOrderPoeni;
        private ListBox lbFilmovi;
        private Label lblFilmovi;
        private Button btnSpasi;
        private NumericUpDown numOrderPoints;
        private CheckBox cbPrikazan;
        private Label lblPrikazan;
        private ErrorProvider errorProvider;
    }
}