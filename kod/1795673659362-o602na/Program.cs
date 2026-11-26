using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace zadatak_25
{
    class Automobil
    {
        public string marka;
        public int godisteProizvodnje;

        public void Prikazi()
        {
            Console.WriteLine("Marka: " + marka);
            Console.WriteLine("Godiste proizvodnje: " + godisteProizvodnje);
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            Automobil auto = new Automobil();
            auto.marka = "Golf";
            auto.godisteProizvodnje = 2015;
            auto.Prikazi();
            Console.ReadKey();
        }
    }
}
