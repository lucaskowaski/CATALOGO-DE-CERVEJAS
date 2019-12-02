import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { IngredientRegisterComponent } from './ingredient-register.component';

describe('IngredientRegisterComponent', () => {
  let component: IngredientRegisterComponent;
  let fixture: ComponentFixture<IngredientRegisterComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ IngredientRegisterComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(IngredientRegisterComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
