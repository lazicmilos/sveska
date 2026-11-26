using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace zadatak_41
{
    // prvi deo klase: polja (u praksi bi ovo bio poseban fajl, npr. Automobil.Polja.cs)
    partial class Automobil
    {
        public string marka;
        public int godiste;
    }

    // drugi deo klase: metode (npr. Automobil.Metode.cs)
    partial class Automobil
    {
        public void Prikazi()
        {
            Console.WriteLine("Marka: " + marka);
            Console.WriteLine("Godiste: " + godiste);
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            Automobil auto = new Automobil();
            auto.marka = "Passat";
            auto.godiste = 2019;
            auto.Prikazi();
            Console.ReadKey();
        }
    }
}
