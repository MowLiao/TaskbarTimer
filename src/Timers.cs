

using System;
using System.Collections.Generic;
using System.Threading;

namespace TaskbarTimer
{

    public class TimerInstance
    {
        bool isRunning = false;

        private int orderNumber = 0;
        private int timerId = -1;
        private int timeoutSeconds = 0;
        private string timerName;
        private Timer timer;

        public TimerInstance()
        {
            this.timerId = -1;
        }

        public TimerInstance(int id, string Name, int Seconds)
        {
            this.timerId = id;
            this.timerName = Name;
            this.timeoutSeconds = Seconds;
        }

        public void Start()
        {
            isRunning = true;
            // TODO
        }

        public void Invalidate()
        {
            isRunning = false;
            // TODO
        }

        public void Pause()
        {
            isRunning = false;
            // TODO
        }

        public int SetTimeout(int newTimeout)
        {
            this.timeoutSeconds = newTimeout;
            return timeoutSeconds;
        }

        public void SetName(string newName)
        {
            this.timerName = newName;
        }

        public int GetTimeout()
        {
            return timeoutSeconds;
        }

        public string GetName()
        {
            return timerName;
        }

        public int GetId()
        {
            return timerId;
        }
    }

    public class Timers
    {
        List<TimerInstance> timerList;
        private Random random = new Random();

        public void NewTimer(int Seconds = 0, string Name = "")
        {
            int newId = 0;
            bool idExists = false;
            while (idExists == true)
            {
                newId = random.Next();
                idExists = IdExists(newId);
            }

            timerList.Add(new TimerInstance(newId, Name, Seconds));
        }

        public TimerInstance getTimer(int id)
        {
            foreach (TimerInstance timer in timerList)
            {
                if (timer.GetId() == id)
                {
                    return timer;
                }
            }
            return new TimerInstance();
        }

        private bool IdExists(int id)
        {
            foreach (TimerInstance timer in timerList)
            {
                if (timer.GetId() == id)
                {
                    return true;
                }
            }
            return false;
        }

        public List<int> getTimerIds()
        {
            List<int> idList = new List<int>();
            foreach (TimerInstance timer in timerList)
            {
                idList.Add(timer.GetId());
            }
            return idList;
        }
    }

} // namespace
