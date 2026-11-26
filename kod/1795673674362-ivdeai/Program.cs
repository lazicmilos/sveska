using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace zadatak_40
{
    class Vektor
    {
        public double x;
        public double y;

        public Vektor(double x, double y)
        {
            this.x = x;
            this.y = y;
        }

        public static Vektor operator +(Vektor v1, Vektor v2)
        {
            return new Vektor(v1.x + v2.x, v1.y + v2.y);
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            Vektor v1 = new Vektor(2, 3);
            Vektor v2 = new Vektor(4, 1);
            Vektor zbir = v1 + v2;
            Console.WriteLine("Prvi vektor je: (" + v1.x + ", " + v1.y + ")");
            Console.WriteLine("Drugi vektor je: (" + v2.x + ", " + v2.y + ")");
            Console.WriteLine();
            Console.WriteLine("Zbir vektora: (" + zbir.x + ", " + zbir.y + ")");
            Console.ReadKey();
        }
    }
}
