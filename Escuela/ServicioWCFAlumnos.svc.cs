﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Activation;
using System.ServiceModel.Web;
using System.Text;

//agregados
using System.Web.Script.Serialization;
using Escuela_DAL;

namespace Escuela {
    [ServiceContract(Namespace = "")]
    [AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Allowed)]
    public class ServicioWCFAlumnos {
        EscuelaEntities modelo;
        public ServicioWCFAlumnos() {
            modelo = new EscuelaEntities();
        }

        // To use HTTP GET, add [WebGet] attribute. (Default ResponseFormat is WebMessageFormat.Json)
        // To create an operation that returns XML,
        //     add [WebGet(ResponseFormat=WebMessageFormat.Xml)],
        //     and include the following line in the operation body:
        //         WebOperationContext.Current.OutgoingResponse.ContentType = "text/xml";
        [WebGet]
        [OperationContract]
        public string ConsultaAlumnosJSON() {
            var alumnos = from mAlumnos in modelo.Alumno
                          select new {
                              matricula = mAlumnos.matricula,
                              nombre = mAlumnos.nombre,
                          };
            /* Convierte los datos a una colección enumerable
             * una vez que es enumerable hacemos return como una lista
             * */
            return (new JavaScriptSerializer().Serialize(alumnos.AsEnumerable<object>().ToList()));
        }

        // Add more operations here and mark them with [OperationContract]
    }
}
