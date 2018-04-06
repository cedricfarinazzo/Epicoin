using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using blockchain;

namespace EpicoinGraphics
{
    public partial class Miner : Form
    {
        public Miner()
        {
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
            InitializeComponent();
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            base.OnFormClosing(e);
            Epicoin.Continue = false;
            if (this.worker != null)
            {
                this.worker.Abort();
            }
            this.worker = null;
            this.work = false;
            Environment.Exit(0);
        }

        protected void StartClick(object sender, EventArgs e)
        {
            if (!this.work)
            {
                Epicoin.Continue = true;
                this.work = true;
                this.worker = new Thread(Epicoin.ClientMine) { Priority = ThreadPriority.Highest };
                this.worker.Start(Epicoin.Wallet);
            }
        }

        protected void StopClick(object sender, EventArgs e)
        {
            if (this.work)
            {
                Epicoin.Continue = false;
                this.worker.Abort();
                this.worker = null;
                this.work = false;
            }
        }

        protected bool work = false;
        protected Thread worker = null;
    }
}
