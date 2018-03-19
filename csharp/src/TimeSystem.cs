using System;
using System.Diagnostics;

namespace ECSDemo
{
    class TimeSystem : ISystem
    {
        static TimeSystem instance;

        public static DateTime Now { get; private set; }
        public static TimeSpan Elapsed { get; private set; }

        DateTime lastTime = DateTime.Now;

        public TimeSystem()
        {
            Debug.Assert(instance == null);
            instance = this;
        }

        public void Tick()
        {
            Now = DateTime.Now;
            Elapsed = Now - lastTime;
            lastTime = Now;
        }
    }
}