namespace zadatak14
{
    internal class Program
    {
        static void duplirajBroj(ref int x)
        {
            x= x*2;
            Console.WriteLine("U metodi je broj : " + x);
        }
        static void Main(string[] args)
        {
            int broj = 8;
            Console.WriteLine("Pre metode je broj : " + broj);
            duplirajBroj(ref broj);
            Console.WriteLine("Posle metode je :" + broj);
            Console.ReadKey();
        }
    }
}
