Console.WriteLine("Unesite prvi broj : ");
int a  = Convert.ToInt32(Console.ReadLine());
Console.WriteLine("Unesite drugi broj : ");
int b = Convert.ToInt32(Console.ReadLine());
bool prvijeveci = a > b;
bool drugijeveci = b > a;
bool jednaki = a == b;

if(prvijeveci)
{
    Console.WriteLine("Prvi broj je veci od drugog broja");
}
else if (drugijeveci)
{
    Console.WriteLine("Drugi broj je veci od prvog broja");
}
else if (jednaki)
{
    Console.WriteLine("Brojevi su jednaki");
}