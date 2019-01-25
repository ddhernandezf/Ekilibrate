using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BarcoSoftUtilidades.Seguridad
{
    public class Usuario
    {
        public int IdUsuario { get; set; }
        public string NombreUsuario { get; set; }

        public int IdTipoUsuario { get; set; }

        public Persona DatosPersona { get; set; }

        public class Persona
        {
            public string Nombres { get; set; }
            public string Apellidos { get; set; }

            public string Telefono { get; set; }
            public string Email { get; set; }
        }

        public static Usuario GetUserByName(string pUserName)
        {
            Usuario user = new Usuario();
            Data.BarcoSoftUtilidadesDB db = new Data.BarcoSoftUtilidadesDB(true);
            user = db.Usuario.Where(x => x.NombreUsuario == pUserName).Select(x => new Usuario
            {
                IdUsuario = x.IdUsuario,
                IdTipoUsuario = x.IdTipoUsuario,
                NombreUsuario = pUserName,
                DatosPersona = new Usuario.Persona
                {
                    Apellidos = x.Persona.Apellidos,
                    Email = x.Persona.Email,
                    Nombres = x.Persona.Nombres,
                    Telefono = x.Persona.Telefono
                }
            }).FirstOrDefault();

            return user;
        }

        public static Usuario GetUserById(int IdUser)
        {
            Usuario user = new Usuario();
            Data.BarcoSoftUtilidadesDB db = new Data.BarcoSoftUtilidadesDB(true);
            user = db.Usuario.Where(x => x.IdUsuario == IdUser).Select(x => new Usuario
            {
                IdUsuario = x.IdUsuario,
                IdTipoUsuario = x.IdTipoUsuario,
                NombreUsuario = x.NombreUsuario,
                DatosPersona = new Usuario.Persona
                {
                    Apellidos = x.Persona.Apellidos,
                    Email = x.Persona.Email,
                    Nombres = x.Persona.Nombres,
                    Telefono = x.Persona.Telefono
                }
            }).FirstOrDefault();
            return user;
        }



        public void ChangePassword(string pActualEncriptedPassword, string pNewEncriptedPassword)
        {
            Data.BarcoSoftUtilidadesDB db = new Data.BarcoSoftUtilidadesDB(true);
            db.Usuario.Where(x => x.IdUsuario == this.IdUsuario && x.Contraseña == pActualEncriptedPassword).ToList().ForEach(y =>
            {
                y.Contraseña = pNewEncriptedPassword;
            });
            db.SaveChanges();

        }

        public static void RecoverPassword(string nombreUsuario)
        {
            Data.BarcoSoftUtilidadesDB db = new Data.BarcoSoftUtilidadesDB(true);

            // Generar nueva contraseña
            Data.Usuario user = db.Usuario.Where(x => x.NombreUsuario == nombreUsuario).FirstOrDefault();
            if (user == null)
            {
                throw new Exception("Nombre de usuario no es conocido en la base de datos.");
            }

            string nuevaContraseña = (DateTime.Now.Millisecond.ToString() + user.Persona.Apellidos).Encrypt();

            //Se coloca la nueva contraseña en la base de datos
            Usuario TempUser = Usuario.GetUserByName(nombreUsuario);
            TempUser.ChangePassword(user.Contraseña, nuevaContraseña.Encrypt());




            //Enviar Mail de recuperación al usuario

            Utilidades.SendMail mail = new Utilidades.SendMail(
                System.Configuration.ConfigurationManager.AppSettings["GmailAccountMail"].Decrypt(), System.Configuration.ConfigurationManager.AppSettings["GmailAccountPassword"].Decrypt(),
                System.Configuration.ConfigurationManager.AppSettings["smtpClient"], Convert.ToInt32(System.Configuration.ConfigurationManager.AppSettings["smtGmailPort"])

                );

            mail.Send("Ekilibrate",user.Persona.Email, TempUser.DatosPersona.Nombres + " " + TempUser.DatosPersona.Apellidos,
                "Recuperación de contraseña Ekilibrate", 
                @""
                ,true
                
              );





        }


    }
}
