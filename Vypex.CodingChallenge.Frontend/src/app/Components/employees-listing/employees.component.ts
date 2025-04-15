import { AsyncPipe, CommonModule } from '@angular/common';
import { Component, inject, OnInit } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { NzBadgeModule } from 'ng-zorro-antd/badge';
import { NzButtonModule } from 'ng-zorro-antd/button';
import { NzDividerModule } from 'ng-zorro-antd/divider';
import { NzDropDownModule } from 'ng-zorro-antd/dropdown';
import { NzIconModule } from 'ng-zorro-antd/icon';
import { NzInputModule } from 'ng-zorro-antd/input';
import { NzPageHeaderModule } from 'ng-zorro-antd/page-header';
import { NzTableModule } from 'ng-zorro-antd/table';
import { Employee } from '../../api/models/employee';
import { EmployeeApiService } from '../../api/services/employee-api.service';
import { EmployeeFormComponent } from "../employee-form/employee-form.component";

@Component({
  selector: 'app-employees',
  standalone: true,
  imports: [
    NzTableModule,
    NzButtonModule,
    AsyncPipe,
    NzDividerModule,
    NzIconModule,
    NzInputModule,
    FormsModule,
    NzPageHeaderModule,
    CommonModule,
    NzBadgeModule,
    NzDropDownModule,NzDividerModule,NzDropDownModule, NzIconModule, NzTableModule,
    EmployeeFormComponent
],
  templateUrl: './employees.component.html',
  styleUrl: './employees.component.scss'
})

export class EmployeesComponent implements OnInit {

  employees: Employee[] = [];
  filteredEmployees: Employee[] = [];
  selectedEmployee: Employee | null = null;
  loading = false;
  searchTerm = '';
  constructor(private employeeService: EmployeeApiService) {}

  ngOnInit(): void {
    this.loadEmployees();
  }

  loadEmployees(): void {
    this.loading = true;
    this.employeeService.getEmployees().subscribe({
      next: (data) => {
        this.employees = data;
        this.applyFilter();
        this.loading = false;
      },
      error: (err) => {
        console.error('Error loading employees', err);
        this.loading = false;
      }
    });
  }

  filterList(): void {
    const term = this.searchTerm.toLowerCase();
    this.filteredEmployees = this.employees.filter(e => e.name.toLowerCase().includes(term));
  }

  applyFilter(): void {
    this.filteredEmployees = this.employees.filter(emp =>
      emp.name.toLowerCase().includes(this.searchTerm.toLowerCase())
    );
  }

  //TODO deleteLeave
  //TODO editLeaves

  cancelEdit(): void {
    this.selectedEmployee = null;
  }
    private readonly employeeApiService = inject(EmployeeApiService);
    public readonly employees$ = this.employeeApiService.getEmployees();
}
