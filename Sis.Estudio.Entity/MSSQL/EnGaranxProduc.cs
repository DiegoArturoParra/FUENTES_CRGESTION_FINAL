using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Runtime.Serialization;

namespace Sis.Estudio.Entity
{
    public class EnGaranxProduc
    {
        [DataMember]
        public string NEmpresa { get; set; }
        [DataMember]
        public string CodigoCliente { get; set; }
        [DataMember]
        public string IdRegProductos { get; set; }
        [DataMember]
        public string CodGarantia { get; set; }
        [DataMember]
        public string CodTipoBien { get; set; }
        [DataMember]
        public string DescripBien { get; set; }
        [DataMember]
        public string Telefonos { get; set; }
        [DataMember]
        public string Propietarios { get; set; }
        [DataMember]
        public string NombreGarante { get; set; }
        [DataMember]
        public string Beneficiario { get; set; }
        [DataMember]
        public string Ubicacion { get; set; }
        [DataMember]
        public string Direccion { get; set; }
        [DataMember]
        public string area { get; set; }
        [DataMember]
        public string DNI { get; set; }
        [DataMember]
        public string ValorComercial { get; set; }
        [DataMember]
        public string MontoGarantia { get; set; }
        [DataMember]
        public string CartaFianza { get; set; }
        [DataMember]
        public string FechaUltTasacion { get; set; }
        [DataMember]
        public string VencimientoCF { get; set; }
        [DataMember]
        public string ValorGravamen { get; set; }
        [DataMember]
        public string NumPartidaElec { get; set; }
        [DataMember]
        public string Observacion { get; set; }
        [DataMember]
        public string Restricciones { get; set; }
        [DataMember]
        public string CoberturaCF { get; set; }
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
