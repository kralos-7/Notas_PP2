using System;

namespace EjemploPOO_Interfaces
{
    interface IVehiculo
    {
        void Conducir();
    }

    class Auto : IVehiculo
    {
        public void Conducir()
        {
            Console.WriteLine("Conduciendo un auto.");
        }
    }

    class Bicicleta : IVehiculo
    {
        public void Conducir()
        {
            Console.WriteLine("Pedaleando una bicicleta.");
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            IVehiculo v1 = new Auto();
            IVehiculo v2 = new Bicicleta();

            v1.Conducir();
            v2.Conducir();

            Console.ReadLine();
        }
    }
}
