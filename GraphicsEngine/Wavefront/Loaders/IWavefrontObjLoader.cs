#region Imports

using System.IO;

#endregion

namespace GraphicsEngine.Wavefront.Loaders
{
	public interface IWavefrontObjLoader
	{
		IWavefrontObj LoadWavefrontObj(Stream lineStream);
	}
}