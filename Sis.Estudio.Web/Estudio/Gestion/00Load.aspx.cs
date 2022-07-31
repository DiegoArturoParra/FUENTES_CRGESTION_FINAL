using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using acetsoft;

public partial class Estudio_Gestion_00Load : System.Web.UI.Page
{
    string str_id_cliente = "";

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {

            if (Request["id_cliente"] != null)
            {
                str_id_cliente = Request["id_cliente"];
                Session[Global.CodCliente] = str_id_cliente.ToString();
            }


            


            Master.TituloModulo = "Datos del Cliente";
        }
    }


    public void EComponente()
    {
        Response.Write(AcetPanel.WriteForm());            
    }
}