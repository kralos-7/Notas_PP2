using System;

namespace EjemploPOO_Encapsulamiento
{
    class CuentaBancaria
    {
        private decimal saldo;

        public void Depositar(decimal cantidad)
        {
            if (cantidad > 0)
                saldo += cantidad;
        }

        public void Retirar(decimal cantidad)
        {
            if (cantidad > 0 && cantidad <= saldo)
                saldo -= cantidad;
        }

        public decimal ObtenerSaldo()
        {
            return saldo;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            CuentaBancaria cuenta = new CuentaBancaria();
            cuenta.Depositar(500);
            cuenta.Retirar(200);

            Console.WriteLine($"Saldo actual: {cuenta.ObtenerSaldo()}");

            Console.ReadLine();
        }
    }
}
