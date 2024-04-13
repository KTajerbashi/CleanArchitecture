namespace CleanArchitecture.WebApp.Models
{
    public class TimerService
    {
        /// <summary>
        /// تعداد اجرای سرویس
        /// </summary>
        private int MaxCount { get; set; }
        /// <summary>
        /// تعداد اجرای
        /// </summary>
        private int InvokeCount { get; set; }

        public TimerService(int count)
        {
            MaxCount = count;
        }
        /// <summary>
        /// وضعیت
        /// </summary>
        public string State { get; set; }
        /// <summary>
        /// از زمان اجرای برنامه چند دقیقه بعد اجراء شود
        /// </summary>
        public int DueTime { get; set; }
        /// <summary>
        /// هر چند ملی ثانیه یکبار این تایمر اجرا شود
        /// </summary>
        public int Period { get; set; }

        public void Execute(object stateInfo)
        {
            AutoResetEvent autoResetEvent = (AutoResetEvent)stateInfo;
            Random random = new Random();
            Console.WriteLine($"Gold Price in {DateTime.Now.ToString("h:mm:ss.fff")} : {random.Next(5000,5010)} =====> {(++InvokeCount).ToString()}");
            if (InvokeCount == MaxCount)
            {
                InvokeCount = 0;
                autoResetEvent.Set();
            }
        }
    }
}
