using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Test_Contacts.Data.Models;

namespace Test_Contacts.Data.Configurations
{
    class ContactConfiguration : IEntityTypeConfiguration<Contact>
    {
        public void Configure(EntityTypeBuilder<Contact> builder)
        {
            builder = builder ?? throw new ArgumentNullException(nameof(builder));

            builder.Property(contact => contact.Id)
                .UseIdentityColumn();

            builder.Property(contact => contact.Name)
                .IsRequired()
                .HasMaxLength(127);

            builder.Property(contact => contact.MobilePhone)
                .IsRequired()
                .HasMaxLength(127);

            builder.Property(contact => contact.JobTitle)
                .IsRequired()
                .HasMaxLength(127);

            builder.Property(contact => contact.BirthDate)
                .IsRequired()
                .HasColumnType("datetime");
        }
    }
}
