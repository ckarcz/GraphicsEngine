#region Imports

using System.Collections.Generic;
using GraphicsEngine.Wavefront.Loaders;

#endregion

namespace GraphicsEngine.Graphics
{
	public interface IWavefrontObjConverter
	{
		IEnumerable<Mesh> ConvertToMesh(IWavefrontObj wavefrontObj);
	}
}