#region Imports

using GraphicsEngine.Math;

#endregion

namespace GraphicsEngine.Graphics
{
	public interface ITriangle
	{
		Vector3 Point1 { get; }
		Vector3 Point2 { get; }
		Vector3 Point3 { get; }
	}
}