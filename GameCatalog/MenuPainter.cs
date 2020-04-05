using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.Drawing.Drawing2D;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

namespace BoneSoft.Windows.Controls.Menus {
	/// <summary></summary>
	public class MenuPainter {
		#region Privates
		private MainMenu menu;
		private ImageList imgs;
		private Hashtable imgndx;
		private int minheight = 22;
		private int imgsize = 24;

		private Pen shadeone = new Pen(new SolidBrush(SystemColors.Control), 1f);
		private Pen shadetwo = new Pen(new SolidBrush(SystemColors.Control), 1f);
		private Pen shadethree = new Pen(new SolidBrush(SystemColors.Control), 1f);
		private Pen shadefour = new Pen(new SolidBrush(SystemColors.Control), 1f);

		private DrawItemEventHandler dieh;
		private MeasureItemEventHandler mieh;
		private DrawItemEventHandler idieh;
		private MeasureItemEventHandler imieh;
		#endregion
		#region Color Privates
		private Color linecolor = Color.FromArgb(166,166,166);
		private Color mainhoverborder = Color.FromArgb(10,36,106);
		private Color mainhoverbackhi = Color.FromArgb(182,189,210);
		private Color mainhoverbacklo = Color.FromArgb(182,189,210);
		private Color mainselectborder = Color.FromArgb(102,102,102);
		private Color mainselectbackhi = SystemColors.Control;
		private Color mainselectbacklo = SystemColors.Control;
		private Color itemhoverborder = Color.FromArgb(10,36,106);
		private Color itemhoverbackhi = Color.FromArgb(182,189,210);
		private Color itemhoverbacklo = Color.FromArgb(182,189,210);
		private Color itemhoverfore = SystemColors.MenuText;
		private Color itemnormalfore = SystemColors.MenuText;
		//		private Color itemhoverbarhi = Color.FromArgb(182,189,210);
		//		private Color itemhoverbarlo = Color.FromArgb(182,189,210);
		private Color itemnormalborder = Color.Transparent;
		private Color itemnormalbackhi = Color.FromArgb(249,248,247);
		private Color itemnormalbacklo = Color.FromArgb(249,248,247);
		private Color itemnormalbarhi = SystemColors.ControlLightLight; // SystemColors.Control
		private Color itemnormalbarlo = SystemColors.ControlLight; // SystemColors.Control
		private Color itemhovercheckborder = Color.FromArgb(10,36,106);
		private Color itemhovercheckback = Color.FromArgb(133,146,181);
		private Color itemnormalcheckborder = Color.FromArgb(10,36,106);
		private Color itemnormalcheckback = Color.FromArgb(212,213,216);
		#endregion

		#region Properties
		public ImageList ImageList {
			get { return imgs; }
			set { imgs = value; }
		}

		public int MinimumHeight {
			get { return minheight; }
			set { minheight = value; }
		}

		public int ImageSize {
			get { return imgsize; }
			set { imgsize = value; }
		}
		#endregion
		#region Color Properties
		/// <summary></summary>
		public Color LineColor {
			get { return linecolor; }
			set { linecolor = value; }
		}

		/// <summary></summary>
		public Color MainHoverBorder {
			get { return mainhoverborder; }
			set { mainhoverborder = value; }
		}

		/// <summary></summary>
		public Color MainHoverBackHi {
			get { return mainhoverbackhi; }
			set { mainhoverbackhi = value; }
		}

		/// <summary></summary>
		public Color MainHoverBackLo {
			get { return mainhoverbacklo; }
			set { mainhoverbacklo = value; }
		}

		/// <summary></summary>
		public Color MainSelectBorder {
			get { return mainselectborder; }
			set { mainselectborder = value; }
		}

		/// <summary></summary>
		public Color MainSelectBackHi {
			get { return mainselectbackhi; }
			set { mainselectbackhi = value; }
		}

		/// <summary></summary>
		public Color MainSelectBackLo {
			get { return mainselectbacklo; }
			set { mainselectbacklo = value; }
		}

		/// <summary></summary>
		public Color ItemHoverBorder {
			get { return itemhoverborder; }
			set { itemhoverborder = value; }
		}

		/// <summary></summary>
		public Color ItemHoverBackHi {
			get { return itemhoverbackhi; }
			set { itemhoverbackhi = value; }
		}

		/// <summary></summary>
		public Color ItemHoverBackLo {
			get { return itemhoverbacklo; }
			set { itemhoverbacklo = value; }
		}

		/// <summary></summary>
		public Color ItemHoverForeColor {
			get { return itemhoverfore; }
			set { itemhoverfore = value; }
		}

		/// <summary></summary>
		public Color ItemNormalForeColor {
			get { return itemnormalfore; }
			set { itemnormalfore = value; }
		}

		//		/// <summary></summary>
		//		public Color ItemHoverBarHi {
		//			get { return itemhoverbarhi; }
		//			set { itemhoverbarhi = value; }
		//		}
		//
		//		/// <summary></summary>
		//		public Color ItemHoverBarLo {
		//			get { return itemhoverbarlo; }
		//			set { itemhoverbarlo = value; }
		//		}

		/// <summary></summary>
		public Color ItemNormalBorder {
			get { return itemnormalborder; }
			set { itemnormalborder = value; }
		}

		/// <summary></summary>
		public Color ItemNormalBackHi {
			get { return itemnormalbackhi; }
			set { itemnormalbackhi = value; }
		}

		/// <summary></summary>
		public Color ItemNormalBackLo {
			get { return itemnormalbacklo; }
			set { itemnormalbacklo = value; }
		}

		/// <summary></summary>
		public Color ItemNormalBarHi {
			get { return itemnormalbarhi; }
			set { itemnormalbarhi = value; }
		}

		/// <summary></summary>
		public Color ItemNormalBarLo {
			get { return itemnormalbarlo; }
			set { itemnormalbarlo = value; }
		}

		/// <summary></summary>
		public Color ItemHoverCheckBorder {
			get { return itemhovercheckborder; }
			set { itemhovercheckborder = value; }
		}

		/// <summary></summary>
		public Color ItemHoverCheckBack {
			get { return itemhovercheckback; }
			set { itemhovercheckback = value; }
		}

		/// <summary></summary>
		public Color ItemNormalCheckBorder {
			get { return itemnormalcheckborder; }
			set { itemnormalcheckborder = value; }
		}

		/// <summary></summary>
		public Color ItemNormalCheckBack {
			get { return itemnormalcheckback; }
			set { itemnormalcheckback = value; }
		}
		#endregion

		#region Constructor
		public MenuPainter(MainMenu menu) {
			this.menu = menu;
			this.imgndx = new Hashtable();

			dieh = new DrawItemEventHandler(main_DrawItem);
			mieh = new MeasureItemEventHandler(main_MeasureItem);
			idieh = new DrawItemEventHandler(item_DrawItem);
			imieh = new MeasureItemEventHandler(item_MeasureItem);

			BoneSoft.Design.ColorBlender blender = new BoneSoft.Design.ColorBlender(7, SystemColors.Control, SystemColors.ControlDark);
			shadeone = new Pen(new SolidBrush(blender.Next()), 1f);
			shadetwo = new Pen(new SolidBrush(blender.Next()), 1f);
			shadethree = new Pen(new SolidBrush(blender.Next()), 1f);
			shadefour = new Pen(new SolidBrush(blender.Next()), 1f);

			#region Setup Hover Colors Based on SystemColors.Control
			Color ctrl = SystemColors.Control;
			int r = ctrl.R;
			int g = ctrl.G;
			int b = ctrl.B;
			//if (r < g || g < b || r - b > 30) {
			int rg = r - g; int gb = g - b;
			if (rg < 0) { rg = -rg; }
			if (gb < 0) { gb = -gb; }
			if (rg > 30 || gb > 30) {
				itemhoverborder = SystemColors.ControlDark;
				itemhoverbackhi = SystemColors.ControlLightLight;
				itemhoverbacklo = SystemColors.ControlLightLight;
				mainhoverborder = SystemColors.ControlDark;
				mainhoverbackhi = SystemColors.ControlLightLight;
				mainhoverbacklo = SystemColors.ControlLightLight;
				itemnormalcheckback = SystemColors.ControlLightLight;
				itemhovercheckback = SystemColors.ControlLight;
			}
			#endregion

			InitMenu();
		}

		public MenuPainter(MainMenu menu, ImageList imgs) : this(menu) {
			this.imgs = imgs;
		}
		#endregion

		#region Setup
		public void Reset() {
			foreach (MenuItem mi in menu.MenuItems) {
				Reset(mi);
			}
			try {
				Form frm = menu.GetForm();
				Reset(frm);
			} catch (Exception ex) {
				Console.WriteLine("Exception!: " + ex.Message);
			}
			InitMenu();
		}
		private void Reset(MenuItem mi) {
			mi.OwnerDraw = false;
			foreach (MenuItem cmi in mi.MenuItems) {
				Reset(cmi);
			}
		}
		private void Reset(Control ctrl) {
			if (ctrl.ContextMenu != null) {
				foreach (MenuItem mi in ctrl.ContextMenu.MenuItems) {
					Reset(mi);
				}
			}
			foreach (Control child in ctrl.Controls) {
				Reset(child);
			}
		}

		private void InitMenu() {
			foreach (MenuItem mi in menu.MenuItems) {
				mi.OwnerDraw = true;
				mi.DrawItem -= dieh;
				mi.MeasureItem -= mieh;
				mi.DrawItem += dieh;
				mi.MeasureItem += mieh;
				foreach (MenuItem cmi in mi.MenuItems) {
					InitMenu(cmi);
				}
			}
			try {
				Form frm = menu.GetForm();
				InitMenu(frm);
			} catch (Exception ex) {
				Console.WriteLine("Exception!: " + ex.Message);
			}
		}
		private void InitMenu(Control ctrl) {
			if (ctrl.ContextMenu != null) {
				foreach (MenuItem mi in ctrl.ContextMenu.MenuItems) {
					InitMenu(mi);
				}
			}
			foreach (Control child in ctrl.Controls) {
				InitMenu(child);
			}
		}
		private void InitMenu(MenuItem item) {
			item.OwnerDraw = true;
			item.DrawItem -= idieh;
			item.MeasureItem -= imieh;
			item.DrawItem += idieh;
			item.MeasureItem += imieh;
			foreach (MenuItem mi in item.MenuItems) {
				InitMenu(mi);
			}
		}
		#endregion

		#region Images
		public void SetMenuImage(MenuItem item, int ndx) {
			if (imgndx.Contains(item)) {
				imgndx.Remove(item);
			}
			imgndx.Add(item, ndx);
		}

		private Image GetImage(int ndx) {
			try {
				return imgs.Images[ndx]; // (Bitmap)imgs.Images[ndx];
			} catch {}
			return null;
		}

		private Image GetImage(MenuItem item) {
			if (item == null) { return null; }
			if (imgndx.Contains(item)) {
				int ndx = (int)imgndx[item];
				return GetImage(ndx);
			}
			return null;
		}
		#endregion

		#region Item Menu
		private void item_DrawItem(object sender, DrawItemEventArgs e) {
			MenuItem mi = sender as MenuItem;
			if ((e.State & DrawItemState.Selected) == DrawItemState.Selected) {
				DrawSelectionRect(e, mi);	
			} else {
				e.Graphics.FillRectangle(new LinearGradientBrush(e.Bounds, itemnormalbacklo, itemnormalbackhi, 180f, false), e.Bounds);
				DrawPictureArea(e, mi);
			}

			if ((e.State & DrawItemState.Checked) == DrawItemState.Checked) {
				DrawCheckBox(e, mi);
			}
			DrawMenuText(e, mi);
			DrawItemPicture(e, mi);
		}

		private void item_MeasureItem(object sender, MeasureItemEventArgs e) {
			MenuItem mi = (MenuItem) sender;
			if ( mi.Text == "-" ) {
				e.ItemHeight = 7;
			} else {
				SizeF miSize = e.Graphics.MeasureString(mi.Text, SystemInformation.MenuFont);
				int scWidth = 0;
				if ( mi.Shortcut != Shortcut.None ) {
					SizeF scSize = e.Graphics.MeasureString(mi.Shortcut.ToString(), SystemInformation.MenuFont);
					scWidth = Convert.ToInt32(scSize.Width);
				}
				int miHeight = Convert.ToInt32(miSize.Height) + 7;
				if (miHeight < 25) miHeight = MinimumHeight;
				e.ItemHeight = miHeight;
				e.ItemWidth = Convert.ToInt32(miSize.Width) + scWidth + (ImageSize * 2);
			}
		}

		private void DrawMenuText(System.Windows.Forms.DrawItemEventArgs e, MenuItem mi) {
			Brush textBrush = new SolidBrush(SystemColors.MenuText);
			if ( mi.Text == "-" ) {
				e.Graphics.DrawLine(new Pen(linecolor), e.Bounds.X + imgsize + 3, e.Bounds.Y + 2, e.Bounds.Width, e.Bounds.Y + 2);
			} else {
				StringFormat sf = new StringFormat();
				sf.LineAlignment = StringAlignment.Center;

				RectangleF rect = new Rectangle(imgsize + 2, e.Bounds.Y, e.Bounds.Width, e.Bounds.Height);
				string miText = mi.Text.Replace("&","");
				if (mi.Enabled) {
					if ((e.State & DrawItemState.Selected) == DrawItemState.Selected) {
						textBrush = new SolidBrush(itemhoverfore);
					} else {
						textBrush = new SolidBrush(itemnormalfore);	
					}
				} else {
					textBrush = new SolidBrush(SystemColors.GrayText);	
				}
				e.Graphics.DrawString(miText, SystemInformation.MenuFont, textBrush, rect, sf);
				DrawShortCutText(e, mi);
			}
		}

		private void DrawShortCutText(System.Windows.Forms.DrawItemEventArgs e, MenuItem mi) {
			if (mi.Shortcut != Shortcut.None && mi.ShowShortcut == true) {
				string sctxt = mi.Shortcut.ToString();
				sctxt = sctxt.Replace("Ctrl", "Ctrl+");
				sctxt = sctxt.Replace("Shift", "Shift+");
				sctxt = sctxt.Replace("Alt", "Alt+");

				SizeF scSize = e.Graphics.MeasureString(sctxt, SystemInformation.MenuFont);

				Rectangle rect = new Rectangle(e.Bounds.Width - Convert.ToInt32(scSize.Width) - imgsize, e.Bounds.Y, Convert.ToInt32(scSize.Width) + 5, e.Bounds.Height);

				StringFormat sf = new StringFormat();
				sf.FormatFlags = StringFormatFlags.DirectionRightToLeft;
				sf.LineAlignment = StringAlignment.Center;

				if (mi.Enabled) {
					if ((e.State & DrawItemState.Selected) == DrawItemState.Selected) {
						e.Graphics.DrawString(sctxt, SystemInformation.MenuFont, new SolidBrush(itemhoverfore), rect, sf);
					} else {
						e.Graphics.DrawString(sctxt, SystemInformation.MenuFont, new SolidBrush(itemnormalfore), rect, sf);
					}
				} else {
					e.Graphics.DrawString(sctxt, SystemInformation.MenuFont, new SolidBrush(SystemColors.GrayText), rect, sf);
				}
			}
		}

		private void DrawPictureArea(System.Windows.Forms.DrawItemEventArgs e, MenuItem mi) {
			Rectangle rect = new Rectangle(e.Bounds.X - 1, e.Bounds.Y, imgsize, e.Bounds.Height);
			Brush b = new LinearGradientBrush(rect, itemnormalbarlo, itemnormalbarhi, 180f, false);
			e.Graphics.FillRectangle(b, rect);
		}

		private void DrawItemPicture(System.Windows.Forms.DrawItemEventArgs e, MenuItem mi) {
			const int MAX_PIC_SIZE = 16;
			Image img = GetImage(mi);

			if (img != null) {
				int width = img.Width > MAX_PIC_SIZE ? MAX_PIC_SIZE : img.Width;
				int height = img.Height > MAX_PIC_SIZE ? MAX_PIC_SIZE : img.Height;
				int x = e.Bounds.X + 2;
				int y = e.Bounds.Y + ((e.Bounds.Height - height) / 2);

				bool selected = (e.State & DrawItemState.Selected) == DrawItemState.Selected;
				Rectangle basic = new Rectangle(x+1, y, width, height);
				Rectangle raised = new Rectangle(x, y-1, width, height);
				Rectangle shadow = new Rectangle(x+2, y+1, width, height);
				if (mi.Enabled) {
					if (selected) {
						ColorMatrix myColorMatrix = new ColorMatrix();
						myColorMatrix.Matrix00 = 0.00f; // Red
						myColorMatrix.Matrix11 = 0.00f; // Green
						myColorMatrix.Matrix22 = 0.00f; // Blue
						myColorMatrix.Matrix33 = 0.25f; // alpha
						myColorMatrix.Matrix44 = 1.00f; // w
						ImageAttributes imageAttr = new ImageAttributes();
						imageAttr.SetColorMatrix(myColorMatrix);
						e.Graphics.DrawImage(img, shadow, 0, 0, width, height, GraphicsUnit.Pixel, imageAttr);

						e.Graphics.DrawImage(img, raised);
					} else {
						e.Graphics.DrawImage(img, basic);
					}
				} else {
					ColorMatrix myColorMatrix = new ColorMatrix();
					myColorMatrix.Matrix00 = 1.00f; // Red
					myColorMatrix.Matrix11 = 1.00f; // Green
					myColorMatrix.Matrix22 = 1.00f; // Blue
					myColorMatrix.Matrix33 = 1.30f; // alpha
					myColorMatrix.Matrix44 = 1.00f; // w
					ImageAttributes imageAttr = new ImageAttributes();
					imageAttr.SetColorMatrix(myColorMatrix);
					e.Graphics.DrawImage(img, basic, 0, 0, width, height, GraphicsUnit.Pixel, imageAttr);
				}
			}
		}

		private void DrawSelectionRect(System.Windows.Forms.DrawItemEventArgs e, MenuItem mi) {
			if (mi.Enabled) {
				e.Graphics.FillRectangle(new LinearGradientBrush(e.Bounds, itemhoverbacklo, itemhoverbackhi, 180f, false), e.Bounds);
				e.Graphics.DrawRectangle(new Pen(itemhoverborder), e.Bounds.X, e.Bounds.Y, e.Bounds.Width - 1, e.Bounds.Height - 1);
			}
		}

		private void DrawCheckBox(System.Windows.Forms.DrawItemEventArgs e, MenuItem mi) {
			int cbSize = imgsize - 5;
			e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
			Rectangle rect = new Rectangle(e.Bounds.X + 1, e.Bounds.Y + ((e.Bounds.Height - cbSize) / 2), cbSize, cbSize);
			Pen pen = new Pen(Color.Black,1.7f);
			if ((e.State & DrawItemState.Selected) == DrawItemState.Selected) {
				e.Graphics.FillRectangle(new SolidBrush(itemhovercheckback), rect);
			} else {
				e.Graphics.FillRectangle(new SolidBrush(itemnormalcheckback), rect);
			}

			e.Graphics.DrawRectangle(new Pen(itemhovercheckborder), rect);
			Bitmap img = (Bitmap)GetImage(mi);

			if (img == null) {
				e.Graphics.DrawLine(pen, e.Bounds.X + 7, e.Bounds.Y + 10, e.Bounds.X + 10, e.Bounds.Y + 14);
				e.Graphics.DrawLine(pen, e.Bounds.X + 10, e.Bounds.Y + 14, e.Bounds.X + 15, e.Bounds.Y + 9);
				//				ControlPaint.DrawMenuGlyph(e.Graphics,
				//					e.Bounds.X+10, e.Bounds.Y+10,
				//					imgsize, e.Bounds.Y+15,
				//					MenuGlyph.Checkmark);
			}
		}
		#endregion

		#region Main Menu
		private void main_DrawItem(object sender, DrawItemEventArgs e) {
			MenuItem mi = sender as MenuItem;
			if ((e.State & DrawItemState.HotLight) == DrawItemState.HotLight) {
				DrawMainHoverRect(e, mi);
			} else if ((e.State & DrawItemState.Selected) == DrawItemState.Selected) {
				DrawMainSelectionRect(e, mi);
			} else {
				Rectangle rect = new Rectangle(e.Bounds.X, e.Bounds.Y, e.Bounds.Width, e.Bounds.Height -1);
				e.Graphics.FillRectangle(new SolidBrush(SystemColors.Control), rect);
				e.Graphics.DrawRectangle(new Pen(SystemColors.Control), rect);
				// Clear Shadow---->
				Rectangle back = new Rectangle(rect.Right+1, rect.Y+4, 3, rect.Height-3);
				e.Graphics.DrawRectangle(new Pen(new SolidBrush(SystemColors.Control), 1f), back);
				e.Graphics.FillRectangle(new SolidBrush(SystemColors.Control), back);
				// <----------------
			}

			// Set the Alignment to center
			StringFormat sf = new StringFormat();
			sf.LineAlignment = StringAlignment.Center;
			sf.Alignment = StringAlignment.Center;

			e.Graphics.DrawString(mi.Text, SystemInformation.MenuFont, new SolidBrush(SystemColors.MenuText), e.Bounds, sf);
		}

		private void main_MeasureItem(object sender, MeasureItemEventArgs e) {
			MenuItem mi = (MenuItem) sender;
			SizeF miSize = e.Graphics.MeasureString(mi.Text, SystemInformation.MenuFont);
			e.ItemWidth = Convert.ToInt32(miSize.Width);
			Console.WriteLine("t:{0} h:{1} w:{2} iw:{3}", mi.Text, miSize.Height, miSize.Width, e.ItemWidth);
		}

		private void DrawMainHoverRect(System.Windows.Forms.DrawItemEventArgs e, MenuItem mi) {
			Rectangle rect = new Rectangle(e.Bounds.X, e.Bounds.Y + 1, e.Bounds.Width, e.Bounds.Height - 2);

			// Clear Shadow---->
			Rectangle back = new Rectangle(rect.Right+1, rect.Y+4, 3, rect.Height-3);
			e.Graphics.DrawRectangle(new Pen(new SolidBrush(SystemColors.Control), 1f), back);
			e.Graphics.FillRectangle(new SolidBrush(SystemColors.Control), back);
			// <----------------
			Brush b = new LinearGradientBrush(rect, mainhoverbackhi, mainhoverbacklo, 90f, false);
			e.Graphics.FillRectangle(b, rect);
			e.Graphics.DrawRectangle(new Pen(mainhoverborder), rect);
		}

		/// <summary>
		/// Draws a selection rectangle
		/// </summary>
		private void DrawMainSelectionRect(System.Windows.Forms.DrawItemEventArgs e, MenuItem mi) {
			Rectangle rect = new Rectangle(e.Bounds.X, e.Bounds.Y + 1, e.Bounds.Width, e.Bounds.Height - 2);

			Brush b = new LinearGradientBrush(rect, mainselectbackhi, mainselectbacklo, 90f, false);
			e.Graphics.FillRectangle(b, rect);
			e.Graphics.DrawRectangle(new Pen(mainselectborder), rect);//Color.FromArgb(102,102,102)
			e.Graphics.DrawLine(new Pen(mainselectbacklo, 1f), rect.X+1, rect.Bottom, rect.Right-1, rect.Bottom); // itemnormalbarhi

			// Draw Shadow--------->
			Rectangle back = new Rectangle(rect.Right+1, rect.Y+4, 3, rect.Height-3);
			e.Graphics.DrawLine(shadeone, back.X, back.Y, back.Right, back.Y);
			e.Graphics.DrawLine(shadeone, back.Right, back.Y, back.Right, back.Bottom);
			e.Graphics.DrawLine(shadetwo, back.X, back.Y+1, back.Right-1, back.Y+1);
			e.Graphics.DrawLine(shadetwo, back.Right-1, back.Y+1, back.Right-1, back.Bottom);
			e.Graphics.DrawLine(shadethree, back.X, back.Y+2, back.Right-2, back.Y+2);
			e.Graphics.DrawLine(shadethree, back.Right-2, back.Y+2, back.Right-2, back.Bottom);
			e.Graphics.DrawLine(shadefour, back.Right-3, back.Y+3, back.Right-3, back.Bottom);
			// -------------------->
		}
		#endregion

		#region Playing
		public void ColorMenu(Color basecolor) {
			BoneSoft.Design.ColorSet cs = new BoneSoft.Design.ColorSet(false, basecolor, 0.3f, 6);
			BoneSoft.Design.ColorSet sc = new BoneSoft.Design.ColorSet(true, basecolor, 0.3f, 4);

			this.MainHoverBackHi = cs.Colors[4];
			this.MainHoverBackLo = cs.Colors[1];
			this.MainHoverBorder = cs.Colors[0];

			this.MainSelectBackHi = cs.Colors[1];
			this.MainSelectBackLo = cs.Colors[5];
			this.MainSelectBorder = cs.Colors[0];

			this.ItemHoverBackHi = cs.Colors[4];
			this.ItemHoverBackLo = cs.Colors[2];
			this.ItemHoverBorder = cs.Colors[0];

			this.ItemNormalBackHi = cs.Colors[5];
			this.ItemNormalBackLo = cs.Colors[4];
			this.ItemNormalBorder = cs.Colors[0];

			this.ItemNormalBarHi = cs.Colors[2];
			this.ItemNormalBarLo = cs.Colors[1];

			this.ItemHoverCheckBack = cs.Colors[1];
			this.ItemHoverCheckBorder = cs.Colors[0];
			this.ItemHoverForeColor = sc.Colors[1];

			this.ItemNormalCheckBack = cs.Colors[2];
			this.ItemNormalCheckBorder = cs.Colors[1];
			this.ItemNormalForeColor = sc.Colors[2];
		}
		#endregion
	}
}