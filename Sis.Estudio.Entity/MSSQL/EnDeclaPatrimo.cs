using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Runtime.Serialization;


namespace Sis.Estudio.Entity
{
    [DataContract]
    public class EnDeclaPatrimo
    {
        [DataMember]
        public string nempresa { get; set; }
        [DataMember]
        public string CodigoCliente { get; set; }
        [DataMember]
        public string CodTipoBien { get; set; }
        [DataMember]
        public string PorPropiedad { get; set; }
        [DataMember]
        public string ValorComercial { get; set; }
        [DataMember]
        public string Moneda { get; set; }
        [DataMember]
        public string PartidaRegistral { get; set; }
        [DataMember]
        public string DatosBien { get; set; }
        [DataMember]
        public string Observacion { get; set; }
        [DataMember]
        public string Estado { get; set; }
        [DataMember]
        public string CodUsuario { get; set; }
        [DataMember]
        public string IdReg { get; set; }

    }
}
