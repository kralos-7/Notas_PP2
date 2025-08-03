using System;

class Figura
{
    public virtual void Dibujar()
    {
        Console.WriteLine("Dibuja figura genérica");
    }
}

class Circulo : Figura
{
    public override void Dibujar()
    {
        Console.WriteLine("Dibuja círculo");
    }
}

class Cuadrado : Figura
{
    public override void Dibujar()
    {
        Console.WriteLine("Dibuja cuadrado");
    }
}

class Program
{
    static void Main()
    {
        Figura f;

        f = new Circulo();
        f.Dibujar();

        f = new Cuadrado();
        f.Dibujar();
    }
}
