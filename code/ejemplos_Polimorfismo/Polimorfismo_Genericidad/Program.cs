using System;

class Caja<T>
{
    private T contenido;

    public void Guardar(T item)
    {
        contenido = item;
    }

    public T Obtener()
    {
        return contenido;
    }
}

class Program
{
    static void Main()
    {
        Caja<int> cajaEnteros = new Caja<int>();
        cajaEnteros.Guardar(123);
        Console.WriteLine(cajaEnteros.Obtener());

        Caja<string> cajaTextos = new Caja<string>();
        cajaTextos.Guardar("Hola");
        Console.WriteLine(cajaTextos.Obtener());
    }
}
