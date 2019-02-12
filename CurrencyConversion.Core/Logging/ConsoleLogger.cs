using CurrencyConversion.Core.Exceptions;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;

namespace CurrencyConversion.Core.Logging
{
    public class ConsoleLogger : ILogger
    {
        private ConsoleColor _debugColor = ConsoleColor.Magenta;
        private ConsoleColor _errorColor = ConsoleColor.Red;
        private ConsoleColor _infoColor = ConsoleColor.DarkCyan;
        private ConsoleColor _warningColor = ConsoleColor.Yellow;
        private ConsoleColor _successColor = ConsoleColor.Green;

        private List<TimeTrackingBlock> _watchList = new List<TimeTrackingBlock>();

        public void Reset()
        {
            _watchList.Clear();
        }

        public void Debug(string message) => Write(message, "Debug", _debugColor);

        public void Error(string message) => Write(message, "Error", _errorColor);

        public void Info(string message) => Write(message, "Info", _infoColor);

        public void Log(CoreException exception) => Write(exception.ToString(), "Exception", _errorColor);

        public void Log(string message, LogLevel severity)
        {
            Write(message, $"Log-{severity}");
        }

        public void Success(string message) => Write(message, "Success", _successColor);

        public void Warning(string message) => Write(message, "Warning", _warningColor);

        private void Write(string message, string prefix, ConsoleColor? color = null)
        {
            Console.ResetColor();

            System.Diagnostics.Debug.WriteLine($"{(!string.IsNullOrWhiteSpace(prefix) ? "[" + prefix.ToUpper() + "] : " : "")}{message}");

            if (color.HasValue)
                Console.BackgroundColor = color.Value;

            Console.WriteLine($"{(!string.IsNullOrWhiteSpace(prefix) ? "[" + prefix.ToUpper() + "] : " : "")}{message}");

            Console.ResetColor();
        }

        public Stopwatch TrackTimeStart()
        {
            var block = new TimeTrackingBlock();
            _watchList.Add(block);
            return block.Start();
        }

        /// <summary>
        /// Stops time tracking and returns the elapsed TimeSpan.
        /// </summary>
        /// <param name="watch">Not null takes an item from watch list randomly. If null, the outermost tracker is taken.</param>
        public TimeSpan TrackTimeEnd(string message = "", LogLevel level = LogLevel.Debug, Stopwatch watch = null)
        {
            TimeTrackingBlock block = null;

            if (watch != null)
                block = _watchList.FirstOrDefault(t => t.Watch == watch);
            else
                block = _watchList.LastOrDefault();

            if (block == null)
            {
                Log($"Elapsed (-1 No Tracker);{message}", level);
                return TimeSpan.MinValue;
            }

            var result = block.End();

            Log($"Elapsed ({result.ToString("c")});{message}", level);

            _watchList.Remove(block);

            return result;
        }

        private class TimeTrackingBlock
        {
            public Stopwatch Watch { get; private set; }

            public TimeTrackingBlock()
            {
                Watch = new Stopwatch();
            }

            public Stopwatch Start()
            {
                Watch.Start();
                return Watch;
            }

            public TimeSpan End()
            {
                Watch.Stop();
                return Watch.Elapsed;
            }
        }
    }
}
