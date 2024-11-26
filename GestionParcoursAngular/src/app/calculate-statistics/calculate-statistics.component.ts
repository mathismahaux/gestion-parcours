import {Component, OnInit} from '@angular/core';
import {Stats} from '../stats';
import {SessionService} from '../services/session.service';
import {FormBuilder, FormGroup, FormsModule, ReactiveFormsModule, Validators} from '@angular/forms';
import {PersonneService} from '../services/personne.service';
import {ParcoursService} from '../services/parcours.service';
import {Personne} from '../personne';
import {Parcours} from '../parcours';

@Component({
  selector: 'app-calculate-statistics',
  standalone: true,
  imports: [
    FormsModule,
    ReactiveFormsModule
  ],
  templateUrl: './calculate-statistics.component.html',
  styleUrl: './calculate-statistics.component.css'
})
export class CalculateStatisticsComponent implements OnInit {
  calculateStatsForm : FormGroup;
  personnes: Personne[] = [];
  parcours: Parcours[] = [];
  successMessage: string = ''
  errorMessage: string = '';
  result: Stats | null = null;

  constructor(
    private sessionService: SessionService,
    private personneService: PersonneService,
    private parcoursService: ParcoursService,
    private fb: FormBuilder
  ) {
    this.calculateStatsForm = this.fb.group({
      personne: ['', Validators.required],
      parcours: ['', Validators.required],
      type: ['', Validators.required]
    })
  }

  ngOnInit(): void {
    this.loadPersonnes();
    this.loadParcours();
  }

  loadPersonnes(): void {
    this.personneService.getAllPersonnes().subscribe((data: Personne[]) => {
      this.personnes = data;
    })
  }

  loadParcours(): void {
    this.parcoursService.getAllParcours().subscribe((data: Parcours[]) => {
      this.parcours = data;
    })
  }

  onSubmit(): void {
    if(this.calculateStatsForm.valid) {
      const formValues = this.calculateStatsForm.value;
      const personneId = formValues.personne;
      const parcoursId = formValues.parcours;
      const type = formValues.type;
      this.sessionService.getStats(personneId, parcoursId, type)
        .subscribe({
          next: (result) => {
            this.result = result;
            this.successMessage = 'Statistics retrieved successfully!';
            setTimeout(() => {
              this.successMessage = '';
            }, 5000);
          },
          error: () => {
            this.result = null;
            this.errorMessage = 'Could not retrieve statistics. Please check the inputs.';
            setTimeout(() => {
              this.errorMessage = '';
            }, 5000);
          }
        })

    }
  }

  resetForm(): void {
    this.calculateStatsForm.reset();
  }
}
