using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace zadatak_45
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Unesite svoju starost: ");
            string unos = Console.ReadLine();

            try
            {
                int starost = Convert.ToInt32(unos);
                Console.WriteLine("Vasa starost je: " + starost + " godina");
            }
            catch (FormatException)
            {
                Console.WriteLine("Greska: morate uneti ceo broj.");
            }
            Console.ReadKey();
        }
    }
}
