using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Tienda.Formularios
{
    public partial class FormClientes : Form
    {
        private object txtApPaterno;

        public FormClientes()
        {
            InitializeComponent();
            Controlador.ControladorCliente objetoControladorCliente = new Controlador.ControladorCliente();
            objetoControladorCliente.MostrarClientes(dgvClientes);

            txtid.ReadOnly = true;

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void FormClientes_Load(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            Controlador.ControladorCliente objetoCliente = new Controlador.ControladorCliente();
            objetoCliente.AgregarCliente(txtNombre,TxtApellido1,txtApellido2); 
            objetoCliente.MostrarClientes(dgvClientes);
        }

        private void dgvClientes_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            Controlador.ControladorCliente objetoCliente = new Controlador.ControladorCliente();
            objetoCliente.seleccionar(dgvClientes, txtid, txtNombre, TxtApellido1, txtApellido2);
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            Controlador.ControladorCliente objetoCliente = new Controlador.ControladorCliente();
            objetoCliente.ModificarCliente(txtid,txtNombre, TxtApellido1, txtApellido2);
            objetoCliente.MostrarClientes(dgvClientes);

        }
    }

