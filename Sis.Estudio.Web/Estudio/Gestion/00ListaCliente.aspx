<%@ Page Title="" Language="C#" MasterPageFile="~/Master/Ceem.master" AutoEventWireup="true" CodeFile="00ListaCliente.aspx.cs" Inherits="Estudio_Gestion_00ListaCliente" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<%@ MasterType VirtualPath="~/Master/Ceem.master" %>
<asp:Content ID="Content1" ContentPlaceHolderID="DefaultContent" Runat="Server">
<div class="form-row" >
    <div class="form-group col-md-3">
    </div>

    
    <div class="form-group col-md-6">
        <div class="rounded" style="min-height: 50px;">
            <div class="form-row col-md-3" style="height: 20px;">
                <label for="inputEmail4">DNI Cliente :</label>
            </div>
            <div class="form-row col-md-6">
                <asp:TextBox ID="txt_CodCliente" runat="server" Width="100%"></asp:TextBox>
                <asp:RegularExpressionValidator ID="valRegExEmail" runat="server" ControlToValidate="txt_CodCliente"
                    ErrorMessage="Formato de DNI incorrecto" ValidationExpression="^\d{8}$">
                </asp:RegularExpressionValidator>
            </div>
            <div class="form-row col-md-3">
                <asp:Button ID="btn_CargarCliente" runat="server" Text="Cargar" class="btn btn-primary"
                    OnClick="btn_CargarCliente_Click" Width="100%"></asp:Button>
                <asp:Label ID="lblMensaje" runat="server" CssClass="Etiqueta" ForeColor="Red"></asp:Label>
                <input id="Hidden1" name="hdnContinuar" style="width: 80px; height: 10px" type="hidden" />
            </div>
        </div>
    </div>

    <div class="form-group col-md-3">
    </div>
</div>
            

            <%--<script type="text/javascript">
                function validarDni() {
                    var txtDni = $('#<%=txt_CodCliente.ClientID%>');
                    dni = txtDni.val();
                    var expRegDni
                    expRegDni = /^\d{8}$/;
                    if(!expRegDni.test(dni)){
                        alert("DNI incorrecto, formato no válido")
                    }
                }
            </script>--%>
</asp:Content>