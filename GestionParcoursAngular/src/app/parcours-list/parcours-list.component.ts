import {Component, OnInit} from '@angular/core';
import {Parcours} from '../parcours';
import {ParcoursService} from '../services/parcours.service';
import {AddParcoursComponent} from '../add-parcours/add-parcours.component';
import {AddPersonneComponent} from '../add-personne/add-personne.component';
import {AddSessionComponent} from '../add-session/add-session.component';
import {NgClass} from '@angular/common';
import {RouterLink, RouterLinkActive, RouterOutlet} from '@angular/router';
import {Personne} from '../personne';
import {PersonneService} from '../services/personne.service';

@Component({
  selector: 'app-parcours-list',
  standalone: true,
  imports: [
    AddParcoursComponent,
    AddPersonneComponent,
    AddSessionComponent,
    NgClass,
    RouterLinkActive,
    RouterLink,
    RouterOutlet
  ],
  templateUrl: './parcours-list.component.html',
  styleUrl: './parcours-list.component.css'
})
export class ParcoursListComponent implements  OnInit {
  parcours: Parcours[] = []
  personnes: Personne[] = []

  constructor(
    private parcoursService: ParcoursService,
    private personneService: PersonneService
  ) {}

  ngOnInit(): void {
    this.loadParcours();
    this.loadPersonnes();
  }

  private loadPersonnes() {
    this.personneService.getAllPersonnes().subscribe((data: Personne[]) => {
      console.log(data);
      this.personnes = data;
    });
  }

  private loadParcours() {
    this.parcoursService.getAllParcours().subscribe((data: Parcours[]) => {
      console.log(data);
      this.parcours = data;
    });
  }

  onParcoursAdded(newParcours: Parcours) : void {
    this.parcours.push(newParcours);
  }
}
