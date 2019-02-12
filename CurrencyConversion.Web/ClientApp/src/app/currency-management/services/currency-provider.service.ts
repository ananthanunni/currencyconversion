import { Injectable } from '@angular/core';
import { UrlProviderService } from '../../app-core/services/url-provider.service';
import { WebRequestHandlerService } from '../../app-core/services/web-request-handler.service';
import { Currency } from '../models/Currency';

@Injectable({
  providedIn: 'root'
})
export class CurrencyProviderService {

  constructor(private urlProvider: UrlProviderService, private webRequestHandler: WebRequestHandlerService) { }

  getCurrencies() {
    return this.webRequestHandler.get<Currency[]>(this.urlProvider.currency_get);
  }
}
