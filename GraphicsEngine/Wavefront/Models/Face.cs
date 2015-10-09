#region Imports

using System.Collections.Generic;

#endregion

namespace GraphicsEngine.Wavefront.Models
{
	public class Face
	{
		private readonly List<FaceVertex> _vertices = new List<FaceVertex>();

		public FaceVertex this[int i]
		{
			get { return _vertices[i]; }
		}

		public int Count
		{
			get { return _vertices.Count; }
		}

		public void AddVertex(FaceVertex vertex)
		{
			_vertices.Add(vertex);
		}
	}
}