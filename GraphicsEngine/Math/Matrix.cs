#region Imports

using System;

#endregion

namespace GraphicsEngine.Math
{
	public struct Matrix
		: IEquatable<Matrix>
	{
		#region Public Static Properties

		public static Matrix IdentityMatrix = new Matrix(
			1f, 0f, 0f, 0f,
			0f, 1f, 0f, 0f,
			0f, 0f, 1f, 0f,
			0f, 0f, 0f, 1f);

		#endregion Public Static Properties

		#region Public Methods

		public bool Equals(Matrix other)
		{
			return ((this.M11 == other.M11) && (this.M22 == other.M22) && (this.M33 == other.M33) && (this.M44 == other.M44) && (this.M12 == other.M12) && (this.M13 == other.M13) && (this.M14 == other.M14) && (this.M21 == other.M21) && (this.M23 == other.M23) && (this.M24 == other.M24) && (this.M31 == other.M31) && (this.M32 == other.M32) && (this.M34 == other.M34) && (this.M41 == other.M41) && (this.M42 == other.M42) && (this.M43 == other.M43));
		}

		#endregion Public Methods

		#region Constructors

		public Matrix(float m11, float m12, float m13, float m14, float m21, float m22, float m23, float m24, float m31, float m32, float m33, float m34, float m41, float m42, float m43, float m44)
		{
			this.M11 = m11;
			this.M12 = m12;
			this.M13 = m13;
			this.M14 = m14;
			this.M21 = m21;
			this.M22 = m22;
			this.M23 = m23;
			this.M24 = m24;
			this.M31 = m31;
			this.M32 = m32;
			this.M33 = m33;
			this.M34 = m34;
			this.M41 = m41;
			this.M42 = m42;
			this.M43 = m43;
			this.M44 = m44;
		}

		public Matrix(Vector4 row1, Vector4 row2, Vector4 row3, Vector4 row4)
		{
			this.M11 = row1.X;
			this.M12 = row1.Y;
			this.M13 = row1.Z;
			this.M14 = row1.W;
			this.M21 = row2.X;
			this.M22 = row2.Y;
			this.M23 = row2.Z;
			this.M24 = row2.W;
			this.M31 = row3.X;
			this.M32 = row3.Y;
			this.M33 = row3.Z;
			this.M34 = row3.W;
			this.M41 = row4.X;
			this.M42 = row4.Y;
			this.M43 = row4.Z;
			this.M44 = row4.W;
		}

		#endregion Constructors

		#region Public Properties

		public float M11;

		public float M12;

		public float M13;

		public float M14;

		public float M21;

		public float M22;

		public float M23;

		public float M24;

		public float M31;

		public float M32;

		public float M33;

		public float M34;

		public float M41;

		public float M42;

		public float M43;

		public float M44;

		#endregion Public Properties

		#region Indexers

		public float this[int index]
		{
			get
			{
				switch (index)
				{
					case 0:
						return M11;
					case 1:
						return M12;
					case 2:
						return M13;
					case 3:
						return M14;
					case 4:
						return M21;
					case 5:
						return M22;
					case 6:
						return M23;
					case 7:
						return M24;
					case 8:
						return M31;
					case 9:
						return M32;
					case 10:
						return M33;
					case 11:
						return M34;
					case 12:
						return M41;
					case 13:
						return M42;
					case 14:
						return M43;
					case 15:
						return M44;
				}
				throw new ArgumentOutOfRangeException();
			}

			set
			{
				switch (index)
				{
					case 0:
						M11 = value;
						break;
					case 1:
						M12 = value;
						break;
					case 2:
						M13 = value;
						break;
					case 3:
						M14 = value;
						break;
					case 4:
						M21 = value;
						break;
					case 5:
						M22 = value;
						break;
					case 6:
						M23 = value;
						break;
					case 7:
						M24 = value;
						break;
					case 8:
						M31 = value;
						break;
					case 9:
						M32 = value;
						break;
					case 10:
						M33 = value;
						break;
					case 11:
						M34 = value;
						break;
					case 12:
						M41 = value;
						break;
					case 13:
						M42 = value;
						break;
					case 14:
						M43 = value;
						break;
					case 15:
						M44 = value;
						break;
					default:
						throw new ArgumentOutOfRangeException();
				}
			}
		}

		public float this[int row, int column]
		{
			get { return this[(row * 4) + column]; }

			set { this[(row * 4) + column] = value; }
		}

		#endregion

		#region Operators

		public static bool operator ==(Matrix thisMatrix, Matrix thatMatrix)
		{
			return ((thisMatrix.M11 == thatMatrix.M11) &&
					(thisMatrix.M12 == thatMatrix.M12) &&
					(thisMatrix.M13 == thatMatrix.M13) &&
					(thisMatrix.M14 == thatMatrix.M14) &&
					(thisMatrix.M21 == thatMatrix.M21) &&
					(thisMatrix.M22 == thatMatrix.M22) &&
					(thisMatrix.M23 == thatMatrix.M23) &&
					(thisMatrix.M24 == thatMatrix.M24) &&
					(thisMatrix.M31 == thatMatrix.M31) &&
					(thisMatrix.M32 == thatMatrix.M32) &&
					(thisMatrix.M33 == thatMatrix.M33) &&
					(thisMatrix.M34 == thatMatrix.M34) &&
					(thisMatrix.M41 == thatMatrix.M41) &&
					(thisMatrix.M42 == thatMatrix.M42) &&
					(thisMatrix.M43 == thatMatrix.M43) &&
					(thisMatrix.M44 == thatMatrix.M44));
		}

		public static bool operator !=(Matrix thisMatrix, Matrix thatMatrix)
		{
			return ((thisMatrix.M11 != thatMatrix.M11) ||
					(thisMatrix.M12 != thatMatrix.M12) ||
					(thisMatrix.M13 != thatMatrix.M13) ||
					(thisMatrix.M14 != thatMatrix.M14) ||
					(thisMatrix.M21 != thatMatrix.M21) ||
					(thisMatrix.M22 != thatMatrix.M22) ||
					(thisMatrix.M23 != thatMatrix.M23) ||
					(thisMatrix.M24 != thatMatrix.M24) ||
					(thisMatrix.M31 != thatMatrix.M31) ||
					(thisMatrix.M32 != thatMatrix.M32) ||
					(thisMatrix.M33 != thatMatrix.M33) ||
					(thisMatrix.M34 != thatMatrix.M34) ||
					(thisMatrix.M41 != thatMatrix.M41) ||
					(thisMatrix.M42 != thatMatrix.M42) ||
					(thisMatrix.M43 != thatMatrix.M43) ||
					(thisMatrix.M44 != thatMatrix.M44));
		}

		public static Matrix operator -(Matrix thisMatrix)
		{
			var newMatrix = new Matrix();
			newMatrix.M11 = -thisMatrix.M11;
			newMatrix.M12 = -thisMatrix.M12;
			newMatrix.M13 = -thisMatrix.M13;
			newMatrix.M14 = -thisMatrix.M14;
			newMatrix.M21 = -thisMatrix.M21;
			newMatrix.M22 = -thisMatrix.M22;
			newMatrix.M23 = -thisMatrix.M23;
			newMatrix.M24 = -thisMatrix.M24;
			newMatrix.M31 = -thisMatrix.M31;
			newMatrix.M32 = -thisMatrix.M32;
			newMatrix.M33 = -thisMatrix.M33;
			newMatrix.M34 = -thisMatrix.M34;
			newMatrix.M41 = -thisMatrix.M41;
			newMatrix.M42 = -thisMatrix.M42;
			newMatrix.M43 = -thisMatrix.M43;
			newMatrix.M44 = -thisMatrix.M44;

			return newMatrix;
		}

		public static Matrix operator +(Matrix matrix1, Matrix matrix2)
		{
			var newMatrix = new Matrix();
			newMatrix.M11 = matrix1.M11 + matrix2.M11;
			newMatrix.M12 = matrix1.M12 + matrix2.M12;
			newMatrix.M13 = matrix1.M13 + matrix2.M13;
			newMatrix.M14 = matrix1.M14 + matrix2.M14;
			newMatrix.M21 = matrix1.M21 + matrix2.M21;
			newMatrix.M22 = matrix1.M22 + matrix2.M22;
			newMatrix.M23 = matrix1.M23 + matrix2.M23;
			newMatrix.M24 = matrix1.M24 + matrix2.M24;
			newMatrix.M31 = matrix1.M31 + matrix2.M31;
			newMatrix.M32 = matrix1.M32 + matrix2.M32;
			newMatrix.M33 = matrix1.M33 + matrix2.M33;
			newMatrix.M34 = matrix1.M34 + matrix2.M34;
			newMatrix.M41 = matrix1.M41 + matrix2.M41;
			newMatrix.M42 = matrix1.M42 + matrix2.M42;
			newMatrix.M43 = matrix1.M43 + matrix2.M43;
			newMatrix.M44 = matrix1.M44 + matrix2.M44;

			return newMatrix;
		}

		public static Matrix operator -(Matrix matrix1, Matrix matrix2)
		{
			var newMatrix = new Matrix();
			newMatrix.M11 = matrix1.M11 - matrix2.M11;
			newMatrix.M12 = matrix1.M12 - matrix2.M12;
			newMatrix.M13 = matrix1.M13 - matrix2.M13;
			newMatrix.M14 = matrix1.M14 - matrix2.M14;
			newMatrix.M21 = matrix1.M21 - matrix2.M21;
			newMatrix.M22 = matrix1.M22 - matrix2.M22;
			newMatrix.M23 = matrix1.M23 - matrix2.M23;
			newMatrix.M24 = matrix1.M24 - matrix2.M24;
			newMatrix.M31 = matrix1.M31 - matrix2.M31;
			newMatrix.M32 = matrix1.M32 - matrix2.M32;
			newMatrix.M33 = matrix1.M33 - matrix2.M33;
			newMatrix.M34 = matrix1.M34 - matrix2.M34;
			newMatrix.M41 = matrix1.M41 - matrix2.M41;
			newMatrix.M42 = matrix1.M42 - matrix2.M42;
			newMatrix.M43 = matrix1.M43 - matrix2.M43;
			newMatrix.M44 = matrix1.M44 - matrix2.M44;

			return newMatrix;
		}

		public static Matrix operator *(Matrix matrix1, Matrix matrix2)
		{
			var newMatrix = new Matrix();
			var m11 = (((matrix1.M11 * matrix2.M11) + (matrix1.M12 * matrix2.M21)) + (matrix1.M13 * matrix2.M31)) + (matrix1.M14 * matrix2.M41);
			var m12 = (((matrix1.M11 * matrix2.M12) + (matrix1.M12 * matrix2.M22)) + (matrix1.M13 * matrix2.M32)) + (matrix1.M14 * matrix2.M42);
			var m13 = (((matrix1.M11 * matrix2.M13) + (matrix1.M12 * matrix2.M23)) + (matrix1.M13 * matrix2.M33)) + (matrix1.M14 * matrix2.M43);
			var m14 = (((matrix1.M11 * matrix2.M14) + (matrix1.M12 * matrix2.M24)) + (matrix1.M13 * matrix2.M34)) + (matrix1.M14 * matrix2.M44);
			var m21 = (((matrix1.M21 * matrix2.M11) + (matrix1.M22 * matrix2.M21)) + (matrix1.M23 * matrix2.M31)) + (matrix1.M24 * matrix2.M41);
			var m22 = (((matrix1.M21 * matrix2.M12) + (matrix1.M22 * matrix2.M22)) + (matrix1.M23 * matrix2.M32)) + (matrix1.M24 * matrix2.M42);
			var m23 = (((matrix1.M21 * matrix2.M13) + (matrix1.M22 * matrix2.M23)) + (matrix1.M23 * matrix2.M33)) + (matrix1.M24 * matrix2.M43);
			var m24 = (((matrix1.M21 * matrix2.M14) + (matrix1.M22 * matrix2.M24)) + (matrix1.M23 * matrix2.M34)) + (matrix1.M24 * matrix2.M44);
			var m31 = (((matrix1.M31 * matrix2.M11) + (matrix1.M32 * matrix2.M21)) + (matrix1.M33 * matrix2.M31)) + (matrix1.M34 * matrix2.M41);
			var m32 = (((matrix1.M31 * matrix2.M12) + (matrix1.M32 * matrix2.M22)) + (matrix1.M33 * matrix2.M32)) + (matrix1.M34 * matrix2.M42);
			var m33 = (((matrix1.M31 * matrix2.M13) + (matrix1.M32 * matrix2.M23)) + (matrix1.M33 * matrix2.M33)) + (matrix1.M34 * matrix2.M43);
			var m34 = (((matrix1.M31 * matrix2.M14) + (matrix1.M32 * matrix2.M24)) + (matrix1.M33 * matrix2.M34)) + (matrix1.M34 * matrix2.M44);
			var m41 = (((matrix1.M41 * matrix2.M11) + (matrix1.M42 * matrix2.M21)) + (matrix1.M43 * matrix2.M31)) + (matrix1.M44 * matrix2.M41);
			var m42 = (((matrix1.M41 * matrix2.M12) + (matrix1.M42 * matrix2.M22)) + (matrix1.M43 * matrix2.M32)) + (matrix1.M44 * matrix2.M42);
			var m43 = (((matrix1.M41 * matrix2.M13) + (matrix1.M42 * matrix2.M23)) + (matrix1.M43 * matrix2.M33)) + (matrix1.M44 * matrix2.M43);
			var m44 = (((matrix1.M41 * matrix2.M14) + (matrix1.M42 * matrix2.M24)) + (matrix1.M43 * matrix2.M34)) + (matrix1.M44 * matrix2.M44);
			newMatrix.M11 = m11;
			newMatrix.M12 = m12;
			newMatrix.M13 = m13;
			newMatrix.M14 = m14;
			newMatrix.M21 = m21;
			newMatrix.M22 = m22;
			newMatrix.M23 = m23;
			newMatrix.M24 = m24;
			newMatrix.M31 = m31;
			newMatrix.M32 = m32;
			newMatrix.M33 = m33;
			newMatrix.M34 = m34;
			newMatrix.M41 = m41;
			newMatrix.M42 = m42;
			newMatrix.M43 = m43;
			newMatrix.M44 = m44;

			return newMatrix;
		}

		public static Matrix operator /(Matrix matrix1, Matrix matrix2)
		{
			var newMatrix = new Matrix();
			newMatrix.M11 = matrix1.M11 / matrix2.M11;
			newMatrix.M12 = matrix1.M12 / matrix2.M12;
			newMatrix.M13 = matrix1.M13 / matrix2.M13;
			newMatrix.M14 = matrix1.M14 / matrix2.M14;
			newMatrix.M21 = matrix1.M21 / matrix2.M21;
			newMatrix.M22 = matrix1.M22 / matrix2.M22;
			newMatrix.M23 = matrix1.M23 / matrix2.M23;
			newMatrix.M24 = matrix1.M24 / matrix2.M24;
			newMatrix.M31 = matrix1.M31 / matrix2.M31;
			newMatrix.M32 = matrix1.M32 / matrix2.M32;
			newMatrix.M33 = matrix1.M33 / matrix2.M33;
			newMatrix.M34 = matrix1.M34 / matrix2.M34;
			newMatrix.M41 = matrix1.M41 / matrix2.M41;
			newMatrix.M42 = matrix1.M42 / matrix2.M42;
			newMatrix.M43 = matrix1.M43 / matrix2.M43;
			newMatrix.M44 = matrix1.M44 / matrix2.M44;

			return newMatrix;
		}

		public static Matrix operator *(Matrix matrix, float number)
		{
			var newMatrix = new Matrix();
			newMatrix.M11 = matrix.M11 * number;
			newMatrix.M12 = matrix.M12 * number;
			newMatrix.M13 = matrix.M13 * number;
			newMatrix.M14 = matrix.M14 * number;
			newMatrix.M21 = matrix.M21 * number;
			newMatrix.M22 = matrix.M22 * number;
			newMatrix.M23 = matrix.M23 * number;
			newMatrix.M24 = matrix.M24 * number;
			newMatrix.M31 = matrix.M31 * number;
			newMatrix.M32 = matrix.M32 * number;
			newMatrix.M33 = matrix.M33 * number;
			newMatrix.M34 = matrix.M34 * number;
			newMatrix.M41 = matrix.M41 * number;
			newMatrix.M42 = matrix.M42 * number;
			newMatrix.M43 = matrix.M43 * number;
			newMatrix.M44 = matrix.M44 * number;

			return newMatrix;
		}

		public static Matrix operator /(Matrix matrix, float number)
		{
			float num = 1f / number;

			var newMatrix = new Matrix();
			newMatrix.M11 = matrix.M11 * num;
			newMatrix.M12 = matrix.M12 * num;
			newMatrix.M13 = matrix.M13 * num;
			newMatrix.M14 = matrix.M14 * num;
			newMatrix.M21 = matrix.M21 * num;
			newMatrix.M22 = matrix.M22 * num;
			newMatrix.M23 = matrix.M23 * num;
			newMatrix.M24 = matrix.M24 * num;
			newMatrix.M31 = matrix.M31 * num;
			newMatrix.M32 = matrix.M32 * num;
			newMatrix.M33 = matrix.M33 * num;
			newMatrix.M34 = matrix.M34 * num;
			newMatrix.M41 = matrix.M41 * num;
			newMatrix.M42 = matrix.M42 * num;
			newMatrix.M43 = matrix.M43 * num;
			newMatrix.M44 = matrix.M44 * num;

			return newMatrix;
		}

		#endregion Operators
	}
}