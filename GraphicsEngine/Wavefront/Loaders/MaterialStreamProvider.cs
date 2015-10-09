#region Imports

using System.IO;

#endregion

namespace GraphicsEngine.Wavefront.Loaders
{
	public class MaterialStreamProvider : IMaterialStreamProvider
	{
		public Stream Open(string materialFilePath)
		{
			return File.Open(materialFilePath, FileMode.Open, FileAccess.Read);
		}
	}

	public class MaterialNullStreamProvider : IMaterialStreamProvider
	{
		public Stream Open(string materialFilePath)
		{
			return null;
		}
	}
}