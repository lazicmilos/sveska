using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace zadatak_33
{
    class BankovniRacun
    {
        private double stanje;

        // svojstvo: get i set na jednom mestu; value je vrednost koja se dodeljuje
        public double Stanje
        {
            get { return stanje; }
            set
            {
                if (value >= 0)
                {
                    stanje = value;
                }
                else
                {
                    Console.WriteLine("Greska: stanje racuna ne moze biti negativno!");
                }
            }
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            BankovniRacun racun = new BankovniRacun();
            // racun.stanje = 1000; ne radi, polje je private
            racun.Stanje = 1000; // poziva set
            Console.WriteLine("Stanje racuna: " + racun.Stanje); // poziva get
            racun.Stanje = -200; // set odbija vrednost
            Console.WriteLine("Stanje racuna: " + racun.Stanje);
            Console.ReadKey();
        }
    }
}
