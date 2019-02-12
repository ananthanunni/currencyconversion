import { Injectable } from '@angular/core';
import { Currency } from '../models/Currency';
import { UrlProviderService } from '../../app-core/services/url-provider.service';
import { WebRequestHandlerService } from '../../app-core/services/web-request-handler.service';
import { ConversionRequest } from '../models/ConversionRequest';
import { ConversionResponse } from '../models/ConversionResponse';

@Injectable({
  providedIn: 'root'
})
export class CurrencyConversionProviderService {
  constructor(private urlProvider:UrlProviderService, private webRequestHandler:WebRequestHandlerService) { }

  convert(fromCurrency: Currency, toCurrency: Currency, amount: number) {
    return this.webRequestHandler.post<ConversionRequest, ConversionResponse>(this.urlProvider.currencyConvert_convert, {
      amount: amount,
      fromCurrency: fromCurrency.id,
      toCurrency:toCurrency.id
    });
  }
}
