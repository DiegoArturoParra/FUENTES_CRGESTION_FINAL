using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Runtime.Serialization;

namespace Sis.Estudio.Entity
{
    [DataContract]
    public class EnGS_TipoGestiones
    {

        [DataMember]
        public string nempresa { get; set; }
        [DataMember]
        public string CodTipoGestion { get; set; }
        [DataMember]
        public string Descripcion { get; set; }
        [DataMember]
        public string Tiempo { get; set; }
        [DataMember]
        public string Proc_auto { get; set; }
        [DataMember]
        public string grupo { get; set; }
        [DataMember]
        public string CodUsuario { get; set; }


        [DataMember]
        public string CodTipoGestionAprob { get; set; }
        [DataMember]
        public string Nivel { get; set; }
        [DataMember]
        public string Cod_Jerarquia { get; set; }
        [DataMember]
        public string Aprobacion { get; set; }
        [DataMember]
        public string Correo { get; set; }

        [DataMember]
        public string Flujo { get; set; }

        [DataMember]
        public string FlagFechaVisita { get; set; }

        [DataMember]
        public string FlagGeneraNuevo { get; set; }

        [DataMember]
        public string FlagProcesoMasivo { get; set; }

    }
}
