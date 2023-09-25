using System;
using System.Collections.Generic;
using System.Text;

namespace Food_Shortage
{
    public interface IBuyer
    {
        int Food { get; }

        void BuyFood();
    }
}
