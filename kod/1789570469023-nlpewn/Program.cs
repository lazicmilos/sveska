int[] niz = new int[10]
Random x=  new Random();
for (int i = 0; i < 10; i++)
{
    niz[i] = x.Next() % 100;
}
foreach (int broj in niz)
{
    Console.WriteLine(broj);
}
Console.ReadKey();