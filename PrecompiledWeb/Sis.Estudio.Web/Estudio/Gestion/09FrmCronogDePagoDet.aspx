﻿<%@ page title="" language="C#" masterpagefile="~/Master/Ficha.master" autoeventwireup="true" inherits="Estudio_Gestion_09FrmCronogDePagoDet, App_Web_kou4i3xh" stylesheettheme="Standard" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<%@ MasterType VirtualPath="~/Master/Ficha.Master" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <script src="../../javascript/jquery-2.1.1.min.js" type="text/javascript"></script>
    <script src="../../javascript/jsUpdateProgress.js" type="text/javascript"></script>
    <script type="text/javascript">
        var ModalProgress = '<%= ModalProgress.ClientID %>';
    </script>
    <script src="../../javascript/jsUpdateProgress.js" type="text/javascript"></script>
    <input id="hdnContinuar" name="hdnContinuar" style="width: 80px; height: 10px" type="hidden" />
    <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
        <contenttemplate>

            <table width="100%" border="0" cellpadding="0" cellspacing="0">
                <tr>
                    <td class="encebezadotabla-3" style="width: 98%; text-align:center">
                    DETALLE CRONOGRAMA DE PAGO
                    </td>
                </tr>
            </table>

            <table width="100%" border="0" cellpadding="0" cellspacing="0">
                <tr>
                    <td style="width: 60%;" valign="top">
                        <asp:GridView ID="gv" runat="server"  Width="100%" EnableTheming="True" AutoGenerateColumns="False"
                            AllowSorting="True" PageSize="20" OnSelectedIndexChanged="gv_SelectedIndexChanged">
                            <PagerSettings PreviousPageText="&amp;lt;Anterior" Mode="NextPreviousFirstLast" LastPageText="Ultimo&amp;gt;&amp;gt;"
                                FirstPageText="&amp;lt;&amp;lt;Primero" NextPageText="Siguiente&amp;gt;"></PagerSettings>
                            <Columns>
                                <asp:TemplateField ShowHeader="False">
                                    <ItemStyle Width="1%"></ItemStyle>
                                    <HeaderStyle Width="1%"></HeaderStyle>
                                    <ItemTemplate>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                
                                <asp:BoundField DataField="IdReg" HeaderText="">
                                    <ItemStyle HorizontalAlign="Left" Height="15px" Font-Bold="False" 
                                        CssClass="hidden"></ItemStyle>
                                    <HeaderStyle Height="23px" CssClass="hidden"></HeaderStyle>
                                </asp:BoundField>                                
                                
                                <asp:BoundField DataField="IdReg" HeaderText="Codigo">
                                    <ItemStyle Width="9%" HorizontalAlign="Left" Height="15px" Font-Bold="False"></ItemStyle>
                                    <HeaderStyle Width="9%" Height="23px"></HeaderStyle>
                                </asp:BoundField>
                                                                
                                <asp:BoundField DataField="NroCuotas" HeaderText="NroCuotas">
                                    <ItemStyle Width="10%" HorizontalAlign="Left" Font-Bold="False"></ItemStyle>
                                    <HeaderStyle Width="10%"></HeaderStyle>
                                </asp:BoundField>

                                <asp:BoundField DataField="FechaVencimiento" HeaderText="FechaVencimiento">
                                    <ItemStyle Width="10%" HorizontalAlign="Left" Font-Bold="False"></ItemStyle>
                                    <HeaderStyle Width="10%"></HeaderStyle>
                                </asp:BoundField>

                                <asp:BoundField DataField="FechaPago" HeaderText="FechaPago">
                                    <ItemStyle Width="10%" HorizontalAlign="Left" Font-Bold="False"></ItemStyle>
                                    <HeaderStyle Width="10%"></HeaderStyle>
                                </asp:BoundField>

                                <asp:BoundField DataField="MontoCuota" HeaderText="MontoCuota">
                                    <ItemStyle Width="10%" HorizontalAlign="Left" Font-Bold="False"></ItemStyle>
                                    <HeaderStyle Width="10%"></HeaderStyle>
                                </asp:BoundField>
                     
                                <asp:BoundField DataField="CodEstadoCronograma" HeaderText="CodEstadoCronograma">
                                    <ItemStyle Width="10%" HorizontalAlign="Left" Font-Bold="False"></ItemStyle>
                                    <HeaderStyle Width="10%"></HeaderStyle>
                                </asp:BoundField>

                                <asp:BoundField DataField="Capital" HeaderText="Capital">
                                    <ItemStyle Width="10%" HorizontalAlign="Left" Font-Bold="False"></ItemStyle>
                                    <HeaderStyle Width="10%"></HeaderStyle>
                                </asp:BoundField>

                                <asp:BoundField DataField="Interes" HeaderText="Interes">
                                    <ItemStyle Width="10%" HorizontalAlign="Left" Font-Bold="False"></ItemStyle>
                                    <HeaderStyle Width="10%"></HeaderStyle>
                                </asp:BoundField>


                                <asp:BoundField DataField="SaldoCapital" HeaderText="SaldoCapital">
                                    <ItemStyle Width="10%" HorizontalAlign="Left" Font-Bold="False"></ItemStyle>
                                    <HeaderStyle Width="10%"></HeaderStyle>
                                </asp:BoundField>

                                <asp:BoundField DataField="CodCalificacionSBS" HeaderText="CodCalificacionSBS">
                                    <ItemStyle Width="10%" HorizontalAlign="Left" Font-Bold="False"></ItemStyle>
                                    <HeaderStyle Width="10%"></HeaderStyle>
                                </asp:BoundField>
                                                              
                            </Columns>
                            <RowStyle Font-Names="Times New Roman" Font-Size="12px"></RowStyle>
                            <EmptyDataTemplate>
                                <table id="tbSinDatos">
                                    <tbody>
                                        <tr>
                                            <td style="width: 10%">
                                                <asp:Image runat="server" ID="imgWarning" ImageUrl="~/imagenes/Mensajes/alerta.jpg" />
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
                            <SelectedRowStyle CssClass="selectedrow"></SelectedRowStyle>
                            <AlternatingRowStyle />
                            <PagerStyle CssClass="BarraPie" HorizontalAlign="Center" />
                        </asp:GridView>
                        <table cellpadding="0" cellspacing="0" style="width: 100%">
                            <tr>
                                <td class="GridViewPie" style="text-align: center">
                                    <asp:Label ID="lbl_Cantidad" runat="server" Text="0"></asp:Label>
                                </td>
                            </tr>
                        </table>
                        <asp:HiddenField ID="hd_Codigo" runat="server" />
                        <asp:HiddenField ID="hd_IdRegProductos" runat="server" />
                        
                    </td>
                    <td style="width: 40%;" valign="top">
                        <table width="100%" >
                            <tr>
                                <td style="width: 100%;" align="center">
                                    <table cellpadding="1" cellspacing="0" border="0" style="width: 100%">
                                        <tr id="IdReg">
                                            <td class="celda-titulo" style="width: 30%; text-align: right;">
                                                Codigo&nbsp;
                                            </td>
                                            <td style="text-align: left; width: 70%;">
                                                <asp:TextBox ID="txt_IdReg" runat="server" ForeColor="Black" Height="18px"
                                                    MaxLength="10"  TabIndex="1" 
                                                    Width="98%"></asp:TextBox>
                                            </td>
                                        </tr>          
                                                                                                     
                                        <tr id="NroCuotas">
                                            <td class="celda-titulo" style="width: 30%; text-align: right;">
                                                NroCuotas&nbsp;
                                            </td>
                                            <td style="text-align: left; width: 70%;">
                                                <asp:TextBox ID="txt_NroCuotas" runat="server" ForeColor="Black" Height="18px"
                                                    MaxLength="50"  TabIndex="1" 
                                                Width="98%"></asp:TextBox>
                                            </td>
                                        </tr>
 
                                        <tr id="FechaVencimiento">
                                            <td class="celda-titulo" style="width: 30%; text-align: right;">
                                                FechaVencimiento&nbsp;
                                            </td>
                                            <td style="text-align: left; width: 70%;">
                                                <asp:TextBox ID="txt_FechaVencimiento" runat="server" ForeColor="Black" Height="18px"
                                                    MaxLength="50"  TabIndex="1" 
                                                Width="98%"></asp:TextBox>
                                            </td>
                                        </tr>
 
                                        <tr id="FechaPago">
                                            <td class="celda-titulo" style="width: 30%; text-align: right;">
                                                FechaPago&nbsp;
                                            </td>
                                            <td style="text-align: left; width: 70%;">
                                                <asp:TextBox ID="txt_FechaPago" runat="server" ForeColor="Black" Height="18px"
                                                    MaxLength="50"  TabIndex="1" 
                                                Width="98%"></asp:TextBox>
                                            </td>
                                        </tr>
 
                                        <tr id="MontoCuota">
                                            <td class="celda-titulo" style="width: 30%; text-align: right;">
                                                MontoCuota&nbsp;
                                            </td>
                                            <td style="text-align: left; width: 70%;">
                                                <asp:TextBox ID="txt_MontoCuota" runat="server" ForeColor="Black" Height="18px"
                                                    MaxLength="50"  TabIndex="1" 
                                                Width="98%"></asp:TextBox>
                                            </td>
                                        </tr>

                                        <tr id="EstadoCronograma">
                                            <td class="celda-titulo" style="width: 30%; text-align: right;">
                                                Estado Cronograma&nbsp;
                                            </td>
                                            <td style="text-align: left; width: 70%;">
                                                <asp:DropDownList ID="cmb_EstadoCronograma" runat="server" AutoPostBack="True" TabIndex="1"
                                                Width="90%" >
                                                </asp:DropDownList>
                                            </td>
                                        </tr>
 
                                        <tr id="Capital">
                                            <td class="celda-titulo" style="width: 30%; text-align: right;">
                                                Capital&nbsp;
                                            </td>
                                            <td style="text-align: left; width: 70%;">
                                                <asp:TextBox ID="txt_Capital" runat="server" ForeColor="Black" Height="18px"
                                                    MaxLength="50"  TabIndex="1" 
                                                Width="98%"></asp:TextBox>
                                            </td>
                                        </tr>
 
                                        <tr id="Interes">
                                            <td class="celda-titulo" style="width: 30%; text-align: right;">
                                                Interes&nbsp;
                                            </td>
                                            <td style="text-align: left; width: 70%;">
                                                <asp:TextBox ID="txt_Interes" runat="server" ForeColor="Black" Height="18px"
                                                    MaxLength="50"  TabIndex="1" 
                                                Width="98%"></asp:TextBox>
                                            </td>
                                        </tr>
 
                                        <tr id="SaldoCapital">
                                            <td class="celda-titulo" style="width: 30%; text-align: right;">
                                                SaldoCapital&nbsp;
                                            </td>
                                            <td style="text-align: left; width: 70%;">
                                                <asp:TextBox ID="txt_SaldoCapital" runat="server" ForeColor="Black" Height="18px"
                                                    MaxLength="50"  TabIndex="1" 
                                                Width="98%"></asp:TextBox>
                                            </td>
                                        </tr>
 
                                        <tr id="CalificacionSBS">
                                            <td class="celda-titulo" style="width: 30%; text-align: right;">
                                                Calificacion SBS&nbsp;
                                            </td>
                                            <td style="text-align: left; width: 70%;">
                                                <asp:DropDownList ID="cmb_CalificacionSBS" runat="server" AutoPostBack="True" TabIndex="1"
                                                Width="90%" >
                                                </asp:DropDownList>
                                            </td>
                                        </tr>
 
                                        <tr id="espacio">
                                            <td  style="width: 30%; text-align: right;">
                                                &nbsp;
                                            </td>
                                            <td style="text-align: left; width: 70%;">
                                                &nbsp;
                                            </td>
                                        </tr>

                                    </table>
                                </td>
                            </tr>
                        </table>
                        <table width="100%" cellpadding="1" cellspacing="0" border="0">
                            <tr>
                                <td style="text-align: center;">
                                    &nbsp;<asp:Button ID="btn_Agregar" runat="server" Text="Agregar" Width="100px" 
                                        OnClick="btn_Agregar_Click" BackColor="#1F529E" ForeColor="White" />
                                    &nbsp;<asp:Button ID="btn_Modificar" runat="server" Text="Modificar"
                                        Width="100px" OnClick="btn_Modificar_Click" BackColor="#1F529E" 
                                        ForeColor="White" />
                                    &nbsp;&nbsp;<asp:Button ID="btn_Grabar" runat="server" 
                                        Text="Grabar" Width="100px" onclick="btn_Grabar_Click" BackColor="#1F529E" 
                                        ForeColor="White" />
                                    &nbsp;<asp:Button ID="btn_Cancelar" runat="server"
                                        Text="Cancelar" Width="100px" onclick="btn_Cancelar_Click" 
                                        BackColor="#1F529E" ForeColor="White" />
                                    &nbsp;<asp:Button ID="btn_Retornar" runat="server"
                                        Text="Retornar" Width="100px" onclick="btn_Retornar_Click" 
                                        BackColor="#1F529E" ForeColor="White"  />
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
            </table>
        </contenttemplate>
    </asp:UpdatePanel>
    <asp:Panel ID="panelUpdateProgress" runat="server" CssClass="updateProgress">
        <asp:UpdateProgress ID="UpdateProg1" DisplayAfter="0" runat="server">
            <progresstemplate>
                <div style="position: relative; top: 50%; text-align: center;">
                    <asp:Image runat="server" ID="Progres" ImageUrl="~/imagenes/loading.gif" Style="vertical-align: middle"
                        alt="Procesando…" />
                    <asp:Label runat="server" ID="lblprogres" ForeColor="White" Text="Procesando…"></asp:Label>
                </div>
            </progresstemplate>
        </asp:UpdateProgress>
    </asp:Panel>
    <cc1:ModalPopupExtender ID="ModalProgress" runat="server" TargetControlID="panelUpdateProgress"
        BackgroundCssClass="modalBackground" PopupControlID="panelUpdateProgress">
    </cc1:ModalPopupExtender>
</asp:Content>






