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
			var conjugated = thisVector.GetConjugated();

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

		public Vector2 Clone()
		{
			return new Vector2(X, Y);
		}

		public Vector2 Normalize()
		{
			X /= Length;
			Y /= Length;

			return this;
		}

		public Vector2 GetNormalized()
		{
			var normalized = Clone().Normalize();

			return normalized;
		}

		public Vector2 Conjugate()
		{
			X = -X;
			Y = -Y;

			return this;
		}

		public Vector2 GetConjugated()
		{
			var copyConjugated = Clone().Conjugate();

			return copyConjugated;
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

		public bool Equals(Vector2 other)
		{
			return this == other;
		}

		#endregion Public Methods
	}
}