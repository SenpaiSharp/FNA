#region License
/* FNA - XNA4 Reimplementation for Desktop Platforms
 * Copyright 2009-2024 Ethan Lee and the MonoGame Team
 *
 * Released under the Microsoft Public License.
 * See LICENSE for details.
 */
#endregion

#region Using Statements
using System;
using System.Collections;
using System.Collections.Generic;
#endregion

namespace Microsoft.Xna.Framework.Media
{
	public sealed class SongCollection : IEnumerable<Song>, IEnumerable, IDisposable
	{
		#region Public Properties

		public Song this[int index]
		{
			get
			{
				return innerlist[index];
			}
		}

		public int Count
		{
			get
			{
				return innerlist.Count;
			}
		}

		public bool IsDisposed
		{
			get;
			private set;
		}

		#endregion

		#region Private Variables

		private List<Song> innerlist;

		#endregion

		#region Internal Constructor

		internal SongCollection(List<Song> songs)
		{
			innerlist = songs;
			IsDisposed = false;
		}

        #endregion

		#region Static Constructors
		//TODO: I am not entirely sure why this class and its functionality exists in a way that it can not really be used easily. For now, I am adding a couple of static constructors until someone tells me what the deal is.
        /// <summary>
        /// Creates a SongCollection to be played in MediaPlayer.
        /// </summary>
        /// <param name="songs">Songs that will make up the collection, in sequence.</param>
        /// <returns>SongCollection</returns>
        public static SongCollection CreatePlaylist(List<Song> songs)
        {
            return new SongCollection(songs);
        }

        /// <summary>
        /// Creates a SongCollection to be played in MediaPlayer.
        /// </summary>
        /// <param name="songs">Songs that will make up the collection, in sequence.</param>
        /// <returns>SongCollection</returns>
        public static SongCollection CreatePlaylist(params Song[] songs)
        {
            return CreatePlaylist(new List<Song>(songs));
        }
        #endregion

        #region Public Dispose Method

        public void Dispose()
		{
			innerlist.Clear();
			IsDisposed = true;
		}

		#endregion

		#region IEnumerable Methods

		public IEnumerator<Song> GetEnumerator()
		{
			return innerlist.GetEnumerator();
		}

		IEnumerator IEnumerable.GetEnumerator()
		{
			return innerlist.GetEnumerator();
		}

		#endregion
	}
}
