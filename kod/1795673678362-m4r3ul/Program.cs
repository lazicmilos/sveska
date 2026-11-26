using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace zadatak_44
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] brojevi = { 10, 20, 30, 40, 50 };
            Console.Write("Unesite redni broj elementa (0-4): ");
            int indeks = Convert.ToInt32(Console.ReadLine());
            Console.Write("Unesite broj kojim delite element: ");
            int delilac = Convert.ToInt32(Console.ReadLine());

            try
            {
                int rezultat = brojevi[indeks] / delilac;
                Console.WriteLine("Rezultat deljenja je: " + rezultat);
            }
            catch (IndexOutOfRangeException)
            {
                Console.WriteLine("Greska: ne postoji element sa tim rednim brojem!");
            }
            catch (DivideByZeroException)
            {
                Console.WriteLine("Greska: delilac ne sme biti nula!");
            }
            Console.ReadKey();
        }
    }
}
