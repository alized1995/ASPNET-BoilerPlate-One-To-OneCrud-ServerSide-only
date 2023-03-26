using Abp.Application.Services;
using Abp.Authorization;
using Abp.Domain.Repositories;
using Abp.UI;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using OneToOneCrud.Authorization;
using OneToOneCrud.Company_Models;
using OneToOneCrud.Employee_Department_DTOs.Vehicle_DTOs;
using OneToOneCrud.Employee_vehicle_DTOs;
using OneToOneCrud.Employee_vehicle_DTOs.vehicle;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OneToOneCrud.Employee_vehicle
{
    [AbpAuthorize(PermissionNames.Pages_Employees)]
    public class VehicleAppService : IVehicleAppService
    {
        private readonly IRepository<Vehicle> _vehicleRepository;
     
        public VehicleAppService(IRepository<Vehicle> vehicleRepository)
        {
            _vehicleRepository = vehicleRepository;
        }

        // Method to create a new vehicle
        public void Createvehicle(CreateVehicleDto input)
        {

            var alreadyRelatedEmployee = _vehicleRepository.FirstOrDefault(d => d.EmployeeId == input.EmployeeId);
            if (alreadyRelatedEmployee != null)
            {
                throw new UserFriendlyException("There is already a vehicle alloted to given employeeId");
            }
            var vehicle = new Vehicle { Name = input.Name, EmployeeId = input.EmployeeId };
            _vehicleRepository.Insert(vehicle);

        }

        // Method to get a list of vehicles of entire table
        public async Task<List<ViewVehicleDto>> GetAllvehicles()
        {
            var vehicles = await _vehicleRepository.GetAllListAsync();
            var vehicleViewList = new List<ViewVehicleDto>();
            foreach (var vehicle in vehicles)
            {
                var vehicleDto = new ViewVehicleDto
                {
                    Id = vehicle.Id,
                    Name = vehicle.Name,
                    EmployeeId = vehicle.EmployeeId

                };
                vehicleViewList.Add(vehicleDto);
            }
            return vehicleViewList;

        }

        // Method to get all vehicles along with related employees

        public async Task<List<ViewVehicleWithEmployeeDto>> GetVehiclesWithEmployees()
        {
            var newList = new List<ViewVehicleWithEmployeeDto>();
            var vehicles = await _vehicleRepository.GetAll().Include(v => v.Employee).ToListAsync();
            foreach(var vehicle in vehicles)
            {
                var newVehicle = new ViewVehicleWithEmployeeDto
                {
                    Id = vehicle.Id,
                    EmployeeId = vehicle.EmployeeId,
                    Name = vehicle.Name,
                    EmployeeName = vehicle.Employee.Name
                    
                };
                newList.Add(newVehicle);
            }

            return newList;
        }

        // Method to get a vehicle by using Id
     
        public async Task<ViewVehicleWithEmployeeDto> GetVehicleById(int id)
        {
            var vehicle = await _vehicleRepository.GetAllIncluding(v => v.Employee).FirstOrDefaultAsync(v => v.Id == id);
            if (vehicle != null)
            {
                var vehicleToPass = new ViewVehicleWithEmployeeDto
                {
                    Id = vehicle.Id,
                    EmployeeId = vehicle.EmployeeId,
                    Name = vehicle.Name,
                    EmployeeName = vehicle.Employee.Name
                };
                return vehicleToPass;
            }
            throw new UserFriendlyException("There is no vehicle with this Id");
        }



        // Method to update the vehicle by given Id
        public async Task<int> UpdatevehicleById(UpdateVehicleDto updatevehicleDto)
        {
            var presentvehicleToUpdate = await _vehicleRepository.FirstOrDefaultAsync(d => d.Id == updatevehicleDto.Id);
            try
            {

                if (presentvehicleToUpdate != null)
                {

                    presentvehicleToUpdate.Name = updatevehicleDto.Name;
                    presentvehicleToUpdate.EmployeeId = updatevehicleDto.EmployeeId;

                    return updatevehicleDto.Id;
                }
            return 0;
            }
            catch(Exception)
            {
                throw new UserFriendlyException("Vehicle already allocated to this employee");
            }

        }

        // Method to Delete the vehicle by given Id
        public async Task<int> DeletevehicleById(int deleteId)
        {
            var vehicleToDelete = await _vehicleRepository.FirstOrDefaultAsync(d => d.Id == deleteId);

            if (vehicleToDelete != null)
            {
                await _vehicleRepository.DeleteAsync(vehicleToDelete);
                return deleteId;
            }
            return 0;
        }



    }
}
