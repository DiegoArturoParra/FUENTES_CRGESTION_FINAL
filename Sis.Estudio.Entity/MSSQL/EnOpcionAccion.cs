using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Runtime.Serialization;

namespace Sis.Estudio.Entity
{
    [DataContract]
    public class EnOpcionAccion
    {
        [DataMember]
        public string IdOpcion { get; set; }

        [DataMember]
        public string IdAccion { get; set; }
    }
}
