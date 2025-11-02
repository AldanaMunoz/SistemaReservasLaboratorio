using SistemaReservasLaboratorio.Views.Laboratorios;
using SistemaReservasLaboratorio.Views.Reservas;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SistemaReservasLaboratorio.Views
{
    public partial class FormPrincipal : Form
    {
        public FormPrincipal()
        {
            InitializeComponent();
            ConfigurarMenu();
        }

        private void ConfigurarMenu()
        {
            this.Text = "Sistema de Reservas de Laboratorio";
            this.WindowState = FormWindowState.Maximized;
        }

        private void altaReservaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                FormAltaReserva formAlta = new FormAltaReserva();
                formAlta.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al abrir formulario: {ex.Message}",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void modificacionReservaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                FormModificarReserva formModificar = new FormModificarReserva();
                formModificar.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al abrir formulario: {ex.Message}",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void bajaReservaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                FormBajaReserva formBaja = new FormBajaReserva();
                formBaja.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al abrir formulario: {ex.Message}",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void consultaReservasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                FormConsultaReserva formConsulta = new FormConsultaReserva();
                formConsulta.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al abrir formulario: {ex.Message}",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        //Gestión de Laboratorios
        private void altaLaboratorioToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                FormAltaLaboratorio formAlta = new FormAltaLaboratorio();
                formAlta.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al abrir formulario: {ex.Message}",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void modificacionLaboratorioToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                FormModificarLaboratorio formModificar = new FormModificarLaboratorio();
                formModificar.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al abrir formulario: {ex.Message}",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void bajaLaboratorioToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                FormBajaLaboratorio formBaja = new FormBajaLaboratorio();
                formBaja.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al abrir formulario: {ex.Message}",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void consultaLaboratoriosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                FormConsultaLaboratorio formConsulta = new FormConsultaLaboratorio();
                formConsulta.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al abrir formulario: {ex.Message}",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void generacionReportesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show(
                "Módulo de reportes en desarrollo.\n\n" +
                "Próximamente se implementarán diversos reportes:\n" +
                "- Reporte de reservas por período\n" +
                "- Estadísticas de uso de laboratorios\n" +
                "- Reportes por profesor/asignatura",
                "Información",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);
        }
        private void integrantesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                FormIntegrantes formIntegrantes = new FormIntegrantes();
                formIntegrantes.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al abrir formulario: {ex.Message}",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void salirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SalirAplicacion();
        }

        private void FormPrincipal_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                DialogResult resultado = MessageBox.Show(
                    "¿Está seguro que desea salir de la aplicación?",
                    "Confirmar salida",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);

                if (resultado == DialogResult.No)
                {
                    e.Cancel = true;
                }
            }
        }
        private void SalirAplicacion()
        {
            DialogResult resultado = MessageBox.Show(
                "¿Está seguro que desea salir de la aplicación?",
                "Confirmar salida",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (resultado == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void FormPrincipal_Load(object sender, EventArgs e)
        {

        }
    }
}
