<%@ page title="" language="C#" masterpagefile="~/Master/Ceem.master" autoeventwireup="true" inherits="Estudio_Gestion_00ListaCliente, App_Web_0nt2mo3d" stylesheettheme="Standard" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<%@ MasterType VirtualPath="~/Master/Ceem.master" %>
<asp:Content ID="Content1" ContentPlaceHolderID="DefaultContent" Runat="Server">
<table width="100%" border="0"  cellspacing="0">
                <tbody>                                    
                    <tr>
                        <td colspan="6" style="height: 15px; text-align: center" class="FondoBlanco">
                            <asp:Label ID="lblMensaje" runat="server" CssClass="Etiqueta" ForeColor="Red"></asp:Label>
                            <input  id="Hidden1" name="hdnContinuar" style="width: 80px; height: 10px" type="hidden" />
                        </td>
                    </tr>
                    <tr>
                        <td bgcolor="#c0c0c0" colspan="6">
                        </td>
                    </tr>
                    <tr id="CodigoCliente">
                        <td class="celda-titulo" style="width: 15%; height: 18px; text-align: right">
                            Código Cliente :</td>
                        <td style="width: 15%; height: 18px; text-align: left">
                            <asp:TextBox ID="txt_CodCliente" runat="server" Width="90%"></asp:TextBox>
                        </td>
                        <td style="width: 5%; height: 18px; text-align: center">
                             <asp:Button ID="btn_CargarCliente" runat="server" Text="Cargar" 
                                 onclick="btn_CargarCliente_Click" BackColor="#1F529E" ForeColor="White"></asp:Button>
                        </td>
                        <td style="width: 15%; height: 18px; text-align: left">
                            &nbsp;</td>
                        <td style="width: 5%; height: 18px; text-align: center">
                            &nbsp;</td>
                        <td style="width: 15%; height: 18px; text-align: left">
                            &nbsp;</td>

                    </tr>                    
                    <tr>
                        <td bgcolor="#c0c0c0" colspan="6">
                        </td>
                    </tr>

                    <tr id="Botones">
                        <td colspan="6" style="text-align:right;">
                             &nbsp;</td>
                    </tr>


                </tbody>
            </table>
</asp:Content>