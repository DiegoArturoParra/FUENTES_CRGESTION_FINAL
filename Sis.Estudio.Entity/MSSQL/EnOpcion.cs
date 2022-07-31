using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Runtime.Serialization;

namespace Sis.Estudio.Entity
{
    [DataContract]
    public class EnOpcion
    {
        [DataMember]
        public string Accion { get; set; }

        [DataMember]
        public string CEmpresa { get; set; }

        [DataMember]
        public string IdModulo { get; set; }

        [DataMember]
        public string TipoOpcion { get; set; }

        [DataMember]
        public string IdOpcionPadre { get; set; }

        [DataMember]
        public string IdOpcion { get; set; }

        [DataMember]
        public string Nombre { get; set; }

        [DataMember]
        public string Descripcion { get; set; }

        [DataMember]
        public string CodUsuario { get; set; }

        [DataMember]
        public string url { get; set; }

        [DataMember]
        public string TopListado { get; set; }
       
        [DataMember]
        public string IdAccion { get; set; }

        [DataMember]
        public string idOpcionAccion { get; set; }       
        
        [DataMember]
        public string Login { get; set; }





    }
}
