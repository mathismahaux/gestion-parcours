import {Component, EventEmitter, Output} from '@angular/core';
import {FormBuilder, FormGroup, FormsModule, ReactiveFormsModule, Validators} from "@angular/forms";
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
  addParcoursForm: FormGroup;

  @Output() addedParcours = new EventEmitter<Parcours>();

  parcours: Parcours = {
    nom: '',
    tempsMarcheMinutes: 0,
    tempsCourseMinutes: 0
  }

  successMessage: string = '';
  errorMessage: string = '';

  constructor(
    private apiService: ParcoursService,
    private fb: FormBuilder
  ) {
    this.addParcoursForm = this.fb.group({
      nom: [this.parcours.nom, [Validators.required, Validators.minLength(5)]],
      tempsMarcheMinutes: [this.parcours.tempsMarcheMinutes, [Validators.required, Validators.min(1)]],
      tempsCourseMinutes: [this.parcours.tempsCourseMinutes, [Validators.required, Validators.min(1)]],
    });
  }

  resetForm() {
    this.addParcoursForm.reset();
  }

  onSubmit(): void {
    if (this.addParcoursForm.valid) {
      const formValues = this.addParcoursForm.value;

      this.apiService.addParcours(formValues).subscribe({
        next: (result) => {
          this.successMessage = 'Course added successfully!';
          this.addedParcours.emit(result);

          setTimeout(() => {
            this.successMessage = '';
          }, 5000);
        },
        error: (err) => {
          this.errorMessage = 'Failed to add course.';

          setTimeout(() => {
            this.errorMessage = '';
          }, 5000);
        }
      });
    }
  }
}
