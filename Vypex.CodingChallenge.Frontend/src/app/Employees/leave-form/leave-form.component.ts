import { CommonModule } from '@angular/common';
import { Component, forwardRef } from '@angular/core';
import { ControlValueAccessor, FormsModule, NG_VALUE_ACCESSOR, ReactiveFormsModule } from '@angular/forms';
import { NzButtonModule } from 'ng-zorro-antd/button';
import { NzDatePickerModule } from 'ng-zorro-antd/date-picker';
import { NzFormModule } from 'ng-zorro-antd/form';

@Component({
  selector: 'app-leave-form',
  standalone: true,
  imports: [CommonModule, FormsModule, ReactiveFormsModule, NzFormModule, NzButtonModule, NzDatePickerModule],
  templateUrl: './leave-form.component.html',
  providers: [{
    provide: NG_VALUE_ACCESSOR,
    useExisting: forwardRef(() => LeaveFormComponent),
    multi: true
  }]
})
export class LeaveFormComponent implements ControlValueAccessor {
  leaves: { startDate: Date, endDate: Date }[] = [];
  onChange = (leaves: any) => {};
  onTouched = () => {};

  writeValue(value: any): void {
    this.leaves = value || [];
  }
  registerOnChange(fn: any): void {
    this.onChange = fn;
  }
  registerOnTouched(fn: any): void {
    this.onTouched = fn;
  }

  addLeave() {
    this.leaves.push({ startDate: new Date(), endDate: new Date() });
    this.onChange(this.leaves);
  }

  removeLeave(index: number) {
    this.leaves.splice(index, 1);
    this.onChange(this.leaves);
  }

  isOverlapping(): boolean {
    const sorted = [...this.leaves].sort((a, b) => new Date(a.startDate).getTime() - new Date(b.startDate).getTime());
    for (let i = 1; i < sorted.length; i++) {
      if (sorted[i].startDate <= sorted[i - 1].endDate) return true;
    }
    return false;
  }
}
