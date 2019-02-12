export class ConversionResponse {
  status: ConversionStatus;
  amount: number;
}

export enum ConversionStatus {
  RateNotAvailable = -1,
  None = 0,
  Success = 1
}
