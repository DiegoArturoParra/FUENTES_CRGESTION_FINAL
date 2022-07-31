using System;
using System.Collections.Generic;
using System.Text;

#region GENERAL
public struct TipoGrabar
{
    public const string Nuevo = "1";
    public const string Modificar = "2";
    public const string Adicionar = "3";
}
public struct TipoBusqueda
{
    public const string AS400 = "1";
    public const string MSSQL = "2";
}
public struct TipoMoneda
{
    public const string Soles = "0";
    public const string Dolares = "1";
    public const string SimboloSoles = "S/.";
    public const string SimboloDolares = "US$";
}
public struct TitulosPaginas
{
    public const string TITPAGINA_01Conv = "BUSQUEDA - EMPRESA";
    public const string TITPAGINA_01ConvBT = "CONVENIO";
}
public struct Semaforo
{
    public const string ROJO = "3";
    public const string AMBAR = "2";
    public const string VERDE = "1";
}
public struct OpcionModulo
{
    public const string MantPerfil = "2";
    public const string MantUsuario = "3";
    public const string MantAccion = "4";
    public const string MantModulo = "5";

    public const string MantTipoGestiones = "101";
    public const string MantEjecutado = "102";
    public const string MantClaseGestiones = "103";
    public const string MantJerarquiaA = "104";
    public const string MantJerarquiaB = "105";
    public const string MantJerarquiaC = "106";
    public const string MantJerarquiaD = "107";
    public const string MantGestionCobranza = "108";
    public const string MantProcesoCampañas = "109";
    public const string MantBusquedaCampaña = "110";
    public const string MantProgramacionVisitas = "111";
    public const string MantUbigeoColindante = "112";


    public const string EstadoDireccion = "113";
    public const string Garantia = "114";
    public const string SituacionLaboral = "115";
    public const string TipoBien = "116";
    public const string TipoContacto = "117";
    public const string TipoDireccion = "118";
    public const string CalificacionSBS = "119";
    public const string Producto = "120";
    public const string SubProducto = "121";
    public const string Gerencia = "122";
    public const string Zona = "123";
    public const string Sectorista = "124";
    public const string Sucursal = "125";
    public const string Columna = "160";


    public const string MantGestionCarteraCobranza = "127";
    public const string MantReglasGestiones = "128";
    public const string ServEnvioCorreoMasivo = "130";

    public const string MantCartas = "131";


    public const string MantResultadoClasificacion = "135";
    public const string Moneda = "159";





           
    public const string OpcionMenu_08MantRechazosObsDet = "0408";
    public const string OpcionMenu_02MantTCProductoDet = "0402";
    public const string OpcionMenu_MantUsuarioDetalle = "0501";
    public const string OpcionMenu_MantPerfilDetalle = "0403";

    public const string Opcion_Plantilla = "41";

    public const string PD_BotonEliminaTarifario = "0198";
    public const string PD_BotonAgregarTarifario = "0199";

    public const string CN_BotonGrabar_SCI = "0499";
    public const string CN_BotonGrabar_REG = "0498";

}

public struct TipoAcceso
{
    public const string Completo = "1";
    public const string Restringido = "2";
    public const string MSG_Restringido = "";
    public const string MSG_SoloLectura = "";

}

public enum TipoMensaje
{
    Exito = 1,
    Error = 2,
    Advertencia = 3,
    Informacion = 4
}
public struct Mensaje
{
    public const string M_DESACTIVACION_CORRECTA = "Se Desactivó Correctamente";
    public const string M_REGISTRO_CORRECTO = "Se Registro Correctamente.";
    public const string M_INGRESE_DATOS = "Ingrese los Datos";
    public const string M_ANULO_REGISTRO_CORRECTAMENTE = "El registro se anuló correctamente";
    public const string M_MODIFICO_REGISTRO_CORRECTAMENTE = "Se Modificó Correctamente";
    public const string M_MODIFIQUE_DATOS = "Modifique los Datos";
    public const string M_SELECCIONAR_REGISTRO = "Debe seleccionar un Registro";
    public const string M_OPERACION_SATISFACTORIA = "La operación se realizó correctamente";
    public const string M_OPERACION_CANCELADA = "La operación se cancelo";
    public const string M_VALIDACION_DNI = "El campo DNI no puede ser vacío.";
    public const string M_VALIDACION_DEFINICION_ID = "No se ha definido ID";
    public const string M_CERO_REGISTROS = "0 Registros.";
    public const string M_VALIDACION_FECHA = "Debe ingresar una fecha";
    public const string M_VALIDACION_RUC = "Debe ingresar un RUC";
    public const string M_VALIDACION_RAZON_SOCIAL = "Debe ingresar una Razon Social";
    public const string M_VALIDACION_MONTO = "Debe ingresar un Monto";
    public const string M_VALIDACION_FECHA_RENDICION = "Debe ingresar una fecha de rendición";
    public const string M_TEXTO_REGISTROS = " Registros";
    public const string M_CODIGO_INVALIDO = "codigo no válido.";
    public const string M_PROCESO_CORRECTO = "Se Procesó Correctamente";


}
public struct Pagina
{

    //7508
    //public const string URL_HOST = "http://192.168.1.65/Ceem.App";
    public const string URL_HOST = "http://localhost:3029/Ceem.App";
    public const string URL_DOMINIO = "http://localhost:3029";
    //public const string URL_PROYECTO = "/Sis.Estudio.Web"; 
    public const string URL_PROYECTO = "";
    public const string URLACCESSDENIED = "~/Errors/AccessDenied.htm";
    public const string URLSESSIONTIMEOUT = "~/Errors/AccessDenied.htm";
    public const string URLSERVICIOCAIDO = "~/Errors/ServicioCaido.htm";
    public const string URLLOGIN = "~/Login.aspx";
    public const string URLPRUEBA = "~/Prueba.aspx";
    public const string URLPAGINAPUBLICA = "~/Login.aspx";
    public const string URLACTUALIZARPASSWORD = "~/Mantenimientos/Seguridad/ActualizaPassword.aspx";
    public const string URL_CONCAT_ADVERTENCIA = "/Advertencia.aspx";
    public const string URL_CONCAT_LOGIN = "/Login.aspx";
}

public struct UrlImagenTipoMensaje
{
    public const string URLIMAGE_ERROR = "~/imagenes/Mensajes/error.gif";
    public const string URLIMAGE_EXITO = "~/imagenes/Mensajes/exito.gif";
    public const string URLIMAGE_ADVERTENCIA = "~/imagenes/Mensajes/alerta.jpg";
    public const string URLIMAGE_INFORMACION = "~/imagenes/Mensajes/exito.gif";
}

public struct UrlImagenContraerExpander
{
    public const string URLIMAGE_CONTRAER = "~/Image/contraer.jpg";
    public const string URLIMAGE_EXPANDER = "~/Image/expander.jpg";
}
public struct PermisoObjeto
{
    public const string PERMITIDO = "1";
    public const string NOPERMITO = "0";
}
public struct TipoObjeto
{
    public const string VENTANA = "VENTANA";
    public const string OPCION = "OPCION";
    public const string CONTROL = "CONTROL";
    public const string SERVICIO = "SERVICIO";
}
public struct TipoDocumentoIdentidadEnum
{
    public const string DNI = "1";
    public const string RUC = "5";
    public const string CARNETEXTRANJERIA = "2";
    public const string CARNETFFAA = "4";
    public const string CARNETFFPP = "3";
    public const string DPI = "11";
    public const string INSTITUCFINANCIERA = "13";
    public const string MENORDEEDAD = "10";
    public const string ORGANISMOESTATAL = "9";
    public const string PASAPORTE = "7";
    public const string PERSJURSINDOC = "12";

}
public struct NacionalidadEnun
{
    public const string Peru = "589";
}
public struct TipoVerificacionComercialManufactura
{
    public const int Manufactura = 1;
    public const int Servicio = 2;
}
public struct EstadoRegistroGrilla
{
    public const int Ninguno = 0;
    public const int Insertado = 1;
    public const int Modificado = 2;
    public const int Eliminado = 3;

}
public struct Mensajes
{
    public const string MSG_INSERCION_EXITO = "01";
    public const string MSG_INSERCION_ERROR = "02";
    public const string MSG_INSERCION_CONFIRMACION = "03";
    public const string MSG_MODIFICACION_EXITO = "04";
    public const string MSG_MODIFICACION_ERROR = "05";
    public const string MSG_MODIFICACION_CONFIRMACION = "06";
    public const string MSG_ELIMINACION_EXITO = "07";
    public const string MSG_ELIMINACION_ERROR = "08";
    public const string MSG_ELIMINACION_CONFIRMACION = "09";
    public const string MSG_OPERACION_EXITO = "10";
    public const string MSG_OPERACION_ERROR = "11";
    public const string MSG_DATOSINSUFICIENTESPARAPROCESO = "12";
    public const string MSG_OBJETONULL = "13";
    public const string MSG_FAULT_ERROR = "14";
    public const string MSG_COMUNICACION_ERROR = "15";
    public const string MSG_VALIDACION_ERROR = "16";
    public const string MSG_BASESEXTERNAS_EXITO = "17";
    public const string MSG_BASESEXTERNAS_SINPERMISO = "18";
    public const string MSG_BASESEXTERNAS_ERROR = "19";
    public const string MSG_BUSQUEDA_SINRESULTADO = "20";
    public const string MSG_REUTILIZARINFORME_CONFIRMACION = "21";
    public const string MSG_REENVIARVERIFICACION_CONFIRMACION = "22";
    public const string MSG_CULMINAREVALUACION_CONFIRMACION = "23";
    public const string MSG_REINICIAR_FILTROS = "24";
    public const string MSG_GENERAR_REPORTE = "25";
    public const string MSG_OPERACION_CANCELAR = "26";
    public const string MSG_APROBACION_CONFIRMACION = "27";
    public const string MSG_REPROCESOBASESEXTERNAS_EXITO = "28";

    public const string MSG_MENSAJECANCELACION = "La operación se cancelo.";
    public const string MSG_MENSAJESELECCIONARREGISTRO = "Debe seleccionar un Registro";
    public const string MSG_MENSAJERUCVALIDO = "Digite Ruc Válido";

    public const string MSG_MENSAJE_SELECCIONAR_ASESOR = "Debe seleccionar un asesor.";

}
public struct FlagsPrograma
{
    public const string FLG_SINPRODUCTO = "00";
    public const string MSG_SINPRODUCTO = "SIN CONVENIO";
    public const string FLG_SINTIPOCONVENIO = "00";
    public const string FLG_VALORTEXTOVACIO = "";
    public const string FLG_VALORCERO = "0";
    public const string FLG_VALORUNO = "1";
    public const string FLG_VALOREMPRESA = "01";
    public const string FLG_VALOREXITOSI = "si";
    public const string FLG_VALOREXITONO = "no";
    public const string FLG_VALORSISTEMA = "001";
    public const string FLG_VALORIDMODULO = "01";
    public const string FLG_VALORDESMODULO = "Seguridad";
}

public struct TOA
{

    public const int IDOPCION = 0;
    public const int IDOPCIONPADRE = 1;
    public const int NOMBRE = 2;
    public const int TipoOpcion = 3;
    public const int IdAccion = 4;
    public const int Accion = 5;
}

public struct ArbolAccion
{

    public const int idOpcionAccion = 0;
    public const int IdOpcion = 1;
    public const int IdAccion = 2;
    public const int Nombre = 3;

}


public struct Accion
{
    public const string Agregar = "1";
    public const string Modificar = "2";
    public const string Eliminar = "3";
    public const string Consultar = "4";
    public const string ExportaExcel = "5";
    public const string Imprimir = "6";

    public const string Agregar_Perfil = "7";
    public const string Eliminar_Perfil = "8";

    public const string Agregar_Opcion = "9";

}

public struct Mant_Estado
{
    public const string Consulta = "consulta";
    public const string Agrega = "agregar";
    public const string Modifica = "modificar";
}

public struct Mant_ViewState
{
    public const string Estado = "estado";
    public const string ID = "id";
}

public struct AccionListado
{
    public const int Top = 0;
    public const int Filtrado = 1;
    public const int Todos = 2;
}

public struct Extencion
{
    public const string Pdf = "pdf";
    public const string Excel = "excel";
}

public struct Global
{
    public const string CodCliente = "CodCliente";
    public const string NEmpresa = "NEmpresa";
    public const string CodUsuario = "codusuario";

    public const string IdRegProducto = "IdRegProducto";
    public const string IdRegProdAval = "IdRegProdAval";


    //public const string CodEmpresa = "CodEmpresa";
}

public struct EstadoGestion
{
    public const string C_ESTADO_PENDIENTE = "1";
    public const string C_ESTADO_EJECUTADO = "2";
    public const string C_ESTADO_NO_EJECUTADO = "3";
    public const string C_ESTADO_RECHAZADO = "4";
    public const string C_ESTADO_CANCELO = "5";
    public const string C_ESTADO_POR_APROBAR = "6";
    public const string C_ESTADO_DESACTIVADO = "7";
}

public struct Constantes
{
    public const int C_CANTIDAD_ITEMS_FILTROS = 8;
}

public struct TipoDocumento
{
    public const string C_TIPDOC_CARTA = "1";
    public const string C_TIPDOC_IVR = "2";
    public const string C_TIPDOC_CORREO = "3";
    public const string C_TIPDOC_SMS = "4";
    public const string C_TIPDOC_CARTA_CAMPO = "5";
    public const string C_TIPDOC_CARTA_AVAL = "6";
    public const string C_TIPDOC_SMS_AVAL = "7";
    public const string C_TIPDOC_IVR_AVAL = "8";
    public const string C_TIPDOC_CORREO_AVAL = "9";
    public const string C_TIPDOC_WHATSAPP = "10";
    public const string C_TIPDOC_WHATSAPP_AVAL = "11";
}
public struct CantMaxCaracter
{
    public const int C_MAXCAR_CARTA = 5000;
    public const int C_MAXCAR_IVR = -1;
    public const int C_MAXCAR_CORREO = 5000;
    public const int C_MAXCAR_SMS = 160;
    public const int C_MAXCAR_CARTA_CAMPO = 5000;
    public const int C_MAXCAR_CARTA_AVAL = 5000;
    public const int C_MAXCAR_SMS_AVAL = 160;
    public const int C_MAXCAR_IVR_AVAL = -1;
    public const int C_MAXCAR_CORREO_AVAL = 5000;
    public const int C_MAXCAR_WHATSAPP = 200;
    public const int C_MAXCAR_WHATSAPP_AVAL = 200;
}

#endregion GENERAL
