using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace zadatak_32
{
    class BankovniRacun
    {
        private double stanje;

        public double GetStanje()
        {
            return stanje;
        }

        public void SetStanje(double vrednost)
        {
            if (vrednost >= 0)
            {
                stanje = vrednost;
            }
            else
            {
                Console.WriteLine("Greska: stanje racuna ne moze biti negativno!");
            }
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            BankovniRacun racun = new BankovniRacun();
            racun.SetStanje(1000);
            Console.WriteLine("Stanje racuna: " + racun.GetStanje());
            racun.SetStanje(-200);
            Console.WriteLine("Stanje racuna: " + racun.GetStanje());
            Console.ReadKey();
        }
    }
}
