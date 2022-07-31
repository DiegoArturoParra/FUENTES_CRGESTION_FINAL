<%@ page title="" language="C#" masterpagefile="~/Master/Ceem.master" autoeventwireup="true" inherits="Estudio_Gestion_GS_Programacion_VisitasDetalle, App_Web_5d2q0ozo" stylesheettheme="Standard" %>

<%@ Register Assembly="RJS.Web.WebControl.PopCalendar" Namespace="RJS.Web.WebControl"TagPrefix="rjs" %>
<%@ MasterType VirtualPath="~/Master/Ceem.master"  %>
<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="DefaultContent" runat="Server">
    <script language="javascript">

        //****************************************************************************************
        //* Nomre       :SiguienteObjeto() 
        //* DescripcioN :				ARONI ESLAVA JHONNY AGOSTO - 2009
        //****************************************************************************************
        function SiguienteObjeto() {
            if (event.keyCode == 13) event.keyCode = 9;
        }

        function Control_Decimal(ctrl, evt) {
            if (event.keyCode == 13) event.keyCode = 9;
            var charCode = evt.keyCode
            var FIND = "."
            var x = ctrl.value
            var y = x.indexOf(FIND)

            if ((charCode > 45 && charCode < 58) || (charCode > 95 && charCode < 106) || (charCode > 32 && charCode < 41) || (charCode == 8) || (charCode == 9) || (charCode == 17) || (charCode == 27) || (charCode == 110) || (charCode == 190)) {
                if ((charCode == 110) || (charCode == 190)) {
                    if (y < 0) {
                        if (x.length > 0)
                            return true
                        else
                            return false
                    }
                    else
                        return false
                }
                else
                    return true;
            }
            else
                return false;
        }

        function Control_Numero(evt) {
            if (event.keyCode == 13) event.keyCode = 9;
            var charCode = evt.keyCode

            if ((charCode > 45 && charCode < 58) || (charCode > 95 && charCode < 106) || (charCode > 32 && charCode < 41) || (charCode == 8) || (charCode == 9) || (charCode == 17) || (charCode == 27))
                return true
            else
                return false
        }

        function Control_Locked(evt) {
            return false
        }

        function Control_Caracter(evt) {
            if (event.keyCode == 13) event.keyCode = 9;
            var charCode = evt.keyCode

            if (charCode == 219)
                return false
            else
                return true
        }

        function Valida_Texto(texto) {
            if (texto == '') {
                return false;
            }
            else {
                return true;
            }
        }

        function ValidaEliminacion() {

            if (Valida_Texto($get('<%= txt_codigo.ClientID %>').value) == false) {
                return;
            }
            document.getElementById('hdnContinuar').value = confirm('¿Se anulará El registro, ¿Desea continuar?');
        }

    </script>

    <asp:UpdatePanel ID="upBotonera" runat="server" UpdateMode="Conditional">
        <ContentTemplate>

                <table id="tbToolbarSuperior" cellpadding="0" cellspacing="0" class="cabeceraScroll"
                                        style="width: 100%">
                                        <tbody>
                                            <tr>
                                                <td style="width: 20%">
                                                    
                                                    <table class="clsToolbar" cellspacing="0" cellpadding="1" width="120px">
                                                        <tr>
                                                            <td valign="middle" width="10" style="text-align: center">
                                                                <asp:Image ID="imgGrip" runat="server" ImageUrl="~/Imagenes/toolbar.grip.gif">
                                                                </asp:Image>
                                                            </td>
                                                            <td  width="0px" >
                                                                <asp:ImageButton ID="btnAgregar" runat="server" 
                                                                    ImageUrl="~/Imagenes/agregar_disabled.png" 
                                                                    Visible="False" />
                                                            </td>

                                                            <td width="1px" >
                                                                <asp:ImageButton ID="btnModificar" runat="server" 
                                                                    ImageUrl="~/Imagenes/modificar_disabled.png" 
                                                                    Visible="False" />
                                                            </td>

                                                            <td width="1" >
                                                                <asp:ImageButton ID="btnConsultar" runat="server" 
                                                                    ImageUrl="~/Imagenes/consultar_disabled.png" 
                                                                    Visible="False" />
                                                            </td>

                                                            <td width="1px" >
                                                                <asp:ImageButton ID="btnEliminar" runat="server" 
                                                                    ImageUrl="~/Imagenes/eliminar_disabled.png" 
                                                                    onclientclick="ValidaEliminacion()" Visible="False" />
                                                            </td>

                                                            <td width="1px" >
                                                                <asp:ImageButton ID="btnGrabar" runat="server" 
                                                                    ImageUrl="~/Imagenes/grabar_disabled.png" 
                                                                    onclick="btnGrabar_Click" />                                                                
                                                            </td>


                                                            <td width="1px" >
                                                                <asp:ImageButton ID="btnSalir" runat="server" 
                                                                    ImageUrl="~/Imagenes/salir_disabled.png" 
                                                                    onclick="btnSalir_Click" />                                                                
                                                            </td>

                                                            <td valign="middle" width="10" style="text-align: center">
                                                                <asp:Image ID="imgSeparator" runat="server" ImageUrl="~/Imagenes/toolbar.grip.gif">
                                                                </asp:Image>
                                                            </td>
                                                        </tr>
                                                    </table>

                                                </td>
                                                <td style="width: 5%; text-align: right" valign="middle">
                                                </td>
                                                <td style="width: 5%; text-align: left" valign="middle">
                                                    &nbsp;
                                                </td>
                                                <td style="width: 25%">
                                                    &nbsp;</td>
                                                <td style="width: 20%; text-align: left">
                                                </td>
                                                <td style="width: 15%">
                                                </td>
                                                <td style="width: 5%">
                                                    &nbsp;</td>
                                                <td style="width: 5%">
                                                    &nbsp;</td>
                                            </tr>
                                        </tbody>
                                    </table>

                <table width="100%" class="">
                
                <tr>
                    <td style="width: 10%">
                    </td>
                    <td style="width: 80%; text-align: center;">
                                    
                            <asp:UpdateProgress ID="UpdateProgress1" runat="server">
                            <ProgressTemplate>
                                <strong><span style="color: #993366; background-color: lightyellow; font-size: 10pt;
                                    font-family: Tahoma;">Procesando tu solicitud..<br />
                                   <img id="img2" src="../../Imagenes/cargando.gif" style="width: 25px; height: 24px" />
                                    <br />
                                </span></strong>
                            </ProgressTemplate>
                            </asp:UpdateProgress>                                    
                                       
                        <asp:Label ID="lblMensaje" runat="server" CssClass="Etiqueta" ForeColor="Red"></asp:Label>
                        <input style="width: 80px; height: 10px" id="hdnContinuar" type="hidden" name="hdnContinuar" />

                    </td>
                    <td style="width: 10%">
                    </td>
                </tr>
            </table>
        </ContentTemplate>
        <Triggers>
            <asp:AsyncPostBackTrigger ControlID="btnGrabar" EventName="Click" />
            <asp:AsyncPostBackTrigger ControlID="btnSalir" EventName="Click" />
        </Triggers>
    </asp:UpdatePanel>

    <asp:UpdatePanel ID="upControles" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
        
                    <table width="100%" border="0" >
                    <tr>
                        <td>
                        </td>
                    </tr>
                        <tr>
                            <td>
                                <table align="center" border="0" cellpadding="4" cellspacing="1" 
                                    width="800px">
                                    <tbody>
                                        <tr >
                                            <td class="CeldaCabeceraEtiqueta" style="width: 23%; text-align: left; height: 7px;" 
                                                valign="top">
                                                <asp:Label ID="lbl_FECHAREGISTRA16" runat="server" CssClass="labeltextonegro" 
                                                    Text="Código:"></asp:Label>
                                                .</td>
                                            <td class="CeldaCabeceraEtiqueta" style="text-align: left; height: 7px;" 
                                                valign="top">
                                                <asp:TextBox ID="txt_codigo" runat="server" style="background-color:#E8E8E8"
                                                    MaxLength="10"  
                                                    Width="100%" Enabled="False"></asp:TextBox>
                                            </td>
                                        </tr>
                                        <tr >
                                            <td class="labeltextonegro" style="width: 23%; text-align: left;" 
                                                valign="top">
                                                Asesor Comercial:</td>
                                            <td class="CeldaCabeceraControl" style="text-align: left;" 
                                                valign="top">
                                                <asp:TextBox ID="txt_Asesor_Comercial" runat="server" MaxLength="10" 
                                                    style="background-color: #E8E8E8" Width="100%" Enabled="False"></asp:TextBox>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="labeltextonegro" style="width: 23%; text-align: left;" valign="top">
                                                Fecha de Visita:</td>
                                            <td class="labeltextonegro" style="text-align: left;" valign="top">
                                                <asp:TextBox ID="txt_FECHAVISITA" runat="server" Enabled="false" Height="18px" 
                                                    MaxLength="10" TabIndex="5" Width="150px"></asp:TextBox>
                                                <cc1:CalendarExtender ID="CalendarExtender2" runat="server" 
                                                    PopupButtonID="imgCal2" TargetControlID="txt_FECHAVISITA" />
                                                <asp:ImageButton ID="imgCal2" runat="Server" AlternateText="Mostrar calendario" 
                                                    ImageUrl="~/imagenes/Calendar.png" />
                                                &nbsp; hhmm:
                                                <asp:DropDownList ID="cmb_horas" runat="server" TabIndex="6" Width="40px"  class="labeltextonegro">
                                                    <asp:ListItem Value="00">00</asp:ListItem>
                                                    <asp:ListItem Value="01">01</asp:ListItem>
                                                    <asp:ListItem Value="02">02</asp:ListItem>
                                                    <asp:ListItem Value="03">03</asp:ListItem>
                                                    <asp:ListItem Value="04">04</asp:ListItem>
                                                    <asp:ListItem Value="05">05</asp:ListItem>
                                                    <asp:ListItem Value="06">06</asp:ListItem>
                                                    <asp:ListItem Value="07">07</asp:ListItem>
                                                    <asp:ListItem Value="08">08</asp:ListItem>
                                                    <asp:ListItem Value="09">09</asp:ListItem>
                                                    <asp:ListItem Value="10">10</asp:ListItem>
                                                    <asp:ListItem Value="11">11</asp:ListItem>
                                                    <asp:ListItem Value="12">12</asp:ListItem>
                                                    <asp:ListItem Value="13">13</asp:ListItem>
                                                    <asp:ListItem Value="14">14</asp:ListItem>
                                                    <asp:ListItem Value="15">15</asp:ListItem>
                                                    <asp:ListItem Value="16">16</asp:ListItem>
                                                    <asp:ListItem Value="17">17</asp:ListItem>
                                                    <asp:ListItem Value="18">18</asp:ListItem>
                                                    <asp:ListItem Value="19">19</asp:ListItem>
                                                    <asp:ListItem Value="20">20</asp:ListItem>
                                                    <asp:ListItem Value="21">21</asp:ListItem>
                                                    <asp:ListItem Value="22">22</asp:ListItem>
                                                    <asp:ListItem Value="23">23</asp:ListItem>
                                                    <asp:ListItem Value="24">24</asp:ListItem>
                                                </asp:DropDownList>
                                                <asp:DropDownList ID="cmb_minutos" runat="server" class="labeltextonegro" 
                                                    TabIndex="6" Width="40px">
                                                    <asp:ListItem Value="00">00</asp:ListItem>
                                                    <asp:ListItem Value="01">01</asp:ListItem>
                                                    <asp:ListItem Value="02">02</asp:ListItem>
                                                    <asp:ListItem Value="03">03</asp:ListItem>
                                                    <asp:ListItem Value="04">04</asp:ListItem>
                                                    <asp:ListItem Value="05">05</asp:ListItem>
                                                    <asp:ListItem Value="06">06</asp:ListItem>
                                                    <asp:ListItem Value="07">07</asp:ListItem>
                                                    <asp:ListItem Value="08">08</asp:ListItem>
                                                    <asp:ListItem Value="09">09</asp:ListItem>
                                                    <asp:ListItem Value="10">10</asp:ListItem>
                                                    <asp:ListItem Value="11">11</asp:ListItem>
                                                    <asp:ListItem Value="12">12</asp:ListItem>
                                                    <asp:ListItem Value="13">13</asp:ListItem>
                                                    <asp:ListItem Value="14">14</asp:ListItem>
                                                    <asp:ListItem Value="15">15</asp:ListItem>
                                                    <asp:ListItem Value="16">16</asp:ListItem>
                                                    <asp:ListItem Value="17">17</asp:ListItem>
                                                    <asp:ListItem Value="18">18</asp:ListItem>
                                                    <asp:ListItem Value="19">19</asp:ListItem>
                                                    <asp:ListItem Value="20">20</asp:ListItem>
                                                    <asp:ListItem Value="21">21</asp:ListItem>
                                                    <asp:ListItem Value="22">22</asp:ListItem>
                                                    <asp:ListItem Value="23">23</asp:ListItem>
                                                    <asp:ListItem Value="24">24</asp:ListItem>
                                                    <asp:ListItem Value="25">25</asp:ListItem>
                                                    <asp:ListItem Value="26">26</asp:ListItem>
                                                    <asp:ListItem Value="27">27</asp:ListItem>
                                                    <asp:ListItem Value="28">28</asp:ListItem>
                                                    <asp:ListItem Value="29">29</asp:ListItem>
                                                    <asp:ListItem Value="30">30</asp:ListItem>
                                                    <asp:ListItem Value="31">31</asp:ListItem>
                                                    <asp:ListItem Value="32">32</asp:ListItem>
                                                    <asp:ListItem Value="33">33</asp:ListItem>
                                                    <asp:ListItem Value="34">34</asp:ListItem>
                                                    <asp:ListItem Value="35">35</asp:ListItem>
                                                    <asp:ListItem Value="36">36</asp:ListItem>
                                                    <asp:ListItem Value="37">37</asp:ListItem>
                                                    <asp:ListItem Value="38">38</asp:ListItem>
                                                    <asp:ListItem Value="39">39</asp:ListItem>
                                                    <asp:ListItem Value="40">40</asp:ListItem>
                                                    <asp:ListItem Value="41">41</asp:ListItem>
                                                    <asp:ListItem Value="42">42</asp:ListItem>
                                                    <asp:ListItem Value="43">43</asp:ListItem>
                                                    <asp:ListItem Value="44">44</asp:ListItem>
                                                    <asp:ListItem Value="45">45</asp:ListItem>
                                                    <asp:ListItem Value="46">46</asp:ListItem>
                                                    <asp:ListItem Value="47">47</asp:ListItem>
                                                    <asp:ListItem Value="48">48</asp:ListItem>
                                                    <asp:ListItem Value="49">49</asp:ListItem>
                                                    <asp:ListItem Value="50">50</asp:ListItem>
                                                    <asp:ListItem Value="51">51</asp:ListItem>
                                                    <asp:ListItem Value="52">52</asp:ListItem>
                                                    <asp:ListItem Value="53">53</asp:ListItem>
                                                    <asp:ListItem Value="54">54</asp:ListItem>
                                                    <asp:ListItem Value="55">55</asp:ListItem>
                                                    <asp:ListItem Value="56">56</asp:ListItem>
                                                    <asp:ListItem Value="57">57</asp:ListItem>
                                                    <asp:ListItem Value="58">58</asp:ListItem>
                                                    <asp:ListItem Value="59">59</asp:ListItem>


                                                </asp:DropDownList>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="labeltextonegro" style="width: 23%; text-align: left;" valign="top">
                                                Codigo de Cliente:</td>
                                            <td class="CeldaCabeceraControl" style="text-align: left;" valign="top">
                                                <asp:TextBox ID="txt_CodigoCliente" runat="server" MaxLength="10" 
                                                    style="background-color: #E8E8E8" Width="100%" Enabled="False"></asp:TextBox>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="labeltextonegro" style="width: 23%; text-align: left;" valign="top">
                                                Cliente:</td>
                                            <td class="CeldaCabeceraControl" style="text-align: left;" valign="top">
                                                <asp:TextBox ID="txt_Cliente" runat="server" MaxLength="10" 
                                                    style="background-color: #E8E8E8" Width="100%" Enabled="False"></asp:TextBox>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="labeltextonegro" style="width: 23%; text-align: left;" valign="top">
                                                Producto:</td>
                                            <td class="CeldaCabeceraControl" style="text-align: left;" valign="top">
                                                <asp:TextBox ID="txt_Producto" runat="server" MaxLength="10" 
                                                    style="background-color: #E8E8E8" Width="100%" Enabled="False"></asp:TextBox>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="labeltextonegro" style="width: 23%; text-align: left;" valign="top">
                                                SubProducto:</td>
                                            <td class="CeldaCabeceraControl" style="text-align: left;" valign="top">
                                                <asp:TextBox ID="txt_SubProducto" runat="server" MaxLength="10" 
                                                    style="background-color: #E8E8E8" Width="100%" Enabled="False"></asp:TextBox>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="labeltextonegro" style="width: 23%; text-align: left;" valign="top">
                                                Dias de mora:</td>
                                            <td class="CeldaCabeceraControl" style="text-align: left;" valign="top">
                                                <asp:TextBox ID="txt_dias_mora" runat="server" MaxLength="10" 
                                                    style="background-color: #E8E8E8" Width="100%" Enabled="False"></asp:TextBox>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="labeltextonegro" style="width: 23%; text-align: left;" valign="top">
                                                Tipo de Agencia:</td>
                                            <td class="CeldaCabeceraControl" style="text-align: left;" valign="top">
                                                <asp:TextBox ID="txt_TipoAgencia" runat="server" MaxLength="10" 
                                                    style="background-color: #E8E8E8" Width="100%" Enabled="False"></asp:TextBox>
                                            </td>
                                        </tr>
                                    </tbody>
                                </table>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                &nbsp;</td>
                        </tr>
                        <tr>
                            <td>
                                <asp:GridView ID="gv" runat="server" AllowPaging="True" AllowSorting="True" 
                                    AutoGenerateColumns="False" EnableTheming="True" PageSize="20" Width="71%" 
                                    HorizontalAlign="Center" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" CellPadding="3">
                                    <FooterStyle BackColor="White" ForeColor="#000066" />
                                    <HeaderStyle BackColor="#006699" Font-Bold="True" ForeColor="White" />
                                    <PagerSettings FirstPageText="&amp;lt;&amp;lt;Primero" 
                                        LastPageText="Ultimo&amp;gt;&amp;gt;" 
                                        NextPageText="Siguiente&amp;gt;" PreviousPageText="&amp;lt;Anterior" />
                                    <Columns>
                                        <asp:TemplateField ShowHeader="False">
                                            <ItemStyle Width="1%" />
                                            <HeaderStyle CssClass="" Width="1%" />
                                            <ItemTemplate>
                                            </ItemTemplate>
                                        </asp:TemplateField>

                                        <asp:BoundField DataField="IdReg" HeaderText="IdReg" SortExpression="">
                                        <ItemStyle Font-Bold="False" Height="15px" HorizontalAlign="Left" Width="10%" />
                                        <HeaderStyle CssClass="" Height="22px" Width="10%" />
                                        </asp:BoundField>

                                        <asp:BoundField DataField="Dir" HeaderText="Dirección" SortExpression="">
                                        <ItemStyle Font-Bold="False" Height="15px" HorizontalAlign="Left" Width="50%" />
                                        <HeaderStyle CssClass="" Height="22px" Width="10%" />
                                        </asp:BoundField>

                                        <asp:BoundField DataField="ubigeo" HeaderText="Ubigeo" 
                                            SortExpression="">
                                        <ItemStyle Font-Bold="False" Height="15px" HorizontalAlign="Left" Width="40%" />
                                        <HeaderStyle CssClass="" Height="22px" Width="10%" />
                                        </asp:BoundField>

                                    </Columns>
                                    <PagerStyle BackColor="White" ForeColor="#000066" HorizontalAlign="Left" />
                                    <RowStyle ForeColor="#000066" />
                                    <EmptyDataTemplate>
                                        <table ID="tbSinDatos">
                                            <tbody>
                                                <tr>
                                                    <td style="width: 10%">
                                                        <img src="../../Imagenes/imgWarning.png" style="width:25px; height:24px" />
                                                    </td>
                                                    <td style="width: 5%">
                                                    </td>
                                                    <td style="width: 85%">
                                                        <asp:Label ID="lblSinDatos" runat="server" CssClass="labeltextonegro" 
                                                            Text="No se encontraron Datos..."></asp:Label>
                                                    </td>
                                                </tr>
                                            </tbody>
                                        </table>
                                    </EmptyDataTemplate>
                                    <SelectedRowStyle CssClass="selectedrow" BackColor="#669999" Font-Bold="True" ForeColor="White" />
                                    <AlternatingRowStyle />
                                    <SortedAscendingCellStyle BackColor="#F1F1F1" />
                                    <SortedAscendingHeaderStyle BackColor="#007DBB" />
                                    <SortedDescendingCellStyle BackColor="#CAC9C9" />
                                    <SortedDescendingHeaderStyle BackColor="#00547E" />
                                </asp:GridView>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                &nbsp;</td>
                        </tr>
                    <tr>
                        <td>
                            <asp:Label ID="lbl_ESTADOREGISTRA" runat="server" CssClass="Item" 
                                Text="Estado_creacion"></asp:Label>
                            <asp:Label ID="lbl_ESTADOMODIFICA" runat="server" CssClass="Item" 
                                Text="estado_modificacion"></asp:Label>
                            <asp:Label ID="lbl_ESTADOANULA" runat="server" CssClass="Item" 
                                Text="estado_anulacion"></asp:Label>
                        </td>                        
                    </tr>
                        <tr>
                            <td>
                                <table align="center" border="0" cellpadding="0" cellspacing="2" class="" 
                                    width="800px">
                                    <tbody>
                                        <tr bgcolor="#000080">
                                            <td class="" colspan="3" style="text-align: center;" valign="top">
                                                <asp:Label ID="lbl_FECHAREGISTRA19" runat="server" CssClass="labeltextoblanco" 
                                                    Text="Auditoría de Cambios"></asp:Label>
                                            </td>
                                        </tr>
                                        <tr bgcolor="#cccccc">
                                            <td class="" style="width: 8%; text-align: left;" valign="">
                                                &nbsp;<asp:Label ID="lbl_FECHAREGISTRA8" runat="server" CssClass="labeltextonegro" 
                                                    Text="Estado"></asp:Label>
                                            </td>
                                            <td class="" style="width: 18%; text-align: left; " valign="">
                                                &nbsp;<asp:Label ID="lbl_FECHAREGISTRA3" runat="server" CssClass="labeltextonegro" 
                                                    Text="Usuario"></asp:Label>
                                            </td>
                                            <td class="" style="width: 9%; text-align: left;" valign="">
                                                &nbsp;<asp:Label ID="lbl_FECHAREGISTRA4" runat="server" CssClass="labeltextonegro" 
                                                    Text="Fecha"></asp:Label>
                                            </td>
                                        </tr>
                                        <tr bgcolor="#ffffff">
                                            <td class="" style="width: 8%; text-align: left;" valign="">
                                                &nbsp;<asp:Label ID="lbl_FECHAREGISTRA5" runat="server" CssClass="labeltextonegro" 
                                                    Text="Creación"></asp:Label>
                                            </td>
                                            <td class="" style="width: 18%; text-align: left;" valign="">
                                                &nbsp;<asp:Label ID="lbl_CODUSUARIOREGISTRA" runat="server" 
                                                    CssClass="labeltextonegro" Text="usuario creacion"></asp:Label>
                                            </td>
                                            <td class="" style="width: 9%; text-align: left;" valign="">
                                                &nbsp;<asp:Label ID="lbl_FECHAREGISTRA" runat="server" CssClass="labeltextonegro" 
                                                    Text="fecha creacion"></asp:Label>
                                            </td>
                                        </tr>
                                        <tr bgcolor="#ffffff">
                                            <td class="" style="width: 8%; text-align: left;" valign="">
                                                &nbsp;<asp:Label ID="lbl_FECHAREGISTRA6" runat="server" CssClass="labeltextonegro" 
                                                    Text="Modificación"></asp:Label>
                                            </td>
                                            <td class="" style="width: 18%; text-align: left;" valign="">
                                                &nbsp;<asp:Label ID="lbl_CODUSUARIOMODIFICA" runat="server" 
                                                    CssClass="labeltextonegro" Text="usuario_modificación"></asp:Label>
                                            </td>
                                            <td class="" style="width: 9%; text-align: left;" valign="">
                                                &nbsp;<asp:Label ID="lbl_FECHAMODIFICA" runat="server" CssClass="labeltextonegro" 
                                                    Text="fecha_modificacion"></asp:Label>
                                            </td>
                                        </tr>
                                        <tr bgcolor="#ffffff">
                                            <td class="" style="width: 8%; text-align: left;" valign="">
                                                &nbsp;<asp:Label ID="lbl_FECHAREGISTRA7" runat="server" CssClass="labeltextonegro" 
                                                    Text="Anulación"></asp:Label>
                                            </td>
                                            <td class="" style="width: 18%; text-align: left;" valign="">
                                                &nbsp;<asp:Label ID="lbl_CODUSUARIOANULA" runat="server" CssClass="labeltextonegro" 
                                                    Text="usuario anulacion"></asp:Label>
                                            </td>
                                            <td class="" style="width: 9%; text-align: left;" valign="">
                                                &nbsp;<asp:Label ID="lbl_FECHAANULA" runat="server" CssClass="labeltextonegro" 
                                                    Text="fecha anulacion"></asp:Label>
                                            </td>
                                        </tr>
                                    </tbody>
                                </table>
                            </td>
                        </tr>
                    </table>
        
   
        
            
            
        </ContentTemplate>
    </asp:UpdatePanel>
    
</asp:Content>


