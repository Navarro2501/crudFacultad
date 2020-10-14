using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Escuela_DAL {
    public class MateriaFacultadDAL {

        EscuelaEntities modelo;

        public MateriaFacultadDAL() {
            modelo = new EscuelaEntities();
        }

        public void agregarMateriaFacultad(MateriaFacultad materia) {
            modelo.MateriaFacultad.Add(materia);
            modelo.SaveChanges();
        }

        public void eliminarMaterias(int matricula) {
            var materias = from tMaterias in modelo.MateriaFacultad
                           where tMaterias.facultad == matricula
                           select tMaterias;

            foreach (MateriaFacultad materia in materias) {
                modelo.MateriaFacultad.Remove(materia);
                modelo.SaveChanges();
            }
        }

    }
}
