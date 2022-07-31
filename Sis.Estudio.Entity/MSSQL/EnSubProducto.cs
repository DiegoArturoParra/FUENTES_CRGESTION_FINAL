using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace Sis.Estudio.Entity
{
    [DataContract]
    public class EnSubProducto
    {
        [DataMember]
        public string CodProducto { get; set; }
        [DataMember]
        public string CodSubProducto { get; set; }
        [DataMember]
        public string SubProducto { get; set; }
        [DataMember]
        public string CodigoInterno { get; set; }
        [DataMember]
        public string Estado { get; set; }
        [DataMember]
        public string CodUsuario { get; set; }
        [DataMember]
        public string NEmpresa { get; set; }
    }
}
