using CurrencyConversion.Core.Exceptions;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace CurrencyConversion.Core.Logging
{
    public interface ILogger
    {
        void Log(CoreException exception);
        void Log(string message, LogLevel severity);

        void Debug(string message);
        void Info(string message);
        void Success(string message);
        void Warning(string message);
        void Error(string message);

        Stopwatch TrackTimeStart();
        TimeSpan TrackTimeEnd(string message = "", LogLevel level = LogLevel.Debug, Stopwatch watch = null);

        void Reset();
    }
}
