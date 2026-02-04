import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Sale } from './entities/sale'; // Adjust the import path as necessary
import { Result, ResultSimple } from './entities/result';

@Injectable({
  providedIn: 'root'
})
export class SalesService {
  private baseUrl = '/sales'; // Base URL for the Sales API

  constructor(private http: HttpClient) { }

  getSales(): Observable<Result<Sale[]>> {
    return this.http.get<Result<Sale[]>> (this.baseUrl);
  }

  // getSales(): Observable<any> {
  //   let result = this.http.get<any> (this.baseUrl)
  //   return result;
  // }

  registerSale(sale: Sale): Observable<ResultSimple> {
    return this.http.post<ResultSimple>(this.baseUrl, sale);
  }
}
  