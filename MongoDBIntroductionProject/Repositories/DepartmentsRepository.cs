using MongoDB.Driver;
using MongoDBIntroductionProject.Models;

namespace MongoDBIntroductionProject.Repositories
{
    public class DepartmentsRepository
    {
        private readonly IMongoCollection<Department> _departmentCollection;

        public DepartmentsRepository()
        {
            string connectionString = "mongodb+srv://fowcode101_db_user:HwwDv43fWKoUb1Jl@cluster0.7xn4frh.mongodb.net/";

            var client = new MongoClient(connectionString);

            var database = client.GetDatabase("projectmanagementdb");

            _departmentCollection =
                database.GetCollection<Department>("departments");
        }

        public void InsertDepartment(Department department)
        {
            _departmentCollection.InsertOne(department);
        }
    }
}