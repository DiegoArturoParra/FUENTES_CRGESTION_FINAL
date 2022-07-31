using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Runtime.Serialization;

namespace Sis.Estudio.Entity
{
    [DataContract]
    public class EnDatosCliente
    {
        [DataMember]
        public string NEMPRESA { get; set; }
        [DataMember]
        public string CodigoCliente { get; set; }
        [DataMember]
        public string CodigoSBS { get; set; }
        [DataMember]
        public string DNI { get; set; }
        [DataMember]
        public string RUC { get; set; }
        [DataMember]
        public string ApePat { get; set; }
        [DataMember]
        public string ApeMat { get; set; }
        [DataMember]
        public string Nombres { get; set; }
        [DataMember]
        public string CodTipoPersona { get; set; }
        [DataMember]
        public string CodStatusLab { get; set; }
        [DataMember]
        public string RazonSocial { get; set; }
        [DataMember]
        public string Profesion { get; set; }
        [DataMember]
        public string CodEstCivil { get; set; }


    }
}
