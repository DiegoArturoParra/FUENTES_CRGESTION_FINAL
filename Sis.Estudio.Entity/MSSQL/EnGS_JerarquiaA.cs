using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Runtime.Serialization;

namespace Sis.Estudio.Entity
{
    [DataContract]
    public class EnGS_JerarquiaA
    {

        [DataMember]
        public string nempresa { get; set; }
        [DataMember]
        public string cod_jerarquiaA { get; set; }
        [DataMember]
        public string desc_jerarquiaA { get; set; }
        [DataMember]
        public string CodUsuario { get; set; }
        [DataMember]
        public string id_ejecutores { get; set; }
    }
}