using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Runtime.Serialization;

namespace Sis.Estudio.Entity
{
    [DataContract]
    public class EnGS_Reportes
    {

        [DataMember]
        public string id_servicio { get; set; }
        [DataMember]
        public string NEMPRESA { get; set; }
        [DataMember]
        public string CodUsuarioRegistra { get; set; }
        [DataMember]
        public string sw { get; set; }
        [DataMember]
        public string fecha_ini { get; set; }
        [DataMember]
        public string fecha_fin { get; set; }
        [DataMember]
        public string Id_Estado_Gestion_Cobranza { get; set; }
        [DataMember]
        public string CodTipoGestion { get; set; }

        [DataMember]
        public string anio { get; set; }
        [DataMember]
        public string mes { get; set; }

        [DataMember]
        public string RangoDias { get; set; }

        [DataMember]
        public string Jerarquia { get; set; }











        


    }
}
