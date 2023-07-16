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
    public class ProductFeaturesConfiguration : IEntityTypeConfiguration<ProductFeatures>
    {
        public void Configure(EntityTypeBuilder<ProductFeatures> builder)
        {
            builder.HasQueryFilter(p => !p.IsDeleted);
        }
    }
}
