using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Drawing.Text;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PruebaTecnicaProductos.Datos
{
    public class DaoProductos
    {

        public string conexion_string = "Server = 192.168.1.115; Database=Compania;User Id = ITdemetech; Password=ITdemetech2019!;";

        public SqlConnection GetConnection()
        {
            SqlConnection conexion_connection = new SqlConnection(conexion_string);
            return conexion_connection;
        }
        public DataTable listarProductos()
        {
            using (SqlConnection connection = GetConnection())
            {
                connection.Open();
                SqlCommand command = new SqlCommand("sp_listar_productos", connection);
                command.CommandType = CommandType.StoredProcedure; 

                DataTable tabla = new DataTable();

                using (SqlDataAdapter adapater = new SqlDataAdapter(command))
                {
                   adapater.Fill(tabla);
                }

                return tabla;

            }
        }

        public bool crearProducto(string Nombre, string Descripcion, decimal Precio, int Cantidad)
        {
            bool creado = false;
            try
            {
                using (SqlConnection connection = GetConnection())
                {
                    connection.Open();
                    SqlCommand command = new SqlCommand("guardar_producto", connection);
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.Add("@Nombre", Nombre);
                    command.Parameters.Add("@Descripcion", Descripcion);
                    command.Parameters.Add("@Precio", Precio);
                    command.Parameters.Add("@Cantidad", Cantidad); 
                    
                    int rowsAffected = command.ExecuteNonQuery();

                    if (rowsAffected > 0)
                    {
                        creado = true;
                         return creado;
                    }


                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }

            return creado;
        }

        public bool editar(int Id, string Nombre, string Descripcion, decimal Precio, int Cantidad)
        {
            bool editado = false;
            try
            {
                using (SqlConnection connection = GetConnection())
                {
                    connection.Open();
                    SqlCommand command = new SqlCommand("editar_producto", connection);
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.Add("@Id", Id);
                    command.Parameters.Add("@Nombre", Nombre);
                    command.Parameters.Add("@Descripcion", Descripcion);
                    command.Parameters.Add("@Precio", Precio);
                    command.Parameters.Add("@Cantidad", Cantidad);

                    int rowsAffected = command.ExecuteNonQuery();

                    if (rowsAffected > 0)
                    {
                        editado = true;
                        return editado;
                    }


                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }

            return editado;
        }

        public bool eliminar(int Id) { 
            bool eliminado = false;
            try
            {
                using (SqlConnection connection = GetConnection())
                {
                    connection.Open();
                    SqlCommand command = new SqlCommand("sp_eliminar_producto", connection);
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.Add("@Id", Id);
                    

                    int rowsAffected = command.ExecuteNonQuery();

                    if (rowsAffected > 0)
                    {
                        eliminado = true;
                        return eliminado;
                    }


                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());

            }
            return eliminado;

        }

    }
}
