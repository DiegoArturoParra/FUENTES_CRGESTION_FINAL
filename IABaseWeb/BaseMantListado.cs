using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web.Security;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Drawing;
using Sis.Estudio.Entity;
using Sis.Estudio.Logic.MSSQL.Seguridad;

namespace IABaseWeb
{
    public class BaseMantListado : BaseWeb
    {
        #region Declaraciones
        #region Controles

        public static GridView gv;
        public static DropDownList ddlPaginaIr;
        public static DropDownList ddlPaginado;
        public static HiddenField hfOrden;
        public static Label lblCantidad;
        public static Label lblPaginaGrilla;

        

        #endregion Controles
        #region Variables
        //public string G_idopcion = "";
        public string PaginaRetorno = "";
        public DataTable DT_Datos;
        public string mstrEstado;
        public int G_Accion = 0;
        #endregion Variables
        #endregion  Declaraciones
        #region Eventos
        #region Eventos_GridView
        protected void gv_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            try
            {
                ddlPaginaIr.Items.Clear();
                for (int i = 0; i < gv.PageCount; i++)
                {
                    ListItem pageListItem = new ListItem(string.Concat("Página ", i + 1), i.ToString());
                    ddlPaginaIr.Items.Add(pageListItem);

                    if (i == gv.PageIndex)
                        pageListItem.Selected = true;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        protected void gv_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {

            

            gv.PageIndex = e.NewPageIndex;
            RefrescarGrid();
        }
        protected void gv_Sorting(object sender, GridViewSortEventArgs e)
        {

            hfOrden.Value = e.SortExpression;
            RefrescarGrid();
        }
        protected void ddlPaginado_SelectedIndexChanged(object sender, EventArgs e)
        {

            gv.PageSize = Convert.ToInt32(ddlPaginado.SelectedValue);
            RefrescarGrid();
        }
        protected void ddlPaginaIr_SelectedIndexChanged(object sender, EventArgs e)
        {

            gv.PageIndex = Convert.ToInt32(ddlPaginaIr.SelectedValue);
            RefrescarGrid();
        }
        #endregion Eventos_GridView
        #region Eventos_Botones
        protected void btnBuscar_Click(object sender, EventArgs e)
        {


            limpiarMensaje();
            G_Accion = 1;
            //this.Master.OcultarMensaje();
            gv.SelectedIndex = -1;
            gv.EditIndex = -1;
            gv.PageIndex = 0;
            Ejecutar_Busqueda();
        }
        protected void btnLimpiar_Click(object sender, EventArgs e)
        {
            limpiarMensaje();
            //this.Master.OcultarMensaje();
            Limpiar_Filtros();
            RefrescarGrid();
        }
        protected virtual void Limpiar_Filtros()
        {

        }

        #endregion Eventos_Botones
        #endregion Eventos#region Metodos
        #region ConfiguracionIncial
        protected void ConfiguracionInicial()
        {

            CargarCombosOpcionesGrilla();
            G_Accion = 0; //TOP
            RefrescarGrid();
        }

        protected void CargarCombosOpcionesGrilla()
        {
            CargarPaginado();
        }
        protected void CargarPaginado()
        {
            ddlPaginado.Items.Add(new ListItem("10 Registros", "10"));
            ddlPaginado.Items.Add(new ListItem("15 Registros", "15"));
            ddlPaginado.Items.Add(new ListItem("20 Registros", "20"));
            ddlPaginado.Items.Add(new ListItem("25 Registros", "25"));
            ddlPaginado.SelectedValue = "10";
        }
        #endregion ConfiguracionIncial
        #region RefrescaGrid
        protected void RefrescarGrid()
        {
            if (hfOrden.Value == string.Empty)
            {
                pfm_CargarGrillaSinOrden();
            }
            else
            {
                pfm_CargarGrillaConOrden();
            }
        }
        protected void pfm_CargarGrillaSinOrden()
        {

            DataTable dt;
            try
            {
                Obtener_Datos();
                dt = DT_Datos;
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
            }
            catch (Exception ex)
            {
                MostrarMensaje(ex.Message.ToString(), true);
                
            }
        }
        protected void pfm_CargarGrillaConOrden()
        {
            DataTable dt;
            DataView dv;
            try
            {
                Obtener_Datos();
                dt = DT_Datos;
                dv = new DataView(dt);
                dv.Sort = hfOrden.Value;
                gv.DataSource = dv;
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
            }
            catch (Exception ex)
            {
                
                MostrarMensaje(ex.Message, true);
            }
        }
        #endregion RefrescaGrid
        #region Funciones

        protected virtual void Ejecutar_Busqueda()
        {

        }

        protected virtual void Obtener_Datos()
        {

        }
        #endregion Funciones        
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
                    #region Pruebas_Old
                    //row.Attributes["OnMouseOut"] = "this.className = this.orignalclassName;";
                    //row.Attributes["OnMouseOver"] = "this.orignalclassName = this.className;this.className = 'selectedrow4';";
                    //row.Attributes["onMouseDown"] = "this.className = 'selectedrow';";

                    //row.Attributes["OnMouseOut"] = "javascript:estilofila(this,'out');";
                    //row.Attributes["OnMouseOver"] = "javascript:estilofila(this,'over');";
                    //row.Attributes["onMouseDown"] = "javascript:estilofila(this,'down');";
                    #endregion Pruebas_Old


                    row.Attributes["OnMouseOut"] = "this.className = this.orignalclassName;";
                    row.Attributes["OnMouseOver"] = "javascript:if (this.className == 'selectedrow') {this.orignalclassName = this.className; this.className = 'selectedrow';}else {this.orignalclassName = this.className; this.className = 'selectedrow4';}";
                    row.Attributes["onMouseDown"] = "this.className = 'selectedrow';";
                    row.Attributes.Add("onclick", Page.ClientScript.GetPostBackEventReference(gv, "Select$" + row.RowIndex.ToString(), true));

                }
            }
            #endregion select
        }
        #endregion Seleccionar
        
    }
}
