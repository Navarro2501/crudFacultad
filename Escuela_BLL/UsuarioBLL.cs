using Escuela_DAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Escuela_BLL {
    public class UsuarioBLL {
        public DataTable consultarUsuario(string nombre, string contraseña) {
            UsuarioDAL usuario = new UsuarioDAL();
            return usuario.consultarUsuario(nombre, contraseña);
        }
    }
}
