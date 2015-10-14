#region Imports

using System;

#endregion

namespace GraphicsEngine.Math
{
	public struct Quaternion
		: IEquatable<Quaternion>
	{
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

		#region Public Methods

		public bool Equals(Quaternion other)
		{
			return ((X == other.X) && (Y == other.Y) && (Z == other.Z) && (W == other.W));
		}

		public static Quaternion CreateFromAxisAngle(Vector3 axis, float angle)
		{
			var half = angle * 0.5f;
			var sin = (float) System.Math.Sin(half);
			var cos = (float) System.Math.Cos(half);
			return new Quaternion(axis.X * sin, axis.Y * sin, axis.Z * sin, cos);
		}

		private Matrix GetRotationMatrix()
		{
			var XX = X * X;
			var YY = Y * Y;
			var ZZ = Z * Z;
			var WW = W * W;
			var X2 = X * 2.0f;
			var Y2 = Y * 2.0f;
			var Z2 = Z * 2.0f;
			var W2 = W * 2.0f;
			var XY = X2 * Y;
			var XZ = X2 * Z;
			var YZ = Y2 * Z;
			var WX = W2 * X;
			var WY = W2 * Y;
			var WZ = W2 * Z;

			var matrix = new float[4, 4];
			matrix[0, 0] = WW + XX - YY - ZZ;
			matrix[0, 1] = XY - WZ;
			matrix[0, 2] = XZ + WY;
			matrix[0, 3] = 0;
			matrix[1, 0] = XY + WZ;
			matrix[1, 1] = WW - XX + YY - ZZ;
			matrix[1, 2] = YZ - WX;
			matrix[1, 3] = 0;
			matrix[2, 0] = XZ - WY;
			matrix[2, 1] = YZ + WX;
			matrix[2, 2] = WW - XX - YY + ZZ;
			matrix[2, 3] = 0;
			matrix[3, 0] = 0;
			matrix[3, 1] = 0;
			matrix[3, 2] = 0;
			matrix[3, 3] = 1;

			return new Matrix(matrix);
		}

		public Vector4 GetAsVector4()
		{
			return new Vector4(X, Y, Z, W);
		}

		#endregion Public Methods

		#region Public Properties

		public static readonly Quaternion IdentityQuaternion = new Quaternion(0, 0, 0, 1);
		public float W;
		public float X;
		public float Y;
		public float Z;

		#endregion Public Properties
	}
}