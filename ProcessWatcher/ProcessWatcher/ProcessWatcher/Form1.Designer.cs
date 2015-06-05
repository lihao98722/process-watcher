namespace ProcessWatcher
{
    partial class Form1
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.button_runserver = new System.Windows.Forms.Button();
            this.textBox_rule = new System.Windows.Forms.TextBox();
            this.button_stopserver = new System.Windows.Forms.Button();
            this.panel_firstuse = new System.Windows.Forms.Panel();
            this.button_newpw_ok = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.textBox_newpw2 = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.textBox_newpw1 = new System.Windows.Forms.TextBox();
            this.panel_enter = new System.Windows.Forms.Panel();
            this.button_enterpw_ok = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.textBox_enterpw = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.button_uninstall = new System.Windows.Forms.Button();
            this.panel_firstuse.SuspendLayout();
            this.panel_enter.SuspendLayout();
            this.SuspendLayout();
            // 
            // button_runserver
            // 
            this.button_runserver.Location = new System.Drawing.Point(329, 100);
            this.button_runserver.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.button_runserver.Name = "button_runserver";
            this.button_runserver.Size = new System.Drawing.Size(84, 31);
            this.button_runserver.TabIndex = 0;
            this.button_runserver.Text = "运行服务";
            this.button_runserver.UseVisualStyleBackColor = true;
            this.button_runserver.Click += new System.EventHandler(this.button1_Click);
            // 
            // textBox_rule
            // 
            this.textBox_rule.Location = new System.Drawing.Point(57, 65);
            this.textBox_rule.Name = "textBox_rule";
            this.textBox_rule.Size = new System.Drawing.Size(448, 27);
            this.textBox_rule.TabIndex = 1;
            // 
            // button_stopserver
            // 
            this.button_stopserver.Location = new System.Drawing.Point(421, 99);
            this.button_stopserver.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.button_stopserver.Name = "button_stopserver";
            this.button_stopserver.Size = new System.Drawing.Size(84, 31);
            this.button_stopserver.TabIndex = 2;
            this.button_stopserver.Text = "停止服务";
            this.button_stopserver.UseVisualStyleBackColor = true;
            this.button_stopserver.Click += new System.EventHandler(this.button_stopserver_Click);
            // 
            // panel_firstuse
            // 
            this.panel_firstuse.Controls.Add(this.button_newpw_ok);
            this.panel_firstuse.Controls.Add(this.label3);
            this.panel_firstuse.Controls.Add(this.textBox_newpw2);
            this.panel_firstuse.Controls.Add(this.label2);
            this.panel_firstuse.Controls.Add(this.label1);
            this.panel_firstuse.Controls.Add(this.textBox_newpw1);
            this.panel_firstuse.Location = new System.Drawing.Point(11, 7);
            this.panel_firstuse.Name = "panel_firstuse";
            this.panel_firstuse.Size = new System.Drawing.Size(551, 167);
            this.panel_firstuse.TabIndex = 3;
            this.panel_firstuse.Visible = false;
            // 
            // button_newpw_ok
            // 
            this.button_newpw_ok.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.button_newpw_ok.Location = new System.Drawing.Point(463, 130);
            this.button_newpw_ok.Name = "button_newpw_ok";
            this.button_newpw_ok.Size = new System.Drawing.Size(64, 30);
            this.button_newpw_ok.TabIndex = 5;
            this.button_newpw_ok.Text = "确定";
            this.button_newpw_ok.UseVisualStyleBackColor = true;
            this.button_newpw_ok.Click += new System.EventHandler(this.button_newpw_ok_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(66, 82);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(54, 20);
            this.label3.TabIndex = 4;
            this.label3.Text = "重复：";
            // 
            // textBox_newpw2
            // 
            this.textBox_newpw2.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.textBox_newpw2.Location = new System.Drawing.Point(144, 79);
            this.textBox_newpw2.Name = "textBox_newpw2";
            this.textBox_newpw2.PasswordChar = '*';
            this.textBox_newpw2.Size = new System.Drawing.Size(320, 25);
            this.textBox_newpw2.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(66, 51);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(54, 20);
            this.label2.TabIndex = 2;
            this.label2.Text = "密码：";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.label1.ForeColor = System.Drawing.Color.Gray;
            this.label1.Location = new System.Drawing.Point(3, 8);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(407, 17);
            this.label1.TabIndex = 1;
            this.label1.Text = "第一次使用，请先设置密码，以后需输入密码才可进行操作。(密码至少8位)";
            // 
            // textBox_newpw1
            // 
            this.textBox_newpw1.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.textBox_newpw1.Location = new System.Drawing.Point(144, 48);
            this.textBox_newpw1.Name = "textBox_newpw1";
            this.textBox_newpw1.PasswordChar = '*';
            this.textBox_newpw1.Size = new System.Drawing.Size(320, 25);
            this.textBox_newpw1.TabIndex = 0;
            // 
            // panel_enter
            // 
            this.panel_enter.Controls.Add(this.button_enterpw_ok);
            this.panel_enter.Controls.Add(this.label5);
            this.panel_enter.Controls.Add(this.textBox_enterpw);
            this.panel_enter.Location = new System.Drawing.Point(11, 9);
            this.panel_enter.Name = "panel_enter";
            this.panel_enter.Size = new System.Drawing.Size(542, 167);
            this.panel_enter.TabIndex = 6;
            this.panel_enter.Visible = false;
            // 
            // button_enterpw_ok
            // 
            this.button_enterpw_ok.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.button_enterpw_ok.Location = new System.Drawing.Point(463, 129);
            this.button_enterpw_ok.Name = "button_enterpw_ok";
            this.button_enterpw_ok.Size = new System.Drawing.Size(64, 30);
            this.button_enterpw_ok.TabIndex = 5;
            this.button_enterpw_ok.Text = "确定";
            this.button_enterpw_ok.UseVisualStyleBackColor = true;
            this.button_enterpw_ok.Click += new System.EventHandler(this.button_enterpw_ok_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(66, 51);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(54, 20);
            this.label5.TabIndex = 2;
            this.label5.Text = "密码：";
            // 
            // textBox_enterpw
            // 
            this.textBox_enterpw.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.textBox_enterpw.Location = new System.Drawing.Point(144, 48);
            this.textBox_enterpw.Name = "textBox_enterpw";
            this.textBox_enterpw.PasswordChar = '*';
            this.textBox_enterpw.Size = new System.Drawing.Size(320, 25);
            this.textBox_enterpw.TabIndex = 0;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.label4.Location = new System.Drawing.Point(54, 39);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(460, 20);
            this.label4.TabIndex = 4;
            this.label4.Text = "监控程序：（输入需要监控的程序的关键字，可用“;”分割开多个程序）";
            // 
            // button_uninstall
            // 
            this.button_uninstall.Location = new System.Drawing.Point(13, 141);
            this.button_uninstall.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.button_uninstall.Name = "button_uninstall";
            this.button_uninstall.Size = new System.Drawing.Size(84, 31);
            this.button_uninstall.TabIndex = 7;
            this.button_uninstall.Text = "卸载服务";
            this.button_uninstall.UseVisualStyleBackColor = true;
            this.button_uninstall.Click += new System.EventHandler(this.button_uninstall_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(562, 197);
            this.Controls.Add(this.panel_enter);
            this.Controls.Add(this.panel_firstuse);
            this.Controls.Add(this.button_stopserver);
            this.Controls.Add(this.textBox_rule);
            this.Controls.Add(this.button_runserver);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.button_uninstall);
            this.Font = new System.Drawing.Font("微软雅黑", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "Form1";
            this.Text = "ProcessWatcher";
            this.panel_firstuse.ResumeLayout(false);
            this.panel_firstuse.PerformLayout();
            this.panel_enter.ResumeLayout(false);
            this.panel_enter.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button_runserver;
        private System.Windows.Forms.TextBox textBox_rule;
        private System.Windows.Forms.Button button_stopserver;
        private System.Windows.Forms.Panel panel_firstuse;
        private System.Windows.Forms.TextBox textBox_newpw1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBox_newpw2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel_enter;
        private System.Windows.Forms.Button button_enterpw_ok;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox textBox_enterpw;
        private System.Windows.Forms.Button button_newpw_ok;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button button_uninstall;
    }
}

