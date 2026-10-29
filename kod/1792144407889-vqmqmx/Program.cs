namespace zadatak17
{
    internal class Program
    {
        static int Mnozi(int a, int b)
        {
            return a * b;
        }
        static void parnost(int z)
        {
            if(z%2==0) Console.WriteLine("Broj je paran");
            else Console.WriteLine("Broj je neparan");
        }
        static void Main(string[] args)
        {
            int a = 7; int b = 3;
            int rezultat;
            rezultat = Mnozi(a, b);
            Console.WriteLine("Mnozenjem dobijam rezultat: " + rezultat);
            parnost(rezultat);
            Console.ReadKey();
        }
    }
}
