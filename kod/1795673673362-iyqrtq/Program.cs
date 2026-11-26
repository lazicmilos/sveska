using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace zadatak_39
{
    class Knjiga
    {
        public string naslov;
        public int brojStrana;
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            Knjiga[] knjige = new Knjiga[4];
            for (int i = 0; i < knjige.Length; i++)
            {
                knjige[i] = new Knjiga();
                Console.Write("Unesite naslov knjige " + (i + 1) + ": ");
                knjige[i].naslov = Console.ReadLine();
                Console.Write("Unesite broj strana: ");
                knjige[i].brojStrana = Convert.ToInt32(Console.ReadLine());
            }

            int ukupnoStrana = 0;
            Console.WriteLine();
            for (int i = 0; i < knjige.Length; i++)
            {
                Console.WriteLine(knjige[i].naslov + " - " + knjige[i].brojStrana + " strana");
                ukupnoStrana += knjige[i].brojStrana;
            }

            double prosek = (double)ukupnoStrana / knjige.Length;
            Console.WriteLine("\nProsecan broj strana: " + prosek);
            Console.ReadKey();
        }
    }
}
