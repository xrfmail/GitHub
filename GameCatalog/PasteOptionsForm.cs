using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

namespace GameList {
	public class PasteOptionsForm : System.Windows.Forms.Form {
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.TextBox txtSepString;
		private System.Windows.Forms.CheckBox chkCodeFirst;
		private System.Windows.Forms.Button btnOk;
		private System.Windows.Forms.Button btnCancel;
		private System.ComponentModel.Container components = null;
		private PasteOptions pos;

		public PasteOptionsForm() {
			InitializeComponent();
			pos = new PasteOptions();
			UpdateUI();
		}

		public PasteOptionsForm(PasteOptions pos) {
			InitializeComponent();
			this.pos = pos;
			UpdateUI();
		}

		private void UpdateUI() {
			this.txtSepString.Text = pos.SeperationString;
			this.chkCodeFirst.Checked = pos.CodeFirst;
		}
		private void UpdateObject() {
			pos.SeperationString = this.txtSepString.Text;
			pos.CodeFirst = this.chkCodeFirst.Checked;
		}

		protected override void Dispose(bool disposing) {
			if (disposing) {
				if (components != null) {
					components.Dispose();
				}
			}
			base.Dispose( disposing );
		}

		public PasteOptions PasteOptions {
			get { return pos; }
			set { pos = value; }
		}

		#region Windows Form Designer generated code
		private void InitializeComponent() {
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(PasteOptionsForm));
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.btnCancel = new System.Windows.Forms.Button();
			this.label1 = new System.Windows.Forms.Label();
			this.btnOk = new System.Windows.Forms.Button();
			this.chkCodeFirst = new System.Windows.Forms.CheckBox();
			this.txtSepString = new System.Windows.Forms.TextBox();
			this.groupBox1.SuspendLayout();
			this.SuspendLayout();
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.btnCancel);
			this.groupBox1.Controls.Add(this.label1);
			this.groupBox1.Controls.Add(this.btnOk);
			this.groupBox1.Controls.Add(this.chkCodeFirst);
			this.groupBox1.Controls.Add(this.txtSepString);
			this.groupBox1.Location = new System.Drawing.Point(0, 0);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(256, 96);
			this.groupBox1.TabIndex = 0;
			this.groupBox1.TabStop = false;
			// 
			// btnCancel
			// 
			this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.btnCancel.Location = new System.Drawing.Point(96, 68);
			this.btnCancel.Name = "btnCancel";
			this.btnCancel.Size = new System.Drawing.Size(75, 20);
			this.btnCancel.TabIndex = 4;
			this.btnCancel.Text = "Cancel";
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(4, 20);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(92, 16);
			this.label1.TabIndex = 3;
			this.label1.Text = "Seperation String";
			// 
			// btnOk
			// 
			this.btnOk.Location = new System.Drawing.Point(176, 68);
			this.btnOk.Name = "btnOk";
			this.btnOk.Size = new System.Drawing.Size(75, 20);
			this.btnOk.TabIndex = 2;
			this.btnOk.Text = "Ok";
			this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
			// 
			// chkCodeFirst
			// 
			this.chkCodeFirst.Checked = true;
			this.chkCodeFirst.CheckState = System.Windows.Forms.CheckState.Checked;
			this.chkCodeFirst.Location = new System.Drawing.Point(100, 40);
			this.chkCodeFirst.Name = "chkCodeFirst";
			this.chkCodeFirst.Size = new System.Drawing.Size(152, 24);
			this.chkCodeFirst.TabIndex = 1;
			this.chkCodeFirst.Text = "Code First";
			// 
			// txtSepString
			// 
			this.txtSepString.Location = new System.Drawing.Point(100, 16);
			this.txtSepString.Name = "txtSepString";
			this.txtSepString.Size = new System.Drawing.Size(152, 20);
			this.txtSepString.TabIndex = 0;
			this.txtSepString.Text = "";
			// 
			// PasteOptionsForm
			// 
			this.AcceptButton = this.btnOk;
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.CancelButton = this.btnCancel;
			this.ClientSize = new System.Drawing.Size(256, 98);
			this.Controls.Add(this.groupBox1);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.Name = "PasteOptionsForm";
			this.ShowInTaskbar = false;
			this.Text = "Paste Options";
			this.groupBox1.ResumeLayout(false);
			this.ResumeLayout(false);

		}
		#endregion

		private void btnOk_Click(object sender, System.EventArgs e) {
			UpdateObject();
			DialogResult = DialogResult.OK;
			this.Hide();
		}
	}

	public class PasteOptions {
		private bool codefirst = true;
		private string seperationstring = "  ";

		public bool CodeFirst {
			get { return codefirst; }
			set { codefirst = value; }
		}

		public string SeperationString {
			get { return seperationstring; }
			set { seperationstring = value; }
		}
	}
}