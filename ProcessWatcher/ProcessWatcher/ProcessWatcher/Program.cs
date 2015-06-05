using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.IO;
using System.Configuration.Install;
using System.Collections;
using System.ServiceProcess;
using System.Security.Principal;

namespace ProcessWatcher
{
    static class Program
    {
        public static string serviceName = "ProcessWatcher";
        public static string serviceFileName;
        public static string pwFilePath = ProcessWatcher.Properties.Resources.pwfile;

        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {
            if (!isAdmin())
            {
                MessageBox.Show("请以管理员权限打开本程序.");
                return;
            }

            if (!File.Exists(pwFilePath))
            {
                MessageBox.Show("配置文件不存在!");
                return;
            }

            string location = System.Reflection.Assembly.GetExecutingAssembly().Location;
            serviceFileName = location.Substring(0, location.LastIndexOf('\\') + 1) +@"data\"+ "WindowsService1.exe";

            try
            {
                if (!isServiceIsExisted(serviceName))
                {
                    InstallmyService(null, serviceFileName);
                }
            }
            catch (Exception)
            {
                MessageBox.Show("操作失败，请使用管理员权限打开本程序.");
                return;
            }

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }

        //安装服务
        public static void InstallmyService(IDictionary stateSaver, string filepath)
        {
            AssemblyInstaller AssemblyInstaller1 = new AssemblyInstaller();
            AssemblyInstaller1.UseNewContext = true;
            AssemblyInstaller1.Path = filepath;
            AssemblyInstaller1.Install(stateSaver);
            AssemblyInstaller1.Commit(stateSaver);
            AssemblyInstaller1.Dispose();
            
        }

        //卸载服务
        public static void UnInstallmyService(string filepath)
        {
            if (!isServiceIsExisted(Program.serviceName))
                return;

            AssemblyInstaller AssemblyInstaller1 = new AssemblyInstaller();
            AssemblyInstaller1.UseNewContext = true;
            AssemblyInstaller1.Path = filepath;
            AssemblyInstaller1.Uninstall(null);
            AssemblyInstaller1.Dispose();
        }

        static bool isServiceIsExisted(string NameService)
        {
            ServiceController[] services = ServiceController.GetServices();
            foreach (ServiceController s in services)
            {
                if (s.ServiceName.ToLower() == NameService.ToLower())
                {
                    return true;
                }
            }
            return false;
        }

        static bool isAdmin()
        {
            WindowsIdentity identity = WindowsIdentity.GetCurrent();
            WindowsPrincipal principal = new WindowsPrincipal(identity);
            return principal.IsInRole(WindowsBuiltInRole.Administrator);
        }
    }
}
