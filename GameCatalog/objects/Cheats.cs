using System;
using System.Collections;
using System.Xml.Serialization;

namespace GameList {
	public class Cheats
    {
		private string setup;
		private Hashtable codes;

		public Cheats() {
			codes = new Hashtable();
		}

		[XmlElement("Setup")]
		public string SetupInformation {
			get { return setup; }
			set { setup = value; }
		}

		public void ClearCodes() {
			codes.Clear();
		}

		public void AddCode(Cheat cheat) {
			try {
				codes.Add(cheat.Code, cheat.Description);
			} catch {
			}
		}

		public void AddCode(string code, string desc) {
			codes.Add(code, desc);
		}

		[XmlArrayItem("Code", typeof(Cheat))]
		[XmlArray("CheatCodes")]
		public Cheat[] CheatCodes {
			get {
				Cheat[] cs = new Cheat[codes.Count];
				int i = 0;
				foreach (string code in codes.Keys) {
					Cheat c = new Cheat(code, codes[code].ToString());
					cs[i++] = c;
				}
				Array.Sort(cs, new CheatComparer());
				return cs;
			}
			set {
				foreach (Cheat c in value) {
					codes.Add(c.Code, c.Description);
				}
			}
		}
	}

	public class Cheat {
		private string code;
		private string desc;

		public Cheat() {
		}

		public Cheat(string code) : this() {
			this.code = code;
		}

		public Cheat(string code, string description) : this(code) {
			this.desc = description;
		}

		[XmlAttribute("code")]
		public string Code {
			get { return code; }
			set { code = value; }
		}

		[XmlElement("Effect")]
		public string Description {
			get { return desc; }
			set { desc = value; }
		}
	}

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