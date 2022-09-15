using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Test_Contacts.Data.Models;
using Test_Contacts.Logic.Interfaces;
using Test_Contacts.Logic.ModelsDto;

namespace Test_Contacts.Logic.Managers
{
    /// <inheritdoc cref="IContactManager"/>
    public class ContactManager : IContactManager
    {
        private readonly IRepositoryManager<Contact> _contactRepository;
        public ContactManager(IRepositoryManager<Contact> contactRepository)
        {
            _contactRepository = contactRepository ?? throw new ArgumentNullException(nameof(contactRepository));
        }

        public async Task CreateAsync(ContactDto model)
        {
            model = model ?? throw new ArgumentNullException(nameof(model));

            var contact = new Contact
            {
                Id = model.Id,
                Name = model.Name,
                MobilePhone = model.MobilePhone,
                JobTitle = model.JobTitle,
                BirthDate = model.BirthDate,
            };
            await _contactRepository.CreateAsync(contact);
            await _contactRepository.SaveChangesAsync();
        }

        public async Task<ContactDto> GetByContactIdAsync(int id)
        {
            var contact = await _contactRepository.GetEntityAsync(c => c.Id == id);
            return new ContactDto
            {
                Id = contact.Id,
                Name = contact.Name,
                MobilePhone = contact.MobilePhone,
                JobTitle = contact.JobTitle,
                BirthDate = contact.BirthDate
            };
        }

        public async Task<IEnumerable<ContactDto>> GetAllAsync()
        {
            var contacts = await _contactRepository.GetAll().ToListAsync();

            if (!contacts.Any())
            {
                return new List<ContactDto>();
            }

            return contacts.Select(p => new ContactDto
            {
                Id = p.Id,
                Name = p.Name,
                MobilePhone = p.MobilePhone,
                JobTitle = p.JobTitle,
                BirthDate = p.BirthDate,
            });
        }
        public async Task UpdateAsync(ContactDto model)
        {
            model = model ?? throw new ArgumentNullException(nameof(model));

            var contact = await _contactRepository.GetEntityAsync(c => c.Id == model.Id);

            if (contact is null)
            {
                throw new NullReferenceException($"'{nameof(model.Id)}' contact not found.");
            }

            if (contact.Name != model.Name)
            {
                contact.Name = model.Name;
            }

            if (contact.MobilePhone != model.MobilePhone)
            {
                contact.MobilePhone = model.MobilePhone;
            }

            if (contact.JobTitle != model.JobTitle)
            {
                contact.JobTitle = model.JobTitle;
            }

            if (contact.BirthDate != model.BirthDate)
            {
                contact.BirthDate = model.BirthDate;
            }

            await _contactRepository.SaveChangesAsync();
        }
        public async Task DeleteAsync(int id)
        {
            var contact = await _contactRepository.GetEntityAsync(c => c.Id == id);
            if (contact is null)
            {
                throw new Exception($"'{nameof(id)}' contact not found.");
            }

            _contactRepository.Delete(contact);
            await _contactRepository.SaveChangesAsync();
        }
    }
}
