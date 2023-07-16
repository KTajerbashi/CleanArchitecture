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
    public class HomePageImagesConfiguration : IEntityTypeConfiguration<HomePageImages>
    {
        public void Configure(EntityTypeBuilder<HomePageImages> builder)
        {
            builder.HasQueryFilter(p => !p.IsDeleted);
        }
    }
}
