using Escuela_DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Escuela_BLL {
    public class MateriaFacultadBLL {
        public void agregarMateriaFacultad(MateriaFacultad materia) {
            MateriaFacultadDAL matFacu = new MateriaFacultadDAL();
            matFacu.agregarMateriaFacultad(materia);
        }

        public void eliminarMaterias(int matricula) {
            MateriaFacultadDAL matFacultad = new MateriaFacultadDAL();
            matFacultad.eliminarMaterias(matricula);
        }
    }
}
