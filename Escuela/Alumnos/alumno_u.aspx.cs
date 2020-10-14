using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using System.Data;
using System.Data.SqlClient;
using Escuela_BLL;
using Escuela_DAL;

namespace Escuela.Alumnos {
    public partial class alumno_u : TemaEscuela, IAcceso {

        #region Eventos
        protected void Page_Load(object sender, EventArgs e) {
            //Se cargan las facultades para poder actualizarlas
            if (!IsPostBack) {
                if (sesionIniciada()) {
                    //Obtiene el valor "pMatricula" del request
                    int matricula = int.Parse(Request.QueryString["pMatricula"]);
                    cargarFacultades();
                    cargarAlumno(matricula);
                } else {
                    Response.Redirect("~/Login.aspx");
                }
            }
        }

        protected void btnEditar_Click(object sender, EventArgs e) {
            modificarAlumno();
            Page.ClientScript.RegisterStartupScript(this.GetType(), "Alta", "alert('Alumno agregado exitosamente')", true);
        }

        protected void ddlEstado_SelectedIndexChanged(object sender, EventArgs e) {
            if (ddlEstado.SelectedIndex != 0) {
                ddlCiudad.Items.Clear();
                cargarCiudades();
            } else ddlCiudad.Items.Clear();
        }

        #endregion

        #region Métodos

        public void cargarAlumno(int matricula) {
            AlumnoBLL alumBLL = new AlumnoBLL();
            Alumno alumno = new Alumno();

            alumno = alumBLL.cargarAlumno(matricula);

            //La tabla dtAlumno sólo trae un registro, se accede al índice 0 y a su columna matrícula
            lblMatricula.Text = alumno.matricula.ToString();
            txtNombre.Text = alumno.nombre;
            txtFechaNacimiento.Text = alumno.fechaNacimiento.ToString().Substring(0, 10);
            txtSemestre.Text = alumno.semestre.ToString();
            ddlFacultad.SelectedValue = alumno.facultad.ToString();

            cargarEstados();
            ddlEstado.SelectedValue = alumno.Ciudad1.estado.ToString();

            cargarCiudades();
            ddlCiudad.SelectedValue = alumno.ciudad.ToString();

            cargarMaterias();
            List<MateriaAlumno> listMaterias = new List<MateriaAlumno>();
            //A la lista de materias se le asigna el valor la relación MateriaAlumno
            listMaterias = alumno.MateriaAlumno.ToList();

            foreach (MateriaAlumno materiaAlum in listMaterias)
                listBoxMaterias.Items.FindByValue(materiaAlum.materia.ToString()).Selected = true;
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

        public void cargarMaterias() {
            MateriaBLL materias = new MateriaBLL();
            List<Materia> listMaterias = new List<Materia>();

            listMaterias = materias.cargarMaterias();

            listBoxMaterias.DataSource = listMaterias;
            listBoxMaterias.DataTextField = "nombre";
            listBoxMaterias.DataValueField = "ID_Materia";
            listBoxMaterias.DataBind();
        }

        public void modificarAlumno() {
            AlumnoBLL alumBLL = new AlumnoBLL();
            Alumno alumno = new Alumno();
            
            alumno.matricula = int.Parse(lblMatricula.Text);
            alumno.nombre = txtNombre.Text;
            alumno.fechaNacimiento = Convert.ToDateTime(txtFechaNacimiento.Text);
            alumno.semestre = int.Parse(txtSemestre.Text);
            alumno.facultad = int.Parse(ddlFacultad.SelectedValue);
            alumno.ciudad = int.Parse(ddlCiudad.SelectedValue);

            MateriaAlumno materiaAlum;
            List<MateriaAlumno> listMaterias = new List<MateriaAlumno>();

            foreach (ListItem item in listBoxMaterias.Items) {
                if (item.Selected) {
                    materiaAlum = new MateriaAlumno();
                    materiaAlum.materia = int.Parse(item.Value);
                    materiaAlum.alumno = alumno.matricula;
                    listMaterias.Add(materiaAlum);
                }
            }

            alumBLL.modificarAlumno(alumno, listMaterias);

        }

        public void cargarEstados() {
            EstadoBLL estado = new EstadoBLL();

            DataTable dtEstados = estado.cargarEstados();

            ddlEstado.DataSource = dtEstados;
            ddlEstado.DataTextField = "nombre";
            ddlEstado.DataValueField = "ID_Estado";
            ddlEstado.DataBind();

            ddlEstado.Items.Insert(0, new ListItem("---- Seleccione estado ----", "0"));
        }

        public void cargarCiudades() {
            CiudadBLL ciudad = new CiudadBLL();
            DataTable dtCiudades = ciudad.cargarCiudadesPorEstado(int.Parse(ddlEstado.SelectedValue));

            ddlCiudad.DataSource = dtCiudades;
            ddlCiudad.DataTextField = "nombre";
            ddlCiudad.DataValueField = "ID_Ciudad";
            ddlCiudad.DataBind();

            ddlCiudad.Items.Insert(0, new ListItem("---- Seleccione ciudad ----", "0"));

        }

        public bool sesionIniciada() {
            if (Session["Usuario"] != null) return true;
            else return false;
        }

        #endregion

    }
}