using System;
using System.IO;

namespace zadatak18
{
    internal class Program
    {
        static void Main(string[] args)
        {
            StreamWriter fajl = new StreamWriter("poruka.txt");
            //ovde sam definisao koji fajl otvaram
            //ako fajl ne postoji, on ce biti kreiran
            //ako fajl postoji, on ce biti prepisan
            fajl.WriteLine("Ovo je poruka koja ce biti upisana u fajl");
            fajl.WriteLine("Ovo je druga poruka koja ce biti upisana u fajl");
            fajl.WriteLine("Ovo je treca poruka koja ce biti upisana u fajl");
            fajl.Write("Proba");
            fajl.Write("Dodatak");
            fajl.Close(); //zatvaranje fajla
            Console.WriteLine("Podaci su upisani u fajl");
            Console.ReadKey();
        }
    }
}