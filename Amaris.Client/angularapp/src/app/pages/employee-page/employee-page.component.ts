import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import Swal from 'sweetalert2';
import { EmployeeResponseService } from '../../models/employee-response';
import { EmployeeService } from '../../services/employee.service';
import { GenericService } from '../../services/generic.service';

@Component({
  selector: 'app-employee-page',
  templateUrl: './employee-page.component.html',
  styleUrls: ['./employee-page.component.css']
})
export class EmployeePageComponent implements OnInit {

  formData!: FormGroup;
  dataSource: EmployeeResponseService[] = [];
  idEmployee: string = '';
  itemsPerPage = 5; 
  currentPage = 1; 

  constructor(
    private employeeService: EmployeeService,
    private genericService : GenericService
  ) { }

  ngOnInit(): void {

  }

  getItems(): EmployeeResponseService[] {
    const startIndex = (this.currentPage - 1) * this.itemsPerPage;
    const endIndex = startIndex + this.itemsPerPage;
    return this.dataSource.slice(startIndex, endIndex);
  }

  pageChanged(event: any): void {
    this.currentPage = event.page;
  }

  showMessageService(status: number) {
    if (status === 400) {
      return this.genericService.showAutoCloseMessage('Ups!', 'We are very sorry, the service currently has many requirements, please try again in 5 secongs. Don t worry, we do it for you look!', 5000);
    }
    if (status === 404) {
      this.dataSource = [];
      return this.genericService.showMessage('We are very sorry, this id does not exist associated with an employee', 'error')
    }
    if (status == 200) {
      return this.genericService.showMessage('Great! here is your requested information', 'success')
    }
  }

  searchEmployee() {
    if (!this.idEmployee) {
      this.employeeService.getEmployeeAll().subscribe(
        response => {
          this.dataSource = response;
          this.showMessageService(200);
        },
        error => {
          this.showMessageService(error.status);
        }
      );
    } else {
      this.employeeService.getEmployeeById(this.idEmployee).subscribe(
        response => {
          this.dataSource = response ? [response] : [];
          this.showMessageService(200);
        },
        error => {
          this.showMessageService(error.status);
        }
      );
    }
  }
}
