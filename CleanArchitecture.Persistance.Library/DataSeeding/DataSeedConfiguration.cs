using Microsoft.EntityFrameworkCore;

namespace CleanArchitecture.Persistence.Library.DataSeeding
{
    public static class DataSeedConfiguration
    {
        public static void DataSeeds(ModelBuilder modelBuilder)
        {
            //modelBuilder.Entity<RegionsEvaluationScore>().HasData(new RegionsEvaluationScore { ID = 1, Key = nameof(ReportingKeysSeed.ActionType), Title = ReportingKeysSeed.ActionType, IsDeleted = false, IsActive = true });
        }
    }
}
