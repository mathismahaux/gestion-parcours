import { Injectable } from '@angular/core';
import {Subject} from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class PersonneSharedService {
  private updatePersonneSubject = new Subject<void>();

  updatePersonne$ = this.updatePersonneSubject.asObservable();

  notifyPersonneAdded(): void {
    this.updatePersonneSubject.next();
  }
}
