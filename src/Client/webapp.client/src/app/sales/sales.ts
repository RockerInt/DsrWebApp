import { Component, signal } from '@angular/core';
import { CommonModule } from '@angular/common';
import { SalesService } from '../services/sales.service';
import { Sale } from '../services/entities/sale'; 

@Component({
  selector: 'app-sales',
  standalone: true,
  imports: [CommonModule],
  templateUrl: './sales.html',
  styleUrl: './sales.css'
})
export class Sales {
  public sales = signal<Sale[]>([]);

  constructor(private salesService: SalesService) {
    this.getSales();
  }

  getSales() {
    this.salesService.getSales().subscribe({
      next: (result) => {
        this.sales.update(prevState => result.content || []);
        console.log('Sales loaded:', result);
      },
      error: (error) => {
        console.error(error);
      }
    });
  }
}
