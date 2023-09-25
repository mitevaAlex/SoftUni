using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Phonebook.Data.Models
{
    public class Contact
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public string Number { get; set; }

        public Contact(string name, string  number)
        {
            this.Name = name;
            this.Number = number;
        }
    }
}
