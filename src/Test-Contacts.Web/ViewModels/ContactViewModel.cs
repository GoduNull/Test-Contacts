using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Test_Contacts.Web.ViewModels
{
    /// <summary>
    /// Contact view model.
    /// </summary>
    public class ContactViewModel
    {
        /// <summary>
        /// Identifier.
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// Name.
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// Mobile Phone.
        /// </summary>
        public string MobilePhone { get; set; }
        /// <summary>
        /// Job Title.
        /// </summary>
        public string JobTitle { get; set; }
        /// <summary>
        /// Birth Date.
        /// </summary>
        public DateTime BirthDate { get; set; }
    }
}
