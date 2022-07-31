using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Runtime.Serialization;

namespace Sis.Estudio.Entity
{
    [DataContract]
    public class EnTransaccion
    {
        [DataMember]
        public string MENSAJE { get; set; }

        [DataMember]
        public string ID { get; set; }

    }
}
