using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace zadatak_26
{
    class Krug
    {
        // osobina: svaki objekat klase Krug ima svoj precnik
        public double precnik;

        // metoda nema parametre, racuna samo sa precnikom objekta
        public double IzracunajObim()
        {
            return Math.PI * precnik;
        }

        public double IzracunajPovrsinu()
        {
            double poluprecnik = precnik / 2;
            return Math.PI * poluprecnik * poluprecnik;
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            Krug a = new Krug();
            Console.Write("Unesite precnik kruga: ");
            a.precnik = Convert.ToDouble(Console.ReadLine());
            Console.WriteLine("Obim kruga je: " + a.IzracunajObim());
            Console.WriteLine("Povrsina kruga je: " + a.IzracunajPovrsinu());
            Console.ReadKey();
        }
    }
}
