using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Runtime.Serialization;

namespace Sis.Estudio.Entity
{
    [DataContract]
    public class EnLogin
    {
        [DataMember]
        public string CEMPRESA { get; set; }
        [DataMember]
        public string LOGIN { get; set; }
        [DataMember]
        public string CODUSUARIO { get; set; }
        [DataMember]
        public string PASSWORD { get; set; }
        [DataMember]
        public string IDMODULO { get; set; }
        [DataMember]
        public string KeyLogin { get; set; }

        
    }
}