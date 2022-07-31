using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace Sis.Estudio.Entity
{
    [DataContract]
    public class EnTipoBien
    {
        [DataMember]
        public string CodTipoBien { get; set; }
        [DataMember]
        public string TipoBien { get; set; }
        [DataMember]
        public string Estado { get; set; }
        [DataMember]
        public string CodUsuario { get; set; }
        [DataMember]
        public string NEmpresa { get; set; }
        

    }
}
