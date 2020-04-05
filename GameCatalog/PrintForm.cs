using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Xml;

namespace GameList {
	public class PrintForm : System.Windows.Forms.Form {
		private AxSHDocVw.AxWebBrowser axWebBrowser1;
		private System.ComponentModel.IContainer components;
		private System.Windows.Forms.ImageList imageList1;
		private BoneSoft.Windows.Controls.Menus.MenuPainter mp;
		private System.Windows.Forms.MainMenu mainMenu1;
		private System.Windows.Forms.MenuItem menuItem1;
		private System.Windows.Forms.MenuItem menuItem2;
		private System.Windows.Forms.MenuItem menuItem3;
		private System.Windows.Forms.MenuItem menuItem4;
		private GameCatalog games;

		public PrintForm() {
			InitializeComponent();
			PaintMenu();
		}

		public PrintForm(GameCatalog gcat) : this() {
			this.games = gcat;
			Init();
		}

		public PrintForm(Games games) : this() {
			this.games = new GameCatalog();
			this.games.Games = games;
			Init();
		}

		private void PaintMenu() {
			mp = new BoneSoft.Windows.Controls.Menus.MenuPainter(this.mainMenu1, this.imageList1);
			mp.SetMenuImage(menuItem4, 10);
		}

		private void Init() {
			try {
				string basepath = System.Reflection.Assembly.GetExecutingAssembly().CodeBase.Replace("file:///", "").Replace("/", @"\");
				basepath = System.IO.Path.GetDirectoryName(basepath) + @"\";

				GameCatalogSerializer gcs = new GameCatalogSerializer();
				XmlDocument doc = gcs.Serialize(games);

				System.Xml.XPath.XPathNavigator nav = doc.CreateNavigator();
				System.Xml.Xsl.XslTransform xt = new System.Xml.Xsl.XslTransform();
				System.Xml.XmlResolver res = new System.Xml.XmlUrlResolver();
				System.IO.StringWriter writer = new System.IO.StringWriter();
				System.Xml.Xsl.XsltArgumentList args = new System.Xml.Xsl.XsltArgumentList();

				System.Xml.XmlNameTable xnt = new System.Xml.NameTable();
				System.Xml.XmlReader xslt = new System.Xml.XmlTextReader(new System.IO.StreamReader(basepath + "GameList.xslt"), xnt);

				xt.Load(xslt, res, new System.Security.Policy.Evidence());
				xt.Transform(nav, args, writer, res);

				string html = writer.ToString();

				WriteHTML(html);
			} catch (Exception ex) {
				string error = "There was an error generating HTML";
				Exception xe = ex;
				while (xe != null) {
					error += "<p><b>" + xe.Message + "</b><br><pre>" + xe.StackTrace + "</pre></p>\r\n";
				}
				WriteHTML(error);
			}
		}

		private void WriteHTML(string html) {
			string basepath = System.Reflection.Assembly.GetExecutingAssembly().CodeBase.Replace("file:///", "").Replace("/", @"\");
			basepath = System.IO.Path.GetDirectoryName(basepath) + @"\";
			using (System.IO.StreamWriter hwriter = new System.IO.StreamWriter(basepath + "print.html", false)) {
				hwriter.Write(html);
				hwriter.Flush();
				hwriter.Close();
			}
			object thingy = null;
			axWebBrowser1.Navigate(basepath + "print.html", ref thingy, ref thingy, ref thingy, ref thingy);
		}

		private void Print() {
			Object o = null;
			axWebBrowser1.ExecWB(SHDocVw.OLECMDID.OLECMDID_PRINT, SHDocVw.OLECMDEXECOPT.OLECMDEXECOPT_DONTPROMPTUSER, ref o, ref o);
		}
		private void PrintPreview() {
			Object o = null;
			axWebBrowser1.ExecWB(SHDocVw.OLECMDID.OLECMDID_PRINTPREVIEW, SHDocVw.OLECMDEXECOPT.OLECMDEXECOPT_DODEFAULT, ref o, ref o);
		}
		private void PageSetup() {
			Object o = null;
			axWebBrowser1.ExecWB(SHDocVw.OLECMDID.OLECMDID_PAGESETUP, SHDocVw.OLECMDEXECOPT.OLECMDEXECOPT_DODEFAULT, ref o, ref o);
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
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(PrintForm));
			this.axWebBrowser1 = new AxSHDocVw.AxWebBrowser();
			this.imageList1 = new System.Windows.Forms.ImageList(this.components);
			this.mainMenu1 = new System.Windows.Forms.MainMenu();
			this.menuItem1 = new System.Windows.Forms.MenuItem();
			this.menuItem2 = new System.Windows.Forms.MenuItem();
			this.menuItem3 = new System.Windows.Forms.MenuItem();
			this.menuItem4 = new System.Windows.Forms.MenuItem();
			((System.ComponentModel.ISupportInitialize)(this.axWebBrowser1)).BeginInit();
			this.SuspendLayout();
			// 
			// axWebBrowser1
			// 
			this.axWebBrowser1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.axWebBrowser1.Enabled = true;
			this.axWebBrowser1.Location = new System.Drawing.Point(0, 0);
			this.axWebBrowser1.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("axWebBrowser1.OcxState")));
			this.axWebBrowser1.Size = new System.Drawing.Size(292, 273);
			this.axWebBrowser1.TabIndex = 0;
			// 
			// imageList1
			// 
			this.imageList1.ImageSize = new System.Drawing.Size(16, 16);
			this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
			this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
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
																					  this.menuItem4});
			this.menuItem1.Text = "File";
			// 
			// menuItem2
			// 
			this.menuItem2.Index = 0;
			this.menuItem2.Text = "Page Setup...";
			this.menuItem2.Click += new System.EventHandler(this.menuPageSetup);
			// 
			// menuItem3
			// 
			this.menuItem3.Index = 1;
			this.menuItem3.Text = "Print Preview...";
			this.menuItem3.Click += new System.EventHandler(this.menuPrintPreview);
			// 
			// menuItem4
			// 
			this.menuItem4.Index = 2;
			this.menuItem4.Shortcut = System.Windows.Forms.Shortcut.CtrlP;
			this.menuItem4.Text = "Print";
			this.menuItem4.Click += new System.EventHandler(this.menuPrint);
			// 
			// PrintForm
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(292, 273);
			this.Controls.Add(this.axWebBrowser1);
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.Name = "PrintForm";
			this.Text = "PrintForm";
			((System.ComponentModel.ISupportInitialize)(this.axWebBrowser1)).EndInit();
			this.ResumeLayout(false);

		}
		#endregion

		private void menuPrint(object sender, System.EventArgs e) {
			Print();
		}

		private void menuPrintPreview(object sender, System.EventArgs e) {
			PrintPreview();
		}

		private void menuPageSetup(object sender, System.EventArgs e) {
			PageSetup();
		}
	}
}