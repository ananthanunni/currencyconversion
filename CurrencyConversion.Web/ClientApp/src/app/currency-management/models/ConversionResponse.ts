export class ConversionResponse {
  status: ConversionStatus;
  amount: number;
  dateUpdated: Date;
}

export enum ConversionStatus {
  RateNotAvailable = -1,
  None = 0,
  Success = 1
}
