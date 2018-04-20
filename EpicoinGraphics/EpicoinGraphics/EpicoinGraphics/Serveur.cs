using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using blockchain;

namespace EpicoinGraphics
{
    public partial class Serveur : Form
    {
        public Serveur()
        {
            Epicoin.Continue = false;
            Epicoin.ImportWallet();
            if (Epicoin.Wallet == null)
            {
                string name = "";
                while (name == "")
                {
                    name = Microsoft.VisualBasic.Interaction.InputBox("Your pseudo :  ", "Your pseudo", "Bob");
                }
                Epicoin.CreateWallet(name);
                Epicoin.ExportWallet();
            }
            Epicoin.ImportChain();
            if (Epicoin.Coin == null)
            {
                Epicoin.Init();
            }


            InitializeComponent();

        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            base.OnFormClosing(e);
            Epicoin.Continue = false;
            StopServ();
            Epicoin.ExportChain();
            Epicoin.ExportWallet();
            Environment.Exit(0);
        }

        private void label10_Click(object sender, EventArgs e)
        {
        }

        private void flowLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
        }

        private void ToAddressTrans_TextChanged(object sender, EventArgs e)
        {
        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {
        }

        protected void StartServClick(object sender, EventArgs e)
        {
            StartServ();
        }

        protected void StopServClick(object sender, EventArgs e)
        {
            StopServ();
        }

        protected void StartServ()
        {
            Epicoin.Continue = true;
            blockchain.Client.DataClient.Continue = true;
            DataServer.Continue = true;
            this.block = new Thread(Epicoin.CreateBlock) { Priority = ThreadPriority.Highest };
            this.server = new Thread(Epicoin.server.Start) { Priority = ThreadPriority.Highest };
            this.saveChain = new Thread(Epicoin.SaveBlockchain) { Priority = ThreadPriority.BelowNormal };
            
            this.block.Start();
            this.server.Start();
            Thread.Sleep(1000);
            this.saveChain.Start();
        }

        protected void StopServ()
        {
            Epicoin.Continue = false;
            blockchain.Client.DataClient.Continue = false;
            DataServer.Continue = false;
            Epicoin.ExportChain();
            Epicoin.ExportWallet();
            this.block = null;
            this.server = null;
            this.saveChain = null;
        }

        protected Thread block = null;
        protected Thread server = null;
        protected Thread saveChain = null;

        private void Serveur_Load(object sender, EventArgs e)
        {
            this.TextBoxName.Text = Epicoin.Wallet.Name;
            this.TextBoxAddress.Text = Epicoin.Wallet.Address[0];
            timerAmount.Start();
            timerServeur.Start();
        }

        private void timerAmount_Tick(object sender, EventArgs e)
        {
            if (Epicoin.Continue)
            {
                this.EpicoinAmount.Text = Epicoin.Wallet.TotalAmount().ToString();
            }
            else
            {
                this.EpicoinAmount.Text = "Server offline";
            }
            this.EpicoinAmount.Refresh();
        }

        private void timerServeur_Tick(object sender, EventArgs e)
        {
            bool datastatus = blockchain.Client.DataClient.Continue;
            bool minestatus = blockchain.Client.DataClient.Continue;
            bool transactionstatus = blockchain.Client.DataClient.Continue;

            this.ServeurDataStatus.Text = datastatus.ToString();
            this.ServeurMinerStatus.Text = minestatus.ToString();
            this.ServeurTransStatus.Text = transactionstatus.ToString();
            this.ServeurDataStatus.Refresh();
            this.ServeurMinerStatus.Refresh();
            this.ServeurTransStatus.Refresh();

            this.ChainIsValid.Text = Epicoin.Coin.IsvalidChain().ToString();
            this.ChainIsValid.Refresh();
            this.ChainPending.Text = (Epicoin.Coin.Pending.Count + (Epicoin.Coin.BlockToMines.Count * Block.nb_trans)).ToString();
            this.ChainPending.Refresh();
            
            Block last = Epicoin.Coin.GetLatestBlock();
            this.ChainLenght.Text = Epicoin.Coin.Chainlist.Count.ToString();
            this.ChainLenght.Refresh();
            this.ChainLastIndex.Text = last.Index.ToString();
            this.ChainLastIndex.Refresh();
            this.ChainLastHash.Text = last.Hashblock.ToString();
            this.ChainLastHash.Refresh();
            this.ChainDifficulty.Text = Epicoin.Coin.Difficulty.ToString();
            this.ChainDifficulty.Refresh();

            this.NextBlockBar.Value = Epicoin.Coin.Pending.Count * 100 / 3;
            this.NextBlockBar.Invalidate();
            this.NextBlockBar.Update();
        }

        protected void SendTransactionClick(object sender, EventArgs e)
        {
            this.TransactionLog.Text = "";
            bool error = false;
            string ToAddress = this.ToAddressTrans.Text;
            string Samount = this.AmountTrans.Text;
            if (ToAddress == "" || Samount == "")
            {
                error = true;
            }
            int amount = 0;
            if (!error)
            {

                try
                {
                    amount = int.Parse(Samount);
                    if (amount <= 0)
                    {
                        throw new Exception();
                    }
                }
                catch
                {
                    error = true;
                }
            }

            string display = "";
            if (!error)
            {
                List<DataTransaction> ltrans = Epicoin.Wallet.GenTransactions(amount, ToAddress);
                
                foreach (var trans in ltrans)
                {
                    display += Epicoin.client.SendTransaction(trans) + "\n";
                }
            }

            this.ToAddressTrans.Text = "";
            this.ToAddressTrans.Refresh();
            this.AmountTrans.Text = "";
            this.AmountTrans.Refresh();
            this.TransactionLog.Text = display;
            this.TransactionLog.Refresh();

        }
    }
}
