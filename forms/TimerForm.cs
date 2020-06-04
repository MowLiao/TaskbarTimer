using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TaskbarTimer
{
    public partial class TimerForm : Form
    {
        readonly int width = 400;
        readonly int height = 400;
        Timer focusTimer;

        public TimerForm()
        {
            InitializeComponent();
            Setup();

            Text = "Congrats, you opened a form";
        }

        private void Setup()
        {
            this.ShowInTaskbar = false;
            this.MinimizeBox = false;
            this.MaximizeBox = false;
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximumSize = new Size(width, height);
            this.MinimumSize = new Size(width, height);
            this.Size = new Size(width, height);

            // Set window location to bottom right of screen
            System.Drawing.Rectangle screenRect = Screen.PrimaryScreen.WorkingArea;
            int xLocation = (screenRect.Width - this.width);
            int yLocation = (screenRect.Height - this.height);
            this.StartPosition = FormStartPosition.Manual;
            this.Location = new Point(xLocation, yLocation);

            // Timer needed to hack force focus on open
            focusTimer = new Timer();
            focusTimer.Tick += new EventHandler(OnTick);
            focusTimer.Interval = 100;
        }

        protected override void OnLostFocus(EventArgs e)
        {
            this.Visible = false;
            focusTimer.Stop();
        }

        protected override void OnGotFocus(EventArgs e)
        {
            this.TopMost = true;
            focusTimer.Start();
        }

        private void OnTick(object sender, EventArgs e)
        {
            // Sometimes opens without focus despite Focused being True, so hack a force focus
            this.Activate();
        }
    }
}
