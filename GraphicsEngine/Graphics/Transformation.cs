#region Imports

using GraphicsEngine.Math;

#endregion

namespace GraphicsEngine.Graphics
{
	public class Transformation
		: ITransformation
	{
		public static ITransformation None = new Transformation();

		public Transformation()
		{
			Reset();
		}

		public Vector3 Scale { get; set; }
		public Vector3 Translation { get; set; }
		public Vector3 Rotation { get; set; }

		public Vector2 Transform(Vector2 point)
		{
			Transform(this, ref point);

			return point;
		}

		public Vector3 Transform(Vector3 point)
		{
			Transform(this, ref point);

			return point;
		}

		public void Transform(ref Vector2 point)
		{
			Transform(this, ref point);
		}

		public void Transform(ref Vector3 point)
		{
			Transform(this, ref point);
		}

		public void Reset()
		{
			Scale = Vector3.OneVector;
			Translation = Vector3.ZeroVector;
			Rotation = Vector3.ZeroVector;
		}

		public static Vector2 Transform(ITransformation transformation, Vector2 point)
		{
			Transform(transformation, ref point);

			return point;
		}

		public static Vector3 Transform(ITransformation transformation, Vector3 point)
		{
			Transform(transformation, ref point);

			return point;
		}

		public static void Transform(ITransformation transformation, ref Vector2 point)
		{
			var translationMatrix = Matrix.CreateTranslationMatrix(transformation.Translation);
			var scalingMatrix = Matrix.CreateScaleMatrix(transformation.Scale);
			var xRotationMatrix = Matrix.CreateXRotationMatrix(transformation.Rotation);
			var yRotationMatrix = Matrix.CreateYRotationMatrix(transformation.Rotation);
			var zRotationMatrix = Matrix.CreateZRotationMatrix(transformation.Rotation);

			var transformationMatrix = scalingMatrix * translationMatrix * xRotationMatrix * yRotationMatrix * zRotationMatrix;

			var x = (point.X * transformationMatrix.M11) + (point.Y * transformationMatrix.M21) + transformationMatrix.M41;
			var y = (point.X * transformationMatrix.M12) + (point.Y * transformationMatrix.M22) + transformationMatrix.M42;

			point.X = x;
			point.Y = y;
		}

		public static void Transform(ITransformation transformation, ref Vector3 point)
		{
			var translationMatrix = Matrix.CreateTranslationMatrix(transformation.Translation);
			var scalingMatrix = Matrix.CreateScaleMatrix(transformation.Scale);
			var xRotationMatrix = Matrix.CreateXRotationMatrix(transformation.Rotation);
			var yRotationMatrix = Matrix.CreateYRotationMatrix(transformation.Rotation);
			var zRotationMatrix = Matrix.CreateZRotationMatrix(transformation.Rotation);

			var transformationMatrix = scalingMatrix * translationMatrix * xRotationMatrix * yRotationMatrix * zRotationMatrix;

			var x = (point.X * transformationMatrix.M11) + (point.Y * transformationMatrix.M21) + (point.Z * transformationMatrix.M31) + transformationMatrix.M41;
			var y = (point.X * transformationMatrix.M12) + (point.Y * transformationMatrix.M22) + (point.Z * transformationMatrix.M32) + transformationMatrix.M42;
			var z = (point.X * transformationMatrix.M13) + (point.Y * transformationMatrix.M23) + (point.Z * transformationMatrix.M33) + transformationMatrix.M43;

			point.X = x;
			point.Y = y;
			point.Z = z;
		}
	}
}