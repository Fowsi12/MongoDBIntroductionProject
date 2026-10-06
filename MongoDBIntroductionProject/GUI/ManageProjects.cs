using MongoDBIntroductionProject.Controllers;

namespace MongoDBIntroductionProject.GUI
{
    internal class ManageProjects
    {
        private readonly ProjectsController _controller;

        public ManageProjects()
        {
            _controller = new ProjectsController();
        }

        public void Show()
        {
            Console.Clear();

            Console.WriteLine("======================================");
            Console.WriteLine("          OPRET NYT PROJEKT");
            Console.WriteLine("======================================");

            Console.Write("Indtast Projekt ID: ");
            string projectId = Console.ReadLine();

            Console.Write("Indtast Projekt Navn: ");
            string name = Console.ReadLine();

            Console.Write("Indtast Beskrivelse: ");
            string description = Console.ReadLine();

            Console.Write("Indtast Startdato (fx 30-09-2026): ");
            DateTime startDate = DateTime.Parse(Console.ReadLine());

            Console.WriteLine("\nOpretter projekt...");

            _controller.CreateNewProject(
                projectId,
                name,
                description,
                startDate
            );

            Console.WriteLine("\nProjekt oprettet!");
            Console.WriteLine("Tryk på en tast for at lukke programmet...");
            Console.ReadKey();
        }
    }
}