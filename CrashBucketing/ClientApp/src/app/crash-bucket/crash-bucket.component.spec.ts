import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { CrashBucketComponent } from './crash-bucket.component';

describe('CrashBucketComponent', () => {
  let component: CrashBucketComponent;
  let fixture: ComponentFixture<CrashBucketComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ CrashBucketComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(CrashBucketComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
