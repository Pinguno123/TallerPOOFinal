namespace TallerPoo
{
    partial class frmGestionEmpleados
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            groupBox1 = new GroupBox();
            btnDeseleccionar = new Button();
            txtComision = new TextBox();
            label7 = new Label();
            txtVentas = new TextBox();
            label6 = new Label();
            txtHoras = new TextBox();
            label5 = new Label();
            txtSueldo = new TextBox();
            label4 = new Label();
            cmbTipo = new ComboBox();
            label3 = new Label();
            txtNombre = new TextBox();
            label2 = new Label();
            btneliminar = new Button();
            txtId = new TextBox();
            btnguardar = new Button();
            label1 = new Label();
            dgvEmpleados = new DataGridView();
            groupBoxReportes = new GroupBox();
            lblSalario = new Label();
            txtFiltroSalario = new TextBox();
            btnFiltrarSalario = new Button();
            lblTipo = new Label();
            cmbFiltroTipo = new ComboBox();
            btnFiltrarTipo = new Button();
            btnMostrarTodos = new Button();
            btnBuscar = new Button();
            btnOrdenar = new Button();
            btnCargarCSV = new Button();
            btnGuardarCSV = new Button();
            groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvEmpleados).BeginInit();
            groupBoxReportes.SuspendLayout();
            SuspendLayout();
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(btnDeseleccionar);
            groupBox1.Controls.Add(txtComision);
            groupBox1.Controls.Add(label7);
            groupBox1.Controls.Add(txtVentas);
            groupBox1.Controls.Add(label6);
            groupBox1.Controls.Add(txtHoras);
            groupBox1.Controls.Add(label5);
            groupBox1.Controls.Add(txtSueldo);
            groupBox1.Controls.Add(label4);
            groupBox1.Controls.Add(cmbTipo);
            groupBox1.Controls.Add(label3);
            groupBox1.Controls.Add(txtNombre);
            groupBox1.Controls.Add(label2);
            groupBox1.Controls.Add(btneliminar);
            groupBox1.Controls.Add(txtId);
            groupBox1.Controls.Add(btnguardar);
            groupBox1.Controls.Add(label1);
            groupBox1.Location = new Point(26, 34);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(428, 391);
            groupBox1.TabIndex = 0;
            groupBox1.TabStop = false;
            groupBox1.Text = "Registro del Empleado";
            // 
            // btnDeseleccionar
            // 
            btnDeseleccionar.Location = new Point(325, 257);
            btnDeseleccionar.Name = "btnDeseleccionar";
            btnDeseleccionar.Size = new Size(85, 32);
            btnDeseleccionar.TabIndex = 17;
            btnDeseleccionar.Text = "Cancelar";
            btnDeseleccionar.UseVisualStyleBackColor = true;
            btnDeseleccionar.Click += btnDeseleccionar_Click;
            // 
            // txtComision
            // 
            txtComision.Location = new Point(208, 338);
            txtComision.Name = "txtComision";
            txtComision.Size = new Size(100, 29);
            txtComision.TabIndex = 16;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(15, 341);
            label7.Name = "label7";
            label7.Size = new Size(176, 21);
            label7.TabIndex = 15;
            label7.Text = "Comisión % (Comisión):";
            // 
            // txtVentas
            // 
            txtVentas.Location = new Point(208, 286);
            txtVentas.Name = "txtVentas";
            txtVentas.Size = new Size(100, 29);
            txtVentas.TabIndex = 14;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(15, 289);
            label6.Name = "label6";
            label6.Size = new Size(187, 21);
            label6.TabIndex = 13;
            label6.Text = "Ventas Realiz. (Comisión):";
            // 
            // txtHoras
            // 
            txtHoras.Location = new Point(208, 234);
            txtHoras.Name = "txtHoras";
            txtHoras.Size = new Size(100, 29);
            txtHoras.TabIndex = 12;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(15, 237);
            label5.Name = "label5";
            label5.Size = new Size(166, 21);
            label5.TabIndex = 11;
            label5.Text = "Horas Trab. (Por Hora):";
            // 
            // txtSueldo
            // 
            txtSueldo.Location = new Point(208, 182);
            txtSueldo.Name = "txtSueldo";
            txtSueldo.Size = new Size(100, 29);
            txtSueldo.TabIndex = 10;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(15, 185);
            label4.Name = "label4";
            label4.Size = new Size(127, 21);
            label4.TabIndex = 9;
            label4.Text = "Sueldo/Tarifa ($):";
            // 
            // cmbTipo
            // 
            cmbTipo.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbTipo.FormattingEnabled = true;
            cmbTipo.Location = new Point(208, 130);
            cmbTipo.Name = "cmbTipo";
            cmbTipo.Size = new Size(100, 29);
            cmbTipo.TabIndex = 8;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(15, 133);
            label3.Name = "label3";
            label3.Size = new Size(137, 21);
            label3.TabIndex = 7;
            label3.Text = "Tipo de Empleado:";
            // 
            // txtNombre
            // 
            txtNombre.Location = new Point(208, 78);
            txtNombre.Name = "txtNombre";
            txtNombre.Size = new Size(100, 29);
            txtNombre.TabIndex = 6;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(15, 81);
            label2.Name = "label2";
            label2.Size = new Size(143, 21);
            label2.TabIndex = 5;
            label2.Text = "Nombre Completo:";
            // 
            // btneliminar
            // 
            btneliminar.Location = new Point(325, 341);
            btneliminar.Name = "btneliminar";
            btneliminar.Size = new Size(85, 32);
            btneliminar.TabIndex = 4;
            btneliminar.Text = "Eliminar";
            btneliminar.UseVisualStyleBackColor = true;
            btneliminar.Click += btneliminar_Click;
            // 
            // txtId
            // 
            txtId.Location = new Point(208, 26);
            txtId.Name = "txtId";
            txtId.Size = new Size(100, 29);
            txtId.TabIndex = 3;
            // 
            // btnguardar
            // 
            btnguardar.Location = new Point(325, 299);
            btnguardar.Name = "btnguardar";
            btnguardar.Size = new Size(85, 32);
            btnguardar.TabIndex = 2;
            btnguardar.Text = "Guardar";
            btnguardar.UseVisualStyleBackColor = true;
            btnguardar.Click += btnguardar_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(15, 29);
            label1.Name = "label1";
            label1.Size = new Size(126, 21);
            label1.TabIndex = 1;
            label1.Text = "ID del Empleado:";
            // 
            // dgvEmpleados
            // 
            dgvEmpleados.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvEmpleados.Location = new Point(480, 33);
            dgvEmpleados.Name = "dgvEmpleados";
            dgvEmpleados.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvEmpleados.Size = new Size(741, 565);
            dgvEmpleados.TabIndex = 1;
            dgvEmpleados.DoubleClick += dgvCelulares_DoubleClick;
            // 
            // groupBoxReportes
            // 
            groupBoxReportes.Controls.Add(lblSalario);
            groupBoxReportes.Controls.Add(txtFiltroSalario);
            groupBoxReportes.Controls.Add(btnFiltrarSalario);
            groupBoxReportes.Controls.Add(lblTipo);
            groupBoxReportes.Controls.Add(cmbFiltroTipo);
            groupBoxReportes.Controls.Add(btnFiltrarTipo);
            groupBoxReportes.Controls.Add(btnMostrarTodos);
            groupBoxReportes.Controls.Add(btnBuscar);
            groupBoxReportes.Controls.Add(btnOrdenar);
            groupBoxReportes.Controls.Add(btnCargarCSV);
            groupBoxReportes.Controls.Add(btnGuardarCSV);
            groupBoxReportes.Location = new Point(26, 435);
            groupBoxReportes.Name = "groupBoxReportes";
            groupBoxReportes.Size = new Size(428, 165);
            groupBoxReportes.TabIndex = 2;
            groupBoxReportes.TabStop = false;
            groupBoxReportes.Text = "Operaciones Extra y Reportes";
            // 
            // lblSalario
            // 
            lblSalario.AutoSize = true;
            lblSalario.Location = new Point(15, 28);
            lblSalario.Name = "lblSalario";
            lblSalario.Size = new Size(73, 21);
            lblSalario.TabIndex = 0;
            lblSalario.Text = "Salario >";
            // 
            // txtFiltroSalario
            // 
            txtFiltroSalario.Location = new Point(90, 25);
            txtFiltroSalario.Name = "txtFiltroSalario";
            txtFiltroSalario.Size = new Size(85, 29);
            txtFiltroSalario.TabIndex = 1;
            // 
            // btnFiltrarSalario
            // 
            btnFiltrarSalario.Location = new Point(185, 23);
            btnFiltrarSalario.Name = "btnFiltrarSalario";
            btnFiltrarSalario.Size = new Size(70, 32);
            btnFiltrarSalario.TabIndex = 2;
            btnFiltrarSalario.Text = "Filtrar";
            btnFiltrarSalario.UseVisualStyleBackColor = true;
            btnFiltrarSalario.Click += btnFiltrarSalario_Click;
            // 
            // lblTipo
            // 
            lblTipo.AutoSize = true;
            lblTipo.Location = new Point(15, 68);
            lblTipo.Name = "lblTipo";
            lblTipo.Size = new Size(43, 21);
            lblTipo.TabIndex = 3;
            lblTipo.Text = "Tipo:";
            // 
            // cmbFiltroTipo
            // 
            cmbFiltroTipo.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbFiltroTipo.FormattingEnabled = true;
            cmbFiltroTipo.Items.AddRange(new object[] { "Por Hora", "Asalariado", "Comisionista" });
            cmbFiltroTipo.Location = new Point(90, 65);
            cmbFiltroTipo.Name = "cmbFiltroTipo";
            cmbFiltroTipo.Size = new Size(120, 29);
            cmbFiltroTipo.TabIndex = 4;
            // 
            // btnFiltrarTipo
            // 
            btnFiltrarTipo.Location = new Point(220, 63);
            btnFiltrarTipo.Name = "btnFiltrarTipo";
            btnFiltrarTipo.Size = new Size(70, 32);
            btnFiltrarTipo.TabIndex = 5;
            btnFiltrarTipo.Text = "Filtrar";
            btnFiltrarTipo.UseVisualStyleBackColor = true;
            btnFiltrarTipo.Click += btnFiltrarTipo_Click;
            // 
            // btnMostrarTodos
            // 
            btnMostrarTodos.Location = new Point(305, 23);
            btnMostrarTodos.Name = "btnMostrarTodos";
            btnMostrarTodos.Size = new Size(110, 72);
            btnMostrarTodos.TabIndex = 6;
            btnMostrarTodos.Text = "Limpiar\nFiltros";
            btnMostrarTodos.UseVisualStyleBackColor = true;
            btnMostrarTodos.Click += btnMostrarTodos_Click;
            // 
            // btnBuscar
            // 
            btnBuscar.Location = new Point(15, 115);
            btnBuscar.Name = "btnBuscar";
            btnBuscar.Size = new Size(85, 32);
            btnBuscar.TabIndex = 7;
            btnBuscar.Text = "Buscar ID";
            btnBuscar.UseVisualStyleBackColor = true;
            btnBuscar.Click += btnBuscar_Click;
            // 
            // btnOrdenar
            // 
            btnOrdenar.Location = new Point(105, 115);
            btnOrdenar.Name = "btnOrdenar";
            btnOrdenar.Size = new Size(120, 32);
            btnOrdenar.TabIndex = 8;
            btnOrdenar.Text = "Ordenar Salario";
            btnOrdenar.UseVisualStyleBackColor = true;
            btnOrdenar.Click += btnOrdenar_Click;
            // 
            // btnCargarCSV
            // 
            btnCargarCSV.Location = new Point(230, 115);
            btnCargarCSV.Name = "btnCargarCSV";
            btnCargarCSV.Size = new Size(90, 32);
            btnCargarCSV.TabIndex = 9;
            btnCargarCSV.Text = "Cargar CSV";
            btnCargarCSV.UseVisualStyleBackColor = true;
            btnCargarCSV.Click += btnCargarCSV_Click;
            // 
            // btnGuardarCSV
            // 
            btnGuardarCSV.Location = new Point(325, 115);
            btnGuardarCSV.Name = "btnGuardarCSV";
            btnGuardarCSV.Size = new Size(90, 32);
            btnGuardarCSV.TabIndex = 10;
            btnGuardarCSV.Text = "Guardar CSV";
            btnGuardarCSV.UseVisualStyleBackColor = true;
            btnGuardarCSV.Click += btnGuardarCSV_Click;
            // 
            // frmGestionEmpleados
            // 
            AutoScaleDimensions = new SizeF(9F, 21F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1241, 630);
            Controls.Add(groupBoxReportes);
            Controls.Add(dgvEmpleados);
            Controls.Add(groupBox1);
            Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            Margin = new Padding(4);
            Name = "frmGestionEmpleados";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Sistema de Gestión de Empleados ";
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvEmpleados).EndInit();
            groupBoxReportes.ResumeLayout(false);
            groupBoxReportes.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private GroupBox groupBox1;
        private Button btnguardar;
        private Label label1;
        private TextBox txtId;
        private Button btneliminar;
        private TextBox txtComision;
        private Label label7;
        private TextBox txtVentas;
        private Label label6;
        private TextBox txtHoras;
        private Label label5;
        private TextBox txtSueldo;
        private Label label4;
        private ComboBox cmbTipo;
        private Label label3;
        private TextBox txtNombre;
        private Label label2;
        private DataGridView dgvEmpleados;
        private Button btnDeseleccionar;
        private GroupBox groupBoxReportes;
        private Button btnBuscar;
        private Button btnOrdenar;
        private Button btnFiltrarSalario;
        private TextBox txtFiltroSalario;
        private Button btnFiltrarTipo;
        private ComboBox cmbFiltroTipo;
        private Button btnMostrarTodos;
        private Button btnGuardarCSV;
        private Button btnCargarCSV;
        private Label lblSalario;
        private Label lblTipo;
    }
}
