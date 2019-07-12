using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestMateAcademy
{
    class Program
    {
        static void Main(string[] args)
        {
            Competition members = new Competition();
            Console.Write("Input amount of gymnasts: ");
            try
            {
                int n = Convert.ToInt32(Console.ReadLine());

                for (int i = 0; i < n; i++)
                {
                    Console.Write("\n");
                    Information first = new Information();
                    Console.Write("Input name of gymnast: ");
                    first.Name = Console.ReadLine();
                    Console.Write("Input surname of gymnast: ");
                    first.Surname = Console.ReadLine();
                    Console.Write("Input nation of gymnast: ");
                    first.Nation = Console.ReadLine();
                    members.Set(first);
                    members.Evaluation(first);
                }
            }
            catch { Console.WriteLine("Input correct information about sportmen!"); }
            members.Result();
            Console.ReadKey();
        }


        class Information
        {
            private string name;
            private string surname;
            private string nation;
            private double average;
            public string Name
            {
                get { return name; }
                set { name = value; }
            }
            public string Surname
            {
                get { return surname; }
                set { surname = value; }
            }
            public string Nation
            {
                get { return nation; }
                set { nation = value; }
            }
            public double Average
            {
                get { return average; }
                set { average = value; }
            }
        }
        class Competition
        {
            Information member;
            public void Set(Information member)
            {
                this.member = member;
            }
            Random rand = new Random();
            public double Mark()
            {
                double a = 0.0;
                double b = 6.0;
                double x = rand.NextDouble();
                return a + (x * (b - a));
            }

            List<Information> numbers = new List<Information>();

            public void Evaluation(Information member)
            {

                Dictionary<int, string> judge = new Dictionary<int, string>
                {
                    [1] = "Ukrainian",
                    [2] = "Russian",
                    [3] = "German",
                    [4] = "French"
                };
                List<double> marks = new List<double>();

                Console.Write("----------------------------------");
                Console.Write("\n");
                for (int i = 0; i < 4; i++)
                {
                    var temp = Mark();
                    marks.Add(temp);
                    Console.WriteLine($"The Judge number {i + 1} give such mark: {temp}");
                }

                marks.Sort();
                marks.Remove(marks.Last());
                marks.Remove(marks.First());

                double summ = 0;
                foreach (var item in marks)
                {
                    summ = summ + item;
                }
                member.Average = summ / marks.Count();
                Console.Write("----------------------------------");
                Console.Write("\n");
                Console.WriteLine("The average result of " + member.Name + " " + member.Surname + " from " + member.Nation + " is " + member.Average);
                numbers.Add(member);
            }
            public void Result()
            {
                Console.Write("----------------------------------");
                Console.Write("\n");
                Console.WriteLine("Gymnasts sorted by surname");
                numbers.Sort((a, b) => a.Surname.CompareTo(b.Surname));
                foreach (var item in numbers)
                {
                    Console.WriteLine("The average result of " + item.Name + " " + item.Surname + " , " + item.Nation + " is " + item.Average);
                }

                Console.Write("----------------------------------");
                Console.Write("\n");
                Console.WriteLine("Result of competition");
                numbers.Sort((a, b) => a.Average.CompareTo(b.Average));
                var firstFiveItems = numbers.Take(3);

                foreach (var item in firstFiveItems)
                {
                    Console.WriteLine("The average result of " + item.Name + " " + item.Surname + " , " + item.Nation + " is " + item.Average);
                }

            }
        }

    }
}
