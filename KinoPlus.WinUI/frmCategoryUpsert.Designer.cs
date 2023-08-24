namespace KinoPlus.WinUI
{
    partial class frmCategoryUpsert
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
            errorProvider = new ErrorProvider(components);
            toolTip = new ToolTip(components);
            ((System.ComponentModel.ISupportInitialize)numOrderPoints).BeginInit();
            ((System.ComponentModel.ISupportInitialize)errorProvider).BeginInit();
            SuspendLayout();
            // 
            // txtNaziv
            // 
            txtNaziv.Font = new Font("Verdana", 11.25F, FontStyle.Regular, GraphicsUnit.Point);
            txtNaziv.Location = new Point(68, 90);
            txtNaziv.Name = "txtNaziv";
            txtNaziv.Size = new Size(359, 26);
            txtNaziv.TabIndex = 1;
            // 
            // lblNaziv
            // 
            lblNaziv.AutoSize = true;
            lblNaziv.FlatStyle = FlatStyle.System;
            lblNaziv.Font = new Font("Verdana", 11.25F, FontStyle.Regular, GraphicsUnit.Point);
            lblNaziv.ForeColor = SystemColors.ControlDarkDark;
            lblNaziv.Location = new Point(68, 67);
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
            lblOrderPoeni.Location = new Point(524, 68);
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
            lblFilmovi.Location = new Point(68, 147);
            lblFilmovi.Name = "lblFilmovi";
            lblFilmovi.Size = new Size(60, 18);
            lblFilmovi.TabIndex = 18;
            lblFilmovi.Text = "Filmovi";
            // 
            // btnSpasi
            // 
            btnSpasi.Anchor = AnchorStyles.Bottom;
            btnSpasi.Font = new Font("Verdana", 12F, FontStyle.Regular, GraphicsUnit.Point);
            btnSpasi.Location = new Point(766, 487);
            btnSpasi.Name = "btnSpasi";
            btnSpasi.Size = new Size(108, 35);
            btnSpasi.TabIndex = 6;
            btnSpasi.Text = "Spasi";
            btnSpasi.UseVisualStyleBackColor = true;
            btnSpasi.Click += btnSpasi_Click;
            // 
            // numOrderPoints
            // 
            numOrderPoints.Font = new Font("Verdana", 11.25F, FontStyle.Regular, GraphicsUnit.Point);
            numOrderPoints.Increment = new decimal(new int[] { 10, 0, 0, 0 });
            numOrderPoints.Location = new Point(524, 91);
            numOrderPoints.Maximum = new decimal(new int[] { 500, 0, 0, 0 });
            numOrderPoints.Name = "numOrderPoints";
            numOrderPoints.RightToLeft = RightToLeft.No;
            numOrderPoints.Size = new Size(130, 26);
            numOrderPoints.TabIndex = 2;
            // 
            // lbFilmovi
            // 
            lbFilmovi.Font = new Font("Verdana", 11.25F, FontStyle.Regular, GraphicsUnit.Point);
            lbFilmovi.FormattingEnabled = true;
            lbFilmovi.ItemHeight = 18;
            lbFilmovi.Location = new Point(68, 170);
            lbFilmovi.Name = "lbFilmovi";
            lbFilmovi.SelectionMode = SelectionMode.MultiSimple;
            lbFilmovi.Size = new Size(806, 274);
            lbFilmovi.TabIndex = 19;
            // 
            // cbPrikazan
            // 
            cbPrikazan.AutoSize = true;
            cbPrikazan.Checked = true;
            cbPrikazan.CheckState = CheckState.Checked;
            cbPrikazan.Font = new Font("Verdana", 11.25F, FontStyle.Regular, GraphicsUnit.Point);
            cbPrikazan.Location = new Point(700, 82);
            cbPrikazan.Name = "cbPrikazan";
            cbPrikazan.Padding = new Padding(8);
            cbPrikazan.Size = new Size(198, 38);
            cbPrikazan.TabIndex = 21;
            cbPrikazan.Text = "Prikaži na naslovnici?";
            cbPrikazan.UseVisualStyleBackColor = true;
            // 
            // errorProvider
            // 
            errorProvider.ContainerControl = this;
            // 
            // frmCategoryUpsert
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(935, 547);
            Controls.Add(cbPrikazan);
            Controls.Add(lbFilmovi);
            Controls.Add(numOrderPoints);
            Controls.Add(btnSpasi);
            Controls.Add(lblFilmovi);
            Controls.Add(lblOrderPoeni);
            Controls.Add(txtNaziv);
            Controls.Add(lblNaziv);
            Name = "frmCategoryUpsert";
            StartPosition = FormStartPosition.CenterScreen;
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
        private ErrorProvider errorProvider;
        private ToolTip toolTip;
    }
}