using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace zadatak_31
{
    class Zaposleni
    {
        public double plata;

        public void Provera()
        {
            if (plata < 0)
            {
                Console.WriteLine("Pogresna plata!");
                plata = 0;
            }
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            Zaposleni zaposleni = new Zaposleni();
            zaposleni.plata = -500; // javno polje, nista ne sprecava ovaj unos
            Console.WriteLine("Plata zaposlenog: " + zaposleni.plata);
            Console.WriteLine("Ovo je nelogicna vrednost, a program je ipak dozvolio unos!");
            zaposleni.Provera();
            Console.WriteLine("Plata zaposlenog: " + zaposleni.plata);
            Console.ReadKey();
        }
    }
}
