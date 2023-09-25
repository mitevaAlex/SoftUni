using System;
using System.Collections.Generic;
using System.Text;

namespace Birthday_Celebrations
{
    public class Robot : ICitizen
    {
        public Robot(string model, string id)
        {
            this.Model = model;
            this.Id = id;
        }

        public string Model { get; private set; }

        public string Id { get; private set; }
    }
}
