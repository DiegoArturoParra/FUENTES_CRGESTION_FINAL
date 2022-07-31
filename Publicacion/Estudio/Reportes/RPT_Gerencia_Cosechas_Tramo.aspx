<%@ page language="C#" masterpagefile="~/Master/Ceem.master" autoeventwireup="true" inherits="Estudio_Reportes_RPT_Gerencia_Cosechas_Tramo, App_Web_ttsq0jlp" stylesheettheme="Standard" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<%@ Register Assembly="GMDatePicker" Namespace="GrayMatterSoft" TagPrefix="cc2" %>
<%@ Register Assembly="Flan.Controls" Namespace="Flan.Controls" TagPrefix="cc3" %>
<%@ MasterType VirtualPath="~/Master/Ceem.master" %>

<asp:Content ID="Content1" ContentPlaceHolderID="DefaultContent" runat="Server">
    <script type="text/javascript">
    </script>
    <asp:UpdatePanel ID="upGvUsuario" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
            
            <div class="form-group col-md-10">
                <div class="rounded" style="min-height: 100px;">
                    <div class="form-group col-md-6">
                        <div class="form-row col-md-4" style ="height:19px;">
                            <label for="inputEmail4">Año inicial:</label>
                        </div>
                        <div class="form-row col-md-8">
                            <asp:DropDownList ID="cmb_Anio" runat="server" TabIndex="6" Width="200px" 
                                AutoPostBack="true" Height="20px" OnSelectedIndexChanged="cmb_Anio_SelectedIndexChanged">
                            </asp:DropDownList>
                        </div>
                        <div class="form-row col-md-4" style ="height:19px;">
                            <label for="inputEmail4">Año Fin:</label>
                        </div>
                        <div class="form-row col-md-8">
                            <asp:DropDownList ID="cmb_Anio_Fin" runat="server" TabIndex="6" Width="200px" 
                                AutoPostBack="true" Height="20px" OnSelectedIndexChanged="cmb_Anio_SelectedIndexChanged">
                            </asp:DropDownList>
                        </div>

                        <div class="form-row col-md-4" style="height:19px;">
                            <label for="inputEmail4">Mes inicial:</label>
                        </div>
                        <div class="form-row col-md-8">
                            <asp:DropDownList ID="cmb_mes_Inicial" runat="server" TabIndex="6" Width="200px" 
                                AutoPostBack="true" Height="20px" OnSelectedIndexChanged="cmb_mes_Inicial_SelectedIndexChanged">
                            </asp:DropDownList>
                        </div>
                        <div class="form-row col-md-4">
                            <label for="inputEmail4">Mes final:</label>
                        </div>
                        <div class="form-row col-md-8">
                            <asp:DropDownList ID="cmb_mes_Final" runat="server" TabIndex="6" Width="200px" 
                                AutoPostBack="true" Height="20px">
                            </asp:DropDownList>
                        </div>
                    </div>
            
                    <div class="form-group col-md-6">
                        <div class="form-row col-md-1">
                        </div>
                        <div class="form-row col-md-3" style ="height:19px;">
                            <label for="inputEmail4">Tramo:</label>
                        </div>
                        <div class="form-row col-md-8">
                            <asp:DropDownList ID="cmb_tramo" runat="server" TabIndex="6" Width="200px" 
                                AutoPostBack="true" Height="20px" OnSelectedIndexChanged="cmb_Anio_SelectedIndexChanged" Enabled="False">
                            </asp:DropDownList>
                        </div>
                        <div class="form-row col-md-1">
                        </div>
                        <div class="form-row col-md-3" style="height:19px;">
                            <label for="inputEmail4">Zona:</label>
                        </div>
                        <div class="form-row col-md-8">
                            <asp:DropDownList ID="cmb_zona" runat="server" TabIndex="6" Width="200px" 
                                AutoPostBack="true" Height="20px" Enabled="False">
                            </asp:DropDownList>
                        </div>
                        <div class="form-row col-md-1">
                        </div>
                        <div class="form-row col-md-3">
                            <label for="inputEmail4">Producto:</label>
                        </div>
                        <div class="form-row col-md-8">
                            <asp:DropDownList ID="cmb_producto" runat="server" TabIndex="6" Width="200px" 
                                AutoPostBack="true" Height="20px" Enabled="False">
                            </asp:DropDownList>
                        </div>
                    </div>
                </div>
            </div>
            <div class="form-group col-md-2">
                <div class="rounded" style="min-height: 100px;">
                    <div class="form-group col-md-12">
                        <asp:Button ID="btn_Excel" runat="server" class="btn btn-primary" OnClick="btn_Excel_Click" Text="Excel" Width="90px" />
                    </div>
                    <div class="form-group col-md-12">
                        <asp:Button ID="btn_Imprimir" runat="server" class="btn btn-primary" OnClick="btn_Imprimir_Click" Text="Imprimir" Width="90px" />
                        <asp:HiddenField ID="HD_Continuar" runat="server" />
                        <input id="hdnContinuar" name="hdnContinuar" style="width: 80px; height: 10px" type="hidden" />
                    </div>
                </div>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
