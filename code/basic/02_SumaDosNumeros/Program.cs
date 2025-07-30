using System;

class Program
{
    static void Main()
    {
        Console.Write("Ingrese el primer número: ");
        int a = int.Parse(Console.ReadLine());

        Console.Write("Ingrese el segundo número: ");
        int b = int.Parse(Console.ReadLine());

        int suma = a + b;
        Console.WriteLine($"La suma es: {suma}");
    }
}