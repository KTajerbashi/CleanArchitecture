using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Library.DatabaseContextApplication.DataSeed
{
    public static class DataSeedConfiguration
    {
        public static void DataSeeds(ModelBuilder modelBuilder)
        {
            //modelBuilder.Entity<RegionsEvaluationScore>().HasData(new RegionsEvaluationScore { ID = 1, Key = nameof(ReportingKeysSeed.ActionType), Title = ReportingKeysSeed.ActionType, IsDeleted = false, IsActive = true });
        }
    }
}
