using System;

namespace CurrencyConversion.Dto.Conversion
{
    public class ConversionResponse : IDto
    {
        public ConversionStatus Status { get; set; }
        public decimal Amount { get; set; }
        public DateTime DateUpdated { get; set; }

        public static ConversionResponse CreateErrorResponse(ConversionStatus status)
        {
            return new ConversionResponse
            {
                Status = status
            };
        }
    }

    public enum ConversionStatus
    {
        TargetCurrencyInvalid = -3,
        SourceCurrencyInvalid = -2,
        RateNotAvailable = -1,

        None = 0,

        Success = 1
    }
}
