import { Routes } from '@angular/router';
import { Sales } from './sales/sales';
import { Clients } from './clients/clients';
import { Products } from './products/products';
import { Inventories } from './inventories/inventories';

export const routes: Routes = [
  { path: 'sale', component: Sales },
  { path: 'client', component: Clients },
  { path: 'product', component: Products },
  { path: 'inventory', component: Inventories }
];