#region Imports

using GraphicsEngine.Math;

#endregion

namespace GraphicsEngine.Graphics
{
	public class Triangle
		: ITriangle
	{
		public Triangle(Vector3 point1, Vector3 point2, Vector3 point3)
		{
			Point1 = point1;
			Point2 = point2;
			Point3 = point3;
		}

		public Vector3 Point1 { get; private set; }
		public Vector3 Point2 { get; private set; }
		public Vector3 Point3 { get; private set; }
	}
}