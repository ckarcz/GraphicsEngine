#region Imports

using System;

#endregion

namespace GraphicsEngine.Math
{
	public struct Rectangle
		: IEquatable<Rectangle>
	{
		#region Constructors

		public Rectangle(float x, float y, float width, float height)
			: this()
		{
			X = x;
			Y = y;
			Width = width;
			Height = height;
		}

		#endregion Constructors

		#region Public Static Properties

		public static readonly Rectangle Empty = new Rectangle(0, 0, 0, 0);

		#endregion

		#region Public Properties

		public float X;

		public float Y;

		public float Width;

		public float Height;

		public Vector2 Position
		{
			get { return new Vector2(X, Y); }
			set
			{
				X = value.X;
				Y = value.Y;
			}
		}

		public Vector2 Size
		{
			get { return new Vector2(Width, Height); }
			set
			{
				Width = value.X;
				Height = value.Y;
			}
		}

		public float LeftX
		{
			get { return System.Math.Min(X, (X + Width)); }
		}

		public float TopY
		{
			get { return System.Math.Min(Y, (Y + Height)); }
		}

		public float BottomY
		{
			get { return System.Math.Min(Y, (Y + Height)); }
		}

		public float RightX
		{
			get { return System.Math.Min(X, (X + Width)); }
		}

		public float CenterX
		{
			get { return X + (Width * 0.5f); }
		}

		public float CenterY
		{
			get { return Y + (Height * 0.5f); }
		}

		public Vector2 TopLeft
		{
			get { return new Vector2(LeftX, TopY); }
		}

		public Vector2 TopRight
		{
			get { return new Vector2(RightX, TopY); }
		}

		public Vector2 BottomLeft
		{
			get { return new Vector2(LeftX, BottomY); }
		}

		public Vector2 BottomRight
		{
			get { return new Vector2(RightX, BottomY); }
		}

		public Vector2 Center
		{
			get { return new Vector2(CenterX, CenterY); }
		}

		public Rectangle Normalized
		{
			get
			{
				var copy = this;
				copy.Normalize();
				return copy;
			}
		}

		#endregion Public Properties

		#region Operators

		public static bool operator ==(Rectangle thisVector, Rectangle otherVector)
		{
			return ((thisVector.X == otherVector.X) &&
					(thisVector.Y == otherVector.Y) &&
					(thisVector.Width == otherVector.Width) &&
					(thisVector.Height == otherVector.Height));
		}

		public static bool operator !=(Rectangle thisVector, Rectangle otherVector)
		{
			return ((thisVector.X != otherVector.X) ||
					(thisVector.Y != otherVector.Y) ||
					(thisVector.Width != otherVector.Width) ||
					(thisVector.Height != otherVector.Height));
		}

		#endregion Operators

		#region Public Methods

		public Rectangle Normalize()
		{
			if (Width < 0)
			{
				X += Width;
				Width = -Width;
			}

			if (Height < 0)
			{
				Y += Height;
				Height = -Height;
			}

			return this;
		}

		public bool Contains(float x, float y)
		{
			return (x >= LeftX) &&
				   (x <= RightX) &&
				   (y >= TopY) &&
				   (y <= BottomY);
		}

		public bool Contains(Vector2 vector)
		{
			return Contains(vector.X, vector.Y);
		}

		public bool Contains(float x, float y, float width, float height)
		{
			return Contains(x, y) && Contains((x + width), (y + height));
		}

		public bool Contains(Rectangle rectangle)
		{
			return Contains(rectangle.X, rectangle.Y) && Contains((rectangle.X + rectangle.Width), (rectangle.Y + rectangle.Height));
		}

		public override bool Equals(object obj)
		{
			if (ReferenceEquals(null, obj))
			{
				return false;
			}

			return obj is Rectangle && Equals((Rectangle) obj);
		}

		public bool Equals(Rectangle otherRectangle)
		{
			return X.Equals(otherRectangle.X) && Y.Equals(otherRectangle.Y) && Width.Equals(otherRectangle.Width) && Height.Equals(otherRectangle.Height);
		}

		public static bool Equals(Rectangle thisRectangle, Rectangle otherRectangle)
		{
			return thisRectangle == otherRectangle;
		}

		public override int GetHashCode()
		{
			unchecked
			{
				var hashCode = X.GetHashCode();
				hashCode = (hashCode * 397) ^ Y.GetHashCode();
				hashCode = (hashCode * 397) ^ Width.GetHashCode();
				hashCode = (hashCode * 397) ^ Height.GetHashCode();
				return hashCode;
			}
		}

		#endregion Public Methods
	}
}