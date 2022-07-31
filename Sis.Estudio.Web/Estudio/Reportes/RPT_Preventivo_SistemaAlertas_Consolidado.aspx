<%@ Page Language="C#" MasterPageFile="~/Master/Ceem.master" AutoEventWireup="true" 
    CodeFile="RPT_Preventivo_SistemaAlertas_Consolidado.aspx.cs" Inherits="Estudio_Reportes_RPT_Preventivo_SistemaAlertas_Consolidado" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<%@ Register Assembly="GMDatePicker" Namespace="GrayMatterSoft" TagPrefix="cc2" %>
<%@ Register Assembly="Flan.Controls" Namespace="Flan.Controls" TagPrefix="cc3" %>
<%@ MasterType VirtualPath="~/Master/Ceem.master" %>
<asp:Content ID="Content1" ContentPlaceHolderID="DefaultContent" runat="Server">
    <script type="text/javascript">
    </script>
    <asp:UpdatePanel ID="upGvUsuario" runat="server" UpdateMode="Conditional">
        <ContentTemplate>

            <div class="form-group col-md-2">
            </div>
            <div class="form-group col-md-6">
                <div class="rounded" style="min-height: 80px;">
                    <div class="form-group col-md-4" style ="height:19px;">
                        <label for="inputEmail4">Año:</label>
                    </div>
                    <div class="form-group col-md-8">
                        <asp:DropDownList ID="cmb_Anio" runat="server" TabIndex="6" Width="250px" 
                            AutoPostBack="true" Height="20px" OnSelectedIndexChanged="cmb_Anio_SelectedIndexChanged">
                        </asp:DropDownList>
                    </div>
                    <div class="form-group col-md-4">
                        <label for="inputEmail4">Mes:</label>
                    </div>
                    <div class="form-group col-md-8">
                        <asp:DropDownList ID="cmb_mes" runat="server" TabIndex="6" Width="250px" AutoPostBack="true" Height="20px">
                        </asp:DropDownList>
                    </div>
                </div>
            </div>
            <div class="form-group col-md-2">
                <div class="rounded" style="min-height: 80px;">
                    <div class="form-group col-md-12">
                        <asp:Button ID="btn_Excel" runat="server" class="btn btn-primary" OnClick="btn_Excel_Click" Text="Excel" Width="100%" />
                    </div>
                    <div class="form-group col-md-12">
                        <asp:Button ID="btn_Imprimir" runat="server" class="btn btn-primary" OnClick="btn_Imprimir_Click" Text="Imprimir" Width="100%"/>
                        <asp:HiddenField ID="HD_Continuar" runat="server" />
                        <input id="hdnContinuar" name="hdnContinuar" style="width: 80px; height: 10px" type="hidden" />
                    </div>
                </div>
            </div>
            <div class="form-group col-md-2">
            </div>
            
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>