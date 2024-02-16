using System;
using System.Collections.Generic;
using System.Configuration.Install;
using System.Linq;
using System.Reflection;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;

namespace ReportService
{
    internal static class Program
    {
        /// <summary>
        /// Główny punkt wejścia dla aplikacji.
        /// </summary>
        static void Main(string[] args)
        {
            if (Environment.UserInteractive)
            {
                var parametr = string.Concat(args);
                switch (parametr)
                {
                    case "--install":
                        ManagedInstallerClass.InstallHelper(new[]
                        {Assembly.GetExecutingAssembly().Location});
                        break;

                    case "--uninstall":
                        ManagedInstallerClass.InstallHelper(new[] { "/u",
                        Assembly.GetExecutingAssembly().Location});
                        break;
                }
            }
            else
            {
                ServiceBase[] ServicesToRun;
                ServicesToRun = new ServiceBase[]
                {
                new ReportService()
                };
                ServiceBase.Run(ServicesToRun);
            }
        }
    }
}
