using System;
using System.ComponentModel;
using System.Drawing;

namespace BoneSoft.Design {
	// System.Drawing.Drawing2D.ColorBlend
	/// <summary></summary>
	public class ColorBlender {
		private Color colorleft;
		private Color colorright;
		private int steps;

		private float step;
		private float stepsize;

		/// <summary></summary>
		/// <param name="numberofsteps"></param>
		/// <param name="one"></param>
		/// <param name="two"></param>
		public ColorBlender(int numberofsteps, Color one, Color two) {
			steps = numberofsteps;
			colorleft = one;
			colorright = two;
			stepsize = 1.0f/Convert.ToSingle(steps);
			step = 0;
		}

		/// <summary></summary>
		/// <returns></returns>
		public bool HasNext() {
			return step < 1;
		}

		/// <summary></summary>
		/// <returns></returns>
		public Color Next() {
			if (!HasNext()) { throw new Exception("Past threshold."); }
			step += stepsize;
			return Morph(step, colorleft, colorright);
		}

		/// <summary></summary>
		/// <param name="ratio"></param>
		/// <param name="c1"></param>
		/// <param name="c2"></param>
		/// <returns></returns>
		public Color Morph(float ratio, Color c1, Color c2) {
			int r = (int)(c1.R + ratio * (c2.R - c1.R));
			int g = (int)(c1.G + ratio * (c2.G - c1.G));
			int b = (int)(c1.B + ratio * (c2.B - c1.B));
			return Color.FromArgb(r, g, b);
		}
	}

	/// <summary></summary>
	public struct ColorRange {
		/// <summary></summary>
		public Color Light;
		/// <summary></summary>
		public Color Lighter;
		/// <summary></summary>
		public Color BaseColor;
		/// <summary></summary>
		public Color Dark;
		/// <summary></summary>
		public Color Darker;

		/// <summary></summary>
		/// <param name="color"></param>
		public ColorRange(Color color) {
			BaseColor = color;
			Light = ColorRange.Tint(0.6f, color);
			Lighter = ColorRange.Tint(0.3f, color);
			Dark = ColorRange.Shade(0.8f, color);
			Darker = ColorRange.Shade(0.6f, color);
		}

		/// <summary></summary>
		/// <param name="color"></param>
		/// <param name="lightratio"></param>
		/// <param name="lighterratio"></param>
		public ColorRange(Color color, float lightratio, float lighterratio) {
			BaseColor = color;
			Light = ColorRange.Tint(lightratio, color);
			Lighter = ColorRange.Tint(lighterratio, color);
			Dark = ColorRange.Shade(lightratio, color);
			Darker = ColorRange.Shade(lighterratio, color);
		}

		/// <summary></summary>
		/// <param name="color"></param>
		/// <param name="lightratio"></param>
		/// <param name="lighterratio"></param>
		/// <param name="darkratio"></param>
		/// <param name="darkerratio"></param>
		public ColorRange(Color color, float lightratio, float lighterratio, float darkratio, float darkerratio) {
			BaseColor = color;
			Light = ColorRange.Tint(lightratio, color);
			Lighter = ColorRange.Tint(lighterratio, color);
			Dark = ColorRange.Shade(darkratio, color);
			Darker = ColorRange.Shade(darkerratio, color);
		}

		/// <summary></summary>
		/// <param name="ratio"></param>
		/// <param name="c1"></param>
		/// <returns></returns>
		public static Color Tint(float ratio, Color c1) {
			return Morph(ratio, Color.White, c1);
		}

		/// <summary></summary>
		/// <param name="ratio"></param>
		/// <param name="c1"></param>
		/// <returns></returns>
		public static Color Shade(float ratio, Color c1) {
			return Morph(ratio, Color.Black, c1);
		}

		/// <summary></summary>
		/// <param name="ratio"></param>
		/// <param name="c1"></param>
		/// <param name="c2"></param>
		/// <returns></returns>
		public static Color Morph(float ratio, Color c1, Color c2) {
			int r = (int)(c1.R + ratio * (c2.R - c1.R));
			int g = (int)(c1.G + ratio * (c2.G - c1.G));
			int b = (int)(c1.B + ratio * (c2.B - c1.B));
			return Color.FromArgb(r, g, b);
		}
	}

	/// <summary></summary>
	public class ColorSet {
		private bool shade;
		private Color color;
		private float factor;
		private int colors;
		private Color[] range;

		/// <summary></summary>
		/// <param name="shade"></param>
		/// <param name="color"></param>
		/// <param name="factor"></param>
		/// <param name="colors"></param>
		public ColorSet(bool shade, Color color, float factor, int colors) {
			if (colors < 1) { throw new ArgumentException("Number of colors must be greater than 0."); }
			if (factor < 0 || factor > 1) { throw new ArgumentException("Factor must be between 0 and 1."); }
			this.shade = shade;
			this.color = color;
			this.factor = factor;
			this.colors = colors;
			Build();
		}

		private void Build() {
			this.range = new Color[colors];
			Color current = color;
			range[0] = current;
			for (int i = 1; i < colors; i++) {
				if (shade) {
					range[i] = ColorRange.Shade(factor, current);
				} else {
					range[i] = ColorRange.Tint(factor, current);
				}
				current = range[i];
			}
		}

		/// <summary></summary>
		public Color[] Colors {
			get { return range; }
		}
	}

	/// <summary></summary>
	public class BlendSet {
		private Color color1;
		private Color color2;
		private float factor;
		private int colors;
		private Color[] range;

		/// <summary></summary>
		/// <param name="one"></param>
		/// <param name="two"></param>
		/// <param name="factor"></param>
		/// <param name="colors"></param>
		public BlendSet(Color one, Color two, float factor, int colors) {
			if (colors < 1) { throw new ArgumentException("Number of colors must be greater than 0."); }
			if (factor < 0 || factor > 1) { throw new ArgumentException("Factor must be between 0 and 1."); }
			this.color1 = one;
			this.color2 = two;
			this.factor = factor;
			this.colors = colors;
			Build();
		}

		private void Build() {
			this.range = new Color[colors];
			Color current = color1;
			range[0] = current;
			for (int i = 1; i < colors; i++) {
				range[i] = ColorRange.Morph(factor, current, color2);
				current = range[i];
			}
		}

		/// <summary></summary>
		public Color[] Colors {
			get { return range; }
		}
	}
}