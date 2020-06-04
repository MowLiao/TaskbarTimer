using System.Collections.Generic;
using System.Diagnostics;

namespace TaskbarTimer
{
    public class Controller
    {
        /*
         * This class controls communication between form UI and data objects
         */
        TimerForm form;
        List<int> timerIdCache;

        public Controller()
        {
            this.form = new TimerForm();
        }

        public void UndisposeForm()
        {
            if (this.form.IsDisposed)
            {
                // When user manually closes form, recreate
                this.form = new TimerForm();
            }
        }

        public void MakeFormVisible()
        {
            if (this.form.Visible == false)
            {
                Debug.WriteLine("LeftClick");
                this.form.Visible = true;
                this.form.Show();
            }
        }
    }

} // namespace