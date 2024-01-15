namespace Undersoft.SDK.Logging
{
    using Serilog.Events;
    using System.Collections.Concurrent;
    using System.Text.Json;
    using System.Text.Json.Serialization;
    using System.Threading;

    public static partial class Log
    {
        private static readonly int BACK_LOG_DAYS = -1;
        private static readonly int BACK_LOG_HOURS = -1;
        private static readonly int BACK_LOG_MINUTES = -1;
        private static readonly JsonSerializerOptions jsonOptions;
        private static int _logLevel = 2;
        private static bool cleaningEnabled = false;
        private static DateTime clearLogTime;
        private static ILogHandler handler { get; set; }

        private static ConcurrentQueue<Starlog> logQueue = new ConcurrentQueue<Starlog>();

        private static bool threadLive;

        public static DateTime Clock = DateTime.Now;

        static Log()
        {
            jsonOptions = JsonOptionsBuilder();
            handler = new LogHandler(jsonOptions, LogEventLevel.Information);
            clearLogTime = DateTime.Now
                .AddDays(BACK_LOG_DAYS)
                .AddHours(BACK_LOG_HOURS)
                .AddMinutes(BACK_LOG_MINUTES);
            Start(_logLevel);
        }

        public static void Add(LogEventLevel logLevel, string category, string message, ILogSate state)
        {
            var _log = new Starlog()
            {
                Level = logLevel,
                Sender = category,
                State = state,
                Message = message
            };

            logQueue.Enqueue(_log);
        }

        public static void ClearLog()
        {
            if (!cleaningEnabled || handler == null)
                return;

            try
            {
                if (DateTime.Now.Day != clearLogTime.Day)
                {
                    if (DateTime.Now.Hour != clearLogTime.Hour)
                    {
                        if (DateTime.Now.Minute != clearLogTime.Minute)
                        {
                            handler.Clean(clearLogTime);
                            clearLogTime = DateTime.Now;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static void CreateHandler(LogEventLevel level)
        {
            handler = new LogHandler(jsonOptions, level);
        }

        public static void SetLevel(int logLevel)
        {
            _logLevel = logLevel;
        }

        public static void Start(int logLevel)
        {
            CreateHandler(LogEventLevel.Information);
            SetLevel(logLevel);
            if (!threadLive)
            {
                threadLive = true;
                Task.Run(logging);
            }
        }

        private static async void logging()
        {
            try
            {
                while (threadLive)
                {
                    Clock = DateTime.Now;
                    await Task.Delay(1000);
                    int count = logQueue.Count;
                    for (int i = 0; i < count; i++)
                    {
                        Starlog log;
                        if (logQueue.TryDequeue(out log))
                        {
                            if (handler != null)
                            {
                                handler.Write(log);
                            }
                        }
                    }

                    if (cleaningEnabled)
                        ClearLog();
                }
            }
            catch (Exception ex) { }
        }

        private static JsonSerializerOptions JsonOptionsBuilder()
        {
            var options = new JsonSerializerOptions();
            options.Converters.Add(new LogExceptionConverter());
            options.PropertyNamingPolicy = JsonNamingPolicy.CamelCase;
            options.DefaultIgnoreCondition = System.Text.Json
                .Serialization
                .JsonIgnoreCondition
                .WhenWritingNull;
            options.ReferenceHandler = ReferenceHandler.IgnoreCycles;
            return options;
        }
    }
}
