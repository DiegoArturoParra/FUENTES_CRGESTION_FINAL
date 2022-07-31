using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Runtime.Serialization;

namespace Sis.Estudio.Entity
{

    [DataContract]
    public class EnCargaInicialPagos
    {

        [DataMember]
        public string NEmpresa { get; set; }
        [DataMember]
        public string sg_orden { get; set; }
        [DataMember]
        public string sg_documento { get; set; }
        [DataMember]
        public string firstname { get; set; }
        [DataMember]
        public string code { get; set; }
        [DataMember]
        public string sg_numero_tarjeta { get; set; }
        [DataMember]
        public string sg_fecha_ultimo_pago { get; set; }
        [DataMember]
        public string sg_cliente_pago { get; set; }
        [DataMember]
        public string nempresa { get; set; }
        [DataMember]
        public string CodUsuario { get; set; }

        [DataMember]
        public string sg_num_credito { get; set; }
        [DataMember]
        public string sg_monto_capital { get; set; }
        [DataMember]
        public string sg_monto_interes { get; set; }
        [DataMember]
        public string sg_monto_reservado { get; set; }
        [DataMember]
        public string sg_monto_otros { get; set; }
        [DataMember]
        public string fecha_pago { get; set; }
        [DataMember]
        public string fecha_registro { get; set; }
        [DataMember]
        public string sw { get; set; }
    }
}
