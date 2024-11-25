import {Component, EventEmitter, Output} from '@angular/core';
import {FormsModule} from '@angular/forms';
import {Personne} from '../personne';
import {PersonneService} from '../services/personne.service';

@Component({
  selector: 'app-add-personne',
  standalone: true,
  imports: [
    FormsModule
  ],
  templateUrl: './add-personne.component.html',
  styleUrl: './add-personne.component.css'
})
export class AddPersonneComponent {
  @Output() addedPersonne = new EventEmitter<Personne>();

  personne: Personne = {
    nom: '',
    prenom: ''
  }

  constructor(private apiService: PersonneService) {}

  addPersonne(): void {
    this.apiService.addPersonne(this.personne).subscribe(result => {
      alert('Person added successfully!');
      this.addedPersonne.emit(result);
    });
  }

}
