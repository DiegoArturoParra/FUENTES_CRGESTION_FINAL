using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Runtime.Serialization;

namespace Sis.Estudio.Entity
{

        [DataContract]
   public  class EnMoneda
   {

       [DataMember]
        public int CodEmpMoneda { get; set; }
     
       [DataMember]
       public int CodMoneda { get; set; }
       [DataMember]
       public string DesMoneda { get; set; }

       [DataMember]
       public string CodUsuario { get; set; }
    
     

   }
}