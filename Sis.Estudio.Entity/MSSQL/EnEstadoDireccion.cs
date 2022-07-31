using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace Sis.Estudio.Entity
{
    [DataContract]
    public class EnEstadoDireccion
    {

        [DataMember]
        public string NEmpresa { get; set; }
        [DataMember]
        public string CodEstadoDir { get; set; }
        [DataMember]
        public string Descrip { get; set; }
        [DataMember]
        public string Estado { get; set; }
        [DataMember]
        public string CodUsuario { get; set; }        

    }
}
