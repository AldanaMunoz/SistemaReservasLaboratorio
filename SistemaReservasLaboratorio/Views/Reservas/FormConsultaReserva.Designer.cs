namespace SistemaReservasLaboratorio.Views.Reservas
{
    partial class FormConsultaReserva
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnBuscarTodas = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.dtpFechaBusqueda = new System.Windows.Forms.DateTimePicker();
            this.btnBuscarPorFecha = new System.Windows.Forms.Button();
            this.btnBuscarPorProfesor = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.txtProfesorBusqueda = new System.Windows.Forms.TextBox();
            this.txtAsignaturaBusqueda = new System.Windows.Forms.TextBox();
            this.btnBuscarPorAsignatura = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.dgvReservas = new System.Windows.Forms.DataGridView();
            this.lblResultados = new System.Windows.Forms.Label();
            this.btnCerrar = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvReservas)).BeginInit();
            this.SuspendLayout();
            // 
            // btnBuscarTodas
            // 
            this.btnBuscarTodas.Location = new System.Drawing.Point(23, 30);
            this.btnBuscarTodas.Name = "btnBuscarTodas";
            this.btnBuscarTodas.Size = new System.Drawing.Size(106, 27);
            this.btnBuscarTodas.TabIndex = 0;
            this.btnBuscarTodas.Text = "Ver Todas";
            this.btnBuscarTodas.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(20, 75);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(72, 16);
            this.label1.TabIndex = 1;
            this.label1.Text = "Por Fecha:";
            // 
            // dtpFechaBusqueda
            // 
            this.dtpFechaBusqueda.Location = new System.Drawing.Point(136, 72);
            this.dtpFechaBusqueda.Name = "dtpFechaBusqueda";
            this.dtpFechaBusqueda.Size = new System.Drawing.Size(200, 22);
            this.dtpFechaBusqueda.TabIndex = 2;
            // 
            // btnBuscarPorFecha
            // 
            this.btnBuscarPorFecha.Location = new System.Drawing.Point(382, 72);
            this.btnBuscarPorFecha.Name = "btnBuscarPorFecha";
            this.btnBuscarPorFecha.Size = new System.Drawing.Size(71, 26);
            this.btnBuscarPorFecha.TabIndex = 3;
            this.btnBuscarPorFecha.Text = "Buscar";
            this.btnBuscarPorFecha.UseVisualStyleBackColor = true;
            // 
            // btnBuscarPorProfesor
            // 
            this.btnBuscarPorProfesor.Location = new System.Drawing.Point(382, 114);
            this.btnBuscarPorProfesor.Name = "btnBuscarPorProfesor";
            this.btnBuscarPorProfesor.Size = new System.Drawing.Size(71, 26);
            this.btnBuscarPorProfesor.TabIndex = 6;
            this.btnBuscarPorProfesor.Text = "Buscar";
            this.btnBuscarPorProfesor.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(20, 117);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(85, 16);
            this.label2.TabIndex = 4;
            this.label2.Text = "Por Profesor:";
            // 
            // txtProfesorBusqueda
            // 
            this.txtProfesorBusqueda.Location = new System.Drawing.Point(136, 116);
            this.txtProfesorBusqueda.Name = "txtProfesorBusqueda";
            this.txtProfesorBusqueda.Size = new System.Drawing.Size(200, 22);
            this.txtProfesorBusqueda.TabIndex = 7;
            // 
            // txtAsignaturaBusqueda
            // 
            this.txtAsignaturaBusqueda.Location = new System.Drawing.Point(136, 157);
            this.txtAsignaturaBusqueda.Name = "txtAsignaturaBusqueda";
            this.txtAsignaturaBusqueda.Size = new System.Drawing.Size(200, 22);
            this.txtAsignaturaBusqueda.TabIndex = 10;
            // 
            // btnBuscarPorAsignatura
            // 
            this.btnBuscarPorAsignatura.Location = new System.Drawing.Point(382, 155);
            this.btnBuscarPorAsignatura.Name = "btnBuscarPorAsignatura";
            this.btnBuscarPorAsignatura.Size = new System.Drawing.Size(71, 26);
            this.btnBuscarPorAsignatura.TabIndex = 9;
            this.btnBuscarPorAsignatura.Text = "Buscar";
            this.btnBuscarPorAsignatura.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(20, 158);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(98, 16);
            this.label3.TabIndex = 8;
            this.label3.Text = "Por Asignatura:";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtAsignaturaBusqueda);
            this.groupBox1.Controls.Add(this.btnBuscarPorAsignatura);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.txtProfesorBusqueda);
            this.groupBox1.Controls.Add(this.btnBuscarPorProfesor);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.btnBuscarPorFecha);
            this.groupBox1.Controls.Add(this.dtpFechaBusqueda);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.btnBuscarTodas);
            this.groupBox1.Location = new System.Drawing.Point(41, 26);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(472, 221);
            this.groupBox1.TabIndex = 11;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Búsqueda";
            // 
            // dgvReservas
            // 
            this.dgvReservas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvReservas.Location = new System.Drawing.Point(24, 286);
            this.dgvReservas.Name = "dgvReservas";
            this.dgvReservas.RowHeadersWidth = 51;
            this.dgvReservas.RowTemplate.Height = 24;
            this.dgvReservas.Size = new System.Drawing.Size(541, 341);
            this.dgvReservas.TabIndex = 12;
            // 
            // lblResultados
            // 
            this.lblResultados.AutoSize = true;
            this.lblResultados.Location = new System.Drawing.Point(21, 639);
            this.lblResultados.Name = "lblResultados";
            this.lblResultados.Size = new System.Drawing.Size(107, 16);
            this.lblResultados.TabIndex = 11;
            this.lblResultados.Text = "Total: 0 reservas";
            // 
            // btnCerrar
            // 
            this.btnCerrar.Location = new System.Drawing.Point(459, 634);
            this.btnCerrar.Name = "btnCerrar";
            this.btnCerrar.Size = new System.Drawing.Size(106, 27);
            this.btnCerrar.TabIndex = 11;
            this.btnCerrar.Text = "Cerrar";
            this.btnCerrar.UseVisualStyleBackColor = true;
            // 
            // FormConsultaReserva
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(593, 675);
            this.Controls.Add(this.btnCerrar);
            this.Controls.Add(this.lblResultados);
            this.Controls.Add(this.dgvReservas);
            this.Controls.Add(this.groupBox1);
            this.Name = "FormConsultaReserva";
            this.Text = "FormConsultaReserva";
            this.Load += new System.EventHandler(this.FormConsultaReserva_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvReservas)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnBuscarTodas;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker dtpFechaBusqueda;
        private System.Windows.Forms.Button btnBuscarPorFecha;
        private System.Windows.Forms.Button btnBuscarPorProfesor;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtProfesorBusqueda;
        private System.Windows.Forms.TextBox txtAsignaturaBusqueda;
        private System.Windows.Forms.Button btnBuscarPorAsignatura;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DataGridView dgvReservas;
        private System.Windows.Forms.Label lblResultados;
        private System.Windows.Forms.Button btnCerrar;
    }
}