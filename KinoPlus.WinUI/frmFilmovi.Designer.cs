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
            lblStatus = new Label();
            cmbStatus = new ComboBox();
            btnNazad = new Button();
            btnNaprijed = new Button();
            lblPaging = new Label();
            txtTrazi = new TextBox();
            lblKategorija = new Label();
            cmbKategorija = new ComboBox();
            btnTrazi = new Button();
            btnReset = new Button();
            ((System.ComponentModel.ISupportInitialize)dgvMovies).BeginInit();
            SuspendLayout();
            // 
            // dgvMovies
            // 
            dgvMovies.AllowUserToOrderColumns = true;
            dgvMovies.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
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
            dgvMovies.Location = new Point(71, 157);
            dgvMovies.Margin = new Padding(0);
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
            dgvMovies.RowTemplate.Height = 65;
            dgvMovies.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvMovies.Size = new Size(1050, 575);
            dgvMovies.TabIndex = 2;
            dgvMovies.CellDoubleClick += dgvMovies_CellDoubleClick;
            // 
            // btnDodaj
            // 
            btnDodaj.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnDodaj.Font = new Font("Dubai", 12F, FontStyle.Regular, GraphicsUnit.Point);
            btnDodaj.Location = new Point(999, 107);
            btnDodaj.Margin = new Padding(4, 3, 4, 3);
            btnDodaj.Name = "btnDodaj";
            btnDodaj.Size = new Size(122, 33);
            btnDodaj.TabIndex = 3;
            btnDodaj.Text = "Dodaj";
            btnDodaj.UseVisualStyleBackColor = true;
            btnDodaj.Click += btnDodaj_Click;
            // 
            // lblStatus
            // 
            lblStatus.AutoSize = true;
            lblStatus.Font = new Font("Dubai", 9.749999F, FontStyle.Regular, GraphicsUnit.Point);
            lblStatus.ForeColor = SystemColors.ControlDarkDark;
            lblStatus.Location = new Point(461, 84);
            lblStatus.Name = "lblStatus";
            lblStatus.Size = new Size(45, 22);
            lblStatus.TabIndex = 5;
            lblStatus.Text = "Status";
            // 
            // cmbStatus
            // 
            cmbStatus.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            cmbStatus.AutoCompleteSource = AutoCompleteSource.ListItems;
            cmbStatus.Font = new Font("Dubai", 12F, FontStyle.Regular, GraphicsUnit.Point);
            cmbStatus.FormattingEnabled = true;
            cmbStatus.Location = new Point(461, 107);
            cmbStatus.Name = "cmbStatus";
            cmbStatus.Size = new Size(187, 35);
            cmbStatus.TabIndex = 6;
            cmbStatus.SelectedValueChanged += cmbStatus_SelectedValueChanged;
            // 
            // btnNazad
            // 
            btnNazad.Anchor = AnchorStyles.Bottom;
            btnNazad.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            btnNazad.Location = new Point(458, 752);
            btnNazad.Name = "btnNazad";
            btnNazad.Size = new Size(75, 31);
            btnNazad.TabIndex = 7;
            btnNazad.Text = "<";
            btnNazad.UseVisualStyleBackColor = true;
            btnNazad.Click += btnNazad_Click;
            // 
            // btnNaprijed
            // 
            btnNaprijed.Anchor = AnchorStyles.Bottom;
            btnNaprijed.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            btnNaprijed.Location = new Point(650, 752);
            btnNaprijed.Name = "btnNaprijed";
            btnNaprijed.Size = new Size(75, 31);
            btnNaprijed.TabIndex = 7;
            btnNaprijed.Text = ">";
            btnNaprijed.UseVisualStyleBackColor = true;
            btnNaprijed.Click += btnNaprijed_Click;
            // 
            // lblPaging
            // 
            lblPaging.Anchor = AnchorStyles.Bottom;
            lblPaging.AutoSize = true;
            lblPaging.Font = new Font("Dubai", 9.749999F, FontStyle.Regular, GraphicsUnit.Point);
            lblPaging.Location = new Point(572, 754);
            lblPaging.Name = "lblPaging";
            lblPaging.Size = new Size(28, 22);
            lblPaging.TabIndex = 8;
            lblPaging.Text = "???";
            // 
            // txtTrazi
            // 
            txtTrazi.Font = new Font("Dubai", 12F, FontStyle.Regular, GraphicsUnit.Point);
            txtTrazi.Location = new Point(71, 107);
            txtTrazi.Name = "txtTrazi";
            txtTrazi.PlaceholderText = "Trazi";
            txtTrazi.Size = new Size(240, 35);
            txtTrazi.TabIndex = 9;
            txtTrazi.TextChanged += txtTrazi_TextChanged;
            // 
            // lblKategorija
            // 
            lblKategorija.AutoSize = true;
            lblKategorija.Font = new Font("Dubai", 9.749999F, FontStyle.Regular, GraphicsUnit.Point);
            lblKategorija.ForeColor = SystemColors.ControlDarkDark;
            lblKategorija.Location = new Point(670, 84);
            lblKategorija.Name = "lblKategorija";
            lblKategorija.Size = new Size(65, 22);
            lblKategorija.TabIndex = 5;
            lblKategorija.Text = "Kategorija";
            // 
            // cmbKategorija
            // 
            cmbKategorija.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            cmbKategorija.AutoCompleteSource = AutoCompleteSource.ListItems;
            cmbKategorija.BackColor = SystemColors.Window;
            cmbKategorija.Font = new Font("Dubai", 12F, FontStyle.Regular, GraphicsUnit.Point);
            cmbKategorija.FormattingEnabled = true;
            cmbKategorija.Location = new Point(670, 107);
            cmbKategorija.Name = "cmbKategorija";
            cmbKategorija.Size = new Size(187, 35);
            cmbKategorija.TabIndex = 6;
            cmbKategorija.SelectedValueChanged += cmbKategorija_SelectedValueChanged;
            // 
            // btnTrazi
            // 
            btnTrazi.Font = new Font("Dubai", 12F, FontStyle.Regular, GraphicsUnit.Point);
            btnTrazi.Location = new Point(323, 107);
            btnTrazi.Name = "btnTrazi";
            btnTrazi.Size = new Size(93, 33);
            btnTrazi.TabIndex = 12;
            btnTrazi.Text = "Pretraga";
            btnTrazi.UseVisualStyleBackColor = true;
            btnTrazi.Click += btnTrazi_Click;
            // 
            // btnReset
            // 
            btnReset.Font = new Font("Dubai", 12F, FontStyle.Regular, GraphicsUnit.Point);
            btnReset.Location = new Point(880, 107);
            btnReset.Margin = new Padding(4, 3, 4, 3);
            btnReset.Name = "btnReset";
            btnReset.Size = new Size(74, 33);
            btnReset.TabIndex = 3;
            btnReset.Text = "Ponisti";
            btnReset.UseVisualStyleBackColor = true;
            btnReset.Click += btnReset_Click;
            // 
            // frmFilmovi
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1327, 848);
            ControlBox = false;
            Controls.Add(txtTrazi);
            Controls.Add(btnTrazi);
            Controls.Add(lblPaging);
            Controls.Add(btnNaprijed);
            Controls.Add(btnNazad);
            Controls.Add(cmbKategorija);
            Controls.Add(lblKategorija);
            Controls.Add(cmbStatus);
            Controls.Add(lblStatus);
            Controls.Add(btnReset);
            Controls.Add(btnDodaj);
            Controls.Add(dgvMovies);
            FormBorderStyle = FormBorderStyle.None;
            Name = "frmFilmovi";
            Text = "Filmovi";
            Load += frmFilmovi_Load;
            ((System.ComponentModel.ISupportInitialize)dgvMovies).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView dgvMovies;
        private Button btnDodaj;
        private Label lblStatus;
        private ComboBox cmbStatus;
        private Button btnNazad;
        private Button btnNaprijed;
        private Label lblPaging;
        private TextBox txtTrazi;
        private Label lblKategorija;
        private ComboBox cmbKategorija;
        private Button btnTrazi;
        private Button btnReset;
    }
}