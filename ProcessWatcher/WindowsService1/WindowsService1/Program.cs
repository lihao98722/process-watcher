using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;
using System.Configuration.Install;
using System.ServiceProcess;
using System.ComponentModel;
using System.Threading;

namespace KILLER
{
    class Program : ServiceBase
    {
        #region 常量
        public const string SERVICE_NAME = "ProcessWatcher";
        public const string CUSTOMSRC_NAME = "进程杀手服务程序";

        #endregion

        private String[] parameter;

        #region 字段

        TimeSpan interval;
        TimeSpan delay;
        Timer timer;

        #endregion

        #region 私有方法
        void Reset()
        {
            interval = TimeSpan.FromSeconds(5);
            delay = TimeSpan.Zero;
        }

        void RaiseTimer()
        {
            timer = new Timer(TimerCallback, null, delay, interval);
        }

        void TryStopTimer()
        {
            if (timer != null)
                timer.Dispose();
            timer = null;
        }

        void TimerCallback(object state)
        {
            foreach (Process p in Process.GetProcesses())
            {
                foreach (string rule in this.parameter)
                {
                    if (p.ProcessName.ToUpper().Contains(rule.ToUpper()))
                    {
                        try
                        {
                            p.Kill();
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine(ex.Message);
                        }
                    }
                }
            }
        }


        #endregion

        #region 构造函数

        public Program()
        {
            base.ServiceName = SERVICE_NAME;
            base.CanStop = true;
            base.CanPauseAndContinue = true;
            base.AutoLog = false;
        }

        #endregion

        #region 继承虚方法
        protected override void OnStart(String[] args)
        {
            Reset();
            try
            {
                String temp=String.IsNullOrEmpty(args[0])?"":args[0];
                this.parameter = temp.Split(';');
                RaiseTimer();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);  
                Stop();
            }
        }

        protected override void OnStop()
        {
            base.OnStop();
            TryStopTimer();
            
        }

        protected override void OnContinue()
        {
            base.OnContinue();
            RaiseTimer();
        }

        protected override void OnPause()
        {
            base.OnPause();
            TryStopTimer();
        }

        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);
            TryStopTimer();
        }

        #endregion

        #region 主函数
        static void Main(string[] args)
        {
            ServiceBase.Run(new Program());
        }

        #endregion

    }

    [RunInstaller(true)]
    public class MyInstaller : Installer
    {
        private Process p = new Process();
        public MyInstaller()
        {
            //InitializeComponent();
            
            p.StartInfo.FileName = "cmd.exe";
            p.StartInfo.UseShellExecute = false;
            p.StartInfo.RedirectStandardInput = true;
            p.StartInfo.RedirectStandardOutput = true;
            p.StartInfo.RedirectStandardError = true;
            p.StartInfo.CreateNoWindow = true;
            p.Start();
            
            ServiceProcessInstaller spi = new ServiceProcessInstaller();
            ServiceInstaller si = new ServiceInstaller();

            spi.AfterInstall += new InstallEventHandler(MyInstaller_AfterInstall);

            spi.Account = ServiceAccount.LocalSystem;

            si.ServiceName = Program.SERVICE_NAME;
            si.StartType = ServiceStartMode.Automatic;
            //si.Description = "  ";
            si.DisplayName = Program.SERVICE_NAME;

            Installers.Add(spi);
            Installers.Add(si);
        }

        private void MyInstaller_AfterInstall(object sender, InstallEventArgs e)
        {
            string Cmdstring = "sc start " + Program.SERVICE_NAME; //CMD命令
            p.StandardInput.WriteLine(Cmdstring);
            p.StandardInput.WriteLine("exit");
        }

        private void MyInstaller_BeforeUninstall(object sender, InstallEventArgs e)
        {
            string Cmdstring = "sc stop " + Program.SERVICE_NAME; //CMD命令
            p.StandardInput.WriteLine(Cmdstring);
            p.StandardInput.WriteLine("exit");
        }

    }
}

