using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Escuela_BLL;

namespace Escuela.Facultad {
    public partial class facultad_s : TemaEscuela, IAcceso {
        protected void Page_Load(object sender, EventArgs e) {
            if (!IsPostBack)
                if (sesionIniciada()) {
                    //grd_facultad.DataSource = cargarFacultades();
                    //grd_facultad.DataBind();
                } else {
                    Response.Redirect("~/Login.aspx");
                }
        }

        //El método contiene un objeto de tipo Facultad BLL, que devuelve una tabla con la cual 
        //Se llenan los datos en una tabla dtFacultades y se devuelven a grd_facultad

        public List<Escuela_DAL.Facultad> cargarFacultades() {
            FacultadBLL facuBLL = new FacultadBLL();
            List<Escuela_DAL.Facultad> listFacultades = new List<Escuela_DAL.Facultad>();

            return listFacultades = facuBLL.cargarFacultades();
        }

        protected void grd_facultad_RowCommand(object sender, GridViewCommandEventArgs e) {
            if (e.CommandName == "Editar") Response.Redirect("~/Facultad/facultad_u.aspx?pID=" + e.CommandArgument);
            else Response.Redirect("~/Facultad/facultad_d.aspx?pID=" + e.CommandArgument);
        }

        public bool sesionIniciada() {
            if (Session["Usuario"] != null) return true;
            else return false;
        }
    }
}