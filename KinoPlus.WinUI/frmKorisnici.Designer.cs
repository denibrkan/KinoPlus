namespace KinoPlus.WinUI
{
    partial class frmKorisnici
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
            dgvKorisnici = new DataGridView();
            lblPaging = new Label();
            btnNaprijed = new Button();
            btnNazad = new Button();
            txtTrazi = new TextBox();
            btnTrazi = new Button();
            ((System.ComponentModel.ISupportInitialize)dgvKorisnici).BeginInit();
            SuspendLayout();
            // 
            // dgvKorisnici
            // 
            dgvKorisnici.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dgvKorisnici.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = SystemColors.Control;
            dataGridViewCellStyle1.Font = new Font("Dubai", 9.749999F, FontStyle.Regular, GraphicsUnit.Point);
            dataGridViewCellStyle1.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = Color.IndianRed;
            dataGridViewCellStyle1.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.True;
            dgvKorisnici.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            dgvKorisnici.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = SystemColors.Window;
            dataGridViewCellStyle2.Font = new Font("Dubai", 12F, FontStyle.Regular, GraphicsUnit.Point);
            dataGridViewCellStyle2.ForeColor = SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.False;
            dgvKorisnici.DefaultCellStyle = dataGridViewCellStyle2;
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
            lblPaging.Font = new Font("Dubai", 9.749999F, FontStyle.Regular, GraphicsUnit.Point);
            lblPaging.Location = new Point(619, 714);
            lblPaging.Name = "lblPaging";
            lblPaging.Size = new Size(28, 22);
            lblPaging.TabIndex = 11;
            lblPaging.Text = "???";
            // 
            // btnNaprijed
            // 
            btnNaprijed.Anchor = AnchorStyles.Bottom;
            btnNaprijed.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
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
            btnNazad.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
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
            txtTrazi.Font = new Font("Dubai", 12F, FontStyle.Regular, GraphicsUnit.Point);
            txtTrazi.Location = new Point(91, 83);
            txtTrazi.Name = "txtTrazi";
            txtTrazi.PlaceholderText = "Traži";
            txtTrazi.Size = new Size(240, 35);
            txtTrazi.TabIndex = 13;
            // 
            // btnTrazi
            // 
            btnTrazi.Font = new Font("Dubai", 12F, FontStyle.Regular, GraphicsUnit.Point);
            btnTrazi.Location = new Point(343, 83);
            btnTrazi.Name = "btnTrazi";
            btnTrazi.Size = new Size(93, 33);
            btnTrazi.TabIndex = 14;
            btnTrazi.Text = "Pretraga";
            btnTrazi.UseVisualStyleBackColor = true;
            btnTrazi.Click += btnTrazi_Click;
            // 
            // frmKorisnici
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1275, 797);
            ControlBox = false;
            Controls.Add(txtTrazi);
            Controls.Add(btnTrazi);
            Controls.Add(lblPaging);
            Controls.Add(btnNaprijed);
            Controls.Add(btnNazad);
            Controls.Add(dgvKorisnici);
            FormBorderStyle = FormBorderStyle.None;
            Name = "frmKorisnici";
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
        private Button btnTrazi;
    }
}