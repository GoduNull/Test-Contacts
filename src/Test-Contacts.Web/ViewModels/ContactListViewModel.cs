using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Test_Contacts.Web.ViewModels
{
    /// <summary>
    /// Contact list view model.
    /// </summary>
    public class ContactListViewModel
    {
        /// <summary>
        /// Contacts.
        /// </summary>
        public IEnumerable<ContactViewModel> Contacts { get; set; }
    }
}
