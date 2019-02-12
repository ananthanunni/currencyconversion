import { Component, OnInit, Input } from '@angular/core';
import { Conversion } from '../home/home.component';
import { Currency } from '../../models/Currency';
import { ConversionStatus } from '../../models/ConversionResponse';

@Component({
  selector: 'currency-management-conversion-result-display',
  templateUrl: './conversion-result-display.component.html',
  styleUrls: ['./conversion-result-display.component.scss']
})
export class ConversionResultDisplayComponent implements OnInit {

  constructor() { }

  @Input("model")
  model: Conversion;

  @Input("currencyCollection")
  currencyCollection: Currency[];

  ngOnInit() {
  }

  get currencyLabel() {
    let currency = this.currencyCollection.find(c => c.id === this.model.request.toCurrency);

    return currency.symbol || currency.code || currency.name;
  }

  get isSuccess() { return this.model.response.status === ConversionStatus.Success; }

  get errorMessage() {
    switch (this.model.response.status) {
      case ConversionStatus.RateNotAvailable: return "Rate not available";

      default: return "";
    }
  }

  formatCurrency(value:number) {
    return value.toFixed(6);
  }
}
