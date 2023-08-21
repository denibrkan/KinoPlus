namespace KinoPlus.WinUI
{
    partial class frmProjections
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
            btnDatumNazad = new Button();
            btnDatumNaprijed = new Button();
            ((System.ComponentModel.ISupportInitialize)dgvProjections).BeginInit();
            SuspendLayout();
            // 
            // cmbLokacija
            // 
            cmbLokacija.Font = new Font("Verdana", 11.25F, FontStyle.Regular, GraphicsUnit.Point);
            cmbLokacija.FormattingEnabled = true;
            cmbLokacija.Location = new Point(479, 115);
            cmbLokacija.Name = "cmbLokacija";
            cmbLokacija.Size = new Size(187, 26);
            cmbLokacija.TabIndex = 11;
            cmbLokacija.SelectedValueChanged += cmbLokacija_SelectedValueChanged;
            // 
            // lblLokacija
            // 
            lblLokacija.AutoSize = true;
            lblLokacija.FlatStyle = FlatStyle.System;
            lblLokacija.Font = new Font("Verdana", 9.749999F, FontStyle.Regular, GraphicsUnit.Point);
            lblLokacija.ForeColor = SystemColors.ControlDarkDark;
            lblLokacija.Location = new Point(479, 96);
            lblLokacija.Name = "lblLokacija";
            lblLokacija.Size = new Size(60, 16);
            lblLokacija.TabIndex = 9;
            lblLokacija.Text = "Lokacija";
            // 
            // lblDatum
            // 
            lblDatum.AutoSize = true;
            lblDatum.FlatStyle = FlatStyle.System;
            lblDatum.Font = new Font("Verdana", 9.749999F, FontStyle.Regular, GraphicsUnit.Point);
            lblDatum.ForeColor = SystemColors.ControlDarkDark;
            lblDatum.Location = new Point(111, 96);
            lblDatum.Name = "lblDatum";
            lblDatum.Size = new Size(49, 16);
            lblDatum.TabIndex = 10;
            lblDatum.Text = "Datum";
            // 
            // dtpDatum
            // 
            dtpDatum.CalendarFont = new Font("Verdana", 10F, FontStyle.Regular, GraphicsUnit.Point);
            dtpDatum.Font = new Font("Verdana", 9.75F, FontStyle.Regular, GraphicsUnit.Point);
            dtpDatum.Location = new Point(111, 115);
            dtpDatum.MinimumSize = new Size(0, 26);
            dtpDatum.Name = "dtpDatum";
            dtpDatum.Size = new Size(256, 26);
            dtpDatum.TabIndex = 8;
            dtpDatum.ValueChanged += dtpDatum_ValueChanged;
            // 
            // btnDodaj
            // 
            btnDodaj.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnDodaj.BackColor = Color.MidnightBlue;
            btnDodaj.Font = new Font("Verdana", 12F, FontStyle.Regular, GraphicsUnit.Point);
            btnDodaj.ForeColor = Color.White;
            btnDodaj.Location = new Point(1032, 109);
            btnDodaj.Margin = new Padding(4, 3, 4, 3);
            btnDodaj.Name = "btnDodaj";
            btnDodaj.Size = new Size(122, 35);
            btnDodaj.TabIndex = 7;
            btnDodaj.Text = "Dodaj";
            btnDodaj.UseVisualStyleBackColor = false;
            btnDodaj.Click += btnDodaj_Click;
            // 
            // lblPaging
            // 
            lblPaging.Anchor = AnchorStyles.Bottom;
            lblPaging.AutoSize = true;
            lblPaging.Font = new Font("Verdana", 9.749999F, FontStyle.Regular, GraphicsUnit.Point);
            lblPaging.Location = new Point(569, 750);
            lblPaging.Name = "lblPaging";
            lblPaging.Size = new Size(28, 16);
            lblPaging.TabIndex = 15;
            lblPaging.Text = "???";
            // 
            // btnNaprijed
            // 
            btnNaprijed.Anchor = AnchorStyles.Bottom;
            btnNaprijed.BackColor = SystemColors.Control;
            btnNaprijed.Font = new Font("Verdana", 12F, FontStyle.Regular, GraphicsUnit.Point);
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
            btnNazad.Font = new Font("Verdana", 12F, FontStyle.Regular, GraphicsUnit.Point);
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
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = SystemColors.Control;
            dataGridViewCellStyle1.Font = new Font("Verdana", 9.749999F, FontStyle.Regular, GraphicsUnit.Point);
            dataGridViewCellStyle1.ForeColor = SystemColors.WindowFrame;
            dataGridViewCellStyle1.SelectionBackColor = Color.MidnightBlue;
            dataGridViewCellStyle1.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.True;
            dgvProjections.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            dgvProjections.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = SystemColors.Window;
            dataGridViewCellStyle2.Font = new Font("Verdana", 11.25F, FontStyle.Regular, GraphicsUnit.Point);
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
            dataGridViewCellStyle3.Font = new Font("Verdana", 9F, FontStyle.Regular, GraphicsUnit.Point);
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
            dgvProjections.CellDoubleClick += dgvProjections_CellDoubleClick;
            dgvProjections.CellFormatting += dgvProjections_CellFormatting;
            // 
            // btnDatumNazad
            // 
            btnDatumNazad.BackColor = Color.AliceBlue;
            btnDatumNazad.FlatStyle = FlatStyle.Flat;
            btnDatumNazad.Font = new Font("Verdana", 9.75F, FontStyle.Regular, GraphicsUnit.Point);
            btnDatumNazad.Location = new Point(72, 115);
            btnDatumNazad.Name = "btnDatumNazad";
            btnDatumNazad.Size = new Size(33, 26);
            btnDatumNazad.TabIndex = 14;
            btnDatumNazad.Text = "<";
            btnDatumNazad.UseVisualStyleBackColor = false;
            btnDatumNazad.Click += btnDatumNazad_Click;
            // 
            // btnDatumNaprijed
            // 
            btnDatumNaprijed.BackColor = Color.AliceBlue;
            btnDatumNaprijed.FlatStyle = FlatStyle.Flat;
            btnDatumNaprijed.Font = new Font("Verdana", 9.75F, FontStyle.Regular, GraphicsUnit.Point);
            btnDatumNaprijed.Location = new Point(376, 115);
            btnDatumNaprijed.Name = "btnDatumNaprijed";
            btnDatumNaprijed.Size = new Size(33, 26);
            btnDatumNaprijed.TabIndex = 14;
            btnDatumNaprijed.Text = ">";
            btnDatumNaprijed.UseVisualStyleBackColor = false;
            btnDatumNaprijed.Click += btnDatumNaprijed_Click;
            // 
            // frmProjections
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
            Name = "frmProjections";
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