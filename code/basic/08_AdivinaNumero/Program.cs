using System;

class Program
{
    static void Main()
    {
        Random rnd = new Random();
        int secreto = rnd.Next(1, 101);
        int intento;

        do
        {
            Console.Write("Adivina el número (1-100): ");
            intento = int.Parse(Console.ReadLine());

            if (intento < secreto)
                Console.WriteLine("Demasiado bajo.");
            else if (intento > secreto)
                Console.WriteLine("Demasiado alto.");
            else
                Console.WriteLine("¡Correcto!");
        } while (intento != secreto);
    }
}