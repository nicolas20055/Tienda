using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace Tienda.Controlador
{
    public class ControladorCliente
    {
        public void MostrarClientes(DataGridView tablaTotalClientes) {

            Configuracion.CConexion objetoConexion = new Configuracion.CConexion();
            Modelos.Cliente objetoCliente = new Modelos.Cliente();

            DataTable Modelo = new DataTable();

            Modelo.Columns.Add("id", typeof(int));
            Modelo.Columns.Add("Nombre", typeof(String));
            Modelo.Columns.Add("ap_paterno", typeof(String));
            Modelo.Columns.Add("ap_materno", typeof(String));
            
            tablaTotalClientes.DataSource = Modelo;
            String sql = "select ID_cliente,nombre,ap_paterno,ap_materno from cliente;";

            try
            {
                MySqlConnection conexion = objetoConexion.EstablecerConexion();
                MySqlCommand comando = new MySqlCommand(sql, conexion);
                MySqlDataAdapter adapter = new MySqlDataAdapter(comando);
                DataSet ds = new DataSet();
                adapter.Fill(ds);

                DataTable dt = ds.Tables[0];

                foreach (DataRow row in dt.Rows)
                {
                    objetoCliente.Id_cliente=Convert.ToInt32(row["ID_cliente"]);
                    objetoCliente.Nombre = row ["nombre"].ToString();
                    objetoCliente.Ap_paterno = row["ap_paterno"].ToString();
                    objetoCliente.Ap_materno = row["ap_materno"].ToString();


                    Modelo.Rows.Add(objetoCliente.Id_cliente, objetoCliente.Nombre, objetoCliente.Ap_paterno, objetoCliente.Ap_materno);

                }
                tablaTotalClientes.DataSource = Modelo;
            }
            catch (Exception e)
            {
                MessageBox.Show("Error al mostrar los datos"+ e.ToString());
            }
            finally
            {
                objetoConexion.CerrarConexion();
            }

        }
    
        public void AgregarCliente(TextBox nombre,TextBox ap_paterno,TextBox ap_materno){


            Configuracion.CConexion objetoConexion = new Configuracion.CConexion();
            Modelos.Cliente objetoCliente = new Modelos.Cliente();
            String consulta = "insert into  cliente(nombre,ap_paterno,ap_materno)values (@nombre,@ap_paterno,@ap_materno)";

            try
            {
                objetoCliente.Nombre = nombre.Text;
                objetoCliente.Ap_paterno = ap_paterno.Text;
                objetoCliente.Ap_materno = ap_materno.Text;

                MySqlConnection conexion =  objetoConexion.EstablecerConexion();

                MySqlCommand comando = new MySqlCommand(consulta, conexion);

                comando.Parameters.AddWithValue("@nombre", objetoCliente.Nombre);
                comando.Parameters.AddWithValue("@ap_paterno", objetoCliente.Ap_paterno);
                comando.Parameters.AddWithValue("@ap_materno", objetoCliente.Ap_materno);

                comando.ExecuteNonQuery();
                MessageBox.Show("Registro guardado correctamente");
            }
            catch (Exception e)
            {
                MessageBox.Show("Error al guardar el registro" + e.ToString());
            }
            finally
            {
                objetoConexion.CerrarConexion();
            }
        }

        public void seleccionar(DataGridView TotalClientes, TextBox id, TextBox nombre, TextBox ap_paterno, TextBox ap_materno)
        {
            int fila = TotalClientes.CurrentRow.Index;

            try
            {
                if(fila >=0)
                {
                    id.Text = TotalClientes.Rows[fila].Cells[0].Value.ToString();
                    nombre.Text = TotalClientes.Rows[fila].Cells[1].Value.ToString();
                    ap_paterno.Text = TotalClientes.Rows[fila].Cells[2].Value.ToString();
                    ap_materno.Text = TotalClientes.Rows[fila].Cells[3].Value.ToString();

                }
            }
            catch (Exception e)
            {
                MessageBox.Show("Error al seleccionar el registro" + e.ToString());
            }
        }

        public void ModificarCliente(TextBox id, TextBox nombre, TextBox ap_paterno, TextBox ap_materno)
        {
            Configuracion.CConexion objetoConexion = new Configuracion.CConexion();
            Modelos.Cliente objetoCliente = new Modelos.Cliente();

            string consulta = "update cliente  set cliente.nombre=@nombres, cliente.ap_paterno=@ap_paterno,cliente.ap_materno=@ap_materno where cliente.ID_cliente = @id;";

            try
            {
                objetoCliente.Id_cliente = int.Parse(id.Text);
                objetoCliente.Nombre = nombre.Text;
                objetoCliente.Ap_paterno = ap_paterno.Text;
                objetoCliente.Ap_materno = ap_materno.Text;

                MySqlConnection conexion = objetoConexion.EstablecerConexion();


                MySqlCommand comando = new MySqlCommand(consulta, conexion);

                comando.Parameters.AddWithValue("@id", objetoCliente.Id_cliente);
                comando.Parameters.AddWithValue("@nombres", objetoCliente.Nombre);
                comando.Parameters.AddWithValue("@ap_paterno", objetoCliente.Ap_paterno);   
                comando.Parameters.AddWithValue("@ap_materno", objetoCliente.Ap_materno);
                
                comando.ExecuteNonQuery();
                MessageBox.Show("Registro modificado correctamente");
            }

            catch (Exception e)
            {
                MessageBox.Show("Error al modificar el registro" + e.ToString());
            }
            finally
            {
                objetoConexion.CerrarConexion();
            }
        }
     
    }
}
