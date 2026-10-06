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

        public void CreateNewEmployee(
            int employeeId,
            string name,
            string email,
            string deptId,
            string deptName)
        {
            // Opret det indlejrede Department-objekt
            Department embeddedDept = new Department
            {
                DepartmentId = deptId,
                Name = deptName
            };

            // Opret Employee-objektet
            Employee newEmployee = new Employee
            {
                EmployeeId = employeeId,
                Name = name,
                Email = email,
                Department = embeddedDept
            };

            // Send medarbejderen videre til repository
            _repository.InsertEmployee(newEmployee);
        }

        public Employee GetEmployeeByEmail(string email)
        {
            return _repository.GetEmployeeByEmail(email);
        }

        public bool AssignEmployeeToDepartment(
            string email,
            string departmentId,
            string departmentName)
        {
            // Opret den afdeling medarbejderen skal tilknyttes
            Department department = new Department
            {
                DepartmentId = departmentId,
                Name = departmentName
            };

            // Bed repository om at opdatere medarbejderen i MongoDB
            var result = _repository.AssignEmployeeToDepartment(
                email,
                department
            );

            // MatchedCount fortæller om medarbejderen blev fundet
            return result.MatchedCount > 0;
        }
        public List<Employee> GetEmployeesByDepartment(string departmentName)
        {
            return _repository.GetEmployeesByDepartment(departmentName);
        }
        public bool AssignEmployeeToProject(
            string email,
            string projectId,
            string projectName,
            string description,
            DateTime startDate)
        {
            Project project = new Project
            {
                Id = Guid.NewGuid().ToString(),
                ProjectId = projectId,
                Name = projectName,
                Description = description,
                Start_Date = startDate
            };

            var result = _repository.AssignEmployeeToProject(
                email,
                project
            );

            return result.MatchedCount > 0;
        }
        public List<Project> GetProjectsByEmployeeEmail(string email)
        {
            return _repository.GetProjectsByEmployeeEmail(email);
        }
        public long UpdateProjectStatusForAllEmployees(
            string projectId,
            string status)
        {
            var result =
                _repository.UpdateProjectStatusForAllEmployees(
                    projectId,
                    status
                );

            return result.ModifiedCount;
        }
        public long PullFinishedProjects(string status)
        {
            var result = _repository.PullFinishedProjects(status);

            return result.ModifiedCount;
        }
    }
}