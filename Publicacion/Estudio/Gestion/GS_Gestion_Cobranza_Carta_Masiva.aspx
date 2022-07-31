<%--<%@ Page Title="" Language="C#" MasterPageFile="~/Master/Ceem.master" AutoEventWireup="true"--%>
<%@ page title="" language="C#" masterpagefile="~/Master/GCCeem.master" autoeventwireup="true" inherits="Estudio_Gestion_GS_Gestion_Cobranza_Carta_Masiva, App_Web_m4xi2a1f" stylesheettheme="Standard" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<%@ Register Assembly="GMDatePicker" Namespace="GrayMatterSoft" TagPrefix="cc2" %>
<%@ Register Assembly="Flan.Controls" Namespace="Flan.Controls" TagPrefix="cc3" %>
<%--<%@ MasterType VirtualPath="~/Master/Ceem.master" %>--%>
<%@ MasterType VirtualPath="~/Master/GCCeem.master" %>



<asp:Content ID="Content1" ContentPlaceHolderID="DefaultContent" runat="Server">


<%--<script src="../../funciones/jquery-1.4.1.js" type="text/javascript"></script>--%>
<script  src="../../funciones/jquery.dataTables.js" type="text/javascript" ></script>


    <script type="text/javascript">


        $(function () {

            $("#lnkPopUp").change(function () {
                window.location.href = "idCarta=2&codTipoDocumento=4" + $("#PageSelectDropDown option:selected").attr('value');
            });
        });

            function fnAbrirPopUpFiltro() {
                var options = 'width=700,height=430,top=80,left=400,scrollbars=YES,menubar=NO,titlebar= NO,status=NO,toolbar=NO';
                window.open('../../Consultas/Busquedas/Filtro.aspx', 'Proveedores', options);
            }
            //function Enter_Buscar(evt) {
            //}

            //function Valida_Todos() {

            //}


            

        




        function SelectAllCheckboxes(spanChk) {
            var oItem = spanChk.children;
            var theBox = (spanChk.type == "checkbox") ? spanChk : spanChk.children.item[0];
            xState = theBox.checked;

            elm = theBox.form.elements;
            for (i = 0; i < elm.length; i++) {
                if (elm[i].type == "checkbox" && elm[i].id != theBox.id) {
                    if (elm[i].checked != xState) {
                        elm[i].click();
                    }
                }
            }
        }

    </script>

    <div class="account"></div>
    <div id="ad"></div>
    <div id="Div1"></div>

<%--    <script src="../../javascript/jquery-2.1.1.min.js"></script>
    <script src="../../funciones/bootstrap.min.js"></script>
    <link href="../../Estilo/bootstrap.min.css" rel="stylesheet" />--%>
    
    <asp:UpdatePanel ID="upGvUsuario" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
            <table id="TMensaje" cellpadding="0" cellspacing="0" width="100%">
                <tr>
                    <td class="altoverow" style="text-align: center">
                        <asp:ValidationSummary ID="vsError" runat="server" HeaderText="No puede realizar esta Operación:"
                            ShowMessageBox="True" ShowSummary="False" CssClass="Etiqueta" />
                        <asp:Label ID="lblMensaje" runat="server" CssClass="Etiqueta" ForeColor="Red"></asp:Label><input
                            id="hdnContinuar" name="hdnContinuar" style="width: 80px; height: 10px" type="hidden" />
                    </td>
                </tr>
            </table>
            <table id="TBotones" border="0" cellpadding="0" cellspacing="0" class="cabeceraScroll" width="100%">
                <tr>
                    <td align="left" style="width: 70%;">
                    </td>
                </tr>
            </table>
            <table  class="cabeceraScroll" style="width:100%">
                <tr>
                    <td>
                    </td>
                    <td>
                        <div>
                            <div>Seleccionar Operación:</div>
                            <div>
                                <div class="panel with-nav-tabs panel-default">
                                    <div class="panel-heading">
                                        <ul class="nav nav-tabs">
                                            <li class="active"><a href="#tabExportar" data-toggle="tab">Procesos masivos </a></li>
                                            <li><a href="#tabImportar" data-toggle="tab">Importar resultado</a></li>
                                            <%--<li><a href="#tabTercerizar" data-toggle="tab">Tercerizar</a></li>--%>
                                        </ul>
                                    </div>
                                    <div class="panel-body">
                                        <div class="tab-content">
                                            <div class="tab-pane fade in active" id="tabExportar">
                                                <div class="form-row">
                                                    <div class="form-group col-md-1">
                                                    </div>
                                                    <div class="form-group col-md-6">
                                                        <div class="rounded"  style="min-height: 80px;">
                                                            <table style="width: 100%;">
                                                                <tr>
                                                                    <td style="width:35%">
                                                                        <label for="inputEmail4">Action Plan:</label>
                                                                    </td>
                                                                    <td style="width:40%">
                                                                        <asp:DropDownList ID="cmb_CodTipoGestion" runat="server" TabIndex="6" Width="250px" 
                                                                        onselectedindexchanged="cmb_CodTipoGestion_SelectedIndexChanged" ONCHANGE="document.getElementById('iframe').src = 'GS_DocumentoListado.aspx?idCarta=1&codTipoDocumento='+this.options[this.selectedIndex].value"
                                                                        AutoPostBack="True">
                                                                        </asp:DropDownList>
                                                                    </td>
                                                                    <td style="width:25%">
                                                                        <%--<asp:Button ID="btnVisualizar" runat="server" Width="160px" Text="Visualizar" OnClick="btnVisualizar_Click" />--%>
                                                                        <a href="#theModal" class="btn btn-primary" style="width:100%; display:inline-block; padding:0px; margin-left:6px;" data-toggle="modal" data-target="#theModal" id ="lnkPopUp" runat="server">Ver modelos</a>
                                                                        <br />
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td>
                                                                        <label for="inputPassword4">Modelo de Documento:</label>
                                                                    </td>
                                                                    <td>
                                                                        <asp:DropDownList ID="cmb_Carta" runat="server" TabIndex="6" Width="250px" 
                                                                        onselectedindexchanged="cmb_Carta_SelectedIndexChanged" AutoPostBack="true">
                                                                        </asp:DropDownList>
                                                                    </td>
                                                                    <td>
                                                                        <div style="text-align:center;">
                                                                            <asp:ImageButton ID="btnExportPDF" runat="server" ImageUrl="~/imagenes/icon_pdf.png" OnClick="btnExportPDF_Click" Visible="False" />
                                                                        </div>
                                                                    </td>
                                                                </tr>
                                                            </table>
                                                        </div>
                                                    </div>
                                                    <div class="form-group col-md-3">
                                                        <div class="rounded" style="min-height: 80px;">
                                                            <div class="form-row col-md-12">
                                                                <table style="margin:auto; text-align:center; height:80px; width: 100%;">
                                                                    <tr>
                                                                        <td style="height: 28px;">
                                                                            <asp:Button ID="btnBuscar" runat="server" class="btn btn-primary" Width="80%" Text="Filtro avanzado" OnClick="btnBuscar_Click" />
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td>
                                                                            <asp:Button ID="btnExportarAP" runat="server" class="btn btn-primary" Width="80%" Text="Enviar/Generar Excel" OnClick="btnExportarAP_Click" />
                                                                            <asp:Button ID="btnEjecutar" runat="server" class="btn btn-primary" Width="80%" Text="Ejecutar" OnClick="btnEjecutar_Click" Visible="false" />
                                                                        </td>
                                                                    </tr>
                                                                    <%--<tr>
                                                                        <td>
                                                                                
                                                                        </td>
                                                                    </tr>--%>
                                                                </table>
                                                            </div>
                                                        </div>
                                                    </div>
                                                    <div class="form-group col-md-2">
                                                    </div>
                                                </div>

                                                <asp:GridView ID="gv" runat="server" Width="100%" EnableTheming="True" AutoGenerateColumns="False"
                                                    AllowSorting="True" AllowPaging="True" Style="text-align: center" ViewStateMode="Enabled"
                                                    BackColor="White" OnPageIndexChanging="gv_PageIndexChanging" OnPageIndexChanged="gv_PageIndexChanged"
                                                    PageSize="40" onselectedindexchanged="gv_SelectedIndexChanged" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" CellPadding="3">
                                                    <FooterStyle HorizontalAlign="Center" VerticalAlign="Middle" BackColor="White" ForeColor="#000066" />
                                                    <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" BackColor="#2F63CB" Font-Bold="True" ForeColor="White" />
                                                    <Columns>
                                                        <asp:TemplateField ShowHeader="False">
                                                            <ItemStyle Width="1%"></ItemStyle>
                                                            <HeaderStyle Width="1%" CssClass=""></HeaderStyle>
                                                            <ItemTemplate>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <%--1--%>
                                                        <asp:BoundField DataField="nIdGestionCobranza" HeaderText="IdReg_G_Cob." SortExpression="">
                                                            <ItemStyle Width="0%" HorizontalAlign="Left" Height="15px" Font-Bold="False" CssClass="hidden">
                                                            </ItemStyle>
                                                            <HeaderStyle Width="0%" CssClass="hidden" Height="22px"></HeaderStyle>
                                                        </asp:BoundField>
                                                        <%--2--%>
                                                        <asp:BoundField DataField="cEjecutor" HeaderText="Gestionado Por" SortExpression="">
                                                            <ItemStyle Width="10%" HorizontalAlign="Left" Height="15px" Font-Bold="False"></ItemStyle>
                                                            <HeaderStyle Width="10%" CssClass="" Height="22px"></HeaderStyle>
                                                        </asp:BoundField>
                                                        <%--<asp:BoundField DataField="Asesores" HeaderText="Asesores" SortExpression="">
                                                            <ItemStyle Width="10%" HorizontalAlign="Left" Height="15px" Font-Bold="False"></ItemStyle>
                                                            <HeaderStyle Width="10%" CssClass="" Height="22px"></HeaderStyle>
                                                        </asp:BoundField>--%>
                                                        <%--3--%>
                                                        <asp:BoundField DataField="dFechaRegistra" HeaderText="Fecha de Creación del AP" SortExpression="">
                                                            <ItemStyle Width="0%" HorizontalAlign="Left" Height="15px" Font-Bold="False" CssClass="hidden"></ItemStyle>
                                                            <HeaderStyle Width="0%" CssClass="hidden" Height="22px"></HeaderStyle>
                                                        </asp:BoundField>
                                                        <%--4--%>
                                                        <asp:BoundField DataField="cTipoGestion" HeaderText="Tipo Action Plan"
                                                            SortExpression="">
                                                            <ItemStyle Width="10%" HorizontalAlign="Left" Height="15px" Font-Bold="False"></ItemStyle>
                                                            <HeaderStyle Width="10%" CssClass="" Height="22px"></HeaderStyle>
                                                        </asp:BoundField>
                                                        <%--5--%>
                                                        <asp:BoundField DataField="cRazonSocial" HeaderText="Cliente / Aval" SortExpression="">
                                                            <ItemStyle Width="20%" HorizontalAlign="Left" Height="15px" Font-Bold="False"></ItemStyle>
                                                            <HeaderStyle Width="20%" CssClass="" Height="22px"></HeaderStyle>
                                                        </asp:BoundField>
                                                        <%--6--%>
                                                        <asp:BoundField DataField="cProducto" HeaderText="Producto" SortExpression="">
                                                            <ItemStyle Width="6%" HorizontalAlign="Left" Height="15px" Font-Bold="False"></ItemStyle>
                                                            <HeaderStyle Width="6%" CssClass="" Height="22px"></HeaderStyle>
                                                        </asp:BoundField>
                                                        <%--7--%>
                                                        <asp:BoundField DataField="nTramo" HeaderText="Tramo" SortExpression="">
                                                            <ItemStyle Width="3%" HorizontalAlign="center" Height="15px" Font-Bold="False" CssClass=""></ItemStyle>
                                                            <HeaderStyle Width="3%" CssClass="" Height="22px"></HeaderStyle>
                                                        </asp:BoundField>
                                                        <%--<asp:BoundField DataField="SubProducto" HeaderText="SubProducto" SortExpression="">
                                                            <ItemStyle Width="10%" HorizontalAlign="Left" Height="15px" Font-Bold="False"></ItemStyle>
                                                            <HeaderStyle Width="10%" CssClass="" Height="22px"></HeaderStyle>
                                                        </asp:BoundField>--%>
                                                        <%--8--%>
                                                        <asp:BoundField DataField="nDiasMora" HeaderText="Dias de mora" SortExpression="">
                                                            <ItemStyle Width="4%" HorizontalAlign="center" Height="15px" Font-Bold="False"></ItemStyle>
                                                            <HeaderStyle Width="4%" CssClass="" Height="22px"></HeaderStyle>
                                                        </asp:BoundField>
                                                        <%--9--%>
                                                        <asp:BoundField DataField="cEjecutado" HeaderText="Clasificación del Action Plan" SortExpression="">
                                                            <ItemStyle Width="10%" HorizontalAlign="Left" Height="15px" Font-Bold="False"></ItemStyle>
                                                            <HeaderStyle Width="10%" CssClass="" Height="22px"></HeaderStyle>
                                                        </asp:BoundField>
                                                        <%--10--%>
                                                        <asp:BoundField DataField="cClaseGestion" HeaderText="Resultado Clasificación" SortExpression="">
                                                            <ItemStyle Width="10%" HorizontalAlign="Left" Height="15px" Font-Bold="False"></ItemStyle>
                                                            <HeaderStyle Width="10%" CssClass="" Height="22px"></HeaderStyle>
                                                        </asp:BoundField>
                                                        <%--11--%>
                                                        <asp:BoundField DataField="nIdEjecutado" HeaderText="CodEjecutado" SortExpression="">
                                                            <ItemStyle Width="10%" HorizontalAlign="Left" Height="15px" Font-Bold="False" CssClass="hidden">
                                                            </ItemStyle>
                                                            <HeaderStyle Width="10%" CssClass="hidden" Height="22px"></HeaderStyle>
                                                        </asp:BoundField>
                                                        <%--12--%>
                                                        <asp:BoundField DataField="cDetalleContactabilidad" HeaderText="Comentarios" SortExpression="">
                                                            <ItemStyle Width="10%" HorizontalAlign="center" Height="15px" Font-Bold="False"></ItemStyle>
                                                            <HeaderStyle Width="10%" CssClass="" Height="22px"></HeaderStyle>
                                                        </asp:BoundField>
                                                        <%--13--%>
                                                        <asp:BoundField DataField="dFechaResultado" HeaderText="Ejecutado" SortExpression="">
                                                            <ItemStyle Width="8%" HorizontalAlign="Left" Height="15px" Font-Bold="False"></ItemStyle>
                                                            <HeaderStyle Width="8%" CssClass="" Height="22px"></HeaderStyle>
                                                        </asp:BoundField>
                                                        <%--<asp:BoundField DataField="desc_ejecutores" HeaderText="Ejecutores" SortExpression="">
                                                            <ItemStyle Width="10%" HorizontalAlign="Left" Height="15px" Font-Bold="False" CssClass="hidden">
                                                            </ItemStyle>
                                                            <HeaderStyle Width="10%" Height="22px" CssClass="hidden"></HeaderStyle>
                                                        </asp:BoundField>--%>

                                                        <%--14--%>
                                                        <asp:BoundField HeaderText="Campaña" SortExpression="">
                                                            <ItemStyle Width="0%" HorizontalAlign="Left" Height="15px" Font-Bold="False" CssClass="hidden"></ItemStyle>
                                                            <HeaderStyle Width="0%" CssClass="hidden" Height="22px"></HeaderStyle>
                                                        </asp:BoundField>

                                                        <%--15--%>
                                                        <asp:BoundField DataField="nIdEstadoGestion">
                                                            <ItemStyle CssClass="hidden"></ItemStyle>
                                                            <HeaderStyle CssClass="hidden"></HeaderStyle>
                                                        </asp:BoundField>

                                                        <%--16--%>
                                                        <asp:BoundField DataField="cEstadoGestion" HeaderText="Estado" SortExpression="">
                                                            <ItemStyle Width="4%" HorizontalAlign="Left" Height="15px" Font-Bold="False"></ItemStyle>
                                                            <HeaderStyle Width="4%" CssClass="" Height="22px"></HeaderStyle>
                                                        </asp:BoundField>

                                                        <%--17--%>
                                                        <asp:BoundField DataField="nIdClaseGestion">
                                                            <ItemStyle CssClass="hidden"></ItemStyle>
                                                            <HeaderStyle CssClass="hidden"></HeaderStyle>
                                                        </asp:BoundField>

                                                        <%--18--%>
                                                        <asp:BoundField DataField="" HeaderText="Ver Ficha" SortExpression="">
                                                            <ItemStyle Width="5%" HorizontalAlign="Left" Height="15px" Font-Bold="False"></ItemStyle>
                                                            <HeaderStyle Width="5%" CssClass="" Height="22px"></HeaderStyle>
                                                        </asp:BoundField>

                                                        <%--19--%>
                                                        <asp:BoundField DataField="nIdCliente">
                                                            <ItemStyle CssClass="hidden"></ItemStyle>
                                                            <HeaderStyle CssClass="hidden"></HeaderStyle>
                                                        </asp:BoundField>

                                                        <%--20--%>
                                                        <asp:TemplateField HeaderText="Select">
                                                            <HeaderTemplate>
                                                                <asp:CheckBox ID="chkAll" onclick="javascript:SelectAllCheckboxes(this);" Checked="true" runat="server"
                                                                    Height="15px" Width="1%"></asp:CheckBox>
                                                            </HeaderTemplate>
                                                            <ItemTemplate>
                                                                <asp:CheckBox ID="chkPermiso" Checked="true" runat="server" />
                                                            </ItemTemplate>
                                                        </asp:TemplateField>

                                                        <%--21--%>
                                                        <asp:BoundField DataField="nIdTipoGestion" HeaderText="CodTipoGestion" SortExpression="">
                                                            <ItemStyle CssClass="hidden" Width="10%"></ItemStyle>
                                                            <HeaderStyle Width="10%" CssClass="hidden" Height="22px"></HeaderStyle>
                                                        </asp:BoundField>

                                                    </Columns>
                                                    <PagerStyle BackColor="White" ForeColor="#000066" HorizontalAlign="Left" />
                                                    <RowStyle ForeColor="#000066"></RowStyle>
                                                    <EmptyDataTemplate>
                                                        <table id="tbSinDatos">
                                                            <tr>
                                                                <td style="width: 10%">
                                                                    <img src="../../Imagenes/imgWarning.png" style="width: 25px; height: 24px" />
                                                                </td>
                                                                <td style="width: 5%">
                                                                </td>
                                                                <td style="width: 85%">
                                                                    <asp:Label ID="lblSinDatos" runat="server" Text="No se encontraron Datos..." CssClass="labeltextonegro"></asp:Label>
                                                                </td>
                                                            </tr>
                                                        </table>
                                                    </EmptyDataTemplate>
                                                    <SelectedRowStyle CssClass="selectedrow" BackColor="#669999" Font-Bold="True" ForeColor="White"></SelectedRowStyle>
                                                    <AlternatingRowStyle />
                                                    <SortedAscendingCellStyle BackColor="#F1F1F1" />
                                                    <SortedAscendingHeaderStyle BackColor="#007DBB" />
                                                    <SortedDescendingCellStyle BackColor="#CAC9C9" />
                                                    <SortedDescendingHeaderStyle BackColor="#00547E" />
                                                </asp:GridView>
                                                <table id="Contador" cellpadding="0" cellspacing="0" width="100%">
                                                    <tr>
                                                        <td class="pagerstyle" style="height: 30px; text-align: center">
                                                            <asp:Label ID="lblCantidad" runat="server"></asp:Label>&nbsp;
                                                            <asp:Label ID="lblPaginaGrilla" runat="server"></asp:Label>&nbsp;
                                                        </td>
                                                    </tr>
                                                </table>


                                            </div>
                                            <div class="tab-pane fade" id="tabImportar">
                                                
                                                
                                                    <div class="form-group col-md-1">
                                                    </div>
                                                    <div class="form-group col-md-7">
                                                        <div class="rounded" style="min-height: 100px;">
                                                            <div class="form-group col-md-12">
                                                                <label for="inputEmail4">Importar Resultados/Clasificaciones de Action Plans Masivos</label>
                                                            </div>
                                                            <div class="form-row col-md-4">
                                                                <label for="inputEmail4">Action Plan:</label>
                                                            </div>
                                                            <div class="form-row col-md-8">
                                                                <asp:DropDownList ID="cmb_TipoGestion" runat="server" TabIndex="6" Width="100%">
                                                                </asp:DropDownList>
                                                            </div>
                                                            <div class="form-row col-md-4">
                                                                <label for="inputEmail4">Archivo de Resultados:</label>
                                                            </div>
                                                            <div class="form-row col-md-8">
                                                                <asp:FileUpload ID="FileUpload1" runat="server" Width="100%" />
                                                            </div>
                                                        </div>
                                                    </div>
                                                    <div class="form-group col-md-2">
                                                        <div class="rounded" style="min-height: 100px;">
                                                            <table style="margin:auto; text-align:center; height:80px;">
                                                                <tr>
                                                                    <td>
                                                                        <asp:Button ID="btnEvaluarGestiones" runat="server" class="btn btn-primary" OnClick="btnEvaluarGestiones_Click" Width="100%"  Text="Importar Resultados"/>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td>
                                                                        <asp:Button ID="btnExportarResultados" runat="server" class="btn btn-primary" OnClick="btnExportarResultados_Click" Width="100%" Text="Tabla de Códigos" />
                                                                    </td>
                                                                </tr>
                                                            </table>
                                                        </div>
                                                    </div>
                                                    <div class="form-group col-md-2">
                                                    </div>

                                                </div>
                                            </div>
                                            <%--<div class="tab-pane fade" id="tabTercerizar">
                                                <asp:Button ID="btnBuscar2" runat="server" class="btn btn-primary" Width="160px" OnClick="btnBuscar_Click" Text="Buscar" />
                                                <asp:Button ID="btnTerceros" runat="server" class="btn btn-primary" OnClick="btnTerceros_Click" Text="Tercerizar" Width="160px" />
                                            </div>--%>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </td>
                    <td>
                    </td>
                </tr>
                <tr>
                    <td></td>
                    <td></td>
                    <td></td>
                </tr>

            </table>
            <%--<table id="ControlesSuperior" border="0" cellpadding="0" cellspacing="0" class="cabeceraScroll"
                width="100%">
                <tr>         
                    <td style="width:2%"></td>
                    <td align="left" style="width: 35%;">   
                        <table id="Table1" border="0" cellpadding="0" cellspacing="0" class="cabeceraScroll" style="text-align:left; margin-left:0px; width:100%;">
                            <tr>
                                <td style="color:#000080; font-weight:bold;" colspan="2">
                                    Filtrar por Datos del Action Plan
                                </td>
                            </tr>
                            <tr id="Estado" style="width:100%">
                                <td align="left" style="width: 38%">
                                    Estado del Action Plan
                                </td>
                                <td align="left" style="width:62%">
                                    <asp:DropDownList ID="cmb_Estado" runat="server" TabIndex="6" Width="100%" 
                                        AutoPostBack="True" OnSelectedIndexChanged="cmb_Estado_SelectedIndexChanged">
                                    </asp:DropDownList>
                                </td>
                            </tr>
                            <tr id="TipoGestion">
                                <td align="left" style="width: 38%">
                                    Action Plan
                                </td>
                                <td align="left" style="width:62%">
                                    
                                </td>
                            </tr>
                            <tr id="Fecha">
                                <td align="left" style="width: 38%">
                                    Fecha de Creación del AP
                                </td>
                                <td align="left" valign="middle" style="width:62%">
                                    Del
                                    <asp:TextBox ID="txt_FECHAINI" runat="server" Enabled="false" Height="18px" MaxLength="10"
                                        TabIndex="5" Width="39%"></asp:TextBox>
                                    <cc1:CalendarExtender ID="CalendarExtender1" runat="server" PopupButtonID="imgCal1"
                                        TargetControlID="txt_FECHAINI" />
                                    <asp:ImageButton ID="imgCal1" runat="Server" AlternateText="Mostrar calendario" ImageUrl="~/imagenes/Calendar.png" />
                                    &nbsp;al
                                    <asp:TextBox ID="txt_FECHAFIN" runat="server" Enabled="false" Height="18px" MaxLength="10"
                                        TabIndex="5" Width="40%"></asp:TextBox>
                                    <cc1:CalendarExtender ID="CalendarExtender2" runat="server" PopupButtonID="imgCal2"
                                        TargetControlID="txt_FECHAFIN" />
                                    <asp:ImageButton ID="imgCal2" runat="Server" AlternateText="Mostrar calendario" ImageUrl="~/imagenes/Calendar.png" />
                                </td>
                            </tr>
                        </table>
                 
                    </td>
                    <td style="width:2%"></td>
                    <td align="left" style="width: 35%;">     
                        <table id="Controles" border="0" cellpadding="0" cellspacing="0" class="cabeceraScroll" style="text-align:left; margin-left:0px; width:100%;">
                            <tr>
                                <td style="color:#000080; font-weight:bold;" colspan="2">
                                    Búsqueda por Datos del Crédito
                                </td>
                            </tr>
                            <tr id="Documento" style="width:100%">
                                <td align="left" style="width: 38%">
                                    Documento de identidad
                                </td>
                                <td align="left" style="width: 62%">
                                    <asp:TextBox ID="txt_documento" runat="server" Width="100%" MaxLength="20" placeholder="Ingrese el DNI"></asp:TextBox>
                                </td>
                            </tr>
                            <tr id="Nombres" style="width:100%">
                                <td align="left" style="width: 38%">
                                    Nombres/Apellidos
                                </td>
                                <td align="left" style="width: 62%">
                                    <asp:TextBox ID="txt_nombres" runat="server" Width="100%" MaxLength="50" placeholder="Ingrese Nombre o Apellido"></asp:TextBox>
                                </td>
                            </tr>
                            <tr style="width:95%">
                                <td align="left" style="width: 38%">
                                    Días de Mora
                                </td>
                                <td style="width: 62%">
                                    
                                <asp:TextBox ID="txt_dias_mora" runat="server" Width="48.8%" placeholder="Desde" ></asp:TextBox>
                                <asp:TextBox ID="txt_dias_mora_hasta" runat="server" Width="50%" placeholder="Hasta" ></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td colspan="2">
                                    &nbsp;&nbsp;&nbsp;
                                    <asp:RegularExpressionValidator ID="rexNombre" runat="server" ControlToValidate="txt_dias_mora" Display="Dynamic" 
                                        ErrorMessage="Debe ingresar por lo menos 3 caracteres." ValidationExpression=".{3,}">*</asp:RegularExpressionValidator>
                                </td>
                            </tr>
                        </table>
                    </td>
                    <td style="width:2%"></td>
                    <td style="width:2%"></td>
                </tr>
            </table>--%>
            <%--<table id="Table4" border="0" cellpadding="0" cellspacing="0" class="cabeceraScroll" width="100%">
                <tr>         
                    <td style="width:2%"></td>
                    <td align="left" style="width: 96%;">  
                        <table id="Table5" border="0" width="100%" class="cabeceraScroll">
                            <tr>
                                <td colspan="10">
                                </td>
                            </tr>
                            <tr id="Tr2">
                                <td align="left" style="width: 4%">
                                    
                                </td>
                                <td style="width:20%">
                                </td>
                                <td style="width: 4%;"></td>
                                <td style="text-align:left; width:20%;">
                                    
                                </td>
                                <td style="width:4%; padding-left:0;">
                                    
                                </td>
                                <td style="width: 20%;">
                                </td>
                                <td  style="text-align:left; width: 4%";>
                                    
                                </td>
                                <td style="width: 20%;">
                                    
                                </td>
                                <td style="text-align:left; width: 4%";>
                                    
                                </td>
                            </tr>    
                            <tr>
                                <td colspan="10">

                                </td>
                            </tr>                        
                        </table>
                    </td>
                    <td style="width:2%"></td>
                </tr>
            </table>--%>
            <%--<table id="Table2" border="0" cellpadding="0" cellspacing="0" class="cabeceraScroll" width="100%">
                <tr>         
                    <td style="width:2%"></td>
                    <td align="left" style="width: 96%;">  
                        <table id="ImportarExcelCartas" border="0" width="100%" class="cabeceraScroll">
                            <tr>
                                <td colspan="11">
                                </td>
                            </tr>
                            <tr>
                                <td colspan="11" style="font-weight:bold; text-align:left; color:#000080;">
                                    Importar Resultados/Clasificaciones de Action Plans Masivos
                                </td>
                            </tr>
                            <tr>
                                <td colspan="11">

                                </td>
                            </tr>                        
                        </table>
                    </td>
                    <td style="width:2%"></td>
                </tr>
            </table>--%>

            <asp:HiddenField ID="hfOrden" runat="server"></asp:HiddenField>
        </ContentTemplate>
        <Triggers>
            <asp:AsyncPostBackTrigger ControlID="btnBuscar" EventName="Click" />
            <asp:PostBackTrigger ControlID = "btnEvaluarGestiones" />
        </Triggers>
    </asp:UpdatePanel>
    <asp:UpdateProgress ID="uprogGvUsuario" runat="server" AssociatedUpdatePanelID="upGvUsuario"
        DisplayAfter="250">
        <ProgressTemplate>
            <asp:Panel ID="pnlGvCargando" runat="server" SkinID="PanelCargando" Width="100px">
                <table id="tbGvCargando" cellpadding="1" cellspacing="1" style="width: 100%">
                    <tr>
                        <td style="width: 50%; text-align: center">
                            <asp:Label ID="lblGvCargando" runat="server" Style="cursor: pointer" Text="Cargando..."
                                CssClass="modalPopup"></asp:Label>
                        </td>
                        <td style="width: 50%; text-align: justify">
                            <asp:Image runat="server" ID="Progres" ImageUrl="~/imagenes/loading.gif" Style="vertical-align: middle"
                                alt="Procesando&#8230;" />
                        </td>
                    </tr>
                </table>
            </asp:Panel>
        </ProgressTemplate>
    </asp:UpdateProgress>

    <div id="theModal" class="modal fade text-center">
        <div class="modal-dialog">
            <div class="modal-header">
                <button type="button" class="close" data-dismiss="modal">&times;</button>
                <h4 class="modal-title">Seleccionar tipo de action plan</h4>
            </div>
            <div class="modal-body">
                <iframe id="iframe" width="100%" height="80%" style="overflow: hidden;" src="GS_DocumentoListado.aspx?idCarta=1&codTipoDocumento=4" frameborder="0" marginheight="0" marginwidth="0" scrolling="yes">Cargando&amp;#8230;</iframe>
            </div>                
            <div class="modal-footer">
                <button type="button" class="btn btn-default" data-dismiss="modal">Cerrar</button>
            </div>
        </div>
    </div>
</asp:Content>
