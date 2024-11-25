import { Injectable } from '@angular/core';
import {HttpClient, HttpHeaders, HttpParams} from '@angular/common/http';
import {Observable} from 'rxjs';
import {Session} from '../session';

export interface DtoOutputAverageTime {
  parcoursId: number;
  type: string;
  averageTime: number;
  standardTime: number;
  isBetterThanStandard: boolean;
}

@Injectable({
  providedIn: 'root'
})
export class SessionService {
  private apiUrl = 'http://localhost:5246/api/sessions';

  constructor(private http: HttpClient) { }

  addSession(session: {
    personneId: number;
    tempsMinutes: number;
    parcoursId: number;
    type: string
  }): Observable<Session> {
    const httpOptions = {
      headers: new HttpHeaders({
        'Content-Type': 'application/json'
      })
    };
    return this.http.post<Session>(this.apiUrl, session, httpOptions);
  }

  getAverageTime(personneId: number, parcoursId: number, type: string): Observable<DtoOutputAverageTime> {
    const params = new HttpParams()
      .set('personneId', personneId)
      .set('parcoursId', parcoursId)
      .set('type', type);

    return this.http.get<DtoOutputAverageTime>(`${this.apiUrl}/average-time`, { params });
  }
}
