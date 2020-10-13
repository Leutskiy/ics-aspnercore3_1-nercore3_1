import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { StateRegistrationComponent } from './state-registration.component';

describe('StateRegistrationComponent', () => {
  let component: StateRegistrationComponent;
  let fixture: ComponentFixture<StateRegistrationComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ StateRegistrationComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(StateRegistrationComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
