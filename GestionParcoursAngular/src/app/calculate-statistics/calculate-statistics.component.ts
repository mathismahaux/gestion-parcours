import { Component } from '@angular/core';
import {DtoOutputAverageTime} from '../dto-output-average-time';
import {SessionService} from '../services/session.service';
import {FormsModule} from '@angular/forms';

@Component({
  selector: 'app-calculate-statistics',
  standalone: true,
  imports: [
    FormsModule
  ],
  templateUrl: './calculate-statistics.component.html',
  styleUrl: './calculate-statistics.component.css'
})
export class CalculateStatisticsComponent {
  personneId: number | null = null;
  parcoursId: number | null = null;
  type: string = '';
  averageTimeResult: DtoOutputAverageTime | null = null;
  errorMessage: string | null = null;

  constructor(private sessionService: SessionService) {}

  calculateAverageTime() {
    if (this.personneId && this.parcoursId && this.type) {
      this.sessionService.getAverageTime(this.personneId, this.parcoursId, this.type)
        .subscribe({
          next: (result) => {
            this.averageTimeResult = result;
            this.errorMessage = null;
          },
          error: (err) => {
            this.errorMessage = 'Could not retrieve statistics. Please check the inputs.';
            this.averageTimeResult = null;
          }
        });
    } else {
      this.errorMessage = 'Please provide all required inputs.';
    }
  }

}
