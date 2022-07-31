using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Runtime.Serialization;

namespace Sis.Estudio.Entity
{
    [DataContract]
    public class EnGS_Resultado
    {

        [DataMember]
        public string nempresa { get; set; }
        [DataMember]
        public string CodResultado { get; set; }
        [DataMember]
        public string Descripcion { get; set; }
        [DataMember]
        public string CodUsuario { get; set; }

    }
}
