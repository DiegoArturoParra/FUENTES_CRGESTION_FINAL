using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Sis.Estudio.Logic.MSSQL.Gestion;
using Sis.Estudio.Entity;
using System.Data;
using Sis.Estudio.Logic.MSSQL.Seguridad;
using System.IO;


namespace ApiServices.Controllers
{
    public class appController : Controller
    {
        //
        // GET: /app/

        [HttpPost]
        public IEnumerable Create(EnGS_Gestion_Cobranza objEnGS_Gestion_Cobranza)
        {
       
        List<EnGS_Gestion_Cobranza> ListEnGS_Gestion_Cobranza = new List<EnGS_Gestion_Cobranza>();
        objEnGS_Gestion_Cobranza.Accion = "0";//Fijo
        objEnGS_Gestion_Cobranza.nEmpresa = "01";//Fijo

       // objEnGS_Gestion_Cobranza.dias_mora = this.Session["GS_Gestion_Cobranza_dias_mora"].ToString();//Variable
       // objEnGS_Gestion_Cobranza.dias_mora_hasta = this.Session["GS_Gestion_Cobranza_dias_mora_hasta"].ToString();//Variable

       // objEnGS_Gestion_Cobranza.fecha_ini = this.Session["GS_Gestion_Cobranza_fecha_ini"].ToString();//Variable
       // objEnGS_Gestion_Cobranza.fecha_fin = this.Session["GS_Gestion_Cobranza_fecha_fin"].ToString();//Variable
        objEnGS_Gestion_Cobranza.CodTipoGestion = "3";//Fijo

      //  objEnGS_Gestion_Cobranza.CodUsuario = (String)this.Session["codusuario"];//Variable Quien se loguea

        objEnGS_Gestion_Cobranza.Nombres = string.Empty;//Fijo
        objEnGS_Gestion_Cobranza.documento = string.Empty;//Fijo
        objEnGS_Gestion_Cobranza.Id_estado_gestion_cobranza = "1";//Fijo
            
        ListEnGS_Gestion_Cobranza.Add(objEnGS_Gestion_Cobranza);
           LoGS_Gestion_Cobranza obj = new LoGS_Gestion_Cobranza();


           return   (from DataRow dr in obj.GS_Gestion_Cobranza_Lista(ListEnGS_Gestion_Cobranza).Rows
                                 select new
                                 {
                                     nMontoCuota = Convert.ToDecimal(dr["nMontoCuota"]),
                                     cDocumento = dr["cDocumento"].ToString(),
                                     cRazonSocial = dr["cRazonSocial"].ToString(),
                                     nDiasMora = Convert.ToInt32(dr["nDiasMora"]),
                                     nTramo = Convert.ToInt32(dr["nTramo"]),
                                     cDireccion = dr["cDireccion"].ToString(),
                                     cDetalleContactabilidad = dr["cDetalleContactabilidad"].ToString(),
                                     nSaldoDeuda = Convert.ToDecimal(dr["nSaldoDeuda"])
                                 }).ToList();  

        }

        //
        // GET: /app/Details/5

        public ActionResult Details(int id)
        {
            return View();
        }

        //
        // GET: /app/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /app/Create

        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /app/Edit/5

        public ActionResult Edit(int id)
        {
            return View();
        }

        //
        // POST: /app/Edit/5

        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /app/Delete/5

        public ActionResult Delete(int id)
        {
            return View();
        }

        //
        // POST: /app/Delete/5

        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

       
    }

   
}
