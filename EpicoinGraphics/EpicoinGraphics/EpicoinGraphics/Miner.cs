using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Threading;
using System.Windows.Forms;
using blockchain;

namespace EpicoinGraphics
{
    public partial class Miner : Form
    {
        public Miner()
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
            Epicoin.ExportWallet();
            Environment.Exit(0);
        }

        protected void StartClick(object sender, EventArgs e)
        {
            if (!this.work)
            {
                Epicoin.Continue = true;
                blockchain.Client.DataClient.Continue = true;
                DataServer.Continue = true;
                this.work = true;
                this.worker = new Thread(Epicoin.Mine) { Priority = ThreadPriority.Highest };
                this.worker.Start(Epicoin.Wallet.Address[0]);
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
                blockchain.Client.DataClient.Continue = false;
                DataServer.Continue = false;
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
            try
            {
                string msg = Epicoin.log.pop();
                if (msg != null)
                {
                    this.LogMiner.AppendText(msg + "\n");
                }
            }
            catch (Exception e)
            { } 
            this.LogMiner.Refresh();
        }

        protected void StopLog()
        {
            this.LogMiner.AppendText("[CM] Stop\n");
            this.LogMiner.Refresh();
            Thread.Sleep(1100);
        }

        protected Thread logWorker;
        protected bool work = false;
        protected Thread worker = null;

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (perfcpu == null)
            {
                return;
            }
            float fcpu = perfcpu.NextValue();
            if (fcpu > cpubar.Maximum)
            {
                fcpu = cpubar.Maximum;
            }
            cpubar.Value = (int)fcpu;
            cpubar.Invalidate();
            cpubar.Update();
        }

        private void Miner_Load(object sender, EventArgs e)
        {
            this.TextBoxName.Text = Epicoin.Wallet.Name;
            this.TextBoxAddress.Text = Epicoin.Wallet.Address[0];
            try
            {
                perfcpu = new PerformanceCounter("Processor Information", "% Processor Time", "_Total");
            }
            catch
            {
                return;
            }
            timer1.Start();
        }

        PerformanceCounter perfcpu = null;
    }
}
