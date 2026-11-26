using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace zadatak_46
{
    internal class Program
    {
        static void ProveriOcenu(int ocena)
        {
            if (ocena < 1 || ocena > 5)
            {
                throw new ArgumentException("Ocena mora biti broj od 1 do 5.");
            }
            Console.WriteLine("Ocena " + ocena + " je ispravna.");
        }

        static void Main(string[] args)
        {
            Console.Write("Unesite ocenu: ");
            int ocena = Convert.ToInt32(Console.ReadLine());
            try
            {
                ProveriOcenu(ocena);
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine("Greska: " + ex.Message);
            }
            Console.ReadKey();
        }
    }
}
