import {Component, Input, OnInit} from '@angular/core';
import {PersonneService} from '../services/personne.service';
import {Personne} from '../personne';
import {AddPersonneComponent} from '../add-personne/add-personne.component';
import {CalculateStatisticsComponent} from '../calculate-statistics/calculate-statistics.component';
import {NgClass} from '@angular/common';

@Component({
  selector: 'app-personne-list',
  standalone: true,
  imports: [
    AddPersonneComponent,
    CalculateStatisticsComponent,
    NgClass
  ],
  templateUrl: './personne-list.component.html',
  styleUrl: './personne-list.component.css'
})
export class PersonneListComponent implements OnInit {
  personnes: Personne[] = []

  constructor(
    private personneService: PersonneService,
  ) {}

  ngOnInit(): void {
    this.loadPersonnes();
  }

  private loadPersonnes() {
    this.personneService.getAllPersonnes().subscribe((data: Personne[]) => {
      this.personnes = data;
    });
  }

  onPersonneAdded(newPersonne: Personne) : void {
    this.personnes.push(newPersonne);
  }
}
