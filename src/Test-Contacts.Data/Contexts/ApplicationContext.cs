using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Test_Contacts.Data.Configurations;
using Test_Contacts.Data.Models;

namespace Test_Contacts.Data.Contexts
{
    class ApplicationContext: DbContext
    {
        /// <summary>
        /// Contructor with params.
        /// </summary>
        /// <param name="options">Database context options.</param>
        public ApplicationContext(DbContextOptions<ApplicationContext> options)
            : base(options)
        {
        }

        /// <summary>
        /// DbSet for Contacts.
        /// </summary>
        public DbSet<Contact> Contacts { get; set; }

        /// <summary>
        /// Model configuration.
        /// </summary>
        /// <param name="builder"></param>
        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder = builder ?? throw new ArgumentNullException(nameof(builder));
            builder.ApplyConfiguration(new ContactConfiguration());
            base.OnModelCreating(builder);
        }
    }
}
