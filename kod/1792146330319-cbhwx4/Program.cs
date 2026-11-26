using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace zadatak_24
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] ucenici = { "Ana", "Marko", "Jovana", "Petar", "Milica" };
            StreamWriter pisac = new StreamWriter("ucenici.txt");
            foreach (string ime in ucenici)
            {
                pisac.WriteLine(ime);
            }
            pisac.Close();
            Console.WriteLine("Imena ucenika su upisana u datoteku ucenici.txt");

            string s;
            StreamReader citaj = new StreamReader("ucenici.txt");
            while ((s = citaj.ReadLine()) != null)
            {
                Console.WriteLine(s);
            }
            citaj.Close();
            Console.ReadKey();
        }
    }
}
