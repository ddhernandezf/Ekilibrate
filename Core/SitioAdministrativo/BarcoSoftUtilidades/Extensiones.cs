using BarcoSoftUtilidades.Seguridad;
using BarcoSoftUtilidades.Utilidades;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace BarcoSoftUtilidades
{
    public static class Extensiones
    {
        #region Publics

        #region DateTime
        /// <summary>
        /// Extensión que traduce valores de fecha a letras. 
        /// </summary>
        /// <param name="Date">El valor de la fecha.</param>
        /// <returns></returns>
        public static string ConvertirEnLetras(this DateTime Date)
        {
            try
            {
                if (Date == null)
                {
                    throw new Exception("El valor de la fecha no debe contener nulos para la traducción.");
                }

                String strFecha = NumercisToLetters(Date.Day) + " DE " + Date.ToString("MMMM", new CultureInfo("es-GT", false)).ToUpper() + " DE " + NumercisToLetters(Date.Year);
                return strFecha;
            }

            catch (Exception ex)
            {
                String ClassName = "Extensiones";
                String MethodName = System.Reflection.MethodBase.GetCurrentMethod().Name;
                throw new Exception(ex.DescripcionTecnica(ClassName, MethodName));
            }
        }
        #endregion

        #region Double
        /// <summary>
        /// Extensión que traduce valores numericos a letras. Parte de centavos la escribe como 'con 00/100'.
        /// </summary>
        /// <param name="Number">Valor numérico para traducir.</param>
        /// <returns></returns>
        public static String ConvertirALetras(this Double Number)
        {
            String res, dec = "";
            Int64 entero;
            int decimales;
            Double nro;

            try
            {
                try
                {
                    nro = Convert.ToDouble(Number);
                }
                catch
                {
                    return "";
                }

                entero = Convert.ToInt64(Math.Truncate(nro));
                decimales = Convert.ToInt32(Math.Round((nro - entero) * 100, 2));
                if (decimales > 0)
                {
                    dec = " CON " + decimales.ToString() + "/100";
                }

                res = NumercisToLetters(Convert.ToDouble(entero)) + dec;
                return res;
            }
            catch (Exception ex)
            {
                String ClassName = "Extensiones";
                String MethodName = System.Reflection.MethodBase.GetCurrentMethod().Name;
                throw new Exception(ex.DescripcionTecnica(ClassName, MethodName));
            }
        }
        #endregion

        #region Int
        /// <summary>
        /// Extensión que traduce valores numericos a letras. Parte de centavos la escribe como 'con 00/100'.
        /// </summary>
        /// <param name="Number">Valor numérico para traducir.</param>
        /// <returns></returns>
        public static String ConvertirALetras(this int Number)
        {
            String res, dec = "";
            Int64 entero;
            int decimales;
            double nro;

            try
            {
                try
                {
                    nro = Convert.ToDouble(Number);
                }
                catch
                {
                    return "";
                }

                entero = Convert.ToInt64(Math.Truncate(nro));
                decimales = Convert.ToInt32(Math.Round((nro - entero) * 100, 2));
                if (decimales > 0)
                {
                    dec = " CON " + decimales.ToString() + "/100";
                }

                res = NumercisToLetters(Convert.ToDouble(entero)) + dec;
                return res;
            }
            catch (Exception ex)
            {
                String ClassName = "Extensiones";
                String MethodName = System.Reflection.MethodBase.GetCurrentMethod().Name;
                throw new Exception(ex.DescripcionTecnica(ClassName, MethodName));
            }
        }
        #endregion

        #region Exception



        /// <summary>
        /// 
        /// </summary>
        /// <param name="className">El nombre de la clase donde se genera la excepción.</param>
        /// <param name="methodName">El nombre del método o función donde ocurre la excepción.</param>
        /// <param name="objectException">Clase que obtiene la información acera de la excepción.</param>
        /// <returns>Retorna en String el mensaje de la excepción ocurrida.</returns>
        public static String DescripcionTecnica(this System.Exception objectException, String className, String methodName)
        {
            String msj = String.Empty;
            if (objectException.Message.Contains("See the inner exception") || objectException.Message.Contains("Vea la excepción"))
            {
                msj = objectException.InnerException.Message;
            }
            else
            {
                msj = objectException.Message;
            }
            return className + "." + methodName + ": " + msj;
        }
        #endregion

        #region Encripción
        /// <summary>
        /// Funcion que extiende el metodo de encripcion en String
        /// </summary>
        /// <param name="str">Parámetro que recibe una cadena de texto</param>
        /// <returns>Retorna cadena de texto encriptada</returns>
        public static String Encrypt(this string str)
        {
            try
            {
                return Cryptography.Encrypt(str);
            }
            catch (Exception ex)
            {
                String ClassName = "Extensiones";
                String MethodName = System.Reflection.MethodBase.GetCurrentMethod().Name;
                throw new Exception(ex.DescripcionTecnica(ClassName, MethodName));
            }
        }
        /// <summary>
        /// Funcion que extiende el metodo de decripcion en String
        /// </summary>
        /// <param name="str">Parámetro que recibe una cadena de texto encriptada</param>
        /// <returns>Retorna cadena de texto</returns>
        public static String Decrypt(this string str)
        {
            try
            {
                return Cryptography.Decrypt(str).Trim();
            }
            catch (Exception ex)
            {
                String ClassName = "Extensiones";
                String MethodName = System.Reflection.MethodBase.GetCurrentMethod().Name;
                throw new Exception(ex.DescripcionTecnica(ClassName, MethodName));
            }

        }
        #endregion


        public static Usuario GetActualUser(this HttpContextBase httpContext)
        {
            return (Usuario)httpContext.Session["actual_Bs_User"];
        }

        public static void SetActualUser(this HttpContextBase httpContext, Usuario user)
        {
            httpContext.Session.Add("actual_Bs_User", user);
        }

        public static void SetActualUser(this HttpContextBase httpContext, string pUserName)
        {
            Usuario user = new Usuario();
            user = Usuario.GetUserByName(pUserName);

            httpContext.Session.Add("actual_Bs_User", user);
        }
        #endregion

        #region Privates
        /// <summary>
        /// Vétodo que traduce valores numericos a letras. 
        /// </summary>
        /// <param name="value">Valor número para traducir.</param>
        /// <returns>Retorna String con el valor</returns>
        private static String NumercisToLetters(Double value)
        {
            try
            {
                String Num2Text = "";
                value = Math.Truncate(value);
                if (value == 0) Num2Text = "CERO";
                else if (value == 1) Num2Text = "UNO";
                else if (value == 2) Num2Text = "DOS";
                else if (value == 3) Num2Text = "TRES";
                else if (value == 4) Num2Text = "CUATRO";
                else if (value == 5) Num2Text = "CINCO";
                else if (value == 6) Num2Text = "SEIS";
                else if (value == 7) Num2Text = "SIETE";
                else if (value == 8) Num2Text = "OCHO";
                else if (value == 9) Num2Text = "NUEVE";
                else if (value == 10) Num2Text = "DIEZ";
                else if (value == 11) Num2Text = "ONCE";
                else if (value == 12) Num2Text = "DOCE";
                else if (value == 13) Num2Text = "TRECE";
                else if (value == 14) Num2Text = "CATORCE";
                else if (value == 15) Num2Text = "QUINCE";
                else if (value < 20) Num2Text = "DIECI" + NumercisToLetters(value - 10);
                else if (value == 20) Num2Text = "VEINTE";
                else if (value < 30) Num2Text = "VEINTI" + NumercisToLetters(value - 20);
                else if (value == 30) Num2Text = "TREINTA";
                else if (value == 40) Num2Text = "CUARENTA";
                else if (value == 50) Num2Text = "CINCUENTA";
                else if (value == 60) Num2Text = "SESENTA";
                else if (value == 70) Num2Text = "SETENTA";
                else if (value == 80) Num2Text = "OCHENTA";
                else if (value == 90) Num2Text = "NOVENTA";
                else if (value < 100) Num2Text = NumercisToLetters(Math.Truncate(value / 10) * 10) + " Y " + NumercisToLetters(value % 10);
                else if (value == 100) Num2Text = "CIEN";
                else if (value < 200) Num2Text = "CIENTO " + NumercisToLetters(value - 100);
                else if ((value == 200) || (value == 300) || (value == 400) || (value == 600) || (value == 800)) Num2Text = NumercisToLetters(Math.Truncate(value / 100)) + "CIENTOS";
                else if (value == 500) Num2Text = "QUINIENTOS";
                else if (value == 700) Num2Text = "SETECIENTOS";
                else if (value == 900) Num2Text = "NOVECIENTOS";
                else if (value < 1000) Num2Text = NumercisToLetters(Math.Truncate(value / 100) * 100) + " " + NumercisToLetters(value % 100);
                else if (value == 1000) Num2Text = "MIL";
                else if (value < 2000) Num2Text = "MIL " + NumercisToLetters(value % 1000);
                else if (value < 1000000)
                {
                    Num2Text = NumercisToLetters(Math.Truncate(value / 1000)) + " MIL";
                    if ((value % 1000) > 0) Num2Text = Num2Text + " " + NumercisToLetters(value % 1000);
                }

                else if (value == 1000000) Num2Text = "UN MILLON";
                else if (value < 2000000) Num2Text = "UN MILLON " + NumercisToLetters(value % 1000000);
                else if (value < 1000000000000)
                {
                    Num2Text = NumercisToLetters(Math.Truncate(value / 1000000)) + " MILLONES ";
                    if ((value - Math.Truncate(value / 1000000) * 1000000) > 0) Num2Text = Num2Text + " " + NumercisToLetters(value - Math.Truncate(value / 1000000) * 1000000);
                }

                else if (value == 1000000000000) Num2Text = "UN BILLON";
                else if (value < 2000000000000) Num2Text = "UN BILLON " + NumercisToLetters(value - Math.Truncate(value / 1000000000000) * 1000000000000);

                else
                {
                    Num2Text = NumercisToLetters(Math.Truncate(value / 1000000000000)) + " BILLONES";
                    if ((value - Math.Truncate(value / 1000000000000) * 1000000000000) > 0) Num2Text = Num2Text + " " + NumercisToLetters(value - Math.Truncate(value / 1000000000000) * 1000000000000);
                }

                return Num2Text;

            }
            catch (Exception ex)
            {
                String ClassName = "Extensions";
                String MethodName = System.Reflection.MethodBase.GetCurrentMethod().Name;
                throw new Exception(ex.DescripcionTecnica(ClassName, MethodName));
            }
        }
        #endregion
    }
}
