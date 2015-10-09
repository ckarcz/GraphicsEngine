#region Imports

using System.IO;

#endregion

namespace GraphicsEngine.Wavefront.Loaders
{
	public interface IMaterialStreamProvider
	{
		Stream Open(string materialFilePath);
	}
}