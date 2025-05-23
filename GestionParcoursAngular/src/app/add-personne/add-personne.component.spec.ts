import { ComponentFixture, TestBed } from '@angular/core/testing';

import { AddPersonneComponent } from './add-personne.component';

describe('AddPersonneComponent', () => {
  let component: AddPersonneComponent;
  let fixture: ComponentFixture<AddPersonneComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [AddPersonneComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(AddPersonneComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
