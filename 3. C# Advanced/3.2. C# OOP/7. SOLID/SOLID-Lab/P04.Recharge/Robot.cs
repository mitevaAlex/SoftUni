using System;
using System.Collections.Generic;
using System.Text;

namespace P04.Recharge
{
    public class Robot : Worker, IRechargeable
    {
        public Robot(string id, int capacity) : base(id)
        {
            this.Capacity = capacity;
            this.CurrentPower = this.Capacity;
        }

        public int Capacity { get; }

        public int CurrentPower { get; set; }

        public override void Work(int hours)
        {
            if (hours > this.CurrentPower)
            {
                hours = CurrentPower;
            }

            base.Work(hours);
            this.CurrentPower -= hours;
        }

        public void Recharge()
        {
            this.CurrentPower = this.Capacity;
        }
    }
}