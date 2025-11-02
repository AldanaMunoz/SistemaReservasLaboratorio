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
    public partial class FormIntegrantes : Form
    {
        public FormIntegrantes()
        {
            InitializeComponent();
            MostrarIntegrantes();
        }
        private void MostrarIntegrantes()
        {
            lblInfo.Text = @"
                INTEGRANTES DEL DESARROLLO

                Apellido y Nombre: Muñoz, Aldana
                Email: aldanabelen.munoz@alumnos.uai.edu.ar

                Apellido y Nombre: Turri, Franco
                Email: @alumnos.uai.edu.ar

                ---
                Proyecto: Sistema de Reservas de Laboratorio
                Materia: Desarrollo y Arquitectura de Software
                Año: 2025
                            ";
        }
        private void FormIntegrantes_Load(object sender, EventArgs e)
        {

        }
    }
}
