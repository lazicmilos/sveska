using System.Runtime.Serialization.Formatters;
Console.WriteLine("Enter number n: ");
int n = Convert.ToInt32(Console.ReadLine());
int zbir = 0;
for (int i=0;i<=n;i++)
{
    if(i%2==0)
       Console.WriteLine(i);
    zbir += i;
}
Console.WriteLine("Zbir : " + zbir);
