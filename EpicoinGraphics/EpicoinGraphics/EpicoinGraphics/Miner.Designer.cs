﻿namespace EpicoinGraphics
{
    partial class Miner
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.panel5 = new System.Windows.Forms.Panel();
            this.ToAddressTrans = new System.Windows.Forms.RichTextBox();
            this.label15 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.StopMiner = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.TextBoxName = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.TextBoxAddress = new System.Windows.Forms.RichTextBox();
            this.StartMiner = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.panel5.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(3, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(680, 40);
            this.panel1.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(300, 5);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(61, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Epicoin";
            // 
            // panel5
            // 
            this.panel5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel5.Controls.Add(this.StartMiner);
            this.panel5.Controls.Add(this.ToAddressTrans);
            this.panel5.Controls.Add(this.label15);
            this.panel5.Controls.Add(this.label17);
            this.panel5.Controls.Add(this.StopMiner);
            this.panel5.Location = new System.Drawing.Point(3, 178);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(680, 488);
            this.panel5.TabIndex = 19;
            // 
            // ToAddressTrans
            // 
            this.ToAddressTrans.Location = new System.Drawing.Point(16, 124);
            this.ToAddressTrans.Name = "ToAddressTrans";
            this.ToAddressTrans.Size = new System.Drawing.Size(658, 359);
            this.ToAddressTrans.TabIndex = 18;
            this.ToAddressTrans.Text = "";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(300, 11);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(48, 20);
            this.label15.TabIndex = 17;
            this.label15.Text = "Miner";
            this.label15.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(12, 101);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(52, 20);
            this.label17.TabIndex = 2;
            this.label17.Text = "Log :  ";
            this.label17.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // StopMiner
            // 
            this.StopMiner.Location = new System.Drawing.Point(364, 46);
            this.StopMiner.Name = "StopMiner";
            this.StopMiner.Size = new System.Drawing.Size(182, 51);
            this.StopMiner.TabIndex = 1;
            this.StopMiner.Text = "Stop";
            this.StopMiner.UseVisualStyleBackColor = true;
            this.StopMiner.Click += new System.EventHandler(this.SendTransaction_Click);
            // 
            // panel2
            // 
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.TextBoxAddress);
            this.panel2.Controls.Add(this.TextBoxName);
            this.panel2.Controls.Add(this.label3);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Location = new System.Drawing.Point(3, 49);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(680, 123);
            this.panel2.TabIndex = 20;
            // 
            // TextBoxName
            // 
            this.TextBoxName.Location = new System.Drawing.Point(134, 10);
            this.TextBoxName.Name = "TextBoxName";
            this.TextBoxName.ReadOnly = true;
            this.TextBoxName.Size = new System.Drawing.Size(237, 26);
            this.TextBoxName.TabIndex = 2;
            this.TextBoxName.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(14, 48);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(184, 20);
            this.label3.TabIndex = 1;
            this.label3.Text = "Votre addresse epicoin : ";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(14, 10);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(95, 20);
            this.label2.TabIndex = 0;
            this.label2.Text = "Votre nom : ";
            // 
            // TextBoxAddress
            // 
            this.TextBoxAddress.BackColor = System.Drawing.SystemColors.Control;
            this.TextBoxAddress.Location = new System.Drawing.Point(8, 71);
            this.TextBoxAddress.Name = "TextBoxAddress";
            this.TextBoxAddress.ReadOnly = true;
            this.TextBoxAddress.Size = new System.Drawing.Size(667, 47);
            this.TextBoxAddress.TabIndex = 3;
            this.TextBoxAddress.Text = "";
            // 
            // StartMiner
            // 
            this.StartMiner.Location = new System.Drawing.Point(108, 46);
            this.StartMiner.Name = "StartMiner";
            this.StartMiner.Size = new System.Drawing.Size(182, 51);
            this.StartMiner.TabIndex = 19;
            this.StartMiner.Text = "Start";
            this.StartMiner.UseVisualStyleBackColor = true;
            // 
            // Miner
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(688, 669);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel5);
            this.Controls.Add(this.panel1);
            this.Name = "Miner";
            this.Text = "Epicoin Miner";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel5.ResumeLayout(false);
            this.panel5.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.RichTextBox ToAddressTrans;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Button StopMiner;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.RichTextBox TextBoxAddress;
        private System.Windows.Forms.TextBox TextBoxName;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button StartMiner;
    }
}