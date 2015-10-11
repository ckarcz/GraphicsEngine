#region Imports

using System.Collections.Generic;
using GraphicsEngine.Math;

#endregion

namespace GraphicsEngine.Graphics
{
	public interface IMesh
	{
		string Name { get; }
		List<Vector3> Vectors { get; }
		List<Vector3> Normals { get; }
	}
}