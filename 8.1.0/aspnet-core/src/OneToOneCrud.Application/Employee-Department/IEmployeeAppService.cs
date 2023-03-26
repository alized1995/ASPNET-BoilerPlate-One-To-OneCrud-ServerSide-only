using Abp.Application.Services;
using OneToOneCrud.Employee_vehicle_DTOs;
using OneToOneCrud.Employee_vehicle_DTOs.Employee_DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OneToOneCrud.Employee_vehicle
{
    public interface IEmployeeAppService : IApplicationService
    {
        Task CreateEmployee(CreateEmployeeDto input);

        Task<List<ViewEmployeeDto>> GetAllEmployees();

        Task<int> UpdateEmployee(UpdateEmployeeDto updateEmployeeDto);

        Task<int> DeleteEmployeeById(int id);

        Task<ViewEmployeeDto> GetEmployeeById(int id);
    }
}
