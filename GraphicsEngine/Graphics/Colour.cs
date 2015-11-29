#region Imports

using System;

#endregion

namespace GraphicsEngine.Graphics
{
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