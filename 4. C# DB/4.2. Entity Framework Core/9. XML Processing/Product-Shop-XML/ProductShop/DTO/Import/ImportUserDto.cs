﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using System.Xml.Serialization;

namespace ProductShop.DTO.Import
{
    [XmlType("User")]
    public class ImportUserDto
    {
        [XmlElement("firstName")]
        public string FirstName { get; set; }

        [Required]
        [XmlElement("lastName")]
        public string LastName { get; set; }

        [XmlElement("age")]
        public int? Age { get; set; }
    }
}
