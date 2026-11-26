using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace zadatak_29
{
    class Osoba
    {
        public string ime;
        public int godine;

        // this.ime je polje objekta, a ime je parametar konstruktora
        public Osoba(string ime, int godine)
        {
            this.ime = ime;
            this.godine = godine;
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            Osoba osoba = new Osoba("Milica", 17);
            Console.WriteLine("Ime: " + osoba.ime);
            Console.WriteLine("Godine: " + osoba.godine);
            Console.ReadKey();
        }
    }
}
