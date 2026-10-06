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
    }
}
