import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class UrlProviderService {
  constructor() { }

  private currencyBase = "currency";
  get currency_get() { return this.getUrl(this.currencyBase); }

  private currencyConvert = "currencyconvert";
  get currencyConvert_convert() { return this.getUrl(this.currencyConvert);}

  private getUrl(urlPart: string) {
    return location.origin + "/api/" + urlPart;
  }

  public urlFormat(template: string, params: string[] = null) {
    var url = template;

    if (params)
      params.forEach((item, index) => {
        url = url.replace(`{${index}}`, item);
      });

    url = url.replace(/(\{\d+\}?\/)/, "");

    return url;
  }
}
