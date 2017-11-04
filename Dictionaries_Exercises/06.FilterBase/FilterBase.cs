using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _06.FilterBase
{
    class FilterBase
    {
        static void Main(string[] args)
        {
            Dictionary<string, int> employeesAge = new Dictionary<string, int>();
            Dictionary<string, string> employeesPosition = new Dictionary<string, string>();
            Dictionary<string, double> employeesSalary = new Dictionary<string, double>();
            string[] input = Console.ReadLine()
                .Split(new char[] { ' ', '-', '>' }, StringSplitOptions.RemoveEmptyEntries);
            while (input[0] != "filter" && input[1] != "base")
            {
                int age;
                double salary;
                if (int.TryParse(input[1], out age))
                {
                    employeesAge[input[0]] = age;
                }
                else if (double.TryParse(input[1], out salary))
                {
                    employeesSalary[input[0]] = salary;
                }
                else
                {
                    employeesPosition[input[0]] = input[1];
                }
                input = Console.ReadLine()
                    .Split(new char[] { ' ', '-', '>' }, StringSplitOptions.RemoveEmptyEntries);
            }
            string filter = Console.ReadLine();
            if (filter == "Position")
            {
                foreach (KeyValuePair<string, string> employee in employeesPosition)
                {
                    Console.WriteLine($"Name: {employee.Key}");
                    Console.WriteLine($"Position: {employee.Value}");
                    Console.WriteLine(new string('=', 20));
                }
            }
            else if (filter == "Age")
            {
                foreach (KeyValuePair<string, int> employee in employeesAge)
                {
                    Console.WriteLine($"Name: {employee.Key}");
                    Console.WriteLine($"Age: {employee.Value}");
                    Console.WriteLine(new string('=', 20));
                }
            }
            else
            {
                foreach (KeyValuePair<string, double> employee in employeesSalary)
                {
                    Console.WriteLine($"Name: {employee.Key}");
                    Console.WriteLine($"Salary: {employee.Value:F2}");
                    Console.WriteLine(new string('=', 20));
                }
            }
        }
    }
}
