import { CommonModule } from '@angular/common';
import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, ReactiveFormsModule, Validators } from '@angular/forms';
import { ActivatedRoute } from '@angular/router';
import { NzButtonModule } from 'ng-zorro-antd/button';
import { NzDatePickerModule } from 'ng-zorro-antd/date-picker';
import { NzFormModule } from 'ng-zorro-antd/form';
import { NzInputModule } from 'ng-zorro-antd/input';
import { LeaveFormComponent } from '../leave-form/leave-form.component';

@Component({
  selector: 'app-employee-edit',
  standalone: true,
  imports: [CommonModule, ReactiveFormsModule, NzFormModule, NzInputModule, NzButtonModule, LeaveFormComponent, NzDatePickerModule],
  templateUrl: './employee-edit.component.html'
})

export class EmployeeEditComponent implements OnInit {
  form!: FormGroup;
  employeeId!: string;

  constructor(private fb: FormBuilder, private route: ActivatedRoute) {}

  ngOnInit(): void {
    this.employeeId = this.route.snapshot.paramMap.get('id')!;
    this.form = this.fb.group({
      leaves: [[], Validators.required]
    });
  }

  submit() {
    if (this.form.valid) {
      const leaves = this.form.value.leaves;
      console.log(`Leave submitted for Employee ID ${this.employeeId}`, leaves);
      // TODO: call API to save leaves
  }
}
}
