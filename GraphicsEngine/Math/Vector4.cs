#region Imports

using System;

#endregion

namespace GraphicsEngine.Math
{
	public struct Vector4
		: IEquatable<Vector4>
	{
		#region Constructors

		public Vector4(float x, float y, float z, float w)
			: this()
		{
			X = x;
			Y = y;
			Z = z;
			W = w;
		}

		#endregion Constructors

		#region Public Static Properties

		public static readonly Vector4 ZeroVector = new Vector4();
		public static readonly Vector4 OneVector = new Vector4(1f, 1f, 1f, 1f);
		public static readonly Vector4 UnitXVector = new Vector4(1f, 0f, 0f, 0f);
		public static readonly Vector4 UnitYVector = new Vector4(0f, 1f, 0f, 0f);
		public static readonly Vector4 UnitZVector = new Vector4(0f, 0f, 1f, 0f);
		public static readonly Vector4 UnitWVector = new Vector4(0f, 0f, 0f, 1f);

		#endregion Public Static Properties

		#region Public Properties

		public float X;
		public float Y;
		public float Z;
		public float W;

		public float Length
		{
			get { return ((float) System.Math.Sqrt(X * X + Y * Y + Z * Z + W * W)); }
		}

		#endregion Public Properties

		#region Operators

		public static bool operator ==(Vector4 thisVector, Vector4 otherVector)
		{
			return ((thisVector.X == otherVector.X) &&
					(thisVector.Y == otherVector.Y) &&
					(thisVector.Z == otherVector.Z) &&
					(thisVector.W == otherVector.W));
		}

		public static bool operator !=(Vector4 thisVector, Vector4 otherVector)
		{
			return ((thisVector.X != otherVector.X) ||
					(thisVector.Y != otherVector.Y) ||
					(thisVector.Z != otherVector.Z) ||
					(thisVector.W != otherVector.W));
		}

		public static Vector4 operator -(Vector4 thisVector)
		{
			var conjugated = thisVector.GetConjugated();

			return conjugated;
		}

		public static Vector4 operator +(Vector4 thisVector, Vector4 otherVector)
		{
			var newVector4 = new Vector4();
			newVector4.X = thisVector.X + otherVector.X;
			newVector4.Y = thisVector.Y + otherVector.Y;
			newVector4.Z = thisVector.Z + otherVector.Z;
			newVector4.W = thisVector.W + otherVector.W;

			return newVector4;
		}

		public static Vector4 operator -(Vector4 thisVector, Vector4 otherVector)
		{
			var newVector4 = new Vector4();
			newVector4.X = thisVector.X - otherVector.X;
			newVector4.Y = thisVector.Y - otherVector.Y;
			newVector4.Z = thisVector.Z - otherVector.Z;
			newVector4.W = thisVector.W - otherVector.W;

			return newVector4;
		}

		public static Vector4 operator *(Vector4 thisVector, Vector4 otherVector)
		{
			var newVector4 = new Vector4();
			newVector4.X = thisVector.X * otherVector.X;
			newVector4.Y = thisVector.Y * otherVector.Y;
			newVector4.Z = thisVector.Z * otherVector.Z;
			newVector4.W = thisVector.W * otherVector.W;

			return newVector4;
		}

		public static Vector4 operator /(Vector4 thisVector, Vector4 otherVector)
		{
			var newVector4 = new Vector4();
			newVector4.X = thisVector.X / otherVector.X;
			newVector4.Y = thisVector.Y / otherVector.Y;
			newVector4.Z = thisVector.Z / otherVector.Z;
			newVector4.W = thisVector.W / otherVector.W;

			return newVector4;
		}

		public static Vector4 operator +(Vector4 thisVector, float number)
		{
			var newVector4 = new Vector4();
			newVector4.X = thisVector.X + number;
			newVector4.Y = thisVector.Y + number;
			newVector4.Z = thisVector.Z + number;
			newVector4.W = thisVector.W + number;

			return newVector4;
		}

		public static Vector4 operator -(Vector4 thisVector, float number)
		{
			var newVector4 = new Vector4();
			newVector4.X = thisVector.X - number;
			newVector4.Y = thisVector.Y - number;
			newVector4.Z = thisVector.Z - number;
			newVector4.W = thisVector.W - number;

			return newVector4;
		}

		public static Vector4 operator *(Vector4 thisVector, float number)
		{
			var newVector4 = new Vector4();
			newVector4.X = thisVector.X * number;
			newVector4.Y = thisVector.Y * number;
			newVector4.Z = thisVector.Z * number;
			newVector4.W = thisVector.W * number;

			return newVector4;
		}

		public static Vector4 operator /(Vector4 thisVector, float number)
		{
			var newVector4 = new Vector4();
			newVector4.X = thisVector.X / number;
			newVector4.Y = thisVector.Y / number;
			newVector4.Z = thisVector.Z / number;
			newVector4.W = thisVector.W / number;

			return newVector4;
		}

		#endregion Operators

		#region Public Methods

		public Vector4 Clone()
		{
			return new Vector4(X, Y, Z, W);
		}

		public Vector4 Normalize()
		{
			X /= Length;
			Y /= Length;
			Z /= Length;
			W /= Length;

			return this;
		}

		public Vector4 GetNormalized()
		{
			var normalized = Clone().Normalize();

			return normalized;
		}

		public Vector4 Conjugate()
		{
			X = -X;
			Y = -Y;
			Z = -Z;
			W = -W;

			return this;
		}

		public Vector4 GetConjugated()
		{
			var conjugated = Clone().Conjugate();

			return conjugated;
		}

		public float GetDistance(Vector4 otherVector)
		{
			var differenceOfVectors = (this - otherVector);
			var lengthOfDifference = differenceOfVectors.Length;

			return lengthOfDifference;
		}

		public float GetDotProduct(Vector4 otherVector)
		{
			var dotProductOfVectors = (X * otherVector.X) + (Y * otherVector.Y) + (Z * otherVector.Z) + (W * otherVector.W);

			return dotProductOfVectors;
		}

		public Vector4 GetDirection(Vector4 otherVector)
		{
			var differenceOfVectors = otherVector - this;
			differenceOfVectors.Normalize();

			return differenceOfVectors;
		}

		public Vector4 GetMiddle(Vector4 otherVector)
		{
			var sumOfVectors = this + otherVector;
			var middleVector = sumOfVectors / 2;

			return middleVector;
		}

		public Vector3 GetAsVector3()
		{
			return new Vector3(X, Y, Z);
		}

		public bool Equals(Vector4 other)
		{
			return this == other;
		}

		#endregion Public Methods
	}
}