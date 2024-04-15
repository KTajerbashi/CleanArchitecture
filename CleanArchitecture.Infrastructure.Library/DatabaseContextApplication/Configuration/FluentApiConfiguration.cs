using Domain.Library.Entities.BUS;
using Domain.Library.Entities.CNT;
using Domain.Library.Entities.GEN;
using Domain.Library.Entities.LOG;
using Domain.Library.Entities.RPT;
using Microsoft.EntityFrameworkCore;
using static Domain.Library.Entities.LOG.DataHistory;

namespace CleanArchitecture.Infrastructure.Library.DatabaseContextApplication.Configuration
{
    public static class FluentApiConfiguration
    {
        public static void Configurations(ModelBuilder builder)
        {
            #region CNT
            builder.ApplyConfiguration(new MenuLinkConfiguration());
            builder.ApplyConfiguration(new MenuRoleConfiguration());
            #endregion
            #region GEN
            builder.ApplyConfiguration(new FileObjectConfiguration());
            builder.ApplyConfiguration(new PictureConfiguration());
            #endregion
            #region RPT
            builder.ApplyConfiguration(new UserReportConfiguration());
            builder.ApplyConfiguration(new ProductReportConfiguration());
            builder.ApplyConfiguration(new ReportConfiguration());
            #endregion
            #region BUS
            builder.ApplyConfiguration(new AuthorConfiguration());
            builder.ApplyConfiguration(new CategoryConfiguration());
            builder.ApplyConfiguration(new FactorConfiguration());
            builder.ApplyConfiguration(new FactorProductConfiguration());
            builder.ApplyConfiguration(new ProductConfiguration());
            builder.ApplyConfiguration(new ProductDetailConfiguration());
            builder.ApplyConfiguration(new ProductTypeConfiguration());
            #endregion
            #region LOG
            builder.ApplyConfiguration(new NLogDataConfiguration());
            builder.ApplyConfiguration(new SystemLogConfiguration());
            #endregion
        }
    }
}
