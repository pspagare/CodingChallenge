export interface Employee {
  id: string;
  name: string;
  totalLeaveDays: string;
  Leaves: LeaveDay[]
}

export interface LeaveDay {
  id?: string;
  startDate: Date;
  endDate: Date;
}
