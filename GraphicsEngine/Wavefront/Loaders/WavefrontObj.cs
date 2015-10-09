#region Imports

using System.Collections.Generic;
using System.Collections.ObjectModel;
using GraphicsEngine.Wavefront.Models;

#endregion

namespace GraphicsEngine.Wavefront.Loaders
{
	internal class WavefrontObj
		: IWavefrontObj
	{
		public WavefrontObj(IList<GeometricVertex> vertices, IList<TextureCoordinate> textures, IList<VertexNormal> normals, IList<Group> groups, IList<Material> materials)
		{
			Vertices = new ReadOnlyCollection<GeometricVertex>(vertices);
			Textures = new ReadOnlyCollection<TextureCoordinate>(textures);
			Normals = new ReadOnlyCollection<VertexNormal>(normals);
			Groups = new ReadOnlyCollection<Group>(groups);
			Materials = new ReadOnlyCollection<Material>(materials);
		}

		public WavefrontObj(IReadOnlyList<GeometricVertex> vertices, IReadOnlyList<TextureCoordinate> textures, IReadOnlyList<VertexNormal> normals, IReadOnlyList<Group> groups, IReadOnlyList<Material> materials)
		{
			Vertices = vertices;
			Textures = textures;
			Normals = normals;
			Groups = groups;
			Materials = materials;
		}

		public IReadOnlyList<GeometricVertex> Vertices { get; }
		public IReadOnlyList<TextureCoordinate> Textures { get; }
		public IReadOnlyList<VertexNormal> Normals { get; }
		public IReadOnlyList<Group> Groups { get; }
		public IReadOnlyList<Material> Materials { get; }
	}
}