using System;

namespace CurrencyConversion.Dto.Conversion
{
    public class ConversionResponse : IDto
    {
        public ConversionStatus Status { get; set; }
        public decimal Amount { get; set; }
        public DateTime DateUpdated { get; set; }

        public static ConversionResponse ExchangeRateUnavailable()
        {
            return new ConversionResponse
            {
                Status = ConversionStatus.RateNotAvailable
            };
        }
    }

    public enum ConversionStatus
    {
        RateNotAvailable = -1,
        None = 0,
        Success = 1
    }
}
