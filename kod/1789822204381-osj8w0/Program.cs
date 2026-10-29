Console.Write("Unesite broj n: ");
int n = int.Parse(Console.ReadLine());

List<int> niz = new List<int>();

Console.Write("Unesite broj: ");
int a = int.Parse(Console.ReadLine());

while (a <= n)
{
    niz.Add(a);

    Console.Write("Unesite broj: ");
    a = int.Parse(Console.ReadLine());
}

Console.WriteLine($"Uneto je {niz.Count} brojeva: {string.Join(", ", niz)}");