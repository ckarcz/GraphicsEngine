#region Imports

using System.Collections.Generic;
using GraphicsEngine.Math;

#endregion

namespace GraphicsEngine.Graphics
{
	public class Polygon
		: IPolygon
	{
		public Polygon(params Vector3[] points)
		{
			Points = new List<Vector3>(points);
		}

		public Polygon(IEnumerable<Vector3> points)
		{
			Points = new List<Vector3>(points);
		}

		public Polygon(IList<Vector3> points)
		{
			Points = points;
		}

		public IList<Vector3> Points { get; private set; }

		IEnumerable<Vector3> IPolygon.Points
		{
			get { return Points; }
		}
	}
}