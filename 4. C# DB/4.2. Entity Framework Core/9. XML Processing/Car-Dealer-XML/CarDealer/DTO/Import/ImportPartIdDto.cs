using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;
using System.Xml.Serialization;

namespace CarDealer.DTO.Import
{
    [XmlType("partId")]
    public class ImportPartIdDto : IEquatable<ImportPartIdDto>
    {
        [XmlAttribute("id")]
        public int Id { get; set; }

        public bool Equals(ImportPartIdDto other)
        {
            return this.Id.Equals(other.Id);
        }

        public override int GetHashCode()
        {
            int hashId = this.Id == null ? 0 : this.Id.GetHashCode();

            return hashId;
        }
    }
}
