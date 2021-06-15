using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CSharp_EmployeeConsoleAppWithDALAssignment.BusinessLogic;
using CSharp_EmployeeConsoleAppWithDALAssignment.Models;

namespace CSharp_EmployeeConsoleAppWithDALAssignment
{
    class Program
    {
        static void Main(string[] args)
        {
            //// 
            /// This app demonstrates the use of a Data Access layer using the Repository Pattern
            ///  Main Program -> Business Logic -> (Data Library) Repository -> Data Access Layer -> Stored Procs -> Data
            ///  
            bool keepGoing = true;

            while (keepGoing)
            {
                Console.WriteLine("Please choose from the menu below.");
                Console.WriteLine("[1]  View all employees");
                Console.WriteLine("[2]  View employees who live in a specific state");
                Console.WriteLine("[3]  View employees who started after a specific date");

                string choice = Console.ReadLine();

                switch(choice)
                {
                    case "1":
                        DisplayAllEmployees();
                        break;
                    case "2":
                        Console.WriteLine("Please enter state abbreviation to filter employees by.");
                        string filterState = Console.ReadLine();
                        DisplayEmployeesByState(filterState);
                        break;
                    case "3":
                        Console.WriteLine("Please enter date (mm/dd/yyyy) to see employees who started after that date.");
                        string filterDate = Console.ReadLine();
                        DisplayEmployeesByStartDate(filterDate);
                        break;
                    default:
                        Console.WriteLine($"{choice} is not a valid choice.");
                        break;
                }

                Console.WriteLine("Keep going? Yes / No");
                string keepGoingChoice = Console.ReadLine();
                if(keepGoingChoice.ToLower() == "yes")
                {
                    keepGoing = true;
                }
                else
                {
                    keepGoing = false;
                }
            }
            Console.WriteLine("Press any key to end.");
            Console.ReadKey();
        }

        private static void DisplayAllEmployees()
        {
            EmployeeBL employeeBL = new EmployeeBL();
            List<EmployeeModel> employeeModels = employeeBL.GetAllEmployees();
            WriteEmployeeInfoToConsole(employeeModels);           
        }

        private static void DisplayEmployeesByState(string state)
        {
            EmployeeBL employeeBL = new EmployeeBL();
            List<EmployeeModel> employeeModels = employeeBL.GetEmployeesByState(state);
            WriteEmployeeInfoToConsole(employeeModels);
        }

        private static void DisplayEmployeesByStartDate(string startDate)
        {
            EmployeeBL employeeBL = new EmployeeBL();
            List<EmployeeModel> employeeModels = employeeBL.GetEmployeesByStartDate(startDate);
            WriteEmployeeInfoToConsole(employeeModels);
        }

        private static void WriteEmployeeInfoToConsole(List<EmployeeModel> employees)
        {
            foreach (EmployeeModel employee in employees)
            {
                Console.WriteLine($"Name: {employee.Name}. Address: {employee.StreetAddress}, {employee.City}, {employee.Zip}.  " +
                    $"Start Date: {employee.EmploymentStartDate}.  End Date: {employee.EmploymentEndDate}.");
            }
        }
    }
}
