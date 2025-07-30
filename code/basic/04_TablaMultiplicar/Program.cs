using System;

class Program
{
    static void Main()
    {
        Console.Write("Ingrese un número: ");
        int num = int.Parse(Console.ReadLine());

        for (int i = 1; i <= 10; i++)
        {
            Console.WriteLine($"{num} x {i} = {num * i}");
        }
    }
}