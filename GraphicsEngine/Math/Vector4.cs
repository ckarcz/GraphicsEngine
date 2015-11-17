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

		public float LengthSquared
		{
			get { return X * X + Y * Y + Z * Z + W * W; }
		}

		public Vector4 Normalized
		{
			get
			{
				var copy = this;
				copy.Normalize();
				return copy;
			}
		}

		public Vector4 Conjugated
		{
			get
			{
				var copy = this;
				copy.Conjugate();
				return copy;
			}
		}

		public Vector3 Xyz
		{
			get { return new Vector3(X, Y, Z); }
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
			var conjugated = thisVector.Conjugated;

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

		public Vector4 Normalize()
		{
			var scale = 1.0f / Length;

			X *= scale;
			Y *= scale;
			Z *= scale;
			W *= scale;

			return this;
		}

		public Vector4 Conjugate()
		{
			X = -X;
			Y = -Y;
			Z = -Z;
			W = -W;

			return this;
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

		public override bool Equals(object obj)
		{
			if (ReferenceEquals(null, obj))
			{
				return false;
			}

			return obj is Vector4 && Equals((Vector4) obj);
		}

		public bool Equals(Vector4 otherVector)
		{
			return Equals(this, otherVector);
		}

		public static bool Equals(Vector4 thisVector, Vector4 otherVector)
		{
			return thisVector == otherVector;
		}

		public override int GetHashCode()
		{
			unchecked
			{
				var hashCode = X.GetHashCode();
				hashCode = (hashCode * 397) ^ Y.GetHashCode();
				hashCode = (hashCode * 397) ^ Z.GetHashCode();
				hashCode = (hashCode * 397) ^ W.GetHashCode();
				return hashCode;
			}
		}

		public override string ToString()
		{
			return string.Format("({0}, {1}, {2}, {3})", X, Y, Z, W);
		}

		#endregion Public Methods
	}
}