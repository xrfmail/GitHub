using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;

namespace GameList {
	public class Form1 : System.Windows.Forms.Form {
		private System.Windows.Forms.ImageList imageList1;
		private System.Windows.Forms.MainMenu mainMenu1;
		private System.Windows.Forms.MenuItem menuItem1;
		private System.Windows.Forms.MenuItem menuItem2;
		private System.Windows.Forms.MenuItem menuItem3;
		private System.Windows.Forms.MenuItem menuItem4;
		private System.Windows.Forms.MenuItem menuItem8;
		private System.Windows.Forms.MenuItem menuItem9;
		private System.Windows.Forms.MenuItem menuItem10;
		private System.Windows.Forms.MenuItem menuItem11;
		private System.Windows.Forms.MenuItem menuItem12;
		private System.Windows.Forms.MenuItem menuItem6;
		private System.Windows.Forms.MenuItem menuItem7;
		private System.ComponentModel.IContainer components;
		private System.Windows.Forms.ListView gamelist;
		private System.Windows.Forms.OpenFileDialog ofd;
		private System.Windows.Forms.SaveFileDialog sfd;
		private System.Windows.Forms.ContextMenu contextMenu1;
		private System.Windows.Forms.MenuItem ctxAdd;
		private System.Windows.Forms.MenuItem ctxRemove;
		private System.Windows.Forms.MenuItem ctxEdit;
		private System.Windows.Forms.MenuItem menuItem5;
		private System.Windows.Forms.MenuItem menuItem13;
		private System.Windows.Forms.MenuItem menuItem14;
		private System.Windows.Forms.MenuItem menuItem15;
		private System.Windows.Forms.MenuItem menuItem16;
		private System.Windows.Forms.ColumnHeader columnHeader1;
		private System.Windows.Forms.ColumnHeader columnHeader2;
		private System.Windows.Forms.ColumnHeader columnHeader3;
		private System.Windows.Forms.ColumnHeader columnHeader4;
		private System.Windows.Forms.MenuItem menuItem17;
		private System.Windows.Forms.MenuItem menuItem18;
		private System.Windows.Forms.MenuItem sortName;
		private System.Windows.Forms.MenuItem sortGenre;
		private System.Windows.Forms.MenuItem sortDev;
		private System.Windows.Forms.MenuItem sortPub;
		private System.Windows.Forms.StatusBar statusBar1;
		private System.Windows.Forms.MenuItem menuItem19;
		private System.Windows.Forms.MenuItem menuItem20;
		private System.Windows.Forms.MenuItem menuItem21;

		#region My Privates
		private BoneSoft.Windows.Controls.Menus.MenuPainter mp;
		private string filename;
		private GameCatalog games;
		private bool dirty = false;
		#endregion

		public Form1() {
			InitializeComponent();
			PaintMenu();
			games = new GameCatalog();
		}

		public Form1(string filename) {
			InitializeComponent();
			PaintMenu();
			OpenFile(filename);
		}

		private void PaintMenu() {
			mp = new BoneSoft.Windows.Controls.Menus.MenuPainter(this.mainMenu1, this.imageList1);
			mp.SetMenuImage(menuItem9, 4);
			mp.SetMenuImage(menuItem10, 5);
			mp.SetMenuImage(menuItem12, 8);
			mp.SetMenuImage(menuItem7, 2);
			mp.SetMenuImage(menuItem2, 0);
			mp.SetMenuImage(menuItem3, 6);
			mp.SetMenuImage(menuItem4, 1); //7
			mp.SetMenuImage(ctxAdd, 0);
			mp.SetMenuImage(ctxRemove, 6);
			mp.SetMenuImage(ctxEdit, 1); //7
			mp.SetMenuImage(menuItem13, 9);
			mp.SetMenuImage(menuItem21, 10);
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
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(Form1));
			this.imageList1 = new System.Windows.Forms.ImageList(this.components);
			this.gamelist = new System.Windows.Forms.ListView();
			this.columnHeader1 = new System.Windows.Forms.ColumnHeader();
			this.columnHeader2 = new System.Windows.Forms.ColumnHeader();
			this.columnHeader3 = new System.Windows.Forms.ColumnHeader();
			this.columnHeader4 = new System.Windows.Forms.ColumnHeader();
			this.contextMenu1 = new System.Windows.Forms.ContextMenu();
			this.ctxAdd = new System.Windows.Forms.MenuItem();
			this.ctxEdit = new System.Windows.Forms.MenuItem();
			this.ctxRemove = new System.Windows.Forms.MenuItem();
			this.mainMenu1 = new System.Windows.Forms.MainMenu();
			this.menuItem8 = new System.Windows.Forms.MenuItem();
			this.menuItem9 = new System.Windows.Forms.MenuItem();
			this.menuItem10 = new System.Windows.Forms.MenuItem();
			this.menuItem11 = new System.Windows.Forms.MenuItem();
			this.menuItem12 = new System.Windows.Forms.MenuItem();
			this.menuItem6 = new System.Windows.Forms.MenuItem();
			this.menuItem7 = new System.Windows.Forms.MenuItem();
			this.menuItem1 = new System.Windows.Forms.MenuItem();
			this.menuItem2 = new System.Windows.Forms.MenuItem();
			this.menuItem4 = new System.Windows.Forms.MenuItem();
			this.menuItem3 = new System.Windows.Forms.MenuItem();
			this.menuItem14 = new System.Windows.Forms.MenuItem();
			this.menuItem15 = new System.Windows.Forms.MenuItem();
			this.menuItem16 = new System.Windows.Forms.MenuItem();
			this.menuItem17 = new System.Windows.Forms.MenuItem();
			this.menuItem18 = new System.Windows.Forms.MenuItem();
			this.sortName = new System.Windows.Forms.MenuItem();
			this.sortGenre = new System.Windows.Forms.MenuItem();
			this.sortDev = new System.Windows.Forms.MenuItem();
			this.sortPub = new System.Windows.Forms.MenuItem();
			this.menuItem19 = new System.Windows.Forms.MenuItem();
			this.menuItem20 = new System.Windows.Forms.MenuItem();
			this.menuItem5 = new System.Windows.Forms.MenuItem();
			this.menuItem13 = new System.Windows.Forms.MenuItem();
			this.ofd = new System.Windows.Forms.OpenFileDialog();
			this.sfd = new System.Windows.Forms.SaveFileDialog();
			this.statusBar1 = new System.Windows.Forms.StatusBar();
			this.menuItem21 = new System.Windows.Forms.MenuItem();
			this.SuspendLayout();
			// 
			// imageList1
			// 
			this.imageList1.ImageSize = new System.Drawing.Size(16, 16);
			this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
			this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
			// 
			// gamelist
			// 
			this.gamelist.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
																					   this.columnHeader1,
																					   this.columnHeader2,
																					   this.columnHeader3,
																					   this.columnHeader4});
			this.gamelist.ContextMenu = this.contextMenu1;
			this.gamelist.Dock = System.Windows.Forms.DockStyle.Fill;
			this.gamelist.FullRowSelect = true;
			this.gamelist.HideSelection = false;
			this.gamelist.LabelEdit = true;
			this.gamelist.Location = new System.Drawing.Point(0, 0);
			this.gamelist.Name = "gamelist";
			this.gamelist.Size = new System.Drawing.Size(332, 221);
			this.gamelist.SmallImageList = this.imageList1;
			this.gamelist.TabIndex = 0;
			this.gamelist.View = System.Windows.Forms.View.Details;
			this.gamelist.DoubleClick += new System.EventHandler(this.gamelist_DoubleClick);
			this.gamelist.AfterLabelEdit += new System.Windows.Forms.LabelEditEventHandler(this.gamelist_AfterLabelEdit);
			this.gamelist.ColumnClick += new System.Windows.Forms.ColumnClickEventHandler(this.gamelist_ColumnClick);
			this.gamelist.SelectedIndexChanged += new System.EventHandler(this.gamelist_SelectedIndexChanged);
			// 
			// columnHeader1
			// 
			this.columnHeader1.Text = "Name";
			this.columnHeader1.Width = 111;
			// 
			// columnHeader2
			// 
			this.columnHeader2.Text = "Genre";
			this.columnHeader2.Width = 67;
			// 
			// columnHeader3
			// 
			this.columnHeader3.Text = "Developer";
			this.columnHeader3.Width = 65;
			// 
			// columnHeader4
			// 
			this.columnHeader4.Text = "Publisher";
			this.columnHeader4.Width = 67;
			// 
			// contextMenu1
			// 
			this.contextMenu1.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
																						 this.ctxAdd,
																						 this.ctxEdit,
																						 this.ctxRemove});
			this.contextMenu1.Popup += new System.EventHandler(this.contextMenu1_Popup);
			// 
			// ctxAdd
			// 
			this.ctxAdd.Index = 0;
			this.ctxAdd.Shortcut = System.Windows.Forms.Shortcut.Ins;
			this.ctxAdd.Text = "Add";
			this.ctxAdd.Click += new System.EventHandler(this.menuItem2_Click);
			// 
			// ctxEdit
			// 
			this.ctxEdit.Index = 1;
			this.ctxEdit.Shortcut = System.Windows.Forms.Shortcut.F2;
			this.ctxEdit.Text = "Edit";
			this.ctxEdit.Click += new System.EventHandler(this.menuItem4_Click);
			// 
			// ctxRemove
			// 
			this.ctxRemove.Index = 2;
			this.ctxRemove.Shortcut = System.Windows.Forms.Shortcut.Del;
			this.ctxRemove.Text = "Remove";
			this.ctxRemove.Click += new System.EventHandler(this.menuItem3_Click);
			// 
			// mainMenu1
			// 
			this.mainMenu1.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
																					  this.menuItem8,
																					  this.menuItem1,
																					  this.menuItem14,
																					  this.menuItem5});
			// 
			// menuItem8
			// 
			this.menuItem8.Index = 0;
			this.menuItem8.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
																					  this.menuItem9,
																					  this.menuItem10,
																					  this.menuItem11,
																					  this.menuItem12,
																					  this.menuItem6,
																					  this.menuItem7});
			this.menuItem8.Text = "File";
			this.menuItem8.Popup += new System.EventHandler(this.menuItem8_Popup);
			// 
			// menuItem9
			// 
			this.menuItem9.Index = 0;
			this.menuItem9.Shortcut = System.Windows.Forms.Shortcut.CtrlO;
			this.menuItem9.Text = "&Open";
			this.menuItem9.Click += new System.EventHandler(this.menuItem9_Click);
			// 
			// menuItem10
			// 
			this.menuItem10.Index = 1;
			this.menuItem10.Shortcut = System.Windows.Forms.Shortcut.CtrlS;
			this.menuItem10.Text = "&Save";
			this.menuItem10.Click += new System.EventHandler(this.menuItem10_Click);
			// 
			// menuItem11
			// 
			this.menuItem11.Index = 2;
			this.menuItem11.Shortcut = System.Windows.Forms.Shortcut.CtrlShiftS;
			this.menuItem11.Text = "Save &As";
			this.menuItem11.Click += new System.EventHandler(this.menuItem11_Click);
			// 
			// menuItem12
			// 
			this.menuItem12.Index = 3;
			this.menuItem12.Shortcut = System.Windows.Forms.Shortcut.CtrlN;
			this.menuItem12.Text = "&New";
			this.menuItem12.Click += new System.EventHandler(this.menuItem12_Click);
			// 
			// menuItem6
			// 
			this.menuItem6.Index = 4;
			this.menuItem6.Text = "-";
			// 
			// menuItem7
			// 
			this.menuItem7.Index = 5;
			this.menuItem7.Text = "E&xit";
			this.menuItem7.Click += new System.EventHandler(this.menuItem7_Click);
			// 
			// menuItem1
			// 
			this.menuItem1.Index = 1;
			this.menuItem1.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
																					  this.menuItem2,
																					  this.menuItem4,
																					  this.menuItem3,
																					  this.menuItem21});
			this.menuItem1.Text = "Game";
			this.menuItem1.Popup += new System.EventHandler(this.menuItem1_Popup);
			// 
			// menuItem2
			// 
			this.menuItem2.Index = 0;
			this.menuItem2.Shortcut = System.Windows.Forms.Shortcut.Ins;
			this.menuItem2.Text = "Add";
			this.menuItem2.Click += new System.EventHandler(this.menuItem2_Click);
			// 
			// menuItem4
			// 
			this.menuItem4.Index = 1;
			this.menuItem4.Shortcut = System.Windows.Forms.Shortcut.F2;
			this.menuItem4.Text = "Edit";
			this.menuItem4.Click += new System.EventHandler(this.menuItem4_Click);
			// 
			// menuItem3
			// 
			this.menuItem3.Index = 2;
			this.menuItem3.Shortcut = System.Windows.Forms.Shortcut.Del;
			this.menuItem3.Text = "Remove";
			this.menuItem3.Click += new System.EventHandler(this.menuItem3_Click);
			// 
			// menuItem14
			// 
			this.menuItem14.Index = 2;
			this.menuItem14.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
																					   this.menuItem15,
																					   this.menuItem16,
																					   this.menuItem17,
																					   this.menuItem18,
																					   this.menuItem19,
																					   this.menuItem20});
			this.menuItem14.Text = "View";
			this.menuItem14.Popup += new System.EventHandler(this.menuItem14_Popup);
			// 
			// menuItem15
			// 
			this.menuItem15.Checked = true;
			this.menuItem15.Index = 0;
			this.menuItem15.RadioCheck = true;
			this.menuItem15.Text = "Details";
			this.menuItem15.Click += new System.EventHandler(this.menuItem15_Click);
			// 
			// menuItem16
			// 
			this.menuItem16.Index = 1;
			this.menuItem16.RadioCheck = true;
			this.menuItem16.Text = "List";
			this.menuItem16.Click += new System.EventHandler(this.menuItem16_Click);
			// 
			// menuItem17
			// 
			this.menuItem17.Index = 2;
			this.menuItem17.Text = "-";
			// 
			// menuItem18
			// 
			this.menuItem18.Index = 3;
			this.menuItem18.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
																					   this.sortName,
																					   this.sortGenre,
																					   this.sortDev,
																					   this.sortPub});
			this.menuItem18.Text = "Arrange Icons";
			// 
			// sortName
			// 
			this.sortName.Index = 0;
			this.sortName.Text = "by Name";
			this.sortName.Click += new System.EventHandler(this.sortName_Click);
			// 
			// sortGenre
			// 
			this.sortGenre.Index = 1;
			this.sortGenre.Text = "by Genre";
			this.sortGenre.Click += new System.EventHandler(this.sortGenre_Click);
			// 
			// sortDev
			// 
			this.sortDev.Index = 2;
			this.sortDev.Text = "by Developer";
			this.sortDev.Click += new System.EventHandler(this.sortDev_Click);
			// 
			// sortPub
			// 
			this.sortPub.Index = 3;
			this.sortPub.Text = "by Publisher";
			this.sortPub.Click += new System.EventHandler(this.sortPub_Click);
			// 
			// menuItem19
			// 
			this.menuItem19.Index = 4;
			this.menuItem19.Text = "-";
			// 
			// menuItem20
			// 
			this.menuItem20.Index = 5;
			this.menuItem20.Text = "Statistics...";
			this.menuItem20.Click += new System.EventHandler(this.menuItem20_Click);
			// 
			// menuItem5
			// 
			this.menuItem5.Index = 3;
			this.menuItem5.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
																					  this.menuItem13});
			this.menuItem5.Text = "Mass";
			this.menuItem5.Popup += new System.EventHandler(this.menuItem5_Popup);
			// 
			// menuItem13
			// 
			this.menuItem13.Index = 0;
			this.menuItem13.Text = "Multiple Properties";
			this.menuItem13.Click += new System.EventHandler(this.menuItem13_Click);
			// 
			// ofd
			// 
			this.ofd.Filter = "Xml files|*.xml|All files|*.*";
			// 
			// sfd
			// 
			this.sfd.Filter = "Xml files|*.xml|All files|*.*";
			// 
			// statusBar1
			// 
			this.statusBar1.Location = new System.Drawing.Point(0, 221);
			this.statusBar1.Name = "statusBar1";
			this.statusBar1.Size = new System.Drawing.Size(332, 16);
			this.statusBar1.TabIndex = 1;
			// 
			// menuItem21
			// 
			this.menuItem21.Index = 3;
			this.menuItem21.Shortcut = System.Windows.Forms.Shortcut.CtrlP;
			this.menuItem21.Text = "Print";
			this.menuItem21.Click += new System.EventHandler(this.menuItem21_Click);
			// 
			// Form1
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(332, 237);
			this.Controls.Add(this.gamelist);
			this.Controls.Add(this.statusBar1);
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.Menu = this.mainMenu1;
			this.Name = "Form1";
			this.Text = "Game Catalog";
			this.Closing += new System.ComponentModel.CancelEventHandler(this.Form1_Closing);
			this.ResumeLayout(false);

		}
		#endregion

		[STAThread]
		static void Main(string[] args) {
			if (args.Length == 1) {
				Application.Run(new Form1(args[0]));
			} else {
				Application.Run(new Form1());
			}
		}

		private void OpenFile(string filename) {
			this.filename = filename;
			games = GameCatalogSerializer.ReadFile(filename);
			dirty = false;
		}

		private void SaveFile(string filename) {
			GameCatalogSerializer.WriteFile(filename, games);
			this.filename = filename;
			dirty = false;
		}

		private void LoadGames() {
			gamelist.Items.Clear();
			if (games != null) {
				foreach (Game g in games.Games) {
					ListViewItem lvi = new ListViewItem(g.Name, 0);
					lvi.SubItems.Add(g.Genre.ToString());
					if (g.Developer != null) {
						lvi.SubItems.Add(g.Developer.Name);
					} else {
						lvi.SubItems.Add("");
					}
					if (g.Publisher != null) {
						lvi.SubItems.Add(g.Publisher.Name);
					} else {
						lvi.SubItems.Add("");
					}
					lvi.Tag = g;
					gamelist.Items.Add(lvi);
				}
			}
		}

		// File Open
		private void menuItem9_Click(object sender, System.EventArgs e) {
			if (dirty) {
				DialogResult dr = MessageBox.Show(this, "Data changed, would you like to save?", "Save", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
				if (dr == DialogResult.Yes) {
					menuItem10_Click(sender, e);
				} else if (dr == DialogResult.Cancel) {
					return;
				}
			}
			if (ofd.ShowDialog(this) == DialogResult.OK) {
				OpenFile(ofd.FileName);
				LoadGames();
			}
		}

		// File Save As
		private void menuItem11_Click(object sender, System.EventArgs e) {
			if (sfd.ShowDialog(this) == DialogResult.OK) {
				SaveFile(sfd.FileName);
			}
		}

		// File Save
		private void menuItem10_Click(object sender, System.EventArgs e) {
			if (filename != null) {
				SaveFile(filename);
			} else {
				menuItem11_Click(sender, e);
			}
		}

		// File New
		private void menuItem12_Click(object sender, System.EventArgs e) {
			if (dirty) {
				DialogResult dr = MessageBox.Show(this, "Data changed, would you like to save?", "Save", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
				if (dr == DialogResult.Yes) {
					menuItem10_Click(sender, e);
				} else if (dr == DialogResult.Cancel) {
					return;
				}
			}
			games = new GameCatalog();
			filename = null;
			gamelist.Items.Clear();
		}

		// File Exit
		private void menuItem7_Click(object sender, System.EventArgs e) {
			if (dirty) {
				DialogResult dr = MessageBox.Show(this, "Data changed, would you like to save?", "Save", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
				if (dr == DialogResult.Yes) {
					menuItem10_Click(sender, e);
				} else if (dr == DialogResult.Cancel) {
					return;
				}
			}
			Application.Exit();
		}

		// Game Add
		private void menuItem2_Click(object sender, System.EventArgs e) {
			GameForm gf = new GameForm();
			if (gf.ShowDialog() == DialogResult.OK) {
				games.Games.Add(gf.Game);
				ListViewItem lvi = new ListViewItem(gf.Game.Name, 0);
				lvi.SubItems.Add(gf.Game.Genre.ToString());
				if (gf.Game.Developer != null) {
					lvi.SubItems.Add(gf.Game.Developer.Name);
				} else {
					lvi.SubItems.Add("");
				}
				if (gf.Game.Publisher != null) {
					lvi.SubItems.Add(gf.Game.Publisher.Name);
				} else {
					lvi.SubItems.Add("");
				}
				lvi.Tag = gf.Game;
				gamelist.Items.Add(lvi);
				dirty = true;
			}
		}

		// Game Remove
		private void menuItem3_Click(object sender, System.EventArgs e) {
			if (gamelist.SelectedItems != null) {
				foreach (ListViewItem lvi in gamelist.SelectedItems) {
					Game g = lvi.Tag as Game;
					games.Games.Remove(g);
					dirty = true;
				}
				LoadGames();
			}
		}

		// Game Edit
		private void menuItem4_Click(object sender, System.EventArgs e) {
			if (gamelist.SelectedItems != null && gamelist.SelectedItems.Count > 0) {
				ListViewItem lvi = gamelist.SelectedItems[0];
				Game g = lvi.Tag as Game;
				GameForm gf = new GameForm(g);
				if (gf.ShowDialog() == DialogResult.OK) {
					lvi.SubItems.Clear();
					lvi.Text = g.Name;
					lvi.SubItems.Add(g.Genre.ToString());
					if (g.Developer != null) {
						lvi.SubItems.Add(g.Developer.Name);
					}
					if (g.Publisher != null) {
						lvi.SubItems.Add(g.Publisher.Name);
					}
					dirty = true;
				}
			}
		}

		// Mass Multiple Properties
		private void menuItem13_Click(object sender, System.EventArgs e) {
			MassForm gf = new MassForm();
			if (gf.ShowDialog() == DialogResult.OK) {
				Game g = gf.Game;
				foreach (ListViewItem lvi in gamelist.SelectedItems) {
					if (!IsEmpty(g.Url)) {
						((Game)lvi.Tag).Url = g.Url;
					}
					if (g.Developer != null && (!IsEmpty(g.Developer.Name) || !IsEmpty(g.Developer.Url))) {
						((Game)lvi.Tag).Developer = g.Developer;
					}
					if (g.Genre != Genre.None) {
						((Game)lvi.Tag).Genre = g.Genre;
					}
					if (g.Publisher != null && (!IsEmpty(g.Publisher.Name) || !IsEmpty(g.Publisher.Url))) {
						((Game)lvi.Tag).Publisher = g.Publisher;
					}
					//if (!IsEmpty(g.Cheat)) {
					//	((Game)lvi.Tag).Cheats = g.Cheat;
					//}
					((Game)lvi.Tag).Cheats = g.Cheats;
					if (!IsEmpty(g.PatchInfo)) {
						((Game)lvi.Tag).PatchInfo = g.PatchInfo;
					}

					lvi.SubItems.Clear();
					lvi.Text = ((Game)lvi.Tag).Name;
					lvi.SubItems.Add(((Game)lvi.Tag).Genre.ToString());
					if (((Game)lvi.Tag).Developer != null) {
						lvi.SubItems.Add(((Game)lvi.Tag).Developer.Name);
					} else {
						lvi.SubItems.Add("");
					}
					if (((Game)lvi.Tag).Publisher != null) {
						lvi.SubItems.Add(((Game)lvi.Tag).Publisher.Name);
					} else {
						lvi.SubItems.Add("");
					}

					dirty = true;
				}
			}
		}

		private bool IsEmpty(string s) {
			return (s == null || s.Equals(string.Empty));
		}

		// Context Popup
		private void contextMenu1_Popup(object sender, System.EventArgs e) {
			ctxEdit.Enabled = gamelist.SelectedItems != null && gamelist.SelectedItems.Count == 1;
			ctxRemove.Enabled = gamelist.SelectedItems != null && gamelist.SelectedItems.Count > 0;
		}

		// Game Popup
		private void menuItem1_Popup(object sender, System.EventArgs e) {
			menuItem4.Enabled = gamelist.SelectedItems != null && gamelist.SelectedItems.Count == 1;
			menuItem3.Enabled = gamelist.SelectedItems != null && gamelist.SelectedItems.Count > 0;
			menuItem21.Enabled = gamelist.SelectedItems != null && gamelist.SelectedItems.Count > 0;
		}

		// File Popup
		private void menuItem8_Popup(object sender, System.EventArgs e) {
			menuItem10.Enabled = dirty && gamelist.Items.Count > 0;
			menuItem11.Enabled = gamelist.Items.Count > 0;
		}

		// Item Double Click
		private void gamelist_DoubleClick(object sender, System.EventArgs e) {
			menuItem4_Click(sender, e);
		}

		// Mass Popup
		private void menuItem5_Popup(object sender, System.EventArgs e) {
			menuItem13.Enabled = gamelist.SelectedItems != null && gamelist.SelectedItems.Count > 0;
		}

		// View Details
		private void menuItem15_Click(object sender, System.EventArgs e) {
			menuItem15.Checked = true;
			menuItem16.Checked = false;
			gamelist.View = View.Details;
		}

		// View List
		private void menuItem16_Click(object sender, System.EventArgs e) {
			menuItem15.Checked = false;
			menuItem16.Checked = true;
			gamelist.View = View.List;
		}

		// Sort by Name
		private void sortName_Click(object sender, System.EventArgs e) {
			games.Sort(GameComparison.Name);
			LoadGames();
		}

		// Sort by Genre
		private void sortGenre_Click(object sender, System.EventArgs e) {
			games.Sort(GameComparison.Genre);
			LoadGames();
		}

		// Sort by Developer
		private void sortDev_Click(object sender, System.EventArgs e) {
			games.Sort(GameComparison.Developer);
			LoadGames();
		}

		// Sort by Publisher
		private void sortPub_Click(object sender, System.EventArgs e) {
			games.Sort(GameComparison.Publisher);
			LoadGames();
		}

		// Column Click
		private void gamelist_ColumnClick(object sender, System.Windows.Forms.ColumnClickEventArgs e) {
			switch (e.Column) {
				case 0: sortName_Click(sender, EventArgs.Empty); break;
				case 1: sortGenre_Click(sender, EventArgs.Empty); break;
				case 2: sortDev_Click(sender, EventArgs.Empty); break;
				case 3: sortPub_Click(sender, EventArgs.Empty); break;
			}
		}

		// Item Label Edit
		private void gamelist_AfterLabelEdit(object sender, System.Windows.Forms.LabelEditEventArgs e) {
			Game g = gamelist.Items[e.Item].Tag as Game;
			if (IsEmpty(e.Label)) {
				e.CancelEdit = true;
				return;
			}
			g.Name = e.Label;
			dirty = true;
		}

		private void Form1_Closing(object sender, System.ComponentModel.CancelEventArgs e) {
			e.Cancel = true;
			menuItem7_Click(sender, EventArgs.Empty);
		}

		// Sort by Popup
		private void menuItem14_Popup(object sender, System.EventArgs e) {
			menuItem18.Enabled = gamelist.Items.Count > 0;
			menuItem20.Enabled = gamelist.Items.Count > 0;
		}

		private void gamelist_SelectedIndexChanged(object sender, System.EventArgs e) {
			if (gamelist.SelectedItems == null) {
				statusBar1.Text = string.Empty;
			} else if (gamelist.SelectedItems.Count == 1) {
				statusBar1.Text = "1 game selected";
			} else {
				statusBar1.Text = gamelist.SelectedItems.Count + " games selected";
			}
		}

		private void menuItem20_Click(object sender, System.EventArgs e) {
			StatsForm sf = new StatsForm(games);
			sf.ShowDialog();
		}

		private void menuItem21_Click(object sender, System.EventArgs e) {
			Games gms = new Games();
			foreach (ListViewItem lvi in gamelist.SelectedItems) {
				Game g = lvi.Tag as Game;
				if (g != null) {
					gms.Add(g);
				}
			}
			if (gms.Count > 0) {
				PrintForm2 pf = new PrintForm2(gms);
				pf.Show();
			}
		}
	}
}