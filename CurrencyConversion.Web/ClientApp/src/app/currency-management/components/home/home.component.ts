import { Component, OnInit } from '@angular/core';
import { CurrencyProviderService } from '../../services/currency-provider.service';
import { Currency } from '../../models/Currency';
import { CurrencyConversionProviderService } from '../../services/currency-conversion-provider.service';
import { ConversionRequest } from '../../models/ConversionRequest';
import { ConversionResponse } from '../../models/ConversionResponse';

@Component({
  selector: 'currency-management-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.scss']
})
export class HomeComponent implements OnInit {
  currencyCollection: Currency[]=[];
  isLoading = true;
  isCalculating = false;

  fromAmount: number;
  fromCurrency: Currency;
  toCurrency: Currency;

  conversions: Conversion[] = [];

  currentConversion: Conversion = null;

  constructor(private currencyProvider: CurrencyProviderService, private currencyConvertor:CurrencyConversionProviderService) { }

  ngOnInit() {
    this.reset();
  }

  convert() {
    this.isCalculating = true;

    let request: ConversionRequest = { amount: this.fromAmount, fromCurrency: this.fromCurrency.id, toCurrency: this.toCurrency.id };

    this.currencyConvertor.convert(this.fromCurrency, this.toCurrency, this.fromAmount)
      .subscribe(result => {        
        this.conversions.push({
          request: request,
          response: result
        });

        this.currentConversion = this.conversions[this.conversions.length - 1];
      });
  }

  private reset() {
    this.isLoading = true;

    this.currencyProvider.getCurrencies()
      .subscribe(currencies => {
        this.currencyCollection = currencies;
        this.isLoading = false;
      });
  }
}

export class Conversion {
  request: ConversionRequest;
  response: ConversionResponse;
}
