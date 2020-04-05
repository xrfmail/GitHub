using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

namespace GameList {
	public class CheatsForm : System.Windows.Forms.Form {
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.Button button4;
		private System.Windows.Forms.Button button3;
		private System.Windows.Forms.ListView cheatbox;
		private System.Windows.Forms.ColumnHeader columnHeader1;
		private System.Windows.Forms.ColumnHeader columnHeader2;
		private System.Windows.Forms.Button cancelButton;
		private System.Windows.Forms.Button okButton;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.TextBox setupBox;
		private System.ComponentModel.IContainer components;
		private System.Windows.Forms.MainMenu mainMenu1;
		private System.Windows.Forms.MenuItem menuItem1;
		private System.Windows.Forms.MenuItem menuItem2;
		private System.Windows.Forms.MenuItem menuItem3;
		private System.Windows.Forms.MenuItem menuItem4;
		private System.Windows.Forms.MenuItem menuItem5;
		private System.Windows.Forms.MenuItem menuItem6;
		private System.Windows.Forms.MenuItem menuItem7;
		private System.Windows.Forms.MenuItem menuItem8;
		private System.Windows.Forms.MenuItem menuItem9;
		private System.Windows.Forms.MenuItem menuItem10;
		private System.Windows.Forms.ImageList imageList1;
		private PasteOptions pos = new PasteOptions();
		private Cheats cheats;
		private BoneSoft.Windows.Controls.Menus.MenuPainter mp;

		public CheatsForm() {
			InitializeComponent();
			cheats = new Cheats();

			mp = new BoneSoft.Windows.Controls.Menus.MenuPainter(this.mainMenu1, this.imageList1);
			mp.SetMenuImage(menuItem2, 0); //add
			mp.SetMenuImage(menuItem3, 6); //delete
			mp.SetMenuImage(menuItem4, 10); //paste code first
			mp.SetMenuImage(menuItem5, 10); //paste code last
			mp.SetMenuImage(menuItem6, 10); //paste special
			mp.SetMenuImage(menuItem7, 11); //copy code
			mp.SetMenuImage(menuItem8, 11); //copy entry
		}

		public CheatsForm(Cheats cheats) : this() {
			this.cheats = cheats;
			if (cheats != null) {
				this.setupBox.Text = cheats.SetupInformation;
				foreach (Cheat c in cheats.CheatCodes) {
					ListViewItem lvi = new ListViewItem(new string[] { c.Code, c.Description });
					lvi.Tag = c;
					cheatbox.Items.Add(lvi);
				}
			}
		}

		public Cheats Cheats {
			get { return cheats; }
			set { cheats = value; }
		}

		protected override void Dispose(bool disposing) {
			if (disposing) {
				if (components != null) {
					components.Dispose();
				}
			}
			base.Dispose( disposing );
		}

		#region Windows Form Designer generated code
		private void InitializeComponent() {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CheatsForm));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.setupBox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.button4 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.cheatbox = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.cancelButton = new System.Windows.Forms.Button();
            this.okButton = new System.Windows.Forms.Button();
            this.mainMenu1 = new System.Windows.Forms.MainMenu(this.components);
            this.menuItem1 = new System.Windows.Forms.MenuItem();
            this.menuItem2 = new System.Windows.Forms.MenuItem();
            this.menuItem3 = new System.Windows.Forms.MenuItem();
            this.menuItem10 = new System.Windows.Forms.MenuItem();
            this.menuItem4 = new System.Windows.Forms.MenuItem();
            this.menuItem5 = new System.Windows.Forms.MenuItem();
            this.menuItem6 = new System.Windows.Forms.MenuItem();
            this.menuItem9 = new System.Windows.Forms.MenuItem();
            this.menuItem7 = new System.Windows.Forms.MenuItem();
            this.menuItem8 = new System.Windows.Forms.MenuItem();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.setupBox);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.button4);
            this.groupBox1.Controls.Add(this.button3);
            this.groupBox1.Controls.Add(this.cheatbox);
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(292, 246);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            // 
            // setupBox
            // 
            this.setupBox.AcceptsReturn = true;
            this.setupBox.AcceptsTab = true;
            this.setupBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.setupBox.Location = new System.Drawing.Point(5, 34);
            this.setupBox.Multiline = true;
            this.setupBox.Name = "setupBox";
            this.setupBox.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.setupBox.Size = new System.Drawing.Size(283, 78);
            this.setupBox.TabIndex = 34;
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(5, 17);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(120, 17);
            this.label2.TabIndex = 33;
            this.label2.Text = "Instructions";
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(5, 116);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(120, 18);
            this.label1.TabIndex = 32;
            this.label1.Text = "Cheat Codes";
            // 
            // button4
            // 
            this.button4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button4.Font = new System.Drawing.Font("Courier New", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button4.Location = new System.Drawing.Point(240, 116);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(24, 18);
            this.button4.TabIndex = 31;
            this.button4.Text = "-";
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // button3
            // 
            this.button3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button3.Font = new System.Drawing.Font("Courier New", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button3.Location = new System.Drawing.Point(264, 116);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(24, 18);
            this.button3.TabIndex = 30;
            this.button3.Text = "+";
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // cheatbox
            // 
            this.cheatbox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cheatbox.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2});
            this.cheatbox.FullRowSelect = true;
            this.cheatbox.HideSelection = false;
            this.cheatbox.Location = new System.Drawing.Point(5, 134);
            this.cheatbox.Name = "cheatbox";
            this.cheatbox.Size = new System.Drawing.Size(283, 108);
            this.cheatbox.TabIndex = 29;
            this.cheatbox.UseCompatibleStateImageBehavior = false;
            this.cheatbox.View = System.Windows.Forms.View.Details;
            this.cheatbox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cheatbox_KeyDown);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Code";
            this.columnHeader1.Width = 75;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Description";
            this.columnHeader2.Width = 185;
            // 
            // cancelButton
            // 
            this.cancelButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cancelButton.Location = new System.Drawing.Point(115, 250);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(86, 22);
            this.cancelButton.TabIndex = 4;
            this.cancelButton.Text = "Cancel";
            this.cancelButton.Click += new System.EventHandler(this.cancelButton_Click);
            // 
            // okButton
            // 
            this.okButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.okButton.Location = new System.Drawing.Point(206, 250);
            this.okButton.Name = "okButton";
            this.okButton.Size = new System.Drawing.Size(86, 22);
            this.okButton.TabIndex = 3;
            this.okButton.Text = "Ok";
            this.okButton.Click += new System.EventHandler(this.okButton_Click);
            // 
            // mainMenu1
            // 
            this.mainMenu1.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.menuItem1});
            // 
            // menuItem1
            // 
            this.menuItem1.Index = 0;
            this.menuItem1.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.menuItem2,
            this.menuItem3,
            this.menuItem10,
            this.menuItem4,
            this.menuItem5,
            this.menuItem6,
            this.menuItem9,
            this.menuItem7,
            this.menuItem8});
            this.menuItem1.Text = "Codes";
            // 
            // menuItem2
            // 
            this.menuItem2.Index = 0;
            this.menuItem2.Shortcut = System.Windows.Forms.Shortcut.Ins;
            this.menuItem2.Text = "Add...";
            this.menuItem2.Click += new System.EventHandler(this.button3_Click);
            // 
            // menuItem3
            // 
            this.menuItem3.Index = 1;
            this.menuItem3.Text = "Delete";
            this.menuItem3.Click += new System.EventHandler(this.button4_Click);
            // 
            // menuItem10
            // 
            this.menuItem10.Index = 2;
            this.menuItem10.Text = "-";
            // 
            // menuItem4
            // 
            this.menuItem4.Index = 3;
            this.menuItem4.Text = "Paste Code First";
            this.menuItem4.Click += new System.EventHandler(this.menuItem4_Click);
            // 
            // menuItem5
            // 
            this.menuItem5.Index = 4;
            this.menuItem5.Shortcut = System.Windows.Forms.Shortcut.CtrlB;
            this.menuItem5.Text = "Paste Code Last";
            this.menuItem5.Click += new System.EventHandler(this.menuItem5_Click);
            // 
            // menuItem6
            // 
            this.menuItem6.Index = 5;
            this.menuItem6.Shortcut = System.Windows.Forms.Shortcut.CtrlShiftV;
            this.menuItem6.Text = "Paste Special...";
            this.menuItem6.Click += new System.EventHandler(this.menuItem6_Click);
            // 
            // menuItem9
            // 
            this.menuItem9.Index = 6;
            this.menuItem9.Text = "-";
            // 
            // menuItem7
            // 
            this.menuItem7.Index = 7;
            this.menuItem7.Shortcut = System.Windows.Forms.Shortcut.CtrlC;
            this.menuItem7.Text = "Copy Code";
            this.menuItem7.Click += new System.EventHandler(this.menuItem7_Click);
            // 
            // menuItem8
            // 
            this.menuItem8.Index = 8;
            this.menuItem8.Text = "Copy Entry";
            this.menuItem8.Click += new System.EventHandler(this.menuItem8_Click);
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "");
            this.imageList1.Images.SetKeyName(1, "");
            this.imageList1.Images.SetKeyName(2, "");
            this.imageList1.Images.SetKeyName(3, "");
            this.imageList1.Images.SetKeyName(4, "");
            this.imageList1.Images.SetKeyName(5, "");
            this.imageList1.Images.SetKeyName(6, "");
            this.imageList1.Images.SetKeyName(7, "");
            this.imageList1.Images.SetKeyName(8, "");
            this.imageList1.Images.SetKeyName(9, "");
            this.imageList1.Images.SetKeyName(10, "");
            this.imageList1.Images.SetKeyName(11, "");
            // 
            // CheatsForm
            // 
            this.AcceptButton = this.okButton;
            this.AutoScaleBaseSize = new System.Drawing.Size(6, 14);
            this.CancelButton = this.cancelButton;
            this.ClientSize = new System.Drawing.Size(292, 273);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.okButton);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Menu = this.mainMenu1;
            this.Name = "CheatsForm";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Cheats Info";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

		}
		#endregion

		private bool usemine = false; // false: defaults to guessing
		private PasteOptions GuessSeperator(string input) {
			string sep = string.Empty;
			input = input.Trim().Replace("\r", "");
			string[] lines = input.Split('\n');

			int sp = 0;
			int spsp = 0;
			int tab = 0;
			int spcolsp = 0;
			int spcol = 0;
			int spdashsp = 0;
			int spdash = 0;
			int speqsp = 0;
			int speq = 0;
			int linecount = 0;

			int startlength = 0;
			int endlength = 0;

			foreach (string line in lines) {
				if (line.Length < 1) { continue; }
				linecount++;
				string linet = line.Trim();
				string tempsep = "";

				string[] chunks = linet.Split(' ');
				if (chunks.Length == 2) {
					sp++;
					tempsep = " ";
				} else {
					if (linet.IndexOf("	") > -1) {
						tab++;
						tempsep = "\t";
					} else if (linet.IndexOf("  ") > -1) {
						spsp++;
						tempsep = "  ";
					}
					if (linet.IndexOf(" : ") > -1) {
						spcolsp++;
						tempsep = " : ";
					} else if (linet.IndexOf(" :") > -1) {
						spcol++;
						tempsep = " :";
					}
					if (linet.IndexOf(" - ") > -1) {
						spdashsp++;
						tempsep = " - ";
					} else if (linet.IndexOf(" -") > -1) {
						spdash++;
						tempsep = " -";
					}
					if (linet.IndexOf(" = ") > -1) {
						speqsp++;
						tempsep = " = ";
					} else if (linet.IndexOf(" =") > -1) {
						speq++;
						tempsep = " =";
					}
				}
				try {
					int pos = linet.IndexOf(tempsep);
					if (pos > startlength) {
						startlength = pos;
					}
					if ((line.Length - pos) > endlength) {
						endlength = line.Length - pos;
					}
				} catch {}
			}
			if (sp == linecount) {
				sep = " ";
			} else if (spsp == linecount) {
				sep = "  ";
			} else if (tab == linecount) {
				sep = "	";
			} else if (spcolsp == linecount) {
				sep = " : ";
			} else if (spcol == linecount) {
				sep = " :";
			} else if (spdashsp == linecount) {
				sep = " - ";
			} else if (spdash == linecount) {
				sep = " -";
			} else if (speqsp == linecount) {
				sep = " = ";
			} else if (speq == linecount) {
				sep = " =";
			}

			PasteOptions p = new PasteOptions();
			p.SeperationString = sep;
			//p.CodeFirst = endlength > startlength;
			return p;
		}

		// Remove selected entries
		private void button4_Click(object sender, System.EventArgs e) {
			if (cheatbox.SelectedItems == null) { return; }
			while (cheatbox.SelectedItems.Count > 0) {
				cheatbox.Items.Remove(cheatbox.SelectedItems[0]);
			}
		}

		// Add entry
		private void button3_Click(object sender, System.EventArgs e) {
			CheatForm cf = new CheatForm();
			if (cf.ShowDialog() == DialogResult.OK) {
				ListViewItem lvi = new ListViewItem(new string[] { cf.CheatCode, cf.CheatDescription });
				lvi.Tag = new Cheat(cf.CheatCode, cf.CheatDescription);
				cheatbox.Items.Add(lvi);
			}
		}

		private void cancelButton_Click(object sender, System.EventArgs e) {
			this.DialogResult = DialogResult.Cancel;
			this.Hide();
		}

		private void okButton_Click(object sender, System.EventArgs e) {
			if (cheats == null) {
				cheats = new Cheats();
			}
			cheats.SetupInformation = setupBox.Text;
			cheats.ClearCodes();
			foreach (ListViewItem lvi in cheatbox.Items) {
				Cheat ct = lvi.Tag as Cheat;
				if (ct == null) { continue; }
				cheats.AddCode(ct);
			}
			this.DialogResult = DialogResult.OK;
			this.Hide();
		}

//		private void PasteSpecial(object sender, System.EventArgs e) {
//			PasteOptionsForm pof = new PasteOptionsForm(pos);
//			if (pof.ShowDialog(this) == DialogResult.OK) {
//				this.pos = pos;
//				usemine = true;
//			} else {
//				usemine = false;
//			}
//			Paste(sender, e);
//		}
		private void Paste() {
			string fullinput = Clipboard.GetDataObject().GetData(typeof(string)).ToString();
			if (!usemine) {
				PasteOptions sep = GuessSeperator(fullinput);
				if (sep.SeperationString.Length > 0) {
					pos = sep;
				}
			}

			string input = fullinput.Replace("\r", "");
			string[] lines = input.Split('\n');
			foreach (string line in lines) {
				if (line.Trim().Length == 0) { continue; }
				int ndx = line.IndexOf(pos.SeperationString);
				Cheat cc = new Cheat();
				if (ndx > -1) {
					if (pos.CodeFirst) {
						cc.Code = line.Substring(0, ndx).Trim();
						if (ndx < line.Length) {
							cc.Description = line.Substring(ndx).Replace(pos.SeperationString, "").Trim();
						}
					} else {
						cc.Description = line.Substring(0, ndx).Trim();
						cc.Code = line.Substring(ndx).Replace(pos.SeperationString, "").Trim();
					}
				} else {
					cc.Code = line;
				}
				if (cc.Code != null && cc.Code.Trim().Length > 0) {
//					AddCode(cc);
					ListViewItem lvi = new ListViewItem(new string[] { cc.Code, cc.Description });
					lvi.Tag = cc;
					cheatbox.Items.Add(lvi);
				}
			}
		}
		private void cheatbox_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e) {
			if (e.KeyCode == Keys.V && e.Control) {
				if (Clipboard.GetDataObject().GetDataPresent(typeof(string))) {
					string fullinput = Clipboard.GetDataObject().GetData(typeof(string)).ToString();
//					string[] inputs = fullinput.Replace("\r", "").Split('\n');
//					foreach (string input in inputs) {
//						int ndx = input.IndexOf("\t");
//						if (ndx > -1) {
//							string code = input.Substring(0, ndx);
//							string desc = input.Substring(ndx+1);
//							ListViewItem lvi = new ListViewItem(new string[] { code, desc });
//							lvi.Tag = new Cheat(code, desc);
//							cheatbox.Items.Add(lvi);
//						}
//					}
					Paste();
				}
			} else if (e.KeyCode == Keys.Delete) {
				button4_Click(sender, EventArgs.Empty);
			}
		}

		// Paste code first
		private void menuItem4_Click(object sender, System.EventArgs e) {
			if (Clipboard.GetDataObject().GetDataPresent(typeof(string))) {
				//usemine = false;
				string fullinput = Clipboard.GetDataObject().GetData(typeof(string)).ToString();
				Paste();
			}
		}

		// Paste code last
		private void menuItem5_Click(object sender, System.EventArgs e) {
			if (Clipboard.GetDataObject().GetDataPresent(typeof(string))) {
				//usemine = false;
				pos.CodeFirst = false;
				string fullinput = Clipboard.GetDataObject().GetData(typeof(string)).ToString();
				Paste();
			}
		}

		// Paste special
		private void menuItem6_Click(object sender, System.EventArgs e) {
			if (Clipboard.GetDataObject().GetDataPresent(typeof(string))) {
				PasteOptionsForm pof = new PasteOptionsForm(pos);
				if (pof.ShowDialog(this) == DialogResult.OK) {
					usemine = true;
					pos = pof.PasteOptions;
					string fullinput = Clipboard.GetDataObject().GetData(typeof(string)).ToString();
					Paste();
				} else {
					usemine = false;
				}
			}
		}

		// Copy Code
		private void menuItem7_Click(object sender, System.EventArgs e) {
			System.Text.StringBuilder txt = new System.Text.StringBuilder();
			if (cheatbox.SelectedItems != null && cheatbox.SelectedItems.Count > 0) {
				bool first = true;
				foreach (ListViewItem lvi in cheatbox.SelectedItems) {
					Cheat cc = lvi.Tag as Cheat;
					if (cc != null) {
						if (first) { first = false; } else { txt.Append("\r\n"); }
						txt.Append(cc.Code);
					}
				}
			}
			Clipboard.SetDataObject(txt.ToString());
		}

		// Copy Entry
		private void menuItem8_Click(object sender, System.EventArgs e) {
			System.Text.StringBuilder txt = new System.Text.StringBuilder();
			if (cheatbox.SelectedItems != null && cheatbox.SelectedItems.Count > 0) {
				bool first = true;
				foreach (ListViewItem lvi in cheatbox.SelectedItems) {
					Cheat cc = lvi.Tag as Cheat;
					if (cc != null) {
						if (first) { first = false; } else { txt.Append("\r\n"); }
						txt.AppendFormat("{0}{1}{2}", cc.Code, pos.SeperationString, cc.Description);
					}
				}
			}
			Clipboard.SetDataObject(txt.ToString());
		}
	}
}