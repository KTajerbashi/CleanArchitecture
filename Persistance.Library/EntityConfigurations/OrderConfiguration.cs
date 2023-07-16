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
    public class OrderConfiguration : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            builder.HasQueryFilter(p => !p.IsDeleted);


            builder.HasOne(p => p.User)
                .WithMany(p => p.Orders)
                .OnDelete(DeleteBehavior.NoAction);


            builder.HasOne(p => p.RequestPay)
                .WithMany(p => p.Orders)
                .OnDelete(DeleteBehavior.NoAction);
        }
    }

}
