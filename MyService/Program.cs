using Squirrel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;

namespace MyService
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        static void Main()
        {
            ServiceBase[] ServicesToRun;
            Update();
            ServicesToRun = new ServiceBase[]
            {
                new Service1()
            };           
            ServiceBase.Run(ServicesToRun);
        }
        static async Task Update()
        {
            System.Net.ServicePointManager.SecurityProtocol = System.Net.SecurityProtocolType.Tls12;
            ServicePointManager.Expect100Continue = true;
            //ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
            //var version = typeof(Program).Assembly.GetName().Version.ToString();
            //if(version == "1.0.1")
            //{ }

            //using (var mgr = new UpdateManager("D:\\squirrel\\Project\\MyApp\\Releases"))
            //{
            //    await mgr.UpdateApp();
            //} 
            try
            {
                using (var mgr = UpdateManager.GitHubUpdateManager("https://github.com/TestSquirrel/MyService", prerelease: true /*accessToken: "672e669504503a78358577280343cbdd2fb19dea"*/))
                {
                    await mgr.Result.UpdateApp();
                }
            }
            catch (Exception ex)
            {

                throw;
            }

        }
    }
    
}
