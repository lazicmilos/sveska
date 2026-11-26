using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace zadatak_49
{
    class NedovoljnoSredstavaException : Exception
    {
        public NedovoljnoSredstavaException(string poruka) : base(poruka)
        {
        }
    }

    class BankovniRacun
    {
        public double Stanje { get; set; }

        public BankovniRacun(double pocetnoStanje)
        {
            Stanje = pocetnoStanje;
        }

        public void Podigni(double iznos)
        {
            if (iznos > Stanje)
            {
                throw new NedovoljnoSredstavaException("Nema dovoljno sredstava. Trenutno stanje je " + Stanje + " dinara.");
            }
            Stanje = Stanje - iznos;
            Console.WriteLine("Podignuto je " + iznos + " dinara. Novo stanje: " + Stanje);
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            BankovniRacun racun = new BankovniRacun(1000);
            Console.Write("Unesite iznos koji zelite da podignete: ");
            double iznos = Convert.ToDouble(Console.ReadLine());
            try
            {
                racun.Podigni(iznos);
            }
            catch (NedovoljnoSredstavaException ex)
            {
                Console.WriteLine("Greska: " + ex.Message);
            }
            Console.ReadKey();
        }
    }
}
