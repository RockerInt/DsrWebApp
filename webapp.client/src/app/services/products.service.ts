import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Product } from './entities/product'; // Adjust the import path as necessary
import { Result, ResultSimple } from './entities/result';

@Injectable({
  providedIn: 'root'
})
export class ProductsService {
  private baseUrl = '/Products'; // Base URL for the Products API

  constructor(private http: HttpClient) { }

  getProducts(): Observable<Result<Product[]>> {
    return this.http.get<Result<Product[]>>(this.baseUrl);
  }

  registerProduct(product: Product): Observable<ResultSimple> {
    return this.http.post<ResultSimple>(this.baseUrl, product);
  }
}
