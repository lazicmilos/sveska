//int[] brojevi = { 1, 2, 3, 4, 5 }; definisanje punog niza
int[] brojevi = new int[5];
int pozicijaMin = 0; // definisanje promenljive za poziciju minimuma
int max = 0;
int srednjaVrednost = 0; // definisanje promenljive za srednju vrednost
int min = 100; // definisanje promenljive za minimum
int zbir = 0; // definisanje promenljive za zbir elemenata
Random x= new Random();
//formiranje promenljive za slucajne brojeve
for (int i = 0; i < 5; i++)
{
    //U niz upisujem sledeci slucajan broj do 100
    brojevi[i] = x.Next(100);
    Console.WriteLine("Element [ " + i + " ]: " + brojevi[i]);
    zbir += brojevi[i];
    if(brojevi[i] > max)
    {
        max = brojevi[i];
    }
    if(brojevi[i] < min)
    {
        min = brojevi[i];
    }
    pozicijaMin = Array.IndexOf(brojevi, min); // pronalazenje pozicije minimuma
    srednjaVrednost = zbir / brojevi.Length; // racunanje srednje vrednosti
}
Console.WriteLine();
int[] drugiNiz = new int[5];
for (int i=0;i<5; i++)
{
    drugiNiz[i]= x.Next(50)*2;
    Console.WriteLine("Element [ " + i + " ]: " + drugiNiz[i]);
}
Console.WriteLine();
int[] treciNiz = new int[5];
for (int i = 4; i >= 0; i--)
{
    treciNiz[i] = x.Next(50) *2-1;
    Console.WriteLine("Element [ " + i + " ]: " + treciNiz[i]);
}
Console.WriteLine();

Console.WriteLine("Zbir elemenata niza je: " + zbir);
Console.WriteLine("Maksimalni element niza je: " + max);
Console.WriteLine("Minimalni element niza je: " + min);
Console.WriteLine("Srednja vrednost elemenata niza je: " + srednjaVrednost);
Console.WriteLine("Pozicija minimalnog elementa niza je: " + pozicijaMin);
Console.ReadKey();