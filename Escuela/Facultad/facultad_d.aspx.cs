using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Escuela_BLL;
using Escuela_DAL;

namespace Escuela.Facultad {
    public partial class facultad_d : TemaEscuela, IAcceso {
        protected void Page_Load(object sender, EventArgs e) {
            if (!IsPostBack) {
                if (sesionIniciada()) {
                    cargarUniversidades();
                    cargarFacultad(int.Parse(Request.QueryString["pID"]));
                } else {
                    Response.Redirect("~/Login.aspx");
                }
            }
        }

        public void cargarFacultad(int id) {
            FacultadBLL facuBLL = new FacultadBLL();
            Escuela_DAL.Facultad facultad = new Escuela_DAL.Facultad();

            //DataTable dtFacultad = facultad.cargarFacultad(int.Parse(Request.QueryString["pID"]));
            facultad = facuBLL.cargarFacultad(id);

            lblID.Text = facultad.ID_Facultad.ToString();
            txtNombre.Text = facultad.nombre.ToString();
            txtCodigo.Text = facultad.codigo.ToString();
            txtFechaCreacion.Text = facultad.fechaCreacion.ToString().Substring(0, 10);
            ddlUniversidades.SelectedValue = facultad.universidad.ToString();
        }

        public void cargarUniversidades() {
            UniversidadBLL universidad = new UniversidadBLL();
            List<Universidad> listUniversidades = new List<Universidad>();
            listUniversidades = universidad.cargarUniversidades();

            ddlUniversidades.DataSource = listUniversidades;
            ddlUniversidades.DataTextField = "nombre";
            ddlUniversidades.DataValueField = "ID_Universidad";
            ddlUniversidades.DataBind();

            ddlUniversidades.Items.Insert(0, new ListItem("---- Seleccione Universidad ----", "0"));
        }

        public void eliminarFacultad() {
            FacultadBLL facultad = new FacultadBLL();

            int id = int.Parse(lblID.Text);

            facultad.eliminarFacultad(id);
            
        }

        protected void Button1_Click(object sender, EventArgs e) {
            eliminarFacultad();
            Page.ClientScript.RegisterStartupScript(this.GetType(), "Alta", "alert('Facultad eliminada exitosamente')", true);
        }
        public bool sesionIniciada() {
            if (Session["Usuario"] != null) return true;
            else return false;
        }
    }
}