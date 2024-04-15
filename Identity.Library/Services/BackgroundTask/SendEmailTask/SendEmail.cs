using System.Globalization;

namespace Identity.Library.Services.BackgroundTask.SendEmailTask
{
    public class SendEmail : IHostedService, IDisposable
    {
        private readonly ILogger<SendEmail> _logger;
        private Timer _timer = null;
        private int ExecuteCount = 0;
        public SendEmail(ILogger<SendEmail> logger)
        {
            _logger = logger;
        }
        /// <summary>
        /// بعد از اجرای برنامه اجرا میشود
        /// </summary>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public Task StartAsync(CancellationToken cancellationToken)
        {
            _logger.LogInformation("Background Task is Running ...");
            /// ایمیل هارا ارسال کن
            /// وضعیت خالی
            /// چقدر زمان بگذرد تا اجرا شود
            /// هر جند  ثانیه این تسک اجرا شود
            _timer = new Timer(SendMail, null, TimeSpan.FromSeconds(2), TimeSpan.FromSeconds(5));

            return Task.CompletedTask;
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            _logger.LogInformation($"Background Task is Stopping.");
            // هنگام تمام شدن اجرای نرم افزار این کد اجرا شده
            // تا از اجرای مجدد تسک خود داری کند
            //  تسک نیز از بین میرود
            _timer.Change(Timeout.Infinite, 0);
            return Task.CompletedTask;
        }
        /// <summary>
        /// منطق تسک پس زمینه
        /// </summary>
        /// <param name="state"></param>
        public void SendMail(object? state)
        {
            var Count = Interlocked.Increment(ref ExecuteCount);
            _logger.LogWarning($"SendEmail is Running... Count  {Count}");
            Thread.Sleep(100);
            _logger.LogInformation($"Emails Sent Success... Count {Count}");
        }
        /// <summary>
        /// پیدا کردن زمان ست شده با تفاوت زمانی اجرا و زمان ست شده
        /// </summary>
        /// <returns></returns>
        private TimeSpan getScheduledParsedTime()
        {
            string[] formats ={@"hh\:mm\:ss" , "hh\\:mm"};
            string jobStartTime = "10:13";
            TimeSpan.TryParseExact(jobStartTime,formats,CultureInfo.InvariantCulture,out TimeSpan ScheduledTimespan);
            return ScheduledTimespan;
        }
        /// <summary>
        /// محاسبه زمان اجرا بعدی از تایم الان تا تایم ست شده
        /// </summary>
        /// <returns></returns>
        private TimeSpan getJobRunDelay()
        {
            TimeSpan scheduledParsedTime = getScheduledParsedTime();
            TimeSpan currentTimeOftheDay = TimeSpan.Parse(DateTime.Now.TimeOfDay.ToString("hh\\:mm"));
            TimeSpan delayTime = scheduledParsedTime >= currentTimeOftheDay
                ? scheduledParsedTime - currentTimeOftheDay
                : new TimeSpan(24,0,0)-currentTimeOftheDay + scheduledParsedTime;
            return delayTime;
        }
        /// <summary>
        /// از بین رفتن تایمر
        /// </summary>
        public void Dispose()
        {
            _timer.Dispose();
        }
    }
}
