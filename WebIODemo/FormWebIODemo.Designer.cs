namespace WebIODemo
{
    partial class FormWebIODemo
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormWebIODemo));
            this.gb_outputs = new System.Windows.Forms.GroupBox();
            this.gb_inputs = new System.Windows.Forms.GroupBox();
            this.gb_counter = new System.Windows.Forms.GroupBox();
            this.gb_getset = new System.Windows.Forms.GroupBox();
            this.co_output = new System.Windows.Forms.ComboBox();
            this.co_input = new System.Windows.Forms.ComboBox();
            this.tb_setoutputs = new System.Windows.Forms.TextBox();
            this.bt_getsingleoutput = new System.Windows.Forms.Button();
            this.bt_setoutputs = new System.Windows.Forms.Button();
            this.bt_getsingleinput = new System.Windows.Forms.Button();
            this.bt_getinputs = new System.Windows.Forms.Button();
            this.bt_getoutputs = new System.Windows.Forms.Button();
            this.gb_connection = new System.Windows.Forms.GroupBox();
            this.bt_connect = new System.Windows.Forms.Button();
            this.tb_port = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.tb_password = new System.Windows.Forms.TextBox();
            this.tb_ip = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.gb_getset.SuspendLayout();
            this.gb_connection.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // gb_outputs
            // 
            resources.ApplyResources(this.gb_outputs, "gb_outputs");
            this.gb_outputs.Name = "gb_outputs";
            this.gb_outputs.TabStop = false;
            // 
            // gb_inputs
            // 
            resources.ApplyResources(this.gb_inputs, "gb_inputs");
            this.gb_inputs.Name = "gb_inputs";
            this.gb_inputs.TabStop = false;
            // 
            // gb_counter
            // 
            resources.ApplyResources(this.gb_counter, "gb_counter");
            this.gb_counter.Name = "gb_counter";
            this.gb_counter.TabStop = false;
            // 
            // gb_getset
            // 
            this.gb_getset.Controls.Add(this.co_output);
            this.gb_getset.Controls.Add(this.co_input);
            this.gb_getset.Controls.Add(this.tb_setoutputs);
            this.gb_getset.Controls.Add(this.bt_getsingleoutput);
            this.gb_getset.Controls.Add(this.bt_setoutputs);
            this.gb_getset.Controls.Add(this.bt_getsingleinput);
            this.gb_getset.Controls.Add(this.bt_getinputs);
            this.gb_getset.Controls.Add(this.bt_getoutputs);
            resources.ApplyResources(this.gb_getset, "gb_getset");
            this.gb_getset.Name = "gb_getset";
            this.gb_getset.TabStop = false;
            // 
            // co_output
            // 
            this.co_output.FormattingEnabled = true;
            this.co_output.Items.AddRange(new object[] {
            resources.GetString("co_output.Items"),
            resources.GetString("co_output.Items1"),
            resources.GetString("co_output.Items2"),
            resources.GetString("co_output.Items3"),
            resources.GetString("co_output.Items4"),
            resources.GetString("co_output.Items5"),
            resources.GetString("co_output.Items6"),
            resources.GetString("co_output.Items7"),
            resources.GetString("co_output.Items8"),
            resources.GetString("co_output.Items9"),
            resources.GetString("co_output.Items10"),
            resources.GetString("co_output.Items11")});
            resources.ApplyResources(this.co_output, "co_output");
            this.co_output.Name = "co_output";
            // 
            // co_input
            // 
            this.co_input.FormattingEnabled = true;
            this.co_input.Items.AddRange(new object[] {
            resources.GetString("co_input.Items"),
            resources.GetString("co_input.Items1"),
            resources.GetString("co_input.Items2"),
            resources.GetString("co_input.Items3"),
            resources.GetString("co_input.Items4"),
            resources.GetString("co_input.Items5"),
            resources.GetString("co_input.Items6"),
            resources.GetString("co_input.Items7"),
            resources.GetString("co_input.Items8"),
            resources.GetString("co_input.Items9"),
            resources.GetString("co_input.Items10"),
            resources.GetString("co_input.Items11")});
            resources.ApplyResources(this.co_input, "co_input");
            this.co_input.Name = "co_input";
            // 
            // tb_setoutputs
            // 
            resources.ApplyResources(this.tb_setoutputs, "tb_setoutputs");
            this.tb_setoutputs.Name = "tb_setoutputs";
            // 
            // bt_getsingleoutput
            // 
            resources.ApplyResources(this.bt_getsingleoutput, "bt_getsingleoutput");
            this.bt_getsingleoutput.Name = "bt_getsingleoutput";
            this.bt_getsingleoutput.UseVisualStyleBackColor = true;
            this.bt_getsingleoutput.Click += new System.EventHandler(this.bt_getsingleoutput_Click);
            // 
            // bt_setoutputs
            // 
            resources.ApplyResources(this.bt_setoutputs, "bt_setoutputs");
            this.bt_setoutputs.Name = "bt_setoutputs";
            this.bt_setoutputs.UseVisualStyleBackColor = true;
            this.bt_setoutputs.Click += new System.EventHandler(this.bt_setoutputs_Click);
            // 
            // bt_getsingleinput
            // 
            resources.ApplyResources(this.bt_getsingleinput, "bt_getsingleinput");
            this.bt_getsingleinput.Name = "bt_getsingleinput";
            this.bt_getsingleinput.UseVisualStyleBackColor = true;
            this.bt_getsingleinput.Click += new System.EventHandler(this.bt_getsingleinput_Click);
            // 
            // bt_getinputs
            // 
            resources.ApplyResources(this.bt_getinputs, "bt_getinputs");
            this.bt_getinputs.Name = "bt_getinputs";
            this.bt_getinputs.UseVisualStyleBackColor = true;
            this.bt_getinputs.Click += new System.EventHandler(this.bt_getinputs_Click);
            // 
            // bt_getoutputs
            // 
            resources.ApplyResources(this.bt_getoutputs, "bt_getoutputs");
            this.bt_getoutputs.Name = "bt_getoutputs";
            this.bt_getoutputs.UseVisualStyleBackColor = true;
            this.bt_getoutputs.Click += new System.EventHandler(this.bt_getoutputs_Click);
            // 
            // gb_connection
            // 
            this.gb_connection.Controls.Add(this.bt_connect);
            this.gb_connection.Controls.Add(this.tb_port);
            this.gb_connection.Controls.Add(this.label3);
            this.gb_connection.Controls.Add(this.tb_password);
            this.gb_connection.Controls.Add(this.tb_ip);
            this.gb_connection.Controls.Add(this.label2);
            this.gb_connection.Controls.Add(this.label1);
            resources.ApplyResources(this.gb_connection, "gb_connection");
            this.gb_connection.Name = "gb_connection";
            this.gb_connection.TabStop = false;
            // 
            // bt_connect
            // 
            resources.ApplyResources(this.bt_connect, "bt_connect");
            this.bt_connect.Name = "bt_connect";
            this.bt_connect.UseVisualStyleBackColor = true;
            this.bt_connect.Click += new System.EventHandler(this.bt_connect_Click);
            // 
            // tb_port
            // 
            resources.ApplyResources(this.tb_port, "tb_port");
            this.tb_port.Name = "tb_port";
            // 
            // label3
            // 
            resources.ApplyResources(this.label3, "label3");
            this.label3.Name = "label3";
            // 
            // tb_password
            // 
            resources.ApplyResources(this.tb_password, "tb_password");
            this.tb_password.Name = "tb_password";
            // 
            // tb_ip
            // 
            resources.ApplyResources(this.tb_ip, "tb_ip");
            this.tb_ip.Name = "tb_ip";
            // 
            // label2
            // 
            resources.ApplyResources(this.label2, "label2");
            this.label2.Name = "label2";
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.Name = "label1";
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1});
            resources.ApplyResources(this.statusStrip1, "statusStrip1");
            this.statusStrip1.Name = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            resources.ApplyResources(this.toolStripStatusLabel1, "toolStripStatusLabel1");
            // 
            // FormWebIODemo
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.gb_connection);
            this.Controls.Add(this.gb_getset);
            this.Controls.Add(this.gb_counter);
            this.Controls.Add(this.gb_inputs);
            this.Controls.Add(this.gb_outputs);
            this.Name = "FormWebIODemo";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormWebIODemo_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.gb_getset.ResumeLayout(false);
            this.gb_getset.PerformLayout();
            this.gb_connection.ResumeLayout(false);
            this.gb_connection.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox gb_outputs;
        private System.Windows.Forms.GroupBox gb_inputs;
        private System.Windows.Forms.GroupBox gb_counter;
        private System.Windows.Forms.GroupBox gb_getset;
        private System.Windows.Forms.GroupBox gb_connection;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ComboBox co_output;
        private System.Windows.Forms.ComboBox co_input;
        private System.Windows.Forms.TextBox tb_setoutputs;
        private System.Windows.Forms.Button bt_getsingleoutput;
        private System.Windows.Forms.Button bt_setoutputs;
        private System.Windows.Forms.Button bt_getsingleinput;
        private System.Windows.Forms.Button bt_getinputs;
        private System.Windows.Forms.Button bt_getoutputs;
        private System.Windows.Forms.Button bt_connect;
        private System.Windows.Forms.TextBox tb_port;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox tb_password;
        private System.Windows.Forms.TextBox tb_ip;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
    }
}

