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

		public WavefrontObj(ReadOnlyCollection<GeometricVertex> vertices, ReadOnlyCollection<TextureCoordinate> textures, ReadOnlyCollection<VertexNormal> normals, ReadOnlyCollection<Group> groups, ReadOnlyCollection<Material> materials)
		{
			Vertices = vertices;
			Textures = textures;
			Normals = normals;
			Groups = groups;
			Materials = materials;
		}

		public ReadOnlyCollection<GeometricVertex> Vertices { get; }
		public ReadOnlyCollection<TextureCoordinate> Textures { get; }
		public ReadOnlyCollection<VertexNormal> Normals { get; }
		public ReadOnlyCollection<Group> Groups { get; }
		public ReadOnlyCollection<Material> Materials { get; }
	}
}