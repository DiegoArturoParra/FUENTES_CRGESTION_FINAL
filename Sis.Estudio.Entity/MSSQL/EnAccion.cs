using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Runtime.Serialization;




namespace Sis.Estudio.Entity
{
    [DataContract]
    public class EnAccion
    {


        [DataMember]
        public string Tipo { get; set; }
      
        [DataMember]
        public string Id { get; set; }
        [DataMember]
        public string Accion { get; set; }
        [DataMember]
        public string CEmpresa { get; set; }
        [DataMember]
        public string CodSistema { get; set; }
        [DataMember]
        public string Nombre { get; set; }
        [DataMember]
        public string Descripcion { get; set; }
        [DataMember]
        public string CodUsuario { get; set; }
        [DataMember]
        public string FechaRegistra { get; set; }
        [DataMember]
        public string FlagSinc { get; set; }
        [DataMember]
        public string FechaSincronizacion { get; set; }
        
    }
}
