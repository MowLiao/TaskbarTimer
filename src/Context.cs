// https://www.codeproject.com/Articles/18683/Creating-a-Tasktray-Application (done)
// https://docs.microsoft.com/en-us/dotnet/api/system.windows.forms.form.showintaskbar?view=netcore-3.1

using System;
using System.Diagnostics;
using System.Drawing;
using System.Reflection;
using System.Windows.Forms;

namespace TaskbarTimer
{
    public class Context : ApplicationContext
    {
        private NotifyIcon notifyIcon;
        private Controller controller;

        public Context()
        {
            // TODO: condition for loading this, e.g. has context started up correctly?
            this.InitNotifyIcon();

            this.controller = new Controller();
        }

        private void InitNotifyIcon()
        {
            MenuItem exitMenuItem = new MenuItem("Exit", new EventHandler(Exit));

            this.notifyIcon = new NotifyIcon();
            this.notifyIcon.Icon = SystemIcons.Application;
            this.notifyIcon.ContextMenu = new ContextMenu(new MenuItem[]
                { exitMenuItem });
            this.notifyIcon.Visible = true;

            this.notifyIcon.MouseClick += new MouseEventHandler(notifyIcon_MouseClick);

            this.notifyIcon.BalloonTipText = "Your Application";
            this.notifyIcon.BalloonTipTitle = "Congrats, your Taskbar App is running.";
            this.notifyIcon.ShowBalloonTip(1);
        }

        private void Exit(object sender, EventArgs e)
        {
            // We must manually tidy up and remove the icon before we exit.
            // Otherwise it will be left behind until the user mouses over.
            notifyIcon.Visible = false;
            Application.Exit();
        }
        
        private void notifyIcon_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                controller.UndisposeForm();
                controller.MakeFormVisible();
            }
            else if (e.Button == MouseButtons.Right)
            {
                // Don't do anything - context menu triggers before this.
            }
            else
            {
                Debug.WriteLine("Other click");
            }
        }

    }

} // namespace

