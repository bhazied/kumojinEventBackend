import { Observable } from 'rxjs';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';

import { EventDto } from '../models/EventDto';
import { environment } from '../../../../../environments/environment';

@Injectable()
export class EventService {
  public apiUrl: string = environment.BASE_URL + 'events';
  constructor(private http: HttpClient) {}
  AddEvent(event: EventDto): Observable<any> {
    const headers = new HttpHeaders({ 'Content-Type': 'application/json' });
    return this.http.post(this.apiUrl, event, {headers});
  }

  GetAllEvent(): Observable<any> {
    const headers = new HttpHeaders({ 'Content-Type': 'application/json' });
        let data = this.http.get(this.apiUrl, {headers});
    console.log(data);
    return data;
  }
}
