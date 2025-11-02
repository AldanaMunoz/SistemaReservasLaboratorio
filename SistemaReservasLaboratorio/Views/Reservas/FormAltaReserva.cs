using SistemaReservasLaboratorio.Controllers;
using SistemaReservasLaboratorio.Exceptions;
using SistemaReservasLaboratorio.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SistemaReservasLaboratorio.Views.Reservas
{
    public partial class FormAltaReserva : Form
    {
        private ControladorReserva controladorReserva;
        private ControladorLaboratorio controladorLaboratorio;
        public FormAltaReserva()
        {
            InitializeComponent();
            controladorReserva = new ControladorReserva();
            controladorLaboratorio = new ControladorLaboratorio();
            CargarLaboratorios();
        }

        private void CargarLaboratorios()
        {
            try
            {
                var laboratorios = controladorLaboratorio.ObtenerTodosLosLaboratorios();
                cboLaboratorio.DataSource = laboratorios;
                cboLaboratorio.DisplayMember = "NumeroAsignado";
                cboLaboratorio.ValueMember = "IdLaboratorio";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar laboratorios: {ex.Message}",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void rdbCuatrimestral_CheckedChanged(object sender, EventArgs e)
        {
            grpCuatrimestral.Enabled = rdbCuatrimestral.Checked;
            grpEventual.Enabled = !rdbCuatrimestral.Checked;
        }
        private void rdbEventual_CheckedChanged(object sender, EventArgs e)
        {
            grpCuatrimestral.Enabled = !rdbEventual.Checked;
            grpEventual.Enabled = rdbEventual.Checked;
        }
        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                if (!ValidarCampos())
                    return;

                if (rdbCuatrimestral.Checked)
                {
                    GuardarReservaCuatrimestral();
                }
                else
                {
                    GuardarReservaEventual();
                }

                MessageBox.Show("Reserva guardada exitosamente", "Éxito",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);

                LimpiarCampos();
            }
            catch (ReservaException ex)
            {
                MessageBox.Show(ex.Message, "Error de Validación",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al guardar reserva: {ex.Message}",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void GuardarReservaCuatrimestral()
        {
            DateTime inicio = dtpFechaInicioCuatri.Value.Date + dtpHoraInicioCuatri.Value.TimeOfDay;
            DateTime fin = dtpFechaFinCuatri.Value.Date + dtpHoraFinCuatri.Value.TimeOfDay;

            ReservaCuatrimestral.TipoPeriodicidad periodicidad =
                rdbSemanal.Checked ? ReservaCuatrimestral.TipoPeriodicidad.Semanal
                                   : ReservaCuatrimestral.TipoPeriodicidad.Quincenal;

            controladorReserva.AgregarReservaCuatrimestral(
                inicio,
                fin,
                periodicidad,
                txtCarrera.Text.Trim(),
                txtAsignatura.Text.Trim(),
                (int)nudAnio.Value,
                txtComision.Text.Trim(),
                txtProfesor.Text.Trim(),
                (int)cboLaboratorio.SelectedValue
            );
        }
        private void GuardarReservaEventual()
        {
            DateTime fechaInicio = dtpFechaInicioEventual.Value.Date + dtpHoraInicioEventual.Value.TimeOfDay;
            int cantidadSemanas = (int)nudSemanas.Value;

            controladorReserva.AgregarReservaEventual(
                fechaInicio,
                cantidadSemanas,
                txtCarrera.Text.Trim(),
                txtAsignatura.Text.Trim(),
                (int)nudAnio.Value,
                txtComision.Text.Trim(),
                txtProfesor.Text.Trim(),
                (int)cboLaboratorio.SelectedValue
            );
        }
        private bool ValidarCampos()
        {
            if (cboLaboratorio.SelectedIndex == -1)
            {
                MessageBox.Show("Debe seleccionar un laboratorio", "Validación",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtCarrera.Text))
            {
                MessageBox.Show("Debe ingresar la carrera", "Validación",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtCarrera.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtAsignatura.Text))
            {
                MessageBox.Show("Debe ingresar la asignatura", "Validación",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtAsignatura.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtComision.Text))
            {
                MessageBox.Show("Debe ingresar la comisión", "Validación",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtComision.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtProfesor.Text))
            {
                MessageBox.Show("Debe ingresar el profesor", "Validación",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtProfesor.Focus();
                return false;
            }

            if (!rdbCuatrimestral.Checked && !rdbEventual.Checked)
            {
                MessageBox.Show("Debe seleccionar el tipo de reserva", "Validación",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (rdbCuatrimestral.Checked)
            {
                if (!rdbSemanal.Checked && !rdbQuincenal.Checked)
                {
                    MessageBox.Show("Debe seleccionar la periodicidad", "Validación",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return false;
                }
            }

            return true;
        }

        private void LimpiarCampos()
        {
            txtCarrera.Clear();
            txtAsignatura.Clear();
            txtComision.Clear();
            txtProfesor.Clear();
            nudAnio.Value = 1;
            nudSemanas.Value = 1;
            rdbCuatrimestral.Checked = true;
            rdbSemanal.Checked = true;
            dtpFechaInicioCuatri.Value = DateTime.Now;
            dtpFechaFinCuatri.Value = DateTime.Now.AddMonths(4);
            dtpFechaInicioEventual.Value = DateTime.Now;
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void label11_Click(object sender, EventArgs e)
        {

        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {

        }
    }
}
