namespace Identity.Library.Services.BackgroundTask.TimerService
{
    public class TimerService
    {
        private int MaxCount { get; set; }
        private int InvokeCount { get; set; }
        public TimerService(int maxCount)
        {
            MaxCount = maxCount;

        }

        public void Execute(object stateInfo)
        {
            var result = string.Empty;
            AutoResetEvent autoResetEvent = (AutoResetEvent)stateInfo;
            Random random = new Random();
            result = $@"    
                            InvokeCount : {InvokeCount}
                            ++InvokeCount : {++InvokeCount}
                            Random Time (5000,5010): {random.Next(5000, 5010)}
                            Now : {DateTime.Now.ToString("h:mm:ss.fff")}
                            ===================="
            ;
            Console.WriteLine(result);
            if (InvokeCount == MaxCount)
            {
                InvokeCount = 0;
                autoResetEvent.Set();
            }
        }
    }
}
