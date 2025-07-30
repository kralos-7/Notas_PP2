using System;

class Program
{
    static void Main()
    {
        Console.Write("Ingrese una frase: ");
        string frase = Console.ReadLine().ToLower();

        int contador = 0;
        foreach (char c in frase)
        {
            if ("aeiou".Contains(c))
                contador++;
        }

        Console.WriteLine($"Cantidad de vocales: {contador}");
    }
}