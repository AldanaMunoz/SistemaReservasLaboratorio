namespace SistemaReservasLaboratorio.Views.Reservas
{
    partial class FormAltaReserva
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.cboLaboratorio = new System.Windows.Forms.ComboBox();
            this.txtCarrera = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtAsignatura = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.nudAnio = new System.Windows.Forms.NumericUpDown();
            this.label5 = new System.Windows.Forms.Label();
            this.txtComision = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtProfesor = new System.Windows.Forms.TextBox();
            this.grpDatosComunes = new System.Windows.Forms.GroupBox();
            this.rdbCuatrimestral = new System.Windows.Forms.RadioButton();
            this.rdbEventual = new System.Windows.Forms.RadioButton();
            this.frpTipoReserva = new System.Windows.Forms.GroupBox();
            this.label7 = new System.Windows.Forms.Label();
            this.dtpFechaInicioCuatri = new System.Windows.Forms.DateTimePicker();
            this.dtpHoraInicioCuatri = new System.Windows.Forms.DateTimePicker();
            this.label8 = new System.Windows.Forms.Label();
            this.dtpHoraFinCuatri = new System.Windows.Forms.DateTimePicker();
            this.dtpFechaFinCuatri = new System.Windows.Forms.DateTimePicker();
            this.label9 = new System.Windows.Forms.Label();
            this.rdbSemanal = new System.Windows.Forms.RadioButton();
            this.rdbQuincenal = new System.Windows.Forms.RadioButton();
            this.grpCuatrimestral = new System.Windows.Forms.GroupBox();
            this.dtpHoraInicioEventual = new System.Windows.Forms.DateTimePicker();
            this.dtpFechaInicioEventual = new System.Windows.Forms.DateTimePicker();
            this.label10 = new System.Windows.Forms.Label();
            this.nudSemanas = new System.Windows.Forms.NumericUpDown();
            this.label11 = new System.Windows.Forms.Label();
            this.grpEventual = new System.Windows.Forms.GroupBox();
            this.btnGuardar = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.nudAnio)).BeginInit();
            this.grpDatosComunes.SuspendLayout();
            this.frpTipoReserva.SuspendLayout();
            this.grpCuatrimestral.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudSemanas)).BeginInit();
            this.grpEventual.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(38, 32);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(79, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "Laboratorio:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(38, 77);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(55, 16);
            this.label2.TabIndex = 1;
            this.label2.Text = "Carrera:";
            // 
            // cboLaboratorio
            // 
            this.cboLaboratorio.FormattingEnabled = true;
            this.cboLaboratorio.Location = new System.Drawing.Point(190, 29);
            this.cboLaboratorio.Name = "cboLaboratorio";
            this.cboLaboratorio.Size = new System.Drawing.Size(121, 24);
            this.cboLaboratorio.TabIndex = 2;
            // 
            // txtCarrera
            // 
            this.txtCarrera.Location = new System.Drawing.Point(190, 71);
            this.txtCarrera.Name = "txtCarrera";
            this.txtCarrera.Size = new System.Drawing.Size(121, 22);
            this.txtCarrera.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(38, 118);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(74, 16);
            this.label3.TabIndex = 4;
            this.label3.Text = "Asignatura:";
            // 
            // txtAsignatura
            // 
            this.txtAsignatura.Location = new System.Drawing.Point(190, 118);
            this.txtAsignatura.Name = "txtAsignatura";
            this.txtAsignatura.Size = new System.Drawing.Size(121, 22);
            this.txtAsignatura.TabIndex = 5;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(38, 162);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(34, 16);
            this.label4.TabIndex = 6;
            this.label4.Text = "Año:";
            // 
            // nudAnio
            // 
            this.nudAnio.Location = new System.Drawing.Point(190, 155);
            this.nudAnio.Maximum = new decimal(new int[] {
            6,
            0,
            0,
            0});
            this.nudAnio.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudAnio.Name = "nudAnio";
            this.nudAnio.Size = new System.Drawing.Size(120, 22);
            this.nudAnio.TabIndex = 7;
            this.nudAnio.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(38, 200);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(66, 16);
            this.label5.TabIndex = 8;
            this.label5.Text = "Comisión:";
            // 
            // txtComision
            // 
            this.txtComision.Location = new System.Drawing.Point(190, 200);
            this.txtComision.Name = "txtComision";
            this.txtComision.Size = new System.Drawing.Size(121, 22);
            this.txtComision.TabIndex = 9;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(38, 241);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(61, 16);
            this.label6.TabIndex = 10;
            this.label6.Text = "Profesor:";
            // 
            // txtProfesor
            // 
            this.txtProfesor.Location = new System.Drawing.Point(190, 241);
            this.txtProfesor.Name = "txtProfesor";
            this.txtProfesor.Size = new System.Drawing.Size(121, 22);
            this.txtProfesor.TabIndex = 11;
            // 
            // grpDatosComunes
            // 
            this.grpDatosComunes.Controls.Add(this.txtProfesor);
            this.grpDatosComunes.Controls.Add(this.label6);
            this.grpDatosComunes.Controls.Add(this.txtComision);
            this.grpDatosComunes.Controls.Add(this.label5);
            this.grpDatosComunes.Controls.Add(this.nudAnio);
            this.grpDatosComunes.Controls.Add(this.label4);
            this.grpDatosComunes.Controls.Add(this.txtAsignatura);
            this.grpDatosComunes.Controls.Add(this.label3);
            this.grpDatosComunes.Controls.Add(this.txtCarrera);
            this.grpDatosComunes.Controls.Add(this.cboLaboratorio);
            this.grpDatosComunes.Controls.Add(this.label2);
            this.grpDatosComunes.Controls.Add(this.label1);
            this.grpDatosComunes.Location = new System.Drawing.Point(23, 29);
            this.grpDatosComunes.Name = "grpDatosComunes";
            this.grpDatosComunes.Size = new System.Drawing.Size(364, 301);
            this.grpDatosComunes.TabIndex = 12;
            this.grpDatosComunes.TabStop = false;
            this.grpDatosComunes.Text = "Reserva";
            // 
            // rdbCuatrimestral
            // 
            this.rdbCuatrimestral.AutoSize = true;
            this.rdbCuatrimestral.Checked = true;
            this.rdbCuatrimestral.Location = new System.Drawing.Point(34, 28);
            this.rdbCuatrimestral.Name = "rdbCuatrimestral";
            this.rdbCuatrimestral.Size = new System.Drawing.Size(106, 20);
            this.rdbCuatrimestral.TabIndex = 13;
            this.rdbCuatrimestral.TabStop = true;
            this.rdbCuatrimestral.Text = "Cuatrimestral";
            this.rdbCuatrimestral.UseVisualStyleBackColor = true;
            // 
            // rdbEventual
            // 
            this.rdbEventual.AutoSize = true;
            this.rdbEventual.Location = new System.Drawing.Point(205, 28);
            this.rdbEventual.Name = "rdbEventual";
            this.rdbEventual.Size = new System.Drawing.Size(80, 20);
            this.rdbEventual.TabIndex = 14;
            this.rdbEventual.Text = "Eventual";
            this.rdbEventual.UseVisualStyleBackColor = true;
            // 
            // frpTipoReserva
            // 
            this.frpTipoReserva.Controls.Add(this.rdbEventual);
            this.frpTipoReserva.Controls.Add(this.rdbCuatrimestral);
            this.frpTipoReserva.Location = new System.Drawing.Point(23, 349);
            this.frpTipoReserva.Name = "frpTipoReserva";
            this.frpTipoReserva.Size = new System.Drawing.Size(364, 63);
            this.frpTipoReserva.TabIndex = 15;
            this.frpTipoReserva.TabStop = false;
            this.frpTipoReserva.Text = "Tipo de Reserva";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(23, 42);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(82, 16);
            this.label7.TabIndex = 12;
            this.label7.Text = "Fecha Inicio:";
            // 
            // dtpFechaInicioCuatri
            // 
            this.dtpFechaInicioCuatri.Location = new System.Drawing.Point(137, 36);
            this.dtpFechaInicioCuatri.Name = "dtpFechaInicioCuatri";
            this.dtpFechaInicioCuatri.Size = new System.Drawing.Size(200, 22);
            this.dtpFechaInicioCuatri.TabIndex = 16;
            // 
            // dtpHoraInicioCuatri
            // 
            this.dtpHoraInicioCuatri.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.dtpHoraInicioCuatri.Location = new System.Drawing.Point(137, 74);
            this.dtpHoraInicioCuatri.Name = "dtpHoraInicioCuatri";
            this.dtpHoraInicioCuatri.Size = new System.Drawing.Size(200, 22);
            this.dtpHoraInicioCuatri.TabIndex = 17;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(23, 117);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(69, 16);
            this.label8.TabIndex = 18;
            this.label8.Text = "Fecha Fin:";
            // 
            // dtpHoraFinCuatri
            // 
            this.dtpHoraFinCuatri.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.dtpHoraFinCuatri.Location = new System.Drawing.Point(137, 155);
            this.dtpHoraFinCuatri.Name = "dtpHoraFinCuatri";
            this.dtpHoraFinCuatri.Size = new System.Drawing.Size(200, 22);
            this.dtpHoraFinCuatri.TabIndex = 20;
            // 
            // dtpFechaFinCuatri
            // 
            this.dtpFechaFinCuatri.Location = new System.Drawing.Point(137, 117);
            this.dtpFechaFinCuatri.Name = "dtpFechaFinCuatri";
            this.dtpFechaFinCuatri.Size = new System.Drawing.Size(200, 22);
            this.dtpFechaFinCuatri.TabIndex = 19;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(23, 205);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(87, 16);
            this.label9.TabIndex = 21;
            this.label9.Text = "Periodicidad:";
            this.label9.Click += new System.EventHandler(this.label9_Click);
            // 
            // rdbSemanal
            // 
            this.rdbSemanal.AutoSize = true;
            this.rdbSemanal.Checked = true;
            this.rdbSemanal.Location = new System.Drawing.Point(137, 201);
            this.rdbSemanal.Name = "rdbSemanal";
            this.rdbSemanal.Size = new System.Drawing.Size(82, 20);
            this.rdbSemanal.TabIndex = 22;
            this.rdbSemanal.TabStop = true;
            this.rdbSemanal.Text = "Semanal";
            this.rdbSemanal.UseVisualStyleBackColor = true;
            // 
            // rdbQuincenal
            // 
            this.rdbQuincenal.AutoSize = true;
            this.rdbQuincenal.Location = new System.Drawing.Point(137, 240);
            this.rdbQuincenal.Name = "rdbQuincenal";
            this.rdbQuincenal.Size = new System.Drawing.Size(88, 20);
            this.rdbQuincenal.TabIndex = 15;
            this.rdbQuincenal.Text = "Quincenal";
            this.rdbQuincenal.UseVisualStyleBackColor = true;
            // 
            // grpCuatrimestral
            // 
            this.grpCuatrimestral.Controls.Add(this.rdbQuincenal);
            this.grpCuatrimestral.Controls.Add(this.rdbSemanal);
            this.grpCuatrimestral.Controls.Add(this.label9);
            this.grpCuatrimestral.Controls.Add(this.dtpHoraFinCuatri);
            this.grpCuatrimestral.Controls.Add(this.dtpFechaFinCuatri);
            this.grpCuatrimestral.Controls.Add(this.label8);
            this.grpCuatrimestral.Controls.Add(this.dtpHoraInicioCuatri);
            this.grpCuatrimestral.Controls.Add(this.dtpFechaInicioCuatri);
            this.grpCuatrimestral.Controls.Add(this.label7);
            this.grpCuatrimestral.Location = new System.Drawing.Point(23, 447);
            this.grpCuatrimestral.Name = "grpCuatrimestral";
            this.grpCuatrimestral.Size = new System.Drawing.Size(364, 298);
            this.grpCuatrimestral.TabIndex = 23;
            this.grpCuatrimestral.TabStop = false;
            this.grpCuatrimestral.Text = "Reserva Cuatrimestral";
            // 
            // dtpHoraInicioEventual
            // 
            this.dtpHoraInicioEventual.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.dtpHoraInicioEventual.Location = new System.Drawing.Point(137, 82);
            this.dtpHoraInicioEventual.Name = "dtpHoraInicioEventual";
            this.dtpHoraInicioEventual.Size = new System.Drawing.Size(200, 22);
            this.dtpHoraInicioEventual.TabIndex = 25;
            // 
            // dtpFechaInicioEventual
            // 
            this.dtpFechaInicioEventual.Location = new System.Drawing.Point(137, 44);
            this.dtpFechaInicioEventual.Name = "dtpFechaInicioEventual";
            this.dtpFechaInicioEventual.Size = new System.Drawing.Size(200, 22);
            this.dtpFechaInicioEventual.TabIndex = 24;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(23, 50);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(82, 16);
            this.label10.TabIndex = 23;
            this.label10.Text = "Fecha Inicio:";
            // 
            // nudSemanas
            // 
            this.nudSemanas.Location = new System.Drawing.Point(217, 133);
            this.nudSemanas.Maximum = new decimal(new int[] {
            52,
            0,
            0,
            0});
            this.nudSemanas.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudSemanas.Name = "nudSemanas";
            this.nudSemanas.Size = new System.Drawing.Size(120, 22);
            this.nudSemanas.TabIndex = 13;
            this.nudSemanas.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudSemanas.ValueChanged += new System.EventHandler(this.numericUpDown1_ValueChanged);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(23, 135);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(144, 16);
            this.label11.TabIndex = 12;
            this.label11.Text = "Cantidad de Semanas:";
            this.label11.Click += new System.EventHandler(this.label11_Click);
            // 
            // grpEventual
            // 
            this.grpEventual.Controls.Add(this.nudSemanas);
            this.grpEventual.Controls.Add(this.label11);
            this.grpEventual.Controls.Add(this.dtpHoraInicioEventual);
            this.grpEventual.Controls.Add(this.dtpFechaInicioEventual);
            this.grpEventual.Controls.Add(this.label10);
            this.grpEventual.Enabled = false;
            this.grpEventual.Location = new System.Drawing.Point(23, 770);
            this.grpEventual.Name = "grpEventual";
            this.grpEventual.Size = new System.Drawing.Size(363, 186);
            this.grpEventual.TabIndex = 26;
            this.grpEventual.TabStop = false;
            this.grpEventual.Text = "Reserva Eventual";
            // 
            // btnGuardar
            // 
            this.btnGuardar.Location = new System.Drawing.Point(41, 998);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(119, 33);
            this.btnGuardar.TabIndex = 27;
            this.btnGuardar.Text = "Guardar";
            this.btnGuardar.UseVisualStyleBackColor = true;
            // 
            // btnCancelar
            // 
            this.btnCancelar.Location = new System.Drawing.Point(228, 998);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(119, 33);
            this.btnCancelar.TabIndex = 28;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            // 
            // FormAltaReserva
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(532, 1105);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnGuardar);
            this.Controls.Add(this.grpEventual);
            this.Controls.Add(this.grpCuatrimestral);
            this.Controls.Add(this.frpTipoReserva);
            this.Controls.Add(this.grpDatosComunes);
            this.Name = "FormAltaReserva";
            this.Text = "FormAltaReserva";
            ((System.ComponentModel.ISupportInitialize)(this.nudAnio)).EndInit();
            this.grpDatosComunes.ResumeLayout(false);
            this.grpDatosComunes.PerformLayout();
            this.frpTipoReserva.ResumeLayout(false);
            this.frpTipoReserva.PerformLayout();
            this.grpCuatrimestral.ResumeLayout(false);
            this.grpCuatrimestral.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudSemanas)).EndInit();
            this.grpEventual.ResumeLayout(false);
            this.grpEventual.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cboLaboratorio;
        private System.Windows.Forms.TextBox txtCarrera;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtAsignatura;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.NumericUpDown nudAnio;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtComision;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtProfesor;
        private System.Windows.Forms.GroupBox grpDatosComunes;
        private System.Windows.Forms.RadioButton rdbCuatrimestral;
        private System.Windows.Forms.RadioButton rdbEventual;
        private System.Windows.Forms.GroupBox frpTipoReserva;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.DateTimePicker dtpFechaInicioCuatri;
        private System.Windows.Forms.DateTimePicker dtpHoraInicioCuatri;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.DateTimePicker dtpHoraFinCuatri;
        private System.Windows.Forms.DateTimePicker dtpFechaFinCuatri;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.RadioButton rdbSemanal;
        private System.Windows.Forms.RadioButton rdbQuincenal;
        private System.Windows.Forms.GroupBox grpCuatrimestral;
        private System.Windows.Forms.DateTimePicker dtpHoraInicioEventual;
        private System.Windows.Forms.DateTimePicker dtpFechaInicioEventual;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.NumericUpDown nudSemanas;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.GroupBox grpEventual;
        private System.Windows.Forms.Button btnGuardar;
        private System.Windows.Forms.Button btnCancelar;
    }
}