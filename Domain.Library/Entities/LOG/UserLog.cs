using Domain.Library.BaseEntities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Library.Entities.LOG
{
    [Table("UserLogs", Schema = "LOG")]
    public class UserLog : BaseEntity
    {
    }
    public class UserLogConfiguration : IEntityTypeConfiguration<UserLogConfiguration>
    {
        public void Configure(EntityTypeBuilder<UserLogConfiguration> builder)
        {
        }
    }




}