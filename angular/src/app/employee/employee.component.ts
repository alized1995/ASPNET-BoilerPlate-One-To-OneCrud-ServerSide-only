import { Component, OnInit } from '@angular/core';
import { EmployeeServiceProxy,CreateEmployeeDto, ViewEmployeeDto, UpdateEmployeeDto} from '@shared/service-proxies/service-proxies';

declare var window: any;



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
  formModal: any;
  confirm: boolean;
  selectDesignation: string;



  constructor(private _employeeService: EmployeeServiceProxy)
    {
    this.designations = ['Intern','Jr. Full Stack Developer', 'Full Stack Developer', 'HR Manager', 'Office Boy',
  'Jr. Dotnet Developer', 'Dotnet Developer', 'Sr. Dotnet Developer', 'Business Developer']
    this.employee = new CreateEmployeeDto();
    this.updateEmployee = new UpdateEmployeeDto();
    this.employees = new Array(); 
    this.confirm = false;
    this.selectDesignation = 'Select Designation'
    }

  ngOnInit(): void {
    this.edit = false;
    this.GetAllEmployees();
    this.formModal = new window.bootstrap.Modal(
      document.getElementById("modal1")
    );

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
      this._employeeService.createEmployee(this.employee).subscribe();
     
      this.employee = new CreateEmployeeDto();
    } catch (error) {
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
  EditEmployee(editEmployee: UpdateEmployeeDto){
    console.log(editEmployee);
    this.edit = true;
    this.updateEmployee = editEmployee.clone();
  }

  // Method used when update button is select from the UI
  UpdateEmployee(action: string){
    if(action == 'update'){
    this._employeeService.updateEmployee(this.updateEmployee).subscribe(result => {
      alert(`Employee of Id ${result} is updated successfully`);
    });
    setTimeout(() => {
      
      this.GetAllEmployees();
    }, 2000);
    this.updateEmployee = new UpdateEmployeeDto();
    this.edit = false;
    }
    else if(action == 'cancel'){
      this.updateEmployee = new UpdateEmployeeDto();
      this.edit = false;
    }
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

  // PopUpModal(){
  //  this.formModal.show();
  //  setTimeout(() => {
  //   this.formModal.hide();
  //  }, 3000);
   
  // }

  // PopUpActions(confirmStatus: boolean){
  //   if(confirmStatus){
  //     this.confirm = true;
  //     this.formModal.hide();
      
  //   }
  //   else if(!confirmStatus){
  //     this.confirm = false;
  //     this.formModal.hide();
  //   }
  // }

}

