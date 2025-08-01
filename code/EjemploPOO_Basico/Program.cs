using System;

namespace EjemploPOO
{
    class Persona
    {
        public string Nombre;
        public int Edad;

        public void Saludar()
        {
            Console.WriteLine($"Hola, me llamo {Nombre} y tengo {Edad} años.");
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Persona p1 = new Persona();
            p1.Nombre = "Carlos";
            p1.Edad = 30;
            p1.Saludar();

            Console.ReadLine();
        }
    }
}
