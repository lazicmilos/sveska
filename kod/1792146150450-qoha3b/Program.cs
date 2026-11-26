using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace zadatak_23
{
    internal class Program
    {
        static void Main(string[] args)
        {
            StreamWriter pisi = new StreamWriter("brojevi.txt");
            Random x = new Random();
            for (int i = 1; i <= 10; i++)
            {
                int z = x.Next() % 100;
                pisi.WriteLine(z);
            }
            pisi.Close();

            // true znaci da se fajl ne brise, nego se pise na njegov kraj
            StreamWriter dodaj = new StreamWriter("brojevi.txt", true);
            Console.WriteLine("Unesi jedan broj");
            string t = Console.ReadLine();
            int k = Convert.ToInt32(t);
            dodaj.WriteLine(k);
            dodaj.Close();

            // provera: ispisujem ceo fajl, uneti broj je poslednji
            Console.WriteLine("Sadrzaj fajla brojevi.txt:");
            string s;
            StreamReader citaj = new StreamReader("brojevi.txt");
            while ((s = citaj.ReadLine()) != null)
            {
                Console.WriteLine(s);
            }
            citaj.Close();
            Console.ReadKey();
        }
    }
}
