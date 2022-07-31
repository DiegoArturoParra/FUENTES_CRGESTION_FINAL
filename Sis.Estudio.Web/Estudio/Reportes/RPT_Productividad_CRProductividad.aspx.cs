using Sis.Estudio.Entity;
using Sis.Estudio.Logic.MSSQL.Gestion;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Excel = Microsoft.Office.Interop.Excel;

public partial class Estudio_Reportes_RPT_Productividad_CRProductividad : System.Web.UI.Page
{
    DataSet ldsResultado;
    DataSet ldsExportarAExcel;
    public string lcNombreArchivo;
    public string lcRutaLocal;
    public string lcRutaCompartida;

    protected void Page_Load(object sender, EventArgs e)
    {
        ScriptManager scriptManager = ScriptManager.GetCurrent(this.Page);
        scriptManager.RegisterPostBackControl(this.btn_Excel);

        btn_Excel.Focus();
        
        mxTraerRutaDescarga();
        if (!Page.IsPostBack)
        {
            this.Master.TituloModulo = "CRProductividad";
            Inicio();
        }
    }

    private void Inicio()
    {
        //Cargar_Modulos();
        CargaComboJerarquiaB();
        CargaComboJerarquiaC("0");
        CargaComboAsesores("0");
        Util.mxGrantAccess(lcRutaLocal);

    }

    private void mxTraerRutaDescarga()
    {
        DataTable ldtResult = new DataTable();
        LoGS_Gestion_Cobranza objLogica = new LoGS_Gestion_Cobranza();
        ldtResult = objLogica.mxTraerRutaDescarga("RutCRPro");
        lcRutaLocal = ldtResult.Rows[0]["cRutLocal"].ToString();
        lcRutaCompartida = ldtResult.Rows[0]["cRutCompartida"].ToString();
    }

    protected void btn_Excel_Click(object sender, EventArgs e)
    {
        string cempresa = string.Empty;
        try
        {
            Master.OcultarMensaje();
            if (txt_FECHAVISITA.Text.Trim().Length == 0)
            {
                Master.MostrarMensaje("Ingresar fecha", TipoMensaje.Advertencia);
                txt_FECHAVISITA.Focus();
            }
            else
            {
                cempresa = (String)this.Session["cempresa"];
                if (!string.IsNullOrEmpty(cempresa))
                {
                    this.mxObtenerResultadoReporteProductividad(Convert.ToDateTime(txt_FECHAVISITA.Text));
                    //Exportar(Extencion.Excel);
                    if (ldsResultado.Tables[0].Rows.Count > 0)
                    {
                        this.mxRetornarDataSetAExportar(ldsResultado);
                        this.mxDescargarReporteProductividad(lcNombreArchivo);
                    }
                    else
                    {
                        Master.MostrarMensaje("No existen registros para la fecha seleccionada", TipoMensaje.Advertencia);
                        return;
                    }
                }
                else
                {
                    this.Session.Abandon();
                    Response.Redirect("../Login.aspx?rd=0");
                    return;
                }
            }
        }
        catch (Exception ex)
        {
            Master.MostrarMensaje(ex.Message.ToString(), TipoMensaje.Error);
        }
    }


    private DataSet mxObtenerResultadoReporteProductividad(DateTime pcFechaResultado)
    {
        string lcEmpresa, ldFechaResultado, lcJerarquiaA, lcJerarquiaB, lcJerarquiaC, lcJerarquiaD, lcCodAsesor;
        lcEmpresa = ldFechaResultado = lcJerarquiaA = lcJerarquiaB = lcJerarquiaC = lcJerarquiaD = lcCodAsesor = string.Empty;
        ldsResultado = new DataSet();
        LoGS_Gestion_Cobranza objLogica = new LoGS_Gestion_Cobranza();
        EnGS_Gestion_Cobranza objEntidad = new EnGS_Gestion_Cobranza();
        List<EnGS_Gestion_Cobranza> ListEntidad = new List<EnGS_Gestion_Cobranza>();


        lcEmpresa = (String)Session[Global.NEmpresa].ToString();
        ldFechaResultado = pcFechaResultado.ToString("yyyyMMdd");
        lcJerarquiaB = cmb_JerarquiaB.SelectedValue.ToString();
        lcJerarquiaC = cmb_JerarquiaC.SelectedValue.ToString();
        lcJerarquiaD = cmb_JerarquiaD.SelectedValue.ToString();
        lcCodAsesor = cmb_JerarquiaD.SelectedValue.ToString();

        objEntidad.nEmpresa = lcEmpresa;
        objEntidad.FechaResultado = ldFechaResultado;
        objEntidad.cod_jerarquiaB = lcJerarquiaB;
        objEntidad.cod_jerarquiaC = lcJerarquiaC;
        objEntidad.cod_jerarquiaD = lcJerarquiaD;
        objEntidad.CodUsuario_Asesores = lcCodAsesor;

        ListEntidad.Add(objEntidad);
        ldsResultado = objLogica.mxObtenerResultadoReporteProductividad(ListEntidad);

        return ldsResultado;
    }

    private DataSet mxRetornarDataSetAExportar(DataSet ldsResultado)
    {
        ldsExportarAExcel = new DataSet();

        this.mxResumen();
        this.mxGestionesRealizadas_Recibidas();
        this.mxCuadroProcentual();
        //this.mxGenerarExcelConDataSet();
        ExportDataSetToExcel(ldsExportarAExcel, string.Empty);
        

        return ldsExportarAExcel;
    }

    //private void mxDataSetAExportar_Resumen(DataSet pdsResultado, ref DataSet pdsExportarAExcel)
    //{
    //    DataTable ldtResumen = new DataTable();
    //    ldtResumen = pdsResultado.Tables["ldsResultado1"];
    //    int lnResumenCount;
    //    string lcNombreColumna, lnCantidad, lcDesTipoGestionAnt, lcDesTipoGestionNue;
    //    lcNombreColumna = lnCantidad = lcDesTipoGestionAnt = lcDesTipoGestionNue = string.Empty;
        

    //    lnResumenCount = ldtResumen.Rows.Count;

    //    for (int i = 0; i < lnResumenCount; i++)
    //    {
    //        DataRow dr = ldtResumen.NewRow();
    //        lcDesTipoGestionNue = ldtResumen.Rows[i]["cDesTipoGestion"].ToString();
    //        if (lcDesTipoGestionAnt != lcDesTipoGestionNue)
    //        {
    //            for (int j = 0; j < ldtResumen.Columns.Count; j++)
    //            {
    //                lcNombreColumna = ldtResumen.Columns[j].ToString();
    //                var lcValor = pdsResultado.Tables[2].Select("cDesTipoGestion = '" + ldtResumen.Rows[i]["cDesTipoGestion"].ToString() + "'");

    //                if (lcValor.Length > 0)
    //                {
    //                    var lcValor2 = pdsResultado.Tables[2].Select("cDesTipoGestion = '" + ldtResumen.Rows[i]["cDesTipoGestion"].ToString() + "' AND dFecResultado = '" + ldtResumen.Columns[j].ToString() + "'");
                        
    //                    if (j < pdsResultado.Tables[2].Columns.Count && lcNombreColumna == pdsResultado.Tables[2].Columns[j].ToString())
    //                    {
    //                        lnCantidad = lcValor.CopyToDataTable().Rows[0][lcNombreColumna].ToString();
    //                    }
    //                    else
    //                    {
    //                        if ((j < pdsResultado.Tables[2].Columns.Count && lcNombreColumna != pdsResultado.Tables[2].Columns[j].ToString()) || (lcValor2.Length == 0))
    //                        {
    //                            lnCantidad = "0";
    //                        }
    //                        else
    //                        {
    //                            lnCantidad = lcValor2.CopyToDataTable().Rows[0]["nCantidad"].ToString();
    //                        }
    //                    }
    //                }
    //                dr[j] = lnCantidad;
    //            }
    //            ldtResumen.Rows.Add(dr);
    //        }

    //        lcDesTipoGestionAnt = lcDesTipoGestionNue;
    //    }

    //    DataView dv = new DataView(ldtResumen);
    //    dv.Sort = "cGrupo, cCodTipoGestion, cCodTipoContacto ASC";
    //    ldtResumen = dv.ToTable();

    //    pdsResultado.Tables.Remove("ldsResultado1");
    //    pdsResultado.Tables.Add(ldtResumen);
    //}
    //private void mxDataSetAExportar_Resumen2(DataSet pdsResultado, ref DataSet pdsExportarAExcel, string pcAgrupadoPor)
    //{
    //    DataTable ldtResumen = new DataTable();
    //    ldtResumen = pdsResultado.Tables["ldsResultado1"];
    //    int lnResumenCount;
    //    string lcNombreColumna, lnCantidad, lcDesTipoGestionAnt, lcDesTipoGestionNue;
    //    lcNombreColumna = lnCantidad = lcDesTipoGestionAnt = lcDesTipoGestionNue = string.Empty;


    //    lnResumenCount = ldtResumen.Rows.Count;

    //    for (int i = 0; i < lnResumenCount; i++)
    //    {
    //        DataRow dr = ldtResumen.NewRow();
    //        lcDesTipoGestionNue = ldtResumen.Rows[i][pcAgrupadoPor].ToString();
    //        if (lcDesTipoGestionAnt != lcDesTipoGestionNue)
    //        {
    //            for (int j = 0; j < ldtResumen.Columns.Count; j++)
    //            {
    //                lcNombreColumna = ldtResumen.Columns[j].ToString();
    //                var lcValor = pdsResultado.Tables[2].Select(pcAgrupadoPor + " = '" + ldtResumen.Rows[i][pcAgrupadoPor].ToString() + "'");

    //                if (lcValor.Length > 0)
    //                {
    //                    var lcValor2 = pdsResultado.Tables[2].Select(pcAgrupadoPor +" = '" + ldtResumen.Rows[i][pcAgrupadoPor].ToString() + "' AND dFecResultado = '" + ldtResumen.Columns[j].ToString() + "'");

    //                    if (j < pdsResultado.Tables[2].Columns.Count && lcNombreColumna == pdsResultado.Tables[2].Columns[j].ToString())
    //                    {
    //                        lnCantidad = lcValor.CopyToDataTable().Rows[0][lcNombreColumna].ToString();
    //                    }
    //                    else
    //                    {
    //                        if ((j < pdsResultado.Tables[2].Columns.Count && lcNombreColumna != pdsResultado.Tables[2].Columns[j].ToString()) || (lcValor2.Length == 0))
    //                        {
    //                            lnCantidad = "0";
    //                        }
    //                        else
    //                        {
    //                            lnCantidad = lcValor2.CopyToDataTable().Rows[0]["nCantidad"].ToString();
    //                        }
    //                    }
    //                }
    //                dr[j] = lnCantidad;
    //            }
    //            ldtResumen.Rows.Add(dr);
    //        }

    //        lcDesTipoGestionAnt = lcDesTipoGestionNue;
    //    }

    //    DataView dv = new DataView(ldtResumen);
    //    dv.Sort = "cGrupo, cCodTipoGestion, cCodTipoContacto ASC";
    //    ldtResumen = dv.ToTable();

    //    pdsResultado.Tables.Remove("ldsResultado1");
    //    pdsResultado.Tables.Add(ldtResumen);
    //}

    private void mxResumen()
    {
        this.mxDataSetAExportar_Agrupamiento_Por_Niveles(ldsResultado, "cDesTipoGestion", "ldsResultado1", "ldsResultado3", "cGrupo, cCodTipoGestion, cCodTipoContacto ASC",1);
        this.mxDataSetAExportar_Agrupamiento_Por_Niveles(ldsResultado, "cGrupo", "ldsResultado1", "ldsResultado4", "cGrupo, cCodTipoGestion, cCodTipoContacto ASC", 2);
        this.mxAgregarColumnaSumatoriaTotal_Vertical("ldsResultado1", 5);
        this.mxAdministrarColumnas_A_Mostrar("ldsResultado1", "", "cGrupo,cCodTipoGestion,cDesTipoGestion");
        this.mxAgregar_DataTable_A_DataSet("ldsResultado1", "Resumen");

    }
    private void mxGestionesRealizadas_Recibidas()
    {
        this.mxDataSetAExportar_Agrupamiento_Por_Niveles(ldsResultado, "cDesTipoContacto", "ldsResultado", "ldsResultado2", "cGrupo, cCodTipoGestion, cCodTipoContacto, cCodResultado ASC",1);
        this.mxDataSetAExportar_Agrupamiento_Por_Niveles(ldsResultado, "cDesTipoGestion", "ldsResultado", "ldsResultado3", "cGrupo, cCodTipoGestion, cCodTipoContacto, cCodResultado ASC",2);
        this.mxDataSetAExportar_Agrupamiento_Por_Niveles(ldsResultado, "cGrupo", "ldsResultado", "ldsResultado4", "cGrupo, cCodTipoGestion, cCodTipoContacto, cCodResultado ASC",3);
        this.mxAgregarColumnaSumatoriaTotal_Vertical("ldsResultado", 7);
        this.mxAdministrarColumnas_A_Mostrar("ldsResultado", "", "cGrupo,cCodTipoGestion,cDesTipoGestion,cCodTipoContacto,cDesTipoContacto");
        this.mxAgregar_DataTable_A_DataSet("ldsResultado", "Gestiones_Realizadas_Recibidas");
    }
    private void mxCuadroProcentual()
    {
        this.mxAdministrarColumnas_A_Mostrar("ldsResultado1", "cCodTipoContacto,cDesTipoContacto,nTotal,nNivel", "");
        this.mxAgregarColumnaPorcentajeTotal_Vertical("ldsResultado1", 3);
        this.mxAgregar_DataTable_A_DataSet("ldsResultado1", "Cuadro_Porcentual"/*"Cuadro_Porcentual"*/);
    }

    private void mxDataSetAExportar_Agrupamiento_Por_Niveles(DataSet pdsResultado, string pcAgrupadoPor, string pcNombreTablaOrigen, string pcNombreTablaForanea, string pcOrdenadoPor, int pnNivel)
    {
        DataTable ldtResumen = new DataTable();
        ldtResumen = pdsResultado.Tables[pcNombreTablaOrigen];
        int lnResumenCount;
        string lcNombreColumna, lnCantidad, lcDesTipoGestionAnt, lcDesTipoGestionNue, lcFiltroSelect;
        lcNombreColumna = lnCantidad = lcDesTipoGestionAnt = lcDesTipoGestionNue = lcFiltroSelect = string.Empty;
        //Creamos una variable ya que este DataTable va ir variando segun se le agregen nuevas filas.
        lnResumenCount = ldtResumen.Rows.Count;
        if (ldtResumen.Columns.IndexOf("nNivel") == -1)
            ldtResumen.Columns.Add("nNivel", typeof(Int32));

        //Recorremos todos las filas de la tabla
        for (int i = 0; i < lnResumenCount; i++)
        {
            //Creamos un DataRow donde agregaremos la sumatoria segun el Campo a agrupar
            DataRow ldrAgrupado = ldtResumen.NewRow();
            //Creamos esta variable (lcDesTipoGestionNue) para hacer una comparacion entre el nuevo y antiguo valor.
            lcDesTipoGestionNue = ldtResumen.Rows[i][pcAgrupadoPor].ToString();

            //Validamos si el valor antiguo y el anterior son diferentes, ya que si corresponden a un mismo grupo, no deberia ingresar a la sentencia.
            if (lcDesTipoGestionAnt != lcDesTipoGestionNue)
            {
                for (int j = 0; j < ldtResumen.Columns.Count; j++)
                {
                    lcNombreColumna = ldtResumen.Columns[j].ToString();

                    //Usamos filtro que se encuetran ya definidos y solo validamos cunado en nombre de la tabla que enviamos como parametro
                    //sea "ldsResultado4" ya que es el que tiene mas columnas y por ende otro tipo de filtro
                    lcFiltroSelect = pdsResultado.Tables[pcNombreTablaForanea].TableName != "ldsResultado4" ?
                                     "cDesTipoGestion = '" + ldtResumen.Rows[i]["cDesTipoGestion"].ToString() + "' AND " + pcAgrupadoPor + " = '" + ldtResumen.Rows[i][pcAgrupadoPor].ToString() + "'" :
                                     pcAgrupadoPor + " = '" + ldtResumen.Rows[i][pcAgrupadoPor].ToString() + "'";
                    
                    //Obtenemos un arreglo con el nombre enviado mediante el parametro de la tabla y aplicamos el filtro segun parametro tambien.
                    var lcValor  = pdsResultado.Tables[pcNombreTablaForanea].Select(lcFiltroSelect);
                    
                    //Validamos que el arreglo lcValor, tenga al menos un registro.
                    if (lcValor.Length > 0)
                    {
                        //Luego realizamos un filtro mas detallado, donde segmentaremos por la fecha de resultado, usando el campo "dFecResultado"
                        var lcValor2 = pdsResultado.Tables[pcNombreTablaForanea].Select(lcFiltroSelect + " AND dFecResultado = '" + ldtResumen.Columns[j].ToString() + "'");

                        //1ra Condicion: Validamos que la columna en la que se haga la busqueda no sobrepase el limite de columnas de la tabla FORANEA
                        // Y
                        //2da Condicion: El nombre de la columna de la tabla Principal, debe ser igual al nombre de la columna de la tabla foranea
                        if (j < pdsResultado.Tables[pcNombreTablaForanea].Columns.Count && lcNombreColumna == pdsResultado.Tables[pcNombreTablaForanea].Columns[j].ToString())
                        {
                            //Con eso tenemos que la columna de la fecha, concidira con el regeistro encontrado el en arreglo de "lcValor2"
                            lnCantidad = lcValor.CopyToDataTable().Rows[0][lcNombreColumna].ToString();
                        }
                        else
                        {
                            //1ra Condicion: Validamos que la columna en la que se haga la busqueda no sobrepase el limite de columnas de la tabla FORANEA
                            // Y
                            //2da Condicion: El nombre de la columna de la tabla Principal, debe ser igual al nombre de la columna de la tabla foranea
                            // O
                            //3ra Condicion: Que el valor del arreglo "lcValor2" este vacio.
                            if ((j < pdsResultado.Tables[pcNombreTablaForanea].Columns.Count && lcNombreColumna != pdsResultado.Tables[pcNombreTablaForanea].Columns[j].ToString()) || (lcValor2.Length == 0))
                            {
                                lnCantidad = "0";
                            }
                            else
                            {
                                lnCantidad = lcValor2.CopyToDataTable().Rows[0]["nCantidad"].ToString();
                            }
                        }
                    }
                    ldrAgrupado[j] = lnCantidad;
                    ldrAgrupado["nNivel"] = pnNivel;
                }
                ldtResumen.Rows.Add(ldrAgrupado);
            }
            lcDesTipoGestionAnt = lcDesTipoGestionNue;
        }
        //Finalmente, ordenamos segun el orden enviado mediante el parametro y volvemos a agregar la tabla al DataSet.
        DataView dv = new DataView(ldtResumen);
        dv.Sort = pcOrdenadoPor;
        ldtResumen = dv.ToTable();

        pdsResultado.Tables.Remove(pcNombreTablaOrigen);
        pdsResultado.Tables.Add(ldtResumen);
    }
    private void mxAgregarColumnaSumatoriaTotal_Vertical(string pcNombreTabla, int pnUbicacionColumnaTotal)
    {
        DataTable ldtTabla = new DataTable();
        int lnSubTotalPorFila;
        string lcNombreGrupo;

        ldtTabla = ldsResultado.Tables[pcNombreTabla];
        ldtTabla.Columns.Add("nTotal", typeof(Int32));
        lcNombreGrupo = string.Empty;

        for (int i = 0; i < ldtTabla.Rows.Count; i++)
        {
            //Reiniciamos el valor de lnSubTotalPorFila, ya que en cada iteracion realizara la sumatorio por fila
            lnSubTotalPorFila = 0;

            for (int j = 0; j < ldtTabla.Columns.Count; j++)
            {
                //Creamos una variable para que setee el valor solo cuando su valor sea diferente de "0".
                lcNombreGrupo = ldtTabla.Rows[i][j].ToString() != "0" ? ldtTabla.Rows[i][j].ToString() : lcNombreGrupo; 

                //Verificamos que la celda seleccionada tenga informacion
                if (ldtTabla.Rows[i][j].ToString() != string.Empty)
                {
                    //Verificamos que el nombre de la columna tenga dentro de sus caracteres el valor de '/', ya que es indicativo que es una FECHA
                    if (ldtTabla.Columns[j].ToString().Contains('/'))
                    {
                        //Solo en este caso se hara la sumatoria de los registros
                        lnSubTotalPorFila += int.Parse(ldtTabla.Rows[i][j].ToString().ToString());
                    }
                    else
                    {
                        //Verifica que la siguiente columna NO sea un campo de FECHA, ya que esto indicaria que es la ultima columna a considerar.
                        if (!ldtTabla.Columns[j+1].ToString().Contains('/'))
                        {
                            //Valida que la siguiente columna a la actual, sea diferente de CERO.
                            if (ldtTabla.Rows[i][j + 1].ToString() != "0")
                            {
                                //Se asignara el valor de la siguiente columna a la actual
                                lcNombreGrupo = ldtTabla.Rows[i][j + 1].ToString();
                            }
                        }
                        //Ingresa solo si la columna siguiente es el de tipo FECHA y le asigna el ultimo valor correcto a la celda.
                        else
                        {
                            ldtTabla.Rows[i][j] = lcNombreGrupo;
                        }
                    }
                }
                else
                {
                    ldtTabla.Rows[i][j] = "0";
                }
            }
            ldtTabla.Rows[i]["nTotal"] = lnSubTotalPorFila;
        }
        //Indicamos la posicion que tomara la fila recientemente agregada.
        ldtTabla.Columns["nTotal"].SetOrdinal(pnUbicacionColumnaTotal); 
    }
    private void mxAgregarColumnaPorcentajeTotal_Vertical(string pcNombreTabla, int pnUbicacionColumnaTotal)
    {
        DataTable ldtTabla = new DataTable();
        int lnSubTotalPorFila, lnNivelNuevo, lnNivelAntiguo;
        double lnPorcentaje;
        string lcNombreGrupo;

        ldtTabla = ldsResultado.Tables[pcNombreTabla];
        ldtTabla.Columns.Add("nPorcentaje", typeof(String));
        lnNivelNuevo = lnNivelAntiguo = 0;
        lcNombreGrupo = string.Empty;

        #region ObtenerCantidadNiveles

        var hashSet = new HashSet<Int32>();

        foreach (DataRow dr in ldtTabla.Rows)
        {
            int itemNo = Convert.ToInt32(dr["nNivel"]);

            // Only unique elements are added to the hash set, 
            // no need to check for duplicates
            hashSet.Add(itemNo);
        }

        var items = new List<Int32>(hashSet);

        int nNumNiv = items.Count();

        #endregion ObtenerCantidadNiveles


        int[] laValor = new int[nNumNiv];
        foreach (DataRow dr in ldtTabla.Rows)
        {
            lnNivelNuevo = int.Parse(dr["nNivel"].ToString());

            if (lnNivelNuevo != lnNivelAntiguo)
            {
                laValor[lnNivelNuevo] = int.Parse(dr["nTotal"].ToString());
            }

            lnPorcentaje = lnNivelNuevo < nNumNiv - 1 ? Math.Round(Math.Round(Convert.ToDouble(dr["nTotal"]) / Convert.ToDouble(laValor[lnNivelNuevo + 1]) * 100 * 100)) / 100 : 100;

            dr["nPorcentaje"] = lnPorcentaje.ToString() + "%";
            lnNivelAntiguo = int.Parse(dr["nNivel"].ToString());
        }
        #region comentario
        /*
        for (int i = 0; i < ldtTabla.Rows.Count; i++)
        {
            //Reinicimos el valor de lnSubTotalPorFila, ya que en cada iteracion realizara la sumatorio por fila
            lnSubTotalPorFila = 0;

            for (int j = 0; j < ldtTabla.Columns.Count; j++)
            {
                //Creamos una variable para que setee el valor solo cuando su valor sea diferente de "0".
                lcNombreGrupo = ldtTabla.Rows[i][j].ToString() != "0" ? ldtTabla.Rows[i][j].ToString() : lcNombreGrupo;

                //Verificamos que la celda seleccionada tenga informacion
                if (ldtTabla.Rows[i][j].ToString() != string.Empty)
                {
                    //Verificamos que el nombre de la columna tenga dentro de sus caracteres el valor de '/', ya que es indicativo que es una FECHA
                    if (ldtTabla.Columns[j].ToString().Contains('/'))
                    {
                        //Solo en este caso se hara la sumatoria de los registros
                        lnSubTotalPorFila += int.Parse(ldtTabla.Rows[i][j].ToString().ToString());
                    }
                    else
                    {
                        //Verifica que la siguiente columna NO sea un campo de FECHA, ya que esto indicaria que es la ultima columna a considerar.
                        if (!ldtTabla.Columns[j + 1].ToString().Contains('/'))
                        {
                            //Valida que la siguiente columna a la actual, sea diferente de CERO.
                            if (ldtTabla.Rows[i][j + 1].ToString() != "0")
                            {
                                //Se asignara el valor de la siguiente columna a la actual
                                lcNombreGrupo = ldtTabla.Rows[i][j + 1].ToString();
                            }
                        }
                        //Ingresa solo si la columna siguiente es el de tipo FECHA y le asigna el ultimo valor correcto a la celda.
                        else
                        {
                            ldtTabla.Rows[i][j] = lcNombreGrupo;
                        }
                    }
                }
                else
                {
                    ldtTabla.Rows[i][j] = "0";
                }
            }
        }*/
        #endregion cometario
        //Indicamos la posicion que tomara la fila recientemente agregada.
        ldtTabla.Columns["nPorcentaje"].SetOrdinal(pnUbicacionColumnaTotal);
    }
    private void mxAdministrarColumnas_A_Mostrar(string pcNombreTabla, string pcListaColumnasAMostrar, string pcListaColumnasAEliminar)
    {
        DataTable ldtTabla = new DataTable();
        string lcNomColDataTable;
        string[] laColumnasAMostrar = pcListaColumnasAMostrar.Split(',');
        string[] laColumnasAEliminar = pcListaColumnasAEliminar.Split(',');
        ldtTabla = ldsResultado.Tables[pcNombreTabla];


        for (int i = 0; i < ldtTabla.Columns.Count; i++)
        {
            lcNomColDataTable = ldtTabla.Columns[i].ToString();
            
            if (pcListaColumnasAMostrar != string.Empty )
            {
                if (laColumnasAMostrar.Length == 0)
                {
                    ldtTabla.Columns.Remove(lcNomColDataTable);
                    i--;
                    continue;
                }
                foreach (string lcNomCol in laColumnasAMostrar)
                {
                    if (lcNomCol.Equals(lcNomColDataTable))
                    {
                        List<string> list = new List<string>(laColumnasAMostrar);
                        list.Remove(lcNomColDataTable);
                        laColumnasAMostrar = list.ToArray();
                        break;
                    }
                    else
                    {
                        ldtTabla.Columns.Remove(lcNomColDataTable);
                        i--;
                        continue;
                    }
                }

            }
            else if (pcListaColumnasAEliminar != string.Empty)
            {
                foreach (string lcNomCol in laColumnasAEliminar)
                {
                    if (lcNomCol.Equals(lcNomColDataTable))
                    {
                        ldtTabla.Columns.Remove(lcNomCol);
                        i--;
                        break;
                    }
                }
            }
            else
            {
            }
        }
    }

    private void mxAgregar_DataTable_A_DataSet(string pcDataTable, string pcNombreHojaExcel)
    {
        DataTable lcDataTable = new DataTable();
        //ldsExportarAExcel = new DataSet();
        lcDataTable = ldsResultado.Tables[pcDataTable];

        //lcDataTable.TableName = pcNombreHojaExcel;

        if (!ldsExportarAExcel.Tables.Contains(pcNombreHojaExcel))
        {
            ldsExportarAExcel.Tables.Add(lcDataTable.Copy());
            ldsExportarAExcel.Tables[pcDataTable].TableName = pcNombreHojaExcel;
        }
    }

    private void mxGenerarExcelConDataSet()
    {
        //this.mxGenerarExportado(ldsExportarAExcel);
    }
    /*private void ExportDataSetToExcel(DataSet ds)
    {
        //Creae an Excel application instance
        Excel.Application excelApp = new Excel.Application();

        //Create an Excel workbook instance and open it from the predefined location
        Excel.Workbook excelWorkBook = excelApp.Workbooks.Open(@"E:\Org.xlsx");

        foreach (DataTable table in ds.Tables)
        {
            //Add a new worksheet to workbook with the Datatable name
            Excel.Worksheet excelWorkSheet = excelWorkBook.Sheets.Add();
            excelWorkSheet.Name = table.TableName;

            for (int i = 1; i < table.Columns.Count + 1; i++)
            {
                excelWorkSheet.Cells[1, i] = table.Columns[i - 1].ColumnName;
            }

            for (int j = 0; j < table.Rows.Count; j++)
            {
                for (int k = 0; k < table.Columns.Count; k++)
                {
                    excelWorkSheet.Cells[j + 2, k + 1] = table.Rows[j].ItemArray[k].ToString();
                }
            }
        }

        excelWorkBook.Save();
        excelWorkBook.Close();
        excelApp.Quit();

    }*/
    //private void mxGenerarExportado(DataSet pdsTablas)
    //{
    //    Excel.Application excel = new Excel.Application();
    //    var workbook = (Excel._Workbook)(excel.Workbooks.Add(Missing.Value));
    //    int lnPosicionColumna;
    //    string lcCelda, lcCelda2 ;
    //    for (int i = 0; i < pdsTablas.Tables.Count; i++)
    //    {
    //        if (workbook.Sheets.Count <= i)
    //        {
    //            workbook.Sheets.Add(Type.Missing, Type.Missing, Type.Missing, Type.Missing);
    //        }
    //        //NOTE: Excel numbering goes from 1 to n
    //        var currentSheet = (Excel._Worksheet)workbook.Sheets[i + 1];
    //        lnPosicionColumna = 1;
    //        currentSheet.Name = pdsTablas.Tables[i].TableName.Substring(3);

    //        for (int a = 1; a < pdsTablas.Tables[i].Columns.Count + 1; a++)
    //        {
    //            currentSheet.Cells[1, a] = pdsTablas.Tables[i].Columns[a - 1].ColumnName;
    //        }

    //        for (int y = 0; y < pdsTablas.Tables[i].Rows.Count; y++)
    //        {
    //            lnPosicionColumna = 1;
    //            //for (int x = 0; x < pdsTablas.Tables[i].Rows[y].ItemArray.Count(); x++)
    //            //{
    //                //if (Array.IndexOf(laColumnas, pdsTablas.Tables[i].Columns[x].ColumnName.ToUpper()) >= 0)
    //                //{
    //            lcCelda = Util.ConvertirNumeroAColumnaExcel(lnPosicionColumna) + (y + 2).ToString();
    //            lcCelda2 = Util.ConvertirNumeroAColumnaExcel(lnPosicionColumna + pdsTablas.Tables[i].Rows.Count) + (y + 2).ToString();

    //                    //currentSheet.Columns.ColumnWidth = 25;
    //                    //currentSheet.get_Range(lcCelda1, lcCelda1).Cells.Font.Name = "Arial";
    //                    //currentSheet.get_Range(lcCelda1, lcCelda1).Font.Color = Color.Black;

    //                    //this.mxObtenerEstiloCelda(1, lcCelda1, ref currentSheet);

    //            currentSheet.get_Range(lcCelda, lcCelda2).Cells.Font.Bold = true;
    //            currentSheet.get_Range(lcCelda, lcCelda2).Cells.Font.Italic = true;
    //            currentSheet.get_Range(lcCelda, lcCelda2).Interior.Color = Color.White;
    //            currentSheet.get_Range(lcCelda, lcCelda2).Cells.Font.Name = "Arial";
    //            currentSheet.get_Range(lcCelda, lcCelda2).Font.Color = Color.Black;


    //                    currentSheet.Cells[y + 2, lnPosicionColumna] = pdsTablas.Tables[i].Rows[y].ItemArray[x];
    //                    lnPosicionColumna++;

    //                    //Elimanmos las columnas que ya usamos para que no se repitan en la siguiente hoja del archivo excel exportado.
    //                    //if (y + 1 >= pdsTablas.Tables[i].Rows.Count)
    //                    //{
    //                    //    var list = new List<string>(laColumnas);
    //                    //    list.Remove(pdsTablas.Tables[i].Columns[x].ColumnName.ToUpper());
    //                    //    laColumnas = list.ToArray();
    //                    //}
    //                //}
    //            //}
    //        }
    //    }
    //    string outfile = @"D:\FernandoRavelo\ExportadoGestiones_" + DateTime.Now.ToString("yyyyMMdd-HHmmss") + ".xlsx";

    //    workbook.SaveAs(outfile, Type.Missing, Type.Missing, Type.Missing,
    //                    Type.Missing, Type.Missing, Excel.XlSaveAsAccessMode.xlExclusive,
    //                    Type.Missing, Type.Missing, Type.Missing, Type.Missing,
    //                    Type.Missing);
    //    //workbook.SaveCopyAs(outfile);
    //    workbook.Close();
    //    excel.Quit();
    //}


    protected void ExportDataSetToExcel(DataSet ds, string fileName)
    {
        Excel.Workbook excelWorkBook = null;
        Excel.Workbook sourceWorkbook = null;
        Excel.Workbook destinationWorkbook = null;
        string convertedFilePath;
        convertedFilePath = string.Empty;
        try
        {
            Excel.Application excelApp = new Excel.Application();


            var convertedFilesDirectory = Path.Combine(@"C:\EXCEL\");

            if (!Directory.Exists(convertedFilesDirectory))
            {
                Directory.CreateDirectory(convertedFilesDirectory);
            }
            lcNombreArchivo = "ReporteProductividad_" + DateTime.Now.ToString("yyyyMMdd_HHmmss") + ".xls";
            convertedFilePath = Path.Combine(lcRutaCompartida, /*fileName*/ lcNombreArchivo);

            File.Copy(lcRutaLocal+@"ReporteProductividad_Template.xls", convertedFilePath, true);
            


            Excel._Workbook wb = null;


            excelApp.DisplayAlerts = false;
            wb = (Excel._Workbook)(excelApp.Workbooks.Add(Missing.Value));
            wb = excelApp.Workbooks.Add(convertedFilePath);



            Excel.Worksheet sheet = (Excel.Worksheet)wb.Worksheets[1];
            sheet.Cells[10, 2] = "ZONA: " + cmb_JerarquiaB.SelectedItem.Text;
            sheet.Cells[10, 5] = "AGENCIA: " + cmb_JerarquiaC.SelectedItem.Text;
            sheet.Cells[10, 8] = "ASESOR: " + cmb_JerarquiaD.SelectedItem.Text;

            sheet.Cells[12, 2] = cmb_JerarquiaB.SelectedItem.Text;
            sheet.Cells[12, 5] = cmb_JerarquiaC.SelectedItem.Text;
            sheet.Cells[12, 8] = txt_FECHAVISITA.Text;


            wb.SaveAs(convertedFilePath, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Excel.XlSaveAsAccessMode.xlNoChange, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing);
            wb.Close();

            excelApp = new Excel.Application();
            excelApp.Visible = false;

            //Create an Excel workbook instance and open it from the predefined location
            excelWorkBook = excelApp.Workbooks.Open(convertedFilePath);

            foreach (DataTable table in ds.Tables)
            {
                int lnMaxNivel = Convert.ToInt32(table.Compute("max([nNivel])", string.Empty)) + 1;

                //Add a new worksheet to workbook with the Datatable name
                Excel.Worksheet excelWorkSheet = (Excel.Worksheet)excelWorkBook.Sheets.Add(After: excelWorkBook.Sheets[excelWorkBook.Sheets.Count]);
                excelWorkSheet.Name = table.TableName;

                for (int i = 0; i < table.Columns.Count; i++)
                {
                    if (table.Columns[i].ToString() != "nNivel")
                    {
                        Excel.Range cel = (Excel.Range)excelApp.Cells[1, i+1];
                        cel.NumberFormat = "@";
                        cel.Font.Size = 12;
                        cel.Font.Bold = true;
                        cel.Interior.Color = System.Drawing.ColorTranslator.FromHtml("#C0C0C0");
                        cel.Borders.Color = Color.Black;
                        cel.Columns.AutoFit();

                        excelWorkSheet.Cells[1, i+1] = table.Columns[i].ColumnName;

                        if (table.Columns[i].ToString() == "cDesTipoContacto" || table.Columns[i].ToString() == "cDesResultado")
                        {
                            cel.ColumnWidth = 60;
                        }
                    }
                }

                for (int j = 0; j < table.Rows.Count; j++)
                {
                    for (int k = 0; k < table.Columns.Count; k++)
                    {

                        if (table.Columns[k].ToString() != "nNivel")
                        {
                            Excel.Range cel = (Excel.Range)excelApp.Cells[j + 2, k + 1];

                            int lnNivel = lnMaxNivel - int.Parse(table.Rows[j]["nNivel"].ToString());

                            switch (lnNivel)
                            {
                                case 1:
                                    cel.Font.Bold = true;
                                    cel.Font.Italic = true;
                                    cel.Interior.Color = Color.White;
                                    break;
                                case 2:
                                    cel.Font.Bold = true;
                                    cel.Font.Italic = true;
                                    cel.Interior.Color = System.Drawing.ColorTranslator.FromHtml("#538DD5");
                                    break;
                                case 3:
                                    cel.Font.Bold = true;
                                    cel.Font.Italic = true;
                                    cel.Interior.Color = System.Drawing.ColorTranslator.FromHtml("#8DB4E2");
                                    break;
                                case 4:
                                    cel.Interior.Color = System.Drawing.ColorTranslator.FromHtml("#D9D9D9");
                                    break;
                                default:
                                    break;

                            }
                            cel.Font.Name = "Arial";
                            cel.Font.Color = Color.Black;
                            cel.Borders.Color = Color.Black;


                            if (table.Columns[k].ToString() == "cDesTipoContacto" || table.Columns[k].ToString() == "cDesResultado")
                            {
                                if (table.Rows[j].ItemArray[k].ToString() == "1" || table.Rows[j].ItemArray[k].ToString() == "2" || table.Rows[j].ItemArray[k].ToString() == "3")
                                {
                                    switch (table.Rows[j].ItemArray[k].ToString())
                                    {
                                        case "1":
                                            table.Rows[j][k] = "GESTIONES REALIZADAS - (OUTBOUND)";
                                            break;
                                        case "2":
                                            table.Rows[j][k] = "GESTIONES RECIBIDAS - (INBOUND)";
                                            break;
                                        case "3":
                                            table.Rows[j][k] = "GESTIONES RECIBIDAS - (INBOUND)";
                                            break;
                                        default:
                                            table.Rows[j][k] = string.Empty;
                                            break;

                                    }
                                    cel.Font.Size = 14;
                                }
                            }

                            excelWorkSheet.Cells[j + 2, k + 1] = table.Rows[j].ItemArray[k].ToString();
                        }
                    }
                }
            }
            //excelWorkBook.Sheets.Move(After: excelWorkBook.Sheets.Count);
            excelWorkBook.Save();
            excelWorkBook.Close();

            excelApp.Quit();

            //File.Copy(convertedFilePath, @"D:\CRGESTION\FUENTES\FUENTES_CRGESTION\Sis.Estudio.Web\ReportesGerencialesModelo\ReporteProductividad\" + lcNombreArchivo, true);
            //File.Copy(convertedFilePath, lcRutaCompartida + lcNombreArchivo, true);
        }
        catch (Exception)
        {
            if (excelWorkBook != null) excelWorkBook.Close(true);
        }
    }
    private void mxDescargarReporteProductividad(string pcNombreArchivo)
    {
        string lcNomArchivo = lcRutaCompartida + pcNombreArchivo;
        string lcArcDestino = "ReporteProductividad.xls";
        this.mxDescargarArchivo(lcNomArchivo, lcArcDestino);
    }
    private void mxDescargarArchivo(string pcNomArchivo, string lcArcDestino)
    {
        try
        {
            if (!string.IsNullOrEmpty(pcNomArchivo))
            {
                Response.Clear();
                Response.Buffer = true;
                Response.ContentType = "application/vnd.ms-excel";
                Response.AddHeader("content-disposition", string.Format("attachment;filename=" + lcArcDestino));
                Response.Charset = "";
                Response.Cache.SetCacheability(HttpCacheability.NoCache);
                Response.TransmitFile(pcNomArchivo);
                //Response.Flush();
                //Response.Close();
                Response.End();
            }
        }
        catch (Exception ex)
        {
            Master.MostrarMensaje(ex.Message.ToString(), TipoMensaje.Error);
        }
    }
    private void mxObtenerEstiloCelda(int lnNivel, string pcCelda, ref Excel._Worksheet currentSheet)
    {
        switch (lnNivel)
        {
            case 1:
                currentSheet.Columns.ColumnWidth = 25;
                //currentSheet.Cells[1, lnPosicionColumna] = pdsTablas.Tables[i].Columns[a].ColumnName.ToUpper();
                currentSheet.get_Range(pcCelda, pcCelda).Cells.Font.Bold = true;
                currentSheet.get_Range(pcCelda, pcCelda).Cells.Font.Italic = true;
                currentSheet.get_Range(pcCelda, pcCelda).Interior.Color = Color.White;
                break;
            case 2:
                currentSheet.Columns.ColumnWidth = 25;
                //currentSheet.Cells[1, lnPosicionColumna] = pdsTablas.Tables[i].Columns[a].ColumnName.ToUpper();
                currentSheet.get_Range(pcCelda, pcCelda).Interior.Color = Color.Blue;
                break;
            case 3:
                currentSheet.Columns.ColumnWidth = 25;
                //currentSheet.Cells[1, lnPosicionColumna] = pdsTablas.Tables[i].Columns[a].ColumnName.ToUpper();
                currentSheet.get_Range(pcCelda, pcCelda).Interior.Color = Color.SkyBlue;
                break;
            case 4:
                currentSheet.Columns.ColumnWidth = 25;
                //currentSheet.Cells[1, lnPosicionColumna] = pdsTablas.Tables[i].Columns[a].ColumnName.ToUpper();
                currentSheet.get_Range(pcCelda, pcCelda).Interior.Color = Color.LightGray;
                break;
            default:
                break;
                
                
        
        }
        currentSheet.get_Range(pcCelda, pcCelda).Cells.Font.Name = "Arial";
        currentSheet.get_Range(pcCelda, pcCelda).Font.Color = Color.Black;
    }


    private void Exportar(string Formato)
    {
        try
        {
            //Declaramos la variables:
            string str_parametros, str_tiporeporte, str_nempresa, str_fecha, str_jerarquia_b, str_jerarquia_c, str_cod_asesor, lcConfig;
            str_parametros = str_tiporeporte = str_nempresa = str_fecha = str_jerarquia_b = str_jerarquia_c = str_cod_asesor = lcConfig = string.Empty;

            //this.Session["FechaReporte"] = txt_FECHAVISITA.Text.Trim();
            str_parametros = "";
            str_tiporeporte = "?tiporeporte=" + Formato;
            str_nempresa = "&nempresa=" + (String)Session[Global.NEmpresa].ToString();
            str_fecha = "&fecha=" + txt_FECHAVISITA.Text.Trim();
            str_jerarquia_b = "&jerarquiab=" + cmb_JerarquiaB.SelectedValue.ToString().Trim();
            str_jerarquia_c = "&jerarquiac=" + cmb_JerarquiaC.SelectedValue.ToString().Trim();
            //string str_jerarquia_d = "&jerarquiad=" + cmb_JerarquiaD.SelectedValue.ToString().Trim();
            str_cod_asesor = "&codasesor=" + cmb_JerarquiaD.SelectedValue.ToString().Trim();

            if (!string.IsNullOrEmpty(str_fecha) || str_fecha == "")
            {
                str_parametros = str_tiporeporte + str_nempresa + str_fecha + str_jerarquia_b + str_jerarquia_c + str_cod_asesor;

                lcConfig = "'resizable = yes, scrollbars = yes, toolbar=no, height = 500, width = 800,left=200,top=100,status=yes, location=no, menubar=no'";

                StringBuilder sb = new StringBuilder();
                sb.Append("<script>var win=window.open('../../Reportes/Reportes/ReporteProductividad_CRProductividad.aspx" + str_parametros + "', 'ReporteProductividad_CRProductividad', " + lcConfig + ");</script>");
                ScriptManager.RegisterStartupScript(this, typeof(Page), "ReporteAccion", sb.ToString(), false);
            }
            else
            {
                Master.MostrarMensaje("Debe ingresar una fecha", TipoMensaje.Error);
            }
        }
        catch (Exception excp)
        {
            Master.MostrarMensaje(excp.ToString(), TipoMensaje.Error);
        }
    }
    protected void btn_Imprimir_Click(object sender, EventArgs e)
    {

    }
    protected void cmb_JerarquiaB_SelectedIndexChanged(object sender, EventArgs e)
    {
        string jerarquiaB = "";
        jerarquiaB = cmb_JerarquiaB.SelectedValue.ToString();
        cmb_JerarquiaC.Items.Clear();
        cmb_JerarquiaD.Items.Clear();
        CargaComboJerarquiaC(jerarquiaB);
        CargaComboAsesores("0");
    }
    protected void cmb_JerarquiaC_SelectedIndexChanged(object sender, EventArgs e)
    {
        string jerarquiaC = "";
        jerarquiaC = cmb_JerarquiaC.SelectedValue.ToString().Trim();
        cmb_JerarquiaD.Items.Clear();
        CargaComboAsesores(jerarquiaC);
    }
    protected void cmb_JerarquiaD_SelectedIndexChanged(object sender, EventArgs e)
    {

    }

    protected void CargaComboJerarquiaB()
    {
        DataTable dt = new DataTable();
        LoGS_JerarquiaB objLoGS_JerarquiaB = new LoGS_JerarquiaB();
        LoGS_JerarquiaA objLoGS_JerarquiaA = new LoGS_JerarquiaA();
        try
        {
            EnGS_JerarquiaB objEnGS_JerarquiaB = new EnGS_JerarquiaB();
            EnGS_JerarquiaA objEnGS_JerarquiaA = new EnGS_JerarquiaA();
            List<EnGS_JerarquiaB> ListEnGS_JerarquiaB = new List<EnGS_JerarquiaB>();
            List<EnGS_JerarquiaA> ListEnGS_JerarquiaA = new List<EnGS_JerarquiaA>();
            cmb_JerarquiaB.Items.Clear();

            objEnGS_JerarquiaB.nempresa = (String)this.Session["cempresa"];
            objEnGS_JerarquiaA.nempresa=(String)this.Session["cempresa"];
            ListEnGS_JerarquiaA.Add(objEnGS_JerarquiaA);
            dt = objLoGS_JerarquiaA.GS_JerarquiaA_Combo(ListEnGS_JerarquiaA);
            objEnGS_JerarquiaB.cod_jerarquiaA = dt.Rows[1]["cod_jerarquiaA"].ToString().Trim();

            ListEnGS_JerarquiaB.Add(objEnGS_JerarquiaB);

            dt.Clear();
            dt = objLoGS_JerarquiaB.GS_JerarquiaB_Combo(ListEnGS_JerarquiaB);

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                ListItem lista = new ListItem();
                lista.Value = dt.Rows[i]["cod_jerarquiaB"].ToString().Trim();
                lista.Text = dt.Rows[i]["desc_jerarquiaB"].ToString().Trim();
                cmb_JerarquiaB.Items.Add(lista);
            }
        }
        catch (Exception excp)
        {
            throw excp;
        }
    }
    protected void CargaComboJerarquiaC(string jerarquiaB)
    {
        DataTable dt = new DataTable();
        LoGS_JerarquiaC objLoGS_JerarquiaC = new LoGS_JerarquiaC();
        try
        {
            EnGS_JerarquiaC objEnGS_JerarquiaC = new EnGS_JerarquiaC();
            List<EnGS_JerarquiaC> ListEnGS_JerarquiaC = new List<EnGS_JerarquiaC>();
            cmb_JerarquiaC.Items.Clear();

            
            objEnGS_JerarquiaC.cod_jerarquiaB = jerarquiaB;
            objEnGS_JerarquiaC.nempresa = (String)this.Session["cempresa"];

            ListEnGS_JerarquiaC.Add(objEnGS_JerarquiaC);


            dt = objLoGS_JerarquiaC.GS_JerarquiaC_Combo(ListEnGS_JerarquiaC);

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                ListItem lista = new ListItem();
                lista.Value = dt.Rows[i]["cod_jerarquiaC"].ToString().Trim();
                lista.Text = dt.Rows[i]["desc_jerarquiaC"].ToString().Trim();
                cmb_JerarquiaC.Items.Add(lista);
            }
        }
        catch (Exception excp)
        {
            throw excp;
        }
    }
    protected void CargaComboAsesores(string jerarquiaC)
    {
        DataTable dt = new DataTable();
        LoGS_JerarquiaC objLoGS_JerarquiaC = new LoGS_JerarquiaC();
        EnGS_JerarquiaC objEnGS_JerarquiaC = new EnGS_JerarquiaC();
        List<EnGS_JerarquiaC> ListEnGS_JerarquiaC = new List<EnGS_JerarquiaC>();
        LoGS_Gestion_Cobranza objLoGS_Gestion_Cobranza = new LoGS_Gestion_Cobranza();
        EnGS_Gestion_Cobranza objEnGS_Gestion_Cobranza = new EnGS_Gestion_Cobranza();
        List<EnGS_Gestion_Cobranza> ListEnGS_Gestion_Cobranza = new List<EnGS_Gestion_Cobranza>();
        objEnGS_Gestion_Cobranza.nEmpresa = (String)this.Session["cempresa"];//8
        try
        {
            //Llenamos empresa y cod de jerarquia B al objeto jerarquiaC
            //Esto para obtener el código del usuario administrador de la agencia seleccionada en cmb_JerarquiaB
            //Ya que para listar los asesores se necesita el código del administrador mediante el objeto objEnGS_GestionCobranza

            if (jerarquiaC=="0")
            {
                objEnGS_Gestion_Cobranza.CodUsuario = "0";
                ListEnGS_Gestion_Cobranza.Add(objEnGS_Gestion_Cobranza);
            }
            else
            {
                objEnGS_JerarquiaC.cod_jerarquiaC = jerarquiaC;
                objEnGS_JerarquiaC.nempresa = (String)this.Session["cempresa"];
                ListEnGS_JerarquiaC.Add(objEnGS_JerarquiaC);
                dt = objLoGS_JerarquiaC.GS_JerarquiaC_sp_ObtenerUsuario(ListEnGS_JerarquiaC);

                objEnGS_Gestion_Cobranza.CodUsuario = dt.Rows[0]["n_codi_usua"].ToString().Trim();
                ListEnGS_Gestion_Cobranza.Add(objEnGS_Gestion_Cobranza);
            }
            
            dt.Clear();
            cmb_JerarquiaD.Items.Clear();

            dt = objLoGS_Gestion_Cobranza.GS_Gestion_Cobranza_Asesores_x_Administrador_Lista(ListEnGS_Gestion_Cobranza);

            for (int i = 0; i < dt.Rows.Count; i++)
            {

                ListItem lista = new ListItem();
                //lista.Value = dt.Rows[i]["cod_jerarquiaD"].ToString().Trim();
                //lista.Text = dt.Rows[i]["nombres"].ToString().Trim();
                lista.Value = dt.Rows[i]["n_codi_usua"].ToString().Trim();
                lista.Text = dt.Rows[i]["nombres"].ToString().Trim();
                cmb_JerarquiaD.Items.Add(lista);

            }
        }
        catch (Exception excp)
        {
            throw excp;
        }
    }
}