using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

namespace GameList {
	public class StatsForm : System.Windows.Forms.Form {
		private System.Windows.Forms.ListView listView1;
		private System.Windows.Forms.Button button1;
		private System.Windows.Forms.ColumnHeader columnHeader1;
		private System.Windows.Forms.ColumnHeader columnHeader2;
		private System.ComponentModel.Container components = null;
		private GameCatalog game;

		public StatsForm(GameCatalog game) {
			InitializeComponent();
			this.game = game;
			UpdateUI();
		}

		private void UpdateUI() {
			StatsCounter counter = new StatsCounter();
			foreach (Game g in game.Games) {
				counter.Add("Genre " + g.Genre.ToString());
			}
			foreach (Game g in game.Games) {
				if (g.Developer != null && g.Developer.Name != null && !g.Developer.Name.Equals(string.Empty)) {
					counter.Add("Developer " + g.Developer.Name);
				}
			}
			foreach (Game g in game.Games) {
				if (g.Publisher != null && g.Publisher.Name != null && !g.Publisher.Name.Equals(string.Empty)) {
					counter.Add("Publisher " + g.Publisher.Name);
				}
			}
			foreach (Game g in game.Games) {
				if (g.CDKey == null) {
					counter.Add("Unknown");
				} else if (g.CDKey.Equals("Copied")) {
					counter.Add("Ripped");
				} else if (g.CDKey.Equals("Download")) {
					counter.Add("Free");
				} else {
					counter.Add("Owned");
				}
			}

			for (int i = 0; i < counter.Count; i++) {
				Stat st = counter[i];
				AddItem(st.Text, st.Count);
			}
		}

		private void AddItem(string text, int count) {
			ListViewItem lvi = new ListViewItem(text);
			lvi.SubItems.Add(count.ToString());
			listView1.Items.Add(lvi);
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
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(StatsForm));
			this.listView1 = new System.Windows.Forms.ListView();
			this.columnHeader1 = new System.Windows.Forms.ColumnHeader();
			this.columnHeader2 = new System.Windows.Forms.ColumnHeader();
			this.button1 = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// listView1
			// 
			this.listView1.AllowColumnReorder = true;
			this.listView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
				| System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.listView1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
																						this.columnHeader1,
																						this.columnHeader2});
			this.listView1.FullRowSelect = true;
			this.listView1.GridLines = true;
			this.listView1.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
			this.listView1.HideSelection = false;
			this.listView1.Location = new System.Drawing.Point(0, 0);
			this.listView1.Name = "listView1";
			this.listView1.Size = new System.Drawing.Size(221, 153);
			this.listView1.TabIndex = 0;
			this.listView1.View = System.Windows.Forms.View.Details;
			// 
			// columnHeader1
			// 
			this.columnHeader1.Text = "Stat";
			this.columnHeader1.Width = 151;
			// 
			// columnHeader2
			// 
			this.columnHeader2.Text = "Value";
			this.columnHeader2.Width = 48;
			// 
			// button1
			// 
			this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.button1.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.button1.Location = new System.Drawing.Point(164, 156);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(56, 20);
			this.button1.TabIndex = 1;
			this.button1.Text = "Close";
			this.button1.Click += new System.EventHandler(this.button1_Click);
			// 
			// StatsForm
			// 
			this.AcceptButton = this.button1;
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.CancelButton = this.button1;
			this.ClientSize = new System.Drawing.Size(220, 176);
			this.Controls.Add(this.button1);
			this.Controls.Add(this.listView1);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.Name = "StatsForm";
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Statistics";
			this.ResumeLayout(false);

		}
		#endregion

		private void button1_Click(object sender, System.EventArgs e) {
			this.Close();
		}
	}
}