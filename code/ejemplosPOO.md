# Ejemplos de Programación Orientada a Objetos en C#

## 1. Clases y Objetos

Se crea una clase `Persona` que tiene atributos (`Nombre`, `Edad`) y un método `Saludar()`.  
Luego se instancia un objeto `p1` que representa a una persona, y se accede a sus propiedades y métodos.

Este ejemplo muestra cómo definir y utilizar clases y objetos en C#.

---

## 2. Herencia

La clase `Estudiante` hereda de `Persona`.  
Además de los atributos heredados (`Nombre`, `Edad`), `Estudiante` tiene un nuevo atributo `Carrera` y un método `Estudiar()`.

Este ejemplo muestra cómo una clase puede reutilizar características de otra clase usando la herencia.

---

## 3. Polimorfismo

La clase base `Animal` define un método virtual `HacerSonido()`.  
Las clases derivadas `Perro` y `Gato` sobrescriben este método con sus propios comportamientos (`¡Guau!`, `¡Miau!`).

Este ejemplo muestra cómo una misma llamada puede tener diferentes comportamientos según el tipo del objeto.

---

## 4. Encapsulamiento

La clase `CuentaBancaria` protege el acceso directo al atributo `saldo`.  
En su lugar, ofrece métodos públicos `Depositar()`, `Retirar()` y `ObtenerSaldo()` para manipular el saldo de forma segura.

Este ejemplo demuestra cómo se pueden proteger los datos internos de una clase usando modificadores de acceso (`private`, `public`).

---

## 5. Interfaces

Se define una interfaz `IVehiculo` con un método `Conducir()`.  
Las clases `Auto` y `Bicicleta` implementan esta interfaz, cada una con su propia versión del método.

Este ejemplo muestra cómo las interfaces permiten definir contratos que otras clases deben cumplir, facilitando el polimorfismo.

---

