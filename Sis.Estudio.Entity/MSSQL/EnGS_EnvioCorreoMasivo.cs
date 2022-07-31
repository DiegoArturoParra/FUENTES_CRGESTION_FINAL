using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Runtime.Serialization;

namespace Sis.Estudio.Entity
{
    [DataContract]
    public class EnGS_EnvioCorreoMasivo
    {

        [DataMember]
        public string id_servicio { get; set; }
        [DataMember]
        public string descrip { get; set; }
        [DataMember]
        public string pendiente { get; set; }
        [DataMember]
        public string nEmpresa { get; set; }
        [DataMember]
        public string Id_Reg_Gestion_Cobranza { get; set; }
        [DataMember]
        public string correo_remitente { get; set; }
        [DataMember]
        public string correo_destinatario { get; set; }
        [DataMember]
        public string correo_asunto { get; set; }
        [DataMember]
        public string correo_cuerpo { get; set; }
        [DataMember]
        public string dFechaEnvio { get; set; }

    }
}
