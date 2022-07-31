using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Runtime.Serialization;

namespace Sis.Estudio.Entity
{
    [DataContract]
    public class EnGS_ReglasGestiones
    {

        [DataMember]
        public string id_ReglasGestiones { get; set; }
        [DataMember]
        public string nempresa { get; set; }
        [DataMember]
        public string dempresa { get; set; }
        [DataMember]
        public string id_ejecutores { get; set; }
        [DataMember]
        public string Tramo { get; set; }
        [DataMember]
        public string dias_mora_de { get; set; }
        [DataMember]
        public string dias_mora_hasta { get; set; }
        [DataMember]
        public string descripcion { get; set; }
        [DataMember]
        public string garantias { get; set; }
        [DataMember]
        public string provisiones { get; set; }
        [DataMember]
        public string CodUsuario { get; set; }
        [DataMember]
        public string SAnulad { get; set; }
    }
}
