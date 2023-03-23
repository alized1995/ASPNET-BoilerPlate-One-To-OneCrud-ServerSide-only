import { Component, OnInit } from '@angular/core';
import { CreateVehicleDto, EmployeeServiceProxy, UpdateVehicleDto, VehicleServiceProxy, ViewEmployeeDto, ViewVehicleDto } from '@shared/service-proxies/service-proxies';

declare var window: any;
@Component({
  selector: 'app-vehicle',
  templateUrl: './vehicle.component.html',
  styleUrls: ['./vehicle.component.css']
})
export class VehicleComponent implements OnInit {
  // Global Declarations
  employees: ViewEmployeeDto[];
  filterEmployeeIds: number[];
  vehicles: ViewVehicleDto[];
  designations: string[];
  vehicle: CreateVehicleDto;
  updateVehicle: UpdateVehicleDto;
  edit: boolean;
  selectEmployee: string;


constructor(private _employeeService: EmployeeServiceProxy, private _vehicleService: VehicleServiceProxy){
  this.GetAllEmployees();
  this.vehicle = new CreateVehicleDto();
  this.updateVehicle = new UpdateVehicleDto();
  this.selectEmployee = 'Select Employee ID';
  
}

ngOnInit(): void {
  this.edit = false;
  this.GetAllEmployees();
  this.GetAllVehicles();
    
  }


EmployeeId(employeeId: number){
  if(this.edit){
  
    this.updateVehicle.employeeId = employeeId;
  }
  else if(!this.edit){
    this.vehicle.employeeId = employeeId;
  }
}

Submit(): void{
  
    this._vehicleService.createvehicle(this.vehicle).subscribe();
    
    this.vehicle = new CreateVehicleDto();

  setTimeout(() => {
    
    this.GetAllVehicles();
  }, 2000);

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

EditVehicle(editVehicle: UpdateVehicleDto){
  console.log(editVehicle);
  this.edit = true;
  this.updateVehicle = editVehicle.clone();
}

UpdateVehicle(action: string){
  if(action == 'update'){
  this._vehicleService.updatevehicleById(this.updateVehicle).subscribe(result => {
    alert(`Vehicle with Id ${result} has been updated successfully`);
  });
  setTimeout(() => {
    
    this.GetAllVehicles();
  }, 2000);
  this.updateVehicle = new UpdateVehicleDto();
  this.edit = false;
  }
  else if(action == 'cancel'){
    this.updateVehicle = new UpdateVehicleDto();
    this.edit = false;
  }
}

 DeleteVehicle(vehicle: UpdateVehicleDto){
      this._vehicleService.deletevehicleById(vehicle.id).subscribe(result =>
          alert(`Vehicle with Id ${result} has been deleted`)
      )
      setTimeout(() => {
    
        this.GetAllVehicles();
      }, 2000);
 
    }
}
