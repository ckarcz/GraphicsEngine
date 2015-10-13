#region Imports

using System;

#endregion

namespace GraphicsEngine.Math
{
	public struct Vector3
		: IEquatable<Vector3>
	{
		#region Constructors

		public Vector3(float x, float y, float z)
			: this()
		{
			X = x;
			Y = y;
			Z = z;
		}

		#endregion Constructors

		#region Public Static Properties

		public static readonly Vector3 ZeroVector = new Vector3(0f, 0f, 0f);
		public static readonly Vector3 OneVector = new Vector3(1f, 1f, 1f);
		public static readonly Vector3 UnitXVector = new Vector3(1f, 0f, 0f);
		public static readonly Vector3 UnitYVector = new Vector3(0f, 1f, 0f);
		public static readonly Vector3 UnitZVector = new Vector3(0f, 0f, 1f);
		public static readonly Vector3 UpVector = new Vector3(0f, 1f, 0f);
		public static readonly Vector3 DownVector = new Vector3(0f, -1f, 0f);
		public static readonly Vector3 RightVector = new Vector3(1f, 0f, 0f);
		public static readonly Vector3 LeftVector = new Vector3(-1f, 0f, 0f);
		public static readonly Vector3 ForwardVector = new Vector3(0f, 0f, -1f);
		public static readonly Vector3 BackwardVector = new Vector3(0f, 0f, 1f);

		#endregion Public Static Properties

		#region Public Properties

		public float X;
		public float Y;
		public float Z;

		public float Length
		{
			get { return ((float) System.Math.Sqrt(X * X + Y * Y + Z * Z)); }
		}

		#endregion Public Properties

		#region Operators

		public static bool operator ==(Vector3 thisVector, Vector3 otherVector)
		{
			return ((thisVector.X == otherVector.X) &&
					(thisVector.Y == otherVector.Y) &&
					(thisVector.Z == otherVector.Z));
		}

		public static bool operator !=(Vector3 thisVector, Vector3 otherVector)
		{
			return ((thisVector.X != otherVector.X) ||
					(thisVector.Y != otherVector.Y) ||
					(thisVector.Z != otherVector.Z));
		}

		public static Vector3 operator -(Vector3 thisVector)
		{
			var conjugated = thisVector.GetConjugated();

			return conjugated;
		}

		public static Vector3 operator +(Vector3 thisVector, Vector3 otherVector)
		{
			var newVector3 = new Vector3();
			newVector3.X = thisVector.X + otherVector.X;
			newVector3.Y = thisVector.Y + otherVector.Y;
			newVector3.Z = thisVector.Z + otherVector.Z;

			return newVector3;
		}

		public static Vector3 operator -(Vector3 thisVector, Vector3 otherVector)
		{
			var newVector3 = new Vector3();
			newVector3.X = thisVector.X - otherVector.X;
			newVector3.Y = thisVector.Y - otherVector.Y;
			newVector3.Z = thisVector.Z - otherVector.Z;

			return newVector3;
		}

		public static Vector3 operator *(Vector3 thisVector, Vector3 otherVector)
		{
			var newVector3 = new Vector3();
			newVector3.X = thisVector.X * otherVector.X;
			newVector3.Y = thisVector.Y * otherVector.Y;
			newVector3.Z = thisVector.Z * otherVector.Z;

			return newVector3;
		}

		public static Vector3 operator /(Vector3 thisVector, Vector3 otherVector)
		{
			var newVector3 = new Vector3();
			newVector3.X = thisVector.X / otherVector.X;
			newVector3.Y = thisVector.Y / otherVector.Y;
			newVector3.Z = thisVector.Z / otherVector.Z;

			return newVector3;
		}

		public static Vector3 operator +(Vector3 thisVector, float number)
		{
			var newVector3 = new Vector3();
			newVector3.X = thisVector.X + number;
			newVector3.Y = thisVector.Y + number;
			newVector3.Z = thisVector.Z + number;

			return newVector3;
		}

		public static Vector3 operator -(Vector3 thisVector, float number)
		{
			var newVector3 = new Vector3();
			newVector3.X = thisVector.X - number;
			newVector3.Y = thisVector.Y - number;
			newVector3.Z = thisVector.Z - number;

			return newVector3;
		}

		public static Vector3 operator *(Vector3 thisVector, float number)
		{
			var newVector3 = new Vector3();
			newVector3.X = thisVector.X * number;
			newVector3.Y = thisVector.Y * number;
			newVector3.Z = thisVector.Z * number;

			return newVector3;
		}

		public static Vector3 operator /(Vector3 thisVector, float number)
		{
			var newVector3 = new Vector3();
			newVector3.X = thisVector.X / number;
			newVector3.Y = thisVector.Y / number;
			newVector3.Z = thisVector.Z / number;

			return newVector3;
		}

		#endregion Operators

		#region Public Methods

		public Vector3 Clone()
		{
			return new Vector3(X, Y, Z);
		}

		public Vector3 Normalize()
		{
			X /= Length;
			Y /= Length;

			return this;
		}

		public Vector3 GetNormalized()
		{
			var normalized = Clone().Normalize();

			return normalized;
		}

		public Vector3 Conjugate()
		{
			X = -X;
			Y = -Y;

			return this;
		}

		public Vector3 GetConjugated()
		{
			var conjugated = Clone().Conjugate();

			return conjugated;
		}

		public float GetDistance(Vector3 otherVector)
		{
			var differenceOfVectors = (this - otherVector);
			var lengthOfDifference = differenceOfVectors.Length;

			return lengthOfDifference;
		}

		public float GetDotProduct(Vector3 otherVector)
		{
			var dotProductOfVectors = (X * otherVector.X) + (Y * otherVector.Y) + (Z * otherVector.Z);

			return dotProductOfVectors;
		}

		public Vector3 GetDirection(Vector3 otherVector)
		{
			var differenceOfVectors = otherVector - this;
			differenceOfVectors.Normalize();

			return differenceOfVectors;
		}

		public Vector3 GetMiddle(Vector3 otherVector)
		{
			var sumOfVectors = this + otherVector;
			var middleVector = sumOfVectors / 2;

			return middleVector;
		}

		public Vector3 Cross(Vector3 otherVector)
		{
			var x = Y * otherVector.Z - otherVector.Y * Z;
			var y = -(X * otherVector.Z - otherVector.X * Z);
			var z = X * otherVector.Y - otherVector.X * Y;

			var result = new Vector3(x, y, z);
			return result;
		}

		public bool Equals(Vector3 other)
		{
			return this == other;
		}

		#endregion Public Methods
	}
}