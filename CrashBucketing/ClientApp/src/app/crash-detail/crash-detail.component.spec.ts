import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { CrashDetailComponent } from './crash-detail.component';

describe('CrashDetailComponent', () => {
  let component: CrashDetailComponent;
  let fixture: ComponentFixture<CrashDetailComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ CrashDetailComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(CrashDetailComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
