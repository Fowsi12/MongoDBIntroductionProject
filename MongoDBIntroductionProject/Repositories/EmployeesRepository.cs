using MongoDB.Driver;
using MongoDBIntroductionProject.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace MongoDBIntroductionProject.Repositories
{
    public class EmployeesRepository
    {
        private readonly IMongoCollection<Employee> _employeeCollection;
        public EmployeesRepository()
        {
            string connectionString = "mongodb+srv://fowcode101_db_user:HwwDv43fWKoUb1Jl@cluster0.7xn4frh.mongodb.net/";

            var client = new MongoClient(connectionString);

            var database = client.GetDatabase("projectmanagementdb");

            _employeeCollection = database.GetCollection<Employee>("employees");
        }

        public void InsertEmployee(Employee employee)
        {
            // Inserts the entire employee document, including the embedded department, into MongoDB." 
            _employeeCollection.InsertOne(employee);
        }
        public Employee GetEmployeeByEmail(string email)
        {
            var filter = Builders<Employee>.Filter.Eq("Email", email);

            return _employeeCollection.Find(filter).FirstOrDefault();
        }
        public UpdateResult AssignEmployeeToDepartment(string email, Department department)
        {
            var filter = Builders<Employee>.Filter.Eq("Email", email);

            var update = Builders<Employee>.Update
                .Set("Department", department);

            return _employeeCollection.UpdateOne(filter, update);
        }
        public List<Employee> GetEmployeesByDepartment(string departmentName)
        {
            var filter = Builders<Employee>.Filter.Eq(
                "Department.Name",
                departmentName
            );

            return _employeeCollection
                .Find(filter)
                .ToList();
        }
        public UpdateResult AssignEmployeeToProject(
            string email,
            Project project)
        {
            var filter = Builders<Employee>.Filter.Eq("Email", email);

            var update = Builders<Employee>.Update
                .Push("Myprojects", project);

            return _employeeCollection.UpdateOne(filter, update);
        }
        public List<Project> GetProjectsByEmployeeEmail(string email)
        {
            var filter = Builders<Employee>.Filter.Eq("Email", email);

            Employee employee = _employeeCollection
                .Find(filter)
                .FirstOrDefault();

            if (employee != null)
            {
                return employee.Myprojects;
            }

            return new List<Project>();
        }
        public UpdateResult UpdateProjectStatusForAllEmployees(
            string projectId,
            string status)
        {
            var filter = Builders<Employee>.Filter.Eq(
                "Myprojects.ProjectId",
                projectId
            );

            var update = Builders<Employee>.Update.Set(
                "Myprojects.$.Status",
                status
            );

            return _employeeCollection.UpdateMany(filter, update);
        }
        public UpdateResult PullFinishedProjects(string status)
        {
            var filter = Builders<Employee>.Filter.Empty;

            var update = Builders<Employee>.Update.PullFilter<Project>(
                "Myprojects",
                Builders<Project>.Filter.Eq("Status", status)
            );

            return _employeeCollection.UpdateMany(filter, update);
        }
    }
}
