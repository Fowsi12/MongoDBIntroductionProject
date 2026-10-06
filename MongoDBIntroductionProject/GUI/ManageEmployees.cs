using MongoDBIntroductionProject.Controllers;
using System;
using System.Collections.Generic;
using System.Text;
using MongoDBIntroductionProject.Models;

namespace MongoDBIntroductionProject.GUI
{
    internal class ManageEmployees
    {
        private readonly EmployeesController _controller;

        public ManageEmployees()
        {
            _controller = new EmployeesController();
        }

        public void Show()
        {
            Console.Clear();

            Console.WriteLine("======================================");
            Console.WriteLine("          MEDARBEJDERE");
            Console.WriteLine("======================================");

            Console.WriteLine("1. Opret medarbejder");
            Console.WriteLine("2. Søg medarbejder via email");
            Console.WriteLine("3. Tilknyt medarbejder til afdeling");
            Console.WriteLine("4. Find medarbejdere via afdeling");
            Console.WriteLine("5. Tilknyt medarbejder til projekt");
            Console.WriteLine("6. Vis medarbejderens projekter");
            Console.WriteLine("7. Opdater projektstatus for alle medarbejdere");
            Console.WriteLine("8. Fjern afsluttede projekter");
            

            Console.Write("\nVælg: ");
            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    CreateEmployee();
                    break;

                case "2":
                    SearchEmployeeByEmail();
                    break;

                case "3":
                    AssignEmployeeToDepartment();
                    break;
                
                case "4":
                    FindEmployeesByDepartment();
                    break;
                
                case "5":
                    AssignEmployeeToProject();
                    break;
                
                case "6":
                    ViewEmployeeProjects();
                    break;
                
                case "7":
                    UpdateProjectStatusForAllEmployees();
                    break;
                
                case "8":
                    PullFinishedProjects();
                    break;

                default:
                    Console.WriteLine("Ugyldigt valg.");
                    break;
            }
        }

        private void CreateEmployee()
        {
            Console.Write("Indtast Medarbejder ID: ");
            int employeeId = int.Parse(Console.ReadLine());

            Console.Write("Indtast Navn: ");
            string name = Console.ReadLine();

            Console.Write("Indtast E-mail: ");
            string email = Console.ReadLine();

            Console.Write("Afdelings ID: ");
            string deptId = Console.ReadLine();

            Console.Write("Afdelings Navn: ");
            string deptName = Console.ReadLine();

            _controller.CreateNewEmployee(
                employeeId,
                name,
                email,
                deptId,
                deptName
            );

            Console.WriteLine("Medarbejder oprettet.");
        }

        private void SearchEmployeeByEmail()
        {
            Console.Write("Indtast medarbejderens email: ");
            string email = Console.ReadLine();

            Employee employee = _controller.GetEmployeeByEmail(email);

            if (employee != null)
            {
                Console.WriteLine("\nMedarbejder fundet:");
                Console.WriteLine($"ID: {employee.EmployeeId}");
                Console.WriteLine($"Navn: {employee.Name}");
                Console.WriteLine($"Email: {employee.Email}");
            }
            else
            {
                Console.WriteLine("\nIngen medarbejder fundet.");
            }

            Console.ReadKey();
        }

        private void AssignEmployeeToDepartment()
        {
            Console.WriteLine("\n======================================");
            Console.WriteLine("   TILKNYT MEDARBEJDER TIL AFDELING");
            Console.WriteLine("======================================");

            Console.Write("Indtast medarbejderens email: ");
            string email = Console.ReadLine();

            Console.Write("Indtast Afdelings ID: ");
            string departmentId = Console.ReadLine();

            Console.Write("Indtast Afdelings Navn: ");
            string departmentName = Console.ReadLine();

            bool updated = _controller.AssignEmployeeToDepartment(
                email,
                departmentId,
                departmentName
            );

            if (updated)
            {
                Console.WriteLine("\nMedarbejderen blev tilknyttet afdelingen.");
            }
            else
            {
                Console.WriteLine("\nMedarbejderen blev ikke fundet.");
            }

            Console.WriteLine("\nTryk på en tast for at fortsætte...");
            Console.ReadKey();
        }
        private void FindEmployeesByDepartment()
        {
            Console.WriteLine("\n======================================");
            Console.WriteLine("   FIND MEDARBEJDERE VIA AFDELING");
            Console.WriteLine("======================================");

            Console.Write("Indtast afdelingens navn: ");
            string departmentName = Console.ReadLine();

            List<Employee> employees =
                _controller.GetEmployeesByDepartment(departmentName);

            if (employees.Count > 0)
            {
                Console.WriteLine("\nMedarbejdere fundet:");

                foreach (Employee employee in employees)
                {
                    Console.WriteLine("------------------------------");
                    Console.WriteLine($"ID: {employee.EmployeeId}");
                    Console.WriteLine($"Navn: {employee.Name}");
                    Console.WriteLine($"Email: {employee.Email}");
                    Console.WriteLine($"Afdeling: {employee.Department.Name}");
                }
            }
            else
            {
                Console.WriteLine("\nIngen medarbejdere fundet i afdelingen.");
            }

            Console.WriteLine("\nTryk på en tast for at fortsætte...");
            Console.ReadKey();
        }
        private void AssignEmployeeToProject()
        {
            Console.WriteLine("\n======================================");
            Console.WriteLine("    TILKNYT MEDARBEJDER TIL PROJEKT");
            Console.WriteLine("======================================");

            Console.Write("Indtast medarbejderens email: ");
            string email = Console.ReadLine();

            Console.Write("Indtast Projekt ID: ");
            string projectId = Console.ReadLine();

            Console.Write("Indtast Projekt Navn: ");
            string projectName = Console.ReadLine();

            Console.Write("Indtast Projekt Beskrivelse: ");
            string description = Console.ReadLine();

            Console.Write("Indtast Startdato (fx 06-10-2026): ");
            DateTime startDate = DateTime.Parse(Console.ReadLine());

            bool updated = _controller.AssignEmployeeToProject(
                email,
                projectId,
                projectName,
                description,
                startDate
            );

            if (updated)
            {
                Console.WriteLine(
                    "\nMedarbejderen blev tilknyttet projektet."
                );
            }
            else
            {
                Console.WriteLine(
                    "\nMedarbejderen blev ikke fundet."
                );
            }

            Console.WriteLine("\nTryk på en tast for at fortsætte...");
            Console.ReadKey();
        }
        private void ViewEmployeeProjects()
        {
            Console.WriteLine("\n======================================");
            Console.WriteLine("       VIS MEDARBEJDERENS PROJEKTER");
            Console.WriteLine("======================================");

            Console.Write("Indtast medarbejderens email: ");
            string email = Console.ReadLine();

            List<Project> projects =
                _controller.GetProjectsByEmployeeEmail(email);

            if (projects.Count > 0)
            {
                Console.WriteLine("\nProjekter:");

                foreach (Project project in projects)
                {
                    Console.WriteLine("------------------------------");
                    Console.WriteLine($"Projekt ID: {project.ProjectId}");
                    Console.WriteLine($"Navn: {project.Name}");
                    Console.WriteLine($"Beskrivelse: {project.Description}");
                    Console.WriteLine($"Startdato: {project.Start_Date:d}");
                }
            }
            else
            {
                Console.WriteLine(
                    "\nIngen projekter fundet for medarbejderen."
                );
            }

            Console.WriteLine("\nTryk på en tast for at fortsætte...");
            Console.ReadKey();
        }
        private void UpdateProjectStatusForAllEmployees()
        {
            Console.WriteLine("\n======================================");
            Console.WriteLine("       OPDATER PROJEKTSTATUS");
            Console.WriteLine("======================================");

            Console.Write("Indtast Projekt ID: ");
            string projectId = Console.ReadLine();

            Console.Write("Indtast ny status: ");
            string status = Console.ReadLine();

            long updatedEmployees =
                _controller.UpdateProjectStatusForAllEmployees(
                    projectId,
                    status
                );

            if (updatedEmployees > 0)
            {
                Console.WriteLine(
                    $"\nProjektstatus blev opdateret hos {updatedEmployees} medarbejder(e)."
                );
            }
            else
            {
                Console.WriteLine(
                    "\nIngen medarbejdere med dette projekt blev fundet."
                );
            }

            Console.WriteLine("\nTryk på en tast for at fortsætte...");
            Console.ReadKey();
        }
        private void PullFinishedProjects()
        {
            Console.WriteLine("\n======================================");
            Console.WriteLine("       FJERN AFSLUTTEDE PROJEKTER");
            Console.WriteLine("======================================");

            Console.Write("Indtast status der skal fjernes (fx Finished): ");
            string status = Console.ReadLine();

            long updatedEmployees =
                _controller.PullFinishedProjects(status);

            if (updatedEmployees > 0)
            {
                Console.WriteLine(
                    $"\nAfsluttede projekter blev fjernet hos {updatedEmployees} medarbejder(e)."
                );
            }
            else
            {
                Console.WriteLine(
                    "\nIngen projekter med denne status blev fundet."
                );
            }

            Console.WriteLine("\nTryk på en tast for at fortsætte...");
            Console.ReadKey();
        }
    }
}