namespace KinoPlus.WinUI
{
    partial class frmUsers
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
            DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle4 = new DataGridViewCellStyle();
            dgvKorisnici = new DataGridView();
            lblPaging = new Label();
            btnNaprijed = new Button();
            btnNazad = new Button();
            txtTrazi = new TextBox();
            cmbRole = new ComboBox();
            lblRole = new Label();
            btnReset = new Button();
            ((System.ComponentModel.ISupportInitialize)dgvKorisnici).BeginInit();
            SuspendLayout();
            // 
            // dgvKorisnici
            // 
            dgvKorisnici.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dgvKorisnici.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.BackColor = SystemColors.Control;
            dataGridViewCellStyle3.Font = new Font("Verdana", 9.749999F, FontStyle.Regular, GraphicsUnit.Point);
            dataGridViewCellStyle3.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = Color.IndianRed;
            dataGridViewCellStyle3.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = DataGridViewTriState.True;
            dgvKorisnici.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle3;
            dgvKorisnici.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle4.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = SystemColors.Window;
            dataGridViewCellStyle4.Font = new Font("Verdana", 11.25F, FontStyle.Regular, GraphicsUnit.Point);
            dataGridViewCellStyle4.ForeColor = SystemColors.ControlText;
            dataGridViewCellStyle4.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = DataGridViewTriState.False;
            dgvKorisnici.DefaultCellStyle = dataGridViewCellStyle4;
            dgvKorisnici.GridColor = Color.Navy;
            dgvKorisnici.Location = new Point(91, 133);
            dgvKorisnici.Name = "dgvKorisnici";
            dgvKorisnici.RowTemplate.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvKorisnici.RowTemplate.DefaultCellStyle.BackColor = Color.White;
            dgvKorisnici.RowTemplate.DefaultCellStyle.SelectionBackColor = Color.MidnightBlue;
            dgvKorisnici.RowTemplate.Height = 50;
            dgvKorisnici.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvKorisnici.Size = new Size(1072, 547);
            dgvKorisnici.TabIndex = 0;
            // 
            // lblPaging
            // 
            lblPaging.Anchor = AnchorStyles.Bottom;
            lblPaging.AutoSize = true;
            lblPaging.Font = new Font("Verdana", 9.749999F, FontStyle.Regular, GraphicsUnit.Point);
            lblPaging.Location = new Point(599, 721);
            lblPaging.Name = "lblPaging";
            lblPaging.Size = new Size(28, 16);
            lblPaging.TabIndex = 11;
            lblPaging.Text = "???";
            // 
            // btnNaprijed
            // 
            btnNaprijed.Anchor = AnchorStyles.Bottom;
            btnNaprijed.Font = new Font("Verdana", 12F, FontStyle.Regular, GraphicsUnit.Point);
            btnNaprijed.Location = new Point(697, 712);
            btnNaprijed.Name = "btnNaprijed";
            btnNaprijed.Size = new Size(75, 31);
            btnNaprijed.TabIndex = 9;
            btnNaprijed.Text = ">";
            btnNaprijed.UseVisualStyleBackColor = true;
            btnNaprijed.Click += btnNaprijed_Click;
            // 
            // btnNazad
            // 
            btnNazad.Anchor = AnchorStyles.Bottom;
            btnNazad.Font = new Font("Verdana", 12F, FontStyle.Regular, GraphicsUnit.Point);
            btnNazad.Location = new Point(505, 712);
            btnNazad.Name = "btnNazad";
            btnNazad.Size = new Size(75, 31);
            btnNazad.TabIndex = 10;
            btnNazad.Text = "<";
            btnNazad.UseVisualStyleBackColor = true;
            btnNazad.Click += btnNazad_Click;
            // 
            // txtTrazi
            // 
            txtTrazi.Font = new Font("Verdana", 11.25F, FontStyle.Regular, GraphicsUnit.Point);
            txtTrazi.Location = new Point(91, 91);
            txtTrazi.Name = "txtTrazi";
            txtTrazi.PlaceholderText = "Pretražite po imenu i prezimenu...";
            txtTrazi.Size = new Size(330, 26);
            txtTrazi.TabIndex = 13;
            txtTrazi.TextChanged += txtTrazi_TextChanged;
            // 
            // cmbRole
            // 
            cmbRole.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbRole.FlatStyle = FlatStyle.Flat;
            cmbRole.Font = new Font("Verdana", 11.25F, FontStyle.Regular, GraphicsUnit.Point);
            cmbRole.FormattingEnabled = true;
            cmbRole.Location = new Point(460, 91);
            cmbRole.Name = "cmbRole";
            cmbRole.Size = new Size(250, 26);
            cmbRole.TabIndex = 16;
            cmbRole.SelectedValueChanged += cmbRole_SelectedValueChanged;
            // 
            // lblRole
            // 
            lblRole.AutoSize = true;
            lblRole.FlatStyle = FlatStyle.System;
            lblRole.Font = new Font("Verdana", 9.749999F, FontStyle.Regular, GraphicsUnit.Point);
            lblRole.ForeColor = SystemColors.ControlDarkDark;
            lblRole.Location = new Point(460, 72);
            lblRole.Name = "lblRole";
            lblRole.Size = new Size(43, 16);
            lblRole.TabIndex = 15;
            lblRole.Text = "Uloga";
            // 
            // btnReset
            // 
            btnReset.Font = new Font("Verdana", 11.25F, FontStyle.Regular, GraphicsUnit.Point);
            btnReset.Location = new Point(735, 91);
            btnReset.Margin = new Padding(4, 3, 4, 3);
            btnReset.Name = "btnReset";
            btnReset.Size = new Size(72, 27);
            btnReset.TabIndex = 17;
            btnReset.Text = "Poništi";
            btnReset.UseVisualStyleBackColor = true;
            btnReset.Click += btnReset_Click;
            // 
            // frmUsers
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1275, 797);
            ControlBox = false;
            Controls.Add(btnReset);
            Controls.Add(cmbRole);
            Controls.Add(lblRole);
            Controls.Add(txtTrazi);
            Controls.Add(lblPaging);
            Controls.Add(btnNaprijed);
            Controls.Add(btnNazad);
            Controls.Add(dgvKorisnici);
            FormBorderStyle = FormBorderStyle.None;
            Name = "frmUsers";
            Text = "Korisnici";
            Load += frmKorisnici_Load;
            ((System.ComponentModel.ISupportInitialize)dgvKorisnici).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView dgvKorisnici;
        private Label lblPaging;
        private Button btnNaprijed;
        private Button btnNazad;
        private TextBox txtTrazi;
        private ComboBox cmbRole;
        private Label lblRole;
        private Button btnReset;
    }
}