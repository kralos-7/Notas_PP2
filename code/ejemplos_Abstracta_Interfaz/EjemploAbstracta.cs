using System;
using System.Collections.Generic;

namespace EjemploClasesAbstractas
{
    public abstract class Animal
    {
        public string Nombre { get; set; }

        public Animal(string nombre)
        {
            Nombre = nombre;
        }

        public abstract void HacerSonido();

        public virtual void Dormir()
        {
            Console.WriteLine($"{Nombre} está durmiendo.");
        }

        public void Comer()
        {
            Console.WriteLine($"{Nombre} está comiendo.");
        }
    }

    public class Perro : Animal
    {
        public Perro(string nombre) : base(nombre) {}

        public override void HacerSonido()
        {
            Console.WriteLine($"{Nombre} dice: ¡Guau!");
        }

        public override void Dormir()
        {
            Console.WriteLine($"{Nombre} duerme en su cama.");
        }
    }

    public class Gato : Animal
    {
        public Gato(string nombre) : base(nombre) {}

        public override void HacerSonido()
        {
            Console.WriteLine($"{Nombre} dice: ¡Miau!");
        }
    }

    public class Vaca : Animal
    {
        public Vaca(string nombre) : base(nombre) {}

        public override void HacerSonido()
        {
            Console.WriteLine($"{Nombre} dice: ¡Muuu!");
        }
    }

    class Programa
    {
        static void Main(string[] args)
        {
            List<Animal> animales = new List<Animal>
            {
                new Perro("Firulais"),
                new Gato("Michi"),
                new Vaca("Lola")
            };

            foreach (var animal in animales)
            {
                animal.Comer();
                animal.HacerSonido();
                animal.Dormir();
                Console.WriteLine();
            }

            Console.ReadKey();
        }
    }
}