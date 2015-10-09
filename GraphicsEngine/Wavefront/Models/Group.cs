#region Imports

using System.Collections.Generic;

#endregion

namespace GraphicsEngine.Wavefront.Models
{
	public class Group
	{
		private readonly List<Face> _faces = new List<Face>();

		public Group(string name)
		{
			Name = name;
		}

		public string Name { get; private set; }
		public Material Material { get; set; }

		public IList<Face> Faces
		{
			get { return _faces; }
		}

		public void AddFace(Face face)
		{
			_faces.Add(face);
		}
	}
}