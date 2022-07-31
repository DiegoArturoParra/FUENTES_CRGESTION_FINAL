using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Runtime.Serialization;
namespace Sis.Estudio.Entity
{
    [DataContract]
    public class EnPerfil
    {
        [DataMember]
        public string Accion { get; set; }
        [DataMember]
        public string IdModulo { get; set; }
        [DataMember]
        public string IdPerfil { get; set; }
        [DataMember]
        public string IdOpcion { get; set; }
        [DataMember]
        public string IdAccion { get; set; }
        [DataMember]
        public string CEmpresa { get; set; }
        [DataMember]
        public string Nombre { get; set; }
        [DataMember]
        public string Descripcion { get; set; }
        [DataMember]
        public string VersionPerfil { get; set; }
        [DataMember]
        public string SAnulad { get; set; }
        [DataMember]
        public string CodSistema { get; set; }
        [DataMember]
        public string CodModulo { get; set; }
        [DataMember]
        public string CodOpcion { get; set; }
        [DataMember]
        public string CodUsuario { get; set; }


    }
}
