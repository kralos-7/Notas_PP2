using System;

namespace EjemploPOO_Polimorfismo
{
    class Animal
    {
        public virtual void HacerSonido()
        {
            Console.WriteLine("El animal hace un sonido.");
        }
    }

    class Perro : Animal
    {
        public override void HacerSonido()
        {
            Console.WriteLine("El perro dice: ¡Guau!");
        }
    }

    class Gato : Animal
    {
        public override void HacerSonido()
        {
            Console.WriteLine("El gato dice: ¡Miau!");
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Animal miAnimal = new Perro();
            miAnimal.HacerSonido();

            miAnimal = new Gato();
            miAnimal.HacerSonido();

            Console.ReadLine();
        }
    }
}
