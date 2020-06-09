

using System;
using System.Collections.Generic;
using System.Timers;

namespace TaskbarTimer
{
    //***************************************************************************
    // TimerInfo
    //***************************************************************************

    public readonly struct TimerInfo
    {
        public readonly string TimerName;
        public readonly TimeSpan TimerTimeout;
        public readonly bool Started;
        public readonly DateTime StartDateTime;

        public TimerInfo(string name, TimeSpan timeout, bool started, DateTime startDateTime)
        {
            this.TimerName = name;
            this.TimerTimeout = timeout;
            this.Started = started;
            this.StartDateTime = startDateTime;

        }
    }

    //***************************************************************************
    // TimerInstance
    //***************************************************************************

    public class TimerInstance
    {
        /* FUTURE:
         * - Elapsed time?
         * - Pause support
         */

        private int TimerId = -1; // TimerId is invalid if -1
        private int TimeoutSeconds = 0;
        private string TimerName;
        private DateTime StartDateTime = new DateTime();
        private Timer TimerObject;

        //-------------------------------------------------------------
        
        public TimerInstance()
        {
            this.TimerId = -1;
        }

        //-------------------------------------------------------------

        public TimerInstance(int id, string name, int seconds)
        {
            this.TimerId = id;
            this.TimerName = name;

            this.TimerObject = new Timer();
            this.TimerObject.Elapsed += OnTimeout;
            this.TimerObject.Interval = seconds * 1000;
            this.TimerObject.AutoReset = false;
        }

        //-------------------------------------------------------------

        public void Start()
        {
            this.StartDateTime = DateTime.Now;
            this.TimerObject.Start();
        }

        //-------------------------------------------------------------

        public void Invalidate()
        {
            this.TimerObject.Stop();
        }

        //-------------------------------------------------------------

        public void Pause()
        {
            // TODO - Need to think about how pause mechanism works
        }

        //-------------------------------------------------------------

        public bool IsRunning()
        {
            return this.TimerObject.Enabled;
        }

        //-------------------------------------------------------------

        public int SetTimeout(int newTimeout)
        {
            this.TimeoutSeconds = newTimeout;
            return TimeoutSeconds;
        }

        //-------------------------------------------------------------

        public void SetName(string newName)
        {
            this.TimerName = newName;
        }

        //-------------------------------------------------------------

        public TimeSpan GetTimeout()
        {
            return new TimeSpan(0, 0, TimeoutSeconds);
        }

        //-------------------------------------------------------------

        public DateTime GetStartDateTime()
        {
            return this.StartDateTime;
        }

        //-------------------------------------------------------------

        public string GetName()
        {
            return TimerName;
        }

        //-------------------------------------------------------------

        public int GetId()
        {
            return TimerId;
        }

        //-------------------------------------------------------------

        private void OnTimeout(Object source, System.Timers.ElapsedEventArgs e)
        {
            // TODO
            // Notify controller
        }

    }


    /***************************************************************************/
    // TIMERS
    /***************************************************************************/

    public class Timers
    {
        List<TimerInstance> TimerList = new List<TimerInstance>();
        private Random Random = new Random();

        //-------------------------------------------------------------

        public void AddTimer(int Seconds = 0, string Name = "")
        {
            int newId = 0;
            bool idExists = true;
            while (idExists == true)
            {
                newId = Random.Next();
                idExists = IdExists(newId);
            }

            TimerList.Add(new TimerInstance(newId, Name, Seconds));
        }

        //-------------------------------------------------------------

        public void RemoveTimer(int TimerId)
        {
            if (this.IdExists(TimerId))
            {
                TimerInstance timer = this.getTimer(TimerId);
                timer.Invalidate();
                TimerList.Remove(timer);
            }
        }

        //-------------------------------------------------------------

        public List<int> GetTimerIds()
        {
            List<int> idList = new List<int>();
            foreach (TimerInstance timer in TimerList)
            {
                idList.Add(timer.GetId());
            }
            return idList;
        }

        //-------------------------------------------------------------

        public TimerInfo GetTimerInfo(int TimerId)
        {
            TimerInstance timer = this.getTimer(TimerId);
            return new TimerInfo(timer.GetName(), timer.GetTimeout(), timer.IsRunning(), timer.GetStartDateTime());
        }

        //-------------------------------------------------------------

        public bool IdExists(int id)
        {
            foreach (TimerInstance timer in TimerList)
            {
                if (timer.GetId() == id)
                {
                    return true;
                }
            }
            return false;
        }


        //-------------------------------------------------------------

        private TimerInstance getTimer(int id)
        {
            foreach (TimerInstance timer in TimerList)
            {
                if (timer.GetId() == id)
                {
                    return timer;
                }
            }

            return new TimerInstance();
        }
    }

} // namespace
