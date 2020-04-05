using System;
using System.IO;
using System.Xml;
using System.Xml.Serialization;

namespace GameList {
	/// <summary>GameCatalog Xml serialization utility.</summary>
	public class GameCatalogSerializer {
		private XmlSerializer s = null;
		private Type type = null;

		/// <summary>Default constructor.</summary>
		public GameCatalogSerializer() {
			this.type = typeof(GameCatalog);
			this.s = new XmlSerializer(this.type);
		}

		/// <summary>Deserializes to an instance of GameCatalog.</summary>
		/// <param name="xml">String xml.</param>
		/// <returns>GameCatalog result.</returns>
		public GameCatalog Deserialize(string xml) {
			TextReader reader = new StringReader(xml);
			return Deserialize(reader);
		}

		/// <summary>Deserializes to an instance of GameCatalog.</summary>
		/// <param name="doc">XmlDocument instance.</param>
		/// <returns>GameCatalog result.</returns>
		public GameCatalog Deserialize(XmlDocument doc) {
			TextReader reader = new StringReader(doc.OuterXml);
			return Deserialize(reader);
		}

		/// <summary>Deserializes to an instance of GameCatalog.</summary>
		/// <param name="reader">TextReader instance.</param>
		/// <returns>GameCatalog result.</returns>
		public GameCatalog Deserialize(TextReader reader) {
			GameCatalog o = (GameCatalog)s.Deserialize(reader);
			reader.Close();
			return o;
		}

		/// <summary>Serializes to an XmlDocument.</summary>
		/// <param name="GameCatalog">GameCatalog to serialize.</param>
		/// <returns>XmlDocument instance.</returns>
		public XmlDocument Serialize(GameCatalog gamecatalog) {
			string xml = StringSerialize(gamecatalog);
			XmlDocument doc = new XmlDocument();
			doc.PreserveWhitespace = true;
			doc.LoadXml(xml);
			doc = Clean(doc);
			return doc;
		}

		private string StringSerialize(GameCatalog gamecatalog) {
			TextWriter w = WriterSerialize(gamecatalog);
			string xml = w.ToString();
			w.Close();
			return xml;
		}

		private TextWriter WriterSerialize(GameCatalog gamecatalog) {
			TextWriter w = new StringWriter();
			this.s = new XmlSerializer(this.type);
			s.Serialize(w, gamecatalog);
			w.Flush();
			return w;
		}

		private XmlDocument Clean(XmlDocument doc) {
			doc.RemoveChild(doc.FirstChild);
			XmlNode first = doc.FirstChild;
			foreach (XmlNode n in doc.ChildNodes) {
				if (n.NodeType == XmlNodeType.Element) {
					first = n;
					break;
				}
			}
			if (first.Attributes != null) {
				XmlAttribute a = null;
				a = first.Attributes["xmlns:xsd"];
				if (a != null) { first.Attributes.Remove(a); }
				a = first.Attributes["xmlns:xsi"];
				if (a != null) { first.Attributes.Remove(a); }
			}
			return doc;
		}

		/// <summary>Reads config data from config file.</summary>
		/// <param name="file">Config file name.</param>
		/// <returns></returns>
		public static GameCatalog ReadFile(string file) {
			GameCatalogSerializer serializer = new GameCatalogSerializer();
			try {
				string xml = string.Empty;
				using (StreamReader reader = new StreamReader(file)) {
					xml = reader.ReadToEnd();
					reader.Close();
				}
				return serializer.Deserialize(xml);
			} catch {}
			return new GameCatalog();
		}

		/// <summary>Writes config data to config file.</summary>
		/// <param name="file">Config file name.</param>
		/// <param name="config">Config object.</param>
		/// <returns></returns>
		public static bool WriteFile(string file, GameCatalog config) {
			bool ok = false;
			GameCatalogSerializer serializer = new GameCatalogSerializer();
			try {
				string xml = serializer.Serialize(config).OuterXml;
				using (StreamWriter writer = new StreamWriter(file, false)) {
					writer.Write(xml);
					writer.Flush();
					writer.Close();
				}
				ok = true;
			} catch {}
			return ok;
		}
	}
}