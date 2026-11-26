using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace zadatak_27
{
    class Pravougaonik
    {
        public double sirina;
        public double visina;

        // konstruktor ima isto ime kao klasa i nema povratnu vrednost
        public Pravougaonik(double s, double v)
        {
            sirina = s;
            visina = v;
        }

        public double IzracunajPovrsinu()
        {
            return sirina * visina;
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            // bez konstruktora bi bilo:
            // Pravougaonik p1 = new Pravougaonik();
            // p1.sirina = 4;
            // p1.visina = 5;
            Pravougaonik p1 = new Pravougaonik(4, 5);
            Pravougaonik p2 = new Pravougaonik(2.5, 3);
            Console.WriteLine("Povrsina p1: " + p1.IzracunajPovrsinu());
            Console.WriteLine("Povrsina p2: " + p2.IzracunajPovrsinu());
            Console.ReadKey();
        }
    }
}
