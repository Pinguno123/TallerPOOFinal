using System;

namespace TallerPoo
{
    public abstract class Empleado : IComparable<Empleado>
    {
        private string nombre = string.Empty;
        private string id = string.Empty;

        public string Nombre
        {
            get => nombre;
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException("El nombre no puede estar vacío.");
                nombre = value;
            }
        }

        public string Id
        {
            get => id;
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException("El ID no puede estar vacío.");
                id = value.Trim();
            }
        }

        protected Empleado(string id, string nombre)
        {
            Id = id;
            Nombre = nombre;
        }

        public abstract decimal CalcularSalario();

        public override string ToString()
        {
            return "ID: " + Id + " | Nombre: " + Nombre;
        }

        public int CompareTo(Empleado? other)
        {
            if (other == null) return 1;
            // Ordenar por salario de mayor a menor
            return other.CalcularSalario().CompareTo(this.CalcularSalario());
        }
    }
}
