using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;
using System.Globalization;




using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Data.SqlClient;
using System.Net.Mail;
using System.Text.RegularExpressions;
using System.Security.Cryptography;
using Sis.Estudio.Entity;

/// <summary>
/// Summary description for Util
/// </summary>
public class Util
    {
        public Util()
        {
            //
            // TODO: Add constructor logic here
            //
        }
        public static string EliminaCeros(string str_imput)
        {
            try
            {
                string str_output = "";
                Int64 int64_imput = 0;
                if (str_imput.Length > 0)
                {
                    int64_imput = Convert.ToInt64(str_imput);
                    str_output = int64_imput.ToString();
                }
                return str_output;
            }
            catch
            {
                return "";
            }
        }
        public static bool fap_EsNumerico(string pstValor)
        {
            // Variable to collect the Return value of the TryParse method.
            bool isNum;

            // Define variable to collect out parameter of the TryParse method. If the conversion fails, the out parameter is zero.
            double retNum;

            // The TryParse method converts a string in a specified style and culture-specific format to its double-precision floating point number equivalent.
            // The TryParse method does not generate an exception if the conversion fails. If the conversion passes, True is returned. If it does not, False is returned.
            isNum = Double.TryParse(pstValor, System.Globalization.NumberStyles.Any, System.Globalization.NumberFormatInfo.InvariantInfo, out retNum);
            return isNum;
        }
        public static void MensajeModal(string pstMensaje, System.Web.UI.Page ppgPagina)
        {
            pstMensaje = pstMensaje.Replace("\n", "\\n");
            pstMensaje = pstMensaje.Replace("\r\n", "\\n");
            pstMensaje = pstMensaje.Replace("'", "\'");

            if ((pstMensaje != String.Empty))
            {
                string scriptString = "<script type=\'text/javascript\'>";
                scriptString = (scriptString + ("alert(\'"
                    + (pstMensaje + "\');<")));
                scriptString += "/";
                scriptString += "script>";
                if (!ppgPagina.IsStartupScriptRegistered("alert"))
                {
                    ppgPagina.RegisterStartupScript("alert", scriptString);
                }
            }
        }
        public static void MensajeModalAjax(string Mensaje, System.Web.UI.Page ppgPagina)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("<script>");
            sb.Append("alert('" + Mensaje + "');");
            sb.Append("</script>");

            ScriptManager.RegisterStartupScript(ppgPagina, typeof(Page), "Mensaje", sb.ToString(), false);
        }
        public static void MensajeExcepcionAJAX(Exception pexExcepcion, System.Web.UI.Page ppgPagina)
        {
            ppgPagina.Session["Exception"] = pexExcepcion.Message;

            StringBuilder sb = new StringBuilder();
            sb.Append("<script>window.showModalDialog('../Error/frmMensajeError.aspx', null,'status:no;dialogWidth:370px;dialogHeight:220px;dialogHide:true;help:no;scroll:no');</script>");
            ScriptManager.RegisterStartupScript(ppgPagina, typeof(Page), "MensajeExcepcion", sb.ToString(), false);
        }
        public static string fap_CadenaFormateada(string pCadena)
        {
            string mCadena;
            mCadena = "%" + pCadena.Replace("*", "%") + "%";
            return mCadena.Trim();
        }
        public static int fap_NumeroPlazo()
        {
            return Convert.ToInt32(System.Configuration.ConfigurationManager.AppSettings["NumeroPlazo"]);
        }
        public static string FormateaTexto(string cadena)
        {
            string mCadena;
            if (!string.IsNullOrEmpty(cadena.Trim()))
            {
                mCadena = fap_CadenaFormateada(cadena.Trim());
            }
            else
            {
                mCadena = fap_CadenaFormateada("");
            }

            return mCadena;
        }
        public static string FormateaEntero(string cadena)
        {
            string mCadena;
            if (!string.IsNullOrEmpty(cadena.Trim()))
            {
                mCadena = cadena.Trim();
            }
            else
            {
                mCadena = "0";
            }
            return mCadena;
        }
        public static string FormateaDecimal(string cadena)
        {
            string mCadena;
            if (!string.IsNullOrEmpty(cadena.Trim()))
            {
                mCadena = cadena.Trim();
            }
            else
            {
                mCadena = "0";
            }

            return mCadena;
        }
        public static string FormateaFecha(string cadena)
        {
            string mCadena;
            if (!string.IsNullOrEmpty(cadena.Trim()))
            {
                mCadena = cadena.Trim();
            }
            else
            {
                mCadena = "01/01/1900";
            }
            return mCadena;
        }




        static public bool esNumero(string _numberText)
        {
            int Result = 0;
            bool numberResult = false;
            if (int.TryParse(_numberText, out Result))
            {
                numberResult = true;
            }
            return numberResult;
        }

        static public bool esDecimal(string _numberText)
        {
            float Result = 0;
            bool numberResult = false;
            if (float.TryParse(_numberText, out Result))
            {
                numberResult = true;
            }
            return numberResult;
        }

        static public bool esFecha(string dateFormat)
        {
            try
            {
                String dts = DateTime.Now.ToString(dateFormat);
                DateTime.ParseExact(dts, dateFormat, CultureInfo.InvariantCulture);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }


        #region ServEnvioCorreoMasivo

        public static void xx()
        {

        }
        public static void EnviarCorreo(string correo_remitente, string correo_destinatario, string correo_asunto, string correo_cuerpo)
        {
            /*-------------------------MENSAJE DE CORREO----------------------*/

            //Creamos un nuevo Objeto de mensaje
            System.Net.Mail.MailMessage mmsg = new System.Net.Mail.MailMessage();

            //Direccion de correo electronico a la que queremos enviar el mensaje
            //mmsg.To.Add(correo_destinatario.Trim());
            mmsg.To.Add("fvalverdeu@crgestion.com.pe");


            //Nota: La propiedad To es una colección que permite enviar el mensaje a más de un destinatario

            //Asunto
            mmsg.Subject = correo_asunto.Trim();
            mmsg.SubjectEncoding = System.Text.Encoding.UTF8;

            //Direccion de correo electronico que queremos que reciba una copia del mensaje
            //mmsg.Bcc.Add("destinatariocopia@servidordominio.com"); //Opcional

            //Cuerpo del Mensaje
            mmsg.Body = correo_cuerpo.Trim();
            mmsg.BodyEncoding = System.Text.Encoding.UTF8;
            mmsg.IsBodyHtml = true; //Si no queremos que se envíe como HTML

            //Correo electronico desde la que enviamos el mensaje
            mmsg.From = new System.Net.Mail.MailAddress(correo_remitente.Trim());


            /*-------------------------CLIENTE DE CORREO----------------------*/

            //Creamos un objeto de cliente de correo
            System.Net.Mail.SmtpClient cliente = new System.Net.Mail.SmtpClient();

            //Hay que crear las credenciales del correo emisor
            cliente.Credentials =
                new System.Net.NetworkCredential("prueba@crgestion.com.pe", "crgestion2016");
                //new System.Net.NetworkCredential("enviocorreo@bomberosperu.gob.pe", "envio2013");

            //Lo siguiente es obligatorio si enviamos el mensaje desde Gmail
            //string ext;
            //ext = txt_correo.Text.Trim().Substring((txt_correo.Text.Trim().Length - 9));
            //if (ext == "gmail.com")
            //{
            //    cliente.Port = 587;
            //    cliente.EnableSsl = true;
            //}


            cliente.Host = "zimbra.crgestion.com.pe"; //Para Gmail "smtp.gmail.com";
            //cliente.Host = "mail.bomberosperu.gob.pe"; //Para Gmail "smtp.gmail.com";


            /*-------------------------ENVIO DE CORREO----------------------*/

            try
            {
                //Enviamos el mensaje      
                cliente.Send(mmsg);

            }
            catch (System.Net.Mail.SmtpException ex)
            {
                //Aquí gestionamos los errores al intentar enviar el correo
            }
        }





        public static void crearEMAILsmtp(string eSubject, string eDe, string eDestinatario, string eDestOcultos, string eTextoEmail)//, string eAdjuntos)
        {
            // System.Web.Mail.SmtpMail.SmtpServer está obsoleta 
            // System.Net.Mail.SmtpClient es la clase recomendada 
            SmtpClient smtpClient = new SmtpClient();
            MailMessage message = new MailMessage();

            try
            {
                try
                {
                    //Attachment adjunto = new Attachment(eAdjuntos);
                    //message.Attachments.Add(adjunto);
                    MailAddress fromAddress = new MailAddress("system_mail_robot@crgestion.com.pe", "CRGestión Mail Notification");

                    //especificar el servidor 
                    smtpClient.Host = "192.168.1.18";

                    //especificar el puerto 
                    smtpClient.Port = 25;

                    //remitente del email (valor parametrizado en la Base de Datos) 
                    message.From = fromAddress;

                    // To: colección de direcciones de mails, o un string formado por la unión de todas con ; 

                    string[] dests = eDestinatario.Split(';');
                    if (dests.Rank > 0)
                    {
                        foreach (string email in dests)
                        {
                            message.To.Add(new MailAddress(email, email));
                        }
                    }

                    message.Subject = eSubject;
                    if (!eDestOcultos.Equals(""))
                    {
                        foreach (string email in eDestOcultos.Split(new string[] { ";" }, StringSplitOptions.None))
                        {
                            message.Bcc.Add(new MailAddress(email, System.Reflection.Missing.Value.ToString()));
                        }
                    }

                    //FOrmato texto, no HTML 
                    message.IsBodyHtml = true;

                    // Texto del mensaje 
                    message.Body = eTextoEmail;

                    // Envía el email 
                    smtpClient.Send(message);

                    //MessageBox.Show("Email enviado con éxito.", "ENVIO DE EMAILS:",
                    //MessageBoxButtons.OK, MessageBoxIcon.Information);
                    //estadoEmail = 1;
                }
                catch (SmtpFailedRecipientsException exAll)
                {
                    //no se ha podido enviar a todos los destinatarios 
                    
                    //MessageBox.Show("No se ha podido enviar a todos los destinatarios: " +
                    //exAll.Message.ToString(), "ENVIO DE EMAILS:", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    //estadoEmail = 0;
                }
            }
            catch (SmtpException ex)
            {
                //estadoEmail = 0;
                //no se ha podido enviar el email correctamente 
                //MessageBox.Show("información del Envío: " + ex.StatusCode.ToString(), "ENVIO DE EMAILS:", 
                // MessageBoxButtons.OK, MessageBoxIcon.Information ); 

                //MessageBox.Show("El envío ha fallado. " + ex.Message.ToString(), "ENVIO DE EMAILS:",
                //MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        #endregion ServEnvioCorreoMasivo

        public static string mes_en_letras(int mes_numero)
        {
            string mes_letras;
            mes_letras = "";

            switch (mes_numero)
            {
                case 1: mes_letras = "Enero"; break;
                case 2: mes_letras = "Febrero"; break;
                case 3: mes_letras = "Marzo"; break;
                case 4: mes_letras = "Abril"; break;
                case 5: mes_letras = "Mayo"; break;
                case 6: mes_letras = "Junio"; break;
                case 7: mes_letras = "Julio"; break;
                case 8: mes_letras = "Agosto"; break;
                case 9: mes_letras = "Setiembre"; break;
                case 10: mes_letras = "Octubre"; break;
                case 11: mes_letras = "Noviembre"; break;
                case 12: mes_letras = "Diciembre"; break;

            }
            return mes_letras;
        }

        #region MetodosGenerales

        public static List<EnColumna> mxLlenarValorInicial_DropDownList(List<EnColumna> lstListaColumna)
        {
            //DataView ldvVistaOrdenada = new DataView();
            //DataRow ldrNuevoRegistro = pdtDataTable.NewRow();
            //DataTable ldtTablaOrdenada = new DataTable();
            //List<EnColumna> lstEnColumna = new List<EnColumna>();

            //string lcNombreColumna = string.Empty;

            ////Obtenemos el nombre de la columna para que sea ordena por dicha columna de la tabla
            //lcNombreColumna = pdtDataTable.Columns[0].ColumnName.ToString();

            ////Agregamos valor a la nueva fila creada (Codigo,Descripcion)
            ////lstEnColumna
            //ldrNuevoRegistro[0] = "-1";
            //ldrNuevoRegistro[1] = "--Seleccionar--";
            //pdtDataTable.Rows.Add(ldrNuevoRegistro);

            ////Asignamos el valor del DataTable a una vista para luego hacer el ordenamiento
            //ldvVistaOrdenada = pdtDataTable.DefaultView;
            //ldvVistaOrdenada.Sort = lcNombreColumna + " ASC";
            //ldtTablaOrdenada = ldvVistaOrdenada.ToTable();

            //----------------------------------------------------

            //Create the select list item you want to add
            //EnColumna selListItem = new EnColumna() { nIdColumna = "-1", cNombreColumna = "---Seleccionar-" };

            ////Create a list of select list items - this will be returned as your select list
            //List<EnColumna> newList = new List<EnColumna>();

            ////Add select list item to list of selectlistitems
            //newList.Add(selListItem);
            //newList.Add(lstListaColumna);

            //Return the list of selectlistitems as a selectlist
            return new List<EnColumna>();




            //return ldtTablaOrdenada;
        }
        public static bool EsNumerico(string pcValor)
        {
            Regex _isNumber = new Regex(@"[^0-9]");
            Match m = _isNumber.Match(pcValor);
            return !m.Success;
        }


        public static string ConvertirNumeroAColumnaExcel(int column)
        {
            string columnString = "";
            decimal columnNumber = column;
            while (columnNumber > 0)
            {
                decimal currentLetterNumber = (columnNumber - 1) % 26;
                char currentLetter = (char)(currentLetterNumber + 65);
                columnString = currentLetter + columnString;
                columnNumber = (columnNumber - (currentLetterNumber + 1)) / 26;
            }
            return columnString;
        }

        public static int ConvertirColumnaExcelANumero(string column)
        {
            int retVal = 0;
            string col = column.ToUpper();
            for (int iChar = col.Length - 1; iChar >= 0; iChar--)
            {
                char colPiece = col[iChar];
                int colNum = colPiece - 64;
                retVal = retVal + colNum * (int)Math.Pow(26, col.Length - (iChar + 1));
            }
            return retVal;
        }



        #endregion MetodosGenerales


        #region Encryption
        public static string Encrypt(string toEncrypt, bool useHashing)
        {
            byte[] keyArray;
            byte[] toEncryptArray = UTF8Encoding.UTF8.GetBytes(toEncrypt);

            System.Configuration.AppSettingsReader settingsReader =
                                                new AppSettingsReader();

            string key = (string)settingsReader.GetValue("SecurityKey",
                                                             typeof(String));
            if (useHashing)
            {
                MD5CryptoServiceProvider hashmd5 = new MD5CryptoServiceProvider();
                keyArray = hashmd5.ComputeHash(UTF8Encoding.UTF8.GetBytes(key));
                hashmd5.Clear();
            }
            else
                keyArray = UTF8Encoding.UTF8.GetBytes(key);

            TripleDESCryptoServiceProvider tdes = new TripleDESCryptoServiceProvider();
            //set the secret key for the tripleDES algorithm
            tdes.Key = keyArray;
            //mode of operation. there are other 4 modes.
            //We choose ECB(Electronic code Book)
            tdes.Mode = CipherMode.ECB;
            //padding mode(if any extra byte added)

            tdes.Padding = PaddingMode.PKCS7;

            ICryptoTransform cTransform = tdes.CreateEncryptor();
            //transform the specified region of bytes array to resultArray
            byte[] resultArray =
              cTransform.TransformFinalBlock(toEncryptArray, 0,
              toEncryptArray.Length);
            //Release resources held by TripleDes Encryptor
            tdes.Clear();
            //Return the encrypted data into unreadable string format
            return Convert.ToBase64String(resultArray, 0, resultArray.Length);
        }

        public static string Decrypt(string cipherString, bool useHashing)
        {
            byte[] keyArray;
            //get the byte code of the string

            byte[] toEncryptArray = Convert.FromBase64String(cipherString);

            System.Configuration.AppSettingsReader settingsReader =
                                                new AppSettingsReader();
            //Get your key from config file to open the lock!
            string key = (string)settingsReader.GetValue("SecurityKey",
                                                         typeof(String));

            if (useHashing)
            {
                //if hashing was used get the hash code with regards to your key
                MD5CryptoServiceProvider hashmd5 = new MD5CryptoServiceProvider();
                keyArray = hashmd5.ComputeHash(UTF8Encoding.UTF8.GetBytes(key));
                //release any resource held by the MD5CryptoServiceProvider

                hashmd5.Clear();
            }
            else
            {
                //if hashing was not implemented get the byte code of the key
                keyArray = UTF8Encoding.UTF8.GetBytes(key);
            }

            TripleDESCryptoServiceProvider tdes = new TripleDESCryptoServiceProvider();
            //set the secret key for the tripleDES algorithm
            tdes.Key = keyArray;
            //mode of operation. there are other 4 modes. 
            //We choose ECB(Electronic code Book)

            tdes.Mode = CipherMode.ECB;
            //padding mode(if any extra byte added)
            tdes.Padding = PaddingMode.PKCS7;

            ICryptoTransform cTransform = tdes.CreateDecryptor();
            byte[] resultArray = cTransform.TransformFinalBlock(
                                 toEncryptArray, 0, toEncryptArray.Length);
            //Release resources held by TripleDes Encryptor                
            tdes.Clear();
            //return the Clear decrypted TEXT
            return UTF8Encoding.UTF8.GetString(resultArray);
        }
        #endregion
    }

