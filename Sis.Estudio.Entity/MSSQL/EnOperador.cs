using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace Sis.Estudio.Entity
{
    [DataContract]
    public class EnOperador
    {
        [DataMember]
        public string nIdOperador { get; set; }
        [DataMember]
        public string cOperador { get; set; }
        [DataMember]
        public string cLogica { get; set; }
        [DataMember]
        public string cDescripcion { get; set; }
        [DataMember]
        public string lNumero { get; set; }
        [DataMember]
        public string lCadena { get; set; }
        [DataMember]
        public string lFecha { get; set; }
    }
}
