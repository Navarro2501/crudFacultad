using Escuela_BLL;
using Escuela_DAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Escuela.Facultad {
    public partial class facultad_i : TemaEscuela, IAcceso {
        #region Eventos
        protected void Page_Load(object sender, EventArgs e) {
            if (!IsPostBack) {
                if (sesionIniciada()) {
                    cargarUniversidades();
                    cargarEstados();
                    cargarMaterias();
                    cargarTabla();
                } else {
                    Response.Redirect("~/Login.aspx");
                }
            }
        }
        protected void Button1_Click(object sender, EventArgs e) {
            agregarFacultad();
            Page.ClientScript.RegisterStartupScript(this.GetType(), "Alta", "alert('Facultad agregada exitosamente')", true);
        }

        protected void ddlEstado_SelectedIndexChanged(object sender, EventArgs e) {
            if (ddlEstado.SelectedIndex != 0) {
                ddlCiudad.Items.Clear();
                cargarCiudades();
            } else ddlCiudad.Items.Clear();
        }

        #endregion

        #region Métodos
        public void agregarFacultad() {
            FacultadBLL facultadBLL = new FacultadBLL();

            Escuela_DAL.Facultad facultad = new Escuela_DAL.Facultad();

            facultad.codigo = txtCodigo.Text;
            facultad.nombre = txtNombre.Text;
            facultad.fechaCreacion = Convert.ToDateTime(txtFechaCreacion.Text);
            facultad.universidad = int.Parse(ddlUniversidades.SelectedValue);
            facultad.ciudad = int.Parse(ddlCiudad.SelectedValue);

            try {
                MateriaFacultad materiaFacu;
                List<MateriaFacultad> listMaterias = new List<MateriaFacultad>();
                facultadBLL.agregarFacultad(facultad);


                foreach (ListItem item in listBoxMaterias.Items) {
                    if (item.Selected) {
                        materiaFacu = new MateriaFacultad();
                        materiaFacu.materia = int.Parse(item.Value);
                        materiaFacu.facultad = facultad.ID_Facultad;
                        listMaterias.Add(materiaFacu);
                    }

                }
                facultadBLL.agregarMateria(listMaterias);

                limpiarCampos();
                
            } catch(Exception ex) {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "Alta", "alert('" + ex.Message + "')", true);
            }
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

        public void cargarTabla() {
            DataTable dt = new DataTable();

            dt.Columns.Add("codigo");
            dt.Columns.Add("nombre");
            dt.Columns.Add("fechaCreacion");
            dt.Columns.Add("universidad");

            ViewState["tablaFacultades"] = dt;
        }

        public bool sesionIniciada() {
            if (Session["Usuario"] != null) return true;
            else return false;
        }

        public void limpiarCampos() {
            txtCodigo.Text = "";
            txtFechaCreacion.Text = "";
            txtNombre.Text = "";
            ddlUniversidades.SelectedIndex = 0;
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

        #endregion
    }
}