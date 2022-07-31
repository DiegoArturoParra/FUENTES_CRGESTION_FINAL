using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Runtime.Serialization;


namespace Sis.Estudio.Entity
{
    [DataContract]
    public class EnGS_Gestion_Cobranza
    {

        [DataMember]
        public string IdReg_Gestion_Cobranza { get; set; }
        [DataMember]
        public string IdReg { get; set; }
        [DataMember]
        public string CodigoCliente { get; set; }
        [DataMember]
        public string DNI { get; set; }
        [DataMember]
        public string RUC { get; set; }
        [DataMember]
        public string RazonSocial { get; set; }

        [DataMember]
        public string ApePat { get; set; }
        [DataMember]
        public string ApeMat { get; set; }
        [DataMember]
        public string Nombres { get; set; }

        [DataMember]
        public string Producto { get; set; }
        [DataMember]
        public string SubProducto { get; set; }
        [DataMember]
        public string Id_tipo_accion_gestion { get; set; }
        [DataMember]
        public string Desc_tipo_accion_gestion { get; set; }
        [DataMember]
        public string CodCLaseGestion { get; set; }
        [DataMember]
        public string Descripcion_ClaseGestion { get; set; }
        [DataMember]
        public string CodEjecutado { get; set; }
        [DataMember]
        public string Descripcion_Ejecutado { get; set; }
        [DataMember]
        public string CodTipoGestion { get; set; }
        [DataMember]
        public string Descripcion_TipoGestion { get; set; }
        [DataMember]
        public string Id_estado_gestion_cobranza { get; set; }
        [DataMember]
        public string Desc_estado_gestion_cobranza { get; set; }
        [DataMember]
        public string Id_ejecutores { get; set; }
        [DataMember]
        public string Desc_ejecutores { get; set; }
        [DataMember]
        public string CodUsuario_Recuperador { get; set; }
        [DataMember]
        public string Recuperador  { get; set; }
        [DataMember]
        public string Asesores { get; set; }
        [DataMember]
        public string CodUsuario_Asesores { get; set; }
        [DataMember]
        public string CodUsuario_Reasignado { get; set; }

        [DataMember]
        public string FechaResultado { get; set; }
        [DataMember]
        public string nEmpresa { get; set; }
        [DataMember]
        public string CodUsuario { get; set; }
        [DataMember]
        public string Accion { get; set; }
        [DataMember]
        public string comentario { get; set; }
        [DataMember]
        public string fecha_ini { get; set; }
        [DataMember]
        public string fecha_fin { get; set; }

        [DataMember]
        public string id_campaña { get; set; }

        [DataMember]
        public string FechaVisita { get; set; }

        [DataMember]
        public string FechaVisita_dmy { get; set; }
        [DataMember]
        public string FechaVisita_hh { get; set; }
        [DataMember]
        public string FechaVisita_mm { get; set; }


        [DataMember]
        public string cod_jerarquiaA { get; set; }
        [DataMember]
        public string cod_jerarquiaB { get; set; }
        [DataMember]
        public string cod_jerarquiaC { get; set; }
        [DataMember]
        public string cod_jerarquiaD { get; set; }


        [DataMember]
        public string Descripcion_carta { get; set; }
        [DataMember]
        public string Pie_carta { get; set; }
        [DataMember]
        public int Num_carta { get; set; }
        [DataMember]
        public string id_carta { get; set; }

        [DataMember]
        public string Nombre { get; set; }



        [DataMember]
        public string MontoCuota { get; set; }
        [DataMember]
        public string dias_mora { get; set; }
        [DataMember]
        public string dias_mora_hasta { get; set; }
        [DataMember]
        public string Distrito { get; set; }
        [DataMember]
        public string CodTipoDir { get; set; }
        [DataMember]
        public string Convenio { get; set; }
        [DataMember]
        public string TelefonoSi { get; set; }
        [DataMember]
        public string Id_carga { get; set; }

        [DataMember]
        public string documento { get; set; }

        [DataMember]
        public string Obs { get; set; }


        [DataMember]
        public string FechaReagenda_dmy { get; set; }
        [DataMember]
        public string FechaReagenda_hh { get; set; }
        [DataMember]
        public string FechaReagenda_mm { get; set; }
        [DataMember]
        public string FechaReagenda { get; set; }

        [DataMember]
        public string Tramo { get; set; }
        [DataMember]
        public string TramoAcelerado { get; set; }

        [DataMember]
        public string FechaLimite { get; set; }
        [DataMember]
        public string CodUsuarioNuevo { get; set; }
        [DataMember]
        public string CodEstadoInterno { get; set; }
        [DataMember]
        public string FechaTomaControl { get; set; }

        [DataMember]
        public string Grupo { get; set; }

    }
}
    