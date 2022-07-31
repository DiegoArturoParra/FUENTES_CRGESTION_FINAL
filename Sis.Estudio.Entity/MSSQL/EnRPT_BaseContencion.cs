using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;
namespace Sis.Estudio.Entity
{
    [DataContract]
    public class EnRPT_BaseContencion
    {
        //[DataMember]
        //public string IdRPT_BaseContencion { get; set; }
        [DataMember]
        public string NEmpresa { get; set; }
        [DataMember]
        public string Tramo { get; set; }
        [DataMember]
        public string Anio { get; set; }
        [DataMember]
        public string AnioInt { get; set; }
        [DataMember]
        public string Mes { get; set; }
        [DataMember]
        public string MesInt { get; set; }
        [DataMember]
        public string Anio_Mes { get; set; }
        [DataMember]
        public string TipoCredito { get; set; }
        [DataMember]
        public string Contencion { get; set; }
        [DataMember]
        public string MesIntInicio { get; set; }
        [DataMember]
        public string MesIntFin { get; set; }
        [DataMember]
        public string AnioIntInicio { get; set; }
        [DataMember]
        public string AnioIntFin { get; set; }
    }
}
