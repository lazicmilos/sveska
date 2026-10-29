int[,] niz = new int[5, 5];
int zbir = 0;
int max = 0;
Random x = new Random();

for (int i = 0; i < 5; i++)
{
    for (int j = 0; j < 5; j++)
    {
        niz[i, j] = x.Next(1, 10);
        zbir += niz[i, j];
        if (niz[i, j] > max)
            max = niz[i, j];

        Console.Write($"{niz[i, j],3}"); // print svakog elementa sa razmakom od 3 karaktera
    }
    Console.WriteLine(); // nova linija nakon svakog reda
}

Console.WriteLine($"\nSuma: {zbir}");
Console.WriteLine($"Maksimum: {max}");
Console.ReadKey();