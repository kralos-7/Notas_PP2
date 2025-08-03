using System;

class Calculadora
{
    public int Sumar(int a, int b)
    {
        return a + b;
    }

    public double Sumar(double a, double b)
    {
        return a + b;
    }

    public int Sumar(int a, int b, int c)
    {
        return a + b + c;
    }
}

class Program
{
    static void Main()
    {
        Calculadora calc = new Calculadora();
        Console.WriteLine(calc.Sumar(2, 3));
        Console.WriteLine(calc.Sumar(2.5, 3.1));
        Console.WriteLine(calc.Sumar(1, 2, 3));
    }
}
