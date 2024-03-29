﻿namespace KinoPlus.WinUI
{
    partial class frmLocations
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
            dgvLocations = new DataGridView();
            lblPaging = new Label();
            btnNaprijed = new Button();
            btnNazad = new Button();
            txtTrazi = new TextBox();
            btnDodaj = new Button();
            ((System.ComponentModel.ISupportInitialize)dgvLocations).BeginInit();
            SuspendLayout();
            // 
            // dgvLocations
            // 
            dgvLocations.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dgvLocations.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = SystemColors.Control;
            dataGridViewCellStyle1.Font = new Font("Verdana", 9.749999F, FontStyle.Regular, GraphicsUnit.Point);
            dataGridViewCellStyle1.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = Color.IndianRed;
            dataGridViewCellStyle1.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.True;
            dgvLocations.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            dgvLocations.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = SystemColors.Window;
            dataGridViewCellStyle2.Font = new Font("Verdana", 11.25F, FontStyle.Regular, GraphicsUnit.Point);
            dataGridViewCellStyle2.ForeColor = SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.False;
            dgvLocations.DefaultCellStyle = dataGridViewCellStyle2;
            dgvLocations.GridColor = Color.Navy;
            dgvLocations.Location = new Point(91, 133);
            dgvLocations.Name = "dgvLocations";
            dgvLocations.RowTemplate.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvLocations.RowTemplate.DefaultCellStyle.BackColor = Color.White;
            dgvLocations.RowTemplate.DefaultCellStyle.SelectionBackColor = Color.MidnightBlue;
            dgvLocations.RowTemplate.Height = 50;
            dgvLocations.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvLocations.Size = new Size(1072, 547);
            dgvLocations.TabIndex = 0;
            dgvLocations.CellDoubleClick += dgvLocations_CellDoubleClick;
            // 
            // lblPaging
            // 
            lblPaging.Anchor = AnchorStyles.Bottom;
            lblPaging.AutoSize = true;
            lblPaging.Font = new Font("Verdana", 9.749999F, FontStyle.Regular, GraphicsUnit.Point);
            lblPaging.Location = new Point(599, 720);
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
            txtTrazi.Location = new Point(90, 96);
            txtTrazi.Name = "txtTrazi";
            txtTrazi.PlaceholderText = "Pretražite po nazivu...";
            txtTrazi.Size = new Size(330, 26);
            txtTrazi.TabIndex = 13;
            txtTrazi.TextChanged += txtTrazi_TextChanged;
            // 
            // btnDodaj
            // 
            btnDodaj.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnDodaj.BackColor = Color.MidnightBlue;
            btnDodaj.Font = new Font("Verdana", 12F, FontStyle.Regular, GraphicsUnit.Point);
            btnDodaj.ForeColor = Color.White;
            btnDodaj.Location = new Point(1041, 83);
            btnDodaj.Margin = new Padding(4, 3, 4, 3);
            btnDodaj.Name = "btnDodaj";
            btnDodaj.Size = new Size(122, 40);
            btnDodaj.TabIndex = 15;
            btnDodaj.Text = "Dodaj";
            btnDodaj.UseVisualStyleBackColor = false;
            btnDodaj.Click += btnDodaj_Click;
            // 
            // frmLocations
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1275, 797);
            ControlBox = false;
            Controls.Add(btnDodaj);
            Controls.Add(txtTrazi);
            Controls.Add(lblPaging);
            Controls.Add(btnNaprijed);
            Controls.Add(btnNazad);
            Controls.Add(dgvLocations);
            FormBorderStyle = FormBorderStyle.None;
            Name = "frmLocations";
            Text = "Lokacije";
            Load += frmLokacije_Load;
            ((System.ComponentModel.ISupportInitialize)dgvLocations).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView dgvLocations;
        private Label lblPaging;
        private Button btnNaprijed;
        private Button btnNazad;
        private TextBox txtTrazi;
        private Button btnDodaj;
    }
}