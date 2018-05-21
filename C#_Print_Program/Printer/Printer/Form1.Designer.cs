namespace Printer
{
    partial class Form1
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.cbPorts = new System.Windows.Forms.ComboBox();
            this.lbPort = new System.Windows.Forms.Label();
            this.buttonConnect = new System.Windows.Forms.Button();
            this.buttonDisconnect = new System.Windows.Forms.Button();
            this.serialPort1 = new System.IO.Ports.SerialPort(this.components);
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripConnectionStatus = new System.Windows.Forms.ToolStripStatusLabel();
            this.tbLog = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.tbAction = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.tbCommand = new System.Windows.Forms.TextBox();
            this.buttonSend = new System.Windows.Forms.Button();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.toolStripMenuItemOpenFile = new System.Windows.Forms.ToolStripMenuItem();
            this.buttonClearLog = new System.Windows.Forms.Button();
            this.timerRefreshPorts = new System.Windows.Forms.Timer(this.components);
            this.buttonsStop = new System.Windows.Forms.Button();
            this.statusStrip1.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // cbPorts
            // 
            this.cbPorts.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbPorts.FormattingEnabled = true;
            this.cbPorts.Location = new System.Drawing.Point(12, 47);
            this.cbPorts.Name = "cbPorts";
            this.cbPorts.Size = new System.Drawing.Size(158, 21);
            this.cbPorts.TabIndex = 0;
            // 
            // lbPort
            // 
            this.lbPort.AutoSize = true;
            this.lbPort.Location = new System.Drawing.Point(11, 31);
            this.lbPort.Name = "lbPort";
            this.lbPort.Size = new System.Drawing.Size(26, 13);
            this.lbPort.TabIndex = 1;
            this.lbPort.Text = "Port";
            // 
            // buttonConnect
            // 
            this.buttonConnect.Location = new System.Drawing.Point(13, 75);
            this.buttonConnect.Name = "buttonConnect";
            this.buttonConnect.Size = new System.Drawing.Size(75, 23);
            this.buttonConnect.TabIndex = 2;
            this.buttonConnect.Text = "Connect";
            this.buttonConnect.UseVisualStyleBackColor = true;
            this.buttonConnect.Click += new System.EventHandler(this.buttonConnect_Click);
            // 
            // buttonDisconnect
            // 
            this.buttonDisconnect.Enabled = false;
            this.buttonDisconnect.Location = new System.Drawing.Point(95, 75);
            this.buttonDisconnect.Name = "buttonDisconnect";
            this.buttonDisconnect.Size = new System.Drawing.Size(75, 23);
            this.buttonDisconnect.TabIndex = 3;
            this.buttonDisconnect.Text = "Disconnect";
            this.buttonDisconnect.UseVisualStyleBackColor = true;
            this.buttonDisconnect.Click += new System.EventHandler(this.buttonDisconnect_Click);
            // 
            // serialPort1
            // 
            this.serialPort1.DataReceived += new System.IO.Ports.SerialDataReceivedEventHandler(this.serialPort1_DataReceived);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripConnectionStatus});
            this.statusStrip1.Location = new System.Drawing.Point(0, 421);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(624, 22);
            this.statusStrip1.SizingGrip = false;
            this.statusStrip1.TabIndex = 4;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripConnectionStatus
            // 
            this.toolStripConnectionStatus.Name = "toolStripConnectionStatus";
            this.toolStripConnectionStatus.Size = new System.Drawing.Size(79, 17);
            this.toolStripConnectionStatus.Text = "Disconnected";
            // 
            // tbLog
            // 
            this.tbLog.Location = new System.Drawing.Point(12, 149);
            this.tbLog.Multiline = true;
            this.tbLog.Name = "tbLog";
            this.tbLog.ReadOnly = true;
            this.tbLog.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.tbLog.Size = new System.Drawing.Size(338, 258);
            this.tbLog.TabIndex = 5;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 130);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(25, 13);
            this.label1.TabIndex = 6;
            this.label1.Text = "Log";
            // 
            // tbAction
            // 
            this.tbAction.Enabled = false;
            this.tbAction.Location = new System.Drawing.Point(176, 48);
            this.tbAction.Multiline = true;
            this.tbAction.Name = "tbAction";
            this.tbAction.Size = new System.Drawing.Size(174, 50);
            this.tbAction.TabIndex = 7;
            this.tbAction.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tbAction_KeyDown);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(176, 33);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(174, 13);
            this.label2.TabIndex = 8;
            this.label2.Text = "Поле для управления стрелками";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(356, 33);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(73, 13);
            this.label3.TabIndex = 10;
            this.label3.Text = "Ввод команд";
            // 
            // tbCommand
            // 
            this.tbCommand.Enabled = false;
            this.tbCommand.Location = new System.Drawing.Point(359, 47);
            this.tbCommand.Multiline = true;
            this.tbCommand.Name = "tbCommand";
            this.tbCommand.Size = new System.Drawing.Size(253, 51);
            this.tbCommand.TabIndex = 11;
            this.tbCommand.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tbCommand_KeyDown);
            // 
            // buttonSend
            // 
            this.buttonSend.Enabled = false;
            this.buttonSend.Location = new System.Drawing.Point(359, 114);
            this.buttonSend.Name = "buttonSend";
            this.buttonSend.Size = new System.Drawing.Size(75, 23);
            this.buttonSend.TabIndex = 12;
            this.buttonSend.Text = "Send";
            this.buttonSend.UseVisualStyleBackColor = true;
            this.buttonSend.Click += new System.EventHandler(this.buttonSend_Click);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItemOpenFile});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(624, 24);
            this.menuStrip1.TabIndex = 14;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // toolStripMenuItemOpenFile
            // 
            this.toolStripMenuItemOpenFile.Enabled = false;
            this.toolStripMenuItemOpenFile.Name = "toolStripMenuItemOpenFile";
            this.toolStripMenuItemOpenFile.Size = new System.Drawing.Size(67, 20);
            this.toolStripMenuItemOpenFile.Text = "Open file";
            this.toolStripMenuItemOpenFile.Click += new System.EventHandler(this.toolStripMenuItemOpenFile_Click);
            // 
            // buttonClearLog
            // 
            this.buttonClearLog.Location = new System.Drawing.Point(359, 383);
            this.buttonClearLog.Name = "buttonClearLog";
            this.buttonClearLog.Size = new System.Drawing.Size(75, 23);
            this.buttonClearLog.TabIndex = 15;
            this.buttonClearLog.Text = "Clear log";
            this.buttonClearLog.UseVisualStyleBackColor = true;
            this.buttonClearLog.Click += new System.EventHandler(this.buttonClearLog_Click);
            // 
            // timerRefreshPorts
            // 
            this.timerRefreshPorts.Enabled = true;
            this.timerRefreshPorts.Tick += new System.EventHandler(this.timerRefreshPorts_Tick);
            // 
            // buttonsStop
            // 
            this.buttonsStop.Enabled = false;
            this.buttonsStop.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonsStop.ForeColor = System.Drawing.Color.Red;
            this.buttonsStop.Location = new System.Drawing.Point(440, 383);
            this.buttonsStop.Name = "buttonsStop";
            this.buttonsStop.Size = new System.Drawing.Size(113, 23);
            this.buttonsStop.TabIndex = 16;
            this.buttonsStop.Text = "STOP PRINTING";
            this.buttonsStop.UseVisualStyleBackColor = true;
            this.buttonsStop.Click += new System.EventHandler(this.buttonsStop_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(624, 443);
            this.Controls.Add(this.buttonsStop);
            this.Controls.Add(this.buttonClearLog);
            this.Controls.Add(this.buttonSend);
            this.Controls.Add(this.tbCommand);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.tbAction);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tbLog);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.buttonDisconnect);
            this.Controls.Add(this.buttonConnect);
            this.Controls.Add(this.lbPort);
            this.Controls.Add(this.cbPorts);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.MainMenuStrip = this.menuStrip1;
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "CNC Plotter";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyDown);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cbPorts;
        private System.Windows.Forms.Label lbPort;
        private System.Windows.Forms.Button buttonConnect;
        private System.Windows.Forms.Button buttonDisconnect;
        private System.IO.Ports.SerialPort serialPort1;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripConnectionStatus;
        private System.Windows.Forms.TextBox tbLog;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbAction;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox tbCommand;
        private System.Windows.Forms.Button buttonSend;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemOpenFile;
        private System.Windows.Forms.Button buttonClearLog;
        private System.Windows.Forms.Timer timerRefreshPorts;
        private System.Windows.Forms.Button buttonsStop;
    }
}

