using CarRacing.Models.Maps.Contracts;
using CarRacing.Models.Racers.Contracts;
using CarRacing.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Text;

namespace CarRacing.Models.Maps
{
    public class Map : IMap
    {
        private const double strictMultiplier = 1.2;
        private const double aggressiveMultiplier = 1.1;

        public Map()
        {
        }

        public string StartRace(IRacer racerOne, IRacer racerTwo)
        {
            if (racerOne.IsAvailable() == false && racerTwo.IsAvailable() == false)
            {
                return OutputMessages.RaceCannotBeCompleted;
            }
            else if (racerOne.IsAvailable() == false)
            {
                return string.Format(
                    OutputMessages.OneRacerIsNotAvailable, 
                    racerTwo.Username, 
                    racerOne.Username);
            }
            else if (racerTwo.IsAvailable() == false)
            {
                return string.Format(
                    OutputMessages.OneRacerIsNotAvailable, 
                    racerOne.Username, 
                    racerTwo.Username);
            }

            string winnerUsername = "";

            racerOne.Race();
            double chanceOfWinningRacerOne = racerOne.Car.HorsePower * racerOne.DrivingExperience;
            if (racerOne.RacingBehavior == "strict")
            {
                chanceOfWinningRacerOne *= strictMultiplier;
            }
            else if (racerOne.RacingBehavior == "aggressive")
            {
                chanceOfWinningRacerOne *= aggressiveMultiplier;
            }

            racerTwo.Race();
            double chanceOfWinningRacerTwo = racerTwo.Car.HorsePower * racerTwo.DrivingExperience;
            if (racerTwo.RacingBehavior == "strict")
            {
                chanceOfWinningRacerTwo *= strictMultiplier;
            }
            else if (racerTwo.RacingBehavior == "aggressive")
            {
                chanceOfWinningRacerTwo *= aggressiveMultiplier;
            }

            if (chanceOfWinningRacerOne > chanceOfWinningRacerTwo)
            {
                winnerUsername = racerOne.Username;
            }
            else
            {
                winnerUsername = racerTwo.Username;
            }

            return string.Format(
                OutputMessages.RacerWinsRace,
                racerOne.Username,
                racerTwo.Username,
                winnerUsername);
        }
    }
}
