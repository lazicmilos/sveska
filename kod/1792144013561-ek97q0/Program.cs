namespace zadatak15
{
    internal class Program
    {
        static void  podeli(ref int a, ref int b, out int z1,out int z2)
        {
          z1 = a / b;
          z2 = a % b;

        }
        static void Main(string[] args)
        {
            int b1 = 11; int b2 = 5;
            int rezkol, rezost;
            podeli(ref b1, ref b2, out rezkol, out rezost);

            Console.WriteLine("Delim "+b1 +" sa "+b2+ "kolicnik: "+rezkol);
            Console.WriteLine("Ostanak: "+rezost);
            Console.ReadKey();
        }
    }
}
