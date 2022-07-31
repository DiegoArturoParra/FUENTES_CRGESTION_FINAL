﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Master/Ficha.master" AutoEventWireup="true" CodeFile="08FrmGaranxProducDet.aspx.cs" Inherits="Estudio_Gestion_08FrmGaranxProducDet" %>
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
        
                    
                        <table width="100%" cellpadding="0" cellspacing="0">
                            <tr  id="Titulo_avalDireccion">
                            <td class="encebezadotabla-3" style="width: 98%; text-align:center" colspan="2">
                            DETALLE GARANTIA POR PRODUCTO
                            </td>
                            </tr>

                            <tr>
                                <td style="width: 60%; vertical-align: top;">
                                
                                    <asp:GridView ID="gv" runat="server" Width="100%" EnableTheming="True" AutoGenerateColumns="False"
                                    AllowSorting="True" PageSize="20" OnSelectedIndexChanged="gv_SelectedIndexChanged" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" CellPadding="3">
                                        <FooterStyle BackColor="White" ForeColor="#000066" />
                                        <HeaderStyle BackColor="#006699" Font-Bold="True" ForeColor="White" />
                                    <PagerSettings PreviousPageText="&amp;lt;Anterior" LastPageText="Ultimo&amp;gt;&amp;gt;"
                                    FirstPageText="&amp;lt;&amp;lt;Primero" NextPageText="Siguiente&amp;gt;"></PagerSettings>
                                    <Columns>
                                                                                                              
                                    <asp:BoundField DataField="IdReg" HeaderText="">
                                    <ItemStyle HorizontalAlign="Left" Font-Bold="False" 
                                        CssClass="hidden"></ItemStyle>
                                    <HeaderStyle CssClass="hidden"></HeaderStyle>
                                    </asp:BoundField>

                                    <asp:BoundField DataField="IdRegProductos" HeaderText="">
                                    <ItemStyle HorizontalAlign="Left" Font-Bold="False" 
                                        CssClass="hidden"></ItemStyle>
                                    <HeaderStyle CssClass="hidden"></HeaderStyle>
                                    </asp:BoundField>
                                                       
                                    <asp:BoundField DataField="Garantia" HeaderText="Tipo Garantia">
                                    <ItemStyle Width="10%" HorizontalAlign="Left"  Font-Bold="False"></ItemStyle>
                                    <HeaderStyle Width="10%" ></HeaderStyle>
                                    </asp:BoundField>

                                    <asp:BoundField DataField="TipoBien" HeaderText="Tipo Bien">
                                    <ItemStyle Width="10%" HorizontalAlign="Left"  Font-Bold="False"></ItemStyle>
                                    <HeaderStyle Width="10%" ></HeaderStyle>
                                    </asp:BoundField>

                                    <asp:BoundField DataField="TipoBien" HeaderText="Tipo Bien">
                                    <ItemStyle Width="10%" HorizontalAlign="Left"  Font-Bold="False"></ItemStyle>
                                    <HeaderStyle Width="10%" ></HeaderStyle>
                                    </asp:BoundField>

                                    <asp:BoundField DataField="DescripBien" HeaderText="Descrip Bien">
                                    <ItemStyle Width="10%" HorizontalAlign="Left"  Font-Bold="False"></ItemStyle>
                                    <HeaderStyle Width="10%" ></HeaderStyle>
                                    </asp:BoundField>            
                                                        
                                    <asp:BoundField DataField="Telefonos" HeaderText="Telefonos">
                                    <ItemStyle Width="10%" HorizontalAlign="Left"  Font-Bold="False"></ItemStyle>
                                    <HeaderStyle Width="10%" ></HeaderStyle>
                                    </asp:BoundField>  
                            
                                    <asp:BoundField DataField="Propietarios" HeaderText="Propietarios">
                                    <ItemStyle Width="10%" HorizontalAlign="Left"  Font-Bold="False"></ItemStyle>
                                    <HeaderStyle Width="10%" ></HeaderStyle>
                                    </asp:BoundField>  
                            
                                    <asp:BoundField DataField="NombreGarante" HeaderText="Nombre Garante">
                                    <ItemStyle Width="10%" HorizontalAlign="Left"  Font-Bold="False"></ItemStyle>
                                    <HeaderStyle Width="10%" ></HeaderStyle>
                                    </asp:BoundField>  
                                                                                                                                  
                                    </Columns>
                                    <RowStyle Font-Names="Trebuchet MS" Font-Size="12px" ForeColor="#000066"></RowStyle>
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
                                    <SelectedRowStyle CssClass="selectedrow" BackColor="#669999" Font-Bold="True" ForeColor="White"></SelectedRowStyle>
                                    <AlternatingRowStyle />
                                    <PagerStyle CssClass="BarraPie" HorizontalAlign="Left" BackColor="White" ForeColor="#000066" />
                                        <SortedAscendingCellStyle BackColor="#F1F1F1" />
                                        <SortedAscendingHeaderStyle BackColor="#007DBB" />
                                        <SortedDescendingCellStyle BackColor="#CAC9C9" />
                                        <SortedDescendingHeaderStyle BackColor="#00547E" />
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
                                <td style="width: 40%; vertical-align: top;">
                                
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
                                                                                                                    
                                                <tr id="TipoGarantia">
                                                    <td class="celda-titulo" style="width: 30%; text-align: right;">
                                                        Tipo Garantia&nbsp;
                                                    </td>
                                                    <td style="text-align: left; width: 70%;">
                                                        <asp:DropDownList ID="cmb_TipoGarantia" runat="server" AutoPostBack="True" TabIndex="1"
                                                        Width="90%" >
                                                        </asp:DropDownList>
                                                    </td>
                                                </tr>

                                                <tr id="TipoBien">
                                                    <td class="celda-titulo" style="width: 30%; text-align: right;">
                                                        Tipo Bien&nbsp;
                                                    </td>
                                                    <td style="text-align: left; width: 70%;">
                                                        <asp:DropDownList ID="cmb_TipoBien" runat="server" AutoPostBack="True" TabIndex="1"
                                                        Width="90%" >
                                                        </asp:DropDownList>
                                                    </td>
                                                </tr>
 
                                                <tr id="DescripBien">
                                                    <td class="celda-titulo" style="width: 30%; text-align: right;">
                                                        DescripBien&nbsp;
                                                    </td>
                                                    <td style="text-align: left; width: 70%;">
                                                        <asp:TextBox ID="txt_DescripBien" runat="server" ForeColor="Black" Height="18px"
                                                            MaxLength="50"  TabIndex="1" 
                                                        Width="98%"></asp:TextBox>
                                                    </td>
                                                </tr>
 
                                                <tr id="Telefonos">
                                                    <td class="celda-titulo" style="width: 30%; text-align: right;">
                                                        Telefonos&nbsp;
                                                    </td>
                                                    <td style="text-align: left; width: 70%;">
                                                        <asp:TextBox ID="txt_Telefonos" runat="server" ForeColor="Black" Height="18px"
                                                            MaxLength="50"  TabIndex="1" 
                                                        Width="98%"></asp:TextBox>
                                                    </td>
                                                </tr>
 
                                                <tr id="Propietarios">
                                                    <td class="celda-titulo" style="width: 30%; text-align: right;">
                                                        Propietarios&nbsp;
                                                    </td>
                                                    <td style="text-align: left; width: 70%;">
                                                        <asp:TextBox ID="txt_Propietarios" runat="server" ForeColor="Black" Height="18px"
                                                            MaxLength="50"  TabIndex="1" 
                                                        Width="98%"></asp:TextBox>
                                                    </td>
                                                </tr>
 
                                                <tr id="NombreGarante">
                                                    <td class="celda-titulo" style="width: 30%; text-align: right;">
                                                        Nombre Garante&nbsp;
                                                    </td>
                                                    <td style="text-align: left; width: 70%;">
                                                        <asp:TextBox ID="txt_NombreGarante" runat="server" ForeColor="Black" Height="18px"
                                                            MaxLength="50"  TabIndex="1" 
                                                        Width="98%"></asp:TextBox>
                                                    </td>
                                                </tr>
 
                                                <tr id="Beneficiario">
                                                    <td class="celda-titulo" style="width: 30%; text-align: right;">
                                                        Beneficiario&nbsp;
                                                    </td>
                                                    <td style="text-align: left; width: 70%;">
                                                        <asp:TextBox ID="txt_Beneficiario" runat="server" ForeColor="Black" Height="18px"
                                                            MaxLength="50"  TabIndex="1" 
                                                        Width="98%"></asp:TextBox>
                                                    </td>
                                                </tr>
 
                                                <tr id="Ubicacion">
                                                    <td class="celda-titulo" style="width: 30%; text-align: right;">
                                                        Ubicacion&nbsp;
                                                    </td>
                                                    <td style="text-align: left; width: 70%;">
                                                        <asp:TextBox ID="txt_Ubicacion" runat="server" ForeColor="Black" Height="18px"
                                                            MaxLength="50"  TabIndex="1" 
                                                        Width="98%"></asp:TextBox>
                                                    </td>
                                                </tr>
 
                                                <tr id="Direccion">
                                                    <td class="celda-titulo" style="width: 30%; text-align: right;">
                                                        Direccion&nbsp;
                                                    </td>
                                                    <td style="text-align: left; width: 70%;">
                                                        <asp:TextBox ID="txt_Direccion" runat="server" ForeColor="Black" Height="18px"
                                                            MaxLength="50"  TabIndex="1" 
                                                        Width="98%"></asp:TextBox>
                                                    </td>
                                                </tr>
 
                                                <tr id="area">
                                                    <td class="celda-titulo" style="width: 30%; text-align: right;">
                                                        Area&nbsp;
                                                    </td>
                                                    <td style="text-align: left; width: 70%;">
                                                        <asp:TextBox ID="txt_area" runat="server" ForeColor="Black" Height="18px"
                                                            MaxLength="50"  TabIndex="1" 
                                                        Width="98%"></asp:TextBox>
                                                    </td>
                                                </tr>
 
                                                <tr id="DNI">
                                                    <td class="celda-titulo" style="width: 30%; text-align: right;">
                                                        DNI&nbsp;
                                                    </td>
                                                    <td style="text-align: left; width: 70%;">
                                                        <asp:TextBox ID="txt_DNI" runat="server" ForeColor="Black" Height="18px"
                                                            MaxLength="50"  TabIndex="1" 
                                                        Width="98%"></asp:TextBox>
                                                    </td>
                                                </tr>
 
                                                <tr id="ValorComercial">
                                                    <td class="celda-titulo" style="width: 30%; text-align: right;">
                                                        Valor Comercial&nbsp;
                                                    </td>
                                                    <td style="text-align: left; width: 70%;">
                                                        <asp:TextBox ID="txt_ValorComercial" runat="server" ForeColor="Black" Height="18px"
                                                            MaxLength="50"  TabIndex="1" 
                                                        Width="98%"></asp:TextBox>
                                                    </td>
                                                </tr>
 
                                                <tr id="MontoGarantia">
                                                    <td class="celda-titulo" style="width: 30%; text-align: right;">
                                                        Monto Garantia&nbsp;
                                                    </td>
                                                    <td style="text-align: left; width: 70%;">
                                                        <asp:TextBox ID="txt_MontoGarantia" runat="server" ForeColor="Black" Height="18px"
                                                            MaxLength="50"  TabIndex="1" 
                                                        Width="98%"></asp:TextBox>
                                                    </td>
                                                </tr>
 
                                                <tr id="CartaFianza">
                                                    <td class="celda-titulo" style="width: 30%; text-align: right;">
                                                        Carta Fianza&nbsp;
                                                    </td>
                                                    <td style="text-align: left; width: 70%;">
                                                        <asp:TextBox ID="txt_CartaFianza" runat="server" ForeColor="Black" Height="18px"
                                                            MaxLength="50"  TabIndex="1" 
                                                        Width="98%"></asp:TextBox>
                                                    </td>
                                                </tr>
 
                                                <tr id="FechaUltTasacion">
                                                    <td class="celda-titulo" style="width: 30%; text-align: right;">
                                                        Fecha Ultima Tasacion&nbsp;
                                                    </td>
                                                    <td style="text-align: left; width: 70%;">
                                                        <asp:TextBox ID="txt_FechaUltTasacion" runat="server" ForeColor="Black" Height="18px"
                                                            MaxLength="50"  TabIndex="1" 
                                                        Width="98%"></asp:TextBox>
                                                    </td>
                                                </tr>
 
                                                <tr id="VencimientoCF">
                                                    <td class="celda-titulo" style="width: 30%; text-align: right;">
                                                        Vencimiento CF&nbsp;
                                                    </td>
                                                    <td style="text-align: left; width: 70%;">
                                                        <asp:TextBox ID="txt_VencimientoCF" runat="server" ForeColor="Black" Height="18px"
                                                            MaxLength="50"  TabIndex="1" 
                                                        Width="98%"></asp:TextBox>
                                                    </td>
                                                </tr>
 
                                                <tr id="ValorGravamen">
                                                    <td class="celda-titulo" style="width: 30%; text-align: right;">
                                                        Valor Gravamen&nbsp;
                                                    </td>
                                                    <td style="text-align: left; width: 70%;">
                                                        <asp:TextBox ID="txt_ValorGravamen" runat="server" ForeColor="Black" Height="18px"
                                                            MaxLength="50"  TabIndex="1" 
                                                        Width="98%"></asp:TextBox>
                                                    </td>
                                                </tr>
 
                                                <tr id="NumPartidaElec">
                                                    <td class="celda-titulo" style="width: 30%; text-align: right;">
                                                        Num Partida Electronica&nbsp;
                                                    </td>
                                                    <td style="text-align: left; width: 70%;">
                                                        <asp:TextBox ID="txt_NumPartidaElec" runat="server" ForeColor="Black" Height="18px"
                                                            MaxLength="50"  TabIndex="1" 
                                                        Width="98%"></asp:TextBox>
                                                    </td>
                                                </tr>
 
                                                <tr id="Observacion">
                                                    <td class="celda-titulo" style="width: 30%; text-align: right;">
                                                        Observacion&nbsp;
                                                    </td>
                                                    <td style="text-align: left; width: 70%;">
                                                        <asp:TextBox ID="txt_Observacion" runat="server" ForeColor="Black" Height="18px"
                                                            MaxLength="50"  TabIndex="1" 
                                                        Width="98%"></asp:TextBox>
                                                    </td>
                                                </tr>
 
                                                <tr id="Restricciones">
                                                    <td class="celda-titulo" style="width: 30%; text-align: right;">
                                                        Restricciones&nbsp;
                                                    </td>
                                                    <td style="text-align: left; width: 70%;">
                                                        <asp:TextBox ID="txt_Restricciones" runat="server" ForeColor="Black" Height="18px"
                                                            MaxLength="50"  TabIndex="1" 
                                                        Width="98%"></asp:TextBox>
                                                    </td>
                                                </tr>
 
                                                <tr id="CoberturaCF">
                                                    <td class="celda-titulo" style="width: 30%; text-align: right;">
                                                        CoberturaCF&nbsp;
                                                    </td>
                                                    <td style="text-align: left; width: 70%;">
                                                        <asp:TextBox ID="txt_CoberturaCF" runat="server" ForeColor="Black" Height="18px"
                                                            MaxLength="50"  TabIndex="1" 
                                                        Width="98%"></asp:TextBox>
                                                    </td>
                                                </tr>
                                                             
                                                <tr id="Estado">
                                                    <td class="celda-titulo" style="width: 30%; text-align: right;">
                                                        Estado&nbsp;
                                                    </td>
                                                    <td style="text-align: left; width: 70%;">
                                                        <asp:DropDownList ID="cmb_Estado" runat="server" AutoPostBack="True" TabIndex="1"
                                                        Width="90%" >
                                                            <asp:ListItem Value="s">Habilitado</asp:ListItem>
                                                            <asp:ListItem Value="n">Inactivo</asp:ListItem>
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
                                                OnClick="btn_Agregar_Click" BackColor="#000080" ForeColor="White" />
                                            &nbsp;<asp:Button ID="btn_Modificar" runat="server" Text="Modificar"
                                                Width="100px" OnClick="btn_Modificar_Click" BackColor="#000080" 
                                                ForeColor="White" />
                                            &nbsp;&nbsp;<asp:Button ID="btn_Grabar" runat="server" 
                                                Text="Grabar" Width="100px" onclick="btn_Grabar_Click" BackColor="#000080" 
                                                ForeColor="White" />
                                            &nbsp;<asp:Button ID="btn_Cancelar" runat="server"
                                                Text="Cancelar" Width="100px" onclick="btn_Cancelar_Click" 
                                                BackColor="#000080" ForeColor="White" />
                                            &nbsp;<asp:Button ID="btn_Retornar" runat="server"
                                                Text="Retornar" Width="100px" onclick="btn_Retornar_Click" 
                                                BackColor="#000080" ForeColor="White"  />
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






