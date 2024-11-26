import {Component, EventEmitter, Input, OnInit, Output} from '@angular/core';
import {Session} from '../session';
import {SessionService} from '../services/session.service';
import {FormBuilder, FormGroup, FormsModule, ReactiveFormsModule, Validators} from '@angular/forms';
import {Personne} from '../personne';
import {PersonneService} from '../services/personne.service';
import {ParcoursService} from '../services/parcours.service';
import {Parcours} from '../parcours';
import {NgClass} from '@angular/common';
import {AddParcoursComponent} from '../add-parcours/add-parcours.component';

@Component({
  selector: 'app-add-session',
  standalone: true,
  imports: [
    FormsModule,
    ReactiveFormsModule,
    NgClass,
    AddParcoursComponent
  ],
  templateUrl: './add-session.component.html',
  styleUrl: './add-session.component.css'
})
export class AddSessionComponent implements OnInit {
  @Input() parcoursInput: Parcours[] = [];
  @Output() addedSession = new EventEmitter<Session>();

  addSessionForm: FormGroup;
  personnes: Personne[] = [];
  successMessage: string = '';
  errorMessage: string= '';

  constructor(
    private sessionService: SessionService,
    private personneService: PersonneService,
    private parcoursService: ParcoursService,
    private fb: FormBuilder
  ) {
    this.addSessionForm = this.fb.group({
      personne: ['', Validators.required],
      parcours: ['', Validators.required],
      type: ['', Validators.required],
      timeMinutes: [null, [Validators.required, Validators.min(1)]]
    });
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
      this.parcoursInput = data;
    })
  }

  onSubmit(): void {
    if (this.addSessionForm.valid) {
      const formValues = this.addSessionForm.value;
      const session = {
        personneId: formValues.personne,
        parcoursId: formValues.parcours,
        type: formValues.type,
        tempsMinutes: formValues.timeMinutes
      };

      this.sessionService.addSession(session).subscribe({
        next: () => {
          this.successMessage = 'Session added successfully!';
          this.addedSession.emit();

          setTimeout(() => {
            this.successMessage = '';
          }, 5000);
        },
        error: (err) => {
          this.errorMessage = 'Failed to add session.';
          setTimeout(() => {
            this.errorMessage = '';
          }, 5000);
        }
      });
    }
  }

  resetForm(): void {
    this.addSessionForm.reset();
  }
}
