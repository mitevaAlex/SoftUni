using System;
using System.Collections.Generic;
using System.Text;

namespace Truck_Tour
{
    class Pump
    {
        public Pump (int petrolAmount, int nextPumpDistance, int pumpIndex)
        {
            this.PetrolAmount = petrolAmount;
            this.NextPumpDistance = nextPumpDistance;
            this.PumpIndex = pumpIndex;
        }

        public int PetrolAmount { get; set; }

        public int NextPumpDistance { get; set; }

        public int PumpIndex { get; set; }
    }
}
