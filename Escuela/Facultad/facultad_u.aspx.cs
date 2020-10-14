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
    public partial class facultad_u : TemaEscuela, IAcceso {
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

        protected void Button1_Click(object sender, EventArgs e) {
            modificarFacultad();
            Page.ClientScript.RegisterStartupScript(this.GetType(), "Alta", "alert('Facultad modificada exitosamente')", true);
        }

        protected void ddlEstado_SelectedIndexChanged(object sender, EventArgs e) {
            if (ddlEstado.SelectedIndex != 0) {
                ddlCiudad.Items.Clear();
                cargarCiudades();
            } else ddlCiudad.Items.Clear();
        }

        #region Métodos
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

            cargarEstados();
            ddlEstado.SelectedValue = facultad.Ciudad1.estado.ToString();

            cargarCiudades();
            ddlCiudad.SelectedValue = facultad.ciudad.ToString();

            cargarMaterias();
            List<MateriaFacultad> listMaterias = new List<MateriaFacultad>();
            //A la lista de materias se le asigna el valor la relación MateriaAlumno
            listMaterias = facultad.MateriaFacultad.ToList();

            foreach (MateriaFacultad materiaFacu in listMaterias)
                listBoxMaterias.Items.FindByValue(materiaFacu.materia.ToString()).Selected = true;

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

        public void cargarMaterias() {
            MateriaBLL materias = new MateriaBLL();
            List<Materia> listMaterias = new List<Materia>();

            listMaterias = materias.cargarMaterias();

            listBoxMaterias.DataSource = listMaterias;
            listBoxMaterias.DataTextField = "nombre";
            listBoxMaterias.DataValueField = "ID_Materia";
            listBoxMaterias.DataBind();
        }

        public void modificarFacultad() {
            FacultadBLL facultadBLL = new FacultadBLL();
            Escuela_DAL.Facultad facultad = new Escuela_DAL.Facultad();

            facultad.ID_Facultad = int.Parse(lblID.Text);
            facultad.codigo = txtCodigo.Text;
            facultad.nombre = txtNombre.Text;
            facultad.fechaCreacion = Convert.ToDateTime(txtFechaCreacion.Text);
            facultad.universidad = int.Parse(ddlUniversidades.SelectedValue);
            facultad.ciudad = int.Parse(ddlCiudad.SelectedValue);

            MateriaFacultad materiaFacu;
            List<MateriaFacultad> listMaterias = new List<MateriaFacultad>();


            foreach (ListItem item in listBoxMaterias.Items) {
                if (item.Selected) {
                    materiaFacu = new MateriaFacultad();
                    materiaFacu.materia = int.Parse(item.Value);
                    materiaFacu.facultad = facultad.ID_Facultad;
                    listMaterias.Add(materiaFacu);
                }

            }

            facultadBLL.modificarFacultad(facultad, listMaterias);
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