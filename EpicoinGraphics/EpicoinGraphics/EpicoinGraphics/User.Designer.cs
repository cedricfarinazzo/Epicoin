namespace EpicoinGraphics
{
    partial class User
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
            this.panel2 = new System.Windows.Forms.Panel();
            this.TextBoxAddress = new System.Windows.Forms.TextBox();
            this.TextBoxName = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.panel5 = new System.Windows.Forms.Panel();
            this.ToAddressTrans = new System.Windows.Forms.RichTextBox();
            this.label15 = new System.Windows.Forms.Label();
            this.AmountTrans = new System.Windows.Forms.TextBox();
            this.label16 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.SendTransaction = new System.Windows.Forms.Button();
            this.panel3 = new System.Windows.Forms.Panel();
            this.ChainLastHash = new System.Windows.Forms.RichTextBox();
            this.ChainLastIndex = new System.Windows.Forms.TextBox();
            this.ChainDifficulty = new System.Windows.Forms.TextBox();
            this.ChainLenght = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.EpicoinAmount = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.RefreshChainStats = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel5.SuspendLayout();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(2, 2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1029, 40);
            this.panel1.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(485, 7);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(61, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Epicoin";
            // 
            // panel2
            // 
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.label5);
            this.panel2.Controls.Add(this.EpicoinAmount);
            this.panel2.Controls.Add(this.label4);
            this.panel2.Controls.Add(this.TextBoxAddress);
            this.panel2.Controls.Add(this.TextBoxName);
            this.panel2.Controls.Add(this.label3);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Location = new System.Drawing.Point(2, 48);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1029, 84);
            this.panel2.TabIndex = 3;
            // 
            // TextBoxAddress
            // 
            this.TextBoxAddress.Location = new System.Drawing.Point(204, 48);
            this.TextBoxAddress.Name = "TextBoxAddress";
            this.TextBoxAddress.ReadOnly = true;
            this.TextBoxAddress.Size = new System.Drawing.Size(813, 26);
            this.TextBoxAddress.TabIndex = 3;
            this.TextBoxAddress.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
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
            // panel5
            // 
            this.panel5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel5.Controls.Add(this.ToAddressTrans);
            this.panel5.Controls.Add(this.label15);
            this.panel5.Controls.Add(this.AmountTrans);
            this.panel5.Controls.Add(this.label16);
            this.panel5.Controls.Add(this.label17);
            this.panel5.Controls.Add(this.SendTransaction);
            this.panel5.Location = new System.Drawing.Point(2, 138);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(509, 367);
            this.panel5.TabIndex = 19;
            // 
            // ToAddressTrans
            // 
            this.ToAddressTrans.Location = new System.Drawing.Point(16, 124);
            this.ToAddressTrans.Name = "ToAddressTrans";
            this.ToAddressTrans.Size = new System.Drawing.Size(481, 158);
            this.ToAddressTrans.TabIndex = 18;
            this.ToAddressTrans.Text = "";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(91, 12);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(92, 20);
            this.label15.TabIndex = 17;
            this.label15.Text = "Transaction";
            this.label15.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // AmountTrans
            // 
            this.AmountTrans.Location = new System.Drawing.Point(95, 58);
            this.AmountTrans.Name = "AmountTrans";
            this.AmountTrans.Size = new System.Drawing.Size(113, 26);
            this.AmountTrans.TabIndex = 16;
            this.AmountTrans.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(12, 58);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(77, 20);
            this.label16.TabIndex = 3;
            this.label16.Text = "Amount : ";
            this.label16.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(12, 101);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(102, 20);
            this.label17.TabIndex = 2;
            this.label17.Text = "To Address : ";
            this.label17.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // SendTransaction
            // 
            this.SendTransaction.Location = new System.Drawing.Point(285, 56);
            this.SendTransaction.Name = "SendTransaction";
            this.SendTransaction.Size = new System.Drawing.Size(182, 51);
            this.SendTransaction.TabIndex = 1;
            this.SendTransaction.Text = "Send";
            this.SendTransaction.UseVisualStyleBackColor = true;
            // 
            // panel3
            // 
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel3.Controls.Add(this.RefreshChainStats);
            this.panel3.Controls.Add(this.ChainLastHash);
            this.panel3.Controls.Add(this.ChainLastIndex);
            this.panel3.Controls.Add(this.ChainDifficulty);
            this.panel3.Controls.Add(this.ChainLenght);
            this.panel3.Controls.Add(this.label12);
            this.panel3.Controls.Add(this.label11);
            this.panel3.Controls.Add(this.label10);
            this.panel3.Controls.Add(this.label9);
            this.panel3.Controls.Add(this.label7);
            this.panel3.Location = new System.Drawing.Point(517, 138);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(503, 367);
            this.panel3.TabIndex = 20;
            // 
            // ChainLastHash
            // 
            this.ChainLastHash.BackColor = System.Drawing.SystemColors.Control;
            this.ChainLastHash.Location = new System.Drawing.Point(17, 250);
            this.ChainLastHash.Name = "ChainLastHash";
            this.ChainLastHash.ReadOnly = true;
            this.ChainLastHash.Size = new System.Drawing.Size(471, 65);
            this.ChainLastHash.TabIndex = 15;
            this.ChainLastHash.Text = "";
            // 
            // ChainLastIndex
            // 
            this.ChainLastIndex.Location = new System.Drawing.Point(162, 124);
            this.ChainLastIndex.Name = "ChainLastIndex";
            this.ChainLastIndex.ReadOnly = true;
            this.ChainLastIndex.Size = new System.Drawing.Size(183, 26);
            this.ChainLastIndex.TabIndex = 12;
            this.ChainLastIndex.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // ChainDifficulty
            // 
            this.ChainDifficulty.Location = new System.Drawing.Point(104, 171);
            this.ChainDifficulty.Name = "ChainDifficulty";
            this.ChainDifficulty.ReadOnly = true;
            this.ChainDifficulty.Size = new System.Drawing.Size(241, 26);
            this.ChainDifficulty.TabIndex = 11;
            this.ChainDifficulty.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // ChainLenght
            // 
            this.ChainLenght.Location = new System.Drawing.Point(131, 71);
            this.ChainLenght.Name = "ChainLenght";
            this.ChainLenght.ReadOnly = true;
            this.ChainLenght.Size = new System.Drawing.Size(214, 26);
            this.ChainLenght.TabIndex = 10;
            this.ChainLenght.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(13, 215);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(137, 20);
            this.label12.TabIndex = 5;
            this.label12.Text = "Last Block Hash : ";
            this.label12.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(14, 124);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(138, 20);
            this.label11.TabIndex = 4;
            this.label11.Text = "Last Block Index : ";
            this.label11.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(14, 174);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(81, 20);
            this.label10.TabIndex = 3;
            this.label10.Text = "Difficulty : ";
            this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(15, 71);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(110, 20);
            this.label9.TabIndex = 2;
            this.label9.Text = "Chain lenght : ";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.label9.Click += new System.EventHandler(this.label9_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(192, 7);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(86, 20);
            this.label7.TabIndex = 0;
            this.label7.Text = "Blockchain";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(451, 13);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(77, 20);
            this.label4.TabIndex = 4;
            this.label4.Text = "Amount : ";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // EpicoinAmount
            // 
            this.EpicoinAmount.Location = new System.Drawing.Point(532, 10);
            this.EpicoinAmount.Name = "EpicoinAmount";
            this.EpicoinAmount.ReadOnly = true;
            this.EpicoinAmount.Size = new System.Drawing.Size(237, 26);
            this.EpicoinAmount.TabIndex = 5;
            this.EpicoinAmount.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(775, 13);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(61, 20);
            this.label5.TabIndex = 6;
            this.label5.Text = "Epicoin";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // RefreshChainStats
            // 
            this.RefreshChainStats.Location = new System.Drawing.Point(22, 12);
            this.RefreshChainStats.Name = "RefreshChainStats";
            this.RefreshChainStats.Size = new System.Drawing.Size(128, 30);
            this.RefreshChainStats.TabIndex = 16;
            this.RefreshChainStats.Text = "Refresh";
            this.RefreshChainStats.UseVisualStyleBackColor = true;
            // 
            // User
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1030, 509);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel5);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Name = "User";
            this.Text = "Epicoin User";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel5.ResumeLayout(false);
            this.panel5.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.TextBox TextBoxAddress;
        private System.Windows.Forms.TextBox TextBoxName;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.RichTextBox ToAddressTrans;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.TextBox AmountTrans;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Button SendTransaction;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.RichTextBox ChainLastHash;
        private System.Windows.Forms.TextBox ChainLastIndex;
        private System.Windows.Forms.TextBox ChainDifficulty;
        private System.Windows.Forms.TextBox ChainLenght;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox EpicoinAmount;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button RefreshChainStats;
    }
}