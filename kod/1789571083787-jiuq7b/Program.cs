tacka koordinata = new tacka();
Random broj = new Random();
koordinata.x = broj.Next() % 100;
koordinata.y = broj.Next() % 100;
Console.WriteLine("X koordinata tacke je : " + koordinata.x);
Console.WriteLine("Y koordinata tacke je : " + koordinata.y);
Console.ReadKey();

struct tacka
{
    public int x, y, i;
}