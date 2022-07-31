using System;
using System.Collections.Generic;
using System.Text;
using System.Security.Cryptography;
using System.IO;
//using COM_ENCRIPTA;
namespace Sis.Estudio.Logic.MSSQL.Funcionabilidad
{
    public class LoEncripta
    {

        #region f_Encripta_Desencripta

        public string f_Encripta_Desencripta(int tarea, string Cadena)
        {

            int l;
            int k;
            int i;
            int lm;
            int cb;
            cb = 0;
            lm = 0;
            l = 0;
            k = 0;
            i = 0;
            string ts;
            ts = "";
            Cadena = Cadena.Trim();
            string Pass;
            Pass = " ";

            try
            {

                if ((tarea == 1))
                {
                    l = Pass.Length;
                    for (i = 1; (i <= l); i++)
                    {
                        k = (k + (RetAsciiCode(Pass.Substring((i - 1), 1)) * i));
                        if ((k > 255))
                        {
                            k = (k - 255);
                        }
                    }
                    while ((k > 255))
                    {
                        k = (k - 255);
                    }
                    lm = Cadena.Length;
                    for (i = 1; (i <= lm); i++)
                    {
                        cb = (RetAsciiCode(Cadena.Substring((i - 1), 1)) + k);
                        // Change Current Byte
                        if ((cb > 255))
                        {
                            cb = (cb - 255);
                        }
                        ts = (ts + ((char)(cb)));
                        k = (k + cb);
                        if ((k > 255))
                        {
                            k = (k - 255);
                        }
                        // Update Key
                    }
                }
                else
                {
                    l = Pass.Length;
                    for (i = 1; (i <= l); i++)
                    {
                        k = (k + (RetAsciiCode(Pass.Substring((i - 1), 1)) * i));
                        if ((k > 255))
                        {
                            k = (k - 255);
                        }
                        // Get Key
                    }
                    while ((k > 255))
                    {
                        k = (k - 255);
                    }
                    lm = Cadena.Length;
                    for (i = 1; (i <= lm); i++)
                    {
                        cb = (RetAsciiCode(Cadena.Substring((i - 1), 1)) - k);
                        // Change Current Byte
                        if ((cb < 0))
                        {
                            cb = (cb + 255);
                        }
                        ts = (ts + ((char)(cb)));
                        k = (k + RetAsciiCode(Cadena.Substring((i - 1), 1)));
                        if ((k > 255))
                        {
                            k = (k - 255);
                        }
                        // Update Key
                    }
                }
                return ts;

                //dato = RetAsciiCode(" ");

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        #endregion f_Encripta_Desencripta

        #region Cl_Encripta
        public string Cl_Encripta(string Cadena)
        {
            try
            {
               //CL_Encripta objEncripta = new CL_Encripta();
               //return objEncripta.f_Encripta_Desencripta(1, Cadena);
               return Cadena;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public string Cl_DesEncripta(string Cadena)
        {
            try
            {
                //CL_Encripta objEncripta = new CL_Encripta();
                //return objEncripta.f_Encripta_Desencripta(2, Cadena);
                return Cadena;            }

            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion Cl_Encripta
        #region rijndael

        #region Declaracion

        private static string passBase = "pass1982dc@avz17";
        private static string saltValue = "s@lAvzjsf";
        private static string hashAlgorithm = "MD5";
        private static int passwordIterations = 1;
        private static string initVector = "@1B2c3D4e5F6g7H8";
        private static int keySize = 128;

        #endregion Declaracion

        public string ObtenerMd5(string pass)
        {
            string enc = "";
            enc = Encriptar(pass);
            return enc;
        }
        public string ObtenerMd52(string pass)
        {
            string desnc = "";
            desnc = Desencriptar(pass);
            return desnc;
        }

        #region Encriptar
        public static string Encriptar(string textoQueEncriptaremos)
        {
            //return Encriptar(textoQueEncriptaremos,"pass75dc@avz10", "s@lAvz", "MD5", 1, "@1B2c3D4e5F6g7H8", 128);
            return Encriptar(textoQueEncriptaremos, passBase, saltValue, hashAlgorithm, passwordIterations, initVector, keySize);
        }
        public static string Encriptar(string textoQueEncriptaremos, string passBase, string saltValue, string hashAlgorithm, int passwordIterations, string initVector, int keySize)
        {
            byte[] initVectorBytes = Encoding.ASCII.GetBytes(initVector);
            byte[] saltValueBytes = Encoding.ASCII.GetBytes(saltValue);
            byte[] plainTextBytes = Encoding.UTF8.GetBytes(textoQueEncriptaremos);

            PasswordDeriveBytes password = new PasswordDeriveBytes(passBase, saltValueBytes, hashAlgorithm, passwordIterations);
            byte[] keyBytes = password.GetBytes(keySize / 8);
            RijndaelManaged symmetricKey = new RijndaelManaged()
            {
                Mode = CipherMode.CBC
            };
            ICryptoTransform encryptor = symmetricKey.CreateEncryptor(keyBytes,
            initVectorBytes);
            MemoryStream memoryStream = new MemoryStream();
            CryptoStream cryptoStream = new CryptoStream(memoryStream, encryptor,
            CryptoStreamMode.Write);

            cryptoStream.Write(plainTextBytes, 0, plainTextBytes.Length);
            cryptoStream.FlushFinalBlock();
            byte[] cipherTextBytes = memoryStream.ToArray();
            memoryStream.Close();
            cryptoStream.Close();
            string cipherText = Convert.ToBase64String(cipherTextBytes);
            return cipherText;
        }
        #endregion
        #region Desencriptar
        public static string Desencriptar(string textoEncriptado)
        {
            // return Desencriptar(textoEncriptado, "pass75dc@avz10", "s@lAvz", "MD5",1, "@1B2c3D4e5F6g7H8", 128);
            return Desencriptar(textoEncriptado, passBase, saltValue, hashAlgorithm, passwordIterations, initVector, keySize);
        }
        /// Método para desencriptar un texto encriptado (Rijndael) 
        public static string Desencriptar(string textoEncriptado, string passBase, string saltValue, string hashAlgorithm, int passwordIterations, string initVector, int keySize)
        {
            byte[] initVectorBytes = Encoding.ASCII.GetBytes(initVector);
            byte[] saltValueBytes = Encoding.ASCII.GetBytes(saltValue);
            byte[] cipherTextBytes = Convert.FromBase64String(textoEncriptado);            
            PasswordDeriveBytes password = new PasswordDeriveBytes(passBase, saltValueBytes, hashAlgorithm, passwordIterations);
            byte[] keyBytes = password.GetBytes(keySize / 8);
            RijndaelManaged symmetricKey = new RijndaelManaged()
            {
                Mode = CipherMode.CBC
            };
            ICryptoTransform decryptor = symmetricKey.CreateDecryptor(keyBytes,
            initVectorBytes);
            MemoryStream memoryStream = new MemoryStream(cipherTextBytes);
            CryptoStream cryptoStream = new CryptoStream(memoryStream, decryptor,
            CryptoStreamMode.Read);
            byte[] plainTextBytes = new byte[cipherTextBytes.Length];
            int decryptedByteCount = cryptoStream.Read(plainTextBytes, 0,
            plainTextBytes.Length);
            memoryStream.Close();
            cryptoStream.Close();
            string plainText = Encoding.UTF8.GetString(plainTextBytes, 0,
            decryptedByteCount);
            return plainText;
        }

        #endregion
        

        public int RetAsciiCode(string MyString)
        {

            /***** metodo 1 ******
            if (MyString.Length == 0)

                return 0;

            else if (MyString.Length > 1)
                MyString = MyString[0].ToString();
            int AsciiCodeO = (int)System.Convert.ToChar(MyString);
            byte[] AsciiCodeB = System.Text.Encoding.ASCII.GetBytes(MyString);

            return AsciiCodeO;
             *************************/

            /***** metodo 2 ******
           
            *************************/

            /***** metodo 3*********/
            return Encoding.Default.GetBytes(MyString)[0];
            /***********************/

        }

        public string RetAsciiChar(int AsciiCode)
        {

            /************* metodo 1 **************
            return System.Convert.ToChar(AsciiCode).ToString();
            *************/

            /***** metodo 3*********/
            if (AsciiCode > 255)
                throw new ArgumentOutOfRangeException("CharCode", AsciiCode, "CharCode must be between 0 and 255.");
            return Encoding.Default.GetString(new[] { (byte)AsciiCode });
            /***********************/
        }


        #endregion rijndael

    }
}
