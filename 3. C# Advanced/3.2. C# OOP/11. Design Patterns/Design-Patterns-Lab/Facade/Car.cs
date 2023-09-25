
using System;
using System.Collections.Generic;
using System.Text;

namespace Facade
{
    public class Car
    {
        //Info
        public string  Type { get; set; }
        public string  Color { get; set; }
        public int NumberOfDoors { get; set; }

        //Address
        public string City { get; set; }
        public string Address { get; set; }

        public override string ToString()
        {
            return $"CarType: {Type}, Color: {Color}, NUmber of doors: {NumberOfDoors}, Manufactured in {City}, at address: {Address}";
        }
    }
}
