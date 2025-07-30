import { HttpClient } from '@angular/common/http';
import { Component, signal } from '@angular/core';
import { RouterOutlet } from '@angular/router';
import { CommonModule } from '@angular/common';
import { SalesService } from './services/sales.service'; 
import { Sale } from './services/entities/sale'; 
import { Result } from './services/entities/result';

@Component({
  selector: 'app-root',
  imports: [RouterOutlet, CommonModule],
  templateUrl: './app.html',
  styleUrl: './app.css'
})
export class App {
  protected readonly title = signal('webapp.client');
  public sales = signal<Sale[]>([]);

  constructor(private http: HttpClient) {this.getSales();}

  getSales() {
    var salesService = new SalesService(this.http);
    salesService.getSales().subscribe({
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
// interface WeatherForecast {
//   date: string;
//   temperatureC: number;
//   temperatureF: number;
//   summary: string;
// }

// @Component({
//   selector: 'app-root',
//   imports: [RouterOutlet, CommonModule],
//   templateUrl: './app.html',
//   styleUrl: './app.css'
// })
// export class App {
//   protected readonly title = signal('webapp.client');
//   public sales = signal<Sale[]>([]);

//   constructor(private http: HttpClient) {this.getForecasts();}

//   getForecasts() {
//     this.http.get<Result<Sale[]>>('/sales').subscribe({
//       next: (result) => {
//         this.sales.update(prevState => result.content || []);
//         console.log('Forecasts loaded:', result);
//       },
//       error: (error) => {
//         console.error(error);
//       }
//     });
//   }
// }