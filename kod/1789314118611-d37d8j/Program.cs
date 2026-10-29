int n = 8;
int[,] tabla = new int[n, n];
Random rand = new Random();

for (int i = 0; i < n; i++)
    for (int j = 0; j < n; j++)
        tabla[i, j] = rand.Next(1, 99);

int[] dRed = { 1, 2, -1, -2, 1, 2, -1, -2 };
int[] dKol = { 2, 1, 2, 1, -2, -1, -2, -1 };

int red = 0, kolona = 0; // a1
tabla[red, kolona] = 99;

// Funkcija koja pretvara (red, kolona) u šahovsku notaciju, npr. (0,0) -> "a1"
string UNotaciju(int r, int k) => $"{(char)('a' + k)}{r + 1}";

Console.WriteLine($"Start: konj na {UNotaciju(red, kolona)}");

for (int potez = 1; potez <= 5; potez++)
{
    List<(int r, int k)> validniPotezi = new List<(int, int)>();

    for (int p = 0; p < 8; p++)
    {
        int noviRed = red + dRed[p];
        int novaKolona = kolona + dKol[p];

        if (noviRed >= 0 && noviRed < n && novaKolona >= 0 && novaKolona < n)
            validniPotezi.Add((noviRed, novaKolona));
    }

    int izbor = rand.Next(validniPotezi.Count);
    (red, kolona) = validniPotezi[izbor];

    tabla[red, kolona] = 99;

    Console.WriteLine($"Potez {potez}: konj na {UNotaciju(red, kolona)}");
}

Console.WriteLine();

// Ispis table sa oznakama, a1 dole levo
Console.Write("   ");
for (int j = 0; j < n; j++)
    Console.Write($"{(char)('a' + j)}".PadLeft(4));
Console.WriteLine();

for (int i = n - 1; i >= 0; i--)
{
    Console.Write($"{i + 1,2} ");
    for (int j = 0; j < n; j++)
        Console.Write(tabla[i, j].ToString().PadLeft(4));
    Console.WriteLine();
}