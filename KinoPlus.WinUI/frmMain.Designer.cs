namespace KinoPlus.WinUI
{
    partial class frmMain
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
            menuStrip = new MenuStrip();
            projekcijeToolStripMenuItem = new ToolStripMenuItem();
            filmoviToolStripMenuItem = new ToolStripMenuItem();
            kategorijeToolStripMenuItem = new ToolStripMenuItem();
            korisniciToolStripMenuItem = new ToolStripMenuItem();
            menuStrip.SuspendLayout();
            SuspendLayout();
            // 
            // menuStrip
            // 
            menuStrip.Font = new Font("Dubai Medium", 12F, FontStyle.Regular, GraphicsUnit.Point);
            menuStrip.Items.AddRange(new ToolStripItem[] { projekcijeToolStripMenuItem, filmoviToolStripMenuItem, kategorijeToolStripMenuItem, korisniciToolStripMenuItem });
            menuStrip.Location = new Point(0, 0);
            menuStrip.Margin = new Padding(0, 20, 0, 20);
            menuStrip.Name = "menuStrip";
            menuStrip.Padding = new Padding(40, 0, 0, 0);
            menuStrip.Size = new Size(1584, 51);
            menuStrip.TabIndex = 0;
            menuStrip.Text = "menuStrip1";
            menuStrip.ItemClicked += menuStrip_ItemClicked;
            // 
            // projekcijeToolStripMenuItem
            // 
            projekcijeToolStripMenuItem.Name = "projekcijeToolStripMenuItem";
            projekcijeToolStripMenuItem.Padding = new Padding(20, 10, 20, 10);
            projekcijeToolStripMenuItem.Size = new Size(122, 51);
            projekcijeToolStripMenuItem.Text = "Projekcije";
            projekcijeToolStripMenuItem.Click += projekcijeToolStripMenuItem_Click;
            // 
            // filmoviToolStripMenuItem
            // 
            filmoviToolStripMenuItem.Name = "filmoviToolStripMenuItem";
            filmoviToolStripMenuItem.Padding = new Padding(20, 10, 20, 10);
            filmoviToolStripMenuItem.Size = new Size(104, 51);
            filmoviToolStripMenuItem.Text = "Filmovi";
            filmoviToolStripMenuItem.Click += filmoviToolStripMenuItem_Click;
            // 
            // kategorijeToolStripMenuItem
            // 
            kategorijeToolStripMenuItem.Name = "kategorijeToolStripMenuItem";
            kategorijeToolStripMenuItem.Padding = new Padding(20, 10, 20, 10);
            kategorijeToolStripMenuItem.Size = new Size(126, 51);
            kategorijeToolStripMenuItem.Text = "Kategorije";
            kategorijeToolStripMenuItem.Click += kategorijeToolStripMenuItem_Click;
            // 
            // korisniciToolStripMenuItem
            // 
            korisniciToolStripMenuItem.Name = "korisniciToolStripMenuItem";
            korisniciToolStripMenuItem.Padding = new Padding(20, 10, 20, 10);
            korisniciToolStripMenuItem.Size = new Size(114, 51);
            korisniciToolStripMenuItem.Text = "Korisnici";
            // 
            // frmMain
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoSize = true;
            ClientSize = new Size(1584, 705);
            Controls.Add(menuStrip);
            Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            IsMdiContainer = true;
            MainMenuStrip = menuStrip;
            Margin = new Padding(4, 3, 4, 3);
            Name = "frmMain";
            Text = "KinoPlus";
            WindowState = FormWindowState.Maximized;
            Load += frmMain_Load;
            menuStrip.ResumeLayout(false);
            menuStrip.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private MenuStrip menuStrip;
        private ToolStripMenuItem filmoviToolStripMenuItem;
        private ToolStripMenuItem kategorijeToolStripMenuItem;
        private ToolStripMenuItem korisniciToolStripMenuItem;
        private ToolStripMenuItem projekcijeToolStripMenuItem;
    }
}