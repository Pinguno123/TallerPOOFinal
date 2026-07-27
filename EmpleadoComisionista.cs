using System;

namespace TallerPoo
{
    public class EmpleadoComisionista : Empleado
    {
        private decimal sueldoBase;
        private decimal ventasRealizadas;
        private decimal porcentajeComision;

        public decimal SueldoBase
        {
            get => sueldoBase;
            set
            {
                if (value < 0)
                    throw new ArgumentException("El sueldo base debe ser un valor positivo.");
                sueldoBase = value;
            }
        }

        public decimal VentasRealizadas
        {
            get => ventasRealizadas;
            set
            {
                if (value < 0)
                    throw new ArgumentException("Las ventas realizadas deben ser un valor positivo.");
                ventasRealizadas = value;
            }
        }

        public decimal PorcentajeComision
        {
            get => porcentajeComision;
            set
            {
                if (value < 0)
                    throw new ArgumentException("El porcentaje de comisión debe ser un valor positivo.");
                porcentajeComision = value;
            }
        }

        public EmpleadoComisionista(string id, string nombre, decimal sueldoBase, decimal ventasRealizadas, decimal porcentajeComision)
            : base(id, nombre)
        {
            SueldoBase = sueldoBase;
            VentasRealizadas = ventasRealizadas;
            PorcentajeComision = porcentajeComision;
        }

        public override decimal CalcularSalario()
        {
            return SueldoBase + (VentasRealizadas * PorcentajeComision / 100);
        }

        public override string ToString()
        {
            return base.ToString() + " | Tipo: Comisionista | Sueldo Base: " + SueldoBase.ToString("C") + " | Ventas: " + VentasRealizadas.ToString("C") + " | Comisión: " + PorcentajeComision + "% | Salario: " + CalcularSalario().ToString("C");
        }
    }
}
