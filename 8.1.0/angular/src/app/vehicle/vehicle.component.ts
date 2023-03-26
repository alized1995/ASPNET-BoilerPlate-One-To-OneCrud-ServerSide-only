import { Component, OnInit } from '@angular/core';
import { CreateVehicleDto, EmployeeServiceProxy, UpdateVehicleDto, VehicleServiceProxy, ViewEmployeeDto, ViewVehicleDto, ViewVehicleWithEmployeeDto } from '@shared/service-proxies/service-proxies';
import { result } from 'lodash-es';

declare var window: any;
@Component({
  selector: 'app-vehicle',
  templateUrl: './vehicle.component.html',
  styleUrls: ['./vehicle.component.css']
})
export class VehicleComponent implements OnInit {
  // Global Declarations
  vehiclesWithEmployee: ViewVehicleWithEmployeeDto[];
  employees: ViewEmployeeDto[];
  filterEmployeeIds: number[];
  vehicles: ViewVehicleDto[];
  designations: string[];
  vehicle: ViewVehicleWithEmployeeDto;
  updateVehicle: ViewVehicleWithEmployeeDto;
  edit: boolean;
  selectEmployee: string;


constructor(private _vehicleService: VehicleServiceProxy, private _employeeService: EmployeeServiceProxy){
  
  
}

ngOnInit(): void {
  this.edit = false;
  this.vehicle = new ViewVehicleWithEmployeeDto();
  this.updateVehicle = new ViewVehicleWithEmployeeDto();
  this.selectEmployee = 'Select Employee by Name';
  this.GetAllVehiclesWithEmployeeNames();
  this.GetAllVehicles();
  this.GetAllEmployees();
    
  }


EmployeeId(employeeId: number){
  if(employeeId != null){
  if(this.edit){
  
    this.updateVehicle.employeeId = employeeId;
    this._employeeService.getEmployeeById(employeeId).subscribe(result =>{
      this.updateVehicle.employeeName = result.name
    })
  }
  else if(!this.edit){
    this.vehicle.employeeId = employeeId;
    this._employeeService.getEmployeeById(employeeId).subscribe(result =>{
      this.vehicle.employeeName = result.name
    })
  }
}
else if(employeeId == null){
this.updateVehicle.employeeName = null;
this.vehicle.employeeName = null;
}

}

Submit(): void{
  if(!this.edit){
    let vehicleToAdd = new CreateVehicleDto();
    vehicleToAdd.name = this.vehicle.name;
    vehicleToAdd.employeeId = this.vehicle.employeeId;
    
    this._vehicleService.createvehicle(vehicleToAdd).subscribe();
    this.vehicle = new ViewVehicleWithEmployeeDto();
    setTimeout(() => {
    
      this.GetAllVehiclesWithEmployeeNames();
    }, 2000);

  }
  else if(this.edit){
    let vehicleToUpdate = new UpdateVehicleDto();
    vehicleToUpdate.id = this.updateVehicle.id;
    vehicleToUpdate.name = this.updateVehicle.name;
    vehicleToUpdate.employeeId = this.updateVehicle.employeeId;
    this._vehicleService.updatevehicleById(vehicleToUpdate).subscribe(result => {
      alert(`Vehicle of Id ${result} is updated successfully`)
    });
    this.updateVehicle = new ViewVehicleWithEmployeeDto();
    this.edit = false;
    setTimeout(() => {
    
      this.GetAllVehiclesWithEmployeeNames();
    }, 2000);
  }

  setTimeout(() => {
    
    this.GetAllVehiclesWithEmployeeNames();
  }, 2000);

}



GetAllVehiclesWithEmployeeNames(){
  this._vehicleService.getVehiclesWithEmployees().subscribe(result => {
      this.vehiclesWithEmployee = result;
    });
  console.log(this.vehiclesWithEmployee);
}

GetAllEmployees(){
  this._employeeService.getAllEmployees().subscribe(result => {
    this.employees = result;
  });
}

GetAllVehicles(){
  this._vehicleService.getAllvehicles().subscribe(result => {
    this.vehicles = result;
  })
}

EditVehicle(editVehicleId: number){
  this.edit = true;
  this._vehicleService.getVehicleById(editVehicleId).subscribe(vehicle => {
    this.updateVehicle = vehicle;
  })
}

// Method used when cancel button is select from the UI
CancelUpdate(){
  this.updateVehicle = new ViewVehicleWithEmployeeDto();
  this.edit = false; 
}


 DeleteVehicle(vehicle: ViewVehicleWithEmployeeDto){
      this._vehicleService.deletevehicleById(vehicle.id).subscribe(result =>
          alert(`Vehicle with Id ${result} has been deleted`)
      )
      setTimeout(() => {
    
        this.GetAllVehiclesWithEmployeeNames();
      }, 2000);
 
    }
}
