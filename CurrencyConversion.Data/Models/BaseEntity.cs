﻿namespace CurrencyConversion.Data.Models
{
    public abstract class BaseEntity : IEntity
    {
        public long Id { get; set; }
    }
}
