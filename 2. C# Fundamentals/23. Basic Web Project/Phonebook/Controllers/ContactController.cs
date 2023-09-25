using Microsoft.AspNetCore.Mvc;
using Phonebook.Data;
using Phonebook.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Phonebook.Controllers
{
    public class ContactController : Controller
    {
        public IActionResult Create(string name, string number)
        {
            Contact contact = new Contact(name, number);
            DataAccess.Contacts.Add(contact);
            return RedirectToAction("Index", "Home");
        }

        public IActionResult Remove(string number)
        {
            Contact contact = DataAccess.Contacts.Find(x => x.Number == number);
            DataAccess.Contacts.Remove(contact);
            return RedirectToAction("Index", "Home");
        }
    }
}
