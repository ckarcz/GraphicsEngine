#region Imports

using System.Collections.Generic;
using GraphicsEngine.Math;

#endregion

namespace GraphicsEngine.Graphics
{
	public interface IMesh
	{
		string Name { get; }
		Vector3? Maximums { get; }
		Vector3? Minimums { get; }
		Vector3? Centers { get; }
		IEnumerable<IPolygon> Faces { get; }
	}
}