using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using Sis.Estudio.Entity;

namespace Sis.Estudio.Data.MSSQL.Estudio
{
    public class DaGaranxProduc : DaConexion
    {
        

        public void Garantia_Producto_INS(List<EnGaranxProduc> ListEnGaranxProduc, SqlTransaction tran)
        {
            try
            {
                #region Parametros
                SqlParameter prm_NEMPRESA = new SqlParameter();
                SqlParameter prm_CODIGOCLIENTE = new SqlParameter();
                SqlParameter prm_IDREGPRODUCTOS = new SqlParameter();
                SqlParameter prm_CODGARANTIA = new SqlParameter();
                SqlParameter prm_CODTIPOBIEN = new SqlParameter();
                SqlParameter prm_DESCRIPBIEN = new SqlParameter();
                SqlParameter prm_TELEFONOS = new SqlParameter();
                SqlParameter prm_PROPIETARIOS = new SqlParameter();
                SqlParameter prm_NOMBREGARANTE = new SqlParameter();
                SqlParameter prm_BENEFICIARIO = new SqlParameter();
                SqlParameter prm_UBICACION = new SqlParameter();
                SqlParameter prm_DIRECCION = new SqlParameter();
                SqlParameter prm_AREA = new SqlParameter();
                SqlParameter prm_DNI = new SqlParameter();
                SqlParameter prm_VALORCOMERCIAL = new SqlParameter();
                SqlParameter prm_MONTOGARANTIA = new SqlParameter();
                SqlParameter prm_CARTAFIANZA = new SqlParameter();
                SqlParameter prm_FECHAULTTASACION = new SqlParameter();
                SqlParameter prm_VENCIMIENTOCF = new SqlParameter();
                SqlParameter prm_VALORGRAVAMEN = new SqlParameter();
                SqlParameter prm_NUMPARTIDAELEC = new SqlParameter();
                SqlParameter prm_OBSERVACION = new SqlParameter();
                SqlParameter prm_RESTRICCIONES = new SqlParameter();
                SqlParameter prm_COBERTURACF = new SqlParameter();
                SqlParameter prm_ESTADO = new SqlParameter();
                SqlParameter prm_CODUSUARIO = new SqlParameter();
                #endregion Parametros


                #region Values
                #region nempresa
                prm_NEMPRESA.ParameterName = "@nempresa";
                prm_NEMPRESA.SqlDbType = SqlDbType.Int;
                prm_NEMPRESA.Direction = ParameterDirection.Input;
                prm_NEMPRESA.Value = ListEnGaranxProduc[0].NEmpresa;
                #endregion nempresa
                #region CodigoCliente
                prm_CODIGOCLIENTE.ParameterName = "@CodigoCliente";
                prm_CODIGOCLIENTE.SqlDbType = SqlDbType.Int;
                prm_CODIGOCLIENTE.Direction = ParameterDirection.Input;
                prm_CODIGOCLIENTE.Value = ListEnGaranxProduc[0].CodigoCliente;
                #endregion CodigoCliente
                #region IdRegProductos
                prm_IDREGPRODUCTOS.ParameterName = "@IdRegProductos";
                prm_IDREGPRODUCTOS.SqlDbType = SqlDbType.Int;
                prm_IDREGPRODUCTOS.Direction = ParameterDirection.Input;
                prm_IDREGPRODUCTOS.Value = ListEnGaranxProduc[0].IdRegProductos;
                #endregion IdRegProductos
                #region CodGarantia
                prm_CODGARANTIA.ParameterName = "@CodGarantia";
                prm_CODGARANTIA.SqlDbType = SqlDbType.Int;
                prm_CODGARANTIA.Direction = ParameterDirection.Input;
                prm_CODGARANTIA.Value = ListEnGaranxProduc[0].CodGarantia;
                #endregion CodGarantia
                #region CodTipoBien
                prm_CODTIPOBIEN.ParameterName = "@CodTipoBien";
                prm_CODTIPOBIEN.SqlDbType = SqlDbType.Int;
                prm_CODTIPOBIEN.Direction = ParameterDirection.Input;
                prm_CODTIPOBIEN.Value = ListEnGaranxProduc[0].CodTipoBien;
                #endregion CodTipoBien
                #region DescripBien
                prm_DESCRIPBIEN.ParameterName = "@DescripBien";
                prm_DESCRIPBIEN.SqlDbType = SqlDbType.VarChar;
                prm_DESCRIPBIEN.Direction = ParameterDirection.Input;
                prm_DESCRIPBIEN.Size = 500;
                prm_DESCRIPBIEN.Value = ListEnGaranxProduc[0].DescripBien;
                #endregion DescripBien
                #region Telefonos
                prm_TELEFONOS.ParameterName = "@Telefonos";
                prm_TELEFONOS.SqlDbType = SqlDbType.VarChar;
                prm_TELEFONOS.Direction = ParameterDirection.Input;
                prm_TELEFONOS.Size = 60;
                prm_TELEFONOS.Value = ListEnGaranxProduc[0].Telefonos;
                #endregion Telefonos
                #region Propietarios
                prm_PROPIETARIOS.ParameterName = "@Propietarios";
                prm_PROPIETARIOS.SqlDbType = SqlDbType.VarChar;
                prm_PROPIETARIOS.Direction = ParameterDirection.Input;
                prm_PROPIETARIOS.Size = 120;
                prm_PROPIETARIOS.Value = ListEnGaranxProduc[0].Propietarios;
                #endregion Propietarios
                #region NombreGarante
                prm_NOMBREGARANTE.ParameterName = "@NombreGarante";
                prm_NOMBREGARANTE.SqlDbType = SqlDbType.VarChar;
                prm_NOMBREGARANTE.Direction = ParameterDirection.Input;
                prm_NOMBREGARANTE.Size = 120;
                prm_NOMBREGARANTE.Value = ListEnGaranxProduc[0].NombreGarante;
                #endregion NombreGarante
                #region Beneficiario
                prm_BENEFICIARIO.ParameterName = "@Beneficiario";
                prm_BENEFICIARIO.SqlDbType = SqlDbType.VarChar;
                prm_BENEFICIARIO.Direction = ParameterDirection.Input;
                prm_BENEFICIARIO.Size = 120;
                prm_BENEFICIARIO.Value = ListEnGaranxProduc[0].Beneficiario;
                #endregion Beneficiario
                #region Ubicacion
                prm_UBICACION.ParameterName = "@Ubicacion";
                prm_UBICACION.SqlDbType = SqlDbType.VarChar;
                prm_UBICACION.Direction = ParameterDirection.Input;
                prm_UBICACION.Size = 120;
                prm_UBICACION.Value = ListEnGaranxProduc[0].Ubicacion;
                #endregion Ubicacion
                #region Direccion
                prm_DIRECCION.ParameterName = "@Direccion";
                prm_DIRECCION.SqlDbType = SqlDbType.VarChar;
                prm_DIRECCION.Direction = ParameterDirection.Input;
                prm_DIRECCION.Size = 120;
                prm_DIRECCION.Value = ListEnGaranxProduc[0].Direccion;
                #endregion Direccion
                #region area
                prm_AREA.ParameterName = "@area";
                prm_AREA.SqlDbType = SqlDbType.VarChar;
                prm_AREA.Direction = ParameterDirection.Input;
                prm_AREA.Size = 60;
                prm_AREA.Value = ListEnGaranxProduc[0].area;
                #endregion area
                #region DNI
                prm_DNI.ParameterName = "@DNI";
                prm_DNI.SqlDbType = SqlDbType.Char;
                prm_DNI.Direction = ParameterDirection.Input;
                prm_DNI.Size = 8;
                prm_DNI.Value = ListEnGaranxProduc[0].DNI;
                #endregion DNI
                #region ValorComercial
                prm_VALORCOMERCIAL.ParameterName = "@ValorComercial";
                prm_VALORCOMERCIAL.SqlDbType = SqlDbType.Decimal;
                prm_VALORCOMERCIAL.Direction = ParameterDirection.Input;
                prm_VALORCOMERCIAL.Value = ListEnGaranxProduc[0].ValorComercial;
                #endregion ValorComercial
                #region MontoGarantia
                prm_MONTOGARANTIA.ParameterName = "@MontoGarantia";
                prm_MONTOGARANTIA.SqlDbType = SqlDbType.Decimal;
                prm_MONTOGARANTIA.Direction = ParameterDirection.Input;
                prm_MONTOGARANTIA.Value = ListEnGaranxProduc[0].MontoGarantia;
                #endregion MontoGarantia
                #region CartaFianza
                prm_CARTAFIANZA.ParameterName = "@CartaFianza";
                prm_CARTAFIANZA.SqlDbType = SqlDbType.Decimal;
                prm_CARTAFIANZA.Direction = ParameterDirection.Input;
                prm_CARTAFIANZA.Value = ListEnGaranxProduc[0].CartaFianza;
                #endregion CartaFianza
                #region FechaUltTasacion
                prm_FECHAULTTASACION.ParameterName = "@FechaUltTasacion";
                prm_FECHAULTTASACION.SqlDbType = SqlDbType.DateTime;
                prm_FECHAULTTASACION.Direction = ParameterDirection.Input;
                prm_FECHAULTTASACION.Value = ListEnGaranxProduc[0].FechaUltTasacion;
                #endregion FechaUltTasacion
                #region VencimientoCF
                prm_VENCIMIENTOCF.ParameterName = "@VencimientoCF";
                prm_VENCIMIENTOCF.SqlDbType = SqlDbType.DateTime;
                prm_VENCIMIENTOCF.Direction = ParameterDirection.Input;
                prm_VENCIMIENTOCF.Value = ListEnGaranxProduc[0].VencimientoCF;
                #endregion VencimientoCF
                #region ValorGravamen
                prm_VALORGRAVAMEN.ParameterName = "@ValorGravamen";
                prm_VALORGRAVAMEN.SqlDbType = SqlDbType.Decimal;
                prm_VALORGRAVAMEN.Direction = ParameterDirection.Input;
                prm_VALORGRAVAMEN.Value = ListEnGaranxProduc[0].ValorGravamen;
                #endregion ValorGravamen
                #region NumPartidaElec
                prm_NUMPARTIDAELEC.ParameterName = "@NumPartidaElec";
                prm_NUMPARTIDAELEC.SqlDbType = SqlDbType.VarChar;
                prm_NUMPARTIDAELEC.Direction = ParameterDirection.Input;
                prm_NUMPARTIDAELEC.Size = 20;
                prm_NUMPARTIDAELEC.Value = ListEnGaranxProduc[0].NumPartidaElec;
                #endregion NumPartidaElec
                #region Observacion
                prm_OBSERVACION.ParameterName = "@Observacion";
                prm_OBSERVACION.SqlDbType = SqlDbType.VarChar;
                prm_OBSERVACION.Direction = ParameterDirection.Input;
                prm_OBSERVACION.Size = 200;
                prm_OBSERVACION.Value = ListEnGaranxProduc[0].Observacion;
                #endregion Observacion
                #region Restricciones
                prm_RESTRICCIONES.ParameterName = "@Restricciones";
                prm_RESTRICCIONES.SqlDbType = SqlDbType.VarChar;
                prm_RESTRICCIONES.Direction = ParameterDirection.Input;
                prm_RESTRICCIONES.Size = 200;
                prm_RESTRICCIONES.Value = ListEnGaranxProduc[0].Restricciones;
                #endregion Restricciones
                #region CoberturaCF
                prm_COBERTURACF.ParameterName = "@CoberturaCF";
                prm_COBERTURACF.SqlDbType = SqlDbType.VarChar;
                prm_COBERTURACF.Direction = ParameterDirection.Input;
                prm_COBERTURACF.Size = 120;
                prm_COBERTURACF.Value = ListEnGaranxProduc[0].CoberturaCF;
                #endregion CoberturaCF
                #region Estado
                prm_ESTADO.ParameterName = "@Estado";
                prm_ESTADO.SqlDbType = SqlDbType.Char;
                prm_ESTADO.Direction = ParameterDirection.Input;
                prm_ESTADO.Size = 1;
                prm_ESTADO.Value = ListEnGaranxProduc[0].Estado;
                #endregion Estado
                #region CodUsuario
                prm_CODUSUARIO.ParameterName = "@CodUsuario";
                prm_CODUSUARIO.SqlDbType = SqlDbType.Int;
                prm_CODUSUARIO.Direction = ParameterDirection.Input;
                prm_CODUSUARIO.Value = ListEnGaranxProduc[0].CodUsuario;
                #endregion CodUsuario
                #endregion Values



                #region Execute
                SqlHelper.ExecuteNonQuery(tran, "CR_Cliente_sp_InsertarPRODGar",
                                               prm_NEMPRESA,
                                               prm_CODIGOCLIENTE,
                                               prm_IDREGPRODUCTOS,
                                               prm_CODGARANTIA,
                                               prm_CODTIPOBIEN,
                                               prm_DESCRIPBIEN,
                                               prm_TELEFONOS,
                                               prm_PROPIETARIOS,
                                               prm_NOMBREGARANTE,
                                               prm_BENEFICIARIO,
                                               prm_UBICACION,
                                               prm_DIRECCION,
                                               prm_AREA,
                                               prm_DNI,
                                               prm_VALORCOMERCIAL,
                                               prm_MONTOGARANTIA,
                                               prm_CARTAFIANZA,
                                               prm_FECHAULTTASACION,
                                               prm_VENCIMIENTOCF,
                                               prm_VALORGRAVAMEN,
                                               prm_NUMPARTIDAELEC,
                                               prm_OBSERVACION,
                                               prm_RESTRICCIONES,
                                               prm_COBERTURACF,
                                               prm_ESTADO,
                                               prm_CODUSUARIO
                                               );
                #endregion Execute
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void Garantia_Producto_UPD(List<EnGaranxProduc> ListEnGaranxProduc, SqlTransaction tran)
        {
            try
            {
                #region Parametros
                SqlParameter prm_IDREG = new SqlParameter();
                SqlParameter prm_NEMPRESA = new SqlParameter();
                SqlParameter prm_CODIGOCLIENTE = new SqlParameter();
                SqlParameter prm_IDREGPRODUCTOS = new SqlParameter();
                SqlParameter prm_CODGARANTIA = new SqlParameter();
                SqlParameter prm_CODTIPOBIEN = new SqlParameter();
                SqlParameter prm_DESCRIPBIEN = new SqlParameter();
                SqlParameter prm_TELEFONOS = new SqlParameter();
                SqlParameter prm_PROPIETARIOS = new SqlParameter();
                SqlParameter prm_NOMBREGARANTE = new SqlParameter();
                SqlParameter prm_BENEFICIARIO = new SqlParameter();
                SqlParameter prm_UBICACION = new SqlParameter();
                SqlParameter prm_DIRECCION = new SqlParameter();
                SqlParameter prm_AREA = new SqlParameter();
                SqlParameter prm_DNI = new SqlParameter();
                SqlParameter prm_VALORCOMERCIAL = new SqlParameter();
                SqlParameter prm_MONTOGARANTIA = new SqlParameter();
                SqlParameter prm_CARTAFIANZA = new SqlParameter();
                SqlParameter prm_FECHAULTTASACION = new SqlParameter();
                SqlParameter prm_VENCIMIENTOCF = new SqlParameter();
                SqlParameter prm_VALORGRAVAMEN = new SqlParameter();
                SqlParameter prm_NUMPARTIDAELEC = new SqlParameter();
                SqlParameter prm_OBSERVACION = new SqlParameter();
                SqlParameter prm_RESTRICCIONES = new SqlParameter();
                SqlParameter prm_COBERTURACF = new SqlParameter();
                SqlParameter prm_ESTADO = new SqlParameter();
                SqlParameter prm_CODUSUARIO = new SqlParameter();
                #endregion Parametros


                #region Values
                #region IdReg
                prm_IDREG.ParameterName = "@IdReg";
                prm_IDREG.SqlDbType = SqlDbType.Int;
                prm_IDREG.Direction = ParameterDirection.Input;
                prm_IDREG.Value = ListEnGaranxProduc[0].IdReg;
                #endregion IdReg
                #region nempresa
                prm_NEMPRESA.ParameterName = "@nempresa";
                prm_NEMPRESA.SqlDbType = SqlDbType.Int;
                prm_NEMPRESA.Direction = ParameterDirection.Input;
                prm_NEMPRESA.Value = ListEnGaranxProduc[0].NEmpresa;
                #endregion nempresa
                #region CodigoCliente
                prm_CODIGOCLIENTE.ParameterName = "@CodigoCliente";
                prm_CODIGOCLIENTE.SqlDbType = SqlDbType.Int;
                prm_CODIGOCLIENTE.Direction = ParameterDirection.Input;
                prm_CODIGOCLIENTE.Value = ListEnGaranxProduc[0].CodigoCliente;
                #endregion CodigoCliente
                #region IdRegProductos
                prm_IDREGPRODUCTOS.ParameterName = "@IdRegProductos";
                prm_IDREGPRODUCTOS.SqlDbType = SqlDbType.Int;
                prm_IDREGPRODUCTOS.Direction = ParameterDirection.Input;
                prm_IDREGPRODUCTOS.Value = ListEnGaranxProduc[0].IdRegProductos;
                #endregion IdRegProductos
                #region CodGarantia
                prm_CODGARANTIA.ParameterName = "@CodGarantia";
                prm_CODGARANTIA.SqlDbType = SqlDbType.Int;
                prm_CODGARANTIA.Direction = ParameterDirection.Input;
                prm_CODGARANTIA.Value = ListEnGaranxProduc[0].CodGarantia;
                #endregion CodGarantia
                #region CodTipoBien
                prm_CODTIPOBIEN.ParameterName = "@CodTipoBien";
                prm_CODTIPOBIEN.SqlDbType = SqlDbType.Int;
                prm_CODTIPOBIEN.Direction = ParameterDirection.Input;
                prm_CODTIPOBIEN.Value = ListEnGaranxProduc[0].CodTipoBien;
                #endregion CodTipoBien
                #region DescripBien
                prm_DESCRIPBIEN.ParameterName = "@DescripBien";
                prm_DESCRIPBIEN.SqlDbType = SqlDbType.VarChar;
                prm_DESCRIPBIEN.Direction = ParameterDirection.Input;
                prm_DESCRIPBIEN.Size = 500;
                prm_DESCRIPBIEN.Value = ListEnGaranxProduc[0].DescripBien;
                #endregion DescripBien
                #region Telefonos
                prm_TELEFONOS.ParameterName = "@Telefonos";
                prm_TELEFONOS.SqlDbType = SqlDbType.VarChar;
                prm_TELEFONOS.Direction = ParameterDirection.Input;
                prm_TELEFONOS.Size = 60;
                prm_TELEFONOS.Value = ListEnGaranxProduc[0].Telefonos;
                #endregion Telefonos
                #region Propietarios
                prm_PROPIETARIOS.ParameterName = "@Propietarios";
                prm_PROPIETARIOS.SqlDbType = SqlDbType.VarChar;
                prm_PROPIETARIOS.Direction = ParameterDirection.Input;
                prm_PROPIETARIOS.Size = 120;
                prm_PROPIETARIOS.Value = ListEnGaranxProduc[0].Propietarios;
                #endregion Propietarios
                #region NombreGarante
                prm_NOMBREGARANTE.ParameterName = "@NombreGarante";
                prm_NOMBREGARANTE.SqlDbType = SqlDbType.VarChar;
                prm_NOMBREGARANTE.Direction = ParameterDirection.Input;
                prm_NOMBREGARANTE.Size = 120;
                prm_NOMBREGARANTE.Value = ListEnGaranxProduc[0].NombreGarante;
                #endregion NombreGarante
                #region Beneficiario
                prm_BENEFICIARIO.ParameterName = "@Beneficiario";
                prm_BENEFICIARIO.SqlDbType = SqlDbType.VarChar;
                prm_BENEFICIARIO.Direction = ParameterDirection.Input;
                prm_BENEFICIARIO.Size = 120;
                prm_BENEFICIARIO.Value = ListEnGaranxProduc[0].Beneficiario;
                #endregion Beneficiario
                #region Ubicacion
                prm_UBICACION.ParameterName = "@Ubicacion";
                prm_UBICACION.SqlDbType = SqlDbType.VarChar;
                prm_UBICACION.Direction = ParameterDirection.Input;
                prm_UBICACION.Size = 120;
                prm_UBICACION.Value = ListEnGaranxProduc[0].Ubicacion;
                #endregion Ubicacion
                #region Direccion
                prm_DIRECCION.ParameterName = "@Direccion";
                prm_DIRECCION.SqlDbType = SqlDbType.VarChar;
                prm_DIRECCION.Direction = ParameterDirection.Input;
                prm_DIRECCION.Size = 120;
                prm_DIRECCION.Value = ListEnGaranxProduc[0].Direccion;
                #endregion Direccion
                #region area
                prm_AREA.ParameterName = "@area";
                prm_AREA.SqlDbType = SqlDbType.VarChar;
                prm_AREA.Direction = ParameterDirection.Input;
                prm_AREA.Size = 60;
                prm_AREA.Value = ListEnGaranxProduc[0].area;
                #endregion area
                #region DNI
                prm_DNI.ParameterName = "@DNI";
                prm_DNI.SqlDbType = SqlDbType.Char;
                prm_DNI.Direction = ParameterDirection.Input;
                prm_DNI.Size = 8;
                prm_DNI.Value = ListEnGaranxProduc[0].DNI;
                #endregion DNI
                #region ValorComercial
                prm_VALORCOMERCIAL.ParameterName = "@ValorComercial";
                prm_VALORCOMERCIAL.SqlDbType = SqlDbType.Decimal;
                prm_VALORCOMERCIAL.Direction = ParameterDirection.Input;
                prm_VALORCOMERCIAL.Value = ListEnGaranxProduc[0].ValorComercial;
                #endregion ValorComercial
                #region MontoGarantia
                prm_MONTOGARANTIA.ParameterName = "@MontoGarantia";
                prm_MONTOGARANTIA.SqlDbType = SqlDbType.Decimal;
                prm_MONTOGARANTIA.Direction = ParameterDirection.Input;
                prm_MONTOGARANTIA.Value = ListEnGaranxProduc[0].MontoGarantia;
                #endregion MontoGarantia
                #region CartaFianza
                prm_CARTAFIANZA.ParameterName = "@CartaFianza";
                prm_CARTAFIANZA.SqlDbType = SqlDbType.Decimal;
                prm_CARTAFIANZA.Direction = ParameterDirection.Input;
                prm_CARTAFIANZA.Value = ListEnGaranxProduc[0].CartaFianza;
                #endregion CartaFianza
                #region FechaUltTasacion
                prm_FECHAULTTASACION.ParameterName = "@FechaUltTasacion";
                prm_FECHAULTTASACION.SqlDbType = SqlDbType.DateTime;
                prm_FECHAULTTASACION.Direction = ParameterDirection.Input;
                prm_FECHAULTTASACION.Value = ListEnGaranxProduc[0].FechaUltTasacion;
                #endregion FechaUltTasacion
                #region VencimientoCF
                prm_VENCIMIENTOCF.ParameterName = "@VencimientoCF";
                prm_VENCIMIENTOCF.SqlDbType = SqlDbType.DateTime;
                prm_VENCIMIENTOCF.Direction = ParameterDirection.Input;
                prm_VENCIMIENTOCF.Value = ListEnGaranxProduc[0].VencimientoCF;
                #endregion VencimientoCF
                #region ValorGravamen
                prm_VALORGRAVAMEN.ParameterName = "@ValorGravamen";
                prm_VALORGRAVAMEN.SqlDbType = SqlDbType.Decimal;
                prm_VALORGRAVAMEN.Direction = ParameterDirection.Input;
                prm_VALORGRAVAMEN.Value = ListEnGaranxProduc[0].ValorGravamen;
                #endregion ValorGravamen
                #region NumPartidaElec
                prm_NUMPARTIDAELEC.ParameterName = "@NumPartidaElec";
                prm_NUMPARTIDAELEC.SqlDbType = SqlDbType.VarChar;
                prm_NUMPARTIDAELEC.Direction = ParameterDirection.Input;
                prm_NUMPARTIDAELEC.Size = 20;
                prm_NUMPARTIDAELEC.Value = ListEnGaranxProduc[0].NumPartidaElec;
                #endregion NumPartidaElec
                #region Observacion
                prm_OBSERVACION.ParameterName = "@Observacion";
                prm_OBSERVACION.SqlDbType = SqlDbType.VarChar;
                prm_OBSERVACION.Direction = ParameterDirection.Input;
                prm_OBSERVACION.Size = 200;
                prm_OBSERVACION.Value = ListEnGaranxProduc[0].Observacion;
                #endregion Observacion
                #region Restricciones
                prm_RESTRICCIONES.ParameterName = "@Restricciones";
                prm_RESTRICCIONES.SqlDbType = SqlDbType.VarChar;
                prm_RESTRICCIONES.Direction = ParameterDirection.Input;
                prm_RESTRICCIONES.Size = 200;
                prm_RESTRICCIONES.Value = ListEnGaranxProduc[0].Restricciones;
                #endregion Restricciones
                #region CoberturaCF
                prm_COBERTURACF.ParameterName = "@CoberturaCF";
                prm_COBERTURACF.SqlDbType = SqlDbType.VarChar;
                prm_COBERTURACF.Direction = ParameterDirection.Input;
                prm_COBERTURACF.Size = 120;
                prm_COBERTURACF.Value = ListEnGaranxProduc[0].CoberturaCF;
                #endregion CoberturaCF
                #region Estado
                prm_ESTADO.ParameterName = "@Estado";
                prm_ESTADO.SqlDbType = SqlDbType.Char;
                prm_ESTADO.Direction = ParameterDirection.Input;
                prm_ESTADO.Size = 1;
                prm_ESTADO.Value = ListEnGaranxProduc[0].Estado;
                #endregion Estado
                #region CodUsuario
                prm_CODUSUARIO.ParameterName = "@CodUsuario";
                prm_CODUSUARIO.SqlDbType = SqlDbType.Int;
                prm_CODUSUARIO.Direction = ParameterDirection.Input;
                prm_CODUSUARIO.Value = ListEnGaranxProduc[0].CodUsuario;
                #endregion CodUsuario
                #endregion Values



                #region Execute
                SqlHelper.ExecuteNonQuery(tran, "CR_Cliente_sp_ModificarPRODGar",
                                               prm_IDREG,
                                               prm_NEMPRESA,
                                               prm_CODIGOCLIENTE,
                                               prm_IDREGPRODUCTOS,
                                               prm_CODGARANTIA,
                                               prm_CODTIPOBIEN,
                                               prm_DESCRIPBIEN,
                                               prm_TELEFONOS,
                                               prm_PROPIETARIOS,
                                               prm_NOMBREGARANTE,
                                               prm_BENEFICIARIO,
                                               prm_UBICACION,
                                               prm_DIRECCION,
                                               prm_AREA,
                                               prm_DNI,
                                               prm_VALORCOMERCIAL,
                                               prm_MONTOGARANTIA,
                                               prm_CARTAFIANZA,
                                               prm_FECHAULTTASACION,
                                               prm_VENCIMIENTOCF,
                                               prm_VALORGRAVAMEN,
                                               prm_NUMPARTIDAELEC,
                                               prm_OBSERVACION,
                                               prm_RESTRICCIONES,
                                               prm_COBERTURACF,
                                               prm_ESTADO,
                                               prm_CODUSUARIO
                                               );
                #endregion Execute
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public DataTable Garantia_Producto_Listar_Reg(List<EnGaranxProduc> ListEnGaranxProduc)
        {
            DataSet DS = new DataSet();
            DataTable dt = new DataTable();
            SqlConnection Conn = new SqlConnection();
            SqlDataAdapter adp = new SqlDataAdapter();
            string sqlCommand;
            try
            {

                Conn = new SqlConnection(MSSQLConnectionString);
                sqlCommand = "CR_Cliente_sp_CargaClientePRODGarREG";
                adp = new SqlDataAdapter(sqlCommand, Conn);
                adp.SelectCommand.CommandType = CommandType.StoredProcedure;
                adp.SelectCommand.CommandTimeout = 10000;
                SqlParameter[] paramsToStore = new SqlParameter[2];

                paramsToStore[0] = new SqlParameter("@NEMPRESA", SqlDbType.Int);
                paramsToStore[0].Value = ListEnGaranxProduc[0].NEmpresa;

                paramsToStore[1] = new SqlParameter("@IdReg", SqlDbType.Int);
                paramsToStore[1].Value = ListEnGaranxProduc[0].IdReg;

                adp.SelectCommand.Parameters.AddRange(paramsToStore);

                adp.Fill(DS, "DataTable1");
                dt = DS.Tables["DataTable1"];

                return dt;
            }
            catch (Exception excp)
            {
                throw excp;
            }
        }


        public DataTable Garantia_Producto_Listar(List<EnGaranxProduc> ListEnGaranxProduc)
        {
            DataSet DS = new DataSet();
            DataTable dt = new DataTable();
            SqlConnection Conn = new SqlConnection();
            SqlDataAdapter adp = new SqlDataAdapter();
            string sqlCommand;
            try
            {

                Conn = new SqlConnection(MSSQLConnectionString);
                sqlCommand = "CR_Cliente_sp_CargaClientePRODGar";
                adp = new SqlDataAdapter(sqlCommand, Conn);
                adp.SelectCommand.CommandType = CommandType.StoredProcedure;
                adp.SelectCommand.CommandTimeout = 10000;
                SqlParameter[] paramsToStore = new SqlParameter[3];

                paramsToStore[0] = new SqlParameter("@NEMPRESA", SqlDbType.Int);
                paramsToStore[0].Value = ListEnGaranxProduc[0].NEmpresa;

                paramsToStore[1] = new SqlParameter("@CodigoCliente", SqlDbType.Int);
                paramsToStore[1].Value = ListEnGaranxProduc[0].CodigoCliente;

                paramsToStore[2] = new SqlParameter("@IdRegPRODUCTOS", SqlDbType.Decimal);
                paramsToStore[2].Value = ListEnGaranxProduc[0].IdRegPRODUCTOS;

                adp.SelectCommand.Parameters.AddRange(paramsToStore);

                adp.Fill(DS, "DataTable1");
                dt = DS.Tables["DataTable1"];

                return dt;
            }
            catch (Exception excp)
            {
                throw excp;
            }
        }

    }
}
