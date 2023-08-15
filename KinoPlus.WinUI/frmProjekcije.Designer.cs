namespace KinoPlus.WinUI
{
    partial class frmProjekcije
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
            DataGridViewCellStyle dataGridViewCellStyle4 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle5 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle6 = new DataGridViewCellStyle();
            cmbLokacija = new ComboBox();
            lblLokacija = new Label();
            lblDatum = new Label();
            dtpDatum = new DateTimePicker();
            btnDodaj = new Button();
            lblPaging = new Label();
            btnNaprijed = new Button();
            btnNazad = new Button();
            dgvProjections = new DataGridView();
            btnDatumNazad = new Button();
            btnDatumNaprijed = new Button();
            ((System.ComponentModel.ISupportInitialize)dgvProjections).BeginInit();
            SuspendLayout();
            // 
            // cmbLokacija
            // 
            cmbLokacija.Font = new Font("Dubai", 12F, FontStyle.Regular, GraphicsUnit.Point);
            cmbLokacija.FormattingEnabled = true;
            cmbLokacija.Location = new Point(479, 106);
            cmbLokacija.Name = "cmbLokacija";
            cmbLokacija.Size = new Size(187, 35);
            cmbLokacija.TabIndex = 11;
            cmbLokacija.SelectedValueChanged += cmbLokacija_SelectedValueChanged;
            // 
            // lblLokacija
            // 
            lblLokacija.AutoSize = true;
            lblLokacija.FlatStyle = FlatStyle.System;
            lblLokacija.Font = new Font("Dubai", 9.749999F, FontStyle.Regular, GraphicsUnit.Point);
            lblLokacija.ForeColor = SystemColors.ControlDarkDark;
            lblLokacija.Location = new Point(479, 81);
            lblLokacija.Name = "lblLokacija";
            lblLokacija.Size = new Size(53, 22);
            lblLokacija.TabIndex = 9;
            lblLokacija.Text = "Lokacija";
            // 
            // lblDatum
            // 
            lblDatum.AutoSize = true;
            lblDatum.FlatStyle = FlatStyle.System;
            lblDatum.Font = new Font("Dubai", 9.749999F, FontStyle.Regular, GraphicsUnit.Point);
            lblDatum.ForeColor = SystemColors.ControlDarkDark;
            lblDatum.Location = new Point(119, 81);
            lblDatum.Name = "lblDatum";
            lblDatum.Size = new Size(47, 22);
            lblDatum.TabIndex = 10;
            lblDatum.Text = "Datum";
            // 
            // dtpDatum
            // 
            dtpDatum.CalendarFont = new Font("Dubai", 10F, FontStyle.Regular, GraphicsUnit.Point);
            dtpDatum.Font = new Font("Dubai", 12F, FontStyle.Regular, GraphicsUnit.Point);
            dtpDatum.Location = new Point(119, 105);
            dtpDatum.Name = "dtpDatum";
            dtpDatum.Size = new Size(256, 35);
            dtpDatum.TabIndex = 8;
            dtpDatum.ValueChanged += dtpDatum_ValueChanged;
            // 
            // btnDodaj
            // 
            btnDodaj.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnDodaj.BackColor = Color.MidnightBlue;
            btnDodaj.Font = new Font("Dubai", 12F, FontStyle.Regular, GraphicsUnit.Point);
            btnDodaj.ForeColor = Color.White;
            btnDodaj.Location = new Point(1032, 102);
            btnDodaj.Margin = new Padding(4, 3, 4, 3);
            btnDodaj.Name = "btnDodaj";
            btnDodaj.Size = new Size(122, 40);
            btnDodaj.TabIndex = 7;
            btnDodaj.Text = "Dodaj";
            btnDodaj.UseVisualStyleBackColor = false;
            btnDodaj.Click += btnDodaj_Click;
            // 
            // lblPaging
            // 
            lblPaging.Anchor = AnchorStyles.Bottom;
            lblPaging.AutoSize = true;
            lblPaging.Font = new Font("Dubai", 9.749999F, FontStyle.Regular, GraphicsUnit.Point);
            lblPaging.Location = new Point(580, 743);
            lblPaging.Name = "lblPaging";
            lblPaging.Size = new Size(28, 22);
            lblPaging.TabIndex = 15;
            lblPaging.Text = "???";
            // 
            // btnNaprijed
            // 
            btnNaprijed.Anchor = AnchorStyles.Bottom;
            btnNaprijed.BackColor = SystemColors.Control;
            btnNaprijed.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            btnNaprijed.Location = new Point(658, 741);
            btnNaprijed.Margin = new Padding(0);
            btnNaprijed.Name = "btnNaprijed";
            btnNaprijed.Size = new Size(75, 31);
            btnNaprijed.TabIndex = 13;
            btnNaprijed.Text = ">";
            btnNaprijed.UseVisualStyleBackColor = false;
            // 
            // btnNazad
            // 
            btnNazad.Anchor = AnchorStyles.Bottom;
            btnNazad.BackColor = SystemColors.Control;
            btnNazad.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            btnNazad.Location = new Point(479, 741);
            btnNazad.Name = "btnNazad";
            btnNazad.Size = new Size(75, 31);
            btnNazad.TabIndex = 14;
            btnNazad.Text = "<";
            btnNazad.UseVisualStyleBackColor = false;
            // 
            // dgvProjections
            // 
            dgvProjections.AllowUserToOrderColumns = true;
            dgvProjections.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dgvProjections.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewCellStyle4.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle4.BackColor = SystemColors.Control;
            dataGridViewCellStyle4.Font = new Font("Dubai", 9.749999F, FontStyle.Regular, GraphicsUnit.Point);
            dataGridViewCellStyle4.ForeColor = SystemColors.WindowFrame;
            dataGridViewCellStyle4.SelectionBackColor = Color.MidnightBlue;
            dataGridViewCellStyle4.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = DataGridViewTriState.True;
            dgvProjections.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle4;
            dgvProjections.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle5.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle5.BackColor = SystemColors.Window;
            dataGridViewCellStyle5.Font = new Font("Dubai", 12F, FontStyle.Regular, GraphicsUnit.Point);
            dataGridViewCellStyle5.ForeColor = SystemColors.ControlText;
            dataGridViewCellStyle5.SelectionBackColor = Color.MidnightBlue;
            dataGridViewCellStyle5.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = DataGridViewTriState.False;
            dgvProjections.DefaultCellStyle = dataGridViewCellStyle5;
            dgvProjections.GridColor = Color.MidnightBlue;
            dgvProjections.Location = new Point(71, 155);
            dgvProjections.Margin = new Padding(0);
            dgvProjections.Name = "dgvProjections";
            dataGridViewCellStyle6.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = SystemColors.Control;
            dataGridViewCellStyle6.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            dataGridViewCellStyle6.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle6.SelectionBackColor = Color.MidnightBlue;
            dataGridViewCellStyle6.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle6.WrapMode = DataGridViewTriState.True;
            dgvProjections.RowHeadersDefaultCellStyle = dataGridViewCellStyle6;
            dgvProjections.RowHeadersWidth = 62;
            dgvProjections.RowTemplate.Height = 65;
            dgvProjections.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvProjections.Size = new Size(1083, 568);
            dgvProjections.TabIndex = 16;
            dgvProjections.CellDoubleClick += dgvProjections_CellDoubleClick;
            // 
            // btnDatumNazad
            // 
            btnDatumNazad.BackColor = Color.AliceBlue;
            btnDatumNazad.FlatStyle = FlatStyle.Flat;
            btnDatumNazad.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            btnDatumNazad.Location = new Point(71, 105);
            btnDatumNazad.Name = "btnDatumNazad";
            btnDatumNazad.Size = new Size(40, 35);
            btnDatumNazad.TabIndex = 14;
            btnDatumNazad.Text = "<";
            btnDatumNazad.UseVisualStyleBackColor = false;
            btnDatumNazad.Click += btnDatumNazad_Click;
            // 
            // btnDatumNaprijed
            // 
            btnDatumNaprijed.BackColor = Color.AliceBlue;
            btnDatumNaprijed.FlatStyle = FlatStyle.Flat;
            btnDatumNaprijed.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            btnDatumNaprijed.Location = new Point(384, 105);
            btnDatumNaprijed.Name = "btnDatumNaprijed";
            btnDatumNaprijed.Size = new Size(40, 35);
            btnDatumNaprijed.TabIndex = 14;
            btnDatumNaprijed.Text = ">";
            btnDatumNaprijed.UseVisualStyleBackColor = false;
            btnDatumNaprijed.Click += btnDatumNaprijed_Click;
            // 
            // frmProjekcije
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1297, 835);
            ControlBox = false;
            Controls.Add(dgvProjections);
            Controls.Add(lblPaging);
            Controls.Add(btnNaprijed);
            Controls.Add(btnDatumNaprijed);
            Controls.Add(btnDatumNazad);
            Controls.Add(btnNazad);
            Controls.Add(cmbLokacija);
            Controls.Add(lblLokacija);
            Controls.Add(lblDatum);
            Controls.Add(dtpDatum);
            Controls.Add(btnDodaj);
            FormBorderStyle = FormBorderStyle.None;
            Name = "frmProjekcije";
            Text = "Projekcije";
            Load += frmProjekcije_Load;
            ((System.ComponentModel.ISupportInitialize)dgvProjections).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ComboBox cmbLokacija;
        private Label lblLokacija;
        private Label lblDatum;
        private DateTimePicker dtpDatum;
        private Button btnDodaj;
        private Label lblPaging;
        private Button btnNaprijed;
        private Button btnNazad;
        private DataGridView dgvProjections;
        private Button btnDatumNazad;
        private Button btnDatumNaprijed;
    }
}