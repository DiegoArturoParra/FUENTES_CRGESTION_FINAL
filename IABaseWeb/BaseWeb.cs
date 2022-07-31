using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Drawing;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web.Security;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Text;
using System.Data.SqlClient;
using System.IO;
using Sis.Estudio.Entity;
using Sis.Estudio.Logic.MSSQL.Seguridad;
//using AjaxControlToolkit;

namespace IABaseWeb
{
    public class BaseWeb : System.Web.UI.Page
    {
        #region Declaraciones
        #region Controles
        public static Label lblMensaje;
        #endregion Controles
        #region Varialbes
        public string G_idopcion = "";
        #endregion Varialbes
        #endregion Declaraciones
        #region Procedimientos
        protected void MostrarMensaje(string str_mensaje, bool error)
        {
                //**********************************************************************************************
                //*	 MostrarMensaje : Muestra el  mensaje de avisos.
                //**********************************************************************************************
                lblMensaje.Text = str_mensaje;
                if (error == true)
                {
                    lblMensaje.ForeColor = Color.Red;
                }
                else
                {
                    lblMensaje.ForeColor = Color.Green;
                }
                upBotonera_Update();    
            
            
        }        
        protected void limpiarMensaje()
        {
            //**********************************************************************************************
            //*	 limpiarMensaje : limpia mensaje de avisos.
            //**********************************************************************************************
            lblMensaje.Text = "";
            lblMensaje.ForeColor = Color.Red;
            upBotonera_Update();
        }        
        #endregion Procedimientos
        #region UpdatePanel
        protected virtual void upBotonera_Update()
        {

        }
        #endregion UpdatePanel
        #region AccesosAccion
        protected void Accesos()
        {
            //****************************************************************************************
            //* Nombre      : Accesos
            //* DescripcioN : Establece los los permisos a las Acciones por Usuario y por Perfil
            //*                                                    Jhonny Developer      /FEBRERO/2010
            //****************************************************************************************
            try
            {
                limpiarMensaje();
                BloqueaAcciones();
                ActivaAccionesComunes();

                DataTable dt = new DataTable();

                List<EnOpcion> ListEnOpcion = new List<EnOpcion>();

          
                EnOpcion objEnOpcion = new EnOpcion();
        


      
                             
                objEnOpcion.CEmpresa = (String)this.Session["cempresa"];
         
                objEnOpcion.CodUsuario = (String)this.Session["codusuario"];
              
                //objEnOpcion.Masteridmodulo = (String)this.Session["Masteridmodulo"];

                objEnOpcion.IdModulo = (String)this.Session["Masteridmodulo"];
                objEnOpcion.IdOpcion = G_idopcion;

                ListEnOpcion.Add(objEnOpcion);
                LoOpcion objLoOpcion = new LoOpcion();
                dt = objLoOpcion.Seguridad_CargaAccionesDeOpcion(ListEnOpcion);
                if (dt.Rows.Count > 0)
                {
                    #region CONTROLES_MANTENIMIENTO

                    #endregion CONTROLES_MANTENIMIENTO
                    string strAccion = "";
                    foreach (DataRow row in dt.Rows)
                    {
                        strAccion = row["IdAccion"].ToString();
                        ActivaAccion(strAccion);
                    }
                }
                //upBotonera.Update();                
            }
            catch (Exception ex)
            {
                MostrarMensaje(ex.Message.ToString(), true);
            }
        }
        protected virtual void BloqueaAcciones()
        {

        }
        protected virtual void ActivaAccionesComunes()
        {

        }
        protected virtual void ActivaAccion(string accion)
        {
        }
        protected void Propiedades_Boton(ImageButton btn, string nombre)
        {
            btn.Enabled = true;
            btn.Attributes.Add("onMouseOver", "src='" + "../../Imagenes/" + nombre + "_over.png " + "'");
            btn.Attributes.Add("onMouseOut", "src='" + "../../Imagenes/" + nombre + "_out.png " + "'");
            btn.ImageUrl = "~/Imagenes/" + nombre + "_out.png";
            btn.ToolTip = nombre;
        }
        #endregion AccesosAccion        
    }
}
