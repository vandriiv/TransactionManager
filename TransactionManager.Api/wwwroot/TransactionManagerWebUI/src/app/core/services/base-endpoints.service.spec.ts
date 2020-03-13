import { TestBed } from '@angular/core/testing';

import { BaseEndpointsService } from './base-endpoints.service';

describe('BaseEndpointsService', () => {
  let service: BaseEndpointsService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(BaseEndpointsService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
