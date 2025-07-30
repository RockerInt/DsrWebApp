import { Component, signal } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ProductsService } from '../services/products.service';
import { Product } from '../services/entities/product'; 

@Component({
  selector: 'app-products',
  standalone: true,
  imports: [CommonModule],
  templateUrl: './products.html',
  styleUrl: './products.css'
})
export class Products {
  public products = signal<Product[]>([]);

  constructor(private productsService: ProductsService) {
    this.getProducts();
  }

  getProducts() {
    this.productsService.getProducts().subscribe({
      next: (result) => {
        this.products.update(prevState => result.content || []);
        console.log('Products loaded:', result);
      },
      error: (error) => {
        console.error(error);
      }
    });
  }
}
