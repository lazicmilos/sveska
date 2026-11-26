using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace zadatak_38
{
    class Kalkulator
    {
        public int Saberi(int a, int b)
        {
            return a + b;
        }

        public double Saberi(double a, double b)
        {
            return a + b;
        }

        public int Saberi(int a, int b, int c)
        {
            return a + b + c;
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            Kalkulator k = new Kalkulator();
            Console.WriteLine("Zbir dva cela broja: " + k.Saberi(3, 4));
            Console.WriteLine("Zbir dva decimalna broja: " + k.Saberi(2.5, 1.7));
            Console.WriteLine("Zbir tri cela broja: " + k.Saberi(1, 2, 3));
            Console.ReadKey();
        }
    }
}
