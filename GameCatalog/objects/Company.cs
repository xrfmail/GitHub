using System;
using System.IO;
using System.Xml.Serialization;

namespace GameList
{
	/// <summary>Represents a Game.Company node.</summary>
	public class Company
    {
		private System.String attribute_name;
		private System.String attribute_url;

		/// <summary></summary>
		public Company() {
		}

		/// <summary></summary>
		/// <param name="name"></param>
		/// <param name="url"></param>
		public Company(string name, string url) {
			this.attribute_name = name;
			this.attribute_url = url;
		}

		/// <summary>System.String name attribute.</summary>
		[XmlAttribute("name")]
		public System.String Name {
			get { return attribute_name; }
			set { attribute_name = value; }
		}

		/// <summary>System.String url attribute.</summary>
		[XmlAttribute("url")]
		public System.String Url {
			get { return attribute_url; }
			set { attribute_url = value; }
		}
	}
}