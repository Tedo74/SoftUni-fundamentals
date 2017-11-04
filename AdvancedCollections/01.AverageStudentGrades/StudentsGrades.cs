using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01.AverageStudentGrades
{
    class StudentsGrades
    {
        static void Main(string[] args)
        {
            Dictionary<string, List<double>> studentsGrade = new Dictionary<string, List<double>>();
            int n = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                string[] info = Console.ReadLine().Split(' ').ToArray();
                string student = info[0];
                double grade = double.Parse(info[1]);
                if (!studentsGrade.ContainsKey(student))
                {
                    studentsGrade.Add(student, new List<double>());
                }
                studentsGrade[student].Add(grade);
            }
            foreach (KeyValuePair<string,List<double>> studentsData in studentsGrade)
            {
                double avg = studentsData.Value.Average();
                Console.WriteLine($"{studentsData.Key} -> {string.Join(" ",studentsData.Value.Select(g => string.Format("{0:F2}",g)).ToArray())} (avg: {avg:F2})");
            }
        }
    }
}
