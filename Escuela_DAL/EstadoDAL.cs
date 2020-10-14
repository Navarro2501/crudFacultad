using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Escuela_DAL {
    public class EstadoDAL {
        public DataTable cargarEstados() {
            //Crear conexión a la base de Datos
            SqlConnection connection = new SqlConnection();
            connection.ConnectionString = @"Server=DESKTOP-3PSO6KS\SQLEXPRESS;Database=Escuela;Trusted_connection=true";

            //Crear comando SQL
            SqlCommand command = new SqlCommand();
            command.CommandType = CommandType.StoredProcedure;
            command.CommandText = "sp_cargarEstados";
            command.Connection = connection;

            //Adaptador de datos
            SqlDataAdapter adapter = new SqlDataAdapter();
            DataTable dtEstados = new DataTable();

            //Conexión abierta
            connection.Open();

            adapter.SelectCommand = command;
            adapter.Fill(dtEstados);

            connection.Close();

            return dtEstados;

        }
    }
}
