using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tienda.Modelos
{
    public class Cliente
    {
        int ID_cliente;
        String nombre;
        String ap_paterno;
        String ap_materno;

        public int Id_cliente { get => ID_cliente; set => ID_cliente = value; }
        public string Nombre { get => nombre; set => nombre = value; }
        public string Ap_paterno { get => ap_paterno; set => ap_paterno = value; }
        public string Ap_materno { get => ap_materno; set => ap_materno = value; }
        public DataRow IdCliente { get; internal set; }
    }
}
