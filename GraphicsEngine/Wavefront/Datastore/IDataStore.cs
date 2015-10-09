#region Imports

using System.Collections.Generic;
using GraphicsEngine.Wavefront.Models;

#endregion

namespace GraphicsEngine.Wavefront.Datastore
{
	public interface IDataStore
	{
		IList<GeometricVertex> Vertices { get; }
		IList<TextureCoordinate> Textures { get; }
		IList<VertexNormal> Normals { get; }
		IList<Material> Materials { get; }
		IList<Group> Groups { get; }
	}
}