using System;
using System.Collections;

namespace GameList {
	/// <summary></summary>
	public enum GameComparison {
		Name, Genre, Developer, Publisher
	}

	/// <summary></summary>
	public class GameComparer : System.Collections.IComparer {
		private GameComparison gc;

		/// <summary></summary>
		/// <param name="gc"></param>
		public GameComparer(GameComparison gc) {
			this.gc = gc;
		}

		/// <summary></summary>
		/// <param name="x"></param>
		/// <param name="y"></param>
		/// <returns></returns>
		public int Compare(object x, object y) {
			Game g1 = x as Game;
			Game g2 = y as Game;
			if (g1 == null && g2 == null) {
				return 0;
			} else if (g1 == null) {
				return -1;
			} else if (g2 == null) {
				return 1;
			}
			int answer = 0;
			switch (gc) {
				case GameComparison.Name:
					return g1.Name.CompareTo(g2.Name);
				case GameComparison.Genre:
					answer = g1.Genre.CompareTo(g2.Genre);
					if (answer == 0) {
						return g1.Name.CompareTo(g2.Name);
					}
					return answer;
				case GameComparison.Developer:
					if (g1.Developer == null && g2.Developer == null) {
						return 0;
					} else if (g1.Developer == null) {
						return -1;
					} else if (g2.Developer == null) {
						return 1;
					}
					answer = g1.Developer.Name.CompareTo(g2.Developer.Name);;
					if (answer == 0) {
						return g1.Name.CompareTo(g2.Name);
					}
					return answer;
				case GameComparison.Publisher:
					if (g1.Publisher == null && g2.Publisher == null) {
						return 0;
					} else if (g1.Publisher == null) {
						return -1;
					} else if (g2.Publisher == null) {
						return 1;
					}
					answer = g1.Publisher.Name.CompareTo(g2.Publisher.Name);;
					if (answer == 0) {
						return g1.Name.CompareTo(g2.Name);
					}
					return answer;
			}
			return answer;
		}
	}
}