using Domain.Library.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistance.Library.EntityConfigurations
{
    public class RequestPayConfiguration : IEntityTypeConfiguration<RequestPay>
    {
        public void Configure(EntityTypeBuilder<RequestPay> builder)
        {
            builder.HasQueryFilter(p => !p.IsDeleted);
        }
    }

}
