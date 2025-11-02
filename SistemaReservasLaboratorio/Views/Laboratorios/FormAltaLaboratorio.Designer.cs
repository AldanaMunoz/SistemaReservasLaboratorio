namespace SistemaReservasLaboratorio.Views.Laboratorios
{
    partial class FormAltaLaboratorio
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
            this.nudNumeroAsignado = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.txtUbicacionPiso = new System.Windows.Forms.TextBox();
            this.nudCapacidadPuestos = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.btnGuardar = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.nudNumeroAsignado)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudCapacidadPuestos)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(69, 54);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(119, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "Número Asignado:";
            // 
            // nudNumeroAsignado
            // 
            this.nudNumeroAsignado.Location = new System.Drawing.Point(287, 52);
            this.nudNumeroAsignado.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudNumeroAsignado.Name = "nudNumeroAsignado";
            this.nudNumeroAsignado.Size = new System.Drawing.Size(120, 22);
            this.nudNumeroAsignado.TabIndex = 1;
            this.nudNumeroAsignado.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(69, 106);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(102, 16);
            this.label2.TabIndex = 2;
            this.label2.Text = "Ubicación/Piso:";
            // 
            // txtUbicacionPiso
            // 
            this.txtUbicacionPiso.Location = new System.Drawing.Point(287, 100);
            this.txtUbicacionPiso.Name = "txtUbicacionPiso";
            this.txtUbicacionPiso.Size = new System.Drawing.Size(120, 22);
            this.txtUbicacionPiso.TabIndex = 3;
            // 
            // nudCapacidadPuestos
            // 
            this.nudCapacidadPuestos.Location = new System.Drawing.Point(287, 148);
            this.nudCapacidadPuestos.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudCapacidadPuestos.Name = "nudCapacidadPuestos";
            this.nudCapacidadPuestos.Size = new System.Drawing.Size(120, 22);
            this.nudCapacidadPuestos.TabIndex = 5;
            this.nudCapacidadPuestos.Value = new decimal(new int[] {
            2,
            0,
            0,
            0});
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(69, 150);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(148, 16);
            this.label3.TabIndex = 4;
            this.label3.Text = "Capacidad de Puestos:";
            // 
            // btnGuardar
            // 
            this.btnGuardar.Location = new System.Drawing.Point(101, 234);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(116, 39);
            this.btnGuardar.TabIndex = 6;
            this.btnGuardar.Text = "Guardar";
            this.btnGuardar.UseVisualStyleBackColor = true;
            // 
            // btnCancelar
            // 
            this.btnCancelar.Location = new System.Drawing.Point(278, 234);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(116, 39);
            this.btnCancelar.TabIndex = 7;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            // 
            // FormAltaLaboratorio
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnGuardar);
            this.Controls.Add(this.nudCapacidadPuestos);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtUbicacionPiso);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.nudNumeroAsignado);
            this.Controls.Add(this.label1);
            this.Name = "FormAltaLaboratorio";
            this.Text = "FormAltaLaboratorio";
            this.Load += new System.EventHandler(this.FormAltaLaboratorio_Load);
            ((System.ComponentModel.ISupportInitialize)(this.nudNumeroAsignado)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudCapacidadPuestos)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown nudNumeroAsignado;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtUbicacionPiso;
        private System.Windows.Forms.NumericUpDown nudCapacidadPuestos;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnGuardar;
        private System.Windows.Forms.Button btnCancelar;
    }
}