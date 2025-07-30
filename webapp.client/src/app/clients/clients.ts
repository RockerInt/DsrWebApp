import { Component, signal } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ClientsService } from '../services/clients.service';
import { Client } from '../services/entities/client';

@Component({
  selector: 'app-clients',
  standalone: true,
  imports: [CommonModule],
  templateUrl: './clients.html',
  styleUrl: './clients.css'
})
export class Clients {
  public clients = signal<Client[]>([]);

  constructor(private clientsService: ClientsService) {
    this.getClients();
  }

  getClients() {
    this.clientsService.getClients().subscribe({
      next: (result) => {
        this.clients.update(prevState => result.content || []);
        console.log('Clients loaded:', result);
      },
      error: (error) => {
        console.error(error);
      }
    });
  }
}
