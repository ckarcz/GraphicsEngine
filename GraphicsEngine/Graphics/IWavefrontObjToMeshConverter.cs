#region Imports

using System.Collections.Generic;
using GraphicsEngine.Wavefront.Loaders;

#endregion

namespace GraphicsEngine.Graphics
{
	public interface IWavefrontObjToMeshConverter
	{
		IList<IMesh> ConvertToMesh(IWavefrontObj wavefrontObj);
	}
}