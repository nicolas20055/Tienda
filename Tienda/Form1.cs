using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Tienda
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            Configuracion.CConexion objetoConexion = new Configuracion.CConexion();
            objetoConexion.EstablecerConexion();
        }

        private void reportesToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void venderToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Formularios.FormVentas objetoformVentas = new Formularios.FormVentas();
            objetoformVentas.Show();
        }

        private void clientesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Formularios.FormClientes objetoformVentas = new Formularios.FormClientes();
            objetoformVentas.Show();
        }

        private void productosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Formularios.FormProductos objetoformVentas = new Formularios.FormProductos();
            objetoformVentas.Show();

        }

        private void buscarComprobanteToolStripMenuItem_Click(object sender, EventArgs e)
        {

            Formularios.FormBuscarComprobante objetoformVentas = new Formularios.FormBuscarComprobante();
            objetoformVentas.Show();
        }

        private void consultaFEchaToolStripMenuItem_Click(object sender, EventArgs e)
        {

            Formularios.FormReportesFechas objetoformVentas = new Formularios.FormReportesFechas();
            objetoformVentas.Show();
        }

        private void administracionToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
    }
}
