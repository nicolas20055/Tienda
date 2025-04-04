using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tienda.Modelos
{
    internal class Producto
    {
        int ID_producto;
        String nombreProducto;
        Double precio_producto;
        int stock;

        public int Id_producto { get => ID_producto; set => ID_producto = value; }
        public string NombreProducto { get => nombreProducto; set => nombreProducto = value; }
        public double Precio_producto { get => precio_producto; set => precio_producto = value; }
        public int Stock { get => stock; set => stock = value; }
    }
}
