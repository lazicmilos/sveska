using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace zadatak_30
{
    class Artikal
    {
        public string naziv;
        public int kolicina;

        public Artikal(string naziv, int kolicina)
        {
            this.naziv = naziv;
            this.kolicina = kolicina;
        }

        // poziva konstruktor iznad, sa podrazumevanom kolicinom 1
        public Artikal(string naziv) : this(naziv, 1)
        {
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            Artikal a1 = new Artikal("Sveska", 5);
            Artikal a2 = new Artikal("Olovka");
            Console.WriteLine(a1.naziv + " - kolicina: " + a1.kolicina);
            Console.WriteLine(a2.naziv + " - kolicina: " + a2.kolicina);
            Console.ReadKey();
        }
    }
}
