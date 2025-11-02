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

namespace SistemaReservasLaboratorio.Views.Laboratorios
{
    public partial class FormConsultaLaboratorio : Form
    {
        private ControladorLaboratorio controlador;

        public FormConsultaLaboratorio()
        {
            InitializeComponent();
            controlador = new ControladorLaboratorio();
            ConfigurarDataGridView();
            CargarLaboratorios();
        }
        private void ConfigurarDataGridView()
        {
            dgvLaboratorios.AutoGenerateColumns = false;
            dgvLaboratorios.Columns.Clear();

            dgvLaboratorios.Columns.Add(new DataGridViewTextBoxColumn
            {
                HeaderText = "ID",
                DataPropertyName = "IdLaboratorio",
                Width = 50
            });

            dgvLaboratorios.Columns.Add(new DataGridViewTextBoxColumn
            {
                HeaderText = "Número Asignado",
                DataPropertyName = "NumeroAsignado",
                Width = 120
            });

            dgvLaboratorios.Columns.Add(new DataGridViewTextBoxColumn
            {
                HeaderText = "Ubicación/Piso",
                DataPropertyName = "UbicacionPiso",
                Width = 200
            });

            dgvLaboratorios.Columns.Add(new DataGridViewTextBoxColumn
            {
                HeaderText = "Capacidad",
                DataPropertyName = "CapacidadPuestos",
                Width = 100
            });
        }
        private void CargarLaboratorios()
        {
            try
            {
                var laboratorios = controlador.ObtenerTodosLosLaboratorios();
                dgvLaboratorios.DataSource = laboratorios;
                lblResultados.Text = $"Total: {laboratorios.Count} laboratorios";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar laboratorios: {ex.Message}",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void btnActualizar_Click(object sender, EventArgs e)
        {
            CargarLaboratorios();
        }
        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();

        }

        private void FormConsultaLaboratorio_Load(object sender, EventArgs e)
        {

        }
    }
}
