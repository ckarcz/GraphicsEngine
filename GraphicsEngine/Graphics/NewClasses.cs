#region Imports

using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing.Imaging;
using GraphicsEngine.Math;

#endregion

namespace GraphicsEngine.Graphics
{
	public interface IDrawDevice
	{
		//ColourPalette DefaultColourPalette { get; }
		//ColourPalette CurrentColourPalette { get; }

		//void SetColourPalette(ColourPalette palette);

		void Draw(IRenderable renderable);
	}

	public class ConsoleDrawDevice
		: IDrawDevice
	{
		private readonly IConsoleWindow _consoleWindow;
		private readonly IRasterizer _rasterizer;

		public ConsoleDrawDevice(IRasterizer rasterizer, IConsoleWindow consoleWindow)
		{
			_rasterizer = rasterizer;
			_consoleWindow = consoleWindow;
		}

		public void Draw(IRenderable renderable)
		{
			ClearConsoleWindow();
			RasterizeToConsoleWindow(renderable);
			UpdateConsoleWindow();
		}

		private void RasterizeToConsoleWindow(IRenderable renderable)
		{
			if (renderable != null)
			{
				var image = _rasterizer.Rasterize(renderable);

				//var imageMinX = image.LocationX;
				//var imageMinY = image.LocationY;
				//var imageMaxX = image.LocationX + image.Width;
				//var imageMaxY = image.LocationY + image.Height;

				//for (int x = imageMinX; x < imageMaxX; x++)
				//{
				//	for (int y = imageMinY; y < imageMaxY; y++)
				//	{
				//		var character = image.GraphicsBuffer.CharacterBuffer[x, y];
				//		var color = image.GraphicsBuffer.ColorBuffer[x, y];
				//		_consoleWindow.Set(x, y, character, color);
				//	}
				//}
			}
		}

		private void UpdateConsoleWindow()
		{
			_consoleWindow.Update();
		}

		private void ClearConsoleWindow()
		{
			_consoleWindow.Clear();
		}
	}

	public interface IRasterizer
	{
		IRasterizedImage Rasterize(IRenderable renderable);
	}

	public interface IRasterizedImage
	{
		IGraphicsBuffer GraphicsBuffer { get; }
	}

	public interface IRenderable
	{
		IEnumerable<RenderablePoint> Points { get; }
	}

	public class SimpleRenderable
		: IRenderable
	{
		public IEnumerable<RenderablePoint> Points { get; set; }
	}

	public class ZSortedRenderable
		: IRenderable
	{
		public IEnumerable<RenderablePoint> Points { get; set; }
	}
	
	public struct RenderablePoint
		: IEquatable<RenderablePoint>
	{
		public byte Character;
		public ushort Color;
		public Vector3 Position;

		public bool Equals(RenderablePoint other)
		{
			throw new NotImplementedException();
		}
	}

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

	public sealed class WindowsDefaultColourPalette
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

		public WindowsDefaultColourPalette()
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

	public struct Colour
		: IEquatable<Colour>
	{
		public Colour(int r, int g, int b)
		{
			R = r;
			B = b;
			G = g;
		}

		public int R { get; }
		public int G { get; }
		public int B { get; }

		public bool Equals(Colour other)
		{
			return (R == other.R) && (G == other.G) && (B == other.B);
		}

		public override bool Equals(object obj)
		{
			if (ReferenceEquals(null, obj))
			{
				return false;
			}

			return obj is Colour && Equals((Colour) obj);
		}

		public override int GetHashCode()
		{
			unchecked
			{
				var hashCode = R;
				hashCode = (hashCode * 397) ^ G;
				hashCode = (hashCode * 397) ^ B;
				return hashCode;
			}
		}

		public override string ToString()
		{
			return string.Format("({0}, {1}, {2})", R, G, B);
		}
	}
}