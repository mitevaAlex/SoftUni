using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace ProductShop.DTO.Import
{
    [XmlType("CategoryProduct")]
    public class ImportCategoryProductDto
    {
        public int CategoryId { get; set; }

        public int ProductId { get; set; }
    }
}
