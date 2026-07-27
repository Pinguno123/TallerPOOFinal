using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace TallerPoo
{
    public partial class frmGestionEmpleados : Form
    {
        private List<Empleado> empleados = new List<Empleado>();
        private int edit_indice = -1;

        private string csvPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "empleados.csv");

        public frmGestionEmpleados()
        {
            InitializeComponent();
            ConfigurarFormularioParaEmpleados();
            
            // Cargar datos persistidos por defecto si el archivo CSV existe
            CargarCSVAlIniciar();
        }

        private void ConfigurarFormularioParaEmpleados()
        {
            // Rellenar y enlazar el ComboBox del tipo de empleado
            cmbTipo.Items.AddRange(new string[] { "Por Hora", "Asalariado", "Comisionista" });
            cmbTipo.SelectedIndex = 0;
            cmbTipo.SelectedIndexChanged += CmbTipo_SelectedIndexChanged;

            // Inicializar visibilidad de campos
            ActualizarVisibilidadCampos();
        }

        private void CmbTipo_SelectedIndexChanged(object? sender, EventArgs e)
        {
            ActualizarVisibilidadCampos();
        }

        private void ActualizarVisibilidadCampos()
        {
            if (cmbTipo.SelectedIndex == 0) // Por Hora
            {
                txtSueldo.Enabled = true;       // Tarifa/Hora
                txtHoras.Enabled = true;        // Horas Trabajadas
                txtVentas.Enabled = false;      // Ventas (No aplica)
                txtComision.Enabled = false;    // Comisión % (No aplica)

                txtVentas.Text = "0";
                txtComision.Text = "0";
            }
            else if (cmbTipo.SelectedIndex == 1) // Asalariado
            {
                txtSueldo.Enabled = true;       // Sueldo Fijo
                txtHoras.Enabled = false;       // Horas Trabajadas (No aplica)
                txtVentas.Enabled = false;      // Ventas (No aplica)
                txtComision.Enabled = false;    // Comisión % (No aplica)

                txtHoras.Text = "0";
                txtVentas.Text = "0";
                txtComision.Text = "0";
            }
            else if (cmbTipo.SelectedIndex == 2) // Comisionista
            {
                txtSueldo.Enabled = true;       // Sueldo Base
                txtHoras.Enabled = false;       // Horas Trabajadas (No aplica)
                txtVentas.Enabled = true;        // Ventas Realizadas
                txtComision.Enabled = true;      // Comisión %

                txtHoras.Text = "0";
            }
        }

        private void actualizarGrid()
        {
            actualizarGridConLista(empleados);
        }

        private void actualizarGridConLista(List<Empleado> lista)
        {
            dgvEmpleados.DataSource = null;
            
            // Crear una proyección para mostrar la información del salario y tipo
            var listaProyectada = lista.Select(emp => new
            {
                ID = emp.Id,
                Nombre = emp.Nombre,
                Tipo = emp.GetType().Name.Replace("Empleado", ""),
                Detalle = emp.ToString(),
                SalarioCalculado = emp.CalcularSalario()
            }).ToList();

            dgvEmpleados.DataSource = listaProyectada;

            // Formatear las columnas de manera segura
            if (dgvEmpleados.Columns.Count > 0)
            {
                if (dgvEmpleados.Columns["ID"] is DataGridViewColumn colId) colId.Width = 70;
                if (dgvEmpleados.Columns["Nombre"] is DataGridViewColumn colNom) colNom.Width = 140;
                if (dgvEmpleados.Columns["Tipo"] is DataGridViewColumn colTipo) colTipo.Width = 90;
                if (dgvEmpleados.Columns["Detalle"] is DataGridViewColumn colDet) colDet.Width = 300;
                if (dgvEmpleados.Columns["SalarioCalculado"] is DataGridViewColumn colSal)
                {
                    colSal.HeaderText = "Salario Final";
                    if (colSal.DefaultCellStyle != null) colSal.DefaultCellStyle.Format = "C2";
                    colSal.Width = 100;
                }
            }
        }

        private void limpiar()
        {
            txtId.Clear();
            txtNombre.Clear();
            txtSueldo.Clear();
            txtHoras.Clear();
            txtVentas.Clear();
            txtComision.Clear();
            
            cmbTipo.SelectedIndex = 0;
            edit_indice = -1;
            
            ActualizarVisibilidadCampos();
        }

        private void dgvCelulares_DoubleClick(object sender, EventArgs e)
        {
            if (dgvEmpleados.SelectedRows.Count == 0) return;

            DataGridViewRow seleccion = dgvEmpleados.SelectedRows[0];
            string? id = seleccion.Cells["ID"].Value?.ToString();

            if (string.IsNullOrEmpty(id)) return;

            int pos = empleados.FindIndex(emp => emp.Id.Equals(id, StringComparison.OrdinalIgnoreCase));
            if (pos == -1) return;

            edit_indice = pos;
            Empleado emp = empleados[pos];

            txtId.Text = emp.Id;
            txtNombre.Text = emp.Nombre;

            if (emp is EmpleadoPorHora eph)
            {
                cmbTipo.SelectedIndex = 0;
                txtSueldo.Text = eph.SueldoPorHora.ToString();
                txtHoras.Text = eph.HorasTrabajadas.ToString();
            }
            else if (emp is EmpleadoAsalariado ea)
            {
                cmbTipo.SelectedIndex = 1;
                txtSueldo.Text = ea.SueldoMensualFijo.ToString();
            }
            else if (emp is EmpleadoComisionista ec)
            {
                cmbTipo.SelectedIndex = 2;
                txtSueldo.Text = ec.SueldoBase.ToString();
                txtVentas.Text = ec.VentasRealizadas.ToString();
                txtComision.Text = ec.PorcentajeComision.ToString();
            }

            ActualizarVisibilidadCampos();
        }

        private void btnguardar_Click(object sender, EventArgs e)
        {
            try
            {
                string id = txtId.Text.Trim();
                string nombre = txtNombre.Text.Trim();

                if (string.IsNullOrWhiteSpace(id))
                {
                    MessageBox.Show("El ID del empleado es un campo obligatorio.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                
                if (string.IsNullOrWhiteSpace(nombre))
                {
                    MessageBox.Show("El Nombre del empleado es un campo obligatorio.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                Empleado nuevoEmpleado;

                if (cmbTipo.SelectedIndex == 0) // Por Hora
                {
                    if (!decimal.TryParse(txtSueldo.Text, out decimal tarifaHora) || tarifaHora < 0)
                        throw new ArgumentException("El sueldo por hora debe ser un valor numérico positivo.");
                    if (!double.TryParse(txtHoras.Text, out double horas) || horas < 0)
                        throw new ArgumentException("Las horas trabajadas deben ser un valor numérico positivo.");

                    nuevoEmpleado = new EmpleadoPorHora(id, nombre, tarifaHora, horas);
                }
                else if (cmbTipo.SelectedIndex == 1) // Asalariado
                {
                    if (!decimal.TryParse(txtSueldo.Text, out decimal sueldoFijo) || sueldoFijo < 0)
                        throw new ArgumentException("El sueldo mensual fijo debe ser un valor numérico positivo.");

                    nuevoEmpleado = new EmpleadoAsalariado(id, nombre, sueldoFijo);
                }
                else // Comisionista
                {
                    if (!decimal.TryParse(txtSueldo.Text, out decimal sueldoBase) || sueldoBase < 0)
                        throw new ArgumentException("El sueldo base debe ser un valor numérico positivo.");
                    if (!decimal.TryParse(txtVentas.Text, out decimal ventas) || ventas < 0)
                        throw new ArgumentException("Las ventas realizadas deben ser un valor numérico positivo.");
                    if (!decimal.TryParse(txtComision.Text, out decimal comision) || comision < 0)
                        throw new ArgumentException("El porcentaje de comisión debe ser un valor numérico positivo.");

                    nuevoEmpleado = new EmpleadoComisionista(id, nombre, sueldoBase, ventas, comision);
                }

                // Guardar o Actualizar
                if (edit_indice > -1)
                {
                    // Validar ID único si se cambió
                    string idAnterior = empleados[edit_indice].Id;
                    if (!idAnterior.Equals(id, StringComparison.OrdinalIgnoreCase) &&
                        empleados.Any(emp => emp.Id.Equals(id, StringComparison.OrdinalIgnoreCase)))
                    {
                        MessageBox.Show("El nuevo ID ingresado ya existe para otro empleado.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    empleados[edit_indice] = nuevoEmpleado;
                    edit_indice = -1;
                    MessageBox.Show("Empleado actualizado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    // Validar ID único al agregar
                    if (empleados.Any(emp => emp.Id.Equals(id, StringComparison.OrdinalIgnoreCase)))
                    {
                        MessageBox.Show("Ya existe un empleado registrado con ese ID. El ID debe ser único.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    empleados.Add(nuevoEmpleado);
                    MessageBox.Show("Empleado registrado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                actualizarGrid();
                limpiar();
            }
            catch (ArgumentException ex)
            {
                MessageBox.Show(ex.Message, "Error de Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al procesar: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btneliminar_Click(object sender, EventArgs e)
        {
            try
            {
                string idEliminar = txtId.Text.Trim();

                if (string.IsNullOrWhiteSpace(idEliminar))
                {
                    throw new EmpleadoNoEncontradoException("No se ha especificado ningún ID de empleado para eliminar.");
                }

                int index = empleados.FindIndex(emp => emp.Id.Equals(idEliminar, StringComparison.OrdinalIgnoreCase));
                
                if (index == -1)
                {
                    throw new EmpleadoNoEncontradoException("No existe ningún empleado registrado con el ID '" + idEliminar + "'.");
                }

                Empleado emp = empleados[index];
                var confirmacion = MessageBox.Show("¿Desea eliminar permanentemente al empleado:\n" + emp.Nombre + " (ID: " + emp.Id + ")?",
                                                   "Confirmar Eliminación",
                                                   MessageBoxButtons.YesNo,
                                                   MessageBoxIcon.Question);

                if (confirmacion == DialogResult.Yes)
                {
                    empleados.RemoveAt(index);
                    edit_indice = -1;
                    limpiar();
                    actualizarGrid();
                    MessageBox.Show("Empleado eliminado del sistema.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (EmpleadoNoEncontradoException ex)
            {
                MessageBox.Show(ex.Message, "Empleado No Encontrado", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocurrió un error inesperado al eliminar: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnDeseleccionar_Click(object? sender, EventArgs e)
        {
            limpiar();
            dgvEmpleados.ClearSelection();
        }

        // --- MÉTODOS DE OPERACIONES EXTRA Y REPORTES ---

        private void btnBuscar_Click(object? sender, EventArgs e)
        {
            try
            {
                string idBuscar = txtId.Text.Trim();

                if (string.IsNullOrWhiteSpace(idBuscar))
                {
                    throw new EmpleadoNoEncontradoException("Por favor, ingrese el ID a buscar en la casilla 'ID del Empleado'.");
                }

                Empleado? emp = empleados.FirstOrDefault(emp => emp.Id.Equals(idBuscar, StringComparison.OrdinalIgnoreCase));

                if (emp == null)
                {
                    throw new EmpleadoNoEncontradoException("No se pudo encontrar ningún empleado con el ID '" + idBuscar + "'.");
                }

                MessageBox.Show("Empleado Encontrado:\n\n" + emp.ToString() + "\n\nSalario Calculado: " + emp.CalcularSalario().ToString("C2"),
                                "Búsqueda Exitosa",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Information);

                // Seleccionar y cargar en formulario
                int pos = empleados.IndexOf(emp);
                edit_indice = pos;

                txtId.Text = emp.Id;
                txtNombre.Text = emp.Nombre;

                if (emp is EmpleadoPorHora eph)
                {
                    cmbTipo.SelectedIndex = 0;
                    txtSueldo.Text = eph.SueldoPorHora.ToString();
                    txtHoras.Text = eph.HorasTrabajadas.ToString();
                }
                else if (emp is EmpleadoAsalariado ea)
                {
                    cmbTipo.SelectedIndex = 1;
                    txtSueldo.Text = ea.SueldoMensualFijo.ToString();
                }
                else if (emp is EmpleadoComisionista ec)
                {
                    cmbTipo.SelectedIndex = 2;
                    txtSueldo.Text = ec.SueldoBase.ToString();
                    txtVentas.Text = ec.VentasRealizadas.ToString();
                    txtComision.Text = ec.PorcentajeComision.ToString();
                }

                ActualizarVisibilidadCampos();
            }
            catch (EmpleadoNoEncontradoException ex)
            {
                MessageBox.Show(ex.Message, "Empleado No Encontrado", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al buscar: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnOrdenar_Click(object? sender, EventArgs e)
        {
            if (empleados.Count == 0)
            {
                MessageBox.Show("No hay empleados registrados para ordenar.", "Ordenar", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Utiliza IComparable para ordenar de mayor a menor salario
            empleados.Sort();
            actualizarGrid();
            MessageBox.Show("Empleados ordenados por salario (de mayor a menor) con éxito.", "Ordenación Exitosa", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnFiltrarSalario_Click(object? sender, EventArgs e)
        {
            if (!decimal.TryParse(txtFiltroSalario.Text, out decimal salarioMinimo) || salarioMinimo < 0)
            {
                MessageBox.Show("Por favor, ingrese un monto de salario numérico y positivo para filtrar.", "Filtrar por Salario", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var filtrados = empleados.Where(emp => emp.CalcularSalario() > salarioMinimo).ToList();
            actualizarGridConLista(filtrados);
        }

        private void btnFiltrarTipo_Click(object? sender, EventArgs e)
        {
            if (cmbFiltroTipo.SelectedIndex == -1)
            {
                MessageBox.Show("Seleccione un tipo de empleado para aplicar el filtro.", "Filtrar por Tipo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int index = cmbFiltroTipo.SelectedIndex;
            List<Empleado> filtrados;

            if (index == 0) // Por Hora
                filtrados = empleados.Where(emp => emp is EmpleadoPorHora).ToList();
            else if (index == 1) // Asalariado
                filtrados = empleados.Where(emp => emp is EmpleadoAsalariado).ToList();
            else // Comisionista
                filtrados = empleados.Where(emp => emp is EmpleadoComisionista).ToList();

            actualizarGridConLista(filtrados);
        }

        private void btnMostrarTodos_Click(object? sender, EventArgs e)
        {
            txtFiltroSalario.Clear();
            cmbFiltroTipo.SelectedIndex = -1;
            actualizarGrid();
        }

        private void btnGuardarCSV_Click(object? sender, EventArgs e)
        {
            GuardarCSV();
        }

        private void btnCargarCSV_Click(object? sender, EventArgs e)
        {
            CargarCSV();
        }

        private void GuardarCSV()
        {
            try
            {
                List<string> lineas = new List<string>();
                foreach (var emp in empleados)
                {
                    if (emp is EmpleadoPorHora eph)
                    {
                        lineas.Add("PorHora," + eph.Id + "," + eph.Nombre + "," + eph.SueldoPorHora + "," + eph.HorasTrabajadas);
                    }
                    else if (emp is EmpleadoAsalariado ea)
                    {
                        lineas.Add("Asalariado," + ea.Id + "," + ea.Nombre + "," + ea.SueldoMensualFijo);
                    }
                    else if (emp is EmpleadoComisionista ec)
                    {
                        lineas.Add("Comisionista," + ec.Id + "," + ec.Nombre + "," + ec.SueldoBase + "," + ec.VentasRealizadas + "," + ec.PorcentajeComision);
                    }
                }

                File.WriteAllLines(csvPath, lineas, Encoding.UTF8);
                MessageBox.Show("Datos exportados exitosamente a empleados.csv.", "CSV Exportado", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al guardar el archivo CSV: " + ex.Message, "Error de Guardado", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CargarCSV()
        {
            try
            {
                if (!File.Exists(csvPath))
                {
                    MessageBox.Show("No se encontró el archivo 'empleados.csv' en el directorio de ejecución.", "Cargar CSV", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                string[] lineas = File.ReadAllLines(csvPath, Encoding.UTF8);
                empleados.Clear();

                foreach (var linea in lineas)
                {
                    if (string.IsNullOrWhiteSpace(linea)) continue;
                    string[] partes = linea.Split(',');
                    if (partes.Length < 3) continue;

                    string tipo = partes[0];
                    string id = partes[1];
                    string nombre = partes[2];

                    if (tipo == "PorHora" && partes.Length == 5)
                    {
                        decimal tarifa = decimal.Parse(partes[3]);
                        double horas = double.Parse(partes[4]);
                        empleados.Add(new EmpleadoPorHora(id, nombre, tarifa, horas));
                    }
                    else if (tipo == "Asalariado" && partes.Length == 4)
                    {
                        decimal sueldoFijo = decimal.Parse(partes[3]);
                        empleados.Add(new EmpleadoAsalariado(id, nombre, sueldoFijo));
                    }
                    else if (tipo == "Comisionista" && partes.Length == 6)
                    {
                        decimal baseSueldo = decimal.Parse(partes[3]);
                        decimal ventas = decimal.Parse(partes[4]);
                        decimal comision = decimal.Parse(partes[5]);
                        empleados.Add(new EmpleadoComisionista(id, nombre, baseSueldo, ventas, comision));
                    }
                }

                actualizarGrid();
                MessageBox.Show("Se importaron " + empleados.Count + " empleados desde 'empleados.csv'.", "CSV Cargado", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar el archivo CSV: " + ex.Message, "Error de Carga", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CargarCSVAlIniciar()
        {
            if (File.Exists(csvPath))
            {
                try
                {
                    string[] lineas = File.ReadAllLines(csvPath, Encoding.UTF8);
                    foreach (var linea in lineas)
                    {
                        if (string.IsNullOrWhiteSpace(linea)) continue;
                        string[] partes = linea.Split(',');
                        if (partes.Length < 3) continue;

                        string tipo = partes[0];
                        string id = partes[1];
                        string nombre = partes[2];

                        if (tipo == "PorHora" && partes.Length == 5)
                        {
                            decimal tarifa = decimal.Parse(partes[3]);
                            double horas = double.Parse(partes[4]);
                            empleados.Add(new EmpleadoPorHora(id, nombre, tarifa, horas));
                        }
                        else if (tipo == "Asalariado" && partes.Length == 4)
                        {
                            decimal sueldoFijo = decimal.Parse(partes[3]);
                            empleados.Add(new EmpleadoAsalariado(id, nombre, sueldoFijo));
                        }
                        else if (tipo == "Comisionista" && partes.Length == 6)
                        {
                            decimal baseSueldo = decimal.Parse(partes[3]);
                            decimal ventas = decimal.Parse(partes[4]);
                            decimal comision = decimal.Parse(partes[5]);
                            empleados.Add(new EmpleadoComisionista(id, nombre, baseSueldo, ventas, comision));
                        }
                    }
                    actualizarGrid();
                }
                catch
                {
                    // Ignorar errores al inicio silenciosamente
                }
            }
        }
    }
}
