using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace Sis.Estudio.Entity
{
    [DataContract]
    public class EnContencionTramo
    {

        [DataMember]
        public string NEMPRESA { get; set; }
        [DataMember]
        public string Anio { get; set; }
        [DataMember]
        public string Tramo { get; set; }



    }
}
