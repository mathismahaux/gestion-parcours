import { ComponentFixture, TestBed } from '@angular/core/testing';

import { AddParcoursComponent } from './add-parcours.component';

describe('AddParcoursComponent', () => {
  let component: AddParcoursComponent;
  let fixture: ComponentFixture<AddParcoursComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [AddParcoursComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(AddParcoursComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
