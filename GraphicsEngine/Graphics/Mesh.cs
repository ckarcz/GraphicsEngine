#region Imports

using System.Collections.Generic;
using GraphicsEngine.Math;

#endregion

namespace GraphicsEngine.Graphics
{
	public class Mesh
		: IMesh
	{
		public Mesh()
		{
			Triangles = new List<Vector3>();
			Normals = new List<Vector3>();
		}

		public string Name { get; set; }
		public List<Vector3> Triangles { get; set; }
		public List<Vector3> Normals { get; set; }
	}
}