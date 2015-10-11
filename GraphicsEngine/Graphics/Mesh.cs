#region Imports

using System.Collections.Generic;

#endregion

namespace GraphicsEngine.Graphics
{
	public class Mesh
		: IMesh
	{
		public Mesh()
		{
			Triangles = new List<Triangle>();
		}

		public List<Triangle> Triangles { get; }
		public string Name { get; set; }

		IEnumerable<Triangle> IMesh.Faces
		{
			get { return Triangles; }
		}
	}
}