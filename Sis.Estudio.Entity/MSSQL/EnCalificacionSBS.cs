using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace Sis.Estudio.Entity
{
    [DataContract]
    public class EnCalificacionSBS
    {
        [DataMember]
        public string CodCalificacionSBS { get; set; }
        [DataMember]
        public string CalificacionSBS { get; set; }
        [DataMember]
        public string IniDiasMora { get; set; }
        [DataMember]
        public string FinDiasMora { get; set; }
        [DataMember]
        public string Estado { get; set; }
        [DataMember]
        public string CodUsuario { get; set; }
        [DataMember]
        public string NEmpresa { get; set; }
        

    }
}
