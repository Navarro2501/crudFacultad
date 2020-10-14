using Escuela_DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Escuela_BLL {
    public class MateriaAlumnoBLL {
        public void agregarMateriaAlumno(MateriaAlumno materia) {
            MateriaAlumnoDAL matAlumno = new MateriaAlumnoDAL();
            matAlumno.agregarMateriaAlumno(materia);
        }

        public void eliminarMaterias(int matricula) {
            MateriaAlumnoDAL matAlumno = new MateriaAlumnoDAL();
            matAlumno.eliminarMaterias(matricula);
        }
    }
}
