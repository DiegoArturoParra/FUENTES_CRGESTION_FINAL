using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Runtime.Serialization;


namespace Sis.Estudio.Entity
{
    [DataContract]
    public class EnClieProdAval
    {
        [DataMember]
        public string NEmpresa { get; set; }
        [DataMember]
        public string CodigoCliente { get; set; }
        [DataMember]
        public string IdRegProductos { get; set; }
        [DataMember]
        public string DNI { get; set; }
        [DataMember]
        public string Nombres { get; set; }
        [DataMember]
        public string CodStatusLaboral { get; set; }
        [DataMember]
        public string Telefonos { get; set; }
        [DataMember]
        public string Observacion { get; set; }
        [DataMember]
        public string Estado { get; set; }
        [DataMember]
        public string CodUsuario { get; set; }
        [DataMember]
        public string IdReg { get; set; }       
        [DataMember]
        public string IdRegPRODUCTOS { get; set; }
    }
}
