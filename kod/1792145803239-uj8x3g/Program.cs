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
        static void Main(String[] args)
        {
            string s;
            StreamWriter fajl = new StreamWriter("brojevi.txt");
            Random x = new Random();
            for (int i = 1; i <= 15; i++)
            {
                int z = x.Next() % 100;
                fajl.WriteLine(z);
            }
            fajl.Close();

            StreamReader citaj = new StreamReader("brojevi.txt");
            while ((s = citaj.ReadLine()) != null)
            {
                //int z = Convert.ToInt16(s);
                Console.WriteLine(s);
            }
            citaj.Close();
            Console.ReadKey();
        }
    }
}