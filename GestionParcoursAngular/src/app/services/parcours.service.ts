import { Injectable } from '@angular/core';
import {HttpClient, HttpHeaders} from '@angular/common/http';
import {catchError, Observable, throwError} from 'rxjs';
import {Parcours} from '../parcours';

@Injectable({
  providedIn: 'root'
})
export class ParcoursService {
  private apiUrl = 'http://localhost:5246/api/parcours';

  constructor(private http: HttpClient) { }

  getAllParcours(): Observable<Parcours[]> {
    return this.http.get<Parcours[]>(this.apiUrl);
  }

  addParcours(parcours: Parcours): Observable<Parcours> {
    const httpOptions = {
      headers: new HttpHeaders({
        'Content-Type': 'application/json'
      })
    };
    return this.http.post<Parcours>(this.apiUrl, parcours, httpOptions).pipe(
      catchError(error => {
        return throwError(error);
      })
    );
  }
}
