
using DemoApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DemoApi.EmployeeData
{
    public class MockEmployeeData : IEmployeeData
    {

        private List<Employee> employees = new List<Employee>()
        {
            new Employee()
            {
                Id =Guid.NewGuid(),
                Name="第一個編號"

            },
            new Employee()
            {
                Id =Guid.NewGuid(),
                Name="第二個編號"

            },
            new Employee()
            {
                Id =Guid.NewGuid(),
                Name="第三個編號"

            },

        };
        public Employee AddEmployee(Employee employee)
        {
            employee.Id = Guid.NewGuid();
            employees.Add(employee);
            return employee;
        }

        public void DeleteEmployee(Employee employee)
        {
            employees.Remove(employee);
        }

        public Employee EditEmployee(Employee employee)
        {
            var existingEmployee = GetEmployee(employee.Id);
            existingEmployee.Name = employee.Name;
            return existingEmployee;
        }

        public Employee GetEmployee(Guid id)
        {
            return employees.SingleOrDefault(x => x.Id == id);
        }

        public List<Employee> GetEmployees()
        {
            return employees;
        }
    }
}
