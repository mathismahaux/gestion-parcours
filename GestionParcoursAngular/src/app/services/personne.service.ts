import { Injectable } from '@angular/core';
import {HttpClient, HttpHeaders} from '@angular/common/http';
import {Personne} from '../personne';
import {Observable} from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class PersonneService {
  private apiUrl = 'http://localhost:5246/api/personnes';

  constructor(private http: HttpClient) { }

  getAllPersonnes(): Observable<Personne[]> {
    return this.http.get<Personne[]>(this.apiUrl);
  }

  addPersonne(personne: Personne): Observable<Personne> {
    const httpOptions = {
      headers: new HttpHeaders({
        'Content-Type': 'application/json'
      })
    };
    return this.http.post<Personne>(this.apiUrl, personne, httpOptions);
  }
}
