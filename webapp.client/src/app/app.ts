import { HttpClient } from '@angular/common/http';
import { Component, signal } from '@angular/core';
import { RouterOutlet } from '@angular/router';
import { CommonModule } from '@angular/common';

interface WeatherForecast {
  date: string;
  temperatureC: number;
  temperatureF: number;
  summary: string;
}

@Component({
  selector: 'app-root',
  imports: [RouterOutlet, CommonModule],
  templateUrl: './app.html',
  styleUrl: './app.css'
})
export class App {
  protected readonly title = signal('webapp.client');
  public forecasts = signal<WeatherForecast[]>([]);

  constructor(private http: HttpClient) {this.getForecasts();}

  getForecasts() {
    this.http.get<WeatherForecast[]>('/weatherforecast').subscribe({
      next: (result) => {
        this.forecasts.update(prevState => result);
        console.log('Forecasts loaded:', result);
      },
      error: (error) => {
        console.error(error);
      }
    });
  }
}
