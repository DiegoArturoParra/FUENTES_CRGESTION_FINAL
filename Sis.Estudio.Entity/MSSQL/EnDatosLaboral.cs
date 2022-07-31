using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Runtime.Serialization;

namespace Sis.Estudio.Entity
{

    [DataContract]
    public class EnDatosLaboral
    {
        [DataMember]
        public string nempresa { get; set; }
        [DataMember]
        public string CodigoCliente { get; set; }
        [DataMember]
        public string RUC { get; set; }
        [DataMember]
        public string Empresa { get; set; }
        [DataMember]
        public string Cargo { get; set; }
        [DataMember]
        public string FechaIngreso { get; set; }
        [DataMember]
        public string CodSitLab { get; set; }
        [DataMember]
        public string Sueldo { get; set; }
        [DataMember]
        public string Telef { get; set; }
        [DataMember]
        public string Anexo { get; set; }
        [DataMember]
        public string Observacion { get; set; }
        [DataMember]
        public string Estado { get; set; }
        [DataMember]
        public string CodUsuario { get; set; }
        [DataMember]
        public string NEMPRESA { get; set; }
        [DataMember]
        public string IdReg { get; set; }


    }
}
