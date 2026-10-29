int[,] niz = new int[8, 8];
Random rand = new Random();

for (int i = 0; i < 8; i++)
    for (int j = 0; j < 8; j++)
        niz[i, j] = rand.Next(1, 100);

// Popuni dijagonale nulama
for (int i = 0; i < 8; i++)
{
    for (int j = 0; j < 8; j++)
    {
        if (i == j || i + j == 7)
            niz[i, j] = 0;
    }
}

// Ispis
for (int i = 0; i < 8; i++)
{
    for (int j = 0; j < 8; j++)
        Console.Write(niz[i, j].ToString().PadLeft(4));
    Console.WriteLine();
}