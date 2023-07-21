export class EmployeeResponseService 
{
  employee_anual_salary: number;
  id: string;
  employee_name: string;
  employee_salary: number;
  employee_age: number;

  constructor() {
    this.employee_anual_salary = 0;
    this.id = '';
    this.employee_name = '';
    this.employee_salary = 0;
    this.employee_age = 0;
   }
}
