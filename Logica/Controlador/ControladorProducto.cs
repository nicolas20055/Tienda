using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Windows.Forms;
//commit
namespace Tienda.Controlador
{
    internal class ControladorProducto
    {
        public void MostrarProductos(DataGridView tablaTotalProductos)
        {

            Configuracion.CConexion objetoConexion = new Configuracion.CConexion();
            Modelos.Producto objetoProducto = new Modelos.Producto();

            DataTable Modelo = new DataTable();

            Modelo.Columns.Add("id", typeof(int));
            Modelo.Columns.Add("NombreProducto", typeof(String));
            Modelo.Columns.Add("precio_producto", typeof(Double));
            Modelo.Columns.Add("stock", typeof(Double));

            tablaTotalProductos.DataSource = Modelo;
            String sql = "select ID_producto,nombre,precio_producto,stock from producto;";

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
                    objetoProducto.Id_producto = Convert.ToInt32(row["ID_producto"]);
                    objetoProducto.NombreProducto= row["nombre"].ToString();
                    objetoProducto.Precio_producto = Convert.ToDouble(row["precio_producto"].ToString());
                    objetoProducto.Stock = Convert.ToInt32(row["stock"].ToString());


                    Modelo.Rows.Add(objetoProducto.Id_producto, objetoProducto.NombreProducto, objetoProducto.Precio_producto, objetoProducto.Stock);

                }
                tablaTotalProductos.DataSource = Modelo;
            }
            catch (Exception e)
            {
                MessageBox.Show("Error al mostrar los datos" + e.ToString());
            }
            finally
            {
                objetoConexion.CerrarConexion();
            }


        }

        public void AgregarProductos(TextBox nombre, TextBox precio_producto, TextBox stock)
        {


            Configuracion.CConexion objetoConexion = new Configuracion.CConexion();
            Modelos.Producto objetoProducto = new Modelos.Producto();
            String consulta = "insert into  producto(nombre,precio_producto,stock)values (@nombre,@precio_Producto,@Stock);";

            try
            {
                objetoProducto.NombreProducto = nombre.Text;
                objetoProducto.Precio_producto = double.Parse(precio_producto.Text);
                objetoProducto.Stock = int.Parse(stock.Text);

                MySqlConnection conexion = objetoConexion.EstablecerConexion();

                MySqlCommand comando = new MySqlCommand(consulta, conexion);

                comando.Parameters.AddWithValue("@nombre", objetoProducto.NombreProducto);
                comando.Parameters.AddWithValue("@precio_producto", objetoProducto.Precio_producto);
                comando.Parameters.AddWithValue("@stock", objetoProducto.Stock);

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
        public void seleccionar(DataGridView TotalProductos, TextBox id, TextBox nombre, TextBox precio_producto , TextBox stock)
        {
            int fila = TotalProductos.CurrentRow.Index;

            try
            {
                if (fila >= 0)
                {
                    id.Text = TotalProductos.Rows[fila].Cells[0].Value.ToString();
                    nombre.Text = TotalProductos.Rows[fila].Cells[1].Value.ToString();
                    precio_producto.Text = TotalProductos.Rows[fila].Cells[2].Value.ToString();
                    stock.Text = TotalProductos.Rows[fila].Cells[3].Value.ToString();

                }
            }
            catch (Exception e)
            {
                MessageBox.Show("Error al seleccionar el registro" + e.ToString());
            }
        }

        public void ModificarProducto(TextBox id, TextBox nombre, TextBox precio_producto, TextBox stock)
        {
            Configuracion.CConexion objetoConexion = new Configuracion.CConexion();
            Modelos.Producto objetoProducto = new Modelos.Producto();

            string consulta = "update producto set producto.nombre=@nombre, producto.precio_producto=@precio_producto, producto.stock=@stock where producto.ID_producto = @id;";

            try
            {
                

                objetoProducto.Id_producto = int.Parse(id.Text);
                objetoProducto.NombreProducto = nombre.Text;
                objetoProducto.Precio_producto = double.Parse(precio_producto.Text);
                objetoProducto.Stock = int.Parse(stock.Text);


                MySqlConnection conexion = objetoConexion.EstablecerConexion();


                MySqlCommand comando = new MySqlCommand(consulta, conexion);

                comando.Parameters.AddWithValue("@id", objetoProducto.Id_producto);
                comando.Parameters.AddWithValue("@nombre", objetoProducto.NombreProducto);
                comando.Parameters.AddWithValue("@Precio_producto", objetoProducto.Precio_producto);
                comando.Parameters.AddWithValue("@Stock", objetoProducto.Stock);

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
        public void LimpiarCampos(TextBox id, TextBox nombre, TextBox ap_paterno, TextBox ap_materno)
        {
            id.Text = "";
            nombre.Text = "";
            ap_paterno.Text = "";
            ap_materno.Text = "";
        }

        public void EliminarProducto(TextBox id)
        {
            Configuracion.CConexion objetoConexion = new Configuracion.CConexion();
            Modelos.Producto objetoProducto = new Modelos.Producto();

            string consulta = "DELETE FROM producto WHERE ID_producto  =@id;";
            try
            {


                objetoProducto.Id_producto = int.Parse(id.Text);


                MySqlConnection conexion = objetoConexion.EstablecerConexion();


                MySqlCommand comando = new MySqlCommand(consulta, conexion);

                comando.Parameters.AddWithValue("@id", objetoProducto.Id_producto);


                comando.ExecuteNonQuery();
                MessageBox.Show("Se elimino correctamente");
            }

            catch (Exception e)
            {
                MessageBox.Show("Error al eliminar el registro" + e.ToString());
            }
            finally
            {
                objetoConexion.CerrarConexion();
            }
        }





    }
}
