using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Activation;
using System.ServiceModel.Web;
using System.Text;
using Escuela_DAL;
using System.Web.Script.Serialization;
using Newtonsoft.Json;

namespace Escuela {
    [ServiceContract(Namespace = "")]
    [AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Allowed)]
    public class ServicioWCFFacultad {
        EscuelaEntities modelo;

        public ServicioWCFFacultad() {
            modelo = new EscuelaEntities();
        }
        
        [WebGet]
        [OperationContract]
        public string consultaFacultadesJSON() {
            var facultades = from mFacultades in modelo.Facultad
                             select new {
                                 ID_Facultad = mFacultades.ID_Facultad,
                                 codigo = mFacultades.codigo,
                                 nombre = mFacultades.nombre,
                                 fechaCreacion = mFacultades.fechaCreacion,
                                 universidad = mFacultades.universidad,
                                 ciudad = mFacultades.ciudad
                             };
            return JsonConvert.SerializeObject(facultades);
        }

        // Add more operations here and mark them with [OperationContract]
    }
}
