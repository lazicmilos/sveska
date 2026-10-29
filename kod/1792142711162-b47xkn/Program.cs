namespace zadatak12
{
    internal class Program
    {
        struct tacka
        {
            public int x, y;
        }
        static void Main(string[] args)
        {
            tacka koordinata;
            Random broj= new Random();
            tacka[] niz= new tacka[10];
            for(int i = 0; i < 10; i++)
            {
                niz[i].x = broj.Next(1, 100);
                niz[i].y = broj.Next(1, 100);
                Console.WriteLine("X koordinata: " + niz[i].x + " tacke je: " + niz[i].x);
                Console.WriteLine("Y koordinata: " + niz[i].y + " tacke je: " + niz[i].y);
            }
            Console.ReadKey();
        }

    }
}
