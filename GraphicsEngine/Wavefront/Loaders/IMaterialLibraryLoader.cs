#region Imports

using System.IO;

#endregion

namespace GraphicsEngine.Wavefront.Loaders
{
	public interface IMaterialLibraryLoader
	{
		void Load(Stream lineStream);
	}
}