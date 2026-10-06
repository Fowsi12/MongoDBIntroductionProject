using MongoDBIntroductionProject.Models;
using MongoDBIntroductionProject.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace MongoDBIntroductionProject.Controllers
{
    public class EmployeesController
    {
        private readonly EmployeesRepository _repository;
        public EmployeesController()
        {
            _repository = new EmployeesRepository();
        }

        public void CreateNewEmployee(int employeeId, string name, string email, string deptId, string deptName)
        {
            // Opret det indlejrede Department-objekt
            Department embeddedDept = new Department
            {
                DepartmentId = deptId,
                Name = deptName
            };

            // Opret hoveddokumentet (Employee) og tilknyt den indlejrede afdeling
            Employee newEmployee =  new Employee
            {
                EmployeeId = employeeId,
                Name = name,
                Email = email,
                Department = embeddedDept
            };

            // Send objektet direkte videre til datalaget (Repository)
            _repository.InsertEmployee(newEmployee);
        }
        public Employee GetEmployeeByEmail(string email)
        {
            return _repository.GetEmployeeByEmail(email);
        }
    }
}
