# Sistema de Gestión de Empleados

Proyecto de Windows Forms en C# para la gestión de nómina de empleados, enfocado en herencia, clases abstractas, polimorfismo y excepciones.

## Integrantes
* Alexandra Elizabeth Alvarado Bautista AB260167
* Daniel Steven Palacios Flores PF260246
* Douglas Emmanuel Sánchez Rivera SR260165
* Karla Angie Arias Pérez AP260403

## Jerarquía de Clases y Uso de Herencia

El sistema utiliza una jerarquía de clases para representar distintos tipos de empleados mediante herencia y polimorfismo.

* **Empleado (Abstracta)**: Clase base con ID y nombre. Contiene el constructor, las propiedades públicas con validación, el método abstracto `CalcularSalario()` y sobrescribe `ToString()`. No puede instanciarse directamente.
* **EmpleadoPorHora**: Hereda de Empleado. Calcula salario como `Sueldo por Hora * Horas Trabajadas`.
* **EmpleadoAsalariado**: Hereda de Empleado. Retorna un sueldo fijo mensual.
* **EmpleadoComisionista**: Hereda de Empleado. Calcula salario como `Sueldo Base + (Ventas * Porcentaje de Comisión / 100)`.

La herencia permite reutilizar el código común definido en la clase base `Empleado`, evitando duplicar atributos y funcionalidades en las clases derivadas.

Diagrama UML: https://drive.google.com/file/d/10kMwALbBlO8RtzPQ6u1iRXLh9jebLzdu/view

## Uso del Polimorfismo

Los empleados se almacenan en una colección única de tipo `List<Empleado>`. Al recorrer la lista e invocar `CalcularSalario()` o `ToString()`, el método ejecutado depende del tipo real del objeto almacenado gracias al polimorfismo y al uso de métodos sobrescritos (`override`), lo que simplifica el diseño y favorece su extensibilidad.

## Justificación del Uso de Funciones Flecha

Se utiliza la sintaxis de funciones flecha (`=>`) para simplificar la escritura del código en dos escenarios:

### 1. Miembros con cuerpo de expresión
Se utilizan en los métodos de acceso (`get`) de las propiedades para simplificar la devolución del valor.
```csharp
public string Nombre
{
    get => nombre;
}
```
Esto reduce la cantidad de código y mejora la legibilidad.

### 2. Expresiones lambda y LINQ
Se emplean expresiones lambda para realizar consultas y operaciones eficientes sobre la colección de empleados mediante LINQ:
* `Select()`: Proyección de datos para el DataGridView.
* `Where()`: Filtrado de empleados.
* `Any()`: Verificación de existencia de un ID.
* `FirstOrDefault()`: Localización de un empleado.
* `FindIndex()`: Obtención de la posición de un empleado en la lista.

Ejemplo de filtrado:
```csharp
empleados.Where(emp => emp.CalcularSalario() > salarioMinimo)
```

## Instrucciones de Ejecución

Requisitos: SDK de .NET y Windows.

Ejecutar en la consola:
```bash
dotnet build
dotnet run
```

## Capturas de Ejecución

### 1. Agregar Empleados
Ingreso de datos según tipo de empleado. Los campos no aplicables se deshabilitan.

![Agregar Empleados](Capturas/Cap1.png)

### 2. Calcular y Mostrar Salarios
Visualización de empleados ordenados por salario y resultado en tabla.

![Calcular Salarios](Capturas/Cap2.png)

### 3. Buscar Empleado
Carga de detalles a partir de un ID.

![Buscar Empleado](Capturas/Cap3.png)

### 4. Excepciones
Mensaje de error controlado al buscar o eliminar ID inexistente.

![Manejo de Excepciones](Capturas/Cap4.png)

### 5. Persistencia
Guardado y carga en archivo plano CSV.

![Persistencia CSV](Capturas/Cap5.png)
![Persistencia CSV](Capturas/Cap6.png)
