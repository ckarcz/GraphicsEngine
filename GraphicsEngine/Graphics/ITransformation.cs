#region Imports

using GraphicsEngine.Math;

#endregion

namespace GraphicsEngine.Graphics
{
	public interface ITransformation
	{
		Vector3 Scale { get; }
		Vector3 Translation { get; }

		void Transform(ref Vector2 point);

		void Transform(ref Vector3 point);
	}
}