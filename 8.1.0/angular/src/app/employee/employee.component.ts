import { Component, OnInit } from '@angular/core';
import { EmployeeServiceProxy,CreateEmployeeDto, ViewEmployeeDto, UpdateEmployeeDto} from '@shared/service-proxies/service-proxies';




@Component({
  selector: 'app-employee',
  templateUrl: './employee.component.html',
  styleUrls: ['./employee.component.css']
})
export class EmployeeComponent implements OnInit{
  // Global Declarations
  employees: ViewEmployeeDto[];
  designations: string[];
  employee: CreateEmployeeDto;
  updateEmployee: UpdateEmployeeDto;
  edit: boolean;
  selectDesignation: string;



  constructor(private _employeeService: EmployeeServiceProxy)
    {
    this.designations = ['Intern','Jr. Full Stack Developer', 'Full Stack Developer', 'HR Manager', 'Office Boy',
  'Jr. Dotnet Developer', 'Dotnet Developer', 'Sr. Dotnet Developer', 'Business Developer']
    this.employee = new CreateEmployeeDto();
    this.updateEmployee = new UpdateEmployeeDto();
    this.employees = []; 
    this.selectDesignation = 'Select Designation'
    }

  ngOnInit(): void {
    this.edit = false;
    this.GetAllEmployees();

  }

  // Method used to add designation using drop down
  Designation(designation: string){
    if(this.edit){
    
      this.updateEmployee.designation = designation;
    }
    else if(!this.edit){
      this.employee.designation = designation;
    }
  }

  // Method used to add new employee in the list
  Submit(): void{
    try {
      if(!this.edit){

        this._employeeService.createEmployee(this.employee).subscribe();
        this.employee = new CreateEmployeeDto();
      }
      else if(this.edit){
        this._employeeService.updateEmployee(this.updateEmployee).subscribe(result => {
          alert(`Employee of Id ${result} is updated successfully`)
        });
        this.updateEmployee = new UpdateEmployeeDto();
        this.edit = false;
      }
    }
    catch (error) {
      alert("This employee is already present");
    }
    
    setTimeout(() => {
      
      this.GetAllEmployees();
    }, 2000);
    
  }


  // Method used everytime when the list of employees has to be fetched
  GetAllEmployees(){
    this._employeeService.getAllEmployees().subscribe(result => {
        this.employees = result;
      });
    
  }

  // Method used when edit button is clicked for update
  EditEmployee(editEmployeeId: number){
    this.edit = true;
    this._employeeService.getEmployeeById(editEmployeeId).subscribe(employee => {
      this.updateEmployee = employee;
    });
  }

  // Method used when cancel button is select from the UI
  CancelUpdate(){
      this.updateEmployee = new UpdateEmployeeDto();
      this.edit = false; 
  }

    // Method used to delete the individual record
   DeleteEmployee(employee: UpdateEmployeeDto){
  
        this._employeeService.deleteEmployeeById(employee.id).subscribe(result => {
            alert(`Employee with Id ${result} has been deleted successfully`);
        });
  
     setTimeout(() => {
      
      this.GetAllEmployees();
    }, 3000);
    }



}

