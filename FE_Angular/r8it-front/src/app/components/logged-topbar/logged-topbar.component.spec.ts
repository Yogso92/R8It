import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { LoggedTopbarComponent } from './logged-topbar.component';

describe('LoggedTopbarComponent', () => {
  let component: LoggedTopbarComponent;
  let fixture: ComponentFixture<LoggedTopbarComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ LoggedTopbarComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(LoggedTopbarComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
