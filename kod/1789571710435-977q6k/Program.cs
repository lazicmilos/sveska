tacka koordinata;
Random broj = new Random();
tacka[] niz = new tacka[10];
for (int i = 0; i < 10; i++)
{
    niz[i].x = broj.Next() % 100;
    niz[i].y = broj.Next() % 100;
    double z = Math.Sqrt(niz[i].x * niz[i].x + niz[i].y * niz[i].y);
    niz[i].udaljenost = z;
    Console.WriteLine("X koordinata" + i + "tacke je" + niz[i].x);
    Console.WriteLine("Y koordinata" + i + "tacke je" + niz[i].y);
    Console.WriteLine("Udaljenost" + i + "tacke je" + niz[i].udaljenost);

}


struct tacka
{
    public int x, y;
    public double udaljenost;
}