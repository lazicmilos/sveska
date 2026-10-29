using System.ComponentModel.DataAnnotations;

int[] niz = new int[10];
Random x = new Random();
int max = 0;
int position = 0;
for (int i = 0; i < niz.Length; i++)
{
    niz[i] = x.Next(1, 100);
    if(niz[i] > max)
    {
        max = niz[i];
        position = i;
    }
    Console.WriteLine("Ispis Elemenata: " + niz[i]);
}
Console.WriteLine("Najveci broj u nizu je: " + max);
Console.WriteLine("Pozicija najveceg broja u nizu je: " + position);