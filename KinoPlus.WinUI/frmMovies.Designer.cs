﻿namespace KinoPlus.WinUI
{
    partial class frmMovies
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
            btnReset = new Button();
            ((System.ComponentModel.ISupportInitialize)dgvMovies).BeginInit();
            SuspendLayout();
            // 
            // dgvMovies
            // 
            dgvMovies.AllowUserToOrderColumns = true;
            dgvMovies.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dgvMovies.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewCellStyle4.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle4.BackColor = SystemColors.Control;
            dataGridViewCellStyle4.Font = new Font("Verdana", 9.749999F, FontStyle.Regular, GraphicsUnit.Point);
            dataGridViewCellStyle4.ForeColor = SystemColors.WindowFrame;
            dataGridViewCellStyle4.SelectionBackColor = Color.MidnightBlue;
            dataGridViewCellStyle4.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = DataGridViewTriState.True;
            dgvMovies.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle4;
            dgvMovies.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle5.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle5.BackColor = SystemColors.Window;
            dataGridViewCellStyle5.Font = new Font("Verdana", 11F, FontStyle.Regular, GraphicsUnit.Point);
            dataGridViewCellStyle5.ForeColor = SystemColors.ControlText;
            dataGridViewCellStyle5.SelectionBackColor = Color.MidnightBlue;
            dataGridViewCellStyle5.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = DataGridViewTriState.False;
            dgvMovies.DefaultCellStyle = dataGridViewCellStyle5;
            dgvMovies.GridColor = Color.MidnightBlue;
            dgvMovies.Location = new Point(94, 157);
            dgvMovies.Margin = new Padding(0);
            dgvMovies.Name = "dgvMovies";
            dataGridViewCellStyle6.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = SystemColors.Control;
            dataGridViewCellStyle6.Font = new Font("Verdana", 9F, FontStyle.Regular, GraphicsUnit.Point);
            dataGridViewCellStyle6.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle6.SelectionBackColor = Color.MidnightBlue;
            dataGridViewCellStyle6.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle6.WrapMode = DataGridViewTriState.True;
            dgvMovies.RowHeadersDefaultCellStyle = dataGridViewCellStyle6;
            dgvMovies.RowHeadersWidth = 62;
            dgvMovies.RowTemplate.Height = 65;
            dgvMovies.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvMovies.Size = new Size(1113, 575);
            dgvMovies.TabIndex = 7;
            dgvMovies.CellDoubleClick += dgvMovies_CellDoubleClick;
            // 
            // btnDodaj
            // 
            btnDodaj.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnDodaj.BackColor = Color.MidnightBlue;
            btnDodaj.Font = new Font("Verdana", 12F, FontStyle.Regular, GraphicsUnit.Point);
            btnDodaj.ForeColor = Color.White;
            btnDodaj.Location = new Point(1085, 110);
            btnDodaj.Margin = new Padding(4, 3, 4, 3);
            btnDodaj.Name = "btnDodaj";
            btnDodaj.Size = new Size(122, 35);
            btnDodaj.TabIndex = 4;
            btnDodaj.Text = "Dodaj";
            btnDodaj.UseVisualStyleBackColor = false;
            btnDodaj.Click += btnDodaj_Click;
            // 
            // lblStatus
            // 
            lblStatus.AutoSize = true;
            lblStatus.FlatStyle = FlatStyle.System;
            lblStatus.Font = new Font("Verdana", 9.749999F, FontStyle.Regular, GraphicsUnit.Point);
            lblStatus.ForeColor = SystemColors.ControlDarkDark;
            lblStatus.Location = new Point(448, 96);
            lblStatus.Name = "lblStatus";
            lblStatus.Size = new Size(51, 16);
            lblStatus.TabIndex = 8;
            lblStatus.Text = "Status";
            // 
            // cmbStatus
            // 
            cmbStatus.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbStatus.FlatStyle = FlatStyle.Flat;
            cmbStatus.Font = new Font("Verdana", 11.25F, FontStyle.Regular, GraphicsUnit.Point);
            cmbStatus.FormattingEnabled = true;
            cmbStatus.Location = new Point(448, 115);
            cmbStatus.Name = "cmbStatus";
            cmbStatus.Size = new Size(250, 26);
            cmbStatus.TabIndex = 1;
            cmbStatus.SelectedValueChanged += cmbStatus_SelectedValueChanged;
            // 
            // btnNazad
            // 
            btnNazad.Anchor = AnchorStyles.Bottom;
            btnNazad.Font = new Font("Verdana", 12F, FontStyle.Regular, GraphicsUnit.Point);
            btnNazad.Location = new Point(538, 752);
            btnNazad.Name = "btnNazad";
            btnNazad.Size = new Size(75, 31);
            btnNazad.TabIndex = 5;
            btnNazad.Text = "<";
            btnNazad.UseVisualStyleBackColor = true;
            btnNazad.Click += btnNazad_Click;
            // 
            // btnNaprijed
            // 
            btnNaprijed.Anchor = AnchorStyles.Bottom;
            btnNaprijed.Font = new Font("Verdana", 12F, FontStyle.Regular, GraphicsUnit.Point);
            btnNaprijed.Location = new Point(717, 752);
            btnNaprijed.Name = "btnNaprijed";
            btnNaprijed.Size = new Size(75, 31);
            btnNaprijed.TabIndex = 6;
            btnNaprijed.Text = ">";
            btnNaprijed.UseVisualStyleBackColor = true;
            btnNaprijed.Click += btnNaprijed_Click;
            // 
            // lblPaging
            // 
            lblPaging.Anchor = AnchorStyles.Bottom;
            lblPaging.AutoSize = true;
            lblPaging.Font = new Font("Verdana", 9.749999F, FontStyle.Regular, GraphicsUnit.Point);
            lblPaging.Location = new Point(631, 761);
            lblPaging.Name = "lblPaging";
            lblPaging.Size = new Size(28, 16);
            lblPaging.TabIndex = 10;
            lblPaging.Text = "???";
            // 
            // txtTrazi
            // 
            txtTrazi.Font = new Font("Verdana", 11.25F, FontStyle.Regular, GraphicsUnit.Point);
            txtTrazi.Location = new Point(94, 115);
            txtTrazi.Name = "txtTrazi";
            txtTrazi.PlaceholderText = "Pretražite po naslovu...";
            txtTrazi.Size = new Size(330, 26);
            txtTrazi.TabIndex = 0;
            txtTrazi.TextChanged += txtTrazi_TextChanged;
            // 
            // lblKategorija
            // 
            lblKategorija.AutoSize = true;
            lblKategorija.FlatStyle = FlatStyle.System;
            lblKategorija.Font = new Font("Verdana", 9.749999F, FontStyle.Regular, GraphicsUnit.Point);
            lblKategorija.ForeColor = SystemColors.ControlDarkDark;
            lblKategorija.Location = new Point(717, 96);
            lblKategorija.Name = "lblKategorija";
            lblKategorija.Size = new Size(73, 16);
            lblKategorija.TabIndex = 9;
            lblKategorija.Text = "Kategorija";
            // 
            // cmbKategorija
            // 
            cmbKategorija.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            cmbKategorija.AutoCompleteSource = AutoCompleteSource.ListItems;
            cmbKategorija.BackColor = SystemColors.Window;
            cmbKategorija.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbKategorija.FlatStyle = FlatStyle.Flat;
            cmbKategorija.Font = new Font("Verdana", 11.25F, FontStyle.Regular, GraphicsUnit.Point);
            cmbKategorija.FormattingEnabled = true;
            cmbKategorija.Location = new Point(717, 115);
            cmbKategorija.Name = "cmbKategorija";
            cmbKategorija.Size = new Size(250, 26);
            cmbKategorija.TabIndex = 2;
            cmbKategorija.SelectedValueChanged += cmbKategorija_SelectedValueChanged;
            // 
            // btnReset
            // 
            btnReset.Font = new Font("Verdana", 11.25F, FontStyle.Regular, GraphicsUnit.Point);
            btnReset.Location = new Point(987, 115);
            btnReset.Margin = new Padding(4, 3, 4, 3);
            btnReset.Name = "btnReset";
            btnReset.Size = new Size(72, 27);
            btnReset.TabIndex = 3;
            btnReset.Text = "Poništi";
            btnReset.UseVisualStyleBackColor = true;
            btnReset.Click += btnReset_Click;
            // 
            // frmMovies
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1327, 848);
            ControlBox = false;
            Controls.Add(txtTrazi);
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
            Name = "frmMovies";
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
        private Button btnReset;
    }
}