using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Runtime.Serialization;

namespace Sis.Estudio.Entity
{
    [DataContract]
    public class EnGS_ClaseGestionesxEjecutado
    {

        [DataMember]
        public string nempresa { get; set; }
        [DataMember]
        public string CodClaseGestion { get; set; }
        [DataMember]
        public string CodEjecutado { get; set; }

    }
}
