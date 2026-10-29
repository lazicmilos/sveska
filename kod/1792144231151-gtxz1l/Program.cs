namespace zadatak16
{
    internal class Program
    {
        static int saberi(int x,int y)
        {
            return x + y;
        }

        static void Main(string[] args)
        {
            int a = 3; int b = 8;
            int rezultat = saberi(a, b);
            Console.WriteLine("Rezultat sabiranja je: " + rezultat);
            Console.ReadKey();
        }
    }
}
