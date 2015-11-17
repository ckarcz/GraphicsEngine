#region Imports

using System;

#endregion

namespace GraphicsEngine.Math
{
	public struct Vector2
		: IEquatable<Vector2>
	{
		#region Constructors

		public Vector2(float x, float y)
			: this()
		{
			X = x;
			Y = y;
		}

		#endregion Constructors

		#region Public Static Properties

		public static readonly Vector2 ZeroVector = new Vector2(0f, 0f);
		public static readonly Vector2 OneVector = new Vector2(1f, 1f);
		public static readonly Vector2 UnitXVector = new Vector2(1f, 0f);
		public static readonly Vector2 UnitYVector = new Vector2(0f, 1f);

		#endregion Public Static Properties

		#region Public Properties

		public float X;
		public float Y;

		public float Length
		{
			get { return ((float) System.Math.Sqrt(X * X + Y * Y)); }
		}

		public float LengthSquared
		{
			get { return X * X + Y * Y; }
		}

		public Vector2 Normalized
		{
			get
			{
				var copy = this;
				copy.Normalize();
				return copy;
			}
		}

		public Vector2 Conjugated
		{
			get
			{
				var copy = this;
				copy.Conjugate();
				return copy;
			}
		}

		public Vector2 Xy
		{
			get { return new Vector2(X, Y); }
		}

		#endregion Public Properties

		#region Operators

		public static bool operator ==(Vector2 thisVector, Vector2 otherVector)
		{
			return ((thisVector.X == otherVector.X) &&
					(thisVector.Y == otherVector.Y));
		}

		public static bool operator !=(Vector2 thisVector, Vector2 otherVector)
		{
			return ((thisVector.X != otherVector.X) ||
					(thisVector.Y != otherVector.Y));
		}

		public static Vector2 operator -(Vector2 thisVector)
		{
			var conjugated = thisVector.Conjugated;

			return conjugated;
		}

		public static Vector2 operator +(Vector2 thisVector, Vector2 otherVector)
		{
			var newVector2 = new Vector2();
			newVector2.X = thisVector.X + otherVector.X;
			newVector2.Y = thisVector.Y + otherVector.Y;

			return newVector2;
		}

		public static Vector2 operator -(Vector2 thisVector, Vector2 otherVector)
		{
			var newVector2 = new Vector2();
			newVector2.X = thisVector.X - otherVector.X;
			newVector2.Y = thisVector.Y - otherVector.Y;

			return newVector2;
		}

		public static Vector2 operator *(Vector2 thisVector, Vector2 otherVector)
		{
			var newVector2 = new Vector2();
			newVector2.X = thisVector.X * otherVector.X;
			newVector2.Y = thisVector.Y * otherVector.Y;

			return newVector2;
		}

		public static Vector2 operator /(Vector2 thisVector, Vector2 otherVector)
		{
			var newVector2 = new Vector2();
			newVector2.X = thisVector.X / otherVector.X;
			newVector2.Y = thisVector.Y / otherVector.Y;

			return newVector2;
		}

		public static Vector2 operator +(Vector2 thisVector, float number)
		{
			var newVector2 = new Vector2();
			newVector2.X = thisVector.X + number;
			newVector2.Y = thisVector.Y + number;

			return newVector2;
		}

		public static Vector2 operator -(Vector2 thisVector, float number)
		{
			var newVector2 = new Vector2();
			newVector2.X = thisVector.X - number;
			newVector2.Y = thisVector.Y - number;

			return newVector2;
		}

		public static Vector2 operator *(Vector2 thisVector, float number)
		{
			var newVector2 = new Vector2();
			newVector2.X = thisVector.X * number;
			newVector2.Y = thisVector.Y * number;

			return newVector2;
		}

		public static Vector2 operator /(Vector2 thisVector, float number)
		{
			var newVector2 = new Vector2();
			newVector2.X = thisVector.X / number;
			newVector2.Y = thisVector.Y / number;

			return newVector2;
		}

		#endregion Operators

		#region Public Methods

		public Vector2 Normalize()
		{
			var scale = 1.0f / Length;

			X *= scale;
			Y *= scale;

			return this;
		}

		public Vector2 Conjugate()
		{
			X = -X;
			Y = -Y;

			return this;
		}

		public float GetDistance(Vector2 otherVector)
		{
			var differenceOfVectors = (this - otherVector);
			var lengthOfDifference = differenceOfVectors.Length;

			return lengthOfDifference;
		}

		public float GetDotProduct(Vector2 otherVector)
		{
			var dotProductOfVectors = (X * otherVector.X) + (Y * otherVector.Y);

			return dotProductOfVectors;
		}

		public Vector2 GetDirection(Vector2 otherVector)
		{
			var differenceOfVectors = otherVector - this;
			differenceOfVectors.Normalize();

			return differenceOfVectors;
		}

		public Vector2 GetMiddle(Vector2 otherVector)
		{
			var sumOfVectors = this + otherVector;
			var middleVector = sumOfVectors / 2;

			return middleVector;
		}

		public override bool Equals(object obj)
		{
			if (ReferenceEquals(null, obj))
			{
				return false;
			}

			return obj is Vector2 && Equals((Vector2) obj);
		}

		public bool Equals(Vector2 otherVector)
		{
			return Equals(this, otherVector);
		}

		public static bool Equals(Vector2 thisVector, Vector2 otherVector)
		{
			return thisVector == otherVector;
		}

		public override int GetHashCode()
		{
			unchecked
			{
				return (X.GetHashCode() * 397) ^ Y.GetHashCode();
			}
		}

		public override string ToString()
		{
			return string.Format("({0}, {1})", X, Y);
		}

		#endregion Public Methods
	}
}