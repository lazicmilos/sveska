using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace zadatak_47
{
    class NegativanBrojException : Exception
    {
        public NegativanBrojException(string poruka) : base(poruka)
        {
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Console.Write("Unesite ceo broj: ");
                int broj = Convert.ToInt32(Console.ReadLine());
                if (broj < 0)
                {
                    throw new NegativanBrojException("Uneti broj ne sme biti negativan.");
                }
                Console.WriteLine("Uneli ste ispravan broj: " + broj);
            }
            catch (NegativanBrojException ex)
            {
                Console.WriteLine("Greska (sopstveni izuzetak): " + ex.Message);
            }
            Console.ReadKey();
        }
    }
}
