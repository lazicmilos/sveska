using System;
class Program
  {
    public static int mnozenje(int a, int b)
    {
        return a * b;
    }

    static void Main()
    {
        int[] niz = new int[10];
        Random x = new Random();
        int n;
        Console.WriteLine("Unesite broj: ");
        n = int.Parse(Console.ReadLine());
        for (int i = 0; i < 10; i++)
        {
            niz[i] = x.Next(1, 100);
            mnozenje(niz[i], n);
            Console.WriteLine($"Broj {niz[i]} pomnozen sa {n} je: {mnozenje(niz[i], n)} ");
        }
    }
}

