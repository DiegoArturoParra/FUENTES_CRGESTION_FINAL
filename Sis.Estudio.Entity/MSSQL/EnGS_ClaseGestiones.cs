using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Runtime.Serialization;

namespace Sis.Estudio.Entity
{
    [DataContract]
    public class EnGS_ClaseGestiones
    {

        [DataMember]
        public string nempresa { get; set; }
        [DataMember]
        public string CodClaseGestion { get; set; }
        [DataMember]
        public string CodTipoGestion { get; set; }
        [DataMember]
        public string Descripcion { get; set; }
        [DataMember]
        public string CodUsuario { get; set; }
        [DataMember]
        public string CodEjecutado { get; set; }

        [DataMember]
        public string CodResultado { get; set; }
        [DataMember]
        public string Descripcion_Resultado { get; set; }
    }
}
