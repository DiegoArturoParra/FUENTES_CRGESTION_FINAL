using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Runtime.Serialization;

namespace Sis.Estudio.Entity
{
    [DataContract]
    public class EnCliente_Gastos
    {

        [DataMember]
        public string IdReg_ClienteGastos { get; set; }
        [DataMember]
        public string NEMPRESA { get; set; }
        [DataMember]
        public string CodigoCliente { get; set; }
        [DataMember]
        public string IdRegProductos { get; set; }
        [DataMember]
        public string Fecha { get; set; }
        [DataMember]
        public string ruc { get; set; }
        [DataMember]
        public string RazonSocial { get; set; }
        [DataMember]
        public string Monto { get; set; }
        [DataMember]
        public string id_tipo_tramite { get; set; }
        [DataMember]
        public string tipo_tramite { get; set; }
        [DataMember]
        public string Observacion { get; set; }
        [DataMember]
        public string FechaRendicion { get; set; }
        [DataMember]
        public string CodUsuario { get; set; }

    }
}
