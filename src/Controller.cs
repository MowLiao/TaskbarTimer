using System.Collections.Generic;
using System.Diagnostics;

namespace TaskbarTimer
{
    //***************************************************************************
    // Controller
    //***************************************************************************

    public class Controller
    {
        /*
         * This class controls communication between Form UI and data objects
         */
        forms.TimerForm Form;
        Timers Timers;
        List<int> TimerIdCache = new List<int>(); // for timer ordering in UI

        //-------------------------------------------------------------

        public Controller()
        {
            // init ui and timer container
            this.Form = new forms.TimerForm();
            Timers = new Timers();
        }

        //-------------------------------------------------------------

        public void UndisposeForm()
        {
            if (this.Form.IsDisposed)
            {
                // When user manually closes Form, recreate
                this.Form = new forms.TimerForm();
            }
        }

        //-------------------------------------------------------------

        public void MakeFormVisible()
        {
            if (this.Form.Visible == false)
            {
                this.Form.Visible = true;
                this.Form.Show();
            }
        }

        //-------------------------------------------------------------

        public void RecacheIds()
        {
            var tempList = Timers.GetTimerIds();
            foreach (int id in tempList)
            {
                if (!this.TimerIdCache.Contains(id))
                {
                    TimerIdCache.Add(id);
                }
            }
            // TODO: Add refresh UI
        }
    }

} // namespace