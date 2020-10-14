using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Escuela_DAL;
using System.Transactions;

namespace Escuela_BLL {
    public class FacultadBLL {
        public List<Facultad> cargarFacultades() {
            FacultadDAL facultad = new FacultadDAL();
            return facultad.cargarFacultades();
        }

        public Facultad cargarFacultad(int id) {
            FacultadDAL facultad = new FacultadDAL();
            return facultad.cargarFacultad(id);
        }
        //Revisar el método de modificar facultad para que deje modificar únicamente el nombre sin cambiar el código
        public void modificarFacultad(Facultad pFacultad, List<MateriaFacultad> listMaterias) {
            FacultadDAL facultad = new FacultadDAL();
            MateriaFacultadBLL matFacultadBLL = new MateriaFacultadBLL();

            using (TransactionScope ts = new TransactionScope()) {
                facultad.modificarFacultad(pFacultad);
                matFacultadBLL.eliminarMaterias(pFacultad.ID_Facultad);

                foreach (MateriaFacultad materia in listMaterias) matFacultadBLL.agregarMateriaFacultad(materia);

                ts.Complete();
            }
        }

        public void eliminarFacultad(int id) {
            FacultadDAL facultad = new FacultadDAL();
            MateriaFacultadBLL matFacultad = new MateriaFacultadBLL();

            using (TransactionScope ts = new TransactionScope()) {
                matFacultad.eliminarMaterias(id);
                facultad.eliminarFacultad(id);

                ts.Complete();
            }
        }

        public void eliminarAlumno(int matricula) {
            AlumnoDAL alumno = new AlumnoDAL();
            MateriaAlumnoBLL matAlumno = new MateriaAlumnoBLL();

            using (TransactionScope ts = new TransactionScope()) {
                matAlumno.eliminarMaterias(matricula);
                alumno.eliminarAlumno(matricula);

                ts.Complete();
            }
        }


        public void agregarFacultad(Facultad paramFacultad) {
            FacultadDAL facultad = new FacultadDAL();
            Facultad facu = new Facultad();

            facu = cargarFacultad(paramFacultad.ID_Facultad);

            if (facu != null) throw new Exception("El código de la facultad ya existe, introduce uno diferente.");
            else {
                if (paramFacultad.fechaCreacion.Year > 2010) throw new Exception("Fecha no permitida, introduce una fecha menor a 2010");
                else if (paramFacultad.fechaCreacion.Year < 1900) throw new Exception("Fecha no permitida, introduce una fecha mayor a 1900");
                else
                    using (TransactionScope ts = new TransactionScope()) {
                    
                        facultad.agregarFacultad(paramFacultad);
                        ts.Complete();
                    }
            }
        }

        public void agregarMateria(List<MateriaFacultad> listMaterias) {
            MateriaFacultadBLL matFacuBLL = new MateriaFacultadBLL();
            foreach (MateriaFacultad materia in listMaterias) matFacuBLL.agregarMateriaFacultad(materia);
        }

        public Facultad cargarCodigoFacultad(string codigo) {
            FacultadDAL facultad = new FacultadDAL();
            return facultad.cargarCodigoFacultad(codigo);
        }
    }
}
