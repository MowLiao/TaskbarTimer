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

namespace TaskbarTimer.forms
{
    //***************************************************************************
    // TimerForm
    //***************************************************************************

    public partial class TimerForm : Form
    {
        readonly int DesiredWidth = 400;
        readonly int DesiredHeight = 600;

        //-------------------------------------------------------------

        public TimerForm()
        {
            InitializeComponent();
            Setup();

            Text = "Congrats, you opened a form";
        }

        //-------------------------------------------------------------

        private void Setup()
        {
            this.ShowInTaskbar = false;
            this.MinimizeBox = false;
            this.MaximizeBox = false;
            this.TopMost = true;

            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximumSize = new Size(DesiredWidth, DesiredHeight);
            this.MinimumSize = new Size(DesiredWidth, DesiredHeight);
            this.Size = new Size(DesiredWidth, DesiredHeight);

            // Set window location to bottom right of screen
            // FUTURE: Detect where notification area is and position accordingly
            System.Drawing.Rectangle screenRect = Screen.PrimaryScreen.WorkingArea;
            int xLocation = (screenRect.Width - this.DesiredWidth);
            int yLocation = (screenRect.Height - this.DesiredHeight);
            this.StartPosition = FormStartPosition.Manual;
            this.Location = new Point(xLocation, yLocation);

            //temp
            TimerList.ItemHeight = 60;
            this.TimerList.Items.Add(new object());
            this.TimerList.Items.Add(new object());
            this.TimerList.Items.Add(new object());
            this.TimerList.Items.Add(new object());
            this.TimerList.Items.Add(new object());
            this.TimerList.Items.Add(new object());
            this.TimerList.Items.Add(new object());
            this.TimerList.Items.Add(new object());
            TimerList.DrawMode = DrawMode.OwnerDrawFixed;
            TimerList.DrawItem += new DrawItemEventHandler(DrawItem);
        }

        //-------------------------------------------------------------

        protected override void OnDeactivate(EventArgs e)
        {
            this.Hide();
        }

        //-------------------------------------------------------------

        private void DrawItem(object sender, System.Windows.Forms.DrawItemEventArgs e)
        {
            e.DrawBackground();

            ClockDrawer drawer = new ClockDrawer(e.Graphics, e.Bounds);
            drawer.DrawFace();

            e.DrawFocusRectangle();
        }
    }
}

