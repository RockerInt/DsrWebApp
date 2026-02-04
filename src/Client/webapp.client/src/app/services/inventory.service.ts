import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Inventory } from './entities/inventory'; // Adjust the import path as necessary
import { Result, ResultSimple } from './entities/result';

@Injectable({
  providedIn: 'root'
})
export class InventoryService {
  private baseUrl = '/Inventory'; // Base URL for the Inventory API

  constructor(private http: HttpClient) { }

  getInventory(productId: string): Observable<Result<Inventory>> {
    return this.http.get<Result<Inventory>> (`${this.baseUrl}/${productId}`);
  }

  getInventories(): Observable<Result<Inventory[]>> {
    return this.http.get<Result<Inventory[]>> (this.baseUrl);
  }

  updateInventoryStock(inventoryUpdate: Inventory): Observable<ResultSimple> {
    return this.http.put<ResultSimple>(`${this.baseUrl}/stock`, inventoryUpdate);
  }
}
