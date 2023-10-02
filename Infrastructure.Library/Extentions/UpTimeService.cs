using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Library.Extentions
{
    public class UpTimeService
    {
        private Stopwatch stopwatch;
        public UpTimeService()
        {
            stopwatch = Stopwatch.StartNew();
            stopwatch.Start();
        }
        public long GetUpTime
        {
            get
            {
                return stopwatch.ElapsedTicks;
            }
        }
    }
}
