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
			Faces = new List<IPolygon>();
		}

		public IList<IPolygon> Faces { get; }
		public string Name { get; set; }

		IEnumerable<IPolygon> IMesh.Faces
		{
			get { return Faces; }
		}
	}
}