import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { BeerRegisterComponent } from './beer-register.component';

describe('BeerRegisterComponent', () => {
  let component: BeerRegisterComponent;
  let fixture: ComponentFixture<BeerRegisterComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ BeerRegisterComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(BeerRegisterComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
