import { CommonModule } from '@angular/common';
import { Component, OnInit, signal } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { Router, RouterModule } from '@angular/router';
import { NzButtonModule } from 'ng-zorro-antd/button';
import { NzInputModule } from 'ng-zorro-antd/input';
import { NzTableModule } from 'ng-zorro-antd/table';
import { debounceTime, Subject } from 'rxjs';
import { EmployeeService } from '../employee.service';

@Component({
  standalone: true,
  selector: 'app-employees-list',
  imports: [CommonModule, FormsModule, NzTableModule, NzInputModule, NzButtonModule, RouterModule],
  templateUrl: './employees-list.component.html',
})
export class EmployeesListComponent implements OnInit {
  employees = signal<any[]>([]);
  search$ = new Subject<string>();

  constructor(private employeeService: EmployeeService, private router: Router) {}

  ngOnInit(): void {
    this.loadEmployees();
    this.search$.pipe(debounceTime(300)).subscribe(searchText => {
      this.loadEmployees(searchText);
    });
  }

  loadEmployees(query: string = '') {
    this.employeeService.getEmployees().subscribe(data => {
      const filtered = query ? data.filter(emp => emp.name.toLowerCase().includes(query.toLowerCase())) : data;
      this.employees.set(filtered);
    });
  }

  refresh() {
    this.loadEmployees();
  }

  search(event: any) {
    this.search$.next(event.target.value);
  }

  editEmployee(id: string) {
    this.router.navigate(['/edit', id]);
  }

  manageLeave(id: number) {
    this.router.navigate(['/leave', id]);
  }
}
