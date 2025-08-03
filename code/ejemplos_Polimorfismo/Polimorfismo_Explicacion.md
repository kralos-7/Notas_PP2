# Ejemplos de Polimorfismo en C#

Este documento contiene una explicación y ejemplo en C# de los cuatro tipos de polimorfismo más comunes.

---

## 1. Sobrecarga de Métodos (Compile-time Polymorphism)

Permite que varios métodos tengan el mismo nombre pero diferente firma (parámetros).

```csharp
class Calculadora
{
    public int Sumar(int a, int b) => a + b;
    public double Sumar(double a, double b) => a + b;
    public int Sumar(int a, int b, int c) => a + b + c;
}
```

---

## 2. Sobreescritura de Métodos (Runtime Polymorphism)

Permite que una subclase reemplace un método de su clase base usando `override`.

```csharp
class Animal
{
    public virtual void HacerSonido() => Console.WriteLine("Sonido genérico");
}

class Perro : Animal
{
    public override void HacerSonido() => Console.WriteLine("¡Guau!");
}
```

---

## 3. Variables Polimórficas

Permiten que una variable de tipo base apunte a objetos de subclases.

```csharp
Figura f = new Circulo();
f.Dibujar();

f = new Cuadrado();
f.Dibujar();
```

Esto permite trabajar con múltiples tipos concretos de forma uniforme.

---

## 4. Genericidad (Generics)

Permite escribir clases o métodos que funcionan con cualquier tipo.

```csharp
class Caja<T>
{
    private T contenido;
    public void Guardar(T item) => contenido = item;
    public T Obtener() => contenido;
}
```

---

Cada uno de estos ejemplos se encuentra implementado como proyecto en Visual Studio en la solución `PolimorfismoCSharp.sln`.

