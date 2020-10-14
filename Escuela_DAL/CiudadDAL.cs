using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Escuela_DAL {
    public class CiudadDAL {
        public DataTable cargarCiudadesPorEstado(int estado) {
            //Crear conexión a la base de Datos
            SqlConnection connection = new SqlConnection();
            connection.ConnectionString = @"Server=DESKTOP-3PSO6KS\SQLEXPRESS;Database=Escuela;Trusted_connection=true";

            //Crear comando SQL
            SqlCommand command = new SqlCommand();
            command.CommandType = CommandType.StoredProcedure;
            command.CommandText = "sp_cargarCiudadesPorEstado";
            command.Connection = connection;

            command.Parameters.AddWithValue("@pEstado", estado);

            //Adaptador de datos
            SqlDataAdapter adapter = new SqlDataAdapter();
            DataTable dtCiudades = new DataTable();

            //Conexión abierta
            connection.Open();

            adapter.SelectCommand = command;
            adapter.Fill(dtCiudades);

            connection.Close();

            return dtCiudades;

        }
    }
}
