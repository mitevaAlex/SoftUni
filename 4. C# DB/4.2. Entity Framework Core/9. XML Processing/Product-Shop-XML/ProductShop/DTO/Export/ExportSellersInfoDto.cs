using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace ProductShop.DTO.Export
{
    [XmlType("Users")]
    public class ExportSellersInfoDto
    {
        [XmlElement("count")]
        public int Count { get; set; }

        [XmlArray("users")]
        public ExportUserInfoDto[] Users { get; set; }
    }
}
