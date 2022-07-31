<%@ page title="" language="C#" masterpagefile="~/Master/Ceem.master" autoeventwireup="true" inherits="Estudio_Reportes_ContencionGestion, App_Web_r2n2tuxx" stylesheettheme="Standard" %>
<%@ Register Assembly="CrystalDecisions.Web, Version=13.0.2000.0, Culture=neutral, PublicKeyToken=692fbea5521e1304"
    Namespace="CrystalDecisions.Web" TagPrefix="CR" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<%@ MasterType VirtualPath="~/Master/Ceem.master" %>    
<asp:Content ID="Content1" ContentPlaceHolderID="DefaultContent" Runat="Server">

    <script src="../../javascript/jquery-2.1.1.min.js" type="text/javascript"></script>
    <script src="../../javascript/jsUpdateProgress.js" type="text/javascript"></script>
    <script type="text/javascript">
        var ModalProgress = '<%= ModalProgress.ClientID %>';


        function Imprimir() {
            var strVentana;
            var strRuta;
            var dato;
            var strParametros;

            strVentana = "resizable=yes,width=800,height=800,scrollbars=yes";
            strRuta = "ContencionTramoC.aspx";
            strParametros = "?tramo=3&anio=2012";
            miPopup = window.open(strRuta + strParametros, "Reporte", strVentana);

            miPopup = null;
        }

    </script>
    <script src="../../javascript/jsUpdateProgress.js" type="text/javascript"></script>
    
    <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
        <contenttemplate>

        <br>        
        <br>
        
    <table width="1000px">
        <tr>
            <td style="width: 1000px;" align="left">
                <table cellpadding="1" cellspacing="0" border="0" style="width: 600px">                            
                    <tr id="Tramo">
                        <td class="celda-titulo" style="width: 200px; text-align: right;">
                            Tipo de Tramo&nbsp;
                        </td>
                        <td style="text-align: left; width: 400px;">
                            <asp:DropDownList ID="cmb_Tramo" runat="server" AutoPostBack="True" 
                                TabIndex="1" Width="98%" 
                                onselectedindexchanged="cmb_Tramo_SelectedIndexChanged1">
                            </asp:DropDownList>
                        </td>
                        <td></td>
                    </tr>

                    <tr id="Agencia">
                        <td class="celda-titulo" style="width: 200px; text-align: right;">
                            Agencia&nbsp;
                        </td>
                        <td style="text-align: left; width: 400px;">
                            <asp:DropDownList ID="cmb_Agencia" runat="server" AutoPostBack="True" 
                                TabIndex="1" Width="98%" 
                                onselectedindexchanged="cmb_Agencia_SelectedIndexChanged1">
                            </asp:DropDownList>
                        </td>
                        <td></td>
                    </tr>

                    <tr id="Anio">
                        <td class="celda-titulo" style="width: 200px; text-align: right;">
                            Año&nbsp;
                        </td>
                        <td style="text-align: left; width: 400px;">
                            <asp:DropDownList ID="cmb_anio" runat="server" AutoPostBack="True" TabIndex="1" 
                                Width="98%" onselectedindexchanged="cmb_anio_SelectedIndexChanged1">
                            </asp:DropDownList>
                        </td>
                        <td>                  
                        </td>
                    </tr>                                                                                   

                    <tr id="TipoGestion">
                        <td class="celda-titulo" style="width: 200px; text-align: right;">
                            Tipo Gestion&nbsp;
                        </td>
                        <td style="text-align: left; width: 400px;">
                            <asp:DropDownList ID="cmb_TipoGestion" runat="server" AutoPostBack="True" 
                                TabIndex="1" Width="98%" 
                                onselectedindexchanged="cmb_TipoGestion_SelectedIndexChanged">
                            </asp:DropDownList>
                        </td>
                        <td>
                        <asp:Button ID="btn_Consultar" runat="server" Text="Consultar" Width="120px" 
                    OnClick="btn_Consultar_Click" TabIndex="4" />
                        </td>
                    </tr>

                </table>
            </td>
        </tr>
    </table> 
        </contenttemplate>        
        <Triggers>
            <asp:PostBackTrigger ControlID="btn_Consultar" />
        </Triggers>

    </asp:UpdatePanel>
    <asp:Panel ID="panelUpdateProgress" runat="server" CssClass="updateProgress">
        <asp:UpdateProgress ID="UpdateProg1" DisplayAfter="0" runat="server">
            <progresstemplate>
                <div style="position: relative; top: 50%; text-align: center;">
                    <asp:Image runat="server" ID="Progres" ImageUrl="~/imagenes/loading.gif" Style="vertical-align: middle"
                        alt="Procesando&#8230;" />
                    <asp:Label runat="server" ID="lblprogres" ForeColor="White" Text="Procesando&#8230;"></asp:Label>
                </div>
            </progresstemplate>
        </asp:UpdateProgress>
    </asp:Panel>
    <cc1:ModalPopupExtender ID="ModalProgress" runat="server" TargetControlID="panelUpdateProgress"
        BackgroundCssClass="modalBackground" PopupControlID="panelUpdateProgress">
    </cc1:ModalPopupExtender>



</asp:Content>
