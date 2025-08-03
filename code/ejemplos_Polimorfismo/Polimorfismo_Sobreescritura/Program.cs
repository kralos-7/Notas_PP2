using System;

class Animal
{
    public virtual void HacerSonido()
    {
        Console.WriteLine("Sonido genérico");
    }
}

class Perro : Animal
{
    public override void HacerSonido()
    {
        Console.WriteLine("¡Guau!");
    }
}

class Gato : Animal
{
    public override void HacerSonido()
    {
        Console.WriteLine("¡Miau!");
    }
}

class Program
{
    static void Main()
    {
        Animal miAnimal = new Perro();
        miAnimal.HacerSonido();

        miAnimal = new Gato();
        miAnimal.HacerSonido();
    }
}
