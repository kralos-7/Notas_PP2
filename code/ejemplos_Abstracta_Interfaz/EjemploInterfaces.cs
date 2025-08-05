using System;
using System.Collections.Generic;

namespace EjemploInterfaces
{
    public interface IVehiculo
    {
        string Marca { get; set; }
        string Modelo { get; set; }
        void Arrancar();
        void Detener();
    }

    public interface IElectrico
    {
        int NivelBateria { get; set; }
        void CargarBateria();
    }

    public class Automovil : IVehiculo
    {
        public string Marca { get; set; }
        public string Modelo { get; set; }

        public Automovil(string marca, string modelo)
        {
            Marca = marca;
            Modelo = modelo;
        }

        public void Arrancar()
        {
            Console.WriteLine($"{Marca} {Modelo} ha arrancado.");
        }

        public void Detener()
        {
            Console.WriteLine($"{Marca} {Modelo} se ha detenido.");
        }
    }

    public class ScooterElectrico : IVehiculo, IElectrico
    {
        public string Marca { get; set; }
        public string Modelo { get; set; }
        public int NivelBateria { get; set; }

        public ScooterElectrico(string marca, string modelo)
        {
            Marca = marca;
            Modelo = modelo;
            NivelBateria = 100;
        }

        public void Arrancar()
        {
            Console.WriteLine($"{Marca} {Modelo} encendido con {NivelBateria}% de batería.");
        }

        public void Detener()
        {
            Console.WriteLine($"{Marca} {Modelo} se detuvo.");
        }

        public void CargarBateria()
        {
            NivelBateria = 100;
            Console.WriteLine($"{Marca} {Modelo} ha sido cargado al 100%.");
        }
    }

    public class PanelSolar : IElectrico
    {
        public int NivelBateria { get; set; }

        public PanelSolar()
        {
            NivelBateria = 50;
        }

        public void CargarBateria()
        {
            NivelBateria = 100;
            Console.WriteLine("Panel solar cargado al 100%.");
        }
    }

    class Programa
    {
        static void Main(string[] args)
        {
            List<IVehiculo> vehiculos = new List<IVehiculo>
            {
                new Automovil("Toyota", "Corolla"),
                new ScooterElectrico("Xiaomi", "M365")
            };

            foreach (var v in vehiculos)
            {
                v.Arrancar();
                v.Detener();
                Console.WriteLine();
            }

            IElectrico dispositivo = new PanelSolar();
            dispositivo.CargarBateria();

            Console.ReadKey();
        }
    }
}