using CleanArchitecture.Domain.Library.BaseEntities;
using CleanArchitecture.Domain.Library.Enums;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace CleanArchitecture.Domain.Library.Entities.GEN
{
    [Table("Files", Schema = "GEN"), Description("فایلها")]
    public class FileObject : GeneralEntity
    {
        public FileTypeEnum FileTypeEnum { get; set; }
    }
    public class FileObjectConfiguration : IEntityTypeConfiguration<FileObject>
    {
        public void Configure(EntityTypeBuilder<FileObject> builder)
        {
        }
    }
}
