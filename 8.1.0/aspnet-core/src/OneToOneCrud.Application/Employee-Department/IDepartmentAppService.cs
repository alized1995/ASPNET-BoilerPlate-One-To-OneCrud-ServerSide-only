using Abp.Application.Services;
using OneToOneCrud.Employee_Department_DTOs;
using OneToOneCrud.Employee_Department_DTOs.Department;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OneToOneCrud.Employee_Department
{
    public interface IDepartmentAppService : IApplicationService
    {
        void CreateDepartment(CreateDepartmentDto input);

        Task<List<ViewDepartmentDto>> GetAllDepartments();

        Task<int> UpdateDepartmentById(int updateId, UpdateDepartmentDto updateDepartmentDto);

        Task<int> DeleteDepartmentById(int deleteId);


    }
}
