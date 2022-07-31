using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Runtime.Serialization;

namespace Sis.Estudio.Entity
{
    [DataContract]
    public class EnGS_Ejecutado
    {

        [DataMember]
        public string nempresa { get; set; }
        [DataMember]
        public string CodEjecutado { get; set; }
        [DataMember]
        public string Descripcion { get; set; }
        [DataMember]
        public string CodTipoGestion { get; set; }
        [DataMember]
        public string desc_CodTipoGestion { get; set; }
        [DataMember]
        public string dias { get; set; }
        [DataMember]
        public string Tiempo { get; set; }
        [DataMember]
        public string CodUsuario { get; set; }

    }
}
