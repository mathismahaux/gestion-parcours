import { Routes } from '@angular/router';
import {PersonneListComponent} from './personne-list/personne-list.component';
import {ParcoursListComponent} from './parcours-list/parcours-list.component';
import {AddParcoursComponent} from './add-parcours/add-parcours.component';
import {AddSessionComponent} from './add-session/add-session.component';

export const routes: Routes = [
  {path: 'personne-list', component: PersonneListComponent},
  {
    path: 'parcours-list',
    component: ParcoursListComponent,
    children: [
      {path: 'add-parcours', component: AddParcoursComponent},
      {path: 'add-session', component: AddSessionComponent},
    ]
  }
];
