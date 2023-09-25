using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace CarDealer.DTO
{
    public class CarPartsDTO
    {

        [JsonProperty("car")]
        public BasicCarDTO Car { get; set; }

        [JsonProperty("parts")]
        public PartDTO[] Parts { get; set; }
    }
}
