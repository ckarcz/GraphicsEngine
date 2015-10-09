#region Imports

using System;

#endregion

namespace GraphicsEngine.Math
{
	public class Quaternion
		: IEquatable<Quaternion>
	{
		#region Constructors

		public Quaternion(float x, float y, float z, float w)
		{
			X = x;
			Y = y;
			Z = z;
			W = w;
		}

		#endregion Constructors

		#region Public Methods

		public bool Equals(Quaternion other)
		{
			if (other == null)
			{
				return false;
			}

			return ((X == other.X) && (Y == other.Y) && (Z == other.Z) && (W == other.W));
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