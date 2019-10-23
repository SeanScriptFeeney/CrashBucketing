import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { CrashBucketsComponent } from './crash-buckets.component';

describe('CrashBucketsComponent', () => {
  let component: CrashBucketsComponent;
  let fixture: ComponentFixture<CrashBucketsComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ CrashBucketsComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(CrashBucketsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
