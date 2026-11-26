using System;
using MojaBiblioteka;

namespace Zadatak42
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string poruka = Pozdrav.PozdraviKorisnika();
            Console.WriteLine(poruka);
            Console.ReadKey();
        }
    }
}
