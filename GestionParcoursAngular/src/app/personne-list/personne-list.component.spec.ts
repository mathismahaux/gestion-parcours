import { ComponentFixture, TestBed } from '@angular/core/testing';

import { PersonneListComponent } from './personne-list.component';

describe('PersonneListComponent', () => {
  let component: PersonneListComponent;
  let fixture: ComponentFixture<PersonneListComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [PersonneListComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(PersonneListComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
