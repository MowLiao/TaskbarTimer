// https://www.codeproject.com/Articles/18683/Creating-a-Tasktray-Application (done)
// https://docs.microsoft.com/en-us/dotnet/api/system.windows.forms.form.showintaskbar?view=netcore-3.1

using System;
using System.Diagnostics;
using System.Drawing;
using System.Reflection;
using System.Windows.Forms;

namespace TaskbarTimer
{
    //***************************************************************************
    // Context
    //***************************************************************************

    public class Context : ApplicationContext
    {
        private NotifyIcon NotifyIcon;
        private Controller Controller;

        public Context()
        {
            // TODO: condition for loading this, e.g. has context started up correctly?
            this.InitNotifyIcon();

            this.Controller = new Controller();
        }

        //-------------------------------------------------------------

        private void InitNotifyIcon()
        {
            MenuItem exitMenuItem = new MenuItem("Exit", new EventHandler(Exit));

            this.NotifyIcon = new NotifyIcon();
            this.NotifyIcon.Icon = SystemIcons.Application;
            this.NotifyIcon.ContextMenu = new ContextMenu(new MenuItem[]
                { exitMenuItem });
            this.NotifyIcon.Visible = true;

            this.NotifyIcon.MouseClick += new MouseEventHandler(NotifyIcon_MouseClick);

            this.NotifyIcon.BalloonTipText = "Your Application";
            this.NotifyIcon.BalloonTipTitle = "Congrats, your Taskbar App is running.";
            this.NotifyIcon.ShowBalloonTip(1);
        }

        //-------------------------------------------------------------

        private void Exit(object sender, EventArgs e)
        {
            // We must manually tidy up and remove the icon before we exit.
            // Otherwise it will be left behind until the user mouses over.
            NotifyIcon.Visible = false;
            Application.Exit();
        }

        //-------------------------------------------------------------

        private void NotifyIcon_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                Controller.UndisposeForm();
                Controller.MakeFormVisible();
            }
            else if (e.Button == MouseButtons.Right)
            {
                // Don't do anything - right click context menu triggers before this.
            }
            else
            {
                Debug.WriteLine("Other click");
            }
        }

    }

} // namespace

