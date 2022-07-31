using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Runtime.Serialization;
namespace Sis.Estudio.Entity
{

    [DataContract]
    public class EnCanalContact
    {

        [DataMember]
        public string NEMPRESA { get; set; }
        [DataMember]
        public string CodigoCliente { get; set; }
        [DataMember]
        public string CodTipoContacto { get; set; }
        [DataMember]
        public string Dato { get; set; }
        [DataMember]
        public string Orden { get; set; }
        [DataMember]
        public string Estado { get; set; }
        [DataMember]
        public string CodUsuario { get; set; }
        [DataMember]
        public string IdReg { get; set; }

        
    }
}
