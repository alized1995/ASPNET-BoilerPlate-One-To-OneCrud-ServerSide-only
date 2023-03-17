using Abp.Application.Services;
using Abp.Domain.Repositories;
using Abp.UI;
using Castle.DynamicProxy.Generators;
using JetBrains.Annotations;
using Microsoft.AspNetCore.Mvc;
using OneToOneCrud.Company_Models;
using OneToOneCrud.Employee_Department_DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OneToOneCrud.Employee_Department
{
    public class EmployeeAppService : IEmployeeAppService
    {
        private readonly IRepository<Employee> _employeeRepository;
        public EmployeeAppService(IRepository<Employee> employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }

        // Method to create a new employee
        public void CreateEmployee(CreateEmployeeDto input)
        {
            var employee = _employeeRepository.FirstOrDefault(e => e.Name ==  input.Name);
            if(employee != null)
            {
                throw new UserFriendlyException("There is already an employee with given name");
            }

            employee = new Employee { Name = input.Name , Address = input.Address, Designation = input.Designation};
            _employeeRepository.Insert(employee);
        }

        // Method to get a list of employees
        public async Task<List<ViewEmployeeDto>> GetAllEmployees()
        {
            var employees = await _employeeRepository.GetAllListAsync();
            var employeesViewList = new List<ViewEmployeeDto>();
            foreach(var employee in employees)
            {
                var employeeDto = new ViewEmployeeDto
                {
                    Name = employee.Name,
                    Address = employee.Address,
                    Designation = employee.Designation,
                    Id = employee.Id

                };
                employeesViewList.Add(employeeDto);
            }
            return employeesViewList;

            
        }

        // Method to update an employee by given Id
        public async Task<int> UpdateEmployeeById(int updateId, UpdateEmployeeDto updateEmployeeDto)
        {
            var presentEmployeeToUpdate = await _employeeRepository.FirstOrDefaultAsync(e => e.Id == updateId);

            if (presentEmployeeToUpdate != null)
            {
                presentEmployeeToUpdate.Name = updateEmployeeDto.Name;
                presentEmployeeToUpdate.Address = updateEmployeeDto.Address;
                presentEmployeeToUpdate.Department = null;
                presentEmployeeToUpdate.Designation = updateEmployeeDto.Designation;

                return updateId;
            }

            return 0;
            
        }


        // Method to Delete an employee by given Id
        public async Task<int> DeleteEmployeeById(int deleteId)
        {
            var employeeToDelete = await _employeeRepository.FirstOrDefaultAsync(e => e.Id == deleteId);

            if (employeeToDelete != null)
            {
                await _employeeRepository.DeleteAsync(employeeToDelete);
                return deleteId;
            }
            return 0;
        }
    }
}
