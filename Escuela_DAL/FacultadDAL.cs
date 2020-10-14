using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Escuela_DAL {
    public class FacultadDAL {

        EscuelaEntities modelo;

        public FacultadDAL() {
            modelo = new EscuelaEntities();
        }

        public List<Facultad> cargarFacultades() {
            var facultades = from mFacultades in modelo.Facultad
                             select mFacultades;

            return facultades.ToList();
        }

        public Facultad cargarFacultad(int id) {
            var facultad = (from mFacultad in modelo.Facultad
                            where mFacultad.ID_Facultad == id
                            select mFacultad).FirstOrDefault();

            return facultad;
        }

        public void modificarFacultad(Facultad pFacultad) {
            var facultad = (from mFacultad in modelo.Facultad
                            where mFacultad.ID_Facultad == pFacultad.ID_Facultad
                            select mFacultad).FirstOrDefault();

            facultad.nombre = pFacultad.nombre;
            facultad.fechaCreacion = pFacultad.fechaCreacion;
            facultad.universidad = pFacultad.universidad;
            facultad.ciudad = pFacultad.ciudad;

            modelo.SaveChanges();

        }

        public void eliminarFacultad(int id) {
            var facultad = (from mFacultad in modelo.Facultad
                            where mFacultad.ID_Facultad == id
                            select mFacultad).FirstOrDefault();

            modelo.Facultad.Remove(facultad);
            modelo.SaveChanges();
        }

        public void agregarFacultad(Facultad facultad) {
            modelo.Facultad.Add(facultad);
            modelo.SaveChanges();
        }

        public Facultad cargarCodigoFacultad(string codigo) {
            var facultad = (from mFacultad in modelo.Facultad
                            where mFacultad.codigo == codigo
                            select mFacultad).FirstOrDefault();

            return facultad;
        }
    }

}
