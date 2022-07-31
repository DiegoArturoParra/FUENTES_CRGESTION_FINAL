using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace Sis.Estudio.Entity
{
    [DataContract]
    public class EnZona
    {
        [DataMember]
        public string NEmpresa { get; set; }
        [DataMember]
        public string CodGerencia { get; set; }
        [DataMember]
        public string CodZona { get; set; }
        [DataMember]
        public string Zona { get; set; }
        [DataMember]
        public string CodigoInterno { get; set; }
        [DataMember]
        public string Estado { get; set; }
        [DataMember]
        public string CodUsuario { get; set; }
        
    }
}
