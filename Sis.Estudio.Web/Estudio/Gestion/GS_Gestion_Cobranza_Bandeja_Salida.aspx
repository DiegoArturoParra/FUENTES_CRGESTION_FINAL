<%--<%@ Page Title="" Language="C#" MasterPageFile="~/Master/Ceem.master" AutoEventWireup="true" CodeFile="GS_Gestion_Cobranza_Bandeja_Salida.aspx.cs" Inherits="Estudio_Gestion_GS_Gestion_Cobranza_Bandeja_Salida" %>--%>
<%@ Page Title="" Language="C#" MasterPageFile="~/Master/GCCeem.master" AutoEventWireup="true" CodeFile="GS_Gestion_Cobranza_Bandeja_Salida.aspx.cs" Inherits="Estudio_Gestion_GS_Gestion_Cobranza_Bandeja_Salida" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<%@ Register Assembly="GMDatePicker" Namespace="GrayMatterSoft" TagPrefix="cc2" %>
<%@ Register Assembly="Flan.Controls" Namespace="Flan.Controls" TagPrefix="cc3" %>
<%--<%@ MasterType VirtualPath="~/Master/Ceem.master" %>--%>
<%@ MasterType VirtualPath="~/Master/GCCeem.master" %>
<asp:Content ID="Content1" ContentPlaceHolderID="DefaultContent" runat="Server">
    <script type="text/javascript">
        function Enter_Buscar(evt) {
        }

        function Valida_Todos() {
        }

        function SelectAllCheckboxes(spanChk) {
            var oItem = spanChk.children;
            var theBox = (spanChk.type == "checkbox") ? spanChk : spanChk.children.item[0];
            xState = theBox.checked;

            elm = theBox.form.elements;
            for (i = 0; i < elm.length; i++)
                if (elm[i].type == "checkbox" && elm[i].id != theBox.id) {
                    if (elm[i].checked != xState)
                        elm[i].click();
                }
        }

    </script>
    <asp:UpdatePanel ID="upGvUsuario" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
            <table id="Mensaje" cellpadding="0" cellspacing="0" width="100%" class="cabeceraScroll">
                <tr>
                    <td class="altoverow" style="text-align: center">
                        <asp:ValidationSummary ID="vsError" runat="server" HeaderText="No puede realizar esta Operación:"
                            ShowMessageBox="True" ShowSummary="False" CssClass="Etiqueta" />
                        <asp:Label ID="lblMensaje" runat="server" CssClass="Etiqueta" ForeColor="Red"></asp:Label><input
                            id="hdnContinuar" name="hdnContinuar" style="width: 80px; height: 10px" type="hidden" />
                    </td>
                </tr>
            </table>
<%--            <table id="Botones" border="0" cellpadding="0" cellspacing="0" class="cabeceraScroll"
                width="100%">
                <tr>
                    <td align="left" style="width: 100%;" rowspan="2">
                        <asp:Button ID="btnBuscar" runat="server" BackColor="#000080" BorderStyle="Ridge"
                            CausesValidation="False" Font-Names="Trebuchet MS" Font-Size="9pt" ForeColor="White"
                            Height="25px" OnClick="btnBuscar_Click" Text="Buscar" Width="90px" />
                        <asp:Button ID="btnModificar" runat="server" BackColor="#000080" BorderStyle="Ridge"
                            CausesValidation="False" Font-Names="Trebuchet MS" Font-Size="9pt" ForeColor="White"
                            Height="25px" OnClick="btnModificar_Click" Text="Evaluar" Width="90px" 
                            Visible="False" />
                        <asp:Button ID="btnConsultar" runat="server" BackColor="#000080" BorderStyle="Ridge"
                            CausesValidation="False" Font-Names="Trebuchet MS" Font-Size="9pt" ForeColor="White"
                            Height="25px" OnClick="btnConsultar_Click" Text="Consultar" Width="90px" 
                            Visible="False" />
                        <asp:Button ID="btnNuevo" runat="server" BackColor="#000080" BorderStyle="Ridge"
                            CausesValidation="False" Font-Names="Trebuchet MS" Font-Size="9pt" ForeColor="White"
                            Height="25px" OnClick="btnNuevo_Click" Text="Nuevo Action Plan" 
                            Width="140px" Visible="false" />
                        <asp:Button ID="btnDesactivar" runat="server" BackColor="#000080" BorderStyle="Ridge"
                            Font-Names="Trebuchet MS" Font-Size="9pt" ForeColor="White" Height="25px" OnClick="btnDesactivar_Click"
                            Text="Desactivar" Width="90px" Visible="False" />
                    </td>
                </tr>
            </table>--%>
<%--            <table id="ControlesSuperior" border="0" cellpadding="0" cellspacing="0" class="cabeceraScroll" width="100%">
                <tr>
                    <td align="center" style="width: 100%;">
                        <table id="Controles" align="center" border="0" cellpadding="0" cellspacing="0" class="cabeceraScroll"
                            width="800px">
                            <tr>
                                <td align="left" style="width: 331px">
                                    Documento de identidad:
                                </td>
                                <td align="left" width="">
                                    <asp:TextBox ID="txt_documento" runat="server" Width="400px" MaxLength="20"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td align="left" style="width: 331px">
                                    Nombres:
                                </td>
                                <td align="left" width="">
                                    <asp:TextBox ID="txt_nombres" runat="server" Width="400px" MaxLength="50"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td align="left" style="width: 331px">
                                    Dias de mora:
                                </td>
                                <td align="left" width="">
                                    <asp:TextBox ID="txt_dias_mora" runat="server" Width="400px"></asp:TextBox>
                                    <asp:RegularExpressionValidator ID="rexNombre" runat="server" ControlToValidate="txt_dias_mora"
                                        Display="Dynamic" ErrorMessage="Debe ingresar por lo menos 3 caracteres." ValidationExpression=".{3,}">*</asp:RegularExpressionValidator>
                                </td>
                            </tr>
                            <tr>
                                <td align="left" style="width: 331px">
                                    Tipo de Gestión:
                                </td>
                                <td align="left" width="">
                                    <asp:DropDownList ID="cmb_CodTipoGestionGrupo" runat="server" TabIndex="6" 
                                        Width="400px">
                                    </asp:DropDownList>
                                </td>
                            </tr>
                            <tr>
                                <td align="left" style="width: 331px">
                                    Fecha de Registro del Action Plan:
                                </td>
                                <td align="left" width="">
                                    Del
                                    <asp:TextBox ID="txt_FECHAINI" runat="server" Enabled="false" Height="18px" MaxLength="10"
                                        TabIndex="5" Width="150px"></asp:TextBox>
                                    <cc1:CalendarExtender ID="CalendarExtender1" runat="server" PopupButtonID="imgCal1"
                                        TargetControlID="txt_FECHAINI" />
                                    <asp:ImageButton ID="imgCal1" runat="Server" AlternateText="Mostrar calendario" ImageUrl="~/imagenes/Calendar.png" />
                                    &nbsp;al
                                    <asp:TextBox ID="txt_FECHAFIN" runat="server" Enabled="false" Height="18px" MaxLength="10"
                                        TabIndex="5" Width="150px"></asp:TextBox>
                                    <cc1:CalendarExtender ID="CalendarExtender2" runat="server" PopupButtonID="imgCal2"
                                        TargetControlID="txt_FECHAFIN" />
                                    <asp:ImageButton ID="imgCal2" runat="Server" AlternateText="Mostrar calendario" ImageUrl="~/imagenes/Calendar.png" />
                                </td>
                            </tr>
                            <tr>
                                <td align="left" >
                                    Usuario Responsable:
                                </td>
                                <td style="text-align:left;">
                                    <asp:DropDownList ID="cmb_UsuarioResponsable" runat="server" TabIndex="6" 
                                        Width="84%" >
                                    </asp:DropDownList>
                                </td>
                            </tr>
                            <tr>
                                <td align="left" style="width: 331px">
                                    &nbsp;</td>
                                <td align="left" width="">
                                    &nbsp;</td>
                            </tr>
                            <tr>
                                <td align="left" colspan="2" style="height: 47px; text-align: center;">
                                    <asp:Button ID="btnGrabarObs" runat="server" BackColor="#000080" 
                                        BorderStyle="Ridge" CausesValidation="False" Font-Names="Trebuchet MS" 
                                        Font-Size="9pt" ForeColor="White" Height="25px" 
                                        Text="Grabar Observacion" Width="176px" onclick="btnGrabarObs_Click" />&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                    <asp:Button ID="btnExportarGestiones" runat="server" BackColor="#000080" BorderStyle="Ridge" Font-Names="Trebuchet MS" Font-Size="9pt" 
                                        ForeColor="White" Height="25px" Text="Aceptar y Exportar" Width="176px" OnClick="btnExportarGestiones_Click" />
                                    </td>
                            </tr>
                            <tr>
                                <td align="left" colspan="2" style="height: 68px; text-align: center;">
                                    <asp:TextBox ID="txt_obs" runat="server" Height="61px" MaxLength="20" 
                                        TextMode="MultiLine" Width="659px"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td align="left" style="width: 331px">
                                    &nbsp;</td>
                                <td align="left" width="">
                                    &nbsp;</td>
                            </tr>
                        </table>
                    </td>
                </tr>
            </table>--%>
            
            <div class="form-group col-md-6">
                <div class="rounded" style="min-height: 100px;">
                    <%--<div class="form-group col-md-12">
                        <label for="inputEmail4">Filtrar por Datos del Action Plan:</label>
                    </div>--%>

                    <div class="form-row col-md-5">
                        <label for="inputEmail4">Estado del Action Plan:</label>
                    </div>
                    <div class="form-row col-md-7">
                        <asp:DropDownList ID="cmb_Estado" runat="server" TabIndex="6" Width="100%" OnSelectedIndexChanged="cmb_Estado_SelectedIndexChanged" AutoPostBack="True">
                        </asp:DropDownList>
                        <%--<asp:DropDownList ID="cmb_Carta" runat="server" TabIndex="6" Width="100%" AutoPostBack="true" CssClass="selectpicker">
                        </asp:DropDownList>--%>
                    </div>
                    <div class="form-row col-md-5">
                        <label for="inputEmail4">Action Plan:</label>
                    </div>
                    <div class="form-row col-md-7">
                        <asp:DropDownList ID="cmb_CodTipoGestionGrupo" runat="server" TabIndex="6" Width="100%" onselectedindexchanged="cmb_CodTipoGestionGrupo_SelectedIndexChanged" AutoPostBack="True">
                        </asp:DropDownList>
                        <%--<asp:Button ID="btnFormatoCarta" runat="server" CausesValidation="False" onclick="btnFormatoCarta_Click" Text="Carta" Width="100%" class="btn btn-primary" />--%>
                    </div>
                    <div class="form-row col-md-5">
                        <label for="inputEmail4">Creación del Action Plan:</label>
                    </div>
                    <div class="form-row col-md-7">
                        Del
                        <asp:TextBox ID="txt_FECHAINI" runat="server" Enabled="false" MaxLength="10"
                            TabIndex="5" Width="33%"></asp:TextBox>
                        <cc1:CalendarExtender ID="CalendarExtender1" runat="server" PopupButtonID="imgCal1"
                            TargetControlID="txt_FECHAINI" />
                        <asp:ImageButton ID="imgCal1" runat="Server" AlternateText="Mostrar calendario" ImageUrl="~/imagenes/Calendar.png" />
                        &nbsp;al
                        <asp:TextBox ID="txt_FECHAFIN" runat="server" Enabled="false" MaxLength="10"
                            TabIndex="5" Width="33%"></asp:TextBox>
                        <cc1:CalendarExtender ID="CalendarExtender2" runat="server" PopupButtonID="imgCal2"
                            TargetControlID="txt_FECHAFIN" />
                        <asp:ImageButton ID="imgCal2" runat="Server" AlternateText="Mostrar calendario" ImageUrl="~/imagenes/Calendar.png" />
                    </div>
                </div>
            </div>
            <div class="form-group col-md-3">
                <div class="rounded" style="min-height: 100px;">
                    <%--<div class="form-group col-md-12">
                        <label for="inputEmail4">Búsqueda por Datos del Crédito:</label>
                    </div>--%>

                    <div class="form-row col-md-4">
                        <label for="inputEmail4">DNI:</label>
                    </div>
                    <div class="form-row col-md-8">
                        <asp:TextBox ID="txt_documento" runat="server" Width="100%" MaxLength="20" OnTextChanged="txt_documento_TextChanged"></asp:TextBox>
                    </div>
                    <div class="form-row col-md-4">
                        <label for="inputEmail4">Nombres:</label>
                    </div>
                    <div class="form-row col-md-8">
                        <asp:TextBox ID="txt_nombres" runat="server" Width="100%" MaxLength="50" OnTextChanged="txt_nombres_TextChanged"></asp:TextBox>
                    </div>
                    <div class="form-row col-md-4">
                        <label for="inputEmail4">Responsable:</label>
                    </div>
                    <div class="form-row col-md-8">
                        <asp:DropDownList ID="cmb_UsuarioResponsable" runat="server" TabIndex="6" Width="100%" >
                        </asp:DropDownList>
                    </div>
                </div>
            </div>
            <div class="form-group col-md-3">
                <div class="rounded" style="min-height: 100px;">
                    <table style="margin:auto; text-align:center; height:80px; width:100%; border-spacing:5px" >
                        <tr>
                            <td>
                                <asp:Button ID="btnBuscar" runat="server" class="btn btn-primary" Text="Buscar" Width="95%"  OnClick="btnBuscar_Click"/>
                            </td>
                            <td>
                                
                                <asp:Button ID="btnExportar" runat="server" class="btn btn-primary" Text="Exportar" Width="95%" OnClick="btnExportar_Click" />
                            </td>
                            <td>
                                <asp:Button ID="btnExportarGestiones" runat="server" class="btn btn-primary" Text="Grabar" Width="95%" OnClick="btnExportarGestiones_Click" />
                            </td>
                        </tr>
                        <tr>
                            <td colspan="3">
                                <asp:TextBox ID="txt_obs" runat="server" Height="61px" MaxLength="20" TextMode="MultiLine" Width="100%" placeholder="Escriba un Comentario."></asp:TextBox>
                            </td>
                        </tr>
                    </table>
                </div>
            </div>

            <table id="Grid" border="0" width="100%">
                <tr>
                    <td align="center" style="width: 100%;">
                        <asp:GridView ID="gv" runat="server" Width="100%" EnableTheming="True" AutoGenerateColumns="False"
                            AllowSorting="True" AllowPaging="True" Style="text-align: center" ViewStateMode="Enabled"
                            BackColor="White" OnPageIndexChanging="gv_PageIndexChanging" 
                            OnPageIndexChanged="gv_PageIndexChanged" PageSize="40" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" CellPadding="3">
                            <FooterStyle HorizontalAlign="Center" VerticalAlign="Middle" BackColor="White" ForeColor="#000066" />
                            <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" BackColor="#2F63CB" Font-Bold="True" ForeColor="White" />
                            <Columns>
                                <asp:TemplateField ShowHeader="False">
                                    <ItemStyle Width="1%"></ItemStyle>
                                    <HeaderStyle Width="1%" CssClass=""></HeaderStyle>
                                    <ItemTemplate>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <%-- 1 --%>
                                <asp:BoundField DataField="IdReg_Gestion_Cobranza" HeaderText="IdReg_G_Cob." SortExpression="">
                                    <ItemStyle Width="10%" HorizontalAlign="Left" Height="15px" Font-Bold="False" CssClass="hidden">
                                    </ItemStyle>
                                    <HeaderStyle Width="10%" CssClass="hidden" Height="22px"></HeaderStyle>
                                </asp:BoundField>
                                <%-- 2 --%>
                                <asp:BoundField DataField="FechaRegistra" HeaderText="Fecha Creación del Action Plan" SortExpression="">
                                    <ItemStyle Width="10%" HorizontalAlign="Left" Height="15px" Font-Bold="False" CssClass=""></ItemStyle>
                                    <HeaderStyle Width="10%" CssClass="" Height="22px"></HeaderStyle>
                                </asp:BoundField>
                                <%--<asp:BoundField DataField="Asesores" HeaderText="Asesores" SortExpression="">
                                    <ItemStyle Width="4%" HorizontalAlign="Left" Height="15px" Font-Bold="False" CssClass="hidden"></ItemStyle>
                                    <HeaderStyle Width="4%" CssClass="hidden" Height="22px"></HeaderStyle>
                                </asp:BoundField>--%>
                                <%--3--%>
                                <asp:BoundField DataField="Recuperador" HeaderText="Action Plan Gestionado Por" SortExpression="">
                                    <ItemStyle Width="11%" HorizontalAlign="Left" Height="15px" Font-Bold="False" CssClass="hidden"></ItemStyle>
                                    <HeaderStyle Width="11%" CssClass="hidden" Height="22px"></HeaderStyle>
                                </asp:BoundField>
                                <%--4--%>
                                <asp:BoundField DataField="Descripcion_TipoGestion" HeaderText="Tipo Action Plan"
                                    SortExpression="">
                                    <ItemStyle Width="14%" HorizontalAlign="Left" Height="15px" Font-Bold="False"></ItemStyle>
                                    <HeaderStyle Width="14%" CssClass="" Height="22px"></HeaderStyle>
                                </asp:BoundField>
                                <%-- 5 --%>
                                <asp:BoundField DataField="RazonSocial" HeaderText="Cliente / Aval" SortExpression="">
                                    <ItemStyle Width="14%" HorizontalAlign="Left" Height="15px" Font-Bold="False"></ItemStyle>
                                    <HeaderStyle Width="14%" CssClass="" Height="22px"></HeaderStyle>
                                </asp:BoundField>
                                <%--<asp:BoundField DataField="Producto" HeaderText="Producto" SortExpression="">
                                    <ItemStyle Width="6%" HorizontalAlign="Left" Height="15px" Font-Bold="False" CssClass=""></ItemStyle>
                                    <HeaderStyle Width="6%" CssClass="" Height="22px"></HeaderStyle>
                                </asp:BoundField>--%>
                                <%--6--%>
                                <asp:BoundField DataField="Asesores" HeaderText="Asesor de Origen" SortExpression="">
                                    <ItemStyle Width="14%" HorizontalAlign="Left" Height="15px" Font-Bold="False" CssClass=""></ItemStyle>
                                    <HeaderStyle Width="14%" CssClass="" Height="22px"></HeaderStyle>
                                </asp:BoundField>
                                <%--7--%>
                                <asp:BoundField DataField="SubProducto" HeaderText="SubProducto" SortExpression="">
                                    <ItemStyle Width="10%" HorizontalAlign="Left" Height="15px" Font-Bold="False" CssClass="hidden"></ItemStyle>
                                    <HeaderStyle Width="10%" CssClass="hidden" Height="22px"></HeaderStyle>
                                </asp:BoundField>
                                <%--8--%>
                                <asp:BoundField DataField="Responsable" HeaderText="Usuario Responsable" SortExpression="">
                                    <ItemStyle Width="10%" HorizontalAlign="Left" Height="15px" Font-Bold="False"  CssClass=""></ItemStyle>
                                    <HeaderStyle Width="10%" CssClass="" Height="22px"></HeaderStyle>
                                </asp:BoundField>
                                <%--9--%>
                                <asp:BoundField DataField="FechaLimite" HeaderText="Fecha Límite" SortExpression="">
                                    <ItemStyle Width="10%" HorizontalAlign="Left" Height="15px" Font-Bold="False"  CssClass=""></ItemStyle>
                                    <HeaderStyle Width="10%" CssClass="" Height="22px"></HeaderStyle>
                                </asp:BoundField>
                                <%--10--%>
                                <asp:BoundField DataField="FechaTomaControl" HeaderText="Fecha de Toma de Control" SortExpression="">
                                    <ItemStyle Width="10%" HorizontalAlign="Left" Height="15px" Font-Bold="False"  CssClass=""></ItemStyle>
                                    <HeaderStyle Width="10%" CssClass="" Height="22px"></HeaderStyle>
                                </asp:BoundField>
                                <%--<asp:BoundField DataField="dias_mora" HeaderText="Dias Mora" SortExpression="">
                                    <ItemStyle Width="3%" HorizontalAlign="Left" Height="15px" Font-Bold="False"></ItemStyle>
                                    <HeaderStyle Width="3%" CssClass="" Height="22px"></HeaderStyle>
                                </asp:BoundField>--%>
                                <%--11--%>
                                <asp:BoundField DataField="Descripcion_ClaseGestion" HeaderText="Clasificación del Action Plan" SortExpression="">
                                    <ItemStyle Width="10%" HorizontalAlign="Left" Height="15px" Font-Bold="False" CssClass="hidden"></ItemStyle>
                                    <HeaderStyle Width="10%" CssClass="hidden" Height="22px"></HeaderStyle>
                                </asp:BoundField>
                                <%--12--%>
                                <asp:BoundField DataField="Descripcion_Ejecutado" HeaderText="Resultado de Clasificación" SortExpression="">
                                    <ItemStyle Width="10%" HorizontalAlign="Left" Height="15px" Font-Bold="False" CssClass="hidden"></ItemStyle>
                                    <HeaderStyle Width="10%" CssClass="hidden" Height="22px"></HeaderStyle>
                                </asp:BoundField>
                                <%--13--%>
                                <asp:BoundField DataField="comentario" HeaderText="Comentarios" SortExpression="">
                                    <ItemStyle Width="12%" HorizontalAlign="Left" Height="15px" Font-Bold="False"></ItemStyle>
                                    <HeaderStyle Width="12%" CssClass="" Height="22px"></HeaderStyle>
                                </asp:BoundField>
                                <%--<asp:BoundField DataField="Obs" HeaderText="Observaciones" SortExpression="">
                                    <ItemStyle Width="10%" HorizontalAlign="Left" Height="15px" Font-Bold="False"></ItemStyle>
                                    <HeaderStyle Width="10%" CssClass="" Height="22px"></HeaderStyle>
                                </asp:BoundField>--%>
                                <%-- 14 --%>
                                <asp:BoundField DataField="FechaResultado" HeaderText="Fecha de Resultado" SortExpression="">
                                    <ItemStyle Width="10%" HorizontalAlign="Left" Height="15px" Font-Bold="False" CssClass="hidden"></ItemStyle>
                                    <HeaderStyle Width="10%" CssClass="hidden" Height="22px"></HeaderStyle>
                                </asp:BoundField>
                                <%--15--%>
                                <asp:BoundField DataField="CodEjecutado" HeaderText="CodEjecutado" SortExpression="">
                                    <ItemStyle Width="10%" HorizontalAlign="Left" Height="15px" Font-Bold="False" CssClass="hidden">
                                    </ItemStyle>
                                    <HeaderStyle Width="10%" CssClass="hidden" Height="22px"></HeaderStyle>
                                </asp:BoundField>
                                <%--16--%>
                                <asp:BoundField DataField="desc_ejecutores" HeaderText="Ejecutores" SortExpression="">
                                    <ItemStyle Width="10%" HorizontalAlign="Left" Height="15px" Font-Bold="False" CssClass="hidden">
                                    </ItemStyle>
                                    <HeaderStyle Width="10%" Height="22px" CssClass="hidden"></HeaderStyle>
                                </asp:BoundField>
                                
                                <%-- 17 --%>
                                <asp:BoundField DataField="id_estado_gestion_cobranza">
                                    <ItemStyle CssClass="hidden"></ItemStyle>
                                    <HeaderStyle CssClass="hidden"></HeaderStyle>
                                </asp:BoundField>
                                <%--18--%>
                                <asp:BoundField DataField="" HeaderText="Estado" SortExpression="">
                                    <ItemStyle Width="3%" HorizontalAlign="Left" Height="15px" Font-Bold="False"  CssClass=""></ItemStyle>
                                    <HeaderStyle Width="3%" CssClass="" Height="22px"></HeaderStyle>
                                </asp:BoundField>
                                <%--19--%>
                                <asp:BoundField DataField="CodCLaseGestion">
                                    <ItemStyle CssClass="hidden"></ItemStyle>
                                    <HeaderStyle CssClass="hidden"></HeaderStyle>
                                </asp:BoundField>
                                <%--20--%>
                                <asp:BoundField DataField="" HeaderText="Ver Ficha" SortExpression="">
                                    <ItemStyle Width="3%" HorizontalAlign="Left" Height="15px" Font-Bold="False"  CssClass="" ></ItemStyle>
                                    <HeaderStyle Width="3%" CssClass="" Height="22px"></HeaderStyle>
                                </asp:BoundField>
                                <%--21--%>
                                <asp:BoundField DataField="CodigoCliente">
                                    <ItemStyle CssClass="hidden"></ItemStyle>
                                    <HeaderStyle CssClass="hidden"></HeaderStyle>
                                </asp:BoundField>

                                <%-- Modif. Gestiones Internas. 12/06/17 --%>
                                <%-- 22 --%>
                                
                                <asp:BoundField DataField="CodUsuarioNuevo" HeaderText="CodResponsable" SortExpression="">
                                    <ItemStyle Width="10%" HorizontalAlign="Left" Height="15px" Font-Bold="False"  CssClass="hidden"></ItemStyle>
                                    <HeaderStyle Width="10%" CssClass="hidden" Height="22px"></HeaderStyle>
                                </asp:BoundField>
                                <%--23--%>
                                <asp:BoundField DataField="CodEstadoInterno" HeaderText="EstadoInterno" SortExpression="">
                                    <ItemStyle Width="10%" HorizontalAlign="Left" Height="15px" Font-Bold="False"  CssClass="hidden"></ItemStyle>
                                    <HeaderStyle Width="10%" CssClass="hidden" Height="22px"></HeaderStyle>
                                </asp:BoundField>
                                <%-- 24 --%>
                                <asp:BoundField DataField="CodUsuario_Asesores" HeaderText="CodUsuario_Asesores" SortExpression="">
                                    <ItemStyle Width="10%" HorizontalAlign="Left" Height="15px" Font-Bold="False"  CssClass="hidden"></ItemStyle>
                                    <HeaderStyle Width="10%" CssClass="hidden" Height="22px"></HeaderStyle>
                                </asp:BoundField>
                                <%-- Fin Modif. --%>
                                <%--25--%>
                                <asp:TemplateField HeaderText="Select">
                                <HeaderTemplate>
                                <asp:CheckBox ID="chkAll" onclick="javascript:SelectAllCheckboxes(this);" runat="server"
                                Height="15px"></asp:CheckBox>
                                </HeaderTemplate>
                                <ItemTemplate>
                                <asp:CheckBox ID="chkPermiso" runat="server" />
                                </ItemTemplate>
                                </asp:TemplateField>

                                <%--26--%>
                                <asp:BoundField DataField="CodTipoGestion" HeaderText="CodTipoGestion" SortExpression="">
                                    <ItemStyle CssClass="hidden" Width="10%"></ItemStyle>
                                    <HeaderStyle Width="10%" CssClass="hidden" Height="22px"></HeaderStyle>
                                </asp:BoundField>
                                <%--27--%>
                                <asp:BoundField DataField="" HeaderText="Evaluar" SortExpression="">
                                    <ItemStyle Width="10%" HorizontalAlign="Left" Height="15px" Font-Bold="False"  CssClass="hidden"></ItemStyle>
                                    <HeaderStyle Width="10%" CssClass="hidden" Height="22px"></HeaderStyle>
                                </asp:BoundField>

                            </Columns>
                            <PagerStyle BackColor="White" ForeColor="#000066" HorizontalAlign="Left" />
                            <RowStyle ForeColor="#000066"></RowStyle>
                            <EmptyDataTemplate>
                                <table id="tbSinDatos">
                                    <tbody>
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
                                    </tbody>
                                </table>
                            </EmptyDataTemplate>
                            <SelectedRowStyle CssClass="selectedrow" BackColor="#669999" Font-Bold="True" ForeColor="White"></SelectedRowStyle>
                            <AlternatingRowStyle />
                            <SortedAscendingCellStyle BackColor="#F1F1F1" />
                            <SortedAscendingHeaderStyle BackColor="#007DBB" />
                            <SortedDescendingCellStyle BackColor="#CAC9C9" />
                            <SortedDescendingHeaderStyle BackColor="#00547E" />
                        </asp:GridView>
                    </td>
                </tr>
            </table>
            <table id="Contador" cellpadding="0" cellspacing="0" style="width: 100%; text-align: center;">
                <tr>
                    <td class="pagerstyle" style="height: 30px; text-align: center">
                        <asp:Label ID="lblCantidad" runat="server"></asp:Label>&nbsp;
                        <asp:Label ID="lblPaginaGrilla" runat="server"></asp:Label>&nbsp;
                    </td>
                </tr>
            </table>
            <asp:HiddenField ID="hfOrden" runat="server"></asp:HiddenField>
        </ContentTemplate>
        <Triggers>
            <asp:AsyncPostBackTrigger ControlID="btnBuscar" EventName="Click" />
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
</asp:Content>



