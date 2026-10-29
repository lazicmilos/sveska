namespace zadatak13
{
    internal class Program
    {
        struct tacka
        {
            public int x;
            public int y;
            public double udaljenost;
        }
        
        static void Main(string[] args)
        {
            tacka koordinata;
            Random broj= new Random();
            tacka[] niz = new tacka[10];
            for (int i = 0; i < 10; i++)
            {
                niz[i].x = broj.Next(0, 100);
                niz[i].y = broj.Next(0, 100);
                double z = Math.Sqrt(niz[i].x * niz[i].x + niz[i].y * niz[i].y);
                niz[i].udaljenost = z;
                Console.WriteLine("X koordinata : " + i + ". tacke je " + niz[i].x);
                Console.WriteLine("Y koordinata : " + i + ". tacke je " + niz[i].y);
                Console.WriteLine("Udaljenost : " + i + ". tacke je " + niz[i].udaljenost);
            }
            Console.ReadKey();
        }
    }
}
