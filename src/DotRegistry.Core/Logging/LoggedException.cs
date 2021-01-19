using System;
namespace DotRegistry.Core.Logging
{
    public class LoggedException : Exception
    {
        public LoggedException(string message): base(message)
        {
        }

        public LoggedException(string message, Exception ex) : base(message, ex)
        {

        }
    }
}
