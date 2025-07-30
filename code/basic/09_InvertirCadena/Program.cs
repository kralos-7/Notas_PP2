using System;

class Program
{
    static void Main()
    {
        Console.Write("Ingrese una palabra: ");
        string texto = Console.ReadLine();

        char[] arreglo = texto.ToCharArray();
        Array.Reverse(arreglo);
        Console.WriteLine("Invertido: " + new string(arreglo));
    }
}