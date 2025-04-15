import { HttpClient } from '@angular/common/http';
import { inject, Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Employee, LeaveDay } from '../models/employee';

@Injectable({ providedIn: 'root' })
export class EmployeeApiService {
  private readonly httpClient = inject(HttpClient);

  private readonly baseUrl = 'https://localhost:7189';

// Get all employees
public getEmployees(): Observable<Array<Employee>> {
  return this.httpClient.get<Array<Employee>>(`${this.baseUrl}/api/employees`);
}

// Add a new leave for an employee
public addLeave(employeeId: string, leave: LeaveDay): Observable<LeaveDay> {
  return this.httpClient.post<LeaveDay>(
    `${this.baseUrl}/api/employees/${employeeId}/leaves`,
    leave
  );
}

// Edit/update an existing leave for an employee
public updateLeave(employeeId: string, leave: LeaveDay): Observable<LeaveDay> {
  return this.httpClient.put<LeaveDay>(
    `${this.baseUrl}/api/employees/${employeeId}/leaves`,
    leave
  );
}

// Delete a leave for an employee
public deleteLeave(employeeId: string, leaveId: string): Observable<void> {
  return this.httpClient.delete<void>(
    `${this.baseUrl}/api/employees/${employeeId}/leaves/${leaveId}`
  );
}

}
