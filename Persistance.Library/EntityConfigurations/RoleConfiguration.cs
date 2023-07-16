using Common.Library;
using Domain.Library.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistance.Library.EntityConfigurations
{
    public class RoleConfiguration : IEntityTypeConfiguration<Role>
    {
        public void Configure(EntityTypeBuilder<Role> builder)
        {
            builder.HasData(new Role { ID = 1, Title = nameof(UserRolesSeed.Admin) });
            builder.HasData(new Role { ID = 2, Title = nameof(UserRolesSeed.Operator) });
            builder.HasData(new Role { ID = 3, Title = nameof(UserRolesSeed.Customer) });
            builder.HasQueryFilter(p => !p.IsDeleted);
        }
    }
}
