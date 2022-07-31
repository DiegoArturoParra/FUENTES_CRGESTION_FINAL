<%@ page language="C#" masterpagefile="~/Master/Ceem.master" autoeventwireup="true" inherits="Estudio_Reportes_RPT_Productividad_CRProductividad, App_Web_ttsq0jlp" stylesheettheme="Standard" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<%@ Register Assembly="GMDatePicker" Namespace="GrayMatterSoft" TagPrefix="cc2" %>
<%@ Register Assembly="Flan.Controls" Namespace="Flan.Controls" TagPrefix="cc3" %>
<%@ MasterType VirtualPath="~/Master/Ceem.master" %>
<asp:Content ID="Content1" ContentPlaceHolderID="DefaultContent" runat="Server">
    <script type="text/javascript">
</script>
    <script type="text/javascript" >
        Sys.WebForms.PageRequestManager.getInstance().add_endRequest(EndRequestHandler);
        function EndRequestHandler(sender, args) {
            if (args.get_error() != undefined) {
                args.set_errorHandled(true);
            }
        }
</script>
    <%--<style type="text/css">
        #overlay {
            position: fixed;
            z-index: 99;
            top: 0px;
            left: 0px;
            background-color: #f8f8f8;
            width: 100%;
            height: 100%;
            filter: Alpha(Opacity=90);
            opacity: 0.9;
            -moz-opacity: 0.9;
        }            
        #theprogress {
            background-color: #fff;
            border:1px solid #ccc;
            padding:10px;
            width: 300px;
            height: 30px;
            line-height:30px;
            text-align: center;
            filter: Alpha(Opacity=100);
            opacity: 1;
            -moz-opacity: 1;
        }
        #modalprogress {
            position: absolute;
            top: 40%;
            left: 50%;
            margin: -11px 0 0 -150px;
            color: #990000;
            font-weight:bold;
            font-size:14px;
        }

    </style>--%>
    <asp:UpdatePanel ID="upGvUsuario" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
            <div class="form-group col-md-2">
            </div>
            <div class="form-group col-md-6">
                <div class="rounded" style="min-height: 100px;">
                    <div class="form-row col-md-5">
                        <label for="inputEmail4">Seleccione Zona:</label>
                    </div>
                    <div class="form-row col-md-7">
                        <asp:DropDownList ID="cmb_JerarquiaB" runat="server" TabIndex="6" Width="80%" 
                                        AutoPostBack="True" 
                                        onselectedindexchanged="cmb_JerarquiaB_SelectedIndexChanged">
                        </asp:DropDownList>
                    </div>
                    <div class="form-row col-md-5">
                        <label for="inputEmail4">Seleccione Agencia:</label>
                    </div>
                    <div class="form-row col-md-7">
                        <asp:DropDownList ID="cmb_JerarquiaC" runat="server" AutoPostBack="True" TabIndex="6" Width="80%" 
                            onselectedindexchanged="cmb_JerarquiaC_SelectedIndexChanged">
                        </asp:DropDownList>
                    </div>
                    <div class="form-row col-md-5">
                        <label for="inputEmail4">Seleccione Asesor:</label>
                    </div>
                    <div class="form-row col-md-7">
                        <asp:DropDownList ID="cmb_JerarquiaD" runat="server" AutoPostBack="True" TabIndex="6" Width="80%" 
                            onselectedindexchanged="cmb_JerarquiaD_SelectedIndexChanged">
                        </asp:DropDownList>
                    </div><div class="form-row col-md-5" style="height: 20px;">
                        <label for="inputEmail4">Fecha:</label>
                    </div>
                    <div class="form-row col-md-7">
                        <asp:TextBox ID="txt_FECHAVISITA" runat="server" Enabled="false" Height="18px" 
                            MaxLength="10" TabIndex="5" Width="70%" AutoPostBack="True"></asp:TextBox>
                        <cc1:CalendarExtender ID="CalendarExtender2" runat="server" 
                            PopupButtonID="imgCal2" TargetControlID="txt_FECHAVISITA" />
                        <asp:ImageButton ID="imgCal2" runat="Server" AlternateText="Mostrar calendario" ImageUrl="~/imagenes/Calendar.png" />
                    </div>
                </div>
            </div>
            <div class="form-group col-md-2">
                <div class="rounded" style="min-height: 90px;">
                    <table style="margin:auto; text-align:center; height:70px; width:100%">
                        <tr>
                            <td>
                                <asp:Button ID="btn_Excel" runat="server" class="btn btn-primary" OnClick="btn_Excel_Click" Text="Excel" Width="100%" />
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Button ID="btn_Imprimir" runat="server" class="btn btn-primary" OnClick="btn_Imprimir_Click" Text="Imprimir" Width="100%" />
                                
                                <asp:HiddenField ID="HD_Continuar" runat="server" />

                                <input id="hdnContinuar" name="hdnContinuar" style="width: 80px; height: 10px" type="hidden" />
                            </td>
                        </tr>
                    </table>
                </div>
            </div>
            <div class="form-group col-md-2">
            </div>
            
            
        </ContentTemplate>
    </asp:UpdatePanel>
    
    <%--<asp:UpdateProgress ID="prgLoadingStatus" runat="server" AssociatedUpdatePanelID="upGvUsuario">
        <ProgressTemplate>
            <div id="overlay">
                <div id="modalprogress">
                    <div id="theprogress">
                        <img alt="indicator" src="../../imagenes/wait.gif" />
                    </div>
                </div>
            </div>
        </ProgressTemplate>
    </asp:UpdateProgress>  --%>
</asp:Content>