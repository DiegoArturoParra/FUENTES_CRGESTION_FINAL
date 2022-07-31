using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Runtime.Serialization;

namespace Sis.Estudio.Entity
{

    [DataContract]
    public class EnCargaInicialMasiva
    {
        [DataMember]
        public string NEmpresa { get; set; }
        [DataMember]
        public string sg_orden { get; set; }
        [DataMember]
        public string sg_documento { get; set; }
        [DataMember]
        public string firstname { get; set; }

        [DataMember]
        public string ApePat { get; set; }
        [DataMember]
        public string ApeMat { get; set; }


        [DataMember]
        public string code { get; set; }
        [DataMember]
        public string address { get; set; }
        [DataMember]
        public string city { get; set; }
        [DataMember]
        public string telephonehome { get; set; }
        [DataMember]
        public string telephonework { get; set; }
        [DataMember]
        public string telephonecel { get; set; }
        [DataMember]
        public string telephone4 { get; set; }
        [DataMember]
        public string telephone5 { get; set; }
        [DataMember]
        public string telephone6 { get; set; }
        [DataMember]
        public string telephone7 { get; set; }
        [DataMember]
        public string telephone8 { get; set; }
        [DataMember]
        public string telephone9 { get; set; }
        [DataMember]
        public string telephone10 { get; set; }
        [DataMember]
        public string telephone11 { get; set; }
        [DataMember]
        public string telephone12 { get; set; }
        [DataMember]
        public string telephone13 { get; set; }
        [DataMember]
        public string telephone14 { get; set; }
        [DataMember]
        public string telephone15 { get; set; }
        [DataMember]
        public string telephone16 { get; set; }
        [DataMember]
        public string telephone17 { get; set; }
        [DataMember]
        public string telephone18 { get; set; }
        [DataMember]
        public string telephone19 { get; set; }
        [DataMember]
        public string telephone20 { get; set; }

        /*Modificado el 27092016 para el envío de correos*/
        [DataMember]
        public string correo { get; set; }
        /*Fin de la modificación*/

        [DataMember]
        public string state { get; set; }
        [DataMember]
        public string sg_comentario { get; set; }
        [DataMember]
        public string sg_situacion_cuenta { get; set; }
        [DataMember]
        public string sg_protesto { get; set; }
        [DataMember]
        public string sg_saldo_adeudado { get; set; }
        [DataMember]
        public string sg_contencion { get; set; }
        [DataMember]
        public string sg_fecha_castigo { get; set; }
        [DataMember]
        public string sg_numero_tarjeta { get; set; }
        [DataMember]
        public string sg_fecha_ultimo_pago { get; set; }
        [DataMember]
        public string sg_cliente_pago { get; set; }
        [DataMember]
        public string cm_monto { get; set; }
        [DataMember]
        public string cm_cuotas_pagadas { get; set; }
        [DataMember]
        public string cm_monto_desembolsado { get; set; }
        [DataMember]
        public string cm_dias_de_atraso { get; set; }
        [DataMember]
        public string cm_AGENCIA { get; set; }
        [DataMember]
        public string cm_CodCliente { get; set; }
        [DataMember]
        public string cm_TipoDomicilio1 { get; set; }
        [DataMember]
        public string cm_Provincia1 { get; set; }
        [DataMember]
        public string cm_Distrito1 { get; set; }
        [DataMember]
        public string cm_TipoDomicilio2 { get; set; }
        [DataMember]
        public string cm_Domicilio2 { get; set; }
        [DataMember]
        public string cm_Distrito2 { get; set; }
        [DataMember]
        public string cm_Provincia2 { get; set; }
        [DataMember]
        public string cm_Departamento2 { get; set; }
        [DataMember]
        public string cm_TipoDomicilio3 { get; set; }
        [DataMember]
        public string cm_Domicilio3 { get; set; }
        [DataMember]
        public string cm_Distrito3 { get; set; }
        [DataMember]
        public string cm_Provincia3 { get; set; }
        [DataMember]
        public string cm_Departamento3 { get; set; }
        [DataMember]
        public string cm_FechDesemb { get; set; }
        [DataMember]
        public string cm_ESTADO { get; set; }
        [DataMember]
        public string cm_Condicion { get; set; }
        [DataMember]
        public string cm_Moneda { get; set; }
        [DataMember]
        public string ci_capital { get; set; }
        [DataMember]
        public string cmc_fecha_facturacion { get; set; }
        [DataMember]
        public string cmc_fecha_vencimiento { get; set; }
        [DataMember]
        public string cmc_pago_minimo { get; set; }
        [DataMember]
        public string cmc_monto_facturado { get; set; }
        [DataMember]
        public string cmc_mora_saldo_facturado { get; set; }
        [DataMember]
        public string cmc_estatus { get; set; }
        [DataMember]
        public string fsol_cartera { get; set; }
        [DataMember]
        public string f_tramo_atraso { get; set; }
        [DataMember]
        public string fsol_fpv { get; set; }
        [DataMember]
        public string fsol_fup { get; set; }
        [DataMember]
        public string Producto { get; set; }
        [DataMember]
        public string SubProducto { get; set; }
        /*Insertar Georeferencia 22/05/2017*/
        [DataMember]
        public string GeoX { get; set; }
        [DataMember]
        public string GeoY { get; set; }




        [DataMember]
        public string sg_responsable { get; set; }
        [DataMember]
        public string code_aval { get; set; }
        [DataMember]
        public string firstname_aval { get; set; }
        [DataMember]
        public string apepat_aval { get; set; }
        [DataMember]
        public string apemat_aval { get; set; }
        [DataMember]
        public string telephonehome_aval { get; set; }
        [DataMember]
        public string sg_comentario_aval { get; set; }

    }
}
