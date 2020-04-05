using System;

namespace GameList {
	public class CheatComparer : System.Collections.IComparer {
		public int Compare(object x, object y) {
			Cheat c1 = x as Cheat;
			Cheat c2 = y as Cheat;
			if (x == null || y == null) {
				return 0;
			}
			return c1.Code.CompareTo(c2.Code);
		}
	}
}