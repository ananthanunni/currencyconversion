import { TestBed } from '@angular/core/testing';

import { CurrencyConversionProviderService } from './currency-conversion-provider.service';

describe('CurrencyConversionProviderService', () => {
  beforeEach(() => TestBed.configureTestingModule({}));

  it('should be created', () => {
    const service: CurrencyConversionProviderService = TestBed.get(CurrencyConversionProviderService);
    expect(service).toBeTruthy();
  });
});
