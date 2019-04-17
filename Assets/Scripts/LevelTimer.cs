using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using UnityEngine;

namespace Assets.Scripts
{
    class LevelTimer
    {
        private int Minutes = 1;
        public System.Timers.Timer aTimer;
        public int LevelDurationInMinutes = 1;
        public bool endLevel = false;
        public int secCounter = 0;
        public int Limit = 1;


        public LevelTimer(int minutes=1)
        {
            aTimer = new System.Timers.Timer();
            aTimer.Interval = 1000;
            aTimer.Elapsed += new System.Timers.ElapsedEventHandler(OnTimedEvent);
            Limit = 60 * minutes;
            aTimer.Start();

        }
        private void OnTimedEvent(object sender, ElapsedEventArgs e)
        {
            secCounter++;
            if(Limit <= secCounter) this.endLevel = true ;
        }

        public int GetElapsed()
        {
            return secCounter;
        }
        public void reset()
        {
            secCounter = 0;
            endLevel = false;
        }

    }
}
