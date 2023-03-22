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
            filmoviToolStripMenuItem = new ToolStripMenuItem();
            none = new ToolStripMenuItem();
            korisniciToolStripMenuItem = new ToolStripMenuItem();
            menuStrip.SuspendLayout();
            SuspendLayout();
            // 
            // menuStrip
            // 
            menuStrip.Font = new Font("Dubai Medium", 12F, FontStyle.Regular, GraphicsUnit.Point);
            menuStrip.Items.AddRange(new ToolStripItem[] { filmoviToolStripMenuItem, none, korisniciToolStripMenuItem });
            menuStrip.Location = new Point(0, 0);
            menuStrip.Name = "menuStrip";
            menuStrip.Padding = new Padding(20, 2, 0, 2);
            menuStrip.Size = new Size(1584, 35);
            menuStrip.TabIndex = 0;
            menuStrip.Text = "menuStrip1";
            menuStrip.ItemClicked += menuStrip_ItemClicked;
            // 
            // filmoviToolStripMenuItem
            // 
            filmoviToolStripMenuItem.Name = "filmoviToolStripMenuItem";
            filmoviToolStripMenuItem.Padding = new Padding(20, 0, 20, 0);
            filmoviToolStripMenuItem.Size = new Size(104, 31);
            filmoviToolStripMenuItem.Text = "Filmovi";
            filmoviToolStripMenuItem.Click += filmoviToolStripMenuItem_Click;
            // 
            // none
            // 
            none.Name = "none";
            none.Padding = new Padding(20, 0, 20, 0);
            none.Size = new Size(126, 31);
            none.Text = "Kategorije";
            none.Click += kategorijeToolStripMenuItem_Click;
            // 
            // korisniciToolStripMenuItem
            // 
            korisniciToolStripMenuItem.Name = "korisniciToolStripMenuItem";
            korisniciToolStripMenuItem.Padding = new Padding(20, 0, 20, 0);
            korisniciToolStripMenuItem.Size = new Size(114, 31);
            korisniciToolStripMenuItem.Text = "Korisnici";
            // 
            // frmMain
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
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
        private ToolStripMenuItem none;
        private ToolStripMenuItem korisniciToolStripMenuItem;
    }
}