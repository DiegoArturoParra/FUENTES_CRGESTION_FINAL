
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Runtime.Serialization;

namespace Sis.Estudio.Entity
{
    [DataContract]
    public class EnGS_Carta
    {

        [DataMember]
        public string id_carta { get; set; }
        [DataMember]
        public string Descripcion { get; set; }
        [DataMember]
        public string Pie { get; set; }
        [DataMember]
        public string Num_carta { get; set; }
        [DataMember]
        public string nEmpresa { get; set; }
        [DataMember]
        public string CodUsuario { get; set; }
        [DataMember]
        public string nombre { get; set; }
        [DataMember]
        public string CodTipoDocum { get; set; }
         [DataMember]
        public string CodTipoGestion { get; set; }
        
        [DataMember]
        public string Descrip { get; set; }

        
    }
}
