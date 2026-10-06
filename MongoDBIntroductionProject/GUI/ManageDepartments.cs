using MongoDBIntroductionProject.Controllers;

namespace MongoDBIntroductionProject.GUI
{
    internal class ManageDepartments
    {
        private readonly DepartmentsController _controller;

        public ManageDepartments()
        {
            _controller = new DepartmentsController();
        }

        public void Show()
        {
            Console.Clear();

            Console.WriteLine("======================================");
            Console.WriteLine("          OPRET NY AFDELING");
            Console.WriteLine("======================================");

            Console.Write("Indtast Afdelings ID: ");
            string departmentId = Console.ReadLine();

            Console.Write("Indtast Afdelings Navn: ");
            string name = Console.ReadLine();

            Console.WriteLine("\nOpretter afdeling...");

            _controller.CreateNewDepartment(departmentId, name);

            Console.WriteLine("\nAfdeling oprettet!");
            Console.WriteLine("Tryk på en tast for at lukke programmet...");
            Console.ReadKey();
        }
    }
}