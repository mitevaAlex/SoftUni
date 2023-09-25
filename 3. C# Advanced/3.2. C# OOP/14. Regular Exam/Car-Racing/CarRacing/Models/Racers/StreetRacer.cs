using CarRacing.Models.Cars.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace CarRacing.Models.Racers
{
    public class StreetRacer : Racer
    {
        private const string racingBehavior = "aggressive";
        private const int drivingExperience = 10;
        private const int drivingExpIncrease = 5;

        public StreetRacer(string username, ICar car) 
            : base(username, racingBehavior, drivingExperience, car)
        {
        }

        public override void Race()
        {
            base.Race();
            DrivingExperience += drivingExpIncrease;
        }
    }
}
