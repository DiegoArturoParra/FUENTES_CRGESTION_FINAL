<%@ page title="" language="C#" masterpagefile="~/Master/Ficha.master" autoeventwireup="true" inherits="Estudio_Gestion_GS_Gestion_CobranzaFichas, App_Web_hhkm3gt1" stylesheettheme="Standard" %>
    <%@ MasterType VirtualPath="~/Master/Ficha.Master" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <link href="../../Estilo/github.css" rel="stylesheet" type="text/css" />
    <link href="../../Estilo/demo.css" rel="stylesheet" type="text/css" />


    <script src="../../javascript/jquery-2.1.1.min.js" type="text/javascript"></script>
    <script src="../../javascript/highlight.pack.js" type="text/javascript"></script>
    <script src="../../javascript/jquery.collapsible.js" type="text/javascript"></script>


    <%		               
        EComponente();            
    %>

    <script type="text/javascript">
        $(document).ready(function () {

            //syntax highlighter

            //        hljs.tabReplace = '    ';
            //        hljs.initHighlightingOnLoad();

            $.fn.slideFadeToggle = function (speed, easing, callback) {
                return this.animate({ opacity: 'toggle', height: 'toggle' }, speed, easing, callback);
            };

            //collapsible management


            $('.collapsible').collapsible({
                speed: 'slow',
                animateOpen: function (elem, opts) { //replace the standard slideUp with custom function
                    elem.next().slideFadeToggle(opts.speed);
                },
                animateClose: function (elem, opts) { //replace the standard slideDown with custom function
                    elem.next().slideFadeToggle(opts.speed);

                },
                loadOpen: function (elem) { //replace the standard open state with custom function
                    elem.next().show();

                },
                loadClose: function (elem, opts) { //replace the close state with custom function
                    elem.next().hide();
                }
            });

            $('.page_collapsible').collapsible({
                speed: 'slow',
                animateOpen: function (elem, opts) { //replace the standard slideUp with custom function                    
                    elem.next().slideFadeToggle(opts.speed);
                },
                animateClose: function (elem, opts) { //replace the standard slideDown with custom function                                        
                    elem.next().slideFadeToggle(opts.speed);
                },
                loadOpen: function (elem) { //replace the standard open state with custom function
                    elem.next().show();
                },
                loadClose: function (elem, opts) { //replace the close state with custom function
                    elem.next().hide();
                }
            });



            //assign open/close all to functions
            function openAll() {
                $('.page_collapsible').collapsible('openAll');
            }
            function closeAll() {
                $('.page_collapsible').collapsible('closeAll');
            }

            //listen for close/open all
            $('#closeAll').click(function (event) {
                event.preventDefault();
                closeAll();

            });
            $('#openAll').click(function (event) {
                event.preventDefault();
                openAll();
            });

        });



        function aviso(ab) {
            var obj = document.getElementById("iframe");
            var alto = obj.contentWindow.document.body.scrollHeight;
            var actual = document.getElementById('iframe').src;

            //alert(ab);
            if (ab == 'Categorias7') {
                if (actual == 'about:blank') {
                    go('FrmDatosCliente.aspx');
                }
                else {
                }
            }


            //alert(actual);
            //go('Crud.aspx');
            //redimen();  
        }

        var ifseleccionado;

        function aviso2(ruta, idiframe) {
            var obj = document.getElementById(idiframe);
            var alto = obj.contentWindow.document.body.scrollHeight;
            var actual = document.getElementById(idiframe).src;
            if (actual == 'about:blank') {
                document.getElementById(idiframe).src = ruta;

                ifseleccionado = idiframe;
                startPollingForCompletion();
            }
            else {
                var altoactual = parseInt(obj.style.height);
                altoactual = altoactual;
                if (alto != altoactual) {
                    //alert(altoactual + ' - ' + alto);
                    redimen(idiframe);
                }
            }
        }

        function go(loc) {
            document.getElementById('iframe').src = loc;
        }

        function resizeIframe(obj) {
            //        var alto = obj.contentWindow.document.body.scrollHeight +30 ;      
            //        obj.style.height = alto + 'px';
        }

        function actualizaf(ifname) {            
            ifseleccionado = ifname;         
//            var obj = document.getElementById(ifname);
//            obj.style.height = '1px';
            startPollingForCompletion();

        }

        function autoAjuste() {
            var obj = document.getElementById(ifseleccionado);
            obj.style.height = '1px';
        }



        function redimen(ifname) {
            var obj = document.getElementById(ifname);            
            var alto = obj.contentWindow.document.body.scrollHeight;                       
            obj.style.height = alto + 'px';
        }

        var setIntervalId;

        function startPollingForCompletion() {
            setIntervalId = setInterval(closeProgressIndicator, 1000);
        }

        function closeProgressIndicator() {
            var obj = document.getElementById(ifseleccionado);

            if (obj.contentWindow.document.readyState == 'complete') {
                redimen(ifseleccionado);
                //alert('cargo completo ' + ifseleccionado);
                clearInterval(setIntervalId);
            }
        }
    </script>
</asp:Content>
