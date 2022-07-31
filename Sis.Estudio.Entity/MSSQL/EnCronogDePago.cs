using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Runtime.Serialization;

namespace Sis.Estudio.Entity
{
    [DataContract]
    public class EnCronogDePago
    {
        [DataMember]
        public string NEmpresa { get; set; }
        [DataMember]
        public string CodigoCliente { get; set; }
        [DataMember]
        public string IdRegProductos { get; set; }
        [DataMember]
        public string NroCuotas { get; set; }
        [DataMember]
        public string FechaVencimiento { get; set; }
        [DataMember]
        public string FechaPago { get; set; }
        [DataMember]
        public string MontoCuota { get; set; }
        [DataMember]
        public string CodEstadoCronograma { get; set; }
        [DataMember]
        public string Capital { get; set; }
        [DataMember]
        public string Interes { get; set; }
        [DataMember]
        public string SaldoCapital { get; set; }
        [DataMember]
        public string CodCalificacionSBS { get; set; }
        [DataMember]
        public string CodUsuario { get; set; }
        [DataMember]
        public string IdReg { get; set; }
        [DataMember]
        public string IdRegPRODUCTOS { get; set; }


    }
}
