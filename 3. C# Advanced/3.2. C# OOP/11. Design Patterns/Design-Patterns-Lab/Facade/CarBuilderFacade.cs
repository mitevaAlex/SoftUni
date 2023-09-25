using System;
using System.Collections.Generic;
using System.Text;

namespace Facade
{
    public class CarBuilderFacade
    {
        public CarBuilderFacade()
        {
            Car = new Car();
        }

        protected Car Car { get; set; }

        public CarInfoBuilder Info => new CarInfoBuilder(Car);

        public CarAddressBuilder Built => new CarAddressBuilder(Car);

        public Car Build() => Car;
    }
}
