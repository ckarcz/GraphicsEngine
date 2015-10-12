#region Imports

using GraphicsEngine.Math;

#endregion

namespace GraphicsEngine.Graphics
{
	public class Transformation
		: ITransformation
	{
		public Transformation()
		{
			Reset();
		}

		public static ITransformation None { get; } = new Transformation();
		public Vector3 Scale { get; set; }
		public Vector3 Translation { get; set; }

		public void Reset()
		{
			Scale = Vector3.OneVector;
			Translation = Vector3.ZeroVector;
		}

		public void Transform(ref Vector2 point)
		{
			Transform(this, ref point);
		}

		public void Transform(ref Vector3 point)
		{
			Transform(this, ref point);
		}

		public static void Transform(ITransformation transformation, ref Vector2 point)
		{
			point.X = point.X * transformation.Scale.X + transformation.Translation.X;
			point.Y = point.Y * transformation.Scale.Y + transformation.Translation.Y;
		}

		public static void Transform(ITransformation transformation, ref Vector3 point)
		{
			point.X = point.X * transformation.Scale.X + transformation.Translation.X;
			point.Y = point.Y * transformation.Scale.Y + transformation.Translation.Y;
			point.Z = point.Z * transformation.Scale.Z + transformation.Translation.Z;
		}
	}
}