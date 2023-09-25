using System.Xml.Serialization;

namespace ProductShop.DTO.Export
{
    [XmlType("SoldProducts")]
    public class ExportSoldProductsInfoDTO
    {
        [XmlElement("count")]
        public int Count { get; set; }

        [XmlArray("products")]
        public ExportProductPriceDto[] SoldProducts { get; set; }
    }
}