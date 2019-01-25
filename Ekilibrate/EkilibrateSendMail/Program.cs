using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Azure.WebJobs;
using System.Net.Mail;
using System.Net;
using Autofac;
using Autofac.Integration.Wcf;
using System.ServiceModel;
using System.Threading;

namespace EkilibrateSendMail
{
    // To learn more about Microsoft Azure WebJobs SDK, please see http://go.microsoft.com/fwlink/?LinkID=320976


    public class Program
    {

        private static ExcecutionResult resultado = null;


        // Please set the following connection strings in app.config for this WebJob to run:
        // AzureWebJobsDashboard and AzureWebJobsStorage
        static void Main()
        {
            try
            {
                //Thread.Sleep(60000);
                var host = new JobHost();
                
                Task callTask = host.CallAsync(typeof(Program).GetMethod("MandaCorreosAsync"));

                Console.WriteLine("Empezando operacion...");
                callTask.Wait();
                Console.WriteLine("Tarea completada, con estado: " + callTask.Status);

                if(resultado != null)
                {
                    Console.WriteLine("Correos enviados: " + resultado.CorreosEnviados);
                    Console.WriteLine("Correos NO enviados: " + resultado.CorreosNoEnviados);

                    if (resultado.Referencia != "")
                        Console.WriteLine("Referencia: " + resultado.Referencia);
                }

                host.RunAndBlock();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }



        [NoAutomaticTrigger]
        public async static Task MandaCorreosAsync()
        {
            try
            {
                
                Mail mail = new Mail();

                resultado = await mail.MandaEmail();

                //return resultado;
            }
            catch (Exception ex)
            {
                Console.Error.Write(ex.Message);
                //throw;
            }
        }
        
    }
}
