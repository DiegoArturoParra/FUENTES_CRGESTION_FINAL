using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace Sis.Estudio.Entity
{
    [DataContract]
    public class EnAvalDireccio
    {

        [DataMember]
        public string NEmpresa { get; set; }
        [DataMember]
        public string CodigoCliente { get; set; }
        [DataMember]
        public string CodTipoDir { get; set; }
        [DataMember]
        public string Dir { get; set; }
        [DataMember]
        public string ubigeo { get; set; }
        [DataMember]
        public string Referencia { get; set; }
        [DataMember]
        public string GeoX { get; set; }
        [DataMember]
        public string GeoY { get; set; }
        [DataMember]
        public string CodEstadoDir { get; set; }
        [DataMember]
        public string Orden { get; set; }
        [DataMember]
        public string CodUsuario { get; set; }
        [DataMember]
        public string IdReg { get; set; }
        [DataMember]
        public string IdRegProdAval { get; set; }


    }
}
