namespace KinoPlus.WinUI
{
    partial class frmFilmovi
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
            dgvMovies = new DataGridView();
            btnDodaj = new Button();
            dtpDatum = new DateTimePicker();
            lblDatum = new Label();
            lblLokacija = new Label();
            cmbLokacija = new ComboBox();
            ((System.ComponentModel.ISupportInitialize)dgvMovies).BeginInit();
            SuspendLayout();
            // 
            // dgvMovies
            // 
            dgvMovies.AllowUserToOrderColumns = true;
            dgvMovies.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = SystemColors.Control;
            dataGridViewCellStyle1.Font = new Font("Dubai", 9.749999F, FontStyle.Regular, GraphicsUnit.Point);
            dataGridViewCellStyle1.ForeColor = SystemColors.WindowFrame;
            dataGridViewCellStyle1.SelectionBackColor = Color.MidnightBlue;
            dataGridViewCellStyle1.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.True;
            dgvMovies.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            dgvMovies.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = SystemColors.Window;
            dataGridViewCellStyle2.Font = new Font("Dubai", 12F, FontStyle.Regular, GraphicsUnit.Point);
            dataGridViewCellStyle2.ForeColor = SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = Color.MidnightBlue;
            dataGridViewCellStyle2.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.False;
            dgvMovies.DefaultCellStyle = dataGridViewCellStyle2;
            dgvMovies.GridColor = Color.MidnightBlue;
            dgvMovies.Location = new Point(98, 166);
            dgvMovies.Margin = new Padding(0);
            dgvMovies.MinimumSize = new Size(1050, 600);
            dgvMovies.Name = "dgvMovies";
            dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = SystemColors.Control;
            dataGridViewCellStyle3.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            dataGridViewCellStyle3.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = Color.MidnightBlue;
            dataGridViewCellStyle3.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = DataGridViewTriState.True;
            dgvMovies.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            dgvMovies.RowHeadersWidth = 62;
            dgvMovies.RowTemplate.Height = 60;
            dgvMovies.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvMovies.Size = new Size(1050, 600);
            dgvMovies.TabIndex = 2;
            // 
            // btnDodaj
            // 
            btnDodaj.Font = new Font("Dubai", 12F, FontStyle.Regular, GraphicsUnit.Point);
            btnDodaj.Location = new Point(1026, 116);
            btnDodaj.Margin = new Padding(4, 3, 4, 3);
            btnDodaj.Name = "btnDodaj";
            btnDodaj.Size = new Size(122, 32);
            btnDodaj.TabIndex = 3;
            btnDodaj.Text = "Dodaj";
            btnDodaj.UseVisualStyleBackColor = true;
            // 
            // dtpDatum
            // 
            dtpDatum.CalendarFont = new Font("Dubai", 10F, FontStyle.Regular, GraphicsUnit.Point);
            dtpDatum.Font = new Font("Dubai", 10F, FontStyle.Regular, GraphicsUnit.Point);
            dtpDatum.Location = new Point(98, 118);
            dtpDatum.Name = "dtpDatum";
            dtpDatum.Size = new Size(229, 30);
            dtpDatum.TabIndex = 4;
            // 
            // lblDatum
            // 
            lblDatum.AutoSize = true;
            lblDatum.Font = new Font("Dubai", 9.749999F, FontStyle.Regular, GraphicsUnit.Point);
            lblDatum.ForeColor = SystemColors.ControlDarkDark;
            lblDatum.Location = new Point(98, 93);
            lblDatum.Name = "lblDatum";
            lblDatum.Size = new Size(47, 22);
            lblDatum.TabIndex = 5;
            lblDatum.Text = "Datum";
            // 
            // lblLokacija
            // 
            lblLokacija.AutoSize = true;
            lblLokacija.Font = new Font("Dubai", 9.749999F, FontStyle.Regular, GraphicsUnit.Point);
            lblLokacija.ForeColor = SystemColors.ControlDarkDark;
            lblLokacija.Location = new Point(418, 93);
            lblLokacija.Name = "lblLokacija";
            lblLokacija.Size = new Size(53, 22);
            lblLokacija.TabIndex = 5;
            lblLokacija.Text = "Lokacija";
            // 
            // cmbLokacija
            // 
            cmbLokacija.Font = new Font("Dubai", 10F, FontStyle.Regular, GraphicsUnit.Point);
            cmbLokacija.FormattingEnabled = true;
            cmbLokacija.Location = new Point(418, 118);
            cmbLokacija.Name = "cmbLokacija";
            cmbLokacija.Size = new Size(187, 30);
            cmbLokacija.TabIndex = 6;
            // 
            // frmFilmovi
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoSize = true;
            ClientSize = new Size(1166, 765);
            ControlBox = false;
            Controls.Add(cmbLokacija);
            Controls.Add(lblLokacija);
            Controls.Add(lblDatum);
            Controls.Add(dtpDatum);
            Controls.Add(btnDodaj);
            Controls.Add(dgvMovies);
            FormBorderStyle = FormBorderStyle.None;
            Name = "frmFilmovi";
            Text = "Filmovi";
            WindowState = FormWindowState.Maximized;
            Load += frmFilmovi_Load;
            ((System.ComponentModel.ISupportInitialize)dgvMovies).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView dgvMovies;
        private Button btnDodaj;
        private DateTimePicker dtpDatum;
        private Label lblDatum;
        private Label lblLokacija;
        private ComboBox cmbLokacija;
    }
}