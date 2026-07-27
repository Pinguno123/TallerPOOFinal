# Sistema de Gestión de Empleados con Herencia y Clases Abstractas

Este proyecto es una aplicación de escritorio desarrollada en C# utilizando Windows Forms. Permite gestionar una nómina de empleados de una empresa aplicando los conceptos fundamentales de la Programación Orientada a Objetos (POO): herencia, clases abstractas, polimorfismo y manejo de excepciones.

## Integrantes del Equipo
* Alexandra Elizabeth Alvarado Bautista  AB260167 
* Daniel Steven Palacios Flores PF260246 
* Douglas Emmanuel Sánchez Rivera SR260165
* Karla Angie Arias Pérez AP260403

---

## Jerarquía de Clases y Uso de Herencia

La arquitectura del sistema sigue un modelo orientado a objetos compuesto por:

1. **Clase Abstracta `Empleado`**:
   * Actúa como clase base.
   * Contiene los campos comunes (`id`, `nombre`) con sus respectivas validaciones públicas de lectura y escritura.
   * Define el método abstracto `CalcularSalario()`, obligando a todas las subclases a implementar su propia lógica de pago.
   * Implementa la interfaz `IComparable<Empleado>` para poder ordenar de forma automática una lista de empleados por su salario (de mayor a menor).
   * Sobrescribe el método virtual `ToString()` para formatear la salida común de datos.

2. **Clases Derivadas**:
   * **`EmpleadoPorHora`**: Representa a trabajadores remunerados según una tarifa horaria. Su salario se calcula como `SueldoPorHora * HorasTrabajadas`.
   * **`EmpleadoAsalariado`**: Empleados con salario mensual fijo. `CalcularSalario()` simplemente retorna este sueldo fijo.
   * **`EmpleadoComisionista`**: Empleados que cobran un sueldo base sumado a una comisión de ventas. Su salario es `SueldoBase + (VentasRealizadas * PorcentajeComision / 100)`.

---

## Diagrama de Clases UML (Mermaid)

El siguiente diagrama representa la estructura de clases del sistema. Puedes visualizarlo directamente en GitHub o copiar el código en [Mermaid Live Editor](https://mermaid.live) para exportarlo como PNG o JPG:

```mermaid
classDiagram
    class IComparable~Empleado~ {
        <<interface>>
        +CompareTo(Empleado other) int
    }

    class Empleado {
        <<abstract>>
        -string nombre
        -string id
        +Nombre string
        +Id string
        +CalcularSalario()* decimal
        +ToString() string
        +CompareTo(Empleado other) int
    }

    class EmpleadoPorHora {
        -decimal sueldoPorHora
        -double horasTrabajadas
        +SueldoPorHora decimal
        +HorasTrabajadas double
        +CalcularSalario() decimal
        +ToString() string
    }

    class EmpleadoAsalariado {
        -decimal sueldoMensualFijo
        +SueldoMensualFijo decimal
        +CalcularSalario() decimal
        +ToString() string
    }

    class EmpleadoComisionista {
        -decimal sueldoBase
        -decimal ventasRealizadas
        -decimal porcentajeComision
        +SueldoBase decimal
        +VentasRealizadas decimal
        +PorcentajeComision decimal
        +CalcularSalario() decimal
        +ToString() string
    }

    class Exception {
        <<system>>
    }

    class EmpleadoNoEncontradoException {
        +EmpleadoNoEncontradoException()
        +EmpleadoNoEncontradoException(string message)
    }

    class frmGestionEmpleados {
        -List~Empleado~ empleados
        -int edit_indice
        -ComboBox cmbTipo
        -GroupBox groupBoxReportes
        -actualizarGrid() void
        -limpiar() void
        -btnguardar_Click(object sender, EventArgs e) void
        -btneliminar_Click(object sender, EventArgs e) void
        -btnBuscar_Click(object sender, EventArgs e) void
        -btnOrdenar_Click(object sender, EventArgs e) void
        -GuardarCSV() void
        -CargarCSV() void
    }

    IComparable~Empleado~ <|.. Empleado : Implements
    Empleado <|-- EmpleadoPorHora : Inherits
    Empleado <|-- EmpleadoAsalariado : Inherits
    Empleado <|-- EmpleadoComisionista : Inherits
    Exception <|-- EmpleadoNoEncontradoException : Inherits
    frmGestionEmpleados --> Empleado : Manages
```

---

## Instrucciones para Ejecutar el Programa

1. **Requisitos**:
   * Tener instalado el SDK de .NET (.NET Core 8.0, 9.0 o 10.0).
   * Sistema operativo Windows (requerido para ejecutar la interfaz de Windows Forms).

2. **Compilación y Ejecución desde Consola**:
   * Abre la terminal de comandos (cmd o PowerShell) en el directorio raíz del proyecto.
   * Restaura y construye el proyecto ejecutando:
     ```bash
     dotnet build
     ```
   * Ejecuta la aplicación mediante:
     ```bash
     dotnet run
     ```

---

## Capturas de Pantalla de la Ejecución

A continuación se detallan los flujos demostrados en la ejecución de la aplicación:

### 1. Agregar Empleados
*Se ingresa un empleado de cada tipo (Por Hora, Asalariado, Comisionista) validando que los datos se ajusten y se deshabiliten los campos no aplicables según la selección.*

![Agregar Empleados](capturas/1_agregar_empleados.png)

### 2. Calcular y Mostrar Salarios
*La tabla muestra de forma instantánea el tipo de empleado, su descripción mediante `ToString()` y el salario final calculado automáticamente.*

![Calcular Salarios](capturas/2_mostrar_salarios.png)

### 3. Buscar un Empleado por ID
*Uso de la función de búsqueda para cargar los detalles del empleado en los controles de edición.*

![Buscar Empleado](capturas/3_buscar_id.png)

### 4. Lanzamiento y Captura de Excepción Personalizada
*Demostración de que si se intenta buscar o eliminar un ID inexistente, el programa lanza un error controlado por `EmpleadoNoEncontradoException` en un cuadro de diálogo sin colapsar.*

![Manejo de Excepciones](capturas/4_excepcion_inexistente.png)

### 5. Guardar y Cargar desde CSV (Extra)
*Persistencia persistiendo los datos de la grilla en el archivo plano `empleados.csv` de manera transparente.*

![Persistencia CSV](capturas/5_csv_persistencia.png)
