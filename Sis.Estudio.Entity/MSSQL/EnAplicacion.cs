using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Runtime.Serialization;

namespace Sis.Estudio.Entity
{
    [DataContract]
    public class EnAplicacion
    {
        [DataMember]
        public string NEmpresa { get; set; }
        [DataMember]
        public string CodProducto { get; set; }
        [DataMember]
        public string CodZona { get; set; }
        [DataMember]
        public string CodGerencia { get; set; }


    }
}
