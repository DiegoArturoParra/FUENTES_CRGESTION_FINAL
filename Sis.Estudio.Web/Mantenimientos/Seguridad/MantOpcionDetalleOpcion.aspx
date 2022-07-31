<%@ Page Title="" Language="C#" MasterPageFile="~/Master/Popup.master" AutoEventWireup="true" CodeFile="MantOpcionDetalleOpcion.aspx.cs" Inherits="Mantenimientos_Seguridad_MantOpcionDetalleOpcion" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<%@ MasterType VirtualPath="~/Master/Popup.master" %>
<asp:Content ID="Content1" ContentPlaceHolderID="DefaultContent" runat="Server">

    <script type="text/javascript">

        function Valida_Entero(Cadena) {
            var1 = parseInt(Cadena, 10)
            //valida que sean numeros   
            if (isNaN(var1)) {
                return false;
            }
            return true;
        }

        function Valida_Fecha(Cadena) {
            var Fecha = new String(Cadena);   // Crea un string   
            var RealFecha = new Date();   // Para sacar la fecha de hoy   
            // Cadena Año   
            var Ano = new String(Fecha.substring(Fecha.lastIndexOf("/") + 1, Fecha.length));
            // Cadena Mes
            var Mes = new String(Fecha.substring(Fecha.indexOf("/") + 1, Fecha.lastIndexOf("/")));
            // Cadena Día   
            var Dia = new String(Fecha.substring(0, Fecha.indexOf("/")));

            // Valido el año   
            if (isNaN(Ano) || Ano.length < 4 || parseFloat(Ano) < 1900) {
                //alert('Año inválido');
                return false;
            }
            // Valido el Mes   
            if (isNaN(Mes) || parseFloat(Mes) < 1 || parseFloat(Mes) > 12) {
                //alert('Mes inválido');
                return false;
            }
            // Valido el Dia   
            if (isNaN(Dia) || parseInt(Dia, 10) < 1 || parseInt(Dia, 10) > 31) {
                //alert('Día inválido');
                return false;
            }
            if (Mes == 4 || Mes == 6 || Mes == 9 || Mes == 11 || Mes == 2) {
                if (Mes == 2 && Dia > 28 || Dia > 30) {
                    alert('Día inválido');
                    return false;
                }
            }

            //para que envie los datos, quitar las  2 lineas siguientes   
            //alert("Fecha correcta.")   
            return true;
        }

        function Valida_Texto(texto) {
            if (texto == '') {
                return false;
            }
            else {
                return true;
            }
        }

        function Valida_Email(valor) {
            re = /^[_a-z0-9-]+(.[_a-z0-9-]+)*@[a-z0-9-]+(.[a-z0-9-]+)*(.[a-z]{2,3})$/
            if (!re.exec(valor)) {
                return false;
            } else {
                return true;
            }
        }

        function FocoOn(control) {
            control.className = 'CajaTextoFoco';
        }

        function FocoOff(control) {
            control.className = 'CajaTexto';
        }

        //****************************************************************************************
        //* Nomre       :SiguienteObjeto() 
        //* DescripcioN :				NSE AGOSTO - 2009
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
            if (event.keyCode == 13) {
                event.keyCode = 9;
            } else if (event.keyCode == 9) {
                event.keyCode = 9;
            } else {
                return false;
            }
        }

        function Control_Caracter(evt) {
            if (event.keyCode == 13) event.keyCode = 9;
            var charCode = evt.keyCode

            if (charCode == 219)
                return false
            else
                return true
        }



        function Res_Control() {
            if (Valida_Texto($get('<%= hd_ID.ClientID %>').value) == true) {
                $get('<%= hd_ID.ClientID %>').className = 'CajaTexto';
            }

            if (Valida_Texto($get('<%= txt_NOMBRE.ClientID %>').value) == true) {
                $get('<%= txt_NOMBRE.ClientID %>').className = 'CajaTexto';
            }

            if (Valida_Texto($get('<%= txt_DESCRIPCION.ClientID %>').value) == true) {
                $get('<%= txt_DESCRIPCION.ClientID %>').className = 'CajaTexto';
            }
        }

        function Validacion() {


            $get('<%= txt_NOMBRE.ClientID %>').className = 'selecterror';
            $get('<%= txt_DESCRIPCION.ClientID %>').className = 'selecterror';

            Res_Control();

            if (Valida_Texto($get('<%= txt_NOMBRE.ClientID %>').value) == false) {
                alert('No se ha definido NOMBRE.');
                $get('<%= txt_NOMBRE.ClientID %>').focus();
                return;
            }

            if (Valida_Texto($get('<%= txt_DESCRIPCION.ClientID %>').value) == false) {
                alert('No se ha definido DESCRIPCION.');
                $get('<%= txt_DESCRIPCION.ClientID %>').focus();
                return;
            }

            document.getElementById('hdnContinuar').value = confirm('Los datos se guardarán, ¿Desea continuar?');
        }

       
        
    </script>

    <asp:UpdatePanel ID="upControles" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
            <!--***************************************************************************************************************-->
            <!--*** CABECERA -->
            <!--***************************************************************************************************************-->
            <table width="100%" border="0" cellspacing="0">
                <tbody>
                    <tr>
                        <td colspan="3" style="height: 1px; text-align: center" class="FondoBlanco">
                            <input id="hdnContinuar" name="hdnContinuar" style="width: 80px; height: 1px" type="hidden" />
                        </td>
                    </tr>
                    <tr>
                        <td class="celda-titulo" style="width: 28%; height: 18px; text-align: right">
                            Codigo </td>
                        <td style="width: 50%; height: 18px; text-align: left">
                            <asp:TextBox ID="txt_ID" runat="server" CssClass="CajaTextoDisable" 
                                ForeColor="Black" MaxLength="10" onkeydown="return Control_Locked(event);" 
                                Width="30px"></asp:TextBox>
                        </td>
                        <td style="width: 40%; height: 18px; text-align: left">
                            &nbsp;</td>
                    </tr>
                    <tr>
                        <td class="celda-titulo" style="width: 28%; height: 18px; text-align: right">
                            Modulo</td>
                        <td style="width: 50%; height: 18px; text-align: left">
                            <asp:TextBox ID="txt_DESMODULO" runat="server" CssClass="CajaTextoDisable" 
                                ForeColor="Black" MaxLength="10" onkeydown="return Control_Locked(event);" 
                                Width="99%"></asp:TextBox>
                        </td>
                        <td style="width: 40%; height: 18px; text-align: left">
                            <asp:HiddenField ID="hd_IDMODULO" runat="server" />
                        </td>
                    </tr>
                    <tr>
                        <td class="celda-titulo" style="width: 28%; height: 18px; text-align: right">
                            Nombre Opción</td>
                        <td style="width: 34%; height: 18px; text-align: left">
                            <asp:TextBox ID="txt_NOMBRE" runat="server" CssClass="CajaTexto" 
                                ForeColor="Black" MaxLength="50" onkeydown="return SiguienteObjeto()" 
                                TabIndex="1" Width="99%"></asp:TextBox>
                        </td>
                        <td style="width: 40%; height: 18px; text-align: left">
                            <asp:HiddenField ID="hd_ID" runat="server" />
                        </td>
                    </tr>
                    <tr>
                        <td class="celda-titulo" style="width: 28%; height: 18px; text-align: right">
                            URL </td>
                        <td style="width: 34%; height: 18px; text-align: left">
                            <asp:TextBox ID="txt_DESCRIPCION" runat="server" CssClass="CajaTexto" 
                                ForeColor="Black" Height="26px" MaxLength="400" TabIndex="2" Width="99%"></asp:TextBox>
                        </td>
                        <td style="width: 40%; height: 18px; text-align: left">
                            <asp:HiddenField ID="hd_REGISTRO" runat="server" />
                        </td>
                    </tr>
                    <tr>
                        <td class="celda-titulo" style="width: 28%; height: 18px; text-align: right">
                            &nbsp;Top Listado Inicial&nbsp;
                        </td>
                        <td style="width: 34%; height: 18px; text-align: left">
                            <asp:TextBox ID="txt_TOPLISTADO" runat="server" CssClass="CajaTexto" 
                                ForeColor="Black" MaxLength="7" onkeydown="return Control_Numero(event)"  
                                TabIndex="3" Width="20%"></asp:TextBox>
                        </td>
                        <td style="width: 40%; height: 18px; text-align: left">
                            &nbsp;</td>
                    </tr>
                    <tr>
                        <td colspan="3" style="text-align: center">
                            <asp:Button ID="btn_GRABAR" runat="server" Text="Grabar" Width="100px" OnClick="btn_GRABAR_Click"
                                OnClientClick="Validacion()" TabIndex="4"  BackColor="#000080" ForeColor="White"/>
                            &nbsp;<asp:Button ID="btn_SALIR" runat="server" Text="Salir" Width="100px" 
                                OnClick="btn_SALIR_Click" TabIndex="5"  BackColor="#000080" ForeColor="White"/>
                            <asp:HiddenField ID="hd_IDMENU" runat="server" />
                        </td>
                    </tr>
                </tbody>
            </table>
            <!--***************************************************************************************************************-->
            <!--*** PANELES -->
            <!--***************************************************************************************************************-->
            <!--***************************************************************************************************************-->
            <!--*** PIE -->
            <!--***************************************************************************************************************-->
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>

