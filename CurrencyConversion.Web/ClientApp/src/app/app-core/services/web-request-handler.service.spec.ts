import { TestBed } from '@angular/core/testing';

import { WebRequestHandlerService } from './web-request-handler.service';

describe('WebRequestHandlerService', () => {
  beforeEach(() => TestBed.configureTestingModule({}));

  it('should be created', () => {
    const service: WebRequestHandlerService = TestBed.get(WebRequestHandlerService);
    expect(service).toBeTruthy();
  });
});
