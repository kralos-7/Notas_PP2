using System;

namespace EjemploPOO_Herencia
{
    class Persona
    {
        public string Nombre;
        public int Edad;

        public void Saludar()
        {
            Console.WriteLine($"Hola, soy {Nombre}, tengo {Edad} años.");
        }
    }

    class Estudiante : Persona
    {
        public string Carrera;

        public void Estudiar()
        {
            Console.WriteLine($"{Nombre} está estudiando {Carrera}.");
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Estudiante e1 = new Estudiante();
            e1.Nombre = "Laura";
            e1.Edad = 22;
            e1.Carrera = "Informática";

            e1.Saludar();
            e1.Estudiar();

            Console.ReadLine();
        }
    }
}
