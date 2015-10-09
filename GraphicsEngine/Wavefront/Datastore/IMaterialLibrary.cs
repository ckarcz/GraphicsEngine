#region Imports

using GraphicsEngine.Wavefront.Models;

#endregion

namespace GraphicsEngine.Wavefront.Datastore
{
	public interface IMaterialLibrary
	{
		void Push(Material material);
	}
}