import { Component, inject, OnInit } from '@angular/core';
import { RouterOutlet } from '@angular/router';
import { Employee } from './api/models';
import { EmployeeApiService } from './api/services/employee-api.service';

@Component({
  selector: 'app-root',
  standalone: true,
  imports: [RouterOutlet],
  templateUrl: './app.component.html',
  styleUrl: './app.component.scss'
})
export class AppComponent implements OnInit{
  private employeService = inject(EmployeeApiService);

  employee: Employee[] = []

  ngOnInit(): void {
    this.employeService.getEmployees().subscribe({
      next: response => this.employee = response,
      error: error => console.log(error)
    })
}}
