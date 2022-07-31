using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Runtime.Serialization;

namespace Sis.Estudio.Entity
{
    [DataContract]
    public class EnCargaTercero
    {
        [DataMember]
        public string NEmpresa { get; set; }
        [DataMember]
        public string dni { get; set; }
        [DataMember]
        public string CodProducto { get; set; }
        [DataMember]
        public string CodSubProducto { get; set; }
        [DataMember]
        public string CodTipoGestion { get; set; }
        [DataMember]
        public string CodResultado { get; set; }
        [DataMember]
        public string CodEjecutado { get; set; }
        [DataMember]
        public string CodEstadoGestionCobranza { get; set; }
        [DataMember]
        public string CodUsuario_Asesores { get; set; }
        [DataMember]
        public string FechaResultado { get; set; }
        [DataMember]
        public string FechaRegistra { get; set; }
        [DataMember]
        public string CodUsuario_Ejecutor { get; set; }
        [DataMember]
        public string Comentario { get; set; }
    }
}