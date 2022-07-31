using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Runtime.Serialization;

namespace Sis.Estudio.Entity
{
    [DataContract]
    public class EnGS_ReglasGestionesxTipoGestion
    {

        [DataMember]
        public string nempresa { get; set; }
        [DataMember]
        public string id_ReglasGestiones { get; set; }
        [DataMember]
        public string CodTipoGestion { get; set; }
        [DataMember]
        public string CodUsuarioEjecutor { get; set; }
    }
}
