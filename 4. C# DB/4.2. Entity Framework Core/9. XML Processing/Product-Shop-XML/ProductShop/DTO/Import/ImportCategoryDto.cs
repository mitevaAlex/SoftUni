using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using System.Xml.Serialization;

namespace ProductShop.DTO.Import
{
    [XmlType("Category")]
    public class ImportCategoryDto
    {
        [Required]
        [XmlElement("name")]
        public string Name { get; set; }
    }
}
