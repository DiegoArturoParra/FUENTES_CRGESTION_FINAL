using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace Sis.Estudio.Entity
{

    [DataContract]
    public class EnTipoDireccion
    {

        [DataMember]
        public string CodTipoDireccion { get; set; }
        [DataMember]
        public string TipoDireccion { get; set; }
        [DataMember]
        public string Estado { get; set; }
        [DataMember]
        public string CodUsuario { get; set; }
        [DataMember]
        public string CodTipoDir { get; set; }        
        [DataMember]
        public string NEmpresa { get; set; }
        


    }
}
