using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Runtime.Serialization;


namespace Sis.Estudio.Entity
{
    [DataContract]
    public class EnProduCliente
    {

        [DataMember]
        public string nempresa { get; set; }
        [DataMember]
        public string CodigoCliente { get; set; }
        [DataMember]
        public string CodProducto { get; set; }
        [DataMember]
        public string CodSubProducto { get; set; }
        [DataMember]
        public string CodigoInterno { get; set; }
        [DataMember]
        public string SaldoCapital { get; set; }
        [DataMember]
        public string Moneda { get; set; }
        [DataMember]
        public string CalifRiesgo { get; set; }
        [DataMember]
        public string PorProvision { get; set; }
        [DataMember]
        public string CodSucursal { get; set; }
        [DataMember]
        public string CodSectorista { get; set; }
        [DataMember]
        public string CodZona { get; set; }
        [DataMember]
        public string CodGerente { get; set; }
        [DataMember]
        public string dias_mora { get; set; }
        [DataMember]
        public string Estado { get; set; }
        [DataMember]
        public string CodUsuario { get; set; }
        [DataMember]
        public string MontoDesemb { get; set; }
        [DataMember]
        public string tea { get; set; }
        [DataMember]
        public string TotCuotasPact { get; set; }
        [DataMember]
        public string MontoCuota { get; set; }
        [DataMember]
        public string NEMPRESA { get; set; }
        [DataMember]
        public string IdReg { get; set; }

        
        [DataMember]
        public string IdRegPRODUCTOS { get; set; }


  


    }
}
