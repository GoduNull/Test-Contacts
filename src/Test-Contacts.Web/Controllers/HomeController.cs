using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Test_Contacts.Logic.Interfaces;
using Test_Contacts.Logic.ModelsDto;
using Test_Contacts.Web.Models;
using Test_Contacts.Web.ViewModels;

namespace Test_Contacts.Web.Controllers
{
    public class HomeController : Controller
    {
        private IContactManager _contactManager;
        public HomeController(IContactManager contactManager)
        {
            _contactManager = contactManager ?? throw new ArgumentNullException(nameof(contactManager));
        }
        [HttpGet]
        public async Task<IActionResult> GetContacts()
        {
            var contacts = await _contactManager.GetAllAsync();

            IEnumerable<ContactViewModel> ContacttViewModels()
            {
                return contacts.Select(c => new ContactViewModel
                {
                    Id = c.Id,
                    Name = c.Name,
                    MobilePhone = c.MobilePhone,
                    JobTitle = c.JobTitle,
                    BirthDate = c.BirthDate,
                });
            }

            ContactListViewModel contactListView = new()
            {
                Contacts = ContacttViewModels()
            };

            return View(contactListView);
        }

        [HttpPost]
        public async Task<IActionResult> CreateContactAsync(ContactViewModel contactView)
        {
                var contactDto = new ContactDto()
            {
                Name = contactView.Name,
                MobilePhone = contactView.MobilePhone,
                JobTitle = contactView.JobTitle,
                BirthDate = contactView.BirthDate,
            };
            await _contactManager.CreateAsync(contactDto);
            return PartialView("Close");
        }

        /// <summary>
        /// CreateProjectModalWindow (Get).
        /// </summary>
        /// <returns>Partial view</returns>
        [HttpGet]
        public ActionResult CreateModalWindow()
        {
            return PartialView("CreateModalWindow");
        }
    }
}
