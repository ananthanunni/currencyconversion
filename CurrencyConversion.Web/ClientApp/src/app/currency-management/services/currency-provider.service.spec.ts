import { TestBed } from '@angular/core/testing';

import { CurrencyProviderService } from './currency-provider.service';

describe('CurrencyProviderService', () => {
  beforeEach(() => TestBed.configureTestingModule({}));

  it('should be created', () => {
    const service: CurrencyProviderService = TestBed.get(CurrencyProviderService);
    expect(service).toBeTruthy();
  });
});
