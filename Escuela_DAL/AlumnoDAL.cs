using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Escuela_DAL {
    public class AlumnoDAL {

        EscuelaEntities modelo;

        public AlumnoDAL() {
            modelo = new EscuelaEntities();
        }

        public List<object> cargarAlumnos() {
            var alumnos = from mAlumnos in modelo.Alumno
                          select new {
                              matricula = mAlumnos.matricula,
                              nombre = mAlumnos.nombre,
                              fechaNacimiento = mAlumnos.fechaNacimiento,
                              semestre = mAlumnos.semestre,
                              nombreFacultad = mAlumnos.Facultad1.nombre,
                              nombreCiudad = mAlumnos.Ciudad1.nombre
                          };
            /* Convierte los datos a una colección enumerable
             * una vez que es enumerable hacemos return como una lista
             * */
            return alumnos.AsEnumerable<object>().ToList();

        }

        public void agregarAlumno(Alumno alumno) {
            modelo.Alumno.Add(alumno);
            modelo.SaveChanges();
        }

        public Alumno cargarAlumno(int matricula) {
            var alumno = (from mAlumno in modelo.Alumno
                          where mAlumno.matricula == matricula
                          select mAlumno).FirstOrDefault();

            return alumno;
        }

        public void modificarAlumno(Alumno pAlumno) {
            var alumno = (from mAlumno in modelo.Alumno
                          where mAlumno.matricula == pAlumno.matricula
                          select mAlumno).FirstOrDefault();

            alumno.nombre = pAlumno.nombre;
            alumno.fechaNacimiento = pAlumno.fechaNacimiento;
            alumno.semestre = pAlumno.semestre;
            alumno.facultad = pAlumno.facultad;
            alumno.ciudad = pAlumno.ciudad;

            modelo.SaveChanges();

        }

        public void eliminarAlumno(int matricula) {
            var alumno = (from mAlumno in modelo.Alumno
                          where mAlumno.matricula == matricula
                          select mAlumno).FirstOrDefault();

            modelo.Alumno.Remove(alumno);
            modelo.SaveChanges();
        }
    }
}
