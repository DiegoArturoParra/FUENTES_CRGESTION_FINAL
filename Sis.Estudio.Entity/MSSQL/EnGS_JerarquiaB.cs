using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Runtime.Serialization;

namespace Sis.Estudio.Entity
{
    [DataContract]
    public class EnGS_JerarquiaB
    {

        [DataMember]
        public string nempresa { get; set; }
        [DataMember]
        public string cod_jerarquiaB { get; set; }
        [DataMember]
        public string cod_jerarquiaA { get; set; }
        [DataMember]
        public string desc_jerarquiaB { get; set; }
        [DataMember]
        public string CodUsuario { get; set; }

    }
}