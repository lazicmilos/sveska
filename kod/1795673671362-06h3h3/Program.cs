using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace zadatak_37
{
    class Proizvod
    {
        public string naziv;
        public int kolicina;
        public static int ukupnaKolicina = 0;

        public Proizvod(string naziv)
        {
            this.naziv = naziv;
            kolicina = 0;
        }

        public void Dodaj(int kolicinaZaDodavanje)
        {
            kolicina += kolicinaZaDodavanje;
            ukupnaKolicina += kolicinaZaDodavanje;
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            Proizvod p1 = new Proizvod("Secer");
            Proizvod p2 = new Proizvod("Brasno");
            p1.Dodaj(10);
            p2.Dodaj(15);
            p1.Dodaj(5);
            Console.WriteLine(p1.naziv + " - kolicina: " + p1.kolicina);
            Console.WriteLine(p2.naziv + " - kolicina: " + p2.kolicina);
            Console.WriteLine("Ukupna kolicina svih proizvoda: " + Proizvod.ukupnaKolicina);
            Console.ReadKey();
        }
    }
}
