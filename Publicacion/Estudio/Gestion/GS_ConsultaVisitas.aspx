<%@ page title="" language="C#" masterpagefile="~/Master/Ceem.master" autoeventwireup="true" inherits="Estudio_Gestion_GS_ConsultaVisitas, App_Web_m4xi2a1f" stylesheettheme="Standard" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<%@ Register Assembly="GMaps" Namespace="Subgurim.Controles" TagPrefix="cc1" %>
<%@ Register Assembly="GMDatePicker" Namespace="GrayMatterSoft" TagPrefix="cc2" %>
<%@ MasterType VirtualPath="~/Master/Ceem.master" %>

<asp:Content ID="Content1" ContentPlaceHolderID="DefaultContent" Runat="Server">
    <div class="form-row" >
        <div class="form-group col-md-12">
            <div class="form-row col-md-3">
                <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Always">
                    <ContentTemplate>
                        <asp:Panel ID="Panel1" runat="server" class="rounded">
                            
                            <label for="inputEmail4">Asesor:</label>
                            <asp:DropDownList ID="cmb_Asesores" runat="server" TabIndex="6" Width="100%" AutoPostBack="true">
                            </asp:DropDownList>
                            <br /><br />
                            <label for="inputEmail4">Fecha Registro de Action Plan:</label>
                            <br />
                            Del
                            <asp:TextBox ID="txt_FECHAINI" runat="server" Enabled="false" Height="18px" MaxLength="10" TabIndex="5" Width="30%"></asp:TextBox>
                            <ajaxToolkit:CalendarExtender ID="CalendarExtender1" runat="server" PopupButtonID="imgCal1" TargetControlID="txt_FECHAINI" />
                            <asp:ImageButton ID="imgCal1" runat="Server" AlternateText="Mostrar calendario" ImageUrl="~/imagenes/Calendar.png" />
                            &nbsp;al
                            <asp:TextBox ID="txt_FECHAFIN" runat="server" Enabled="false" Height="18px" MaxLength="10" TabIndex="5" Width="30%"></asp:TextBox>
                            <ajaxToolkit:CalendarExtender ID="CalendarExtender2" runat="server" PopupButtonID="imgCal2" TargetControlID="txt_FECHAFIN" />
                            <asp:ImageButton ID="imgCal2" runat="Server" AlternateText="Mostrar calendario" ImageUrl="~/imagenes/Calendar.png" />
                            <br /><br />
                            <div class="text-center">
                                <asp:Button ID="btnBuscar" runat="server" class="btn btn-primary" Text="Buscar" Width="50%" OnClick="btnBuscar_Click" />
                            </div>
                            <br /><br />
                            Clientes Visitados:&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                <asp:TextBox ID="txt_CONTADOR_CLIENTES" runat="server" Enabled="false" Height="18px" MaxLength="10" TabIndex="5" Width="50px"></asp:TextBox>
                            <br /><br />
                            Total de Visitas Realizadas:&nbsp;&nbsp;&nbsp;
                                <asp:TextBox ID="txt_CONTADOR" runat="server" Enabled="false" Height="18px" MaxLength="10" TabIndex="5" Width="50px"></asp:TextBox>
                            <br /><br />
                        </asp:Panel>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </div>
            <div class="form-group col-md-9">
                <div style="width: 100%; height: 600px;">
                    <cc1:GMap ID="GMap1" runat="server" Key="AIzaSyDlQZ0qAnONpjeQyuY6aJ5bVkE5JnFFZOE" style="width: 100%; height: 100%;" Height="100%" Width="100%" BorderColor="Black" />
                </div>
            </div>
        </div>
    </div>
</asp:Content>