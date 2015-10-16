#region Imports

using System.Collections.Generic;
using GraphicsEngine.Math;

#endregion

namespace GraphicsEngine.Graphics
{
	public interface IPolygon
	{
		IEnumerable<Vector3> Points { get; }

		Vector3 this[int index] { get; }
	}
}