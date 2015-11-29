#region Imports

using System;

#endregion

namespace GraphicsEngine.Math
{
	public struct Quaternion
		: IEquatable<Quaternion>
	{
		#region Public Static Properties

		public static readonly Quaternion IdentityQuaternion = new Quaternion(0, 0, 0, 1);

		#endregion Public Static Properties

		#region Constructors

		public Quaternion(float x, float y, float z, float w)
			: this()
		{
			X = x;
			Y = y;
			Z = z;
			W = w;
		}

		public Quaternion(Vector3 axis, float w)
			: this()
		{
			X = axis.X;
			Y = axis.Y;
			Z = axis.Z;
			W = w;
		}

		public Quaternion(Vector4 axis)
			: this()
		{
			X = axis.X;
			Y = axis.Y;
			Z = axis.Z;
			W = axis.W;
		}

		#endregion Constructors

		#region Public Properties

		public float W;
		public float X;
		public float Y;
		public float Z;

		#endregion Public Properties

		#region Operators

		public static bool operator ==(Quaternion thisQuaternion, Quaternion otherQuaternion)
		{
			return ((thisQuaternion.X == otherQuaternion.X) &&
					(thisQuaternion.Y == otherQuaternion.Y) &&
					(thisQuaternion.Z == otherQuaternion.Z) &&
					(thisQuaternion.W == otherQuaternion.W));
		}

		public static bool operator !=(Quaternion thisQuaternion, Quaternion otherQuaternion)
		{
			return ((thisQuaternion.X != otherQuaternion.X) ||
					(thisQuaternion.Y != otherQuaternion.Y) ||
					(thisQuaternion.Z != otherQuaternion.Z) ||
					(thisQuaternion.W != otherQuaternion.W));
		}

		#endregion Operators

		#region Public Methods

		public static Quaternion CreateFromAxisAngle(Vector3 axis, float angle)
		{
			if (axis.Length == 0.0f)
			{
				return IdentityQuaternion;
			}

			var half = angle * 0.5f;
			var sin = (float) System.Math.Sin(half);
			var cos = (float) System.Math.Cos(half);
			return new Quaternion(axis.X * sin, axis.Y * sin, axis.Z * sin, cos);
		}

		public Vector4 GetAsVector4()
		{
			return new Vector4(X, Y, Z, W);
		}

		public override bool Equals(object obj)
		{
			if (ReferenceEquals(null, obj))
			{
				return false;
			}

			return obj is Quaternion && Equals((Quaternion) obj);
		}

		public bool Equals(Quaternion otherQuaternion)
		{
			return Equals(this, otherQuaternion);
		}

		public static bool Equals(Quaternion thisQuaternion, Quaternion otherQuaternion)
		{
			return thisQuaternion == otherQuaternion;
		}

		public override int GetHashCode()
		{
			unchecked
			{
				var hashCode = W.GetHashCode();
				hashCode = (hashCode * 397) ^ X.GetHashCode();
				hashCode = (hashCode * 397) ^ Y.GetHashCode();
				hashCode = (hashCode * 397) ^ Z.GetHashCode();
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