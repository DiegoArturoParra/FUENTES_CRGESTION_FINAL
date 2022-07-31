using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Runtime.Serialization;


namespace Sis.Estudio.Entity
{
    [DataContract]
    public class EnGS_Campaña
    {

        [DataMember]
        public string id_campaña { get; set; }
        [DataMember]
        public string desc_campaña { get; set; }
        [DataMember]
        public string condicion_campaña { get; set; }
    

        [DataMember]
        public string IdReg { get; set; }
        [DataMember]
        public string nEmpresa { get; set; }
        [DataMember]
        public string CodigoCliente { get; set; }
        [DataMember]
        public string DNI { get; set; }
        [DataMember]
        public string RUC { get; set; }
        [DataMember]
        public string RazonSocial { get; set; }

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
        public string CodEstadoDir { get; set; }
        
        [DataMember]
        public string CodUsuario { get; set; }

        [DataMember]
        public string Dias_deuda { get; set; }


        [DataMember]
        public string condicion_dias { get; set; }
        [DataMember]
        public string condicion_capital { get; set; }
        [DataMember]
        public string condicion_saldocapital { get; set; }

        
        [DataMember]
        public string fecha_ini { get; set; }
        [DataMember]
        public string fecha_fin { get; set; }


        
    }
}
