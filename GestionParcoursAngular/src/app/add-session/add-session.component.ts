import {Component, EventEmitter, OnInit, Output} from '@angular/core';
import {Session} from '../session';
import {SessionService} from '../services/session.service';
import {FormsModule, ReactiveFormsModule} from '@angular/forms';
import {Personne} from '../personne';
import {PersonneService} from '../services/personne.service';
import {ParcoursService} from '../services/parcours.service';
import {Parcours} from '../parcours';
import {NgClass} from '@angular/common';

@Component({
  selector: 'app-add-session',
  standalone: true,
  imports: [
    FormsModule,
    ReactiveFormsModule,
    NgClass
  ],
  templateUrl: './add-session.component.html',
  styleUrl: './add-session.component.css'
})
export class AddSessionComponent implements OnInit {
  @Output() addedSession = new EventEmitter<Session>();

  personnes: Personne[] = [];
  parcours: Parcours[] = [];
  selectedPersonneId!: number;
  selectedParcoursId!: number;
  enteredType!: string;
  enteredTempsMinutes!: number;

  constructor(
    private sessionService: SessionService,
    private personneService: PersonneService,
    private parcoursService: ParcoursService
  ) {}

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

  addSession(): void {
    if (this.selectedPersonneId && this.selectedParcoursId && this.enteredType && this.enteredTempsMinutes) {
      const session = {
        personneId: +this.selectedPersonneId,
        parcoursId: +this.selectedParcoursId,
        type: this.enteredType,
        tempsMinutes: this.enteredTempsMinutes
      };

      console.log('Session object before sending:', session);

      this.sessionService.addSession(session).subscribe({
        next: () => {
          alert('Session added successfully!');
          this.addedSession.emit();
        },
        error: (err) => {
          console.error('Error adding session:', err);
        }
      });
    } else {
      alert('Please enter all the information.');
    }
  }
}
