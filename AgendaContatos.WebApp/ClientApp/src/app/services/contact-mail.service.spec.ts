import { TestBed, inject } from '@angular/core/testing';

import { ContactMailService } from './contact-mail.service';

describe('ContactMailService', () => {
  beforeEach(() => {
    TestBed.configureTestingModule({
      providers: [ContactMailService]
    });
  });

  it('should be created', inject([ContactMailService], (service: ContactMailService) => {
    expect(service).toBeTruthy();
  }));
});
