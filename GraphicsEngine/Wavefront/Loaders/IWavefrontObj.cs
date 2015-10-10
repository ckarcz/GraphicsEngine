#region Imports

using System.Collections.ObjectModel;
using GraphicsEngine.Wavefront.Models;

#endregion

namespace GraphicsEngine.Wavefront.Loaders
{
	public interface IWavefrontObj
	{
		ReadOnlyCollection<GeometricVertex> Vertices { get; }
		ReadOnlyCollection<TextureCoordinate> Textures { get; }
		ReadOnlyCollection<VertexNormal> Normals { get; }
		ReadOnlyCollection<Group> Groups { get; }
		ReadOnlyCollection<Material> Materials { get; }
	}
}