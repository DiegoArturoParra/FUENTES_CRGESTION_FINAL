using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace Sis.Estudio.Entity
{
    [DataContract]
    public class EnGS_BaseReportes
    {
        [DataMember]
        public string Anio { get; set; }
        [DataMember]
        public string Mes { get; set; }
        [DataMember]
        public string NEmpresa { get; set; }
        [DataMember]
        public string CodAgencia { get; set; }
        [DataMember]
        public string CodCliente { get; set; }
        [DataMember]
        public string Cliente { get; set; }
        [DataMember]
        public string DNI { get; set; }
        [DataMember]
        public string CodProducto { get; set; }
        [DataMember]
        public string CodSubProducto { get; set; }
        [DataMember]
        public string Credito { get; set; }
        [DataMember]
        public string DiasAtraso { get; set; }
        [DataMember]
        public string CodAnalista { get; set; }
        [DataMember]
        public string Tramo { get; set; }
        [DataMember]
        public string Moneda { get; set; }
        [DataMember]
        public string FecDesembolso { get; set; }
        [DataMember]
        public string Desembolso { get; set; }
        [DataMember]
        public string Plazo { get; set; }
        [DataMember]
        public string Categoria { get; set; }
        [DataMember]
        public string SaldoNetoMN { get; set; }
        [DataMember]
        public string ProvisionMN { get; set; }
        [DataMember]
        public string SaldoCapitalMN { get; set; }
        [DataMember]
        public string Estado { get; set; }
        [DataMember]
        public string CIIU { get; set; }
        [DataMember]
        public string Destino { get; set; }
        [DataMember]
        public string Cuotas { get; set; }
        [DataMember]
        public string FecVenc { get; set; }
        [DataMember]
        public string CapitalVigenteMN { get; set; }
        [DataMember]
        public string CapitalRefinanciadoMN { get; set; }
        [DataMember]
        public string CapitalVencidoMN { get; set; }
        [DataMember]
        public string CapitalJuidicialMN { get; set; }
        [DataMember]
        public string CuotaVencida { get; set; }
        [DataMember]
        public string Sobregiro { get; set; }
        [DataMember]
        public string Garantia { get; set; }
        [DataMember]
        public string AnioFin { get; set; }
        [DataMember]
        public string MesFin { get; set; }
    }
}
