using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace zadatak_21
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

            string s;
            StreamReader citaj = new StreamReader("brojevi.txt");
            while ((s = citaj.ReadLine()) != null)
            {
                Console.WriteLine(s);
            }
            citaj.Close();

            Console.WriteLine();
            Console.WriteLine("PROCITAO SAM SVE");
            Console.ReadKey();
        }
    }
}
