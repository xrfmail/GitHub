using System;
using System.Collections;

namespace GameList {
	/// <summary>
	///	 <para>
	///	   A collection that stores <see cref='Game'/> objects.
	///	</para>
	/// </summary>
	/// <seealso cref='Game'/>
	[Serializable()]
	public class Games : CollectionBase {
		/// <summary>Notifies when the collection has been modified.</summary>
		public event EventHandler OnItemsChanged;

		/// <summary>Notifies that an item has been added.</summary>
		public event GameHandler OnItemAdd;

		/// <summary>Notifies that items have been added.</summary>
		public event GameHandler OnItemsAdd;

		/// <summary>Notifies that an item has been removed.</summary>
		public event GameHandler OnItemRemove;

		/// <summary>
		///	 <para>
		///	   Initializes a new instance of <see cref='Game'/>.
		///	</para>
		/// </summary>
		public Games() {
		}

		/// <summary>
		///	 <para>
		///	   Initializes a new instance of <see cref='Game'/> based on another <see cref='Game'/>.
		///	</para>
		/// </summary>
		/// <param name='value'>
		///	   A <see cref='Game'/> from which the contents are copied
		/// </param>
		public Games(Games value) {
			this.AddRange(value);
		}

		/// <summary>
		///	 <para>
		///	   Initializes a new instance of <see cref='Game'/> containing any array of <see cref='Game'/> objects.
		///	</para>
		/// </summary>
		/// <param name='value'>
		///	   A array of <see cref='Game'/> objects with which to intialize the collection
		/// </param>
		public Games(Game[] value) {
			this.AddRange(value);
		}

		/// <summary>
		/// <para>Represents the entry at the specified index of the <see cref='Game'/>.</para>
		/// </summary>
		/// <param name='index'><para>The zero-based index of the entry to locate in the collection.</para></param>
		/// <value>
		///	<para> The entry at the specified index of the collection.</para>
		/// </value>
		/// <exception cref='System.ArgumentOutOfRangeException'><paramref name='index'/> is outside the valid range of indexes for the collection.</exception>
		public Game this[int index] {
			get { return ((Game)(List[index])); }
			set { List[index] = value; }
		}

		/// <summary>
		///	<para>Adds a <see cref='Game'/> with the specified value to the 
		///	<see cref='Game'/> .</para>
		/// </summary>
		/// <param name='value'>The <see cref='Game'/> to add.</param>
		/// <returns>
		///	<para>The index at which the new element was inserted.</para>
		/// </returns>
		/// <seealso cref='Games.AddRange'/>
		public int Add(Game value) {
			int ndx = List.Add(value);
			if (OnItemAdd != null) { OnItemAdd(this, new GameArgs(value)); }
			if (OnItemsChanged != null) { OnItemsChanged(value, EventArgs.Empty); }
			return ndx;
		}

		/// <summary>
		/// <para>Copies the elements of an array to the end of the <see cref='Game'/>.</para>
		/// </summary>
		/// <param name='value'>
		///	An array of type <see cref='Game'/> containing the objects to add to the collection.
		/// </param>
		/// <returns>
		///   <para>None.</para>
		/// </returns>
		/// <seealso cref='Games.Add'/>
		public void AddRange(Game[] value) {
			for (int i = 0; i < value.Length; i++) {
				this.Add(value[i]);
			}
			if (OnItemsAdd != null) { OnItemsAdd(this, new GameArgs(value)); }
			if (OnItemsChanged != null) { OnItemsChanged(value, EventArgs.Empty); }
		}

		/// <summary>
		///	 <para>
		///	   Adds the contents of another <see cref='Game'/> to the end of the collection.
		///	</para>
		/// </summary>
		/// <param name='value'>
		///	A <see cref='Game'/> containing the objects to add to the collection.
		/// </param>
		/// <returns>
		///   <para>None.</para>
		/// </returns>
		/// <seealso cref='Games.Add'/>
		public void AddRange(Games value) {
			for (int i = 0; i < value.Count; i++) {
				this.Add(value[i]);
			}
			if (OnItemsAdd != null) { OnItemsAdd(this, new GameArgs(value)); }
			if (OnItemsChanged != null) { OnItemsChanged(value, EventArgs.Empty); }
		}

		/// <summary>
		/// <para>Gets a value indicating whether the 
		///	<see cref='Game'/> contains the specified <see cref='Game'/>.</para>
		/// </summary>
		/// <param name='value'>The <see cref='Game'/> to locate.</param>
		/// <returns>
		/// <para><see langword='true'/> if the <see cref='Game'/> is contained in the collection; 
		///   otherwise, <see langword='false'/>.</para>
		/// </returns>
		/// <seealso cref='Games.IndexOf'/>
		public bool Contains(Game value) {
			return List.Contains(value);
		}

		/// <summary>
		/// <para>Copies the <see cref='Game'/> values to a one-dimensional <see cref='System.Array'/> instance at the 
		///	specified index.</para>
		/// </summary>
		/// <param name='array'><para>The one-dimensional <see cref='System.Array'/> that is the destination of the values copied from <see cref='Game'/> .</para></param>
		/// <param name='index'>The index in <paramref name='array'/> where copying begins.</param>
		/// <returns>
		///   <para>None.</para>
		/// </returns>
		/// <exception cref='System.ArgumentException'><para><paramref name='array'/> is multidimensional.</para> <para>-or-</para> <para>The number of elements in the <see cref='Game'/> is greater than the available space between <paramref name='arrayIndex'/> and the end of <paramref name='array'/>.</para></exception>
		/// <exception cref='System.ArgumentNullException'><paramref name='array'/> is <see langword='null'/>. </exception>
		/// <exception cref='System.ArgumentOutOfRangeException'><paramref name='arrayIndex'/> is less than <paramref name='array'/>'s lowbound. </exception>
		/// <seealso cref='System.Array'/>
		public void CopyTo(Game[] array, int index) {
			List.CopyTo(array, index);
		}

		/// <summary>
		///	<para>Returns the index of a <see cref='Game'/> in 
		///	   the <see cref='Game'/> .</para>
		/// </summary>
		/// <param name='value'>The <see cref='Game'/> to locate.</param>
		/// <returns>
		/// <para>The index of the <see cref='Game'/> of <paramref name='value'/> in the 
		/// <see cref='Game'/>, if found; otherwise, -1.</para>
		/// </returns>
		/// <seealso cref='Games.Contains'/>
		public int IndexOf(Game value) {
			return List.IndexOf(value);
		}

		/// <summary>
		/// <para>Inserts a <see cref='Game'/> into the <see cref='Games'/> at the specified index.</para>
		/// </summary>
		/// <param name='index'>The zero-based index where <paramref name='value'/> should be inserted.</param>
		/// <param name=' value'>The <see cref='Game'/> to insert.</param>
		/// <returns><para>None.</para></returns>
		/// <seealso cref='Games.Add'/>
		public void Insert(int index, Game value) {
			List.Insert(index, value);
			if (OnItemAdd != null) { OnItemAdd(this, new GameArgs(value)); }
			if (OnItemsChanged != null) { OnItemsChanged(value, EventArgs.Empty); }
		}

		/// <summary>
		///	<para> Removes a specific <see cref='Game'/> from the 
		///	<see cref='Games'/> .</para>
		/// </summary>
		/// <param name='value'>The <see cref='Game'/> to remove from the <see cref='Games'/> .</param>
		/// <returns><para>None.</para></returns>
		/// <exception cref='System.ArgumentException'><paramref name='value'/> is not found in the Collection. </exception>
		public void Remove(Game value) {
			List.Remove(value);
			if (OnItemRemove != null) { OnItemRemove(this, new GameArgs(value)); }
			if (OnItemsChanged != null) { OnItemsChanged(value, EventArgs.Empty); }
		}

		/// Event arguments for the Games collection class.
		public class GameArgs : EventArgs {
			private Games t;

			/// Default constructor.
			public GameArgs() {
				t = new Games();
			}

			/// Initializes with a Game.
			/// Data object.
			public GameArgs(Game t) : this() {
				this.t.Add(t);
			}

			/// Initializes with a collection of Game objects.
			/// Collection of data.
			public GameArgs(Games ts) : this() {
				this.t.AddRange(ts);
			}

			/// Initializes with an array of Game objects.
			/// Array of data.
			public GameArgs(Game[] ts) : this() {
				this.t.AddRange(ts);
			}

			/// Gets or sets the data of this argument.
			public Games Games {
				get { return t; }
				set { t = value; }
			}
		}

		/// Games event handler.
		public delegate void GameHandler(object sender, GameArgs e);
	}
}