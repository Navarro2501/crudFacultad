using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

//Necesarias para la conexión con la base de datos
using System.Data;
using System.Data.SqlClient;
using Escuela_BLL;


namespace Escuela.Alumnos {
    public partial class alumno_s : TemaEscuela, IAcceso {
        protected void Page_Load(object sender, EventArgs e) {
            //Si es la primera vez que se carga la página
            if (!IsPostBack) {
                if (sesionIniciada()) {
                    //El elemento grd_alumnos se llena con el método cargarAlumnos
                    grd_alumnos.DataSource = cargarAlumnos();
                    grd_alumnos.DataBind();
                } else {
                    Response.Redirect("~/Login.aspx");
                }
            }
        }

        public List<object> cargarAlumnos() {
            AlumnoBLL alumBLL = new AlumnoBLL();
            List<object> listAlumnos = new List<object>();

             listAlumnos= alumBLL.cargarAlumnos();

            return listAlumnos;
        }
        protected void grd_alumnos_RowCommand(object sender, GridViewCommandEventArgs e) {
            if (e.CommandName == "Editar") Response.Redirect("~/Alumnos/alumno_u.aspx?pMatricula=" + e.CommandArgument);
            else Response.Redirect("~/Alumnos/alumno_d.aspx?pMatricula=" + e.CommandArgument);
        }

        public bool sesionIniciada() {
            if (Session["Usuario"] != null) return true;
            else return false;
        }
    }
}