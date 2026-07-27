using System;

namespace TallerPoo
{
    public class EmpleadoAsalariado : Empleado
    {
        private decimal sueldoMensualFijo;

        public decimal SueldoMensualFijo
        {
            get => sueldoMensualFijo;
            set
            {
                if (value < 0)
                    throw new ArgumentException("El sueldo mensual fijo debe ser un valor positivo.");
                sueldoMensualFijo = value;
            }
        }

        public EmpleadoAsalariado(string id, string nombre, decimal sueldoMensualFijo)
            : base(id, nombre)
        {
            SueldoMensualFijo = sueldoMensualFijo;
        }

        public override decimal CalcularSalario()
        {
            return SueldoMensualFijo;
        }

        public override string ToString()
        {
            return base.ToString() + " | Tipo: Asalariado | Sueldo Fijo: " + SueldoMensualFijo.ToString("C") + " | Salario: " + CalcularSalario().ToString("C");
        }
    }
}
