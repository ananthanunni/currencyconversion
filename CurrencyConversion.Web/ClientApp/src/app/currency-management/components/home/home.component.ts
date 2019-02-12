import { Component, OnInit } from '@angular/core';
import { CurrencyProviderService } from '../../services/currency-provider.service';
import { Currency } from '../../models/Currency';
import { CurrencyConversionProviderService } from '../../services/currency-conversion-provider.service';
import { ConversionRequest } from '../../models/ConversionRequest';
import { ConversionResponse, ConversionStatus } from '../../models/ConversionResponse';
import { MatSnackBar } from '@angular/material';

@Component({
  selector: 'currency-management-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.scss']
})
export class HomeComponent implements OnInit {
  currencyCollection: Currency[] = [];
  isLoading = true;
  isCalculating = false;

  fromAmount: number;
  fromCurrency: Currency;
  toCurrency: Currency;

  conversions: Conversion[] = [];

  currentConversion: Conversion = null;

  constructor(private currencyProvider: CurrencyProviderService, private currencyConvertor: CurrencyConversionProviderService, private snackBar: MatSnackBar) { }

  ngOnInit() {
    this.reset();
  }

  swapCurrencies() {
    let leftCurrency = this.fromCurrency.id;
    let rightCurrency = this.toCurrency.id;

    this.fromCurrency = this.currencyCollection.find(c => c.id === rightCurrency);
    this.toCurrency = this.currencyCollection.find(c => c.id === leftCurrency);
  }

  convert() {
    let request: ConversionRequest = { amount: this.fromAmount, fromCurrency: this.fromCurrency.id, toCurrency: this.toCurrency.id };

    if (request.fromCurrency === request.toCurrency) {
      this.saveConversion(request, { amount: request.amount, status: ConversionStatus.Success, dateUpdated: null });
      return;
    }

    this.isCalculating = true;

    this.currencyConvertor.convert(this.fromCurrency, this.toCurrency, this.fromAmount)
      .subscribe(
        result => {
          this.saveConversion(request, result);
          this.isCalculating = false;

          if (result.status === ConversionStatus.Success)
            this.snackBar.open("Amount converted to new currency.", null, { duration: 1800 });
        },
        err => {
          this.isCalculating = false;
          this.snackBar.open("Conversion could not be completed.");
        }
      );
  }

  private reset() {
    this.isLoading = true;

    this.currencyProvider.getCurrencies()
      .subscribe(currencies => {
        this.currencyCollection = currencies.sort((c1, c2) => c1.name.localeCompare(c2.name));

        if (this.currencyCollection.length > 0)
          this.fromCurrency = this.currencyCollection[0];

        if (this.currencyCollection.length > 1)
          this.toCurrency = this.currencyCollection[1];

        this.isLoading = false;
      });
  }

  private saveConversion(request: ConversionRequest, response: ConversionResponse) {
    this.conversions.splice(0, 0, {
      request: request,
      response: response
    });

    this.currentConversion = this.conversions[0];
  }
}

export class Conversion {
  request: ConversionRequest;
  response: ConversionResponse;
}
