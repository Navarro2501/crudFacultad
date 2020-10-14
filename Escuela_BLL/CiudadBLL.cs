using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Escuela_DAL;

namespace Escuela_BLL {
    public class CiudadBLL {
        public DataTable cargarCiudadesPorEstado(int estado) {
            CiudadDAL ciudad = new CiudadDAL();
            return ciudad.cargarCiudadesPorEstado(estado);
        }
    }
}
