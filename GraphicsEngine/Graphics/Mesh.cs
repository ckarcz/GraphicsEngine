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
			Triangles = new List<ITriangle>();
		}

		public List<ITriangle> Triangles { get; }
		public string Name { get; set; }

		IEnumerable<ITriangle> IMesh.Triangles
		{
			get { return Triangles; }
		}
	}
}