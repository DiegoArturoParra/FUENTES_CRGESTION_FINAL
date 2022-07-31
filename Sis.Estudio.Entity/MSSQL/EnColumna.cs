using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace Sis.Estudio.Entity
{
    [DataContract]
    public class EnColumna
    {
        [DataMember]
        public string nIdColumna { get; set; }
        [DataMember]
        public string nIdUser { get; set; }
        [DataMember]
        public string nIdTabla { get; set; }
        [DataMember]
        public string cNombreColumna { get; set; }
        [DataMember]
        public string cValor { get; set; }
        [DataMember]
        public string lActivo { get; set; }
        [DataMember]
        public string lVisible { get; set; }
        [DataMember]
        public string nOrden { get; set; }
        [DataMember]
        public string cDescripcion { get; set; }
        [DataMember]
        public string lModificable { get; set; }
        [DataMember]
        public string lCampoOrigen { get; set; }
        [DataMember]
        public string cTipoCampo { get; set; }
        [DataMember]
        public string cTipoDato { get; set; }
        [DataMember]
        public string nLongDato { get; set; }
        [DataMember]
        public string lObligatorio { get; set; }
        [DataMember]
        public string dFechaRegistro { get; set; }
        [DataMember]
        public string dFechaModificacion { get; set; }
        [DataMember]
        public string nEmpresa { get; set; }

    }
}
