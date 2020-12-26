using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration.Install;
using System.Linq;
using System.ServiceProcess;
using System.Threading.Tasks;

namespace GismeteoWinService
{
    [RunInstaller(true)]
    public partial class GismeteoServiceInstaller : System.Configuration.Install.Installer
    {
        public GismeteoServiceInstaller()
        {
            InitializeComponent();
            ServiceInstaller serviceInstaller = new ServiceInstaller();
            ServiceProcessInstaller processInstaller = new ServiceProcessInstaller();

            processInstaller.Account = ServiceAccount.LocalSystem;
            serviceInstaller.StartType = ServiceStartMode.Manual;
            serviceInstaller.ServiceName ="GismeteoWinService";

            Installers.Add(serviceInstaller);
            Installers.Add(processInstaller);

        }
    }
}
