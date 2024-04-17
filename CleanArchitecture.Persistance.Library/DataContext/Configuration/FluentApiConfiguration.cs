using Microsoft.EntityFrameworkCore;

namespace CleanArchitecture.Infrastructure.Library.DatabaseContextApplication.Configuration
{
    public static class FluentApiConfiguration
    {
        public static void Configurations(ModelBuilder builder)
        {
            #region LOG
            //builder.ApplyConfiguration(new NLogDataConfiguration());
            //builder.ApplyConfiguration(new SystemLogConfiguration());
            #endregion
        }
    }
}
