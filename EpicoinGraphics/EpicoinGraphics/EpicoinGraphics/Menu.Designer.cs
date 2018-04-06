using System;
using System.Windows.Forms;

namespace EpicoinGraphics
{
    partial class Menu
    {
        /// <summary>
        /// Variable nécessaire au concepteur.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Nettoyage des ressources utilisées.
        /// </summary>
        /// <param name="disposing">true si les ressources managées doivent être supprimées ; sinon, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Code généré par le Concepteur Windows Form

        /// <summary>
        /// Méthode requise pour la prise en charge du concepteur - ne modifiez pas
        /// le contenu de cette méthode avec l'éditeur de code.
        /// </summary>
        private void InitializeComponent()
        {
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.m_MinerButton = new System.Windows.Forms.Button();
            this.m_UserButton = new System.Windows.Forms.Button();
            this.m_ServeurButton = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(6, 6);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(790, 48);
            this.panel1.TabIndex = 0;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(376, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(61, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Epicoin";
            // 
            // panel2
            // 
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.m_MinerButton);
            this.panel2.Controls.Add(this.m_UserButton);
            this.panel2.Controls.Add(this.m_ServeurButton);
            this.panel2.Location = new System.Drawing.Point(6, 60);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(790, 378);
            this.panel2.TabIndex = 4;
            // 
            // m_MinerButton
            // 
            this.m_MinerButton.Location = new System.Drawing.Point(361, 288);
            this.m_MinerButton.Name = "m_MinerButton";
            this.m_MinerButton.Size = new System.Drawing.Size(101, 32);
            this.m_MinerButton.TabIndex = 3;
            this.m_MinerButton.Text = "Miner";
            this.m_MinerButton.UseVisualStyleBackColor = true;
            this.m_MinerButton.Click += new System.EventHandler(this.MinerClick);
            // 
            // m_UserButton
            // 
            this.m_UserButton.Location = new System.Drawing.Point(361, 184);
            this.m_UserButton.Name = "m_UserButton";
            this.m_UserButton.Size = new System.Drawing.Size(101, 32);
            this.m_UserButton.TabIndex = 2;
            this.m_UserButton.Text = "User";
            this.m_UserButton.UseVisualStyleBackColor = true;
            this.m_UserButton.Click += new System.EventHandler(this.UserClick);
            // 
            // m_ServeurButton
            // 
            this.m_ServeurButton.Location = new System.Drawing.Point(361, 88);
            this.m_ServeurButton.Name = "m_ServeurButton";
            this.m_ServeurButton.Size = new System.Drawing.Size(101, 32);
            this.m_ServeurButton.TabIndex = 1;
            this.m_ServeurButton.Text = "Serveur";
            this.m_ServeurButton.UseVisualStyleBackColor = true;
            this.m_ServeurButton.Click += new System.EventHandler(this.ServeurClick);
            // 
            // Menu
            // 
            this.AccessibleRole = System.Windows.Forms.AccessibleRole.TitleBar;
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Name = "Menu";
            this.Text = "EpicoinGraphics";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private void ServeurClick(object sender, EventArgs e)
        {
            this.Visible = false;
            Serveur serv = new Serveur();
            serv.ShowDialog();
        }

        private void MinerClick(object sender, EventArgs e)
        {
            this.Visible = false;
            Miner miner = new Miner();
            miner.ShowDialog();
            
        }

        private void UserClick(object sender, EventArgs e)
        {
            this.Visible = false;
            User user = new User();
            user.ShowDialog();
        }

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button m_MinerButton;
        private System.Windows.Forms.Button m_UserButton;
        private System.Windows.Forms.Button m_ServeurButton;
    }
}

