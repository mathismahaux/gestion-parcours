import { ComponentFixture, TestBed } from '@angular/core/testing';

import { CalculateStatisticsComponent } from './calculate-statistics.component';

describe('CalculateStatisticsComponent', () => {
  let component: CalculateStatisticsComponent;
  let fixture: ComponentFixture<CalculateStatisticsComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [CalculateStatisticsComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(CalculateStatisticsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
