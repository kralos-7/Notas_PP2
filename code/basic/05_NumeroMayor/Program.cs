using System;

class Program
{
    static void Main()
    {
        Console.Write("Ingrese el primer número: ");
        int a = int.Parse(Console.ReadLine());
        Console.Write("Ingrese el segundo número: ");
        int b = int.Parse(Console.ReadLine());
        Console.Write("Ingrese el tercer número: ");
        int c = int.Parse(Console.ReadLine());

        int mayor = Math.Max(a, Math.Max(b, c));
        Console.WriteLine($"El número mayor es: {mayor}");
    }
}