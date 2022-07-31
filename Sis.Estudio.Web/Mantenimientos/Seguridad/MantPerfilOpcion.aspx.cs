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
using IABaseWeb;
public partial class Mantenimientos_Seguridad_MantPerfilOpcion : BaseMantDetalle
{
    #region Declaraciones
    public string mstrEstado;
    public string mstrId;
    string strEmpresa;
    #endregion  Declaraciones
    #region eventos
    protected void Page_Load(object sender, EventArgs e)
    {
        //****************************************************************************************
        //* Nomre       : Page_Load
        //* DescripcioN :
        //****************************************************************************************
        if (!IsPostBack)
        {
            this.Master.TituloModulo = "Opciones de  Perfil";
            G_idopcion = OpcionModulo.MantPerfil;
            #region accesos
            Accesos();
            #endregion accesos

            tvOpciones.Attributes.Add("onclick", "TreeViewPostBack();");
            InicioOperacion();

            //======================    Fin Apariencia JavaScript de botones  =====================================================//            
            btnGrabar.Attributes.Add("onClick", "document.getElementById('hdnContinuar').value = confirm('Los datos se guardarán, ¿Desea continuar?');");
            //====================== Funcionabilidad JavaScript de botones j. Aroni E.=============================================//

            //=================================== Fin  Funcionabilidad JavaScript =================================================//
        }
    }
    protected void btnGrabar_Click(object sender, ImageClickEventArgs e)
    {
        //****************************************************************************************
        //* Nomre       :btnGrabar_Click 
        //* DescripcioN :
        //****************************************************************************************
        limpiarMensaje();
        #region Sesion
        string cempresa = (String)this.Session["cempresa"]; ;
        if (cempresa == "" || cempresa == null)
        {
            this.Session.Abandon();
            Response.Redirect("../Login.aspx?rd=0");
            return;
        }
        #endregion Sesion
        bool continuar;
        bool.TryParse(Request.Form["hdnContinuar"], out continuar);
        if (continuar)
        {
            //VALIDACION
            if (txt_IDPERFIL.Text.Length < 1)  //VALIDA
            {
                return;
            }

            Actualiza_PerfilOpcion();
        }
        else
        {
            MostrarMensaje(Mensajes.MSG_MENSAJECANCELACION, true);
        }
    }
    protected void btnSalir_Click(object sender, ImageClickEventArgs e)
    {
        #region Sesion
        string cempresa = (String)this.Session["cempresa"]; ;
        if (cempresa == "" || cempresa == null)
        {
            this.Session.Abandon();
            Response.Redirect("../Login.aspx?rd=0");
            return;
        }
        #endregion Sesion

        string estado = (String)ViewState[Mant_ViewState.Estado];
        string str_idmodulo = "?idmodulo=" + Convert.ToString(hd_IDMODULO.Value);
        string str_idperfil = "&idperfil=" + txt_IDPERFIL.Text;
        string lstEstado = "&estado=" + estado;
        Response.Redirect("MantPerfilDetalle.aspx" + str_idmodulo + str_idperfil + lstEstado);
    }
    protected void btnActualizarOpciones_Click(object sender, EventArgs e)
    {
        //lbtnDeshacerCambios.Enabled = true;
    }
    protected void lbtnDeshacerCambios_Click(object sender, EventArgs e)
    {
        try
        {
            Carga_PerfilOpcion(txt_IDPERFIL.Text);
            upControles.Update();
        }
        catch
        {
            MostrarMensaje("No se cargo correctamtne el IDPERFIL", true);
        }
    }
    #endregion eventos
    #region Procedimientos
    protected void InicioOperacion()
    {
        //****************************************************************************************
        //* Nomre       : InicioOperacion
        //* DescripcioN :
        //****************************************************************************************
        try
        {
            string str_Estado = "";
            string str_IDPERFIL = "";
            string str_NOMBRE = "";
            string str_idmodulo = "";
            string str_desmodulo = "";

            if (Request["idperfil"] != null)
            {
                str_IDPERFIL = (String)Request["idperfil"];
                str_NOMBRE = (String)Request["nombre"];
                str_idmodulo = (String)Request["idmodulo"];
                str_desmodulo = (String)Request["desmodulo"];

                txt_IDPERFIL.Text = str_IDPERFIL;
                txt_NOMBRE.Text = str_NOMBRE;
                hd_IDMODULO.Value = str_idmodulo;
                txt_DESMODULO.Text = str_desmodulo;
                Carga_Opciones();
                Carga_PerfilOpcion(str_IDPERFIL);
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
    private void Carga_Opciones()
    {
        //**********************************************************************************************
        //*	 Carga_Opciones(). carga las opciones que existe por todo el sistema para pintar el arbol
        //**********************************************************************************************
        try
        {
            LoPerfil objLoPerfil = new LoPerfil();
            List<EnPerfil> ListEnPerfil = new List<EnPerfil>();
            EnPerfil objEnPerfil = new EnPerfil();
           
            DataTable dt = new DataTable();
            DataTable dt_accion = new DataTable();
            
            objEnPerfil.CEmpresa = (String)this.Session["cempresa"];
            objEnPerfil.IdModulo = hd_IDMODULO.Value;
            ListEnPerfil.Add(objEnPerfil);
            dt = objLoPerfil.Carga_OpcionesParaArbol(ListEnPerfil);
            dt_accion = objLoPerfil.Carga_AccionesParaArbol(ListEnPerfil);
            if (dt.Rows.Count > 0)
            {
                tvOpciones.Visible = true;
                lblSinDatosOpcion.Visible = false;
            }
            else
            {
                tvOpciones.Visible = false;
                lblSinDatosOpcion.Visible = true;
            }
            tvOpciones.Nodes.Clear();
            foreach (DataRow row in dt.Rows)
            {
                //if (row[0].ToString() == row[1].ToString())
                if (row[TOA.TipoOpcion].ToString() == "1")
                {
                    TreeNode tnodo;
                    tnodo = new TreeNode();
                    tnodo.Text = row[2].ToString();
                    tnodo.Value = row[0].ToString();
                    tnodo.Checked = false;
                    tnodo.SelectAction = TreeNodeSelectAction.None;
                    tnodo.Target = "1";
                    pfm_UbicarHijos(row[0].ToString(), tnodo, dt, dt_accion);
                    tvOpciones.Nodes.Add(tnodo);
                }
            }
            tvOpciones.CollapseAll();
        }
        catch (Exception Exp)
        {
            throw Exp;
        }
    }
    private void Carga_PerfilOpcion(string str_IDPERFIL)
    {
        //**********************************************************************************************
        //*	 Carga_PerfilOpcion() lista las opciones por el idperfil
        //**********************************************************************************************
        try
        {

            LoPerfil objLoPerfil = new LoPerfil();
            List<EnPerfil> ListEnPerfil = new List<EnPerfil>();
            EnPerfil objEnPerfil = new EnPerfil();

            
            DataTable dt = new DataTable();
            DataTable dt_accion = new DataTable();
            
            objEnPerfil.IdPerfil  = str_IDPERFIL;
            objEnPerfil.CEmpresa  = (String)this.Session["cempresa"];

            ListEnPerfil.Add(objEnPerfil);

            #region opcion
            dt = objLoPerfil.Carga_PerfilOpcionesParaArbol(ListEnPerfil);            
            #endregion opcion

            #region accion
            //WCF
            dt_accion = objLoPerfil.Carga_PerfilAccionesParaArbol(ListEnPerfil);            
            //WCF
            #endregion accion

            ChecaModulo(dt, tvOpciones.Nodes, dt_accion);
            tvOpciones.CollapseAll();
        }

        catch (Exception Exp)
        {
            throw Exp;
        }
    }
    #endregion Procedimientos
    #region arbol
    private void ChecaModulo(DataTable dt, TreeNodeCollection nodos, DataTable dt_accion)
    {
        //**********************************************************************************************
        //*	 ChecaOpionesUsuario() Selecciona las opciones que tiene el IDPERFIL
        //**********************************************************************************************
        try
        {
            foreach (DataRow row in dt.Rows)
            {
                foreach (TreeNode nodo in nodos)
                {
                    string target = nodo.Target.ToString();
                    if (target == "1")
                    {
                        if (row[1].ToString() == nodo.Value)
                        {
                            nodo.Checked = true;
                        }
                        if (nodo.ChildNodes.Count > 0)
                        {
                            ChecaOpciones(dt, nodo.ChildNodes, dt_accion);
                        }
                    }
                }
            }
        }
        catch (Exception Exp)
        {
            throw Exp;
        }
    }

    private void ChecaOpciones(DataTable dt, TreeNodeCollection nodos, DataTable dt_accion)
    {
        try
        {

            string str_opcion = "";

            foreach (DataRow row in dt.Rows)
            {
                foreach (TreeNode nodo in nodos)
                {
                    string target = nodo.Target.ToString();
                    if (target == "2")
                    {
                        if (row[1].ToString() == nodo.Value)
                        {
                            nodo.Checked = true;
                        }

                        if (nodo.ChildNodes.Count > 0)
                        {
                            str_opcion = nodo.Text.ToString();
                            str_opcion = nodo.Value.ToString();
                            ChecaAcciones(dt_accion, nodo.ChildNodes, str_opcion);
                        }
                    }
                }
            }
        }
        catch (Exception Exp)
        {
            throw Exp;
        }
    }

    private void ChecaAcciones(DataTable dt, TreeNodeCollection nodos, string opcion)
    {
        try
        {

            #region recorreDT
            foreach (DataRow row in dt.Rows)
            {
                string idopcion_Opcion = opcion;
                string idopcion_Accion = "";

                idopcion_Accion = row["idopcion"].ToString();
                if (idopcion_Opcion == idopcion_Accion)
                {
                    #region recorre_Arbol
                    foreach (TreeNode nodo in nodos)
                    {
                        string dato = nodo.Text;
                        dato = nodo.Value.ToString();
                        string target = nodo.Target.ToString();
                        if (target == "3")
                        {
                            if (row["idaccion"].ToString() == nodo.Value)
                            {
                                nodo.Checked = true;
                            }
                        }
                    }
                    #endregion recorre_Arbol
                }
            }
            #endregion recorreDT

        }
        catch (Exception Exp)
        {
            throw Exp;
        }
    }

    private void pfm_UbicarHijos(string CodtnPadre, TreeNode tn, DataTable dt, DataTable dt_accion)
    {
        foreach (DataRow row in dt.Rows)
        {
            if (row[TOA.IDOPCIONPADRE].ToString() == CodtnPadre && row[TOA.IDOPCION].ToString() != CodtnPadre)
            {
                TreeNode tnodo;
                tnodo = new TreeNode();
                tnodo.Text = row[2].ToString();
                tnodo.Value = row[0].ToString();
                tnodo.Checked = false;
                tnodo.Target = "2";
                tnodo.SelectAction = TreeNodeSelectAction.None;

                //pfm_UbicarHijos(row[0].ToString(), tnodo, dt);
                pfm_UbicarAccion(row[TOA.IDOPCION].ToString(), tnodo, dt_accion);
                tn.ChildNodes.Add(tnodo);
            }
        }
    }
    private void pfm_UbicarAccion(string idOpcion, TreeNode tn, DataTable dt_accion)
    {
        foreach (DataRow row in dt_accion.Rows)
        {
            if (row[ArbolAccion.IdOpcion].ToString() == idOpcion)
            {
                TreeNode tnodo;
                tnodo = new TreeNode();
                tnodo.Text = row[ArbolAccion.Nombre].ToString();
                tnodo.Value = row[ArbolAccion.IdAccion].ToString();
                tnodo.Checked = false;
                tnodo.Target = "3";
                tnodo.SelectAction = TreeNodeSelectAction.None;
                //pfm_UbicarHijos(row[0].ToString(), tnodo, dt);
                tn.ChildNodes.Add(tnodo);
            }
        }
    }
    protected void tvOpciones_TreeNodeCheckChanged(object sender, TreeNodeEventArgs e)
    {
        pfm_ChecaDesChecaHijos(e.Node, e.Node.Checked);
        pfm_ChecaDesChecaPadres(e.Node, e.Node.Checked);
    }
    private void pfm_ChecaDesChecaHijos(TreeNode ptnnodo, bool pblValor)
    {
        if (ptnnodo.ChildNodes.Count > 0)
        {
            foreach (TreeNode nodoshijos in ptnnodo.ChildNodes)
            {
                nodoshijos.Checked = pblValor;
                pfm_ChecaDesChecaHijos(nodoshijos, pblValor);
            }
        }
    }
    private void pfm_ChecaDesChecaPadres(TreeNode ptnnodo, bool pblValor)
    {
        if (ptnnodo.Parent != null)
        {
            if (pblValor == true)
            {
                ptnnodo.Parent.Checked = true;
            }
            else
            {
                int i = 0;
                foreach (TreeNode nodoshijos in ptnnodo.Parent.ChildNodes)
                {
                    if (nodoshijos.Checked == pblValor)
                        i += 1;
                }
                if (i == ptnnodo.Parent.ChildNodes.Count)
                    ptnnodo.Parent.Checked = pblValor;

                pfm_ChecaDesChecaPadres(ptnnodo.Parent, pblValor);
            }
        }
    }
    private DataTable AgregarNodosDT(TreeNodeCollection nodos, DataTable dt)
    {
        foreach (TreeNode nodo in nodos)
        {
            string target = nodo.Target.ToString();
            if (target != "3")
            {
                if (nodo.Checked == true)
                {
                    DataRow dr;
                    dr = dt.NewRow();
                    dr["IdOpcion"] = nodo.Value;
                    dt.Rows.Add(dr);
                }
                if (nodo.ChildNodes.Count > 0)
                {
                    AgregarNodosDT(nodo.ChildNodes, dt);
                }
            }
        }
        return dt;
    }

    private DataTable AgregarNodosDTAccion(TreeNodeCollection nodos, DataTable dt)
    {
        TreeNode nodoPadre = new TreeNode();

        foreach (TreeNode nodo in nodos)
        {
            string target = nodo.Target.ToString();

            if (target == "3")
            {
                nodoPadre = nodo.Parent;

                string nodopadrevalue = nodoPadre.Value.ToString();

                if (nodopadrevalue == "3")
                {

                    string temp = "";
                }

                if (nodo.Checked == true)
                {
                    DataRow dr;

                    dr = dt.NewRow();
                    dr["IdOpcion"] = nodoPadre.Value;
                    dr["IdAccion"] = nodo.Value;
                    dt.Rows.Add(dr);
                }
            }

            if (nodo.ChildNodes.Count > 0)
            {
                AgregarNodosDTAccion(nodo.ChildNodes, dt);
            }

        }
        return dt;
    }

    #endregion arbol
    #region Datos
    private void Actualiza_PerfilOpcion()
    {
        //****************************************************************************************
        //* Nomre       :pfm_ActualizarPerfilOpcion()
        //* DescripcioN :
        //****************************************************************************************
        try
        {

            LoPerfil objLoPerfil = new LoPerfil();

            #region Cabecera
            List<EnPerfil> ListEnPerfil = new List<EnPerfil>();
            EnPerfil objEnPerfil = new EnPerfil();
            objEnPerfil.IdPerfil = txt_IDPERFIL.Text;
            objEnPerfil.CEmpresa = (String)this.Session["cempresa"];            
            objEnPerfil.CodUsuario = (String)this.Session["codusuario"];
            ListEnPerfil.Add(objEnPerfil);
            #endregion Cabecera

            #region Opcion

            List<EnOpcion> ListEnOpcion = new List<EnOpcion>();
            EnOpcion objEnOpcion;

            DataTable dt = new DataTable();
            DataColumn dc = new DataColumn();
            dc.DataType = System.Type.GetType("System.Int32");
            dc.ColumnName = "IdOpcion";
            dt.Columns.Add(dc);
            dt = AgregarNodosDT(tvOpciones.Nodes, dt);

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                objEnOpcion = new EnOpcion();
                objEnOpcion.IdOpcion = dt.Rows[i]["IdOpcion"].ToString();
                ListEnOpcion.Add(objEnOpcion);
            }
            #endregion Opcion

            #region Acciones

            DataTable dt_accion = new DataTable();
            DataColumn dc_accion = new DataColumn();

            DataColumn dc_opcion = new DataColumn();
            dc_opcion.DataType = System.Type.GetType("System.Int32");
            dc_opcion.ColumnName = "IdOpcion";
            dt_accion.Columns.Add(dc_opcion);

            dc_accion.DataType = System.Type.GetType("System.Int32");
            dc_accion.ColumnName = "IdAccion";
            dt_accion.Columns.Add(dc_accion);
            dt_accion = AgregarNodosDTAccion(tvOpciones.Nodes, dt_accion);




            List<EnOpcionAccion> ListOpcionAccion = new List<EnOpcionAccion>();
            int int_CantFilas = dt_accion.Rows.Count;
            //String[,] arrAccion = new String[2, int_CantFilas];
            for (int i = 0; i < int_CantFilas; i++)
            {
                //arrAccion[0, i] = dt_accion.Rows[i]["IdOpcion"].ToString();
                //arrAccion[1, i] = dt_accion.Rows[i]["IdAccion"].ToString();

                EnOpcionAccion EnOA = new EnOpcionAccion();
                EnOA.IdOpcion = dt_accion.Rows[i]["IdOpcion"].ToString();
                EnOA.IdAccion = dt_accion.Rows[i]["IdAccion"].ToString();

                ListOpcionAccion.Add(EnOA);
            }

            //procesarArray(threeDimensional);

            #endregion Acciones

            objLoPerfil.TransaccionPerfilOpcion(ListEnPerfil, ListEnOpcion, ListOpcionAccion);
            InicioOperacion();
            MostrarMensaje("Se Registró Correctamente", false);
        }
        catch (Exception ex)
        {
            MostrarMensaje(ex.Message.ToString(), true);
        }
    }

    private void procesarArray(String[,] arrAccion)
    {
        int int_CantFilas = arrAccion.GetLength(1);


        for (int i = 0; i < int_CantFilas; i++)
        {
            string VALOR = arrAccion[0, i].ToString();
            string VALOR2 = arrAccion[1, i].ToString();
        }

    }

    #endregion Datos
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
        upBotonera.Update();
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
            btnGrabar.Enabled = false;
            btnSalir.Enabled = false;
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
            Propiedades_Boton(btnGrabar, "grabar");
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
            {/*
                case Accion.Agregar_Opcion:
                    Propiedades_Boton(btnGrabar, "grabar");
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