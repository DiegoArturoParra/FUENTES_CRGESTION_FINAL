using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Runtime.Serialization;

namespace Sis.Estudio.Entity
{
    [DataContract]
    public class EnGS_UbigeoColindante
    {
        [DataMember]
        public string id { get; set; }
        [DataMember]
        public string CodDepartamento { get; set; }
        [DataMember]
        public string CodProvincia { get; set; }
        [DataMember]
        public string CodDistrito { get; set; }

        [DataMember]
        public string Desc_CodDepartamento { get; set; }
        [DataMember]
        public string Desc_CodProvincia { get; set; }
        [DataMember]
        public string Desc_CodDistrito { get; set; }

        [DataMember]
        public string Ubigeo_central { get; set; }
        [DataMember]
        public string Ubigeo_alrededor { get; set; }

        [DataMember]
        public string CodUsuario { get; set; }

    }
}

