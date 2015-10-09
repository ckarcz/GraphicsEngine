#region Imports

using System.Collections.Generic;
using GraphicsEngine.Wavefront.Models;

#endregion

namespace GraphicsEngine.Wavefront.Loaders
{
	public interface IWavefrontObj
	{
		IReadOnlyList<GeometricVertex> Vertices { get; }
		IReadOnlyList<TextureCoordinate> Textures { get; }
		IReadOnlyList<VertexNormal> Normals { get; }
		IReadOnlyList<Group> Groups { get; }
		IReadOnlyList<Material> Materials { get; }
	}
}