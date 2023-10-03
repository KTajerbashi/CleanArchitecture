using Application.Library.Interfaces.SEC.Person.DTOs;
using Common.Library.Utilities;
using Domain.Library.Entities.SEC;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistance.Library.EntityConfigurations.SEC
{
    public class PersonConfiguration : IEntityTypeConfiguration<Person>
    {
        public void Configure(EntityTypeBuilder<Person> builder)
        {
            builder.HasQueryFilter(x => x.IsDeleted == false);
            builder.HasComment(ExtentionUtilities.GetDescription(typeof(Person)));

            builder.HasIndex(i => i.ID);
            builder.HasMany(p => p.PersonRoles).WithOne(r => r.Person).HasForeignKey(f => f.PersonID);
            builder.HasMany(p => p.Pictures).WithOne(r => r.Person).HasForeignKey(f => f.PersonID);
        }
    }
}
