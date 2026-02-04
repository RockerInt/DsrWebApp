import { bootstrapApplication } from '@angular/platform-browser';
import { provideHttpClient, withFetch } from '@angular/common/http';
import { provideZonelessChangeDetection } from '@angular/core';
import { App } from './app/app';

bootstrapApplication(App, {
  providers: [
    provideHttpClient(withFetch()),
    provideZonelessChangeDetection() // Zoneless Angular
  ]
});
