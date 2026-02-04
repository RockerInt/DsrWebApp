import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Client } from './entities/client'; // Adjust the import path as necessary
import { Result, ResultSimple } from './entities/result';

@Injectable({
  providedIn: 'root'
})
export class ClientsService {
  private baseUrl = '/Clients'; // Base URL for the Clients API

  constructor(private http: HttpClient) { }

  getClients(): Observable<Result<Client[]>> {
    return this.http.get<Result<Client[]>>(this.baseUrl);
  }

  registerClient(client: Client): Observable<ResultSimple> {
    return this.http.post<ResultSimple>(this.baseUrl, client);
  }
}
