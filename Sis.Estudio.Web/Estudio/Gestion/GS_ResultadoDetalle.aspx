<%@ Page Title="" Language="C#" MasterPageFile="~/Master/Ceem.master" AutoEventWireup="true" CodeFile="GS_ResultadoDetalle.aspx.cs" Inherits="Estudio_Gestion_GS_ResultadoDetalle" %>

<%@ Register Assembly="RJS.Web.WebControl.PopCalendar" Namespace="RJS.Web.WebControl"TagPrefix="rjs" %>
<%@ MasterType VirtualPath="~/Master/Ceem.master"  %>
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
                                                                    onclick="btnAgregar_Click" />                                                                
                                                            </td>

                                                            <td width="1px" >
                                                                <asp:ImageButton ID="btnModificar" runat="server" 
                                                                    ImageUrl="~/Imagenes/modificar_disabled.png" 
                                                                    onclick="btnModificar_Click" />                                                                
                                                            </td>

                                                            <td width="1" >
                                                                <asp:ImageButton ID="btnConsultar" runat="server" 
                                                                    ImageUrl="~/Imagenes/consultar_disabled.png" 
                                                                    onclick="btnConsultar_Click" />                                                                
                                                            </td>

                                                            <td width="1px" >
                                                                <asp:ImageButton ID="btnEliminar" runat="server" 
                                                                    ImageUrl="~/Imagenes/eliminar_disabled.png" 
                                                                    onclick="btnEliminar_Click" onclientclick="ValidaEliminacion()"  />                                                                
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
                                            </td>
                                            <td class="CeldaCabeceraControl" style="text-align: left; height: 7px;" 
                                                valign="top">
                                                <asp:TextBox ID="txt_codigo" runat="server" style="background-color:#cccccc"
                                                    MaxLength="10" onkeydown="return Control_Locked(event);" 
                                                    Width="100%"></asp:TextBox>
                                            </td>
                                        </tr>
                                        <tr >
                                            <td class="labeltextonegro" style="width: 23%; text-align: left;" 
                                                valign="top">
                                                <asp:Label ID="lbl_FECHAREGISTRA17" runat="server" CssClass="Item" 
                                                    Text="Descripción:"></asp:Label>
                                            </td>
                                            <td class="CeldaCabeceraControl" style="text-align: left;" 
                                                valign="top">
                                                <asp:TextBox ID="txt_descripcion" runat="server" CssClass="CajaTexto" 
                                                    ForeColor="Black" MaxLength="50" onkeydown="return SiguienteObjeto()" 
                                                    TabIndex="1" Width="100%"></asp:TextBox>
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
                                                <asp:Label ID="lbl_FECHAREGISTRA20" runat="server" CssClass="labeltextoblanco" 
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


