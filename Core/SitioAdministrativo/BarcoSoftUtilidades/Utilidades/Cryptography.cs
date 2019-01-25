using System;
using System.Linq;
using System.Text;
using System.Security.Cryptography;

namespace BarcoSoftUtilidades.Utilidades
{
    /// <summary>
    /// Clase que permite la encripción de Strings para el sistema KATHARSIS.
    /// </summary>
    public static class Cryptography
    {
        #region PrivateProperties
        /// <summary>
        /// Palabra clave que se utiliza en el algoritmo de encripción
        /// </summary>
        private static readonly string magicWord = "BarcoSoft$$";
        /// <summary>
        /// Servicio de criptografía
        /// </summary>
        private static TripleDESCryptoServiceProvider des = new TripleDESCryptoServiceProvider();
        /// <summary>
        /// Proveedor de servicio de criptografía
        /// </summary>
        private static MD5CryptoServiceProvider md5cc = new MD5CryptoServiceProvider();
        #endregion

        #region Privates
        /// <summary>
        /// Función privada que transforma texto a un arreglo de bytes
        /// </summary>
        /// <param name="str">Ingresa el texto a transformar</param>
        /// <returns>Retorna arreglo de tipo byte</returns>
        private static byte[] Md5Hash(string str)
        {
            try
            {
                return md5cc.ComputeHash(ASCIIEncoding.ASCII.GetBytes(str));
            }
            catch (Exception ex)
            {
                String ClassName = "Cryptography";
                String MethodName = System.Reflection.MethodBase.GetCurrentMethod().Name;
                throw new Exception(ex.DescripcionTecnica(ClassName, MethodName));
            }

        }
        /// <summary>
        /// Método privado que define el valor de los proveedores de servicio
        /// </summary>
        /// <param name="strMagic">Recibe el texto de la palabra clave para cifrado</param>
        private static void DefineDes(string strMagic)
        {
            try
            {
                des.Key = Md5Hash(strMagic);
                des.Mode = CipherMode.ECB;
            }
            catch (Exception ex)
            {
                String ClassName = "Cryptography";
                String MethodName = System.Reflection.MethodBase.GetCurrentMethod().Name;
                throw new Exception(ex.DescripcionTecnica(ClassName, MethodName));
            }
        }
        #endregion

        #region Publics
        /// <summary>
        /// Funcion que extiende el metodo de encripcion en String
        /// </summary>
        /// <param name="str">Parámetro que recibe una cadena de texto</param>
        /// <returns>Retorna cadena de texto encriptada</returns>
        public static String Encrypt(string str)
        {
            try
            {
                if (string.IsNullOrEmpty(str))
                {
                    return string.Empty;
                }

                DefineDes(magicWord);

                str = str.Replace("á", "-/&$ta$&/-")
               .Replace("é", "-/&$tecu$&/-")
               .Replace("í", "-/&$ticu$&/-")
               .Replace("ó", "-/&$tocu$&/-")
               .Replace("ú", "-/&$tucu$&/-")
               .Replace("ñ", "-/&$tncu$&/-")
               .Replace("ü", "-/&$tuumcu$&/-")
               .Replace("Á", "-/&$tAcu$&/-")
               .Replace("É", "-/&$tEcu$&/-")
               .Replace("Í", "-/&$tIcu$&/-")
               .Replace("Ó", "-/&$tOcu$&/-")
               .Replace("Ú", "-/&$tUcu$&/-")
               .Replace("Ñ", "-/&$tNcu$&/-")
               .Replace("Ü", "-/&$tUumcu$&/-");



                byte[] buffer = ASCIIEncoding.ASCII.GetBytes(str);
                string result = Convert.ToBase64String(des.CreateEncryptor().TransformFinalBlock(buffer, 0, buffer.Length));

                return result.Replace("+", "(m)")
               .Replace("=", "(i)")
               .Replace("/", "(d1)")
               .Replace(@"\", "(d2)");

                //if (result[0] == '+')
                //    return Encrypt(" " + str);
                //else
                //    return result;

            }
            catch (Exception ex)
            {
                String ClassName = "Cryptography";
                String MethodName = System.Reflection.MethodBase.GetCurrentMethod().Name;
                throw new Exception(ex.DescripcionTecnica(ClassName, MethodName));
            }
        }
        /// <summary>
        /// Funcion que extiende el metodo de decripcion en String
        /// </summary>
        /// <param name="str">Parámetro que recibe una cadena de texto encriptada</param>
        /// <returns>Retorna cadena de texto</returns>
        public static String Decrypt(string str)
        {
            try
            {
                if (string.IsNullOrEmpty(str))
                {
                    return string.Empty;
                }

                str = str.Replace(" ", "+");
                DefineDes(magicWord);
                str = str.Replace("(m)", "+")
               .Replace("(i)", "=")
               .Replace("(d1)", "/")
               .Replace("(d2)", @"(\)");

                byte[] buffer = Convert.FromBase64String(str);
                str = ASCIIEncoding.ASCII.GetString(des.CreateDecryptor().TransformFinalBlock(buffer, 0, buffer.Length));

                str = str
               .Replace("-/&$ta$&/-", "á")
               .Replace("-/&$tecu$&/-", "é")
               .Replace("-/&$ticu$&/-", "í")
               .Replace("-/&$tocu$&/-", "ó")
               .Replace("-/&$tucu$&/-", "ú")
               .Replace("-/&$tncu$&/-", "ñ")
               .Replace("-/&$tuumcu$&/-", "ü")
               .Replace("-/&$tAcu$&/-", "Á")
               .Replace("-/&$tEcu$&/-", "É")
               .Replace("-/&$tIcu$&/-", "Í")
               .Replace("-/&$tOcu$&/-", "Ó")
               .Replace("-/&$tUcu$&/-", "Ú")
               .Replace("-/&$tNcu$&/-", "Ñ")
               .Replace("-/&$tUumcu$&/-", "Ü");


                return str.Trim();
            }
            catch (Exception ex)
            {
                String ClassName = "Cryptography";
                String MethodName = System.Reflection.MethodBase.GetCurrentMethod().Name;
                throw new Exception(ex.DescripcionTecnica(ClassName, MethodName));
            }

        }
        #endregion
    }
}
