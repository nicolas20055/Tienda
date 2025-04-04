using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace Tienda.Formularios
{
    public partial class FormProductos : Form
    {
        public FormProductos()
        {
            InitializeComponent();
            Controlador.ControladorProducto objetoProducto = new Controlador.ControladorProducto();
            objetoProducto.MostrarProductos(dgvProductos);
            txtid.ReadOnly = true;
        }
       

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            Controlador.ControladorProducto objetoProducto = new Controlador.ControladorProducto();
            objetoProducto.AgregarProductos(txtNombreP,txtStock,TxtPrecio);
            objetoProducto.MostrarProductos(dgvProductos);
        }

        private void dgvProductos_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            Controlador.ControladorProducto objetoProducto = new Controlador.ControladorProducto();
            objetoProducto.seleccionar(dgvProductos, txtid, txtNombreP, txtStock, TxtPrecio);
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            Controlador.ControladorProducto objetoProducto = new Controlador.ControladorProducto();
            objetoProducto.ModificarProducto(txtid,txtNombreP, txtStock, TxtPrecio);
            objetoProducto.MostrarProductos(dgvProductos);
        }

        private void Eliminar_Click(object sender, EventArgs e)
        {
            Controlador.ControladorProducto objetoProducto = new Controlador.ControladorProducto();
            objetoProducto.EliminarProducto(txtid);
            objetoProducto.MostrarProductos(dgvProductos);
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            Controlador.ControladorProducto objetoProducto = new Controlador.ControladorProducto();
            objetoProducto.LimpiarCampos(txtid, txtNombreP, txtStock, TxtPrecio);
        }
    }
}
