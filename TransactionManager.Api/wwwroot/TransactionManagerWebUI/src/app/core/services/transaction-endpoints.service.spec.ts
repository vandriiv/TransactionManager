import { TestBed } from '@angular/core/testing';

import { TransactionEndpointsService } from './transaction-endpoints.service';

describe('TransactionEndpointsService', () => {
  let service: TransactionEndpointsService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(TransactionEndpointsService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
