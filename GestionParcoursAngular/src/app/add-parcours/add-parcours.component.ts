import {Component, EventEmitter, Output} from '@angular/core';
import {FormsModule, ReactiveFormsModule} from "@angular/forms";
import {Personne} from '../personne';
import {PersonneService} from '../services/personne.service';
import {Parcours} from '../parcours';
import {ParcoursService} from '../services/parcours.service';

@Component({
  selector: 'app-add-parcours',
  standalone: true,
    imports: [
        FormsModule,
        ReactiveFormsModule
    ],
  templateUrl: './add-parcours.component.html',
  styleUrl: './add-parcours.component.css'
})
export class AddParcoursComponent {
  @Output() addedParcours = new EventEmitter<Parcours>();

  parcours: Parcours = {
    nom: '',
    tempsMarcheMinutes: 0,
    tempsCourseMinutes: 0
  }

  successMessage: string = '';
  errorMessage: string = '';


  constructor(private apiService: ParcoursService) {}

  addParcours(): void {
    this.apiService.addParcours(this.parcours).subscribe({
      next: (result) => {
        this.successMessage = 'Course added successfully!';
        this.addedParcours.emit(result);

        this.parcours = {
          nom: '',
          tempsMarcheMinutes: 0,
          tempsCourseMinutes: 0
        };

        setTimeout(() => {
          this.successMessage = '';
        }, 5000);
      },
      error: (err) => {
        this.errorMessage = 'Failed to add course: One or more validation errors occured.';

        setTimeout(() => {
          this.errorMessage = '';
        }, 5000);
      }
    });
  }
}
