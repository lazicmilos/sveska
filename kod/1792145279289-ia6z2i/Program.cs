using System;
using System.IO;
namespace zadatak19
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string s;
            StreamReader citaj=new StreamReader("poruka.txt");
            //spremio sam fajl za citanje
            while((s = citaj.ReadLine()) != null)
            //s je red koji je procitan iz fajla
            //petlja radi dokle god je taj red razlicit od null
            //null znaci da je kraj fajla
            {
                Console.WriteLine(s);
            }
            citaj.Close();
            Console.WriteLine("Podaci su uspesno procitani");
            Console.ReadKey();
        }
    }
}
