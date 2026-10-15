using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient; 

namespace PruebaTecnicaProductos.Datos
{
    public class Conexion
    {
        public string conexion_string = "Server = 192.168.1.115; Database=Compania;User Id = ITdemetech; Password=ITdemetech2019!;";

        public SqlConnection GetConnection()
        {
            SqlConnection conexion_connection = new SqlConnection(conexion_string);
            return conexion_connection;
        }
    }
}

    
