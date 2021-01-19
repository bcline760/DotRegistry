using System;

using log4net;

namespace DotRegistry.Core.Logging
{
    public static class LoggingExtensions
    {
        public static Exception IfNotLoggedThenLog(this Exception ex, ILog log)
        {
            if (ex == null || ex.GetType() == typeof(LoggedException))
                return ex;

            log.Error(ex.Message, ex);

            return new LoggedException("An error has occured", ex);
        }
    }
}
