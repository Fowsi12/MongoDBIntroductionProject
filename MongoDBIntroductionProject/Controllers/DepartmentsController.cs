using MongoDBIntroductionProject.Models;
using MongoDBIntroductionProject.Repositories;

namespace MongoDBIntroductionProject.Controllers
{
    public class DepartmentsController
    {
        private readonly DepartmentsRepository _repository;

        public DepartmentsController()
        {
            _repository = new DepartmentsRepository();
        }

        public void CreateNewDepartment(string departmentId, string name)
        {
            Department newDepartment = new Department
            {
                DepartmentId = departmentId,
                Name = name
            };

            _repository.InsertDepartment(newDepartment);
        }
    }
}