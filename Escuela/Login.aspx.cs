using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using System.Data;
using Escuela_BLL;

namespace Escuela {
    public partial class Login : System.Web.UI.Page {

        #region Eventos
        protected void Page_Load(object sender, EventArgs e) {

        }

        protected void btnIngresar_Click(object sender, EventArgs e) {
            if (usuarioValido()) Response.Redirect("~/Facultad/facultad_s.aspx");
            else Page.ClientScript.RegisterStartupScript(this.GetType(), "Sesión", "alert('Usuario y / o contraseña inválidos.')", true);
        }
        #endregion

        #region Métodos
        public bool usuarioValido() {
            bool acceso = false;
            UsuarioBLL userBLL = new UsuarioBLL();
            DataTable dtUsuario = userBLL.consultarUsuario(txtUsuario.Text, txtContraseña.Text);

            if(dtUsuario.Rows.Count > 0) {
                Session["Usuario"] = dtUsuario;
                acceso = true;
            }
            return acceso;

        }
        #endregion
    }
}