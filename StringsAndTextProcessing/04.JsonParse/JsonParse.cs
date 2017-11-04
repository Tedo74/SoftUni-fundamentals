using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04.JsonParse
{
    class JsonParse
    {
        static void Main()
        {
            string input = Console.ReadLine();
            input = input.Substring(2, input.Length - 4);
            string[] student = input.Split(new string[] {"},{"}, StringSplitOptions.RemoveEmptyEntries);
            
            foreach (var s in student)
            {
                Console.WriteLine($"{Getname(s)} : {GetAge(s)} -> {GetGrades(s)}");
            }
        }

        static string Getname(string student)
        {
            int nameStart = student.IndexOf("\"", 0);
            int nameEnd = student.IndexOf("\"", nameStart + 1);
            string name = student.Substring(nameStart + 1, nameEnd - 1 - nameStart);
            return name;
        }

        static string GetAge(string student)
        {
            int firstComma = student.IndexOf(",");
            int first2points = student.IndexOf(":");
            int ageStart = student.IndexOf(":", first2points + 1);
            int ageEnd = student.IndexOf(",",firstComma + 1);
            string age = student.Substring(ageStart + 1, ageEnd - 1 - ageStart);
            return age;
        }

        static string GetGrades(string student)
        {
            int start = student.IndexOf("[");
            int end = student.IndexOf("]");
            string grades = student.Substring(start + 1, end - 1 - start);
            if (grades == String.Empty)
            {
                grades = "None";
            }
            
            return grades;
        }
    }
}
