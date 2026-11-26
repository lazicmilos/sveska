using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace zadatak_43
{
    internal class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Console.Write("Unesite prvi broj: ");
                int prviBroj = Convert.ToInt32(Console.ReadLine());
                Console.Write("Unesite drugi broj: ");
                int drugiBroj = Convert.ToInt32(Console.ReadLine());

                int kolicnik = prviBroj / drugiBroj;
                Console.WriteLine("Kolicnik je: " + kolicnik);
            }
            catch (Exception) // hvata i DivideByZeroException i FormatException
            {
                Console.WriteLine("Doslo je do greske prilikom deljenja.");
            }
            Console.WriteLine("Program nastavlja da radi normalno.");
            Console.ReadKey();
        }
    }
}
