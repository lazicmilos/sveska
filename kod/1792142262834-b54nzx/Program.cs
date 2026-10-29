namespace zadatak11
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Unesite prvi broj: ");
            int a = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Unesite drugi broj: ");
            int b = Convert.ToInt32(Console.ReadLine());
            bool prvijeveci = a > b;
            bool jednak = a == b;
            bool drugijeveci = a < b;
            if(prvijeveci)
            {
                Console.WriteLine("Prvi broj je veci od drugog");
            }
            else if(jednak)
            {
                Console.WriteLine("Brojevi su jednaki");
            }
            else if (drugijeveci)
            {
                Console.WriteLine("Drugi broj je veci od prvog");
            }
            Console.ReadKey();

        }
    }
}
