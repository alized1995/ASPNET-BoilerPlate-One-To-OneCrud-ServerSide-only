using Abp.Application.Services;
using OneToOneCrud.Employee_Department_DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OneToOneCrud.Employee_Department
{
    public interface IEmployeeAppService : IApplicationService
    {
        void CreateEmployee(CreateEmployeeDto input);

        Task<List<ViewEmployeeDto>> GetAllEmployees();

        Task<int> UpdateEmployeeById(int updateId, UpdateEmployeeDto updateEmployeeDto);

        Task<int> DeleteEmployeeById(int deleteId);
    }
}
