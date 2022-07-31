<%@ page title="" language="C#" masterpagefile="~/Master/Ficha.master" autoeventwireup="true" inherits="Estudio_Gestion_Prueba, App_Web_0nt2mo3d" stylesheettheme="Standard" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<%@ MasterType VirtualPath="~/Master/Ficha.Master" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server" >
    <script src="../../javascript/jquery-2.1.1.min.js" type="text/javascript"></script>
    <script src="../../javascript/jsUpdateProgress.js" type="text/javascript"></script>
    <script type="text/javascript">

        function muestra() {
            var body = document.body,
            html = document.documentElement;
            var exito = Math.max(body.scrollHeight, body.offsetHeight,
                       html.clientHeight, html.scrollHeight, html.offsetHeight);


                       

        var _docHeight = (document.height !== undefined)? document.height : document.body.offsetHeight;



        alert(_docHeight);
            alert(body.scrollHeight);
            alert(body.offsetHeight);
            alert(html.clientHeight);
            alert(html.scrollHeight);
            alert(html.offsetHeight);

        }


        var ModalProgress = '<%= ModalProgress.ClientID %>';
    </script>
    <script src="../../javascript/jsUpdateProgress.js" type="text/javascript"></script>
    <input id="hdnContinuar" name="hdnContinuar" style="width: 80px; height: 10px" type="hidden" />
    <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
        <contenttemplate>



        <input type="button" value="hOLA" onclick="muestra();" />

            <asp:Button ID="btn_Retornar" runat="server" onclick="btn_Retornar_Click" 
                Text="Retornar" Width="100px"  />


            <asp:Button ID="btn_Otro" runat="server"
                Text="Otro" Width="100px" onclick="btn_Otro_Click" 
                  />
                                

            <asp:Panel  runat="server" ID="pnl_prueba" Height="50px"></asp:Panel>

        </contenttemplate>
    </asp:UpdatePanel>
    <asp:Panel ID="panelUpdateProgress" runat="server" CssClass="updateProgress">
        <asp:UpdateProgress ID="UpdateProg1" DisplayAfter="0" runat="server">
            <progresstemplate>
                <div style="position: relative; top: 50%; text-align: center;">
                    <asp:Image runat="server" ID="Progres" ImageUrl="~/imagenes/loading.gif" Style="vertical-align: middle"
                        alt="Procesando…" />
                    <asp:Label runat="server" ID="lblprogres" ForeColor="White" Text="Procesando…"></asp:Label>
                </div>
            </progresstemplate>
        </asp:UpdateProgress>
    </asp:Panel>
    <cc1:ModalPopupExtender ID="ModalProgress" runat="server" TargetControlID="panelUpdateProgress"
        BackgroundCssClass="modalBackground" PopupControlID="panelUpdateProgress">
    </cc1:ModalPopupExtender>
</asp:Content>
