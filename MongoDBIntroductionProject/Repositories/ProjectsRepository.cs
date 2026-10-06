using MongoDB.Driver;
using MongoDBIntroductionProject.Models;

namespace MongoDBIntroductionProject.Repositories
{
    public class ProjectsRepository
    {
        private readonly IMongoCollection<Project> _projectCollection;

        public ProjectsRepository()
        {
            string connectionString = "mongodb+srv://fowcode101_db_user:HwwDv43fWKoUb1Jl@cluster0.7xn4frh.mongodb.net/";

            var client = new MongoClient(connectionString);

            var database = client.GetDatabase("projectmanagementdb");

            _projectCollection =
                database.GetCollection<Project>("projects");
        }

        public void InsertProject(Project project)
        {
            _projectCollection.InsertOne(project);
        }
    }
}