using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace Sis.Estudio.Entity
{
    [DataContract]
    public class EnSucursal
    {
        [DataMember]
        public string NEmpresa { get; set; }
        [DataMember]
        public string CodSucursal { get; set; }
        [DataMember]
        public string Sucursal { get; set; }
        [DataMember]
        public string CodigoInterno { get; set; }
        [DataMember]
        public string Estado { get; set; }
        [DataMember]
        public string CodUsuario { get; set; }
    }
}
