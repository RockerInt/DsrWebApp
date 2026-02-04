import { Component, signal } from '@angular/core';
import { CommonModule } from '@angular/common';
import { InventoryService } from '../services/inventory.service';
import { Inventory } from '../services/entities/inventory';

@Component({
  selector: 'app-inventories',
  standalone: true,
  imports: [CommonModule],
  templateUrl: './inventories.html',
  styleUrl: './inventories.css'
})
export class Inventories {
  public inventory = signal<Inventory[]>([]);

  constructor(private inventoryService: InventoryService) {
    this.getInventory();
  }

  getInventory() {
    this.inventoryService.getInventories().subscribe({
      next: (result) => {
        this.inventory.update(prevState => result.content || []);
        console.log('Inventories loaded:', result);
      },
      error: (error) => {
        console.error(error);
      }
    });
  }
}
