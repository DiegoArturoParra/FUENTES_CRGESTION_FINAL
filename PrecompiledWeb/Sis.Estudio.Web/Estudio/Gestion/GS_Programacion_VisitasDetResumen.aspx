<%@ page title="" language="C#" masterpagefile="~/Master/Popup.master" autoeventwireup="true" inherits="Estudio_Gestion_GS_Programacion_VisitasDetResumen, App_Web_kou4i3xh" stylesheettheme="Standard" %>
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
                            Distrito:</td>
                        <td style="width: 50%; height: 18px; text-align: left">
                            <asp:TextBox ID="txt_Distrito" runat="server" CssClass="CajaTextoDisable" 
                                ForeColor="Black" MaxLength="10" onkeydown="return Control_Locked(event);" 
                                Width="99%" ReadOnly="True"></asp:TextBox>
                        </td>
                        <td style="width: 40%; height: 18px; text-align: left">
                            &nbsp;</td>
                    </tr>
                    <tr>
                        <td class="celda-titulo" style="width: 28%; height: 18px; text-align: right">
                            Total Distrito:</td>
                        <td style="width: 34%; height: 18px; text-align: left">
                            <asp:TextBox ID="txt_TotalDistrito" runat="server" CssClass="CajaTextoDisable" 
                                ForeColor="Black" MaxLength="50" onkeydown="return Control_Locked(event);"  
                                TabIndex="1" Width="30%" ReadOnly="True"></asp:TextBox>
                        </td>
                        <td style="width: 40%; height: 18px; text-align: left">
                            &nbsp;</td>
                    </tr>
                    <tr>
                        <td class="celda-titulo" style="width: 28%; height: 18px; text-align: right">
                            Monto Cuota:
                        </td>
                        <td style="width: 34%; height: 18px; text-align: left">
                            <asp:TextBox ID="txt_MontoCuota" runat="server" CssClass="CajaTextoDisable" 
                                ForeColor="Black" MaxLength="7" onkeydown="return Control_Locked(event);"  
                                TabIndex="3" Width="30%" ReadOnly="True"></asp:TextBox>
                        </td>
                        <td style="width: 40%; height: 18px; text-align: left">
                            &nbsp;</td>
                    </tr>
                    <tr>
                        <td colspan="3" style="text-align: center">
                            &nbsp;<asp:Button ID="btn_SALIR" runat="server" Text="Salir" Width="100px" 
                                OnClick="btn_SALIR_Click" TabIndex="5" />
                            <asp:HiddenField ID="hd_IDMENU" runat="server" />
                        </td>
                    </tr>
                </tbody>
            </table>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>



