using System;
using System.ComponentModel;
using System.Threading;
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
                logWorker = new Thread(UpdateLog);
                logWorker.Start();
            }
        }

        protected void StopClick(object sender, EventArgs e)
        {
            if (this.work)
            {
                try
                {
                    logWorker.Abort();
                    logWorker = null;
                }
                catch(Exception)
                { }
                Epicoin.Continue = false;
                this.worker.Abort();
                this.worker = null;
                this.work = false;
                Invoke(new MethodInvoker(delegate { StopLog(); }));
            }
        }

        protected void UpdateLog()
        {
            while (this.work)
            {
                Invoke(new MethodInvoker(delegate { RefreshLog(); }));
                Thread.Sleep(200);
            }
        }

        protected void RefreshLog()
        {
            this.LogMiner.Clear();
            try
            {
                this.LogMiner.AppendText(Epicoin.log.Read());
            }
            catch(Exception)
            { }
            this.LogMiner.Refresh();
        }

        protected void StopLog()
        {
            this.LogMiner.AppendText("[CM] Stop");
            this.LogMiner.Refresh();
        }

        protected Thread logWorker;
        protected bool work = false;
        protected Thread worker = null;
    }
}
