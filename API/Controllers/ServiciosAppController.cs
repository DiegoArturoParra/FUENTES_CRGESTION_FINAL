using API.Models;
using Newtonsoft.Json.Linq;
using Sis.Estudio.Entity;
using Sis.Estudio.Logic.MSSQL.Estudio;
using Sis.Estudio.Logic.MSSQL.Gestion;
using Sis.Estudio.Logic.MSSQL.Seguridad;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;

namespace API.Controllers
{
    [RoutePrefix("api/servicios-app")]
    public class ServiciosAppController : ApiController
    {
        // GET api/mostrar-imagen/{id}

        [HttpGet]
        [Route("mostrar-imagen/{id}")]
        public IHttpActionResult GetImagen(int id)
        {
            var response = new LoGS_Gestion_Cobranza().GS_Gestion_Cobranza_Imagen(id);
            return Content(response.StatusCode, response);
        }



        [HttpPost]
        [Route("listpendientes")]
        public IHttpActionResult listpendientes(EnGS_Gestion_Cobranza objEnGS_Gestion_Cobranza)
        {

            List<EnGS_Gestion_Cobranza> ListEnGS_Gestion_Cobranza = new List<EnGS_Gestion_Cobranza>();
            LoGS_Gestion_Cobranza obj = new LoGS_Gestion_Cobranza();
            objEnGS_Gestion_Cobranza.Accion = "0";//Fijo
            objEnGS_Gestion_Cobranza.nEmpresa = "01";//Fijo
            objEnGS_Gestion_Cobranza.CodTipoGestion = "3";//Fijo
                                                          //objEnGS_Gestion_Cobranza.Nombres = string.Empty;//Fijo
                                                          //objEnGS_Gestion_Cobranza.documento = string.Empty;//Fijo

            ListEnGS_Gestion_Cobranza.Add(objEnGS_Gestion_Cobranza);

            //DataTable dt = obj.GS_Gestion_Cobranza_Lista(ListEnGS_Gestion_Cobranza);
            var data = (from DataRow dr in obj.GS_Gestion_Cobranza_Lista_App(ListEnGS_Gestion_Cobranza).Rows
                        select new
                        {
                            nMontoCuota = Convert.ToDecimal(dr["nMontoCuota"]),
                            cDocumento = dr["cDocumento"].ToString(),
                            cRazonSocial = dr["cRazonSocial"].ToString(),
                            nDiasMora = Convert.ToInt32(dr["nDiasMora"]),
                            nTramo = Convert.ToInt32(dr["nTramo"]),
                            cDireccion = dr["cDireccion"].ToString(),
                            cDetalleContactabilidad = dr["cDetalleContactabilidad"].ToString(),
                            nSaldoDeuda = Convert.ToDecimal(dr["nSaldoDeuda"]),
                            nMontoDesemb = Convert.ToDecimal(dr["nMontoDesemb"]),
                            nCuotPac = Convert.ToInt32(dr["nCuotPac"]),
                            nCuotPag = Convert.ToDecimal(dr["nCuotPag"]),
                            nMontoCapital = Convert.ToDecimal(dr["nMontoCapital"]),
                            dFechaVencimiento = dr["dFechaVencimiento"].ToString(),
                            dFechaUltimoPago = dr["dFechaUltimoPago"].ToString(),
                            cProducto = dr["cProducto"].ToString(),
                            cSubProducto = dr["cSubProducto"].ToString(),
                            nIdClienteGestion = dr["nIdClienteGestion"].ToString(),
                            nIdGestionCobranza = dr["nIdGestionCobranza"].ToString(),
                            cUbigeo = dr["cUbigeo"].ToString(),
                            nIdCliente = dr["nIdCliente"].ToString(),
                            lGestionIncompleta = Convert.ToBoolean(dr["lGestionIncompleta"]),
                            cIdentificador = dr["cIdentificador"].ToString()
                        }).ToList();

            return Ok(data);
        }

        [HttpPost]
        [Route("listEjecutados")]
        public IHttpActionResult listEjecutados(EnGS_Gestion_Cobranza objEnGS_Gestion_Cobranza)
        {

            List<EnGS_Gestion_Cobranza> ListEnGS_Gestion_Cobranza = new List<EnGS_Gestion_Cobranza>();
            LoGS_Gestion_Cobranza obj = new LoGS_Gestion_Cobranza();
            objEnGS_Gestion_Cobranza.Accion = "0";//Fijo
            objEnGS_Gestion_Cobranza.nEmpresa = "01";//Fijo
            objEnGS_Gestion_Cobranza.CodTipoGestion = "";//Fijo
                                                         //objEnGS_Gestion_Cobranza.Nombres = string.Empty;//Fijo
                                                         //objEnGS_Gestion_Cobranza.documento = string.Empty;//Fijo

            ListEnGS_Gestion_Cobranza.Add(objEnGS_Gestion_Cobranza);

            return Ok((from DataRow dr in obj.GS_Gestion_Cobranza_Lista_App(ListEnGS_Gestion_Cobranza).Rows
                       select new
                       {
                           nMontoCuota = Convert.ToDecimal(dr["nMontoCuota"]),
                           cDocumento = dr["cDocumento"].ToString(),
                           cRazonSocial = dr["cRazonSocial"].ToString(),
                           nDiasMora = Convert.ToInt32(dr["nDiasMora"]),
                           nTramo = Convert.ToInt32(dr["nTramo"]),
                           cDireccion = dr["cDireccion"].ToString(),
                           cDetalleContactabilidad = dr["cDetalleContactabilidad"].ToString(),
                           nSaldoDeuda = Convert.ToDecimal(dr["nSaldoDeuda"]),
                           nMontoDesemb = Convert.ToDecimal(dr["nMontoDesemb"]),
                           nCuotPac = Convert.ToInt32(dr["nCuotPac"]),
                           nCuotPag = Convert.ToDecimal(dr["nCuotPag"]),
                           nMontoCapital = Convert.ToDecimal(dr["nMontoCapital"]),
                           dFechaVencimiento = dr["dFechaVencimiento"].ToString(),
                           dFechaUltimoPago = dr["dFechaUltimoPago"].ToString(),
                           cProducto = dr["cProducto"].ToString(),
                           cSubProducto = dr["cSubProducto"].ToString(),
                           nIdClienteGestion = dr["nIdClienteGestion"].ToString(),
                           nIdGestionCobranza = dr["nIdGestionCobranza"].ToString(),
                           cUbigeo = dr["cUbigeo"].ToString(),
                           nIdCliente = dr["nIdCliente"].ToString(),
                           nIdEjecutado = dr["nIdEjecutado"].ToString(),
                           cEjecutado = dr["cEjecutado"].ToString(),
                           nIdClaseGestion = dr["nIdClaseGestion"].ToString(),
                           cClaseGestion = dr["cClaseGestion"].ToString(),
                           nIdTipoGestion = dr["nIdTipoGestion"].ToString(),
                           cTipoGestion = dr["cTipoGestion"].ToString(),
                           dFechaResultado = dr["dFechaResultado"].ToString()
                       }).ToList());
        }


        [HttpPost]
        [Route("listEjecutadosXCliente")]
        public IHttpActionResult listEjecutadosXCliente(EnGS_Gestion_Cobranza objEnGS_Gestion_Cobranza)
        {

            List<EnGS_Gestion_Cobranza> ListEnGS_Gestion_Cobranza = new List<EnGS_Gestion_Cobranza>();
            LoGS_Gestion_Cobranza obj = new LoGS_Gestion_Cobranza();
            objEnGS_Gestion_Cobranza.Accion = "0";//Fijo
            objEnGS_Gestion_Cobranza.nEmpresa = "01";//Fijo
            objEnGS_Gestion_Cobranza.CodTipoGestion = "3";//Fijo
                                                          //objEnGS_Gestion_Cobranza.Nombres = string.Empty;//Fijo
                                                          //objEnGS_Gestion_Cobranza.documento = string.Empty;//Fijo

            ListEnGS_Gestion_Cobranza.Add(objEnGS_Gestion_Cobranza);

            //DataTable dt = obj.GS_Gestion_Cobranza_Lista(ListEnGS_Gestion_Cobranza);
            return Ok((from DataRow dr in obj.GS_Gestion_Cobranza_Lista_App(ListEnGS_Gestion_Cobranza).Rows
                       select new
                       {
                           nMontoCuota = Convert.ToDecimal(dr["nMontoCuota"]),
                           cDocumento = dr["cDocumento"].ToString(),
                           cRazonSocial = dr["cRazonSocial"].ToString(),
                           nDiasMora = Convert.ToInt32(dr["nDiasMora"]),
                           nTramo = Convert.ToInt32(dr["nTramo"]),
                           cDireccion = dr["cDireccion"].ToString(),
                           cDetalleContactabilidad = dr["cDetalleContactabilidad"].ToString(),
                           nSaldoDeuda = Convert.ToDecimal(dr["nSaldoDeuda"]),
                           nMontoDesemb = Convert.ToDecimal(dr["nMontoDesemb"]),
                           nCuotPac = Convert.ToInt32(dr["nCuotPac"]),
                           nCuotPag = Convert.ToDecimal(dr["nCuotPag"]),
                           nMontoCapital = Convert.ToDecimal(dr["nMontoCapital"]),
                           dFechaVencimiento = dr["dFechaVencimiento"].ToString(),
                           dFechaUltimoPago = dr["dFechaUltimoPago"].ToString(),
                           cProducto = dr["cProducto"].ToString(),
                           cSubProducto = dr["cSubProducto"].ToString(),
                           nIdClienteGestion = dr["nIdClienteGestion"].ToString(),
                           nIdGestionCobranza = dr["nIdGestionCobranza"].ToString(),
                           cUbigeo = dr["cUbigeo"].ToString(),
                           nIdCliente = dr["nIdCliente"].ToString(),
                           lGestionIncompleta = Convert.ToBoolean(dr["lGestionIncompleta"])
                       }).ToList());
        }
        [HttpPost]
        [Route("traergestor")]
        public IHttpActionResult traergestor(EnLogin objEnLogin)
        {

            List<EnLogin> ListEnLogin = new List<EnLogin>();
            //objEnLogin = new EnLogin();
            LoLogin objLoLogin = new LoLogin();

            objEnLogin.CEMPRESA = "01";
            //objEnLogin.LOGIN = "jroblesa";
            //objEnLogin.PASSWORD = Util.Encrypt(objEnLogin.PASSWORD, true);
            objEnLogin.PASSWORD = objEnLogin.PASSWORD;

            ListEnLogin.Add(objEnLogin);


            return Ok((from DataRow dr in objLoLogin.GetUsuarioLogin(ListEnLogin).Rows
                       select new
                       {
                           idusuario = dr["idusuario"].ToString(),
                           codusuario = dr["codusuario"].ToString(),
                           nombresusuario = dr["nombresusuario"].ToString(),
                           perfil = dr["perfil"].ToString()
                       }).ToList());

        }


        [HttpPost]
        [Route("listResultadoTodos")]
        public IHttpActionResult listResultadoTodos()
        {
            //LoGS_Resultado objLoGS_Resultado = new LoGS_Resultado();

            //return (from DataRow dr in objLoGS_Resultado.GS_Resultado_Listar_Todos().Rows
            //        select new
            //        {
            //            nIdClasificacion = dr["nIdClasificacion"].ToString(),
            //            cClasificacion = dr["cClasificacion"].ToString(),
            //            nIdResultado = dr["nIdResultado"].ToString(),
            //            cResultado = dr["cResultado"].ToString()
            //        }).ToList();

            EnGS_Ejecutado objEnGS_Ejecutado = new EnGS_Ejecutado();
            List<EnGS_Ejecutado> ListEnGS_Ejecutado = new List<EnGS_Ejecutado>();
            LoGS_Ejecutado objLoGS_Ejecutado = new LoGS_Ejecutado();

            objEnGS_Ejecutado.CodTipoGestion = "3";
            ListEnGS_Ejecutado.Add(objEnGS_Ejecutado);

            return Ok((from DataRow dr in objLoGS_Ejecutado.GS_Ejecutado_TipoGestiones_Combo(ListEnGS_Ejecutado).Rows
                       select new
                       {
                           CodEjecutado = dr["CodEjecutado"].ToString(),
                           Descripcion = dr["Descripcion"].ToString()
                       }).ToList());
        }
        [HttpPost]
        [Route("listclasificacion")]
        public IHttpActionResult listclasificacion(EnGS_Ejecutado objEnGS_Ejecutado)
        {
            objEnGS_Ejecutado = new EnGS_Ejecutado();
            List<EnGS_Ejecutado> ListEnGS_Ejecutado = new List<EnGS_Ejecutado>();
            LoGS_Ejecutado objLoGS_Ejecutado = new LoGS_Ejecutado();

            objEnGS_Ejecutado.CodTipoGestion = "3";
            ListEnGS_Ejecutado.Add(objEnGS_Ejecutado);

            return Ok((from DataRow dr in objLoGS_Ejecutado.GS_Ejecutado_TipoGestiones_Combo(ListEnGS_Ejecutado).Rows
                       select new
                       {
                           CodEjecutado = dr["CodEjecutado"].ToString(),
                           Descripcion = dr["Descripcion"].ToString()
                       }).ToList());
        }

        [HttpGet]
        [Route("listresultado/{id}")]
        public IHttpActionResult listresultado(string id)
        {
            EnGS_ClaseGestiones objEnGS_ClaseGestiones = new EnGS_ClaseGestiones();
            List<EnGS_ClaseGestiones> ListEnGS_ClaseGestiones = new List<EnGS_ClaseGestiones>();

            LoGS_ClaseGestiones objLoGS_ClaseGestiones = new LoGS_ClaseGestiones();
            objEnGS_ClaseGestiones.CodEjecutado = id;//Variable
            ListEnGS_ClaseGestiones.Add(objEnGS_ClaseGestiones);

            return Ok((from DataRow dr in objLoGS_ClaseGestiones.GS_ClaseGestionesxEjecutado_Combo(ListEnGS_ClaseGestiones).Rows
                       select new
                       {
                           codclasegestion = dr["codclasegestion"].ToString(),
                           Descripcion = dr["Descripcion"].ToString()
                       }).ToList());
        }

        [HttpPost]
        [Route("updategestion")]
        public IHttpActionResult updategestion(EnGS_Gestion_Cobranza objEnGS_Gestion_Cobranza)
        {
            String lcMensaje = string.Empty;
            List<EnGS_Gestion_Cobranza> ListEnGS_Gestion_Cobranza = new List<EnGS_Gestion_Cobranza>();
            LoGS_Gestion_Cobranza obj = new LoGS_Gestion_Cobranza();
            objEnGS_Gestion_Cobranza.CodTipoGestion = "3";//Fijo
            objEnGS_Gestion_Cobranza.nEmpresa = "01";//Fijo
            objEnGS_Gestion_Cobranza.Num_carta = 0;//Fijo

            ListEnGS_Gestion_Cobranza.Add(objEnGS_Gestion_Cobranza);

            lcMensaje = obj.GS_Gestion_Cobranza_UPD(ListEnGS_Gestion_Cobranza);
            JObject o = JObject.Parse(lcMensaje);
            return Ok(o);
        }

        [HttpPost]
        [Route("insertgestion")]
        public IHttpActionResult insertgestion(EnGS_Gestion_Cobranza objEnGS_Gestion_Cobranza)
        {
            String lcMensaje = string.Empty;
            List<EnGS_Gestion_Cobranza> ListEnGS_Gestion_Cobranza = new List<EnGS_Gestion_Cobranza>();
            LoGS_Gestion_Cobranza obj = new LoGS_Gestion_Cobranza();
            objEnGS_Gestion_Cobranza.nEmpresa = "01";//Fijo
            objEnGS_Gestion_Cobranza.Num_carta = 0;//Fijo

            ListEnGS_Gestion_Cobranza.Add(objEnGS_Gestion_Cobranza);

            obj.GS_Gestion_Cobranza_SubTarea_INS(ListEnGS_Gestion_Cobranza);
            return Ok(lcMensaje);
        }

        [HttpPost]
        [Route("updatedireccion")]
        public IHttpActionResult updatedireccion(EnDirecCliente objEnDirecCliente)
        {

            String lcMensaje = string.Empty;
            List<EnDirecCliente> ListEnDirecCliente = new List<EnDirecCliente>();
            LoDirecCliente obj = new LoDirecCliente();
            objEnDirecCliente.CodEstadoDir = "1";//Fijo
            objEnDirecCliente.CodTipoDir = "1";//Fijo
            objEnDirecCliente.NEMPRESA = "01";//Fijo

            ListEnDirecCliente.Add(objEnDirecCliente);

            lcMensaje = obj.DirecCliente_UPD(ListEnDirecCliente);

            JObject o = JObject.Parse(lcMensaje);
            return Ok(o);
        }

        [HttpPost]
        [Route("uploadImage")]
        public IHttpActionResult uploadImage()
        {
            LoGS_Gestion_Cobranza obj = new LoGS_Gestion_Cobranza();
            EnGS_Gestion_Cobranza objEnGS_Gestion_Cobranza = new EnGS_Gestion_Cobranza();
            var req = HttpContext.Current.Request;
            var data = new UploadImagen();
            try
            {
                var id = req["nIdReg"];
                if (id != null)
                {
                    /*  var file = System.Web.HttpContext.Current.Request.Files.Count > 0 ?
                  System.Web.HttpContext.Current.Request.Files[0] : null;*/
                    var file = System.Web.HttpContext.Current.Request.Files.Count > 0 ?
                    System.Web.HttpContext.Current.Request.Files[0] : null;

                    if (file != null && file.ContentLength > 0)
                    {
                        //guarda en bd
                        byte[] bytes;
                        using (BinaryReader br = new BinaryReader(file.InputStream))
                        {
                            bytes = br.ReadBytes(file.ContentLength);
                        }
                        var fileName = Path.GetFileName(file.FileName);
                        objEnGS_Gestion_Cobranza.IdReg = id;
                        objEnGS_Gestion_Cobranza.Nombre = fileName;
                        objEnGS_Gestion_Cobranza.comentario = "imagen";

                        // arma la ruta del archivo
                        var rutaNombreArchivo = Path.Combine(System.Web.HttpContext.Current.Server.MapPath("~/uploads"), fileName);
                        byte[] fileBytes;

                        string base64 = Convert.ToBase64String(bytes);

                        fileBytes = Convert.FromBase64String(base64);

                        MemoryStream ms = new MemoryStream(fileBytes);
                        //write to file
                        FileStream fileOption = new FileStream(rutaNombreArchivo, FileMode.Create, FileAccess.Write);
                        ms.WriteTo(fileOption);
                        fileOption.Close();
                        ms.Close();
                        objEnGS_Gestion_Cobranza.RazonSocial = rutaNombreArchivo;
                        data.cRuta = rutaNombreArchivo;
                        data.nIdReg = id;
                        data.cNombre = fileName;
                        data.cDescripcion = "imagen";
                        obj.GS_Gestion_Cobranza_INS_Imagen(objEnGS_Gestion_Cobranza, bytes);
                        return Ok(data);
                    }
                }
                return BadRequest("data incorrecta");
            }
            catch (Exception ex)
            {
                return Content(HttpStatusCode.InternalServerError, ex.Message);
            }
        }
        //   return file= string.Format("Image Updated Successfulyy.");
        //return Request.CreateErrorResponse(HttpContext.Current, message);

        // JObject o = JObject.Parse(file != null ? "/uploads/" + file.FileName : null); //  return o;              


        // return  file != null ? "/uploads/" + file.FileName : null;




        //@"{'res':'exito'}"
        /*[HttpPost]  // required to spell it out like this if using ApiController, or it will default to System.Mvc.Http.HttpPost
        public IHttpActionResult Post([FromBody]MyModel myModelObj)
        {
            MY_ATTACHMENT_TABLE_MODEL tblAtchm = new MY_ATTACHMENT_TABLE_MODEL();
            tblAtchm.Name = myModelObj.name;
            tblAtchm.Type = myModelObj.type;
            tblAtchm.File = System.Convert.FromBase64String(myModelObj.file);
            EntityFrameworkContextName ef = new EntityFrameworkContextName();
            ef.MY_ATTACHMENT_TABLE_MODEL.Add(tblAtchm);
            ef.SaveChanges();
        }*/
        // POST api/serviciocr
    }
}
