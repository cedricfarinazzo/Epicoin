namespace EpicoinGraphics
{
    partial class Serveur
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
            this.components = new System.ComponentModel.Container();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label19 = new System.Windows.Forms.Label();
            this.EpicoinAmount = new System.Windows.Forms.TextBox();
            this.label18 = new System.Windows.Forms.Label();
            this.TextBoxAddress = new System.Windows.Forms.TextBox();
            this.TextBoxName = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.ChainLastHash = new System.Windows.Forms.RichTextBox();
            this.ChainPending = new System.Windows.Forms.TextBox();
            this.ChainLastIndex = new System.Windows.Forms.TextBox();
            this.ChainDifficulty = new System.Windows.Forms.TextBox();
            this.ChainLenght = new System.Windows.Forms.TextBox();
            this.ChainIsValid = new System.Windows.Forms.TextBox();
            this.NextBlockBar = new System.Windows.Forms.ProgressBar();
            this.label14 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.panel4 = new System.Windows.Forms.Panel();
            this.ServeurTransStatus = new System.Windows.Forms.TextBox();
            this.ServeurMinerStatus = new System.Windows.Forms.TextBox();
            this.ServeurDataStatus = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.StopServeur = new System.Windows.Forms.Button();
            this.StartServeur = new System.Windows.Forms.Button();
            this.panel5 = new System.Windows.Forms.Panel();
            this.label20 = new System.Windows.Forms.Label();
            this.TransactionLog = new System.Windows.Forms.TextBox();
            this.ToAddressTrans = new System.Windows.Forms.RichTextBox();
            this.label15 = new System.Windows.Forms.Label();
            this.AmountTrans = new System.Windows.Forms.TextBox();
            this.label16 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.SendTransaction = new System.Windows.Forms.Button();
            this.timerAmount = new System.Windows.Forms.Timer(this.components);
            this.timerServeur = new System.Windows.Forms.Timer(this.components);
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel4.SuspendLayout();
            this.panel5.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(-2, 1);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1029, 40);
            this.panel1.TabIndex = 1;
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
            this.panel2.Controls.Add(this.label19);
            this.panel2.Controls.Add(this.EpicoinAmount);
            this.panel2.Controls.Add(this.label18);
            this.panel2.Controls.Add(this.TextBoxAddress);
            this.panel2.Controls.Add(this.TextBoxName);
            this.panel2.Controls.Add(this.label3);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Location = new System.Drawing.Point(-2, 47);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1029, 84);
            this.panel2.TabIndex = 2;
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(801, 16);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(61, 20);
            this.label19.TabIndex = 7;
            this.label19.Text = "Epicoin";
            this.label19.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // EpicoinAmount
            // 
            this.EpicoinAmount.Location = new System.Drawing.Point(552, 13);
            this.EpicoinAmount.Name = "EpicoinAmount";
            this.EpicoinAmount.ReadOnly = true;
            this.EpicoinAmount.Size = new System.Drawing.Size(237, 26);
            this.EpicoinAmount.TabIndex = 6;
            this.EpicoinAmount.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(469, 16);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(77, 20);
            this.label18.TabIndex = 5;
            this.label18.Text = "Amount : ";
            this.label18.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
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
            // panel3
            // 
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel3.Controls.Add(this.ChainLastHash);
            this.panel3.Controls.Add(this.ChainPending);
            this.panel3.Controls.Add(this.ChainLastIndex);
            this.panel3.Controls.Add(this.ChainDifficulty);
            this.panel3.Controls.Add(this.ChainLenght);
            this.panel3.Controls.Add(this.ChainIsValid);
            this.panel3.Controls.Add(this.NextBlockBar);
            this.panel3.Controls.Add(this.label14);
            this.panel3.Controls.Add(this.label13);
            this.panel3.Controls.Add(this.label12);
            this.panel3.Controls.Add(this.label11);
            this.panel3.Controls.Add(this.label10);
            this.panel3.Controls.Add(this.label9);
            this.panel3.Controls.Add(this.label8);
            this.panel3.Controls.Add(this.label7);
            this.panel3.Location = new System.Drawing.Point(-2, 137);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(514, 504);
            this.panel3.TabIndex = 3;
            this.panel3.Paint += new System.Windows.Forms.PaintEventHandler(this.panel3_Paint);
            // 
            // ChainLastHash
            // 
            this.ChainLastHash.BackColor = System.Drawing.SystemColors.Control;
            this.ChainLastHash.Location = new System.Drawing.Point(17, 250);
            this.ChainLastHash.Name = "ChainLastHash";
            this.ChainLastHash.ReadOnly = true;
            this.ChainLastHash.Size = new System.Drawing.Size(481, 65);
            this.ChainLastHash.TabIndex = 15;
            this.ChainLastHash.Text = "";
            // 
            // ChainPending
            // 
            this.ChainPending.Location = new System.Drawing.Point(194, 351);
            this.ChainPending.Name = "ChainPending";
            this.ChainPending.ReadOnly = true;
            this.ChainPending.Size = new System.Drawing.Size(148, 26);
            this.ChainPending.TabIndex = 14;
            this.ChainPending.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // ChainLastIndex
            // 
            this.ChainLastIndex.Location = new System.Drawing.Point(159, 144);
            this.ChainLastIndex.Name = "ChainLastIndex";
            this.ChainLastIndex.ReadOnly = true;
            this.ChainLastIndex.Size = new System.Drawing.Size(183, 26);
            this.ChainLastIndex.TabIndex = 12;
            this.ChainLastIndex.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // ChainDifficulty
            // 
            this.ChainDifficulty.Location = new System.Drawing.Point(101, 183);
            this.ChainDifficulty.Name = "ChainDifficulty";
            this.ChainDifficulty.ReadOnly = true;
            this.ChainDifficulty.Size = new System.Drawing.Size(241, 26);
            this.ChainDifficulty.TabIndex = 11;
            this.ChainDifficulty.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.ChainDifficulty.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // ChainLenght
            // 
            this.ChainLenght.Location = new System.Drawing.Point(128, 104);
            this.ChainLenght.Name = "ChainLenght";
            this.ChainLenght.ReadOnly = true;
            this.ChainLenght.Size = new System.Drawing.Size(214, 26);
            this.ChainLenght.TabIndex = 10;
            this.ChainLenght.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // ChainIsValid
            // 
            this.ChainIsValid.Location = new System.Drawing.Point(101, 59);
            this.ChainIsValid.Name = "ChainIsValid";
            this.ChainIsValid.ReadOnly = true;
            this.ChainIsValid.Size = new System.Drawing.Size(241, 26);
            this.ChainIsValid.TabIndex = 9;
            this.ChainIsValid.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // NextBlockBar
            // 
            this.NextBlockBar.Location = new System.Drawing.Point(14, 435);
            this.NextBlockBar.Name = "NextBlockBar";
            this.NextBlockBar.Size = new System.Drawing.Size(484, 27);
            this.NextBlockBar.TabIndex = 8;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(14, 396);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(163, 20);
            this.label14.TabIndex = 7;
            this.label14.Text = "Next Block Progress : ";
            this.label14.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(14, 354);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(174, 20);
            this.label13.TabIndex = 6;
            this.label13.Text = "Pending Transactions : ";
            this.label13.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(10, 227);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(137, 20);
            this.label12.TabIndex = 5;
            this.label12.Text = "Last Block Hash : ";
            this.label12.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(15, 144);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(138, 20);
            this.label11.TabIndex = 4;
            this.label11.Text = "Last Block Index : ";
            this.label11.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(14, 183);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(81, 20);
            this.label10.TabIndex = 3;
            this.label10.Text = "Difficulty : ";
            this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.label10.Click += new System.EventHandler(this.label10_Click);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(13, 104);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(110, 20);
            this.label9.TabIndex = 2;
            this.label9.Text = "Chain lenght : ";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(15, 59);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(69, 20);
            this.label8.TabIndex = 1;
            this.label8.Text = "Is valid : ";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(172, 14);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(86, 20);
            this.label7.TabIndex = 0;
            this.label7.Text = "Blockchain";
            // 
            // panel4
            // 
            this.panel4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel4.Controls.Add(this.ServeurTransStatus);
            this.panel4.Controls.Add(this.ServeurMinerStatus);
            this.panel4.Controls.Add(this.ServeurDataStatus);
            this.panel4.Controls.Add(this.label6);
            this.panel4.Controls.Add(this.label5);
            this.panel4.Controls.Add(this.label4);
            this.panel4.Controls.Add(this.StopServeur);
            this.panel4.Controls.Add(this.StartServeur);
            this.panel4.Location = new System.Drawing.Point(518, 137);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(509, 165);
            this.panel4.TabIndex = 4;
            // 
            // ServeurTransStatus
            // 
            this.ServeurTransStatus.Location = new System.Drawing.Point(181, 121);
            this.ServeurTransStatus.Name = "ServeurTransStatus";
            this.ServeurTransStatus.ReadOnly = true;
            this.ServeurTransStatus.Size = new System.Drawing.Size(205, 26);
            this.ServeurTransStatus.TabIndex = 17;
            this.ServeurTransStatus.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // ServeurMinerStatus
            // 
            this.ServeurMinerStatus.Location = new System.Drawing.Point(137, 86);
            this.ServeurMinerStatus.Name = "ServeurMinerStatus";
            this.ServeurMinerStatus.ReadOnly = true;
            this.ServeurMinerStatus.Size = new System.Drawing.Size(249, 26);
            this.ServeurMinerStatus.TabIndex = 16;
            this.ServeurMinerStatus.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // ServeurDataStatus
            // 
            this.ServeurDataStatus.Location = new System.Drawing.Point(133, 56);
            this.ServeurDataStatus.Name = "ServeurDataStatus";
            this.ServeurDataStatus.ReadOnly = true;
            this.ServeurDataStatus.Size = new System.Drawing.Size(253, 26);
            this.ServeurDataStatus.TabIndex = 15;
            this.ServeurDataStatus.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(12, 124);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(163, 20);
            this.label6.TabIndex = 4;
            this.label6.Text = "Transaction Serveur : ";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 89);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(119, 20);
            this.label5.TabIndex = 3;
            this.label5.Text = "Miner Serveur : ";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 59);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(115, 20);
            this.label4.TabIndex = 2;
            this.label4.Text = "Data Serveur : ";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // StopServeur
            // 
            this.StopServeur.Location = new System.Drawing.Point(246, 14);
            this.StopServeur.Name = "StopServeur";
            this.StopServeur.Size = new System.Drawing.Size(230, 31);
            this.StopServeur.TabIndex = 1;
            this.StopServeur.Text = "Stop";
            this.StopServeur.UseVisualStyleBackColor = true;
            this.StopServeur.Click += new System.EventHandler(this.StopServClick);
            // 
            // StartServeur
            // 
            this.StartServeur.Location = new System.Drawing.Point(16, 14);
            this.StartServeur.Name = "StartServeur";
            this.StartServeur.Size = new System.Drawing.Size(224, 31);
            this.StartServeur.TabIndex = 0;
            this.StartServeur.Text = "Start";
            this.StartServeur.UseVisualStyleBackColor = true;
            this.StartServeur.Click += new System.EventHandler(this.StartServClick);
            // 
            // panel5
            // 
            this.panel5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel5.Controls.Add(this.label20);
            this.panel5.Controls.Add(this.TransactionLog);
            this.panel5.Controls.Add(this.ToAddressTrans);
            this.panel5.Controls.Add(this.label15);
            this.panel5.Controls.Add(this.AmountTrans);
            this.panel5.Controls.Add(this.label16);
            this.panel5.Controls.Add(this.label17);
            this.panel5.Controls.Add(this.SendTransaction);
            this.panel5.Location = new System.Drawing.Point(518, 308);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(509, 333);
            this.panel5.TabIndex = 18;
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Location = new System.Drawing.Point(18, 264);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(48, 20);
            this.label20.TabIndex = 22;
            this.label20.Text = "Log : ";
            // 
            // TransactionLog
            // 
            this.TransactionLog.Location = new System.Drawing.Point(16, 290);
            this.TransactionLog.Name = "TransactionLog";
            this.TransactionLog.ReadOnly = true;
            this.TransactionLog.Size = new System.Drawing.Size(481, 26);
            this.TransactionLog.TabIndex = 21;
            // 
            // ToAddressTrans
            // 
            this.ToAddressTrans.Location = new System.Drawing.Point(16, 124);
            this.ToAddressTrans.Name = "ToAddressTrans";
            this.ToAddressTrans.Size = new System.Drawing.Size(481, 121);
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
            this.SendTransaction.Click += new System.EventHandler(this.SendTransactionClick);
            // 
            // timerAmount
            // 
            this.timerAmount.Interval = 2000;
            this.timerAmount.Tick += new System.EventHandler(this.timerAmount_Tick);
            // 
            // timerServeur
            // 
            this.timerServeur.Tick += new System.EventHandler(this.timerServeur_Tick);
            // 
            // Serveur
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1028, 653);
            this.Controls.Add(this.panel5);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Name = "Serveur";
            this.Text = "Epicoin Serveur";
            this.Load += new System.EventHandler(this.Serveur_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.panel5.ResumeLayout(false);
            this.panel5.PerformLayout();
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
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button StopServeur;
        private System.Windows.Forms.Button StartServeur;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.ProgressBar NextBlockBar;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TextBox ChainIsValid;
        private System.Windows.Forms.TextBox ChainDifficulty;
        private System.Windows.Forms.TextBox ChainLenght;
        private System.Windows.Forms.TextBox ChainPending;
        private System.Windows.Forms.TextBox ChainLastIndex;
        private System.Windows.Forms.TextBox ServeurTransStatus;
        private System.Windows.Forms.TextBox ServeurMinerStatus;
        private System.Windows.Forms.TextBox ServeurDataStatus;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.TextBox AmountTrans;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Button SendTransaction;
        private System.Windows.Forms.RichTextBox ToAddressTrans;
        private System.Windows.Forms.RichTextBox ChainLastHash;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.TextBox EpicoinAmount;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.Timer timerAmount;
        private System.Windows.Forms.Timer timerServeur;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.TextBox TransactionLog;
    }
}