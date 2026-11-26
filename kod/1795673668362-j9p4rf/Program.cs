using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace zadatak_34
{
    class IPhone
    {
        private double cena;

        public void SetCena(double novaCena)
        {
            if (novaCena < 800)
            {
                Console.WriteLine("Greska: cena ne moze da bude ispod 800 eur.");
                return;
            }
            cena = novaCena;
        }

        public double GetCena()
        {
            return cena;
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            IPhone telefon = new IPhone();
            telefon.SetCena(1200);
            Console.WriteLine("Cena: " + telefon.GetCena() + " eur");
            telefon.SetCena(500);
            Console.WriteLine("Cena: " + telefon.GetCena() + " eur");
            Console.ReadKey();
        }
    }
}
