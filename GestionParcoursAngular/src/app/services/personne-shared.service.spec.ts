import { TestBed } from '@angular/core/testing';

import { PersonneSharedService } from './personne-shared.service';

describe('PersonneSharedService', () => {
  let service: PersonneSharedService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(PersonneSharedService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
