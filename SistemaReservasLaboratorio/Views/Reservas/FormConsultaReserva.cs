using SistemaReservasLaboratorio.Controllers;
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
    public partial class FormConsultaReserva : Form
    {
        private ControladorReserva controlador;
        public FormConsultaReserva()
        {
            InitializeComponent();
            controlador = new ControladorReserva();
            ConfigurarDataGridView();
        }
        private void ConfigurarDataGridView()
        {
            dgvReservas.AutoGenerateColumns = false;
            dgvReservas.Columns.Clear();

            dgvReservas.Columns.Add(new DataGridViewTextBoxColumn
            {
                HeaderText = "ID",
                DataPropertyName = "IdReserva",
                Width = 50
            });

            dgvReservas.Columns.Add(new DataGridViewTextBoxColumn
            {
                HeaderText = "Tipo",
                DataPropertyName = "TipoReserva",
                Width = 100
            });

            dgvReservas.Columns.Add(new DataGridViewTextBoxColumn
            {
                HeaderText = "Asignatura",
                DataPropertyName = "Asignatura",
                Width = 150
            });

            dgvReservas.Columns.Add(new DataGridViewTextBoxColumn
            {
                HeaderText = "Profesor",
                DataPropertyName = "Profesor",
                Width = 150
            });

            dgvReservas.Columns.Add(new DataGridViewTextBoxColumn
            {
                HeaderText = "Fecha Inicio",
                DataPropertyName = "FechaHoraInicio",
                Width = 150
            });

            dgvReservas.Columns.Add(new DataGridViewTextBoxColumn
            {
                HeaderText = "Fecha Fin",
                DataPropertyName = "FechaHoraFin",
                Width = 150
            });

            dgvReservas.Columns.Add(new DataGridViewTextBoxColumn
            {
                HeaderText = "Carrera",
                DataPropertyName = "Carrera",
                Width = 120
            });
        }
        private void btnBuscarTodas_Click(object sender, EventArgs e)
        {
            try
            {
                var reservas = controlador.ObtenerTodasLasReservas();
                dgvReservas.DataSource = reservas;
                lblResultados.Text = $"Total: {reservas.Count} reservas";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar reservas: {ex.Message}",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void btnBuscarPorFecha_Click(object sender, EventArgs e)
        {
            try
            {
                var reservas = controlador.BuscarReservasPorFecha(dtpFechaBusqueda.Value);
                dgvReservas.DataSource = reservas;
                lblResultados.Text = $"Encontradas: {reservas.Count} reservas";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al buscar reservas: {ex.Message}",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void btnBuscarPorProfesor_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(txtProfesorBusqueda.Text))
                {
                    MessageBox.Show("Ingrese el nombre del profesor", "Validación",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                var reservas = controlador.BuscarReservasPorProfesor(txtProfesorBusqueda.Text);
                dgvReservas.DataSource = reservas;
                lblResultados.Text = $"Encontradas: {reservas.Count} reservas";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al buscar reservas: {ex.Message}",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void btnBuscarPorAsignatura_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(txtAsignaturaBusqueda.Text))
                {
                    MessageBox.Show("Ingrese el nombre de la asignatura", "Validación",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                var reservas = controlador.BuscarReservasPorAsignatura(txtAsignaturaBusqueda.Text);
                dgvReservas.DataSource = reservas;
                lblResultados.Text = $"Encontradas: {reservas.Count} reservas";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al buscar reservas: {ex.Message}",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FormConsultaReserva_Load(object sender, EventArgs e)
        {

        }
    }
}
