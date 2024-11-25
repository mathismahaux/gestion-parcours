import { Component } from '@angular/core';
import {RouterLink, RouterLinkActive, RouterOutlet} from '@angular/router';
import {PersonneListComponent} from './personne-list/personne-list.component';
import {ParcoursListComponent} from './parcours-list/parcours-list.component';

@Component({
  selector: 'app-root',
  standalone: true,
  imports: [RouterOutlet, PersonneListComponent, ParcoursListComponent, RouterLinkActive, RouterLink],
  templateUrl: './app.component.html',
  styleUrl: './app.component.css'
})
export class AppComponent {
  title = 'GestionParcoursAngular';
}
