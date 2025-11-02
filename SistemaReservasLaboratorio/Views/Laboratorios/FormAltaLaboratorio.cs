using SistemaReservasLaboratorio.Controllers;
using SistemaReservasLaboratorio.Exceptions;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SistemaReservasLaboratorio.Views.Laboratorios
{
    public partial class FormAltaLaboratorio : Form
    {
        private ControladorLaboratorio controlador;
        public FormAltaLaboratorio()
        {
            InitializeComponent();
            controlador = new ControladorLaboratorio();
        }
        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                if (!ValidarCampos())
                    return;

                int numeroAsignado = (int)nudNumeroAsignado.Value;
                string ubicacionPiso = txtUbicacionPiso.Text.Trim();
                int capacidadPuestos = (int)nudCapacidadPuestos.Value;

                controlador.AgregarLaboratorio(numeroAsignado, ubicacionPiso, capacidadPuestos);

                MessageBox.Show("Laboratorio guardado exitosamente", "Éxito",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);

                LimpiarCampos();
            }
            catch (LaboratorioException ex)
            {
                MessageBox.Show(ex.Message, "Error de Validación",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al guardar laboratorio: {ex.Message}",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private bool ValidarCampos()
        {
            if (nudNumeroAsignado.Value <= 0)
            {
                MessageBox.Show("El número asignado debe ser mayor a cero", "Validación",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                nudNumeroAsignado.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtUbicacionPiso.Text))
            {
                MessageBox.Show("Debe ingresar la ubicación/piso", "Validación",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtUbicacionPiso.Focus();
                return false;
            }

            if (nudCapacidadPuestos.Value <= 0)
            {
                MessageBox.Show("La capacidad debe ser mayor a cero", "Validación",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                nudCapacidadPuestos.Focus();
                return false;
            }

            return true;
        }
        private void LimpiarCampos()
        {
            nudNumeroAsignado.Value = 1;
            txtUbicacionPiso.Clear();
            nudCapacidadPuestos.Value = 1;
        }
        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void FormAltaLaboratorio_Load(object sender, EventArgs e)
        {

        }
    }
}
