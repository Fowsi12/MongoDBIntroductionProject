using MongoDBIntroductionProject.GUI;

internal class Program
{
    private static void Main(string[] args)
    {
        Console.WriteLine("======================================");
        Console.WriteLine("         PROJECT MANAGEMENT");
        Console.WriteLine("======================================");

        Console.WriteLine("1. Medarbejdere");
        Console.WriteLine("2. Afdelinger");
        Console.WriteLine("3. Projekter");
        Console.WriteLine("4. Afslut");

        Console.Write("\nVælg en mulighed: ");
        string choice = Console.ReadLine();

        switch (choice)
        {
            case "1":
                ManageEmployees employeesMenu = new ManageEmployees();
                employeesMenu.Show();
                break;

            case "2":
                ManageDepartments departmentsMenu = new ManageDepartments();
                departmentsMenu.Show();
                break;

            case "3":
                ManageProjects projectsMenu = new ManageProjects();
                projectsMenu.Show();
                break;

            case "4":
                Console.WriteLine("Programmet afsluttes...");
                break;

            default:
                Console.WriteLine("Ugyldigt valg.");
                break;
        }
    }
}