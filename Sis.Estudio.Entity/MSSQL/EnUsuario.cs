using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Runtime.Serialization;


namespace Sis.Estudio.Entity
{
    [DataContract]
    public class EnUsuario
    {

        [DataMember]
        public string id { get; set; }
        [DataMember]
        public string IdPerfil { get; set; }        
        [DataMember]
        public string IdUsuarioPerfil { get; set; }                
        [DataMember]
        public string CEmpresa { get; set; }
        [DataMember]
        public string Tipo { get; set; }
        [DataMember]
        public string codUsuario { get; set; }
        [DataMember]
        public string Accion { get; set; }
        [DataMember]
        public string nombreusuario { get; set; }
        [DataMember]
        public string login3 { get; set; }
        [DataMember]
        public string Password { get; set; }
        [DataMember]
        public string PasswordNuevo { get; set; }
        [DataMember]
        public string Sbloqueado { get; set; }
        [DataMember]
        public string FechaRegistra { get; set; }
        [DataMember]
        public string FlagSinc { get; set; }
        [DataMember]
        public string FechaSincronizacion { get; set; }
        [DataMember]
        public string email { get; set; }

        [DataMember]
        public string paterno { get; set; }
        [DataMember]
        public string materno { get; set; }
        [DataMember]
        public string nombre1 { get; set; }
        [DataMember]
        public string dni { get; set; }

        [DataMember]
        public string cod_jerarquiaA { get; set; }
        [DataMember]
        public string cod_jerarquiaB { get; set; }
        [DataMember]
        public string cod_jerarquiaC { get; set; }
        [DataMember]
        public string cod_jerarquiaD { get; set; }
        [DataMember]
        public string id_ejecutores { get; set; }

        
    }
}
