using System;

class Program
{
    static void Main()
    {
        Console.Write("Ingrese un número: ");
        int n = int.Parse(Console.ReadLine());
        bool esPrimo = true;

        if (n < 2)
            esPrimo = false;
        else
        {
            for (int i = 2; i <= Math.Sqrt(n); i++)
            {
                if (n % i == 0)
                {
                    esPrimo = false;
                    break;
                }
            }
        }

        Console.WriteLine(esPrimo ? "Es primo." : "No es primo.");
    }
}