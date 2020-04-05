using System;
using System.IO;
using System.Xml.Serialization;

namespace GameList {
	/// <summary>Represents an xml root GameCatalog document element.</summary>
	[XmlRoot("GameCatalog")]
	public class GameCatalog {
		private Games element_game = new Games();

		/// <summary>Games Game collection xml element.</summary>
		[XmlArrayItem("Game", typeof(Game))]
		[XmlArray("Games")]
		public Games Games {
			get { return element_game; }
			set { element_game = value; }
		}

		/// <summary></summary>
		/// <param name="gc"></param>
		public void Sort(GameComparison gc) {
			GameComparer gcr = new GameComparer(gc);
			Game[] games = new Game[element_game.Count];
			element_game.CopyTo(games, 0);
			Array.Sort(games, gcr);
			element_game.Clear();
			element_game.AddRange(games);
		}
	}
}