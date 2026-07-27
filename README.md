# Sistema de Gestión de Empleados

Proyecto de Windows Forms en C# para la gestión de nómina de empleados, enfocado en herencia, clases abstractas, polimorfismo y excepciones.

## Integrantes
* Alexandra Elizabeth Alvarado Bautista AB260167
* Daniel Steven Palacios Flores PF260246
* Douglas Emmanuel Sánchez Rivera SR260165
* Karla Angie Arias Pérez AP260403

## Arquitectura de Clases

* **Empleado (Abstracta)**: Clase base con ID y nombre. Define el método abstracto `CalcularSalario()`. Implementa `IComparable<Empleado>` para ordenar por salario y sobrescribe `ToString()`.
* **EmpleadoPorHora**: Hereda de Empleado. Calcula salario como `SueldoPorHora * HorasTrabajadas`.
* **EmpleadoAsalariado**: Hereda de Empleado. Retorna un sueldo fijo mensual.
* **EmpleadoComisionista**: Hereda de Empleado. Calcula salario como `SueldoBase + (VentasRealizadas * PorcentajeComision / 100)`.

Diagrama UML: https://drive.google.com/file/d/10kMwALbBlO8RtzPQ6u1iRXLh9jebLzdu/view

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
