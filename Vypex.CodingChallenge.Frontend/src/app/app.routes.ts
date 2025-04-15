import { Routes } from '@angular/router';
import { EMPLOYEES_ROUTES } from './Components/employees-listing/employees.routes';

export const routes: Routes = [
  {
    path: '**',
    redirectTo: 'employees',
  },
  {
    path: 'employees',
    children: EMPLOYEES_ROUTES
  },
];
