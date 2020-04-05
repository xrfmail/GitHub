using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

namespace GameList {
	public class GameForm : System.Windows.Forms.Form {
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.Label label8;
		private System.Windows.Forms.Label label10;
		private System.Windows.Forms.Label label11;
		private System.Windows.Forms.Label label13;
		private System.Windows.Forms.Button button1;
		private System.Windows.Forms.Button button2;
		private System.Windows.Forms.TextBox namebox;
		private System.Windows.Forms.TextBox isbnbox;
		private System.Windows.Forms.TextBox cdkeybox;
		private System.Windows.Forms.TextBox urlbox;
		private System.Windows.Forms.TextBox devurlbox;
		private System.Windows.Forms.TextBox devnamebox;
		private System.Windows.Forms.TextBox puburlbox;
		private System.Windows.Forms.TextBox pubnamebox;
		private System.Windows.Forms.RichTextBox patchbox;
		private System.Windows.Forms.RichTextBox walkbox;
		private System.ComponentModel.Container components = null;
		private System.Windows.Forms.Label label14;
		private System.Windows.Forms.ComboBox genreBox;
		private System.Windows.Forms.Button button3;

		private Game game;

		public GameForm() {
			InitializeComponent();
			this.game = new Game();
			foreach (string s in Enum.GetNames(typeof(Genre))) {
				genreBox.Items.Add(Enum.Parse(typeof(Genre), s, true));
			}
		}

		public GameForm(Game game) : this() {
			this.game = game;
			UpdateUI();
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
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(GameForm));
			this.label1 = new System.Windows.Forms.Label();
			this.namebox = new System.Windows.Forms.TextBox();
			this.isbnbox = new System.Windows.Forms.TextBox();
			this.label2 = new System.Windows.Forms.Label();
			this.cdkeybox = new System.Windows.Forms.TextBox();
			this.label3 = new System.Windows.Forms.Label();
			this.urlbox = new System.Windows.Forms.TextBox();
			this.label4 = new System.Windows.Forms.Label();
			this.label5 = new System.Windows.Forms.Label();
			this.devurlbox = new System.Windows.Forms.TextBox();
			this.label6 = new System.Windows.Forms.Label();
			this.devnamebox = new System.Windows.Forms.TextBox();
			this.puburlbox = new System.Windows.Forms.TextBox();
			this.label8 = new System.Windows.Forms.Label();
			this.pubnamebox = new System.Windows.Forms.TextBox();
			this.label10 = new System.Windows.Forms.Label();
			this.label11 = new System.Windows.Forms.Label();
			this.patchbox = new System.Windows.Forms.RichTextBox();
			this.walkbox = new System.Windows.Forms.RichTextBox();
			this.label13 = new System.Windows.Forms.Label();
			this.button1 = new System.Windows.Forms.Button();
			this.button2 = new System.Windows.Forms.Button();
			this.label14 = new System.Windows.Forms.Label();
			this.genreBox = new System.Windows.Forms.ComboBox();
			this.button3 = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(0, 8);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(56, 16);
			this.label1.TabIndex = 0;
			this.label1.Text = "Name";
			// 
			// namebox
			// 
			this.namebox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.namebox.Location = new System.Drawing.Point(56, 4);
			this.namebox.Name = "namebox";
			this.namebox.Size = new System.Drawing.Size(248, 20);
			this.namebox.TabIndex = 0;
			this.namebox.Text = "";
			// 
			// isbnbox
			// 
			this.isbnbox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.isbnbox.Location = new System.Drawing.Point(208, 28);
			this.isbnbox.Name = "isbnbox";
			this.isbnbox.Size = new System.Drawing.Size(96, 20);
			this.isbnbox.TabIndex = 1;
			this.isbnbox.Text = "";
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(160, 32);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(48, 16);
			this.label2.TabIndex = 2;
			this.label2.Text = "ASIN";
			// 
			// cdkeybox
			// 
			this.cdkeybox.Location = new System.Drawing.Point(56, 28);
			this.cdkeybox.Name = "cdkeybox";
			this.cdkeybox.Size = new System.Drawing.Size(96, 20);
			this.cdkeybox.TabIndex = 2;
			this.cdkeybox.Text = "";
			// 
			// label3
			// 
			this.label3.Location = new System.Drawing.Point(0, 32);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(56, 16);
			this.label3.TabIndex = 4;
			this.label3.Text = "CD Key";
			// 
			// urlbox
			// 
			this.urlbox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.urlbox.Location = new System.Drawing.Point(208, 52);
			this.urlbox.Name = "urlbox";
			this.urlbox.Size = new System.Drawing.Size(96, 20);
			this.urlbox.TabIndex = 4;
			this.urlbox.Text = "";
			// 
			// label4
			// 
			this.label4.Location = new System.Drawing.Point(160, 56);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(48, 16);
			this.label4.TabIndex = 6;
			this.label4.Text = "URL";
			// 
			// label5
			// 
			this.label5.Location = new System.Drawing.Point(0, 80);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(56, 16);
			this.label5.TabIndex = 8;
			this.label5.Text = "Developer";
			// 
			// devurlbox
			// 
			this.devurlbox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.devurlbox.Location = new System.Drawing.Point(208, 76);
			this.devurlbox.Name = "devurlbox";
			this.devurlbox.Size = new System.Drawing.Size(96, 20);
			this.devurlbox.TabIndex = 6;
			this.devurlbox.Text = "";
			// 
			// label6
			// 
			this.label6.Location = new System.Drawing.Point(160, 80);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(48, 16);
			this.label6.TabIndex = 11;
			this.label6.Text = "URL";
			// 
			// devnamebox
			// 
			this.devnamebox.Location = new System.Drawing.Point(56, 76);
			this.devnamebox.Name = "devnamebox";
			this.devnamebox.Size = new System.Drawing.Size(96, 20);
			this.devnamebox.TabIndex = 5;
			this.devnamebox.Text = "";
			// 
			// puburlbox
			// 
			this.puburlbox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.puburlbox.Location = new System.Drawing.Point(208, 100);
			this.puburlbox.Name = "puburlbox";
			this.puburlbox.Size = new System.Drawing.Size(96, 20);
			this.puburlbox.TabIndex = 8;
			this.puburlbox.Text = "";
			// 
			// label8
			// 
			this.label8.Location = new System.Drawing.Point(160, 104);
			this.label8.Name = "label8";
			this.label8.Size = new System.Drawing.Size(48, 16);
			this.label8.TabIndex = 16;
			this.label8.Text = "URL";
			// 
			// pubnamebox
			// 
			this.pubnamebox.Location = new System.Drawing.Point(56, 100);
			this.pubnamebox.Name = "pubnamebox";
			this.pubnamebox.Size = new System.Drawing.Size(96, 20);
			this.pubnamebox.TabIndex = 7;
			this.pubnamebox.Text = "";
			// 
			// label10
			// 
			this.label10.Location = new System.Drawing.Point(0, 104);
			this.label10.Name = "label10";
			this.label10.Size = new System.Drawing.Size(56, 16);
			this.label10.TabIndex = 13;
			this.label10.Text = "Publisher";
			// 
			// label11
			// 
			this.label11.Location = new System.Drawing.Point(0, 128);
			this.label11.Name = "label11";
			this.label11.Size = new System.Drawing.Size(72, 16);
			this.label11.TabIndex = 18;
			this.label11.Text = "Patch Info";
			// 
			// patchbox
			// 
			this.patchbox.AcceptsTab = true;
			this.patchbox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.patchbox.HideSelection = false;
			this.patchbox.Location = new System.Drawing.Point(0, 144);
			this.patchbox.Name = "patchbox";
			this.patchbox.Size = new System.Drawing.Size(304, 44);
			this.patchbox.TabIndex = 9;
			this.patchbox.Text = "";
			// 
			// walkbox
			// 
			this.walkbox.AcceptsTab = true;
			this.walkbox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
				| System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.walkbox.HideSelection = false;
			this.walkbox.Location = new System.Drawing.Point(0, 212);
			this.walkbox.Name = "walkbox";
			this.walkbox.Size = new System.Drawing.Size(304, 76);
			this.walkbox.TabIndex = 11;
			this.walkbox.Text = "";
			// 
			// label13
			// 
			this.label13.Location = new System.Drawing.Point(0, 196);
			this.label13.Name = "label13";
			this.label13.Size = new System.Drawing.Size(72, 16);
			this.label13.TabIndex = 22;
			this.label13.Text = "Walkthrough";
			// 
			// button1
			// 
			this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.button1.Location = new System.Drawing.Point(232, 292);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(72, 20);
			this.button1.TabIndex = 12;
			this.button1.Text = "Ok";
			this.button1.Click += new System.EventHandler(this.button1_Click);
			// 
			// button2
			// 
			this.button2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.button2.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.button2.Location = new System.Drawing.Point(156, 292);
			this.button2.Name = "button2";
			this.button2.Size = new System.Drawing.Size(72, 20);
			this.button2.TabIndex = 13;
			this.button2.Text = "Cancel";
			// 
			// label14
			// 
			this.label14.Location = new System.Drawing.Point(0, 56);
			this.label14.Name = "label14";
			this.label14.Size = new System.Drawing.Size(56, 16);
			this.label14.TabIndex = 26;
			this.label14.Text = "Genre";
			// 
			// genreBox
			// 
			this.genreBox.Location = new System.Drawing.Point(56, 52);
			this.genreBox.Name = "genreBox";
			this.genreBox.Size = new System.Drawing.Size(96, 21);
			this.genreBox.TabIndex = 3;
			// 
			// button3
			// 
			this.button3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.button3.Location = new System.Drawing.Point(0, 292);
			this.button3.Name = "button3";
			this.button3.Size = new System.Drawing.Size(72, 20);
			this.button3.TabIndex = 27;
			this.button3.Text = "Cheats";
			this.button3.Click += new System.EventHandler(this.button3_Click);
			// 
			// GameForm
			// 
			this.AcceptButton = this.button1;
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.CancelButton = this.button2;
			this.ClientSize = new System.Drawing.Size(304, 312);
			this.Controls.Add(this.button3);
			this.Controls.Add(this.genreBox);
			this.Controls.Add(this.label14);
			this.Controls.Add(this.button2);
			this.Controls.Add(this.button1);
			this.Controls.Add(this.walkbox);
			this.Controls.Add(this.label13);
			this.Controls.Add(this.patchbox);
			this.Controls.Add(this.label11);
			this.Controls.Add(this.puburlbox);
			this.Controls.Add(this.pubnamebox);
			this.Controls.Add(this.devurlbox);
			this.Controls.Add(this.devnamebox);
			this.Controls.Add(this.urlbox);
			this.Controls.Add(this.cdkeybox);
			this.Controls.Add(this.isbnbox);
			this.Controls.Add(this.namebox);
			this.Controls.Add(this.label8);
			this.Controls.Add(this.label10);
			this.Controls.Add(this.label6);
			this.Controls.Add(this.label5);
			this.Controls.Add(this.label4);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.label1);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.Name = "GameForm";
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Game Info";
			this.ResumeLayout(false);

		}
		#endregion

		public Game Game {
			get { return game; }
			set {
				game = value;
				UpdateUI();
			}
		}

		private void UpdateUI() {
			namebox.Text = game.Name;
			isbnbox.Text = game.Isbn;
			cdkeybox.Text = game.CDKey;
			urlbox.Text = game.Url;
			for (int i = 0; i < genreBox.Items.Count; i++) {
				if ((Genre)genreBox.Items[i] == game.Genre) {
					genreBox.SelectedIndex = i;
					break;
				}
			}
			if (game.Developer != null) {
				devnamebox.Text = game.Developer.Name;
				devurlbox.Text = game.Developer.Url;
			}
			if (game.Publisher != null) {
				pubnamebox.Text = game.Publisher.Name;
				puburlbox.Text = game.Publisher.Url;
			}
			patchbox.Text = game.PatchInfo;
			//cheatbox.Text = game.Cheat;
			walkbox.Text = game.Walkthrough;
		}

		private void UpdateObject() {
			game.Name = namebox.Text;
			game.Isbn = isbnbox.Text;
			game.CDKey = cdkeybox.Text;
			game.Url = urlbox.Text;
			if (genreBox.SelectedItem != null) {
				game.Genre = (Genre)genreBox.SelectedItem;
			}
			if (!devnamebox.Text.Equals(string.Empty) || !devurlbox.Text.Equals(string.Empty)) {
				game.Developer = new Company(devnamebox.Text, devurlbox.Text);
			}
			if (!pubnamebox.Text.Equals(string.Empty) || !puburlbox.Text.Equals(string.Empty)) {
				game.Publisher = new Company(pubnamebox.Text, puburlbox.Text);
			}
			game.PatchInfo = patchbox.Text;
			//game.Cheat = cheatbox.Text;
			game.Walkthrough = walkbox.Text;
		}

		private void button1_Click(object sender, System.EventArgs e) {
			UpdateObject();
			this.DialogResult = DialogResult.OK;
			this.Hide();
		}

		private void button3_Click(object sender, System.EventArgs e) {
			CheatsForm cf = new CheatsForm(game.Cheats);
			if (cf.ShowDialog(this) == DialogResult.OK) {
				game.Cheats = cf.Cheats;
			}
		}
	}
}