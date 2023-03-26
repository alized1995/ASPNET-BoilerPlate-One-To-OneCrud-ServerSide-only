using Abp.Application.Services;
using Abp.Authorization;
using Abp.Domain.Repositories;
using Abp.UI;
using Castle.DynamicProxy.Generators;
using JetBrains.Annotations;
using Microsoft.AspNetCore.Mvc;
using OneToOneCrud.Authorization;
using OneToOneCrud.Company_Models;
using OneToOneCrud.Employee_vehicle_DTOs;
using OneToOneCrud.Employee_vehicle_DTOs.Employee_DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OneToOneCrud.Employee_vehicle
{
    [AbpAuthorize(PermissionNames.Pages_Employees)]
    public class EmployeeAppService : IEmployeeAppService
    {
        private readonly IRepository<Employee> _employeeRepository;
        public EmployeeAppService(IRepository<Employee> employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }

        // Method to create a new employee
        public async Task CreateEmployee(CreateEmployeeDto input)
        {

            var employee = await _employeeRepository.FirstOrDefaultAsync(e => e.Name == input.Name);
            if (employee != null)
            {
                throw new UserFriendlyException("There is already an employee with given name");
            }


            employee = new Employee { Name = input.Name, Address = input.Address, Designation = input.Designation };
            await _employeeRepository.InsertAsync(employee);
        }

        // Method to get a list of employees
        public async Task<List<ViewEmployeeDto>> GetAllEmployees()
        {
            var employees = await _employeeRepository.GetAllListAsync();
            var employeesViewList = new List<ViewEmployeeDto>();
            foreach (var employee in employees)
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

        // Method to get an employee by using Id
        public async Task<ViewEmployeeDto> GetEmployeeById(int id)
        {
            var employee = await _employeeRepository.FirstOrDefaultAsync(e => e.Id == id);
            if (employee != null)
            {
                var employeeToPass = new ViewEmployeeDto
                {
                    Id = employee.Id,
                    Name = employee.Name,
                    Address = employee.Address,
                    Designation = employee.Designation
                };
            return employeeToPass;
            }
            throw new UserFriendlyException("There is no employee with this Id");
        }

        // Method to update an employee by given Id
        public async Task<int> UpdateEmployee(UpdateEmployeeDto updateEmployeeDto)
        {
            var presentEmployeeToUpdate = await _employeeRepository.FirstOrDefaultAsync(e => e.Id == updateEmployeeDto.Id);

            if (presentEmployeeToUpdate != null)
            {

                presentEmployeeToUpdate.Name = updateEmployeeDto.Name;
                presentEmployeeToUpdate.Address = updateEmployeeDto.Address;
                presentEmployeeToUpdate.Vehicle = null;
                presentEmployeeToUpdate.Designation = updateEmployeeDto.Designation;

                return updateEmployeeDto.Id;
            }

            return 0;

        }


        // Method to Delete an employee by given Id
        public async Task<int> DeleteEmployeeById (int id)
        {
            var employeeToDelete = await _employeeRepository.FirstOrDefaultAsync(e => e.Id == id);

            if (employeeToDelete != null)
            {
                await _employeeRepository.DeleteAsync(employeeToDelete);
                return employeeToDelete.Id;
            }
            return 0;
        }
    }
}
