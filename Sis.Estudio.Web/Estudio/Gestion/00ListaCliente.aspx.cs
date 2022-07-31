using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Sis.Estudio.Entity;
using Sis.Estudio.Logic.MSSQL.Estudio;

public partial class Estudio_Gestion_00ListaCliente : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            Master.TituloModulo = "Datos del Cliente";
        }
        //txt_CodCliente.Attributes.Add("onkeypress", "javascript:return validarDni();");
        //txt_CodCliente.Attributes["onkeypress"] = "validarDni();";
    }
    protected void btn_CargarCliente_Click(object sender, EventArgs e)
    {
        List<EnDatosCliente> List = new List<EnDatosCliente>();
        EnDatosCliente objEn = new EnDatosCliente();
        //if (txt_CodCliente.Text.Trim() != string.Empty)
        //{
            objEn.DNI = txt_CodCliente.Text.Trim();
            LoDatosCliente objLo = new LoDatosCliente();
            int cod = objLo.CodigoCliente_Dni(objEn);
            if (cod == -1)
            {
                //Master.MostrarMensaje(Mensajes.MSG_VALIDACION_ERROR, TipoMensaje.Error);
                Master.MostrarMensaje("No se encontró el DNI", TipoMensaje.Error);
            }
            else
            {
                Session[Global.CodCliente] = cod.ToString();
                //Session[Global.CodCliente] = txt_CodCliente.Text.Trim();
                Response.Redirect("00Load.aspx");
            }
        //}
        //else
        //{
        //    Master.MostrarMensaje("El campo DNI no puede ser vacío.", TipoMensaje.Error);
        //}
    }
    private void Limpiar_Controles()
    {
        txt_CodCliente.Text = string.Empty;
        lblMensaje.Text = string.Empty;
        Master.OcultarMensaje();
    }
}