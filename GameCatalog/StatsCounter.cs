using System;
using System.Collections;

namespace GameList {
	public class StatsCounter {
		private ArrayList tbl;

		public StatsCounter() {
			tbl = new ArrayList();
		}

		public void Add(string text) {
			bool found = false;
			foreach (Stat st in tbl) {
				if (st.Text.Equals(text)) {
					found = true;
					st.Count++;
					found = true;
					break;
				}
			}
			if (!found) {
				Stat s = new Stat(text, 1);
				tbl.Add(s);
			}
		}

		public Stat this[int i] {
			get { return (Stat)tbl[i]; }
		}

		public int Count {
			get { return tbl.Count; }
		}
	}

	public class Stat {
		private string text;
		private int count;
		public Stat(string text, int count) {
			this.text = text;
			this.count = count;
		}
		public string Text {
			get { return text; }
			set { text = value; }
		}
		public int Count {
			get { return count; }
			set { count = value; }
		}
	}
}