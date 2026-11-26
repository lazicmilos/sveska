using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace zadatak_36
{
    class Student
    {
        public string ime;
        public static int brojStudenata = 0;

        public Student(string ime)
        {
            this.ime = ime;
            brojStudenata++;
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            Student s1 = new Student("Marko");
            Student s2 = new Student("Ana");
            Student s3 = new Student("Jovan");
            Console.WriteLine("Ukupno napravljeno studenata: " + Student.brojStudenata);
            Console.ReadKey();
        }
    }
}
