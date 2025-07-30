using System;

class Program
{
    static void Main()
    {
        Console.Write("Ingrese un número: ");
        int numero = int.Parse(Console.ReadLine());

        if (numero % 2 == 0)
            Console.WriteLine("Es par.");
        else
            Console.WriteLine("Es impar.");
    }
}