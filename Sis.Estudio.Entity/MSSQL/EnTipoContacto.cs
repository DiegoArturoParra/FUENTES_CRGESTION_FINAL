using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;
namespace Sis.Estudio.Entity
{
    [DataContract]
    public class EnTipoContacto
    {
        [DataMember]
        public string CodTipoContacto { get; set; }
        [DataMember]
        public string TipoContacto { get; set; }
        [DataMember]
        public string Estado { get; set; }
        [DataMember]
        public string CodUsuario { get; set; }
        [DataMember]
        public string NEmpresa{ get; set; }
        
    }
}
