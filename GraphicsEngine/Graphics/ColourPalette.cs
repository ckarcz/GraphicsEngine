#region Imports

using System;
using System.Collections;
using System.Collections.Generic;

#endregion

namespace GraphicsEngine.Graphics
{
	public class ColourPalette
		: IEnumerable<ColourPalette.Entry>
	{
		private readonly IList<Entry> _entries;

		public ColourPalette(int size)
		{
			Size = size;
			_entries = new List<Entry>(Size);
		}

		public int Size { get; private set; }

		public Entry this[int index]
		{
			get
			{
				if ((index < 0) || (index > Size))
				{
					throw new ArgumentOutOfRangeException(index.ToString());
				}

				return _entries[index];
			}
			protected set
			{
				if ((index < 0) || (index > Size))
				{
					throw new ArgumentOutOfRangeException(index.ToString());
				}

				_entries[index] = value;
			}
		}

		public IEnumerator<Entry> GetEnumerator()
		{
			return _entries.GetEnumerator();
		}

		IEnumerator IEnumerable.GetEnumerator()
		{
			return GetEnumerator();
		}

		public ColourPalette Set(Entry entry)
		{
			return Set(entry.Index, entry.Colour);
		}

		public ColourPalette Set(int index, Colour color)
		{
			if (index < 0 || index > 15)
			{
				throw new ArgumentOutOfRangeException(string.Format("Invalid index. Valid values are between 0 and {0} inclusive.", Size));
			}

			_entries[index] = new Entry(index, color);
			return this;
		}

		public struct Entry
			: IEquatable<Entry>
		{
			public Entry(int index, int r, int g, int b)
				: this(index, new Colour(r, g, b))
			{
			}

			public Entry(int index, Colour colour)
				: this()
			{
				Index = index;
				Colour = colour;
			}

			public int Index { get; }
			public Colour Colour { get; }

			public bool Equals(Entry other)
			{
				return Index == other.Index && Colour.Equals(other.Colour);
			}

			public override bool Equals(object obj)
			{
				if (ReferenceEquals(null, obj))
				{
					return false;
				}

				return obj is Entry && Equals((Entry) obj);
			}

			public static bool Equals(Entry thisEntry, Entry otherEntry)
			{
				return thisEntry.Equals(otherEntry);
			}

			public override int GetHashCode()
			{
				unchecked
				{
					return (Index * 397) ^ Colour.GetHashCode();
				}
			}

			public override string ToString()
			{
				return string.Format("{0}:{1}", Index, Colour);
			}
		}
	}

	public sealed class DefaultConsoleColourPalette
	: ColourPalette
	{
		public static readonly Entry Black = new Entry(0, new Colour(0, 0, 0));
		public static readonly Entry DarkBlue = new Entry(1, new Colour(0, 0, 128));
		public static readonly Entry DarkGreen = new Entry(2, new Colour(0, 128, 0));
		public static readonly Entry DarkCyan = new Entry(3, new Colour(0, 128, 128));
		public static readonly Entry DarkRed = new Entry(4, new Colour(128, 0, 0));
		public static readonly Entry DarkMagenta = new Entry(5, new Colour(128, 0, 128));
		public static readonly Entry DarkYellow = new Entry(6, new Colour(128, 128, 0));
		public static readonly Entry LightGrey = new Entry(7, new Colour(192, 192, 192));
		public static readonly Entry DarkGrey = new Entry(8, new Colour(128, 128, 128));
		public static readonly Entry Blue = new Entry(9, new Colour(0, 0, 255));
		public static readonly Entry Green = new Entry(10, new Colour(0, 255, 0));
		public static readonly Entry Cyan = new Entry(11, new Colour(0, 255, 255));
		public static readonly Entry Red = new Entry(12, new Colour(255, 0, 0));
		public static readonly Entry Magenta = new Entry(13, new Colour(255, 0, 255));
		public static readonly Entry Yellow = new Entry(14, new Colour(255, 255, 0));
		public static readonly Entry White = new Entry(15, new Colour(255, 255, 255));

		public DefaultConsoleColourPalette()
			: base(16)
		{
			this[Black.Index] = Black;
			this[DarkBlue.Index] = DarkBlue;
			this[DarkGreen.Index] = DarkGreen;
			this[DarkCyan.Index] = DarkCyan;
			this[DarkRed.Index] = DarkRed;
			this[DarkMagenta.Index] = DarkMagenta;
			this[DarkYellow.Index] = DarkYellow;
			this[LightGrey.Index] = LightGrey;
			this[DarkGreen.Index] = DarkGreen;
			this[Blue.Index] = Blue;
			this[Green.Index] = Green;
			this[Cyan.Index] = Cyan;
			this[Red.Index] = Red;
			this[Magenta.Index] = Magenta;
			this[Yellow.Index] = Yellow;
			this[White.Index] = White;
		}
	}
}