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
		public float RotationXTheta { get; set; }
		public float RotationYTheta { get; set; }
		public float RotationZTheta { get; set; }

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
			RotationXTheta = 0;
			RotationYTheta = 0;
			RotationZTheta = 0;
		}

		public static void Transform(ITransformation transformation, ref Vector2 point)
		{
			var translationMatrix = Matrix.CreateTranslationMatrix(transformation.Translation);
			var scalingMatrix = Matrix.CreateScaleMatrix(transformation.Scale);
			var xRotationMatrix = Matrix.CreateXRotationMatrix(transformation.RotationXTheta);
			var yRotationMatrix = Matrix.CreateYRotationMatrix(transformation.RotationYTheta);
			var zRotationMatrix = Matrix.CreateZRotationMatrix(transformation.RotationZTheta);

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
			var xRotationMatrix = Matrix.CreateXRotationMatrix(transformation.RotationXTheta);
			var yRotationMatrix = Matrix.CreateYRotationMatrix(transformation.RotationYTheta);
			var zRotationMatrix = Matrix.CreateZRotationMatrix(transformation.RotationZTheta);

			var transformationMatrix = scalingMatrix * translationMatrix * xRotationMatrix * yRotationMatrix * zRotationMatrix;

			var x = (point.X * transformationMatrix.M11) + (point.Y * transformationMatrix.M21) + (point.Z * transformationMatrix.M31);
			var y = (point.X * transformationMatrix.M12) + (point.Y * transformationMatrix.M22) + (point.Z * transformationMatrix.M32);
			var z = (point.X * transformationMatrix.M13) + (point.Y * transformationMatrix.M23) + (point.Z * transformationMatrix.M33);

			point.X = x;
			point.Y = y;
			point.Z = z;
		}
	}
}