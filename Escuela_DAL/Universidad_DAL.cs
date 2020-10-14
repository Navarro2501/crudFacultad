using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Escuela_DAL {
    public class Universidad_DAL {

        EscuelaEntities modelo;

        public Universidad_DAL() {
            modelo = new EscuelaEntities();
        }

        public List<Universidad> cargarUniversidades() {
            var universidades = from mUniversidades in modelo.Universidad
                             select mUniversidades;

            return universidades.ToList();
        }
    }
}
