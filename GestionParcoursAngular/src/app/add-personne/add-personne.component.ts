import {Component, EventEmitter, Output} from '@angular/core';
import {FormBuilder, FormGroup, FormsModule, ReactiveFormsModule, Validators} from '@angular/forms';
import {Personne} from '../personne';
import {PersonneService} from '../services/personne.service';

@Component({
  selector: 'app-add-personne',
  standalone: true,
  imports: [
    FormsModule,
    ReactiveFormsModule
  ],
  templateUrl: './add-personne.component.html',
  styleUrl: './add-personne.component.css'
})
export class AddPersonneComponent {
  addPersonForm: FormGroup;

  @Output() addedPersonne = new EventEmitter<Personne>();

  personne: Personne = {
    nom: '',
    prenom: ''
  }

  successMessage: string = '';
  errorMessage: string = '';

  constructor(
    private personneService: PersonneService,
    private fb: FormBuilder
  ) {
    this.addPersonForm = this.fb.group({
      nom: [this.personne.nom, [Validators.required, Validators.minLength(2), Validators.pattern('^[a-zA-Z ,.\'-]+$')]],
      prenom: [this.personne.prenom, [Validators.required, Validators.minLength(2), Validators.pattern('^[a-zA-Z ,.\'-]+$')]]
    })
  }

  resetForm() {
    this.addPersonForm.reset();
  }

  onSubmit(): void {
    if (this.addPersonForm.valid) {
      const formValues = this.addPersonForm.value;

      this.personneService.addPersonne(formValues).subscribe({
        next: (result) => {
          this.successMessage = 'Person added successfully!';
          this.addedPersonne.emit(result);

          setTimeout(() => {
            this.successMessage = '';
          }, 5000);
        },
        error: (err) => {
          this.errorMessage = 'Failed to add person.';

          setTimeout(() => {
            this.errorMessage = '';
          }, 5000);
        }
      });
    }
  }
}
