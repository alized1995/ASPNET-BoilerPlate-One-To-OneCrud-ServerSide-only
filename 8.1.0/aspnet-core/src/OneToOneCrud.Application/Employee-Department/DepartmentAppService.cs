using Abp.Application.Services;
using Abp.Domain.Repositories;
using Abp.UI;
using Microsoft.AspNetCore.Builder;
using OneToOneCrud.Company_Models;
using OneToOneCrud.Employee_Department_DTOs;
using OneToOneCrud.Employee_Department_DTOs.Department;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OneToOneCrud.Employee_Department
{
    public class DepartmentAppService : IDepartmentAppService
    {
        private readonly IRepository<Department> _departmentRepository;
     
        public DepartmentAppService(IRepository<Department> departmentRepository)
        {
            _departmentRepository = departmentRepository;
        }

        // Method to create a new department
        public void CreateDepartment(CreateDepartmentDto input)
        {

            var alreadyRelatedEmployee = _departmentRepository.FirstOrDefault(d => d.EmployeeId == input.EmployeeId);
            if (alreadyRelatedEmployee != null)
            {
                throw new UserFriendlyException("There is already a department related to given employeeId");
            }
            var department = new Department { Name = input.Name, EmployeeId = input.EmployeeId };
            _departmentRepository.Insert(department);

        }

        // Method to get a list of departments of entire table
        public async Task<List<ViewDepartmentDto>> GetAllDepartments()
        {
            var departments = await _departmentRepository.GetAllListAsync();
            var departmentViewList = new List<ViewDepartmentDto>();
            foreach (var department in departments)
            {
                var departmentDto = new ViewDepartmentDto
                {
                    Id = department.Id,
                    Name = department.Name,
                    EmployeeId = department.EmployeeId

                };
                departmentViewList.Add(departmentDto);
            }
            return departmentViewList;

        }


        // Method to update the department by given Id
        public async Task<int> UpdateDepartmentById(int updateId, UpdateDepartmentDto updateDepartmentDto)
        {
            var presentDepartmentToUpdate = await _departmentRepository.FirstOrDefaultAsync(d => d.Id == updateId);

            if (presentDepartmentToUpdate != null)
            {
                presentDepartmentToUpdate.Name = updateDepartmentDto.Name;
                presentDepartmentToUpdate.EmployeeId = updateDepartmentDto.EmployeeId;

                return updateId;
            }

            return 0;

        }

        // Method to Delete the department by given Id
        public async Task<int> DeleteDepartmentById(int deleteId)
        {
            var departmentToDelete = await _departmentRepository.FirstOrDefaultAsync(d => d.Id == deleteId);

            if (departmentToDelete != null)
            {
                await _departmentRepository.DeleteAsync(departmentToDelete);
                return deleteId;
            }
            return 0;
        }



    }
}
