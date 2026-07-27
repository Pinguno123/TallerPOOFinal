using System;

namespace TallerPoo
{
    public class EmpleadoPorHora : Empleado
    {
        private decimal sueldoPorHora;
        private double horasTrabajadas;

        public decimal SueldoPorHora
        {
            get => sueldoPorHora;
            set
            {
                if (value < 0)
                    throw new ArgumentException("El sueldo por hora debe ser un valor positivo.");
                sueldoPorHora = value;
            }
        }

        public double HorasTrabajadas
        {
            get => horasTrabajadas;
            set
            {
                if (value < 0)
                    throw new ArgumentException("Las horas trabajadas deben ser un valor positivo.");
                horasTrabajadas = value;
            }
        }

        public EmpleadoPorHora(string id, string nombre, decimal sueldoPorHora, double horasTrabajadas)
            : base(id, nombre)
        {
            SueldoPorHora = sueldoPorHora;
            HorasTrabajadas = horasTrabajadas;
        }

        public override decimal CalcularSalario()
        {
            return SueldoPorHora * (decimal)HorasTrabajadas;
        }

        public override string ToString()
        {
            return base.ToString() + " | Tipo: Por Hora | Tarifa/Hora: " + SueldoPorHora.ToString("C") + " | Horas: " + HorasTrabajadas + " | Salario: " + CalcularSalario().ToString("C");
        }
    }
}
