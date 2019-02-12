export class ConversionResponse {
  status: ConversionStatus;
  amount: number;
  dateUpdated: Date;
}

export enum ConversionStatus {
  TargetCurrencyInvalid = -3,
  SourceCurrencyInvalid = -2,
  RateNotAvailable = -1,

  None = 0,

  Success = 1
}
