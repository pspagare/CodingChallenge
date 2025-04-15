import { Routes } from '@angular/router';
import { EmployeeEditComponent } from './Employees/employee-edit/employee-edit.component';
import { EmployeesListComponent } from './Employees/employees-list/employees-list.component';
import { LeaveFormComponent } from './Employees/leave-form/leave-form.component';

export const routes: Routes = [
  { path: '', component: EmployeesListComponent },
  { path: 'leave/:id', component: EmployeeEditComponent },
  { path: 'leave', component: LeaveFormComponent },
];
