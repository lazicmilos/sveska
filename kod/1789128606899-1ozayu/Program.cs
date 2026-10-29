class Program
{
    static int brojac;

    static void pozovi()
    {
        brojac++;
        Console.WriteLine("Funkcija je pozvana {0} puta.", brojac);
    }

    static void druga()
    {
        brojac += 3;
        Console.WriteLine("Brojac je uvecan 3 puta!");
    }

    static void Main(string[] args)
    {
        pozovi();
        druga();
        pozovi();
        pozovi();
        Console.ReadKey();
    }
}