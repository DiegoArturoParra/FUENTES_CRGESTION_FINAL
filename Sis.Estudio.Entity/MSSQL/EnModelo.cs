using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Runtime.Serialization;

namespace Sis.Estudio.Entity
{
    [DataContract]
    public class EnModelo
    {

        [DataMember]
        public string file { get; set; }
        [DataMember]
        public string title { get; set; }
        [DataMember]
        public string type { get; set; }
    }
}
