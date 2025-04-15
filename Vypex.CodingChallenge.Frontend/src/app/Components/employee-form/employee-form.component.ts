import { Component, EventEmitter, Input, OnChanges, Output } from '@angular/core';
import { FormArray, FormBuilder, FormGroup, ReactiveFormsModule, Validators } from '@angular/forms';
import { NzButtonModule } from 'ng-zorro-antd/button';
import { NzCheckboxModule } from 'ng-zorro-antd/checkbox';
import { NzFormModule } from 'ng-zorro-antd/form';
import { NzInputModule } from 'ng-zorro-antd/input';
import { LeaveDay } from '../../api/models/employee';

@Component({
  selector: 'employee-form-component',
  standalone: true,
  imports: [ReactiveFormsModule, NzButtonModule, NzCheckboxModule, NzFormModule, NzInputModule],
  templateUrl: './employee-form.component.html',
  styleUrl: './employee-form.component.scss'
})
export class EmployeeFormComponent implements OnChanges {
  @Input() leaveDays: LeaveDay[] = [];
  @Output() leaveDaysChange = new EventEmitter<LeaveDay[]>();
  @Output() cancel = new EventEmitter<void>();

  form!: FormGroup;

  constructor(private fb: FormBuilder) {
    this.form = this.fb.group({
      leaveArray: this.fb.array([])
    });
  }

  ngOnChanges(): void {
    const leaveArray = this.form.get('leaveArray') as FormArray;
    leaveArray.clear();
    this.leaveDays.forEach(day => {
      leaveArray.push(this.createLeaveForm(day));
    });
  }

  createLeaveForm(day: LeaveDay): FormGroup {
    return this.fb.group({
      startDate: [day.startDate, Validators.required],
      endDate: [day.endDate, Validators.required]
    }, { validators: this.dateValidator });
  }

  dateValidator(group: FormGroup): any {
    const start = new Date(group.get('startDate')?.value);
    const end = new Date(group.get('endDate')?.value);
    return start && end && start <= end ? null : { invalidRange: true };
  }

  addLeave(): void {
    const leaveArray = this.form.get('leaveArray') as FormArray;
    leaveArray.push(this.createLeaveForm({ startDate: new Date(), endDate: new Date() }));
  }

  removeLeave(index: number): void {
    const leaveArray = this.form.get('leaveArray') as FormArray;
    leaveArray.removeAt(index);
  }

  onSubmit(): void {
    const leaveArray = this.form.get('leaveArray') as FormArray;
    const leaveDays = leaveArray.getRawValue();
    if (this.validateNoOverlap(leaveDays)) {
      this.leaveDaysChange.emit(leaveDays);
    } else {
      alert('Leave days cannot overlap!');
    }
  }

  cancelEdit(): void {
    this.cancel.emit();
  }

  validateNoOverlap(leaveDays: LeaveDay[]): boolean {
    const sorted = [...leaveDays].sort((a, b) => new Date(a.startDate).getTime() - new Date(b.startDate).getTime());
    for (let i = 1; i < sorted.length; i++) {
      if (new Date(sorted[i].startDate) <= new Date(sorted[i - 1].endDate)) {
        return false;
      }
    }
    return true;
  }
}
