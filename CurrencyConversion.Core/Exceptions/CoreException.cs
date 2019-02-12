using System;

namespace CurrencyConversion.Core.Exceptions
{
    public class CoreException : Exception
    {
        public DateTime Timestamp { get; }
        public int ErrorCode { get; }

        public CoreException(string message = null, Exception innerException = null)
            : base(message ?? "An unhandled exception occured.", innerException)
        {
            Timestamp = DateTime.UtcNow;
            ErrorCode = -1;
        }

        public override string ToString() => $"[{ErrorCode} {this.GetType().Name}] {Message}";
    }
}
