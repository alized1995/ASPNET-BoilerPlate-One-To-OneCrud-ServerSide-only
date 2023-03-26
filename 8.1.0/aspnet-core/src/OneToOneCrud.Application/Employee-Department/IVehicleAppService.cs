using Abp.Application.Services;
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
    public interface IVehicleAppService : IApplicationService
    {
        void Createvehicle(CreateVehicleDto input);

        Task<List<ViewVehicleDto>> GetAllvehicles();

        Task<int> UpdatevehicleById( UpdateVehicleDto updatevehicleDto);

        Task<int> DeletevehicleById(int deleteId);

        Task<ViewVehicleWithEmployeeDto> GetVehicleById(int id);

        Task<List<ViewVehicleWithEmployeeDto>> GetVehiclesWithEmployees();


    }
}
