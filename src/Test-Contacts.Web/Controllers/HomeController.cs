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
        /// <summary>
        /// Get cintacts (Get).
        /// </summary>
        /// <returns> Contact list</returns>
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
        /// <summary>
        /// Create contact (Post).
        /// </summary>
        /// <param name="contactView"></param>
        /// <returns>Partial view Close</returns>
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
        /// Update contact (Post).
        /// </summary>
        /// <param name="contactView"></param>
        /// <returns>Partial view Close</returns>
        [HttpPost]
        public async Task<IActionResult> UpdateContactAsync(ContactViewModel contactView)
        {
            var contactDto = new ContactDto()
            {
                Id=contactView.Id,
                Name = contactView.Name,
                MobilePhone = contactView.MobilePhone,
                JobTitle = contactView.JobTitle,
                BirthDate = contactView.BirthDate,
            };
            await _contactManager.UpdateAsync(contactDto);
            return PartialView("CloseUpdate");
        }
        /// <summary>
        /// CreateProjectModalWindow (Get).
        /// </summary>
        /// <returns>Partial view CreateModalWindow</returns>
        [HttpGet]
        public ActionResult CreateModalWindow()
        {
            return PartialView("CreateModalWindow");
        }
        /// <summary>
        /// UpdateModalWindow
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Partial view UpdateModalWindow</returns>
        [HttpPost]
        public async Task<ActionResult> UpdateModalWindowAsync(int id)
        {
            var contact = await _contactManager.GetByContactIdAsync(id);

            return PartialView(new ContactViewModel
            {
                Id = contact.Id,
                Name = contact.Name,
                MobilePhone = contact.MobilePhone,
                JobTitle = contact.JobTitle,
                BirthDate = contact.BirthDate,
            });
        }
    }
}
