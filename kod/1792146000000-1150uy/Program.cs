using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace zadatak_22
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int max = 0;
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
                int p = Convert.ToInt32(s);
                if (p > max) max = p;
            }
            citaj.Close();

            Console.WriteLine();
            Console.WriteLine("Procitao sam sve");
            Console.WriteLine("Najveci broj je " + max);
            Console.ReadKey();
        }
    }
}
