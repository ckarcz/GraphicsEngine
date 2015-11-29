#region Imports

using System.Collections.Generic;
using GraphicsEngine.Wavefront.Loaders;

#endregion

namespace GraphicsEngine.Graphics
{
	public interface IWavefrontObjConverter
	{
		IEnumerable<IMesh> ConvertToMesh(IWavefrontObj wavefrontObj);
	}
}