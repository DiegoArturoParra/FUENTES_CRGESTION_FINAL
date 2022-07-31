using System;
using System.Drawing;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Collections.Generic;
using Sis.Estudio.Entity;
using Sis.Estudio.Logic.MSSQL.Seguridad;
using IABaseWeb;

public partial class Mantenimientos_Seguridad_MantUsuarioPerfil : BaseMantDetalle
{
    #region Declaraciones    
    public string mstrId;
    
    #endregion  Declaraciones
    #region Eventos
    protected void Page_Load(object sender, EventArgs e)
    {
        btn_REFRESCAR.Focus();
        if (!Page.IsPostBack)
        {
            this.Master.TituloModulo = "Asignar Perfiles";
            G_idopcion = OpcionModulo.MantUsuario;
            #region accesos
            Accesos();
            #endregion accesos
            btnEliminar.Attributes.Add("onClick", "document.getElementById('hdnContinuar').value = confirm('¿Se anulará El registro, ¿Desea continuar?');");
            InicioOperacion();
            Refresca_Grid("1");
        }
    }
    #endregion Eventos
    #region Perfil
    #region eventos



    protected void btnAgregar_Click(object sender, ImageClickEventArgs e)
    {
        Master.OcultarMensaje();
        #region Sesion
        string cempresa = (String)this.Session["cempresa"]; ;
        if (cempresa == "" || cempresa == null)
        {
            this.Session.Abandon();
            Response.Redirect("../Login.aspx?rd=0");
            return;
        }
        #endregion Sesion
        #region js
        string str_parametro = "?parametro=" + "";
        string str_tipo = "&tipo=0";//0=busqueda con retorno,1= busqueda sin retorno

        string strINI_JS;
        string strFIN_JS;
        string strTamaño;
        string strPos;
        string strScript2;

        strINI_JS = " <script language='javascript'> ";
        strFIN_JS = " </script> ";

        strTamaño = " var ancho = 900;   var alto = 380; ";
        strPos = " xpos=(screen.width/2)-(ancho/2);  ypos=(screen.height/2)-(alto/2); ";

        strScript2 = " win=window.open('../../Consultas/Busquedas/BuscarPerfil.aspx" + str_parametro + str_tipo + "','buscar','toolbar=0,location=0,directories=0,status=0,menubar=0,scrollbars=0,resizable=0,width='+ancho+',height='+alto+',left='+xpos+',top='+ypos+''); ";
        strScript2 = strINI_JS + strTamaño + strPos + strScript2 + strFIN_JS;
        ScriptManager.RegisterStartupScript(this, typeof(Page), "win", strScript2.ToString(), false);
        #endregion js

    }
    protected void btnEliminar_Click(object sender, ImageClickEventArgs e)
    {
        //Master.OcultarMensaje();
        //ClearRowsMenu();
        bool continuar;
        bool.TryParse(Request.Form["hdnContinuar"], out continuar);
        if (continuar)
        {
            if (gv.SelectedIndex != -1)
            {
                string str_codigo = gv.SelectedRow.Cells[1].Text.ToString();
                Eliminar(str_codigo);
            }
            else
            {
                Master.MostrarMensaje(Mensaje.M_SELECCIONAR_REGISTRO, TipoMensaje.Advertencia);
                return;
            }
        }
        else
        {
            Master.MostrarMensaje(Mensaje.M_OPERACION_CANCELADA, TipoMensaje.Advertencia);
        }
    }
    protected void btnSalir_Click(object sender, ImageClickEventArgs e)
    {
        string estado = (String)ViewState[Mant_ViewState.Estado];

        string lstCodUsuario = hd_idusuario.Value;
        string lstEstado = "&estado=" + estado;
        Response.Redirect("MantUsuarioDetalle.aspx?IdUsuario=" + lstCodUsuario + lstEstado);
    }

    protected void btn_GrabarUsuarioPerfil_Click(object sender, EventArgs e)
    {
        try
        {
            Grabar_UsuarioPerfil();
            //Refresca_Acciones(hd_IdOpcionOpcion.Value);
        }
        catch (Exception ex)
        {
            Master.MostrarMensaje(ex.ToString(), TipoMensaje.Error);
        }
    }

    protected void btn_REFRESCAR_Click(object sender, EventArgs e)
    {
        Master.OcultarMensaje();
        #region Sesion
        string cempresa = (String)this.Session["cempresa"]; ;
        if (cempresa == "" || cempresa == null)
        {
            this.Session.Abandon();
            Response.Redirect("../Login.aspx?rd=0");
            return;
        }
        #endregion Sesion
        Refresca_Grid("1");
        up_GV.Update();
    }
    #endregion eventos
    #region metodos
    private void Refresca_Grid(string str_TIPO)
    {
        //****************************************************************************************
        //* Nomre       :Refresca_Grid
        //* DescripcioN :
        //****************************************************************************************
        DataTable dt;
        try
        {
            dt = Obtener_Datos(str_TIPO);

            gv.DataSource = dt;
            gv.DataBind();

            if (dt.Rows.Count > 0)
            {
                lblCantidad.Text = "Total: " + dt.Rows.Count.ToString() + " Registros";
                lblPaginaGrilla.Text = "[Registros: " + Convert.ToString((gv.PageIndex * gv.PageSize) + 1) + "-" + Convert.ToString(gv.PageIndex * gv.PageSize + gv.PageSize) + "]";
            }
            else
            {
                lblCantidad.Text = "Total: 0 Registros";
                lblPaginaGrilla.Text = "[Registros: 0-0 ]";
            }

            ClearRowsMenu();
            gv.SelectedIndex = -1;
            gv.EditIndex = -1;
            gv.PageIndex = 0;
            up_GV.Update();




        }
        catch (Exception ex)
        {
            Master.MostrarMensaje(ex.Message.ToString(), TipoMensaje.Error, ex);
        }
    }
    protected void ClearRowsMenu()
    {
        //hd_IdOpcionMenu.Value = "";
    }

    protected void InicioOperacion()
    {
        //****************************************************************************************
        //* Nomre       : InicioOperacion
        //* DescripcioN :
        //****************************************************************************************
        try
        {
            string str_Estado = "";
            string str_IdUsuario = "";


            if (Request["idusuario"] != null)
            {
                str_IdUsuario = Request["idusuario"];
                hd_idusuario.Value = str_IdUsuario;
            }

            if (Request["estado"] != null)
            {
                str_Estado = Request["estado"];
            }

            mstrEstado = str_Estado;
            ViewState.Add("estado", mstrEstado);

        }
        catch (Exception excp)
        {
            MostrarMensaje(excp.Message.ToString(), true);
        }
    }


    #endregion metodos
    #region grid
    protected void gv_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        //****************************************************************************************
        //* Nomre       :gv_PageIndexChanging
        //* DescripcioN :
        //****************************************************************************************
        gv.PageIndex = e.NewPageIndex;
        Refresca_Grid("1");
    }
    protected void gv_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        //****************************************************************************************
        //* Nomre       :gv_RowDataBound
        //* DescripcioN :
        //****************************************************************************************
        try
        {

            //***
            //ddlPaginaIr.Items.Clear();
            for (int i = 0; i < gv.PageCount; i++)
            {
                ListItem pageListItem = new ListItem(string.Concat("Página ", i + 1), i.ToString());
                //  ddlPaginaIr.Items.Add(pageListItem);

                if (i == gv.PageIndex)
                    pageListItem.Selected = true;
            }
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    protected void gv_Sorting(object sender, GridViewSortEventArgs e)
    {
        //****************************************************************************************
        //* Nomre       :gv_Sorting
        //* DescripcioN :
        //****************************************************************************************
        hfOrden.Value = e.SortExpression;
        Refresca_Grid("1");
    }
    protected void ddlPaginado_SelectedIndexChanged(object sender, EventArgs e)
    {
        //****************************************************************************************
        //* Nomre       :ddlPaginado_SelectedIndexChanged
        //* DescripcioN :
        //****************************************************************************************

        Refresca_Grid("1");
    }
    protected void ddlPaginaIr_SelectedIndexChanged(object sender, EventArgs e)
    {
        //****************************************************************************************
        //* Nomre       :ddlPaginaIr_SelectedIndexChanged
        //* DescripcioN :
        //****************************************************************************************
        //gv.PageIndex = Convert.ToInt32(ddlPaginaIr.SelectedValue);
        //Refresca_Grid("1");
    }
    protected void gv_SelectedIndexChanged(object sender, EventArgs e)
    {
        Master.OcultarMensaje();
        #region Sesion
        string cempresa = (String)this.Session["cempresa"]; ;
        if (cempresa == "" || cempresa == null)
        {
            this.Session.Abandon();
            Response.Redirect("../Login.aspx?rd=0");
            return;
        }
        #endregion Sesion

        hd_IdOpcionMenu.Value = gv.SelectedRow.Cells[1].Text.ToString();

        if (hd_IdOpcionMenu.Value.Length < 1)
        {
            Master.MostrarMensaje("No se ha definido id paso ", TipoMensaje.Advertencia);
        }


    }
    #endregion grid
    #region datos
    private DataTable Obtener_Datos(string str_TIPO)
    {
        //****************************************************************************************
        //* Nomre       :Obtener_Datos
        //* DescripcioN :
        //****************************************************************************************

        LoUsuario objLoUsuario = new LoUsuario();
      
        #region validacion

        #endregion validacion

        List<EnUsuario> ListEnUsuario = new List<EnUsuario>();
        EnUsuario objEnUsuario = new EnUsuario();


        objEnUsuario.CEmpresa = (String)this.Session["cempresa"];
        objEnUsuario.id = hd_idusuario.Value;

        ListEnUsuario.Add(objEnUsuario);
               
        DataTable dt = null;
        try
        {           
            dt = objLoUsuario.Lista_UsuarioPorPerfil(ListEnUsuario);                       
        }
        catch (Exception ex)
        {
            throw ex;
        }
        return dt;
    }
    private void Eliminar(string str_cod1)
    {
        //****************************************************************************************
        //* Nomre       : Grabar
        //* DescripcioN :
        //****************************************************************************************
        LoUsuario objLoUsuario = new LoUsuario();

        string msg = "";
        string Exito = "";
        try
        {
            #region Carga_Variable

            List<EnUsuario> ListEnUsuario = new List<EnUsuario>();
            EnUsuario objEnUsuario = new EnUsuario();

            objEnUsuario.CEmpresa = (String)this.Session["cempresa"];
            objEnUsuario.IdUsuarioPerfil = str_cod1;

            ListEnUsuario.Add(objEnUsuario);
            #endregion Carga_Variable

            msg = objLoUsuario.Elimina_UsuarioPerfil(ListEnUsuario);

            if (msg == "") { Exito = FlagsPrograma.FLG_VALOREXITOSI; } else { Master.MostrarMensaje(msg, TipoMensaje.Error, msg); Exito = FlagsPrograma.FLG_VALOREXITONO; return; }

            Exito = FlagsPrograma.FLG_VALOREXITOSI;
        }
        catch (SqlException ex)
        {
            msg = HttpUtility.HtmlEncode(ex.Message);
            Master.MostrarMensaje(msg, TipoMensaje.Error);
            Exito = FlagsPrograma.FLG_VALOREXITONO;
        }
        catch (Exception ex)
        {
            msg = HttpUtility.HtmlEncode(ex.Message);
            Master.MostrarMensaje(msg, TipoMensaje.Error);
            Exito = FlagsPrograma.FLG_VALOREXITONO;

        }
        if (Exito == FlagsPrograma.FLG_VALOREXITOSI)
        {
            Master.MostrarMensaje("Se Elimino Correctamente.", TipoMensaje.Exito);
            Refresca_Grid("1");
            up_GV.Update();
        }
    }
    private void Grabar_UsuarioPerfil()
    {
        //****************************************************************************************
        //* Nomre       : Grabar
        //* DescripcioN :
        //****************************************************************************************
        LoUsuario objLoUsuario = new LoUsuario();
        string msg = "";
        string Exito = "";
        try
        {
            #region Carga_Variable
            List<EnUsuario> ListEnUsuario = new List<EnUsuario>();
            EnUsuario objEnUsuario = new EnUsuario();

            objEnUsuario.CEmpresa = (String)this.Session["cempresa"];
            objEnUsuario.id  = hd_idusuario.Value;
            objEnUsuario.IdPerfil = hd_idperfil.Value;
            objEnUsuario.codUsuario = (String)this.Session["codusuario"];
            ListEnUsuario.Add(objEnUsuario);
            #endregion Carga_Variable
            msg = objLoUsuario.Insertar_UsuarioPerfil(ListEnUsuario);
            if (msg == "") { Exito = "si"; } else { Master.MostrarMensaje(msg, TipoMensaje.Error, msg); Exito = "no"; return; }

            Exito = "si";
        }
        catch (SqlException ex)
        {
            msg = HttpUtility.HtmlEncode(ex.Message);
            Master.MostrarMensaje(msg, TipoMensaje.Error);
            Exito = "no";
        }
        catch (Exception ex)
        {
            msg = HttpUtility.HtmlEncode(ex.Message);
            Master.MostrarMensaje(msg, TipoMensaje.Error);
            Exito = "no";
        }
        if (Exito == "si")
        {
            Master.MostrarMensaje(Mensaje.M_REGISTRO_CORRECTO, TipoMensaje.Exito);
            Refresca_Grid("");
            //hd_IdOpcionOpcion.Value = gv2.SelectedRow.Cells[1].Text.ToString();
            //Refresca_Acciones(hd_IdOpcionOpcion.Value.Trim());
            //up_GV2.Update();                
        }
    }
    #endregion datos
    #endregion Perfil
    #region Seleccionar
    protected override void Render(System.Web.UI.HtmlTextWriter writer)
    {
        AddRowSelectToGridView(gv);
        base.Render(writer);
    }
    private void AddRowSelectToGridView(GridView gv)
    {
        #region select
        if (gv.EditIndex == -1)
        {
            foreach (GridViewRow row in gv.Rows)
            {
                #region Old
                //row.Attributes["OnMouseOut"] = "this.className = this.orignalclassName;";
                //row.Attributes["OnMouseOver"] = "this.orignalclassName = this.className;this.className = 'selectedrow4';";
                //row.Attributes["onMouseDown"] = "this.className = 'selectedrow';";
                #endregion Old

                row.Attributes["OnMouseOut"] = "this.className = this.orignalclassName;";
                row.Attributes["OnMouseOver"] = "javascript:if (this.className == 'selectedrow') {this.orignalclassName = this.className; this.className = 'selectedrow';}else {this.orignalclassName = this.className; this.className = 'selectedrow4';}";
                row.Attributes["onMouseDown"] = "this.className = 'selectedrow';";

                row.Attributes.Add("onclick", Page.ClientScript.GetPostBackEventReference(gv, "Select$" + row.RowIndex.ToString(), true));


            }
        }
        #endregion select
    }
    #endregion Seleccionar
    #region Mensajes
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
    }
    protected void limpiarMensaje()
    {
        //**********************************************************************************************
        //*	 limpiarMensaje : limpia mensaje de avisos.
        //**********************************************************************************************
        lblMensaje.Text = "";
        lblMensaje.ForeColor = Color.Red;
        upBotonera.Update();
    }
    #endregion Mensajes
    #region AccesosAccion
    protected override void BloqueaAcciones()
    {
        try
        {
            btnAgregar.Enabled = false;
            btnEliminar.Enabled = false;

        }
        catch (Exception ex)
        {
            MostrarMensaje(ex.Message.ToString(), true);
        }
    }

    protected override void ActivaAccionesComunes()
    {
        try
        {
            Propiedades_Boton(btnSalir, "salir");
            Propiedades_Boton(btnAgregar, "agregar");
            Propiedades_Boton(btnEliminar, "eliminar");
        }
        catch (Exception ex)
        {
            MostrarMensaje(ex.Message.ToString(), true);
        }
    }

    protected override void ActivaAccion(string accion)
    {
        try
        {
            switch (accion)
            {
                /*
                case Accion.Agregar_Perfil:
                    Propiedades_Boton(btnAgregar, "agregar");
                    break;

                case Accion.Eliminar_Perfil:
                    Propiedades_Boton(btnEliminar, "eliminar");
                    break;
              */ 
            }
        }
        catch (Exception ex)
        {
            MostrarMensaje(ex.Message.ToString(), true);
        }
    }
    #endregion AccesosAccion
}