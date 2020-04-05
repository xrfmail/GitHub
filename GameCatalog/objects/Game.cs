using System;
using System.IO;
using System.Xml.Serialization;

namespace GameList {
	/// <summary>Genre values.</summary>
	public enum Genre {
		None, RTS, FPS, TPS, RPG, MMO,
		Action, Simulation, Fighting, Adventure,
		Sports, Racing, Puzzle, Arcade
	}

	/// <summary>Represents a GameCatalog.Game node.</summary>
	public class Game {
		private System.String attribute_name;
		private System.String attribute_isbn;
		private System.String element_cdkey;
		private System.String element_url;
		private Company element_developer;
		private Company element_publisher;
		private System.String element_patchinfo;
		private Cheats element_cheat;
		private System.String element_walkthrough;
		private Genre genre;

		/// <summary>System.String name attribute.</summary>
		[XmlAttribute("name")]
		public System.String Name {
			get { return attribute_name; }
			set { attribute_name = value; }
		}

		/// <summary>Genre attribute.</summary>
		[XmlAttribute("genre")]
		public Genre Genre {
			get { return genre; }
			set { genre = value; }
		}

		/// <summary>System.String isbn attribute.</summary>
		[XmlAttribute("isbn")]
		public System.String Isbn {
			get { return attribute_isbn; }
			set { attribute_isbn = value; }
		}

		/// <summary>String CDKey element.</summary>
		[XmlElement("CDKey")]
		public System.String CDKey {
			get { return element_cdkey; }
			set { element_cdkey = value; }
		}

		/// <summary>String Url element.</summary>
		[XmlElement("Url")]
		public System.String Url {
			get { return element_url; }
			set { element_url = value; }
		}

		/// <summary>Company Developer xml element.</summary>
		[XmlElement("Developer")]
		public Company Developer {
			get { return element_developer; }
			set { element_developer = value; }
		}

		/// <summary>Company Publisher xml element.</summary>
		[XmlElement("Publisher")]
		public Company Publisher {
			get { return element_publisher; }
			set { element_publisher = value; }
		}

		/// <summary>String PatchInfo element.</summary>
		[XmlElement("PatchInfo")]
		public System.String PatchInfo {
			get { return element_patchinfo; }
			set { element_patchinfo = value; }
		}

		/// <summary>String Cheat element.</summary>
		[XmlElement("Cheats")]
		public Cheats Cheats {
			get { return element_cheat; }
			set { element_cheat = value; }
		}

		/// <summary>String Walkthrough element.</summary>
		[XmlElement("Walkthrough")]
		public System.String Walkthrough {
			get { return element_walkthrough; }
			set { element_walkthrough = value; }
		}
	}
}