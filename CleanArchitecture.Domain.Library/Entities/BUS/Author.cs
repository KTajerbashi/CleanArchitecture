using CleanArchitecture.Domain.Library.BaseEntities;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace CleanArchitecture.Domain.Library.Entities.BUS
{
    [Table("Authors", Schema = "BUS"), Description("نویسنده گان")]
    public class Author : BaseEntity
    {
    }
    //public class AuthorConfiguration : IEntityTypeConfiguration<Author>
    //{
    //    public void Configure(EntityTypeBuilder<Author> builder)
    //    {
    //    }
    //}
}
