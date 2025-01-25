using CleanArchitecture.Core.Domain.Library.BaseCoreDomain;
using System.ComponentModel.DataAnnotations.Schema;

namespace CleanArchitecture.Core.Domain.Library.Entities.Identity;

[Table("", Schema = "")]
public class UserRoleEntity : AuditableEntity
{

}
