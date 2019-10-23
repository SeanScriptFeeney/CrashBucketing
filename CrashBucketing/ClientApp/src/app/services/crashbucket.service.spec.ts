import { TestBed } from '@angular/core/testing';

import { CrashbucketService } from './crashbucket.service';

describe('CrashbucketService', () => {
  beforeEach(() => TestBed.configureTestingModule({}));

  it('should be created', () => {
    const service: CrashbucketService = TestBed.get(CrashbucketService);
    expect(service).toBeTruthy();
  });
});
