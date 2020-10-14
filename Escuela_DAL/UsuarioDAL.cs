using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data;
using System.Data.SqlClient;

namespace Escuela_DAL {
    public class UsuarioDAL {
        public DataTable consultarUsuario(string nombre, string contraseña) {
            //Crear conexión a la base de Datos
            SqlConnection connection = new SqlConnection();
            connection.ConnectionString = @"Server=DESKTOP-3PSO6KS\SQLEXPRESS;Database=Escuela;Trusted_connection=true";

            //Crear comando SQL
            SqlCommand command = new SqlCommand();
            command.CommandType = CommandType.StoredProcedure;
            command.CommandText = "sp_consultarUsuario";
            command.Connection = connection;

            command.Parameters.AddWithValue("pNombre", nombre);
            command.Parameters.AddWithValue("pContraseña", contraseña);

            //Adaptador de datos
            SqlDataAdapter adapter = new SqlDataAdapter();
            DataTable dtUsuario = new DataTable();

            //Conexión abierta
            connection.Open();

            adapter.SelectCommand = command;
            adapter.Fill(dtUsuario);

            connection.Close();

            return dtUsuario;
        }
    }
}
