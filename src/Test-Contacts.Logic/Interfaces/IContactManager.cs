using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Test_Contacts.Logic.ModelsDto;

namespace Test_Contacts.Logic.Interfaces
{
    /// <summary>
    /// Contact manager.
    /// </summary>
    public interface IContactManager
    {
        /// <summary>
        /// Create contact.
        /// </summary>
        /// <param name="model">Contact data transfer object.</param>
        Task CreateAsync(ContactDto model);

        /// <summary>
        /// Get contact by identifier.
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Contact data transfer object.</returns>
        Task<ContactDto> GetByContactIdAsync(int id);

        /// <summary>
        /// Get all contacts .
        /// </summary>
        /// <returns>Contact data transfer objects.</returns>
        Task<IEnumerable<ContactDto>> GetAllAsync();

        /// <summary>
        /// Update contact.
        /// </summary>
        /// <param name="model">Contact data transfer object.</param>
        Task UpdateAsync(ContactDto model);

        /// <summary>
        /// Delete contact by identifier.
        /// </summary>
        /// <param name="id">Contact identifier.</param>
        Task DeleteAsync(int id);
    }
}
