#region Imports

using System.Collections.Generic;
using GraphicsEngine.Wavefront.Loaders;

#endregion

namespace GraphicsEngine.Graphics
{
	public interface IWavefrontObjToMeshConverter
	{
		IEnumerable<Mesh> ConvertToMesh(IWavefrontObj wavefrontObj);
	}
}