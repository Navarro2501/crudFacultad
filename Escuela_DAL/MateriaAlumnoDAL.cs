using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Escuela_DAL {
    public class MateriaAlumnoDAL {
        EscuelaEntities modelo;

        public MateriaAlumnoDAL() {
            modelo = new EscuelaEntities();
        }

        public void agregarMateriaAlumno(MateriaAlumno materia) {
            modelo.MateriaAlumno.Add(materia);
            modelo.SaveChanges();
        }

        public void eliminarMaterias(int matricula) {
            var materias = from tMaterias in modelo.MateriaAlumno
                           where tMaterias.alumno == matricula
                           select tMaterias;

            foreach(MateriaAlumno materia in materias) {
                modelo.MateriaAlumno.Remove(materia);
                modelo.SaveChanges();
            }
        }
    }
}
