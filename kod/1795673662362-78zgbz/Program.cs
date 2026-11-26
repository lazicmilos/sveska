using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace zadatak_28
{
    class Proizvod
    {
        public string naziv;
        public double cena;

        public Proizvod(string n, double c)
        {
            naziv = n;
            cena = c;
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            Proizvod p1 = new Proizvod("Hleb", 80);
            Proizvod p2 = new Proizvod("Mleko", 110);
            Proizvod p3 = new Proizvod("Jogurt", 95);
            Console.WriteLine(p1.naziv + " " + p1.cena + " din.");
            Console.WriteLine(p2.naziv + " " + p2.cena + " din.");
            Console.WriteLine(p3.naziv + " " + p3.cena + " din.");
            double ukupno = p1.cena + p2.cena + p3.cena;
            Console.WriteLine("Ukupna vrednost: " + ukupno + " din.");
            Console.ReadKey();
        }
    }
}
