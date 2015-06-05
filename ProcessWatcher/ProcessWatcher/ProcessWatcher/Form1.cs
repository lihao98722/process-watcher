using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;
using System.Management;
using System.IO;
using System.ServiceProcess;

namespace ProcessWatcher
{
    public partial class Form1 : Form
    {
        private string oldRule;

        public Form1()
        {
            InitializeComponent();

            //String s = "FirstTime";
            //FileOperation.SaveToFile(s);
            //MessageBox.Show(FileOperation.ReadFromFile());
            String s = FileOperation.ReadFromFile();
            if (s == "FirstTime")
            {
                this.panel_firstuse.BringToFront();
                this.panel_firstuse.Visible = true;
            }
            else
            {
                this.panel_enter.BringToFront();
                this.panel_enter.Visible = true;
            }

            
        }

        //运行服务
        private void button1_Click(object sender, EventArgs e)
        {
            if(String.IsNullOrEmpty(this.textBox_rule.Text))
            {
                MessageBox.Show("不能为空");
                return;
            }

            this.button_runserver.Enabled = false;
            try
            {
                ServiceController sc = new ServiceController(Program.serviceName);
                string[] args = { this.textBox_rule.Text };
                if (isServerRunning())
                {
                    sc.Stop(); 
                    sc.WaitForStatus(ServiceControllerStatus.Stopped);;
                }
                sc.Start(args);
                sc.WaitForStatus(ServiceControllerStatus.Running);

                ProcessWatcher.Properties.Settings.Default.rule = this.textBox_rule.Text;
                ProcessWatcher.Properties.Settings.Default.Save();
                this.button_stopserver.Enabled = true;
                this.textBox_rule.Enabled = false;
                
                MessageBox.Show("服务运行成功！");
            }
            catch (Exception ex)
            {
                //MessageBox.Show("运行失败，请确认服务已经安装！");
                MessageBox.Show("操作失败，请使用管理员权限打开本程序.");
                this.button_runserver.Enabled = true;
            }
        }

        //停止服务
        private void button_stopserver_Click(object sender, EventArgs e)
        {
            this.button_stopserver.Enabled = false;
            try
            {
                ServiceController sc = new ServiceController(Program.serviceName);
                sc.Stop();
                sc.WaitForStatus(ServiceControllerStatus.Stopped);
                //Program.UnInstallmyService(Program.serviceFileName);
                this.button_runserver.Enabled = true;
                this.textBox_rule.Enabled = true;
                MessageBox.Show("服务停止成功！");
            }
            catch (Exception ex)
            {
                MessageBox.Show("操作失败，请使用管理员权限打开本程序.");
                this.button_stopserver.Enabled = true;
            }
        }

        //确定新密码
        private void button_newpw_ok_Click(object sender, EventArgs e)
        {
            if (this.textBox_newpw1.Text == this.textBox_newpw2.Text)
            {
                if (this.textBox_newpw1.Text == "")
                    return;

                if (this.textBox_newpw1.Text.Length < 8)
                {
                    MessageBox.Show("密码至少需8位");
                    return;
                }
                else
                {
                    if (!FileOperation.SaveToFile(this.textBox_newpw1.Text))
                    {
                        MessageBox.Show("发生错误!");
                        return;
                    }

                    this.panel_firstuse.Visible = false;
                    this.oldRule = ProcessWatcher.Properties.Settings.Default.rule;
                    this.textBox_rule.Text = this.oldRule;

                    bool isServerRunning = this.isServerRunning();
                    this.button_runserver.Enabled = !isServerRunning;
                    this.button_stopserver.Enabled = isServerRunning;
                    this.textBox_rule.Enabled = this.button_runserver.Enabled;
                }
            }
            else
            {
                MessageBox.Show("两次密码不一致.");
            }
        }


        //登录
        private void button_enterpw_ok_Click(object sender, EventArgs e)
        {
            String pw = FileOperation.ReadFromFile();
            if (pw == this.textBox_enterpw.Text && !String.IsNullOrEmpty(this.textBox_enterpw.Text))
            {
                this.panel_enter.Visible = false;
                this.oldRule = ProcessWatcher.Properties.Settings.Default.rule;
                this.textBox_rule.Text = this.oldRule;

                bool isServerRunning = this.isServerRunning();
                this.button_runserver.Enabled = !isServerRunning;
                this.button_stopserver.Enabled = isServerRunning;
                this.textBox_rule.Enabled = this.button_runserver.Enabled;
            }
            else
            {
                MessageBox.Show("密码错误！");
            }
        }

        private bool isServerRunning()
        {
            ServiceController sc = new ServiceController(Program.serviceName);
            return sc.Status.Equals(ServiceControllerStatus.Running);
        }

        private bool isServiceExist()
        {
            ServiceController[] services = ServiceController.GetServices();
            foreach (ServiceController s in services)
            {
                if (s.ServiceName.ToLower() == Program.serviceName.ToLower())
                {
                    return true;
                }
            }
            return false;
        }

        //卸载服务
        private void button_uninstall_Click(object sender, EventArgs e)
        {
            if (isServerRunning())
            {
                ServiceController sc = new ServiceController(Program.serviceName);
                sc.Stop();
                sc.WaitForStatus(ServiceControllerStatus.Stopped);
            }


            Program.UnInstallmyService(Program.serviceFileName);
            MessageBox.Show("卸载服务成功！");
            this.Close();
        }
    }
}
