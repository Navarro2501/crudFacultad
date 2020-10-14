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

namespace Escuela.Alumnos {
    public partial class alumno_d : TemaEscuela, IAcceso {
        protected void Page_Load(object sender, EventArgs e) {
            if (!IsPostBack) {
                if (sesionIniciada()) {
                    int matricula = int.Parse(Request.QueryString["pMatricula"]);
                    cargarFacultades();
                    cargarAlumno(matricula);
                } else {
                    Response.Redirect("~/Login.aspx");
                }
            }
        }

        public void cargarAlumno(int matricula) {
            AlumnoBLL alumBLL = new AlumnoBLL();
            Alumno alumno = new Alumno();
            
            alumno = alumBLL.cargarAlumno(matricula);

            //La tabla dtAlumno sólo trae un registro, se accede al índice 0 y a su columna matrícula
            lblMatricula.Text = alumno.matricula.ToString();
            lblNombre.Text = alumno.nombre;
            lblFechaNacimiento.Text = alumno.fechaNacimiento.ToString().Substring(0, 10);
            lblSemestre.Text = alumno.semestre.ToString();
            ddlFacultad.SelectedValue = alumno.facultad.ToString();
        }

        //Se trae acá para cargar los datos en principio y así ser usados en el método de arriba.
        public void cargarFacultades() {
            FacultadBLL facuBLL = new FacultadBLL();
            List<Escuela_DAL.Facultad> listFacultades = new List<Escuela_DAL.Facultad>();

            listFacultades = facuBLL.cargarFacultades();

            //De dónde se va a llenar la tabla
            ddlFacultad.DataSource = listFacultades;
            //El dato que se va a renderizar
            ddlFacultad.DataTextField = "nombre";
            //El valor que tendrá ese dato
            ddlFacultad.DataValueField = "ID_Facultad";
            //Uso del dato
            ddlFacultad.DataBind();

            ddlFacultad.Items.Insert(0, new ListItem("---- Seleccione Facultad ----", "0"));
        }

        public void eliminarAlumno() {
            AlumnoBLL alumBLL = new AlumnoBLL();

            int matricula = int.Parse(lblMatricula.Text);

            alumBLL.eliminarAlumno(matricula);
        }

        protected void btnEliminar_Click(object sender, EventArgs e) {
            eliminarAlumno();
            Page.ClientScript.RegisterStartupScript(this.GetType(), "Alta", "alert('Alumno eliminado exitosamente')", true);
        }

        public bool sesionIniciada() {
            if (Session["Usuario"] != null) return true;
            else return false;
        }
    }
}