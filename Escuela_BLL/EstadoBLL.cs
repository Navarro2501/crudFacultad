using Escuela_DAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace Escuela_BLL {
    public class EstadoBLL {
        public DataTable cargarEstados() {
            EstadoDAL estados = new EstadoDAL();
            return estados.cargarEstados();
        }
    }
}
