using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace CubeAIProto
{
    internal class TimerManager
    {
        public static GameTime gameTime;
        public bool ready; // can run or not
        public int mSec;
        public TimeSpan timer = new TimeSpan();
        public TimerManager(int m)
        {
            ready = false;
            mSec = m;
        }
        public TimerManager(int m, bool start)//testing to see if works
        {
            ready = true;
            mSec = m;
        }

        public int Msec
        {
            get { return mSec; }
            set { mSec = value; }
        }
        public int Timer
        {
            get { return (int)timer.TotalMilliseconds; }
        }

        public void UpdateTimer(GameTime g)
        {
            timer += g.ElapsedGameTime;
        }

        public bool Test()
        {
            if (timer.TotalMilliseconds >= mSec || ready)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public void ResetZero()
        {
            timer = TimeSpan.Zero;
            ready = false;
        }
        public void ResetNew(int n)
        {
            timer = TimeSpan.Zero;
            Msec = n;
            ready = false;
        }

        public virtual XElement ReturnXML() //unused
        {
            XElement xml = new XElement("Timer",
                new XElement("mSec", mSec),
                new XElement("timer", Timer));

            return xml;
        }

        public void SetTimer(TimeSpan time)
        {
            timer = time;
        }
        public void SetTimer(int msec)
        {
            timer = TimeSpan.FromMilliseconds((long)(msec));
        }


    }
}