using System;
using System.ComponentModel;
using System.Windows.Forms;

namespace GUI
{
    public partial class ucTimer : UserControl
    {
        public int Current { get; set; }
        public int Max { get; set; }

        [Browsable(true)]
        public event EventHandler EndEvent;
        protected void Timer_End(object sender, EventArgs e)
        {
            //bubble the event up to the parent
            if (this.EndEvent != null)
                this.EndEvent(this, e);
        }
        public ucTimer()
        {
            InitializeComponent();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            this.Current++;
            this.label.Text = secToStr(this.Current);
            if (Max != -1 && Current >= Max)
            {
                this.timer1.Enabled = false;
                this.Timer_End(this, null);
            }
        }

        private string secToStr(int current)
        {
            int hours = current / 3600;
            int mod = current % 3600;
            int mins = mod / 60;
            int secs = mod % 60;
            return hours.ToString() + ":" + mins.ToString().PadLeft(2, '0') + ":" + secs.ToString().PadLeft(2, '0');
        }

        public void Start()
        {
            this.timer1.Enabled = true;
            this.timer1.Start();
        }

        public void Stop()
        {
            this.timer1.Enabled = false;
            this.timer1.Stop();
        }
    }
}
