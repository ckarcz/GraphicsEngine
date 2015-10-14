#region Imports

using GraphicsEngine.Math;

#endregion

namespace GraphicsEngine.Graphics
{
	public interface ITransformation
	{
		Vector3 Scale { get; }
		Vector3 Translation { get; }
		Vector3 Rotation { get; }

		Vector2 Transform(Vector2 point);

		Vector3 Transform(Vector3 point);

		void Transform(ref Vector2 point);

		void Transform(ref Vector3 point);
	}
}