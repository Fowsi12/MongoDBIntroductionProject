using MongoDBIntroductionProject.Models;
using MongoDBIntroductionProject.Repositories;

namespace MongoDBIntroductionProject.Controllers
{
    public class ProjectsController
    {
        private readonly ProjectsRepository _repository;

        public ProjectsController()
        {
            _repository = new ProjectsRepository();
        }

        public void CreateNewProject(
            string projectId,
            string name,
            string description,
            DateTime startDate)
        {
            Project newProject = new Project
            {
                Id = Guid.NewGuid().ToString(),
                ProjectId = projectId,
                Name = name,
                Description = description,
                Start_Date = startDate
            };

            _repository.InsertProject(newProject);
        }
    }
}