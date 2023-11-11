using Microsoft.AspNetCore.Identity;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Library.Entities.SEC
{
    /// <summary>
    /// مدعی نقش
    /// </summary>
    [Table("RoleClaim", Schema = "SEC"), Description("مدعی نقش")]
    public class RoleClaim : IdentityRoleClaim<long>
    {

        [Description("کلید")]
        public Guid Guid { get; set; }


        [Description("حذف شده"), DefaultValue(false)]
        public bool IsDeleted { get; set; }

        [Description("فعال"), DefaultValue(false)]
        public bool IsActive { get; set; }

        
    }
}
