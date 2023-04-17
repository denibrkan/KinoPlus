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
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
            cmbLokacija = new ComboBox();
            lblLokacija = new Label();
            lblDatum = new Label();
            dtpDatum = new DateTimePicker();
            btnDodaj = new Button();
            lblPaging = new Label();
            btnNaprijed = new Button();
            btnNazad = new Button();
            dgvProjections = new DataGridView();
            ((System.ComponentModel.ISupportInitialize)dgvProjections).BeginInit();
            SuspendLayout();
            // 
            // cmbLokacija
            // 
            cmbLokacija.Font = new Font("Dubai", 10F, FontStyle.Regular, GraphicsUnit.Point);
            cmbLokacija.FormattingEnabled = true;
            cmbLokacija.Location = new Point(391, 109);
            cmbLokacija.Name = "cmbLokacija";
            cmbLokacija.Size = new Size(187, 30);
            cmbLokacija.TabIndex = 11;
            cmbLokacija.SelectedValueChanged += cmbLokacija_SelectedValueChanged;
            // 
            // lblLokacija
            // 
            lblLokacija.AutoSize = true;
            lblLokacija.Font = new Font("Dubai", 9.749999F, FontStyle.Regular, GraphicsUnit.Point);
            lblLokacija.ForeColor = SystemColors.ControlDarkDark;
            lblLokacija.Location = new Point(391, 84);
            lblLokacija.Name = "lblLokacija";
            lblLokacija.Size = new Size(53, 22);
            lblLokacija.TabIndex = 9;
            lblLokacija.Text = "Lokacija";
            // 
            // lblDatum
            // 
            lblDatum.AutoSize = true;
            lblDatum.Font = new Font("Dubai", 9.749999F, FontStyle.Regular, GraphicsUnit.Point);
            lblDatum.ForeColor = SystemColors.ControlDarkDark;
            lblDatum.Location = new Point(71, 84);
            lblDatum.Name = "lblDatum";
            lblDatum.Size = new Size(47, 22);
            lblDatum.TabIndex = 10;
            lblDatum.Text = "Datum";
            // 
            // dtpDatum
            // 
            dtpDatum.CalendarFont = new Font("Dubai", 10F, FontStyle.Regular, GraphicsUnit.Point);
            dtpDatum.Font = new Font("Dubai", 10F, FontStyle.Regular, GraphicsUnit.Point);
            dtpDatum.Location = new Point(71, 109);
            dtpDatum.Name = "dtpDatum";
            dtpDatum.Size = new Size(229, 30);
            dtpDatum.TabIndex = 8;
            dtpDatum.ValueChanged += dtpDatum_ValueChanged;
            // 
            // btnDodaj
            // 
            btnDodaj.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnDodaj.Font = new Font("Dubai", 12F, FontStyle.Regular, GraphicsUnit.Point);
            btnDodaj.Location = new Point(1032, 107);
            btnDodaj.Margin = new Padding(4, 3, 4, 3);
            btnDodaj.Name = "btnDodaj";
            btnDodaj.Size = new Size(122, 32);
            btnDodaj.TabIndex = 7;
            btnDodaj.Text = "Dodaj";
            btnDodaj.UseVisualStyleBackColor = true;
            btnDodaj.Click += btnDodaj_Click;
            // 
            // lblPaging
            // 
            lblPaging.Anchor = AnchorStyles.Bottom;
            lblPaging.AutoSize = true;
            lblPaging.Font = new Font("Dubai", 9.749999F, FontStyle.Regular, GraphicsUnit.Point);
            lblPaging.Location = new Point(593, 743);
            lblPaging.Name = "lblPaging";
            lblPaging.Size = new Size(28, 22);
            lblPaging.TabIndex = 15;
            lblPaging.Text = "???";
            // 
            // btnNaprijed
            // 
            btnNaprijed.Anchor = AnchorStyles.Bottom;
            btnNaprijed.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            btnNaprijed.Location = new Point(671, 741);
            btnNaprijed.Name = "btnNaprijed";
            btnNaprijed.Size = new Size(75, 31);
            btnNaprijed.TabIndex = 13;
            btnNaprijed.Text = ">";
            btnNaprijed.UseVisualStyleBackColor = true;
            // 
            // btnNazad
            // 
            btnNazad.Anchor = AnchorStyles.Bottom;
            btnNazad.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            btnNazad.Location = new Point(479, 741);
            btnNazad.Name = "btnNazad";
            btnNazad.Size = new Size(75, 31);
            btnNazad.TabIndex = 14;
            btnNazad.Text = "<";
            btnNazad.UseVisualStyleBackColor = true;
            // 
            // dgvProjections
            // 
            dgvProjections.AllowUserToOrderColumns = true;
            dgvProjections.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dgvProjections.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvProjections.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = SystemColors.Control;
            dataGridViewCellStyle1.Font = new Font("Dubai", 9.749999F, FontStyle.Regular, GraphicsUnit.Point);
            dataGridViewCellStyle1.ForeColor = SystemColors.WindowFrame;
            dataGridViewCellStyle1.SelectionBackColor = Color.MidnightBlue;
            dataGridViewCellStyle1.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.True;
            dgvProjections.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            dgvProjections.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = SystemColors.Window;
            dataGridViewCellStyle2.Font = new Font("Dubai", 12F, FontStyle.Regular, GraphicsUnit.Point);
            dataGridViewCellStyle2.ForeColor = SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = Color.MidnightBlue;
            dataGridViewCellStyle2.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.False;
            dgvProjections.DefaultCellStyle = dataGridViewCellStyle2;
            dgvProjections.GridColor = Color.MidnightBlue;
            dgvProjections.Location = new Point(71, 155);
            dgvProjections.Margin = new Padding(0);
            dgvProjections.Name = "dgvProjections";
            dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = SystemColors.Control;
            dataGridViewCellStyle3.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            dataGridViewCellStyle3.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = Color.MidnightBlue;
            dataGridViewCellStyle3.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = DataGridViewTriState.True;
            dgvProjections.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            dgvProjections.RowHeadersWidth = 62;
            dgvProjections.RowTemplate.Height = 65;
            dgvProjections.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvProjections.Size = new Size(1083, 568);
            dgvProjections.TabIndex = 16;
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
    }
}