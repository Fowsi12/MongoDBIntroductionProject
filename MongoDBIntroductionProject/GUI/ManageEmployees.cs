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
    }
}


