using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

/*
 * GUI Spec:
 *  - Borderless window
 *  - Appears at the bottom right of the screen, implies that this is a taskbar only app
 *      - FUTURE: Show next to where the notify icons are appearing - other people might have task bar on e.g. left on side of the screen
 *  - Custom GUI
 *      - Start with basic for now, move to custom graphics as an extension
 *  - Is there a built in form timer?
 *  - One main window containing:
 *      - Add new timer
 *      - List of current timers
 *  - Dialog window notifying timeout happened
 *      - Dismiss button
 *      - Start new button to input new timer
 *      - Start again button to start a new timer with same params immediately
 *  
 * To do:
 *  - Make class diagram
 *  - Need to create data objects to hold X number of timers
 *      - can they be expandable or do they need to be fixed?
 *  - Central timer controller
 *      - are we doing this in the context or should we have a custom class for it?
 */

namespace TaskbarTimer
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Context());
        }
    }
}
